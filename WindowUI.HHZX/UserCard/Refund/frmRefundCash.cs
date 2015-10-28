using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Model.HHZX.UserInfomation.CardUserInfo;
using BLL.IBLL.HHZX.ConsumeAccount;
using BLL.IBLL.HHZX.UserCard;
using BLL.Factory.HHZX;
using Model.HHZX.UserCard;
using Model.HHZX.ComsumeAccount;
using Model.General;
using WindowUI.HHZX.UserInformation.CardUserInfo;
using WindowUI.HHZX.UserCard.Recharge;
using PaymentEquipment.Entity;

namespace WindowUI.HHZX.UserCard.Refund
{
    /// <summary>
    /// 个人现金退款
    /// </summary>
    public partial class frmRefundCash : BaseReaderForm
    {
        /// <summary>
        /// 当前用户发卡信息
        /// </summary>
        private UserCardPair_ucp_Info _CurrentPair;

        private ICardUserAccountBL _ICardUserAccountBL;
        private IUserCardPairBL _IUserCardPairBL;
        private ISystemAccountDetailBL _ISystemAccountDetailBL;
        private IPreConsumeRecordBL _IPreConsumeRecordBL;
        private IRechargeRecordBL _IRechargeRecordBL;

        public frmRefundCash()
            : base()
        {
            InitializeComponent();

            this._ICardUserAccountBL = MasterBLLFactory.GetBLL<ICardUserAccountBL>(MasterBLLFactory.CardUserAccount);
            this._IUserCardPairBL = MasterBLLFactory.GetBLL<IUserCardPairBL>(MasterBLLFactory.UserCardPair);
            this._ISystemAccountDetailBL = MasterBLLFactory.GetBLL<ISystemAccountDetailBL>(MasterBLLFactory.SystemAccountDetail);
            this._IPreConsumeRecordBL = MasterBLLFactory.GetBLL<IPreConsumeRecordBL>(MasterBLLFactory.PreConsumeRecord);
            this._IRechargeRecordBL = MasterBLLFactory.GetBLL<IRechargeRecordBL>(MasterBLLFactory.RechargeRecord);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            labReaderState.Click += new EventHandler(base.labReaderState_Click);

            if (base._IsConnected)
            {
                labReaderState.Text = "读卡器已连接";
            }
            else
            {
                labReaderState.Text = "读卡器未连接";
            }
            resetAllControls();
        }

        private void resetAllControls()
        {
            labUserName.Text = string.Empty;
            labClassName.Text = string.Empty;
            labStuNum.Text = string.Empty;
            labCardBalance.Text = "0.00";
            labAccountBalance.Text = "0.00";
            labAccountSyncTime.Text = "未同步";
            tbxRefundMoney.Text = "0.00";
            tbxRefundMoney.Enabled = false;
            btnConfirmRefund.Enabled = false;
            labPreCost.Text = "0.00";
            btnPreCostDetail.Enabled = false;
            cbxPrint.Enabled = false;
            tbxRefundDesc.Text = string.Empty;
            tbxRefundDesc.Enabled = false;

            btnReadCard.Focus();
        }

        private void btnConfirmRefund_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbxRefundMoney.Text.Trim()))
            {
                this.ShowWarningMessage("请输入退款金额。");
                tbxRefundMoney.Focus();
                return;
            }
            decimal fRefund;//退款额
            bool res = decimal.TryParse(tbxRefundMoney.Text.Trim(), out fRefund);
            if (!res)
            {
                this.ShowWarningMessage("请检查退款金额的格式。");
                tbxRefundMoney.Focus();
                return;
            }
            if (fRefund <= 0)
            {
                this.ShowWarningMessage("退款金额需大于0，请重新输入。");
                tbxRefundMoney.Focus();
                return;
            }
            else if (fRefund > Common.DefineConstantValue.MaxRechargeVal)
            {
                this.ShowWarningMessage("退款金额不能大于" + Common.DefineConstantValue.MaxRechargeVal.ToString() + "，请重新输入。");
                tbxRefundMoney.Focus();
                tbxRefundMoney.SelectAll();
                return;
            }

            decimal fCardBalance = this._CurrentCardInfo.CardBalance;//卡内余额
            decimal fPreCost = decimal.Parse(labPreCost.Text);//未结算预付款
            decimal fAdvance = decimal.Zero;//透支额

            //************计算卡内金额是否足以退款*******************
            #region 计算卡内金额是否足以退款

            if (base._CurrentCardUserInfo.cus_cIdentityNum == Common.DefineConstantValue.CodeMasterDefine.KEY2_SIOT_CardUserIdentity_Student)
            {
                List<RechargeRecord_rcr_Info> listAdvance = this._IRechargeRecordBL.SearchRecords(new RechargeRecord_rcr_Info()
                {
                    rcr_cUserID = base._CurrentCardUserInfo.cus_cRecordID,
                    rcr_cRechargeType = Common.DefineConstantValue.ConsumeMoneyFlowType.Recharge_AdvanceMoney.ToString(),
                });
                listAdvance = listAdvance.OrderByDescending(x => x.rcr_dRechargeTime).ToList();
                if (listAdvance != null && listAdvance.Count > 0)
                {
                    fAdvance = listAdvance[0].rcr_fRechargeMoney;
                }
            }

            if (ckbPreCost.Checked)
            {
                if (fCardBalance - fAdvance - Math.Abs(fPreCost) < fRefund)
                {
                    ShowWarningMessage("卡余额不足以支付本次退款。");
                    return;
                }
            }
            else
            {
                if (fCardBalance - fAdvance < fRefund)
                {
                    ShowWarningMessage("卡余额不足以支付本次退款。");
                    return;
                }
            }

            #endregion

            if (string.IsNullOrEmpty(tbxRefundDesc.Text))
            {
                ShowWarningMessage("请先输入退款原因。");
                tbxRefundDesc.Focus();
                tbxRefundDesc.SelectAll();
                return;
            }

            if (base._CurrentCardUserInfo == null)
            {
                this.ShowWarningMessage("当前卡用户信息异常，请重新读卡。");
                btnReadCard.Focus();
                return;
            }
            if (base.UserInformation == null)
            {
                this.ShowWarningMessage("当前操作用户信息异常，请重新登录。");
                return;
            }

            dlgConfirmInfo dlg = new dlgConfirmInfo();
            dlg.IsPrinted = cbxPrint.Checked;
            dlg.RefundMoney = fRefund * -1;
            if (ckbPreCost.Checked)
            {
                dlg.PreCostMoney = Math.Abs(fPreCost) * -1;
            }
            else
            {
                dlg.PreCostMoney = 0;
            }
            dlg.UserInfo = this._CurrentCardUserInfo;
            dlg.CardInfo = base._CurrentCardInfo;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                ConsumeCardInfo chkCardInfo = this._Reader.ReadCardInfo(base._CardInfoSection, base._SectionPwd);
                if (chkCardInfo == null || (chkCardInfo != null && chkCardInfo.CardSourceID != base._CurrentCardInfo.CardSourceID))
                {
                    this.ShowWarningMessage("卡片信息已变更，请重新读卡后操作。");
                    resetAllControls();
                    return;
                }

                this.Cursor = Cursors.WaitCursor;
                try
                {
                    //物理卡充值
                    ReturnValueInfo rvInfo = this._Reader.Recharge(base._CardInfoSection, base._SectionPwd, (fRefund + Math.Abs(dlg.PreCostMoney)) * -1);
                    if (rvInfo.boolValue && !rvInfo.isError)
                    {
                        RechargeRecord_rcr_Info rechargeInfo = new RechargeRecord_rcr_Info();
                        rechargeInfo.rcr_cRecordID = Guid.NewGuid();
                        rechargeInfo.rcr_cAdd = base.UserInformation.usm_cUserLoginID;
                        rechargeInfo.rcr_cLast = base.UserInformation.usm_cUserLoginID;
                        rechargeInfo.rcr_cCardID = chkCardInfo.CardSourceID;
                        rechargeInfo.rcr_cDesc = tbxRefundDesc.Text;
                        rechargeInfo.rcr_cRechargeType = Common.DefineConstantValue.ConsumeMoneyFlowType.Refund_PersonalCash.ToString();
                        rechargeInfo.rcr_cStatus = Common.DefineConstantValue.ConsumeMoneyFlowStatus.Finished.ToString();
                        rechargeInfo.rcr_cUserID = base._CurrentCardUserInfo.cus_cRecordID;
                        rechargeInfo.rcr_dLastDate = DateTime.Now;
                        rechargeInfo.rcr_dRechargeTime = DateTime.Now;
                        rechargeInfo.rcr_fBalance = fCardBalance - (fRefund + Math.Abs(dlg.PreCostMoney));
                        rechargeInfo.rcr_fRechargeMoney = fRefund;
                        if (ckbPreCost.Checked)
                        {
                            rvInfo = this._IRechargeRecordBL.CashRefund(rechargeInfo, dlg.PreCostMoney);
                        }
                        else
                        {
                            rvInfo = this._IRechargeRecordBL.CashRefund(rechargeInfo, 0);
                        }

                        if (rvInfo.boolValue && !rvInfo.isError)
                        {
                            this.Cursor = Cursors.Default;
                            this.ShowInformationMessage("退款成功。" + Environment.NewLine + "退款用户：" + this._CurrentCardUserInfo.cus_cChaName + "，退款金额：" + fRefund.ToString() + "元");

                            resetAllControls();
                            return;
                        }
                        else
                        {
                            #region  退款回滚

                            ShowErrorMessage("上传退款记录失败，需要进行回滚扣费，请摆放好卡片后，点击确定。");
                            ConsumeCardInfo cardInfoRollback = this._Reader.ReadCardInfo(base._CardInfoSection, base._SectionPwd);
                            if (cardInfoRollback.CardSourceID != chkCardInfo.CardSourceID)
                            {
                                ShowWarningMessage("卡片信息不符合，请核对后重新放卡，原卡片卡号为：" + chkCardInfo.CardNo.ToString() + ",卡信息为：" + chkCardInfo.Name);
                                cardInfoRollback = this._Reader.ReadCardInfo(base._CardInfoSection, base._SectionPwd);
                                if (cardInfoRollback.CardSourceID == chkCardInfo.CardSourceID)
                                {
                                    //录入退款记录失败，则需要将原先充入的卡金额扣除，如果卡已被取走，则需等待后台自动同步金额
                                    rvInfo = this._Reader.Recharge(base._CardInfoSection, base._SectionPwd, fRefund + Math.Abs(dlg.PreCostMoney));
                                    if (rvInfo.boolValue && !rvInfo.isError)
                                    {
                                        ShowInformationMessage("回滚扣费成功，可重新进行充值。");
                                        return;
                                    }
                                    else
                                    {
                                        ShowWarningMessage("回滚扣费失败，请联系系统管理员处理问题卡片。");
                                    }
                                }
                                else
                                {
                                    ShowWarningMessage("核对信息失败，请联系系统管理员处理问题卡片。");
                                }
                            }
                            else
                            {
                                rvInfo = this._Reader.Recharge(base._CardInfoSection, base._SectionPwd, fRefund + Math.Abs(dlg.PreCostMoney));
                                if (rvInfo.boolValue && !rvInfo.isError)
                                {
                                    ShowInformationMessage("回滚扣费成功，可重新进行充值。");
                                    return;
                                }
                                else
                                {
                                    ShowWarningMessage("回滚扣费失败，请联系系统管理员处理问题卡片。");
                                }
                            }
                            #endregion
                        }
                        resetAllControls();
                        this.Cursor = Cursors.Default;
                        this.ShowWarningMessage("现金退款失败。" + rvInfo.messageText);
                        return;
                    }
                    else
                    {
                        resetAllControls();
                        this.Cursor = Cursors.Default;
                        this.ShowWarningMessage("现金退款失败。" + rvInfo.messageText);
                        return;
                    }

                }
                catch (Exception ex)
                {
                    this.Cursor = Cursors.Default;
                    this.ShowErrorMessage("退款失败。" + Environment.NewLine + ex);
                    return;
                }
            }
        }

        private void frmRechargeOfflineSingle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (btnConfirmRefund.Enabled)
                {
                    btnConfirmRefund_Click(null, null);
                }
            }

        }

        private void tbxRefundMoney_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbxRefundMoney.Text.Trim()))
            {
                return;
            }
            decimal fRecharge = Convert.ToDecimal(tbxRefundMoney.Text);
            if (fRecharge > 0)
            {
                btnConfirmRefund.Enabled = true;
                cbxPrint.Enabled = true;
            }
            else
            {
                btnConfirmRefund.Enabled = false;
                cbxPrint.Enabled = false;
            }
        }

        private void btnPreCostDetail_Click(object sender, EventArgs e)
        {
            dlgPreCostDetail dlgDetail = new dlgPreCostDetail(this._CurrentCardUserInfo);
            dlgDetail.ShowDialog();
        }

        private void btnReadCard_Click(object sender, EventArgs e)
        {
            if (this._IsConnected)
            {
                bool resUkey = base.CheckUKey();
                if (!resUkey)
                {
                    return;
                }

                this.Cursor = Cursors.WaitCursor;
                resetAllControls();

                ConsumeCardInfo cardInfo = this._Reader.ReadCardInfo(base._CardInfoSection, base._SectionPwd);
                if (cardInfo != null)
                {
                    this._CurrentCardInfo = cardInfo;

                    labCardBalance.Text = cardInfo.CardBalance.ToString();
                    labCardNo.Text = cardInfo.CardNo.PadLeft(8, '0');
                    string strCardID = cardInfo.CardSourceID;

                    //根据原始卡号查询发卡信息
                    UserCardPair_ucp_Info searchInfo = new UserCardPair_ucp_Info();
                    searchInfo.ucp_cCardID = strCardID;
                    searchInfo.ucp_iCardNo = int.Parse(cardInfo.CardNo);

                    List<UserCardPair_ucp_Info> listPairInfo = this._IUserCardPairBL.SearchRecords(searchInfo);
                    listPairInfo = listPairInfo.Where(x => x.ucp_cUseStatus != Common.DefineConstantValue.ConsumeCardStatus.Returned.ToString()).ToList();
                    UserCardPair_ucp_Info pairInfo = null;
                    if (listPairInfo == null || (listPairInfo != null && listPairInfo.Count < 1))
                    {
                        this._CurrentPair = null;
                        pairInfo = null;

                        this.Cursor = Cursors.Default;
                        resetAllControls();
                        this.ShowWarningMessage("此卡未被发卡。");
                        return;
                    }
                    else
                    {
                        listPairInfo = listPairInfo.OrderByDescending(x => x.ucp_dPairTime).ToList();
                        this._CurrentPair = listPairInfo[0];
                        pairInfo = listPairInfo[0];
                        if (pairInfo.ucp_cUseStatus == Common.DefineConstantValue.ConsumeCardStatus.LoseReporting.ToString())
                        {
                            this.Cursor = Cursors.Default;
                            resetAllControls();
                            this.ShowWarningMessage("此卡正在挂失中，请解挂后重试。");
                            return;
                        }
                    }

                    if (pairInfo.CardOwner != null)
                    {
                        base._CurrentCardUserInfo = pairInfo.CardOwner;
                        base._CurrentCardInfo = cardInfo;

                        labUserName.Text = pairInfo.CardOwner.cus_cChaName;
                        labStuNum.Text = pairInfo.CardOwner.cus_cStudentID;
                        labClassName.Text = pairInfo.CardOwner.ClassInfo == null ? pairInfo.CardOwner.DeptInfo.dpm_cName : pairInfo.CardOwner.ClassInfo.csm_cClassName;

                        // 获取用户账户资料
                        getAccountInfos();
                        //计算未结算款项
                        computePreCost();

                        tbxRefundDesc.Enabled = true;
                        tbxRefundMoney.Enabled = true;
                        tbxRefundMoney.Focus();
                        tbxRefundMoney.SelectAll();
                    }
                    else
                    {
                        base._CurrentCardUserInfo = null;

                        resetAllControls();
                        this.Cursor = Cursors.Default;
                        this.ShowWarningMessage("获取消费卡用户信息异常，请重试。");
                        return;
                    }
                }
                else
                {
                    this.Cursor = Cursors.Default;
                    resetAllControls();
                    this.ShowWarningMessage("读卡信息失败，请重试。");
                    return;
                }
            }
            else
            {
                this.Cursor = Cursors.Default;
                resetAllControls();
                this.ShowWarningMessage("未连接到读写器，请检查设备连通性。");
                return;
            }

            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// 获取账户信息
        /// </summary>
        private void getAccountInfos()
        {
            List<CardUserAccount_cua_Info> listAccountInfo = this._ICardUserAccountBL.SearchRecords(new CardUserAccount_cua_Info()
            {
                cua_cCUSID = base._CurrentCardUserInfo.cus_cRecordID
            });
            if (listAccountInfo != null && listAccountInfo.Count > 0)
            {
                labAccountBalance.Text = listAccountInfo[0].cua_fCurrentBalance.ToString();
                labAccountSyncTime.Text = listAccountInfo[0].cua_dLastSyncTime.ToString("yyyy-MM-dd HH:mm:ss");
            }
        }

        /// <summary>
        /// 计算未结算款项
        /// </summary>
        private void computePreCost()
        {
            List<PreConsumeRecord_pcs_Info> listPreCost = this._IPreConsumeRecordBL.SearchRecords(new PreConsumeRecord_pcs_Info()
            {
                pcs_cUserID = base._CurrentCardUserInfo.cus_cRecordID
            });
            listPreCost = listPreCost.Where(x =>
                x.pcs_lIsSettled == false
                && x.pcs_cConsumeType != Common.DefineConstantValue.ConsumeMoneyFlowType.IndeterminateCost.ToString()
                && x.pcs_cConsumeType != Common.DefineConstantValue.ConsumeMoneyFlowType.AdvanceMealCost.ToString()
                && x.pcs_cConsumeType != Common.DefineConstantValue.ConsumeMoneyFlowType.HedgeFund.ToString()
                ).ToList();
            if (listPreCost != null && listPreCost.Count > 0)
            {
                decimal fSumPreCost = listPreCost.Sum(x => x.pcs_fCost);
                labPreCost.Text = Math.Round(fSumPreCost, 2).ToString();
                btnPreCostDetail.Enabled = true;
            }
        }
    }
}
