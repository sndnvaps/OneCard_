using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PaymentEquipment.Entity;
using BLL.IBLL.HHZX.ConsumeAccount;
using BLL.Factory.HHZX;
using BLL.IBLL.HHZX.UserCard;
using Model.HHZX.UserCard;
using WindowUI.TQS.ClassLibrary.Public;
using Model.HHZX.ComsumeAccount;
using Model.HHZX.UserInfomation.CardUserInfo;
using Model.General;
using WindowUI.TQS;
using PaymentEquipment.DeviceFactory;
using BLL.IBLL.SysMaster;
using Model.SysMaster;
using Model.HHZX.MealBooking;
using BLL.IBLL.HHZX.MealBooking;
using Common;

namespace WindowsUI.TQS.UserCard
{
    public partial class frmCardRecharge : BaseReaderForm
    {
        ConsumeCardInfo _CardInfo;
        CardUserMaster_cus_Info _UserInfo;
        private IRechargeRecordBL _IRechargeRecordBL;
        private IPreConsumeRecordBL _IPreConsumeRecordBL;
        private IUserCardPairBL _IUserCardPairBL;
        private List<PreRechargeRecord_prr_Info> _ListPreRechargeRecord;
        private List<RechargeRecord_rcr_Info> _ListRechargeRecord;
        private IPreRechargeRecordBL _IPreRechargeRecordBL;
        private string _strPwd;
        private Common.General localLog;

        public frmCardRecharge(string strPwd)
            : base(strPwd)
        {
            InitializeComponent();
            this._strPwd = strPwd;
            localLog = new General(Common.General.BindLocalLogInfo());
        }

        public override void Show()
        {
            if (this._IRechargeRecordBL == null)
            {
                this._IRechargeRecordBL = MasterBLLFactory.GetBLL<IRechargeRecordBL>(MasterBLLFactory.RechargeRecord);
            }
            if (this._IPreConsumeRecordBL == null)
            {
                this._IPreConsumeRecordBL = MasterBLLFactory.GetBLL<IPreConsumeRecordBL>(MasterBLLFactory.PreConsumeRecord);
            }
            if (this._IUserCardPairBL == null)
            {
                this._IUserCardPairBL = MasterBLLFactory.GetBLL<IUserCardPairBL>(MasterBLLFactory.UserCardPair);
            }
            if (this._IPreRechargeRecordBL == null)
            {
                this._IPreRechargeRecordBL = MasterBLLFactory.GetBLL<IPreRechargeRecordBL>(MasterBLLFactory.PreRechargeRecord);
            }

            InitReadCard();
        }

        /// <summary>
        /// 初始化读卡信息
        /// </summary>
        void InitReadCard()
        {
            labCardNo.Text = string.Empty.PadLeft(8, '0');
            labName.Text = string.Empty;
            labPreCost.Text = "0.00";
            labRecharge.Text = "0.00";
            labTotalRecharge.Text = "0.00";
            labCardBalance.Text = "0.00";
            lvRechargeList.SetDataSource<RechargeInfo>(new List<RechargeInfo>());
            ListViewSorter sorter = new ListViewSorter(1, SortOrder.Ascending);
            lvRechargeList.ListViewItemSorter = sorter;
            lvRechargeList.Sorting = SortOrder.Ascending;

            WaitForCardReader wfcrFrm = new WaitForCardReader(this._strPwd);

            GlobalVar.OpenFormList.Add(wfcrFrm);

            if (wfcrFrm.ShowDialog() == DialogResult.OK)
            {
                this._CardInfo = wfcrFrm.CardInfo;
                if (this._CardInfo != null)
                {
                    string strCardID = this._CardInfo.CardSourceID;
                    labCardBalance.Text = this._CardInfo.CardBalance.ToString();

                    UserCardPair_ucp_Info cardPair = this._IUserCardPairBL.SearchRecords(new UserCardPair_ucp_Info()
                    {
                        ucp_iCardNo = Convert.ToInt16(this._CardInfo.CardNo),
                        ucp_cCardID = strCardID
                    }).FirstOrDefault();
                    if (cardPair != null)
                    {
                        if (cardPair.CardOwner != null && cardPair.CardOwner.AccountInfo != null)
                        {
                            ucMealBookingDetail.ShowData(cardPair.CardOwner);
                            labName.Text = cardPair.CardOwner.cus_cChaName;
                            labCardNo.Text = this._CardInfo.CardNo.PadLeft(8, '0');
                            this._UserInfo = cardPair.CardOwner;

                            //预充值表
                            List<PreRechargeRecord_prr_Info> listPreRechargeRecord = this._IPreRechargeRecordBL.SearchRecords(new PreRechargeRecord_prr_Info()
                            {
                                prr_cUserID = cardPair.ucp_cCUSID,
                                prr_cStatus = Common.DefineConstantValue.ConsumeMoneyFlowStatus.WaitForAcceptTransfer.ToString()
                            });
                            if (listPreRechargeRecord == null && (listPreRechargeRecord != null && listPreRechargeRecord.Count > 0))
                            {
                                base.MessageDialog("提示", "没有可用的预充值的记录。");
                                return;
                            }

                            //转账列表
                            List<RechargeRecord_rcr_Info> listRechargeRecord = new List<RechargeRecord_rcr_Info>();
                            foreach (PreRechargeRecord_prr_Info item in listPreRechargeRecord)
                            {
                                RechargeRecord_rcr_Info rechrageInfo = new RechargeRecord_rcr_Info();
                                rechrageInfo.rcr_cAdd = "tqs";
                                rechrageInfo.rcr_cCardID = this._CardInfo.CardSourceID;
                                rechrageInfo.rcr_cLast = "tqs";
                                rechrageInfo.rcr_cRechargeType = item.prr_cRechargeType;
                                rechrageInfo.rcr_cRecordID = Guid.NewGuid();
                                rechrageInfo.rcr_cStatus = Common.DefineConstantValue.ConsumeMoneyFlowStatus.Finished.ToString();
                                rechrageInfo.rcr_cUserID = item.prr_cUserID;
                                rechrageInfo.rcr_dLastDate = DateTime.Now;
                                rechrageInfo.rcr_dRechargeTime = item.prr_dRechargeTime;
                                rechrageInfo.rcr_fBalance = 0;
                                rechrageInfo.rcr_fRechargeMoney = item.prr_fRechargeMoney;

                                item.prr_cRCRID = rechrageInfo.rcr_cRecordID;

                                listRechargeRecord.Add(rechrageInfo);
                            }
                            this._ListPreRechargeRecord = listPreRechargeRecord;
                            this._ListRechargeRecord = listRechargeRecord;

                            List<RechargeInfo> listRechargeInfo = getRechargeInfo(listRechargeRecord);
                            if (listRechargeInfo != null)
                            {
                                listRechargeInfo = listRechargeInfo.OrderByDescending(x => x.RechargeTime).ToList();
                                lvRechargeList.SetDataSource<RechargeInfo>(listRechargeInfo);
                                decimal dRecharge = listRechargeInfo.Sum(x => x.RechargeMoney);
                                if (dRecharge != 0)
                                {
                                    labRecharge.Text = dRecharge.ToString();
                                }
                            }

                            //未结算的预消费列表
                            List<PreConsumeRecord_pcs_Info> listPreCost = this._IPreConsumeRecordBL.SearchRecords(new PreConsumeRecord_pcs_Info() { pcs_cAccountID = cardPair.CardOwner.AccountInfo.cua_cRecordID });
                            if (listPreCost != null)
                            {
                                listPreCost = listPreCost.Where(x =>
                                    x.pcs_cConsumeType != Common.DefineConstantValue.ConsumeMoneyFlowType.IndeterminateCost.ToString()
                                    && x.pcs_cConsumeType != Common.DefineConstantValue.ConsumeMoneyFlowType.AdvanceMealCost.ToString()
                                    && x.pcs_cConsumeType != Common.DefineConstantValue.ConsumeMoneyFlowType.HedgeFund.ToString()
                                    && x.pcs_lIsSettled == false
                                    && x.pcs_cUserID == cardPair.CardOwner.cus_cRecordID
                                    ).ToList();
                                labPreCost.Text = Math.Round(listPreCost.Sum(x => x.pcs_fCost), 2).ToString();
                            }
                            else
                            {
                                labPreCost.Text = "0.00";
                            }

                            decimal fTotalRecharge = decimal.Parse(labRecharge.Text) + decimal.Parse(labPreCost.Text);
                            decimal fActualRecharge = decimal.Parse(labRecharge.Text) + decimal.Parse(labPreCost.Text) + decimal.Parse(labCardBalance.Text);
                            labTotalRecharge.Text = fTotalRecharge.ToString();
                            if (fActualRecharge >= decimal.Zero)
                                btnRecharge.Enabled = true;
                            else
                                btnRecharge.Enabled = false;
                        }
                        else
                        {
                            base.MessageDialog("提示", "本卡持卡人信息异常！");
                            return;
                        }
                    }
                    else
                    {
                        base.MessageDialog("提示", "未找到此卡或此卡不能進行充值！");
                        return;
                    }
                }
                else
                {
                    base.MessageDialog("提示", "读卡失败，请重试。" + Environment.NewLine + "（如多次失败，卡片有可能已损坏，请及时申请更换）");
                    return;
                }
            }
        }

        /// <summary>
        /// 转换充值信息
        /// </summary>
        /// <param name="listRechargeRecord"></param>
        /// <returns></returns>
        List<RechargeInfo> getRechargeInfo(List<RechargeRecord_rcr_Info> listRechargeRecord)
        {
            List<RechargeInfo> listRechargeInfo = null;
            try
            {
                if (listRechargeRecord != null)
                {
                    listRechargeInfo = new List<RechargeInfo>();
                    listRechargeRecord = listRechargeRecord.OrderByDescending(x => x.rcr_dRechargeTime).ToList();
                    for (int i = 0; i < listRechargeRecord.Count; i++)
                    {
                        try
                        {
                            RechargeInfo info = new RechargeInfo();
                            info.ID = i + 1;
                            info.RecordID = listRechargeRecord[i].rcr_cRecordID;
                            info.RechargeType = Common.DefineConstantValue.GetMoneyFlowDesc(listRechargeRecord[i].rcr_cRechargeType);
                            info.RechargeTime = listRechargeRecord[i].rcr_dRechargeTime;
                            info.RechargeMoney = listRechargeRecord[i].rcr_fRechargeMoney;
                            listRechargeInfo.Add(info);
                        }
                        catch (Exception exx)
                        { base.MessageDialog("提示", exx.Message); }
                    }
                }
            }
            catch (Exception ex)
            { base.MessageDialog("提示", ex.Message); }
            return listRechargeInfo;
        }

        /// <summary>
        /// 充值信息
        /// </summary>
        class RechargeInfo
        {
            /// <summary>
            /// 记录
            /// </summary>
            public Guid RecordID { get; set; }
            /// <summary>
            /// 序号
            /// </summary>
            public int ID { get; set; }
            /// <summary>
            /// 充值金额
            /// </summary>
            public decimal RechargeMoney { get; set; }
            /// <summary>
            /// 充值时间
            /// </summary>
            public DateTime RechargeTime { get; set; }
            /// <summary>
            /// 充值类型
            /// </summary>
            public string RechargeType { get; set; }
        }

        private void lvRechargeList_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (lvRechargeList.Sorting == SortOrder.Ascending)
            {
                ListViewSorter sorter = new ListViewSorter(e.Column, SortOrder.Descending);
                lvRechargeList.ListViewItemSorter = sorter;
                lvRechargeList.Sorting = SortOrder.Descending;
            }
            else
            {
                ListViewSorter sorter = new ListViewSorter(e.Column, SortOrder.Ascending);
                lvRechargeList.ListViewItemSorter = sorter;
                lvRechargeList.Sorting = SortOrder.Ascending;
            }
        }

        private void btnRecharge_Click(object sender, EventArgs e)
        {
            dlgConfirmInfo dlg = new dlgConfirmInfo();
            dlg.CardInfo = this._CardInfo;
            dlg.UserInfo = this._UserInfo;
            dlg.RechargeMoney = decimal.Parse(labTotalRecharge.Text);
            dlg.PreCostMoney = decimal.Parse(labPreCost.Text);

            GlobalVar.OpenFormList.Add(dlg);

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                this.Cursor = Cursors.WaitCursor;
                this._Reader = PaymentReaderFactory.CreateWriter(PaymentReaderFactory.EastRiverReader906);
                this._Reader.Conn();

                //卡信息再次验证
                ConsumeCardInfo cardInfo = this._Reader.ReadCardInfo(base._CardInfoSection, base._SectionPwd);
                if (cardInfo == null)
                {
                    base.MessageDialog("提示", "转账失败。" + Environment.NewLine + "无法确认卡信息，请重新读卡再试。");
                    this.Cursor = Cursors.Default;
                    return;
                }
                if (cardInfo.CardSourceID != dlg.CardInfo.CardSourceID)
                {
                    base.MessageDialog("提示", "转账失败。" + Environment.NewLine + "卡信息已变更，请重新读卡再试。");
                    this.Cursor = Cursors.Default;
                    return;
                }

                decimal fTotalRecharge = decimal.Parse(labTotalRecharge.Text);
                decimal fPreCost = dlg.PreCostMoney;

                try
                {
                    string strOldCardName = cardInfo.Name.Trim();
                    string strCurrentCardName = (this._UserInfo.ClassInfo.GradeInfo.gdm_cAbbreviation + this._UserInfo.cus_cChaName).Trim();
                    if (strOldCardName != strCurrentCardName)
                    {
                        ConsumeCardInfo changeCardInfo = new ConsumeCardInfo();
                        changeCardInfo.CardBalance = this._CardInfo.CardBalance;
                        changeCardInfo.CardNo = this._CardInfo.CardNo;
                        changeCardInfo.CardPwd = this._CardInfo.CardPwd;
                        changeCardInfo.CardSourceID = this._CardInfo.CardSourceID;
                        changeCardInfo.CardBalance = this._CardInfo.CardBalance;
                        changeCardInfo.Name = strCurrentCardName;

                        //年级信息发生变更，修改对应信息
                        ReturnValueInfo rvChangeCardInfo = this._Reader.WriteCardInfo(base._CardInfoSection, base._SectionPwd, changeCardInfo);
                    }
                }
                catch (Exception)
                { }

                //先进行物理卡充值
                ReturnValueInfo rvInfo = this._Reader.Recharge(base._CardInfoSection, base._SectionPwd, dlg.RechargeMoney);
                if (rvInfo.boolValue && !rvInfo.isError)
                {
                    //卡充值成功后，将原充值记录的状态更新为已完成
                    if (this._ListRechargeRecord != null)
                    {
                        for (int i = 0; i < this._ListRechargeRecord.Count; i++)
                        {
                            if (this._ListRechargeRecord[i] != null)
                            {
                                this._ListRechargeRecord[i].rcr_cStatus = Common.DefineConstantValue.ConsumeMoneyFlowStatus.Finished.ToString();

                                fPreCost += this._ListRechargeRecord[i].rcr_fRechargeMoney;
                                if (fPreCost < 0)
                                {
                                    //未将未结算预付款扣除完毕，余额不变
                                    if (i != this._ListRechargeRecord.Count - 1)
                                    {
                                        this._ListRechargeRecord[i].rcr_fBalance = this._CardInfo.CardBalance;
                                    }
                                    else
                                    {
                                        this._ListRechargeRecord[i].rcr_fBalance = this._CardInfo.CardBalance + fPreCost;
                                    }
                                }
                                else
                                {
                                    this._ListRechargeRecord[i].rcr_fBalance = this._CardInfo.CardBalance + Math.Abs(fPreCost);
                                }

                                this._ListRechargeRecord[i].rcr_dRechargeTime = DateTime.Now.AddSeconds(i);
                            }
                        }

                        decimal fPreCostRecharge = dlg.PreCostMoney;
                        if (fPreCostRecharge != 0)
                        {
                            fPreCostRecharge = Math.Abs(fPreCostRecharge);
                        }
                        rvInfo = this._IRechargeRecordBL.UpdateRechargeRecord(this._ListPreRechargeRecord, this._ListRechargeRecord, fPreCostRecharge);
                    }
                    else
                    {
                        rvInfo.messageText = "转账缓存信息异常，请重新打开本窗口。";
                        rvInfo.isError = true;
                    }

                    if (rvInfo.boolValue && !rvInfo.isError)
                    {
                        try
                        {
                            IMealBookingHistoryBL mealBl = MasterBLLFactory.GetBLL<IMealBookingHistoryBL>(MasterBLLFactory.MealBookingHistory);
                            MealBookingHistory_mbh_Info history = new MealBookingHistory_mbh_Info();
                            history.mbh_cTargetType = Common.DefineConstantValue.MealType.DebtAuto.ToString();
                            history.mbh_cTargetID = this._UserInfo.cus_cRecordID;
                            history.mbh_dMealDate = DateTime.Now.Date;
                            List<MealBookingHistory_mbh_Info> listHistory = mealBl.SearchRecords(history);
                            if (listHistory != null && listHistory.Count > 0)
                            {
                                DateTime? dtSysNow = DateTime.Now;
                                if (rvInfo.ValueObject != null)
                                {
                                    dtSysNow = Convert.ToDateTime(rvInfo.ValueObject);
                                }
                                if (dtSysNow == null)
                                {
                                    dtSysNow = DateTime.Now;
                                }
                                localLog.WriteLog(this._UserInfo.cus_cChaName + "转账完毕。时间：" + dtSysNow.ToString(), string.Empty, SystemLog.SystemLog.LogType.Trace);

                                ResetMealPlanning(this._UserInfo, dtSysNow.Value, listHistory);

                            }
                        }
                        catch (Exception exSub)
                        {
                            localLog.WriteLog(exSub.Message, string.Empty, SystemLog.SystemLog.LogType.Error);
                        }

                        //成功录入充值记录后提示成功
                        this.Cursor = Cursors.Default;
                        base.MessageDialog("提示", "充值成功。");

                        InitReadCard();
                    }
                    else
                    {
                        //录入充值记录失败，则需要将原先充入的卡金额扣除，如果卡已被取走，则需等待后台自动同步金额
                        rvInfo = this._Reader.Recharge(base._CardInfoSection, base._SectionPwd, dlg.RechargeMoney * -1);

                        this.Cursor = Cursors.Default;
                        base.MessageDialog("提示", "充值失败。" + Environment.NewLine + rvInfo.messageText);
                        return;
                    }
                }
                else
                {
                    this.Cursor = Cursors.Default;
                    base.MessageDialog("提示", "充值失败。" + Environment.NewLine + rvInfo.messageText);

                    return;
                }
            }
        }

        private void btnPreCostDetail_Click(object sender, EventArgs e)
        {
            dlgPreCostDetail dlg = new dlgPreCostDetail(this._UserInfo);

            GlobalVar.OpenFormList.Add(dlg);

            dlg.ShowDialog();
        }

        /// <summary>
        /// 重设被欠费停餐的人员开餐情况
        /// </summary>
        /// <param name="userInfo"></param>
        private void ResetMealPlanning(CardUserMaster_cus_Info userInfo, DateTime dtSysNow, List<MealBookingHistory_mbh_Info> listMeaslHistory)
        {
            try
            {
                ICodeMasterBL bll = BLL.Factory.SysMaster.MasterBLLFactory.GetBLL<ICodeMasterBL>(BLL.Factory.SysMaster.MasterBLLFactory.CodeMaster_cmt);
                List<CodeMaster_cmt_Info> listMealTimeSpans = bll.SearchRecords(new CodeMaster_cmt_Info() { cmt_cKey1 = Common.DefineConstantValue.CodeMasterDefine.KEY1_MealTimeSpan });
                List<CodeMaster_cmt_Info> listBlacklistTImeSpans = bll.SearchRecords(new CodeMaster_cmt_Info() { cmt_cKey1 = Common.DefineConstantValue.CodeMasterDefine.KEY1_BWListUploadInterval });
                TimeSpan tsBLLunch = TimeSpan.Parse(listBlacklistTImeSpans.Find(x => x.cmt_cValue == Common.DefineConstantValue.MealType.Lunch.ToString()).cmt_cRemark);
                TimeSpan tsMealLunch = TimeSpan.Parse(listMealTimeSpans.Find(x => x.cmt_cKey2 == Common.DefineConstantValue.MealType.Lunch.ToString()).cmt_cRemark2);
                TimeSpan tsBLSupper = TimeSpan.Parse(listBlacklistTImeSpans.Find(x => x.cmt_cValue == Common.DefineConstantValue.MealType.Supper.ToString()).cmt_cRemark);
                TimeSpan tsMealSupper = TimeSpan.Parse(listMealTimeSpans.Find(x => x.cmt_cKey2 == Common.DefineConstantValue.MealType.Supper.ToString()).cmt_cRemark2);

                TimeSpan tsNow = TimeSpan.Parse(dtSysNow.ToString("HH:mm"));

                string strMealType = string.Empty;
                if (tsNow >= tsBLLunch && tsNow <= tsMealLunch)
                {
                    strMealType = Common.DefineConstantValue.MealType.Lunch.ToString();
                    MealBookingHistory_mbh_Info mealInfo = listMeaslHistory.Find(x => x.mbh_cMealType == strMealType);
                    if (mealInfo != null)
                    {
                        localLog.WriteLog("找到午餐计划。" + dtSysNow.ToString(), string.Empty, SystemLog.SystemLog.LogType.Trace);
                        UpdateMealPlanning(strMealType, userInfo, mealInfo);
                    }
                    else
                    {
                        localLog.WriteLog("找不到午餐计划。" + dtSysNow.ToString(), string.Empty, SystemLog.SystemLog.LogType.Trace);
                    }
                }
                else if (tsNow >= tsBLSupper && tsNow <= tsMealSupper)
                {
                    strMealType = Common.DefineConstantValue.MealType.Supper.ToString();
                    MealBookingHistory_mbh_Info mealInfo = listMeaslHistory.Find(x => x.mbh_cMealType == strMealType);
                    if (mealInfo != null)
                    {
                        localLog.WriteLog("找到晚餐计划。" + dtSysNow.ToString(), string.Empty, SystemLog.SystemLog.LogType.Trace);
                        UpdateMealPlanning(strMealType, userInfo, mealInfo);
                    }
                    else
                    {
                        localLog.WriteLog("找不到晚餐计划。" + dtSysNow.ToString(), string.Empty, SystemLog.SystemLog.LogType.Trace);
                    }
                }
                else
                {
                    localLog.WriteLog(userInfo.cus_cChaName + "，不在就餐时间内。" + dtSysNow.ToString(), string.Empty, SystemLog.SystemLog.LogType.Trace);
                }

                ReturnValueInfo rvInfo = AddOldCardBList(int.Parse(_CardInfo.CardNo), DefineConstantValue.EnumBlacklistCardOpt.RemoveList);
                if (rvInfo.boolValue && !rvInfo.isError)
                {
                    localLog.WriteLog(userInfo.cus_cChaName + "清除名单成功。" + dtSysNow.ToString(), string.Empty, SystemLog.SystemLog.LogType.Trace);
                }
                else
                {
                    localLog.WriteLog(userInfo.cus_cChaName + "清除名单失败。" + rvInfo.messageText + " " + dtSysNow.ToString(), string.Empty, SystemLog.SystemLog.LogType.Error);
                }
            }
            catch (Exception ex)
            {
                localLog.WriteLog(ex.Message, string.Empty, SystemLog.SystemLog.LogType.Error);
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
                        currentMealInfo.mbh_lIsSet = true;
                        //currentMealInfo.mbh_cTargetType = oldMealInfo.mbh_cTargetType;
                        currentMealInfo.mbh_dAddDate = DateTime.Now;
                        currentMealInfo.mbh_cAdd = "TQS";
                        ReturnValueInfo rvInfo = mealBL.UpdateRecordWithPreCost(currentMealInfo);
                        localLog.WriteLog(userInfo.cus_cChaName + "，更新计划成功。" + DateTime.Now.ToString(), string.Empty, SystemLog.SystemLog.LogType.Trace);
                    }
                }
                else
                {
                    localLog.WriteLog(userInfo.cus_cChaName + "，找不到可用的历史定餐计划。" + DateTime.Now.ToString(), string.Empty, SystemLog.SystemLog.LogType.Trace);
                }
            }
            catch (Exception ex)
            {
                localLog.WriteLog(userInfo.cus_cChaName + "，异常：" + ex.Message, string.Empty, SystemLog.SystemLog.LogType.Error);
            }
        }

        ReturnValueInfo AddOldCardBList(int iCardNo, Common.DefineConstantValue.EnumBlacklistCardOpt blistOpt)
        {
            localLog.WriteLog("清除名单成功。", string.Empty, SystemLog.SystemLog.LogType.Trace);

            IBlacklistChangeRecordBL blistBL = MasterBLLFactory.GetBLL<IBlacklistChangeRecordBL>(MasterBLLFactory.BlacklistChangeRecord);
            BlacklistChangeRecord_blc_Info blistInsert = new BlacklistChangeRecord_blc_Info();
            blistInsert.blc_cAdd = "TQS";
            blistInsert.blc_cOperation = blistOpt.ToString();
            blistInsert.blc_cOptReason = Common.DefineConstantValue.EnumBlacklistReason.BlacklistOpt.ToString();
            blistInsert.blc_cRecordID = Guid.NewGuid();
            blistInsert.blc_dAddDate = DateTime.Now;
            blistInsert.blc_iCardNo = iCardNo;
            ReturnValueInfo rvInfo = blistBL.Save(blistInsert, DefineConstantValue.EditStateEnum.OE_Insert);
            return rvInfo;
        }
    }
}
