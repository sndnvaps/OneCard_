using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Model.General;
using PaymentEquipment.Entity;
using BLL.IBLL.HHZX.UserInfomation.CardUserInfo;
using BLL.Factory.HHZX;
using Model.HHZX.UserInfomation.CardUserInfo;
using Model.HHZX.UserCard;
using BLL.IBLL.HHZX.UserCard;
using BLL.IBLL.HHZX.ConsumeAccount;
using Model.HHZX.ComsumeAccount;
using Microsoft.Reporting.WebForms;
using Common;
using Model.HHZX.Report;
using WindowUI.HHZX.ClassLibrary.Public;
using BLL.IBLL.SysMaster;
using Model.SysMaster;
using BLL.IBLL.HHZX.MealBooking;
using Model.HHZX.MealBooking;
using BLL.IBLL.HHZX.ConsumerDevice;
using Model.HHZX.ConsumerDevice;
using PaymentEquipment.IDevice;
using PaymentEquipment.DeviceFactory;
using System.Net;
using System.Configuration;

namespace WindowUI.HHZX.UserCard.Recharge
{
    /*
     * 05-24 Donald FINISH：卡片实际充值，TODO：1、人员信息关联，2、充值记录日志；3、不正常充值回滚机制；4、显示此用户今天的定餐情况
     * 06-03 Donald FINISH : 1、人员信息关联，2、充值记录日志；3、不正常充值回滚机制；TODO：1、显示此用户今天的定餐情况，2、打印小票
     */
    /// <summary>
    /// 实时充值详细信息
    /// </summary>
    public partial class frmRechargeRealTimeDetail : BaseReaderForm
    {
        private ICardUserMasterBL _ICardUserMasterBL;
        private IUserCardPairBL _IUserCardPairBL;
        private IRechargeRecordBL _IRechargeRecordBL;
        private IPreConsumeRecordBL _IPreConsumeRecordBL;
        /// <summary>
        /// 当前用户发卡信息
        /// </summary>
        private UserCardPair_ucp_Info _CurrentPairInfo;
        private ICardUserAccountBL _ICardUserAccountBL;
        private ICardUserAccountDetailBL _ICardUserAccountDetailBL;
        private delegate void DLG_GetRechargeHistory();
        private delegate void DLG_GetMealTime();

        private TimeSpan? _tsBLLunch;
        private TimeSpan? _tsMealLunch;
        private TimeSpan? _tsBLSupper;
        private TimeSpan? _tsMealSupper;

        public frmRechargeRealTimeDetail()
            : base()
        {
            InitializeComponent();

            this._ICardUserMasterBL = MasterBLLFactory.GetBLL<ICardUserMasterBL>(MasterBLLFactory.CardUserMaster);
            this._IUserCardPairBL = MasterBLLFactory.GetBLL<IUserCardPairBL>(MasterBLLFactory.UserCardPair);
            this._IRechargeRecordBL = MasterBLLFactory.GetBLL<IRechargeRecordBL>(MasterBLLFactory.RechargeRecord);
            this._IPreConsumeRecordBL = MasterBLLFactory.GetBLL<IPreConsumeRecordBL>(MasterBLLFactory.PreConsumeRecord);
            this._ICardUserAccountBL = MasterBLLFactory.GetBLL<ICardUserAccountBL>(MasterBLLFactory.CardUserAccount);
            this._ICardUserAccountDetailBL = MasterBLLFactory.GetBLL<ICardUserAccountDetailBL>(MasterBLLFactory.CardUserAccountDetail);

            this._tsBLLunch = null;
            this._tsMealLunch = null;
            this._tsBLSupper = null;
            this._tsMealSupper = null;
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
            this.Invoke(new DLG_GetRechargeHistory(BindRechargeList));
            this.Invoke(new DLG_GetMealTime(BindMealTime));
        }

        /// <summary>
        /// 获取系统需要读取的就餐时段及黑名单上传时段
        /// </summary>
        void BindMealTime()
        {
            ICodeMasterBL bll = BLL.Factory.SysMaster.MasterBLLFactory.GetBLL<ICodeMasterBL>(BLL.Factory.SysMaster.MasterBLLFactory.CodeMaster_cmt);
            List<CodeMaster_cmt_Info> listMealTimeSpans = bll.SearchRecords(new CodeMaster_cmt_Info() { cmt_cKey1 = Common.DefineConstantValue.CodeMasterDefine.KEY1_MealTimeSpan });
            List<CodeMaster_cmt_Info> listBlacklistTImeSpans = bll.SearchRecords(new CodeMaster_cmt_Info() { cmt_cKey1 = Common.DefineConstantValue.CodeMasterDefine.KEY1_BWListUploadInterval });

            this._tsBLLunch = TimeSpan.Parse(listBlacklistTImeSpans.Find(x => x.cmt_cValue == Common.DefineConstantValue.MealType.Lunch.ToString()).cmt_cRemark);
            this._tsMealLunch = TimeSpan.Parse(listMealTimeSpans.Find(x => x.cmt_cKey2 == Common.DefineConstantValue.MealType.Lunch.ToString()).cmt_cRemark2);
            this._tsBLSupper = TimeSpan.Parse(listBlacklistTImeSpans.Find(x => x.cmt_cValue == Common.DefineConstantValue.MealType.Supper.ToString()).cmt_cRemark);
            this._tsMealSupper = TimeSpan.Parse(listMealTimeSpans.Find(x => x.cmt_cKey2 == Common.DefineConstantValue.MealType.Supper.ToString()).cmt_cRemark2);
        }

        /// <summary>
        /// 绑定当天充值流水账信息
        /// </summary>
        void BindRechargeList()
        {
            CardUserAccountDetail_cuad_Info rechargeInfo = new CardUserAccountDetail_cuad_Info();
            List<CardUserAccountDetail_cuad_Info> listRechargeDetail = this._ICardUserAccountDetailBL.SearchRecords(rechargeInfo, DateTime.Now, DateTime.Now);
            if (listRechargeDetail != null && listRechargeDetail.Count >= 0)
            {
                listRechargeDetail = listRechargeDetail.Where(x => x.cuad_cFlowType != Common.DefineConstantValue.ConsumeMoneyFlowType.Recharge_AdvanceMoney.ToString()).ToList();
                labRechargeAmount.Text = listRechargeDetail.Sum(x => x.FlowMoney).ToString();
                gbxAmount.Text = "现金充值记录：" + listRechargeDetail.Count.ToString() + " 条";
            }
            lvRechargeAmount.SetDataSource<CardUserAccountDetail_cuad_Info>(listRechargeDetail);
        }

        /// <summary>
        /// 获取账户信息
        /// </summary>
        private void GetAccountInfos()
        {
            CardUserAccount_cua_Info searchInfo = new CardUserAccount_cua_Info();
            searchInfo.cua_cCUSID = base._CurrentCardUserInfo.cus_cRecordID;
            List<CardUserAccount_cua_Info> listAccountInfo = this._ICardUserAccountBL.SearchRecords(searchInfo);
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
        private void ComputePreCost(UserCardPair_ucp_Info pairInfo)
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
                }
                else
                {
                    labPreCost.Text = "0.00";
                    btnPreCostDetail.Enabled = true;
                }

            }
            else
            {
                labPreCost.Text = "未付金额信息异常";
                btnPreCostDetail.Enabled = false;
            }
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
                        this._CurrentPairInfo = null;
                        pairInfo = null;

                        this.Cursor = Cursors.Default;
                        resetAllControls();
                        this.ShowWarningMessage("此卡未被发卡。");
                        btnRead.Focus();
                        return;
                    }
                    else
                    {
                        listPairInfo = listPairInfo.OrderByDescending(x => x.ucp_dPairTime).ToList();
                        this._CurrentPairInfo = listPairInfo[0];
                        pairInfo = listPairInfo[0];
                        if (pairInfo.ucp_cUseStatus == Common.DefineConstantValue.ConsumeCardStatus.LoseReporting.ToString())
                        {
                            this.Cursor = Cursors.Default;
                            resetAllControls();
                            this.ShowWarningMessage("此卡正在挂失中，请解挂后重试。");
                            btnRead.Focus();
                            return;
                        }
                    }

                    if (pairInfo.CardOwner != null)
                    {
                        base._CurrentCardUserInfo = pairInfo.CardOwner;
                        base._CurrentCardInfo = cardInfo;
                        base._CurrentCardUserInfo.PairInfo = pairInfo;

                        labUserName.Text = pairInfo.CardOwner.cus_cChaName;
                        labStuNum.Text = pairInfo.CardOwner.cus_cStudentID;
                        labClassName.Text = pairInfo.CardOwner.ClassInfo == null ? pairInfo.CardOwner.DeptInfo.dpm_cName : pairInfo.CardOwner.ClassInfo.csm_cClassName;


                        if (cbxMealDetail.Checked)
                        {
                            //显示停餐信息
                            ucMealBookingDetail.ShowData(pairInfo.CardOwner);
                        }
                        else
                        {
                            ucMealBookingDetail.BreakfastDesc = "未读";
                            ucMealBookingDetail.LunchDesc = "未读";
                            ucMealBookingDetail.SupperDesc = "未读";
                        }
                        // 获取用户账户资料
                        GetAccountInfos();
                        //计算未结算款项
                        ComputePreCost(pairInfo);
                        //显示未转账的总金额
                        GetWaitForTransRecharge(pairInfo.CardOwner);

                        tbxRechargeMoney.Enabled = true;
                        tbxRechargeMoney.Focus();
                        tbxRechargeMoney.SelectAll();
                    }
                    else
                    {
                        base._CurrentCardUserInfo = null;
                        ucMealBookingDetail.UserInfo = null;

                        resetAllControls();
                        this.Cursor = Cursors.Default;
                        this.ShowWarningMessage("获取消费卡用户信息异常，请重试。");
                        btnRead.Focus();
                        return;
                    }
                }
                else
                {
                    this.Cursor = Cursors.Default;
                    resetAllControls();
                    this.ShowWarningMessage("读卡信息失败，请重试。");
                    btnRead.Focus();
                    return;
                }
            }
            else
            {
                this.Cursor = Cursors.Default;
                resetAllControls();
                this.ShowWarningMessage("未连接到读写器，请检查设备连通性。");
                btnRead.Focus();
                return;
            }

            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// 显示等待转账的转账款总额
        /// </summary>
        /// <param name="cardUserMaster_cus_Info"></param>
        private void GetWaitForTransRecharge(CardUserMaster_cus_Info userInfo)
        {
            if (userInfo != null)
            {
                IPreRechargeRecordBL preRecBL = MasterBLLFactory.GetBLL<IPreRechargeRecordBL>(MasterBLLFactory.PreRechargeRecord);
                PreRechargeRecord_prr_Info searchInfo = new PreRechargeRecord_prr_Info();
                searchInfo.prr_cStatus = Common.DefineConstantValue.ConsumeMoneyFlowStatus.WaitForAcceptTransfer.ToString();
                searchInfo.prr_cUserID = userInfo.cus_cRecordID;
                List<PreRechargeRecord_prr_Info> listRecord = preRecBL.SearchRecords(searchInfo);
                if (listRecord != null && listRecord.Count > 0)
                {
                    labWaitForTrans.Text = listRecord.Sum(x => x.prr_fRechargeMoney).ToString();
                }
                else
                {
                    labWaitForTrans.Text = "0.00";
                }
            }
            else
            {
                labWaitForTrans.Text = "账户信息异常";
            }
        }

        private void btnConfirmRecharge_Click(object sender, EventArgs e)
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
            if (string.IsNullOrEmpty(tbxRechargeMoney.Text.Trim()))
            {
                this.ShowWarningMessage("请输入充值金额。");
                tbxRechargeMoney.Focus();
                tbxRechargeMoney.SelectAll();
                return;
            }

            decimal fRecharge;//实际充值金额
            #region 检查实际充值金额

            bool res = decimal.TryParse(tbxRechargeMoney.Text.Trim(), out fRecharge);
            if (!res)
            {
                this.ShowWarningMessage("请检查充值金额的格式。");
                tbxRechargeMoney.Focus();
                tbxRechargeMoney.SelectAll();
                return;
            }
            if (fRecharge <= 0)
            {
                this.ShowWarningMessage("充值金额需大于0，请重新输入。");
                tbxRechargeMoney.Focus();
                tbxRechargeMoney.SelectAll();
                return;
            }
            else if (fRecharge > Common.DefineConstantValue.MaxRechargeVal)
            {
                this.ShowWarningMessage("充值金额不能大于" + Common.DefineConstantValue.MaxRechargeVal.ToString() + "，请重新输入。");
                tbxRechargeMoney.Focus();
                tbxRechargeMoney.SelectAll();
                return;
            }

            #endregion

            decimal fPreCost;//当次欠费，显示为负数
            #region 检查当次欠费

            bool resPreCost = decimal.TryParse(labPreCost.Text, out fPreCost);
            if (!resPreCost)
            {
                this.ShowWarningMessage("充值金额需大于0，请重新输入。");
                btnRead.Focus();
                return;
            }

            #endregion

            if (base._CurrentCardInfo == null)
            {
                ShowWarningMessage("原卡信息异常，请重新读卡确认。");
                btnRead.Focus();
                return;
            }
            if (this._CurrentPairInfo == null)
            {
                ShowWarningMessage("卡信息异常，请重新读卡确认。");
                btnRead.Focus();
                return;
            }
            if (base._CurrentCardUserInfo == null)
            {
                ShowWarningMessage("卡用户信息异常，请重新读卡确认");
                btnRead.Focus();
                return;
            }

            decimal fAdvanceMoney = decimal.Zero;
            RechargeRecord_rcr_Info searchAdvance = new RechargeRecord_rcr_Info();
            //searchAdvance.rcr_cCardID = this._CurrentCardInfo.CardSourceID;
            searchAdvance.rcr_cUserID = this._CurrentCardUserInfo.cus_cRecordID;
            searchAdvance.rcr_cRechargeType = Common.DefineConstantValue.ConsumeMoneyFlowType.Recharge_AdvanceMoney.ToString();
            RechargeRecord_rcr_Info advanceRecharge = this._IRechargeRecordBL.SearchRecords(searchAdvance).FirstOrDefault();
            if (advanceRecharge != null)
            {
                fAdvanceMoney = advanceRecharge.rcr_fRechargeMoney;
            }

            //确认页面
            dlgConfirmInfo dlg = new dlgConfirmInfo();
            dlg.CardInfo = base._CurrentCardInfo;
            dlg.UserInfo = base._CurrentCardUserInfo;
            dlg.IsPrinted = cbxPrint.Checked;
            dlg.RechargeMoney = fRecharge;
            dlg.AdvanceMoney = fAdvanceMoney;
            if (ckbIsSyncUnPay.Checked)
            {
                dlg.PreCostMoney = fPreCost;
            }
            else
            {
                dlg.PreCostMoney = decimal.Zero;
            }

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                this.Cursor = Cursors.WaitCursor;

                decimal fRechargeDeduct = decimal.Zero;
                if (ckbIsSyncUnPay.Checked)
                {
                    fRechargeDeduct = fRecharge + fPreCost;//已经扣除的预付款数据
                    if (fRechargeDeduct < fRecharge)
                        fPreCost = Math.Abs(fPreCost);
                    else
                        fPreCost = 0;
                }
                else
                {
                    fRechargeDeduct = fRecharge;
                    fPreCost = 0;
                }

                //卡信息再次验证
                ConsumeCardInfo cardInfo = this._Reader.ReadCardInfo(base._CardInfoSection, base._SectionPwd);
                #region 卡片信息再次验证

                if (cardInfo == null)
                {
                    ShowWarningMessage("充值失败。" + Environment.NewLine + "无法确认充值卡信息，请重新读卡再试。");
                    this.Cursor = Cursors.Default;
                    return;
                }
                if (cardInfo.CardSourceID != dlg.CardInfo.CardSourceID)
                {
                    ShowWarningMessage("充值失败。" + Environment.NewLine + "充值卡信息已变更，请重新读卡再试。");
                    this.Cursor = Cursors.Default;
                    return;
                }

                #endregion

                //修正卡显示资料
                #region 修正卡显示资料
                try
                {
                    string strOldCardName = cardInfo.Name.Trim();
                    string strCurrentCardName = (this._CurrentPairInfo.CardOwner.ClassInfo.GradeInfo.gdm_cAbbreviation + this._CurrentPairInfo.CardOwner.cus_cChaName).Trim();
                    if (strOldCardName != strCurrentCardName)
                    {
                        ConsumeCardInfo changeCardInfo = new ConsumeCardInfo();
                        changeCardInfo.CardBalance = this._CurrentCardInfo.CardBalance;
                        changeCardInfo.CardNo = this._CurrentCardInfo.CardNo;
                        changeCardInfo.CardPwd = this._CurrentCardInfo.CardPwd;
                        changeCardInfo.CardSourceID = this._CurrentCardInfo.CardSourceID;
                        changeCardInfo.CardBalance = this._CurrentCardInfo.CardBalance;
                        changeCardInfo.Name = strCurrentCardName;

                        //年级信息发生变更，修改对应信息
                        ReturnValueInfo rvChangeCardInfo = this._Reader.WriteCardInfo(base._CardInfoSection, base._SectionPwd, changeCardInfo);
                    }
                }
                catch (Exception)
                { }
                #endregion

                //先进行【卡物理充值】
                ReturnValueInfo rvInfo = this._Reader.Recharge(base._CardInfoSection, base._SectionPwd, fRechargeDeduct);
                if (rvInfo.boolValue && !rvInfo.isError)
                {
                    //卡物理充值成功，继续进行充值记录上传操作
                    RechargeRecord_rcr_Info rechargeRecord = new RechargeRecord_rcr_Info();
                    #region 实体赋值

                    rechargeRecord.rcr_cRecordID = Guid.NewGuid();
                    rechargeRecord.rcr_cCardID = cardInfo.CardSourceID;
                    rechargeRecord.rcr_cRechargeType = DefineConstantValue.ConsumeMoneyFlowType.Recharge_PersonalRealTime.ToString();
                    rechargeRecord.rcr_cStatus = DefineConstantValue.ConsumeMoneyFlowStatus.Finished.ToString();
                    rechargeRecord.rcr_cUserID = this._CurrentCardUserInfo.cus_cRecordID;
                    rechargeRecord.rcr_dRechargeTime = DateTime.Now;//TODO:应该修改为跟服务器时间
                    rechargeRecord.rcr_fRechargeMoney = fRechargeDeduct;//扣减欠费得到的当次实际充值金额
                    rechargeRecord.PreCostMoney = fPreCost;//需要缴付的欠款金额
                    //<--卡实际充值后余额=卡当前余额+实际充值金额
                    rechargeRecord.rcr_fBalance = base._CurrentCardInfo.CardBalance + fRechargeDeduct;
                    //--->
                    rechargeRecord.IsNeedSyncAccount = ckbIsSyncUnPay.Checked;//是否需要同步账户，主要用以分别透支金额这些系统额外金额的记录登记
                    rechargeRecord.rcr_cAdd = this.UserInformation.usm_cUserLoginID;
                    rechargeRecord.rcr_cLast = rechargeRecord.rcr_cAdd;
                    rechargeRecord.rcr_dLastDate = rechargeRecord.rcr_dRechargeTime;

                    #endregion

                    //卡充值成功后，将充值信息写入充值记录表
                    rvInfo = this._IRechargeRecordBL.InsertRechargeRecord(rechargeRecord);
                    ComputePreCost(this._CurrentPairInfo);

                    if (rvInfo.boolValue && !rvInfo.isError)
                    {
                        //成功录入充值记录后提示成功
                        this.Cursor = Cursors.Default;
                        this.ShowInformationMessage("充值成功。");

                        if (cbxPrint.Checked)
                        {
                            RechargeDetail rdInfo = new RechargeDetail();
                            rdInfo.CardNo = Int32.Parse(this.labCardNo.Text);
                            rdInfo.OperationTime = System.DateTime.Now;
                            rdInfo.Operator = this.UserInformation.usm_cUserLoginID;
                            rdInfo.RechargeValue = fRecharge;
                            rdInfo.UserName = this.labUserName.Text;
                            rdInfo.ClassName = this.labClassName.Text;
                            //打印小票
                            PrintTicket(rdInfo);
                        }

                        resetAllControls();
                        this.Invoke(new DLG_GetRechargeHistory(BindRechargeList));

                        DateTime? dtSysNow = DateTime.Now;//使用系统时间作准，避免因客户机时间不同步造成操作异常
                        if (rvInfo.ValueObject != null)
                        {
                            dtSysNow = Convert.ToDateTime(rvInfo.ValueObject);
                        }
                        if (dtSysNow == null)
                        {
                            dtSysNow = DateTime.Now;
                        }
                        ResetMealPlanning(base._CurrentCardUserInfo, dtSysNow);

                        btnRead.Focus();
                        return;
                    }
                    else
                    {
                        ShowErrorMessage("上传充值记录失败，需要进行回滚扣费，请摆放好卡片后，点击确定。");
                        ConsumeCardInfo cardInfoRollback = this._Reader.ReadCardInfo(base._CardInfoSection, base._SectionPwd);
                        if (cardInfoRollback.CardSourceID != cardInfo.CardSourceID)
                        {
                            ShowWarningMessage("卡片信息不符合，请核对后重新放卡，原卡片卡号为：" + cardInfo.CardNo.ToString() + ",卡信息为：" + cardInfo.Name);
                            cardInfoRollback = this._Reader.ReadCardInfo(base._CardInfoSection, base._SectionPwd);
                            if (cardInfoRollback.CardSourceID == cardInfo.CardSourceID)
                            {
                                //录入充值记录失败，则需要将原先充入的卡金额扣除，如果卡已被取走，则需等待后台自动同步金额
                                rvInfo = this._Reader.Recharge(base._CardInfoSection, base._SectionPwd, fRechargeDeduct * -1);
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
                            rvInfo = this._Reader.Recharge(base._CardInfoSection, base._SectionPwd, fRechargeDeduct * -1);
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
                        this.ShowInformationMessage("充值失败。" + rvInfo.messageText);
                        btnRead.Focus();
                        return;
                    }
                }
                else
                {
                    resetAllControls();
                    this.Cursor = Cursors.Default;
                    this.ShowInformationMessage("充值失败。" + rvInfo.messageText);
                    btnRead.Focus();
                    return;
                }
            }
        }



        /// <summary>
        /// 重设被欠费停餐的人员开餐情况
        /// </summary>
        /// <param name="userInfo"></param>
        private void ResetMealPlanning(CardUserMaster_cus_Info userInfo, DateTime? dtSysNow)
        {
            try
            {
                if (this._tsBLLunch == null || this._tsBLSupper == null || this._tsMealLunch == null || this._tsMealSupper == null)
                {
                    BindMealTime();
                }
                if (this._tsBLLunch == null || this._tsBLSupper == null || this._tsMealLunch == null || this._tsMealSupper == null)
                {
                    return;
                }
                TimeSpan tsBLLunch = this._tsBLLunch.Value;
                TimeSpan tsMealLunch = this._tsMealLunch.Value;
                TimeSpan tsBLSupper = this._tsBLSupper.Value;
                TimeSpan tsMealSupper = this._tsMealSupper.Value;
                TimeSpan tsNow = TimeSpan.Parse(dtSysNow.Value.ToString("HH:mm"));

                bool l_blnIsNeedAlert = false;

                if (tsNow >= tsBLLunch && tsNow <= tsMealLunch)
                {
                    //显示停餐信息
                    ucMealBookingDetail.ShowData(this._CurrentPairInfo.CardOwner);
                    ucMealBookingDetail.BreakfastDesc = "未读";
                    ucMealBookingDetail.LunchDesc = "未读";
                    ucMealBookingDetail.SupperDesc = "未读";

                    if (!ucMealBookingDetail.LunchPlanning)
                    {
                        MealBookingHistory_mbh_Info oldPlan = ucMealBookingDetail.ListUserOldPlanning.Find(x => x.mbh_cMealType == Common.DefineConstantValue.MealType.Lunch.ToString());
                        if (oldPlan.mbh_lIsSet)
                        {
                            UpdateMealPlanning(Common.DefineConstantValue.MealType.Lunch.ToString(), userInfo, oldPlan);
                            l_blnIsNeedAlert = true;
                        }
                    }
                }
                else if (tsNow >= tsBLSupper && tsNow <= tsMealSupper)
                {
                    //显示停餐信息
                    ucMealBookingDetail.ShowData(this._CurrentPairInfo.CardOwner);
                    ucMealBookingDetail.BreakfastDesc = "未读";
                    ucMealBookingDetail.LunchDesc = "未读";
                    ucMealBookingDetail.SupperDesc = "未读";

                    if (!ucMealBookingDetail.SupperPlanning)
                    {
                        MealBookingHistory_mbh_Info oldPlan = ucMealBookingDetail.ListUserOldPlanning.Find(x => x.mbh_cMealType == Common.DefineConstantValue.MealType.Supper.ToString());
                        if (oldPlan.mbh_lIsSet)
                        {
                            UpdateMealPlanning(Common.DefineConstantValue.MealType.Supper.ToString(), userInfo, oldPlan);
                            l_blnIsNeedAlert = true;
                        }
                    }
                }

                if (!l_blnIsNeedAlert)
                {
                    return;
                }
                ReturnValueInfo rvInfo = AddOldCardList(int.Parse(base._CurrentCardInfo.CardNo), DefineConstantValue.EnumCardUploadListOpt.AddWhiteList);
                if (rvInfo.boolValue && !rvInfo.isError)
                {
                    //base.ShowInformationMessage("欠费停餐状态已清除成功，等待两分钟左右后可恢复打卡。");
                }
                else
                {
                    base.ShowErrorMessage("欠费停餐状态已清除失败。" + rvInfo.messageText);
                }
            }
            catch (Exception ex)
            {
                base.ShowErrorMessage(ex);
            }
        }
        /// <summary>
        /// 更新定餐计划
        /// </summary>
        /// <param name="strMealType"></param>
        /// <param name="userInfo"></param>
        void UpdateMealPlanning(string strMealType, CardUserMaster_cus_Info userInfo, MealBookingHistory_mbh_Info oldMealInfo)
        {
            try
            {
                //ShowInformationMessage("检测到该用户此前被欠费自动停餐，现更新定餐信息并提交到各个消费机处。");

                IMealBookingHistoryBL mealBL = MasterBLLFactory.GetBLL<IMealBookingHistoryBL>(MasterBLLFactory.MealBookingHistory);
                MealBookingHistory_mbh_Info mealInfo = new MealBookingHistory_mbh_Info();
                mealInfo.mbh_cMealType = strMealType;
                mealInfo.mbh_cTargetID = userInfo.cus_cRecordID;
                mealInfo.mbh_dMealDate = DateTime.Now;
                List<MealBookingHistory_mbh_Info> listMealInfo = mealBL.SearchRecords(mealInfo);
                if (listMealInfo != null && listMealInfo.Count > 0)
                {
                    MealBookingHistory_mbh_Info currentMealInfo = listMealInfo.FirstOrDefault();
                    if (currentMealInfo != null)
                    {
                        currentMealInfo.mbh_lIsSet = oldMealInfo.mbh_lIsSet;
                        currentMealInfo.mbh_cTargetType = oldMealInfo.mbh_cTargetType;
                        currentMealInfo.mbh_dAddDate = DateTime.Now;
                        currentMealInfo.mbh_cAdd = base.UserInformation.usm_cUserLoginID;
                        ReturnValueInfo rvInfo = mealBL.UpdateRecordWithPreCost(currentMealInfo);
                    }
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex);
            }
        }

        ReturnValueInfo AddOldCardList(int iCardNo, Common.DefineConstantValue.EnumCardUploadListOpt blistOpt)
        {
            IBlacklistChangeRecordBL blistBL = MasterBLLFactory.GetBLL<IBlacklistChangeRecordBL>(MasterBLLFactory.BlacklistChangeRecord);
            BlacklistChangeRecord_blc_Info blistInsert = new BlacklistChangeRecord_blc_Info();
            blistInsert.blc_cAdd = this.UserInformation.usm_cUserLoginID;
            blistInsert.blc_cOperation = blistOpt.ToString();
            blistInsert.blc_cOptReason = Common.DefineConstantValue.EnumCardUploadListReason.WhitelistOpt.ToString();
            blistInsert.blc_cRecordID = Guid.NewGuid();
            blistInsert.blc_dAddDate = DateTime.Now;
            blistInsert.blc_iCardNo = iCardNo;
            ReturnValueInfo rvInfo = blistBL.Save(blistInsert, DefineConstantValue.EditStateEnum.OE_Insert);
            return rvInfo;
        }

        /// <summary>
        /// 重置所有控件
        /// </summary>
        private void resetAllControls()
        {
            labUserName.Text = string.Empty;
            labClassName.Text = string.Empty;
            labCardNo.Text = string.Empty.PadLeft(8, '0');
            labStuNum.Text = string.Empty;
            labCardBalance.Text = "0.00";
            labAccountBalance.Text = "0.00";
            labAccountSyncTime.Text = "未同步";
            tbxRechargeMoney.Text = "0.00";
            tbxRechargeMoney.Enabled = false;
            btnConfirmRecharge.Enabled = false;
            labPreCost.Text = "0.00";
            btnPreCostDetail.Enabled = false;
            ckbIsSyncUnPay.Checked = true;
            ucMealBookingDetail.ShowData(null);
            labWaitForTrans.Text = "0.00";

            labAmountDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }

        private void tbxRechargeMoney_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbxRechargeMoney.Text.Trim()))
            {
                return;
            }
            try
            {
                decimal fRecharge = Convert.ToDecimal(tbxRechargeMoney.Text);
                if (fRecharge > 0)
                {
                    btnConfirmRecharge.Enabled = true;
                    cbxPrint.Enabled = true;
                }
                else
                {
                    btnConfirmRecharge.Enabled = false;
                    cbxPrint.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex);
                tbxRechargeMoney.Text = "0.00";
                tbxRechargeMoney.Focus();
                tbxRechargeMoney.SelectAll();
            }
        }

        /// <summary>
        /// 小票打印
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

        private void btnPreCostDetail_Click(object sender, EventArgs e)
        {
            dlgPreCostDetail dlgDetail = new dlgPreCostDetail(this._CurrentCardUserInfo);
            dlgDetail.ShowDialog();
        }

        private void frmRechargeRealTimeDetail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (btnConfirmRecharge.Enabled)
                {
                    btnConfirmRecharge_Click(btnConfirmRecharge, null);
                }
                else if (btnRead.Enabled)
                {
                    btnRead_Click(btnRead, null);
                }
                Button btnSender = sender as Button;
                if (btnSender != null)
                {
                    if (btnSender.Name == "btnCancel")
                    {
                        return;
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (ShowQuestionMessage("是否确认退出？"))
            {
                this.Close();
            }
        }
    }
}
