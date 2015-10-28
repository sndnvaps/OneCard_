using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL.IBLL.HHZX.UserInfomation.CardUserInfo;
using BLL.IBLL.HHZX.UserCard;
using BLL.IBLL.HHZX.ConsumeAccount;
using BLL.Factory.HHZX;
using Model.General;
using Model.HHZX.UserCard;
using PaymentEquipment.Entity;
using Model.HHZX.ComsumeAccount;
using Model.HHZX.Report;
using Microsoft.Reporting.WebForms;
using Common;
using System.Configuration;
using WindowUI.HHZX.ClassLibrary.Public;
using WindowUI.HHZX.UserCard.Recharge;

namespace WindowUI.HHZX.UserCard.Refund
{
    /// <summary>
    /// 卡实时退款
    /// </summary>
    public partial class frmRefundRealTimeDetail : BaseReaderForm
    {
        private ICardUserMasterBL _ICardUserMasterBL;
        private IUserCardPairBL _IUserCardPairBL;
        private IRechargeRecordBL _IRechargeRecordBL;
        private ISystemAccountDetailBL _ISystemAccountDetailBL;
        private IPreConsumeRecordBL _IPreConsumeRecordBL;
        private UserCardPair_ucp_Info _PairInfo;
        private ICardUserAccountBL _ICardUserAccountBL;

        public frmRefundRealTimeDetail()
            : base()
        {
            InitializeComponent();

            this._ICardUserMasterBL = MasterBLLFactory.GetBLL<ICardUserMasterBL>(MasterBLLFactory.CardUserMaster);
            this._IUserCardPairBL = MasterBLLFactory.GetBLL<IUserCardPairBL>(MasterBLLFactory.UserCardPair);
            this._IRechargeRecordBL = MasterBLLFactory.GetBLL<IRechargeRecordBL>(MasterBLLFactory.RechargeRecord);
            this._ISystemAccountDetailBL = MasterBLLFactory.GetBLL<ISystemAccountDetailBL>(MasterBLLFactory.SystemAccountDetail);
            this._IPreConsumeRecordBL = MasterBLLFactory.GetBLL<IPreConsumeRecordBL>(MasterBLLFactory.PreConsumeRecord);
            this._ICardUserAccountBL = MasterBLLFactory.GetBLL<ICardUserAccountBL>(MasterBLLFactory.CardUserAccount);
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

        private void btnRead_Click(object sender, EventArgs e)
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
                        this._PairInfo = null;
                        pairInfo = null;

                        this.Cursor = Cursors.Default;
                        resetAllControls();
                        this.ShowWarningMessage("此卡未被发卡。");
                        return;
                    }
                    else
                    {
                        listPairInfo = listPairInfo.OrderByDescending(x => x.ucp_dPairTime).ToList();
                        this._PairInfo = listPairInfo[0];
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
                        computePreCost(pairInfo);

                        tbxDesc.Enabled = true;
                        tbxDesc.Text = string.Empty;
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
        /// 计算预付款欠款值
        /// </summary>
        /// <param name="pairInfo">发卡资料</param>
        private void computePreCost(UserCardPair_ucp_Info pairInfo)
        {
            //计算未付的预付款金额
            List<PreConsumeRecord_pcs_Info> listPreCost = this._IPreConsumeRecordBL.SearchRecords(new PreConsumeRecord_pcs_Info()
            {
                pcs_cUserID = pairInfo.ucp_cCUSID
            });
            listPreCost = listPreCost.Where(x =>
                x.pcs_lIsSettled == false
                && x.pcs_cConsumeType != Common.DefineConstantValue.ConsumeMoneyFlowType.IndeterminateCost.ToString()
                && x.pcs_cConsumeType != Common.DefineConstantValue.ConsumeMoneyFlowType.AdvanceMealCost.ToString()
                && x.pcs_cConsumeType != Common.DefineConstantValue.ConsumeMoneyFlowType.HedgeFund.ToString()
                ).ToList();
            if (listPreCost != null)
            {
                if (listPreCost.Count > 0)
                {
                    decimal fSumPreCost = listPreCost.Sum(x => x.pcs_fCost);
                    labPreCost.Text = Math.Round(fSumPreCost, 2).ToString();
                    btnPreCostDetail.Enabled = true;
                    ckbPreCost.Enabled = true;
                }
                else
                {
                    labPreCost.Text = "0.00";
                }

            }
            else
            {
                labPreCost.Text = "未付金额信息异常";
            }
        }

        private void btnConfirmRefund_Click(object sender, EventArgs e)
        {
            bool resUkey = base.CheckUKey();
            if (!resUkey)
            {
                return;
            }
            if (base._CurrentCardInfo == null)
            {
                this.ShowWarningMessage("请重新读卡。");
                btnRead.Focus();
                return;
            }
            if (string.IsNullOrEmpty(tbxRefundMoney.Text.Trim()))
            {
                this.ShowWarningMessage("请输入退款金额。");
                tbxRefundMoney.Focus();
                tbxRefundMoney.SelectAll();
                return;
            }

            decimal fRefund;
            #region 处理退款金额

            bool res = decimal.TryParse(tbxRefundMoney.Text.Trim(), out fRefund);
            if (!res)
            {
                this.ShowWarningMessage("请检查退款金额的格式。");
                tbxRefundMoney.Focus();
                tbxRefundMoney.SelectAll();
                return;
            }
            if (fRefund <= 0)
            {
                this.ShowWarningMessage("退款金额需大于0，请重新输入。");
                tbxRefundMoney.Focus();
                tbxRefundMoney.SelectAll();
                return;
            }
            else if (fRefund > Common.DefineConstantValue.MaxRechargeVal)
            {
                this.ShowWarningMessage("充值金额不能大于" + Common.DefineConstantValue.MaxRechargeVal.ToString() + "，请重新输入。");
                tbxRefundMoney.Focus();
                tbxRefundMoney.SelectAll();
                return;
            }

            #endregion

            if (string.IsNullOrEmpty(tbxDesc.Text))
            {
                ShowWarningMessage("请先输入退款原因。");
                tbxDesc.Focus();
                tbxDesc.SelectAll();
                return;
            }

            decimal fPreCost = decimal.Zero;
            if (ckbPreCost.Checked)
            {
                fPreCost = decimal.Parse(labPreCost.Text);
            }

            dlgConfirmInfo dlg = new dlgConfirmInfo();
            dlg.CardInfo = base._CurrentCardInfo;
            dlg.IsPrinted = cbxPrint.Checked;
            dlg.RefundMoney = fRefund;
            dlg.UserInfo = base._CurrentCardUserInfo;
            dlg.PreCostMoney = fPreCost;
            dlg.IsPrinted = cbxPrint.Checked;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                //卡信息再次验证
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
                    fRefund = fRefund - Math.Abs(fPreCost);//实际退款金额 = 用户键入的退款额 - 需交付的欠款额
                    //先进行物理卡充值
                    ReturnValueInfo rvInfo = this._Reader.Recharge(base._CardInfoSection, base._SectionPwd, fRefund);
                    if (rvInfo.boolValue && !rvInfo.isError)
                    {
                        RechargeRecord_rcr_Info rechargeRecord = new RechargeRecord_rcr_Info();
                        #region 填充实体

                        rechargeRecord.rcr_cRecordID = Guid.NewGuid();
                        rechargeRecord.rcr_cUserID = this._CurrentCardUserInfo.cus_cRecordID;
                        rechargeRecord.rcr_cCardID = chkCardInfo.CardSourceID;
                        rechargeRecord.rcr_cRechargeType = DefineConstantValue.ConsumeMoneyFlowType.Refund_CardPersonalRealTime.ToString();
                        rechargeRecord.rcr_cStatus = DefineConstantValue.ConsumeMoneyFlowStatus.Finished.ToString();
                        rechargeRecord.rcr_dRechargeTime = DateTime.Now;
                        rechargeRecord.rcr_fRechargeMoney = fRefund;
                        rechargeRecord.rcr_fBalance = base._CurrentCardInfo.CardBalance + fRefund;//退款后卡余额 = 当前卡余额 + 退款金额
                        rechargeRecord.PreCostMoney = fPreCost;//未结算的欠款
                        rechargeRecord.rcr_cDesc = tbxDesc.Text;
                        rechargeRecord.rcr_cAdd = this.UserInformation.usm_cUserLoginID;
                        rechargeRecord.rcr_cLast = rechargeRecord.rcr_cAdd;
                        rechargeRecord.rcr_dLastDate = rechargeRecord.rcr_dRechargeTime;
                        rechargeRecord.IsNeedSyncAccount = ckbPreCost.Checked;

                        #endregion

                        //卡退款成功后，将退款信息写入充值记录表
                        rvInfo = this._IRechargeRecordBL.InsertRechargeRecord(rechargeRecord);

                        if (rvInfo.boolValue && !rvInfo.isError)
                        {
                            //成功录入退款记录后提示成功
                            this.Cursor = Cursors.Default;
                            this.ShowInformationMessage("退款成功。" + Environment.NewLine + "退款用户：" + this._CurrentCardUserInfo.cus_cChaName + "，退款金额：" + fRefund.ToString() + "元");

                            if (cbxPrint.Checked)
                            {
                                RechargeDetail rdInfo = new RechargeDetail();
                                //rdInfo.CardNo = Int32.Parse(this.labCardNo.Text);
                                rdInfo.OperationTime = System.DateTime.Now;
                                rdInfo.Operator = this.UserInformation.usm_cUserLoginID;
                                rdInfo.RechargeValue = fRefund;
                                rdInfo.UserName = this.labUserName.Text;
                                rdInfo.ClassName = this.labClassName.Text;
                                //打印小票
                                PrintTicket(rdInfo);
                            }

                            resetAllControls();
                            btnRead.Focus();
                            return;
                        }
                        else
                        {
                            ShowErrorMessage("上传充值记录失败，需要进行回滚扣费，请摆放好卡片后，点击确定。");
                            ConsumeCardInfo cardInfoRollback = this._Reader.ReadCardInfo(base._CardInfoSection, base._SectionPwd);
                            if (cardInfoRollback.CardSourceID != chkCardInfo.CardSourceID)
                            {
                                ShowWarningMessage("卡片信息不符合，请核对后重新放卡，原卡片卡号为：" + chkCardInfo.CardNo.ToString() + ",卡信息为：" + chkCardInfo.Name);
                                cardInfoRollback = this._Reader.ReadCardInfo(base._CardInfoSection, base._SectionPwd);
                                if (cardInfoRollback.CardSourceID == chkCardInfo.CardSourceID)
                                {
                                    //录入退款记录失败，则需要将原先充入的卡金额扣除，如果卡已被取走，则需等待后台自动同步金额
                                    rvInfo = this._Reader.Recharge(base._CardInfoSection, base._SectionPwd, fRefund * -1);
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
                                rvInfo = this._Reader.Recharge(base._CardInfoSection, base._SectionPwd, fRefund * -1);
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

                            resetAllControls();
                            this.Cursor = Cursors.Default;
                            this.ShowInformationMessage("实时卡退款失败。" + rvInfo.messageText);
                            btnRead.Focus();
                            return;
                        }
                    }
                    else
                    {
                        resetAllControls();
                        this.Cursor = Cursors.Default;
                        this.ShowInformationMessage("实时卡退款失败。" + rvInfo.messageText);
                        btnRead.Focus();
                        return;
                    }
                }
                catch (Exception ex)
                {
                    this.Cursor = Cursors.Default;
                    this.ShowErrorMessage("退款失败。" + Environment.NewLine + ex);
                    btnRead.Focus();
                    return;
                }
            }
        }

        /// <summary>
        /// 打印小票
        /// </summary>
        /// <param name="rdInfo"></param>
        private void PrintTicket(RechargeDetail rdInfo)
        {
            List<RechargeDetail> rdList = new List<RechargeDetail>();

            rdList.Add(rdInfo);

            LocalReport lr = new LocalReport();
            ReportDataSource rds = new ReportDataSource("RechargeDetail", rdList);
            lr.ReportPath = DefineConstantValue.ReportFileBasePath + @"RechargeTicket.rdlc";
            lr.DataSources.Add(rds);

            string printName = ConfigurationSettings.AppSettings["TicketPrintName"];

            TicketPrint tp = new TicketPrint();
            tp.PrintTicket(lr, printName);
        }

        /// <summary>
        /// 重置所有控件
        /// </summary>
        private void resetAllControls()
        {
            labCardNo.Text = string.Empty.PadLeft(8, '0');
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
            tbxDesc.Enabled = false;
            tbxDesc.Text = string.Empty;
            ckbPreCost.Enabled = false;
            ckbPreCost.Checked = true;
        }

        private void tbxRefundMoney_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbxRefundMoney.Text.Trim()))
            {
                return;
            }
            try
            {
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
            catch (Exception ex)
            {
                tbxRefundMoney.Text = "0.00";
                tbxRefundMoney.Focus();
                tbxRefundMoney.SelectAll();
            }
        }

        private void frmRefundRealTimeDetail_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (btnConfirmRefund.Enabled)
                {
                    btnConfirmRefund_Click(btnConfirmRefund, null);
                }
                else if (btnRead.Enabled)
                {
                    btnRead_Click(btnRead, null);
                }
            }
        }

        private void btnPreCostDetail_Click(object sender, EventArgs e)
        {
            dlgPreCostDetail dlgDetail = new dlgPreCostDetail(this._CurrentCardUserInfo);
            dlgDetail.ShowDialog();
        }

        //private void PrintTicket(RechargeDetail rdInfo)
        //{
        //    List<RechargeDetail> rdList = new List<RechargeDetail>();

        //    rdList.Add(rdInfo);

        //    LocalReport lr = new LocalReport();
        //    ReportDataSource rds = new ReportDataSource("RechargeDetail", rdList);
        //    lr.ReportPath = DefineConstantValue.ReportFileBasePath + @"RechargeTicket.rdlc";
        //    lr.DataSources.Add(rds);

        //    TicketPrint tp = new TicketPrint();
        //    tp.PrintTicket(lr, "BTP-N58(S)");
        //}
    }
}
