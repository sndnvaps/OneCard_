using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WindowUI.HHZX.UserInformation.CardUserInfo;
using Model.HHZX.UserInfomation.CardUserInfo;
using PaymentEquipment.Entity;
using BLL.IBLL.HHZX.UserCard;
using BLL.Factory.HHZX;
using Model.HHZX.UserCard;
using Common;
using BLL.IBLL.HHZX.UserInfomation.UserCard;
using Model.General;
using Model.IModel;
using BLL.IBLL.HHZX.UserInfomation.CardUserInfo;
using BLL.IBLL.HHZX.ConsumeAccount;
using Model.HHZX.ComsumeAccount;
using WindowUI.HHZX.SystemSettings;
using Model.SysMaster;
using BLL.IBLL.SysMaster;
using BLL.IBLL.HHZX.MealBooking;
using Model.HHZX.MealBooking;
using BLL.IBLL.HHZX.ConsumerDevice;
using Model.HHZX.ConsumerDevice;

namespace WindowUI.HHZX.UserCard
{
    /// <summary>
    /// 换卡
    /// </summary>
    public partial class frmCardReplace : BaseReaderForm
    {
        /// <summary>
        /// 换卡费用
        /// </summary>
        private decimal _ReplaceCost;
        /// <summary>
        /// 当前用户信息
        /// </summary>
        private CardUserMaster_cus_Info _CurrentUserInfo;
        /// <summary>
        /// 当前卡信息
        /// </summary>
        private ConsumeCardInfo _CardInfo;
        private IUserCardPairBL _IUserCardPairBL;
        private IConsumeCardMasterBL _IConsumeCardMasterBL;
        private ICardUserMasterBL _ICardUserMasterBL;
        private ICardUserAccountBL _ICardUserAccountBL;
        private ICodeMasterBL _ICodeMasterBL;
        private IConsumeMachineBL _IConsumeMachineBL;
        private IBlacklistChangeRecordBL m_IBlacklistChangeRecordBL;

        public frmCardReplace()
        {
            InitializeComponent();
            initReader();
            this._IUserCardPairBL = MasterBLLFactory.GetBLL<IUserCardPairBL>(MasterBLLFactory.UserCardPair);
            this._IConsumeCardMasterBL = MasterBLLFactory.GetBLL<IConsumeCardMasterBL>(MasterBLLFactory.ConsumeCardMaster);
            this._ICardUserMasterBL = MasterBLLFactory.GetBLL<ICardUserMasterBL>(MasterBLLFactory.CardUserMaster);
            this._ICardUserAccountBL = MasterBLLFactory.GetBLL<ICardUserAccountBL>(MasterBLLFactory.CardUserAccount);
            this._ICodeMasterBL = BLL.Factory.SysMaster.MasterBLLFactory.GetBLL<ICodeMasterBL>(BLL.Factory.SysMaster.MasterBLLFactory.CodeMaster_cmt);
            this._IConsumeMachineBL = MasterBLLFactory.GetBLL<IConsumeMachineBL>(MasterBLLFactory.ConsumeMachine);
            this.m_IBlacklistChangeRecordBL = MasterBLLFactory.GetBLL<IBlacklistChangeRecordBL>(MasterBLLFactory.BlacklistChangeRecord);

            initCost();

            //btnSelectUser_Click(null, null);
        }

        private void initReader()
        {
            this.btnReaderCon.Click += btnReaderState_Click;
            btnReaderState_Click(this.btnReaderCon, null);
        }

        private void btnSelectUser_Click(object sender, EventArgs e)
        {
            dlgCardUserSelection dcusForm = new dlgCardUserSelection();
            dcusForm.ShowDialog();
            if (dcusForm.SelectedUser != null)
            {
                _CurrentUserInfo = dcusForm.SelectedUser;
                gpbReplace.Enabled = true;
                initValue();
            }
            else
            {
                gpbReplace.Enabled = false;
            }
        }

        private void initValue()
        {
            this.lblChaName.Text = _CurrentUserInfo.cus_cChaName;
            this.lblNumber.Text = _CurrentUserInfo.cus_cStudentID;

            if (_CurrentUserInfo.ClassInfo != null)
            {
                this.lblClass.Text = _CurrentUserInfo.ClassInfo.csm_cClassName;
            }
            else if (_CurrentUserInfo.DeptInfo != null)
            {
                this.lblClass.Text = _CurrentUserInfo.DeptInfo.dpm_cName;
            }
            else
            {
                this.lblClass.Text = "无";
            }

            if (_CurrentUserInfo.PairInfo != null)
            {
                this.lblCardNo.Text = _CurrentUserInfo.PairInfo.ucp_iCardNo.ToString();

                switch (_CurrentUserInfo.PairInfo.ucp_cUseStatus)
                {
                    case "Normal":
                        this.lblUserStatus.Text = "使用中";
                        break;
                    case "LoseReporting":
                        this.lblUserStatus.Text = "挂失中";
                        break;
                    case "Damaged":
                        this.lblUserStatus.Text = "已损坏";
                        break;
                    case "Lost":
                        this.lblUserStatus.Text = "已丢失";
                        break;
                    case "Returned":
                        this.lblUserStatus.Text = "已退卡";
                        break;
                }
            }
            else
            {
                this.lblCardNo.Text = "未发卡";
                this.lblUserStatus.Text = "未发卡";
                gpbReplace.Enabled = false;
            }
        }

        /// <summary>
        ///  读卡
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRead_Click(object sender, EventArgs e)
        {
            try
            {
                bool resUkey = base.CheckUKey();
                if (!resUkey)
                {
                    return;
                }

                this.btnSave.Enabled = false;
                this.lblReadNo.Text = "未读卡";
                _CardInfo = null;

                btnReaderState_Click(this.btnReaderCon, null);
                if (_IsConnected)
                {
                    this.Cursor = Cursors.WaitCursor;

                    _CardInfo = _Reader.ReadCardInfo(_CardInfoSection, _SectionPwd);
                    if (_CardInfo != null)
                    {
                        this.lblReadNo.Text = "已读卡";
                        this.btnSave.Enabled = true;
                    }
                    else
                    {
                        _CardInfo = _Reader.ReadCardInfo(_CardInfoSection, this._OrganizeSectionPwd);
                        if (_CardInfo != null)
                        {
                            ReturnValueInfo rvInfo = this._Reader.ModifySectionPwd(base._CardInfoSection, base._OrganizeSectionPwd, base._SectionPwd);
                            this.lblReadNo.Text = "已读卡";
                            this.btnSave.Enabled = true;
                        }
                        else
                        {
                            base.ShowErrorMessage("找不到卡片，请确认读卡器是否已连接或是否将卡片放在读卡器的感应区内。");
                        }

                    }
                }
                else
                {
                    base.ShowErrorMessage("找不到读卡器，请确认读卡器是否已连接。");
                }
            }
            catch
            {
                base.ShowErrorMessage("找不到卡片，请确认读卡器是否已连接或是否将卡片放在读卡器的感应区内。");

            }

            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// 確定換卡
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                bool resUkey = base.CheckUKey();
                if (!resUkey)
                {
                    return;
                }

                #region 添加换卡前对收数情况的判断，若收数未成功，则不能进行换卡操作

                ConsumeMachineMaster_cmm_Info searchMacInfo = new ConsumeMachineMaster_cmm_Info();
                searchMacInfo.cmm_cStatus = Common.DefineConstantValue.ConsumeMachineStatus.Using.ToString();
                List<ConsumeMachineMaster_cmm_Info> listMacInfos = this._IConsumeMachineBL.SearchRecords(searchMacInfo);
                listMacInfos = listMacInfos.Where(x => x.cmm_lIsActive).ToList();
                if (listMacInfos == null && listMacInfos.Count > 0)
                {
                    base.ShowErrorMessage("获取消费数据同步信息时出现异常，请重试。");
                    return;
                }
                //消费机最后同步时间
                DateTime dtMacSync = listMacInfos[0].cmm_dLastAccessTime;
                //List<ConsumeMachineMaster_cmm_Info> listUnSyncMachineInfos = listMacInfos.Where(x =>
                //          x.cmm_dLastAccessTime.Hour != dtMacSync.Hour).ToList();
                List<ConsumeMachineMaster_cmm_Info> listUnSyncMachineInfos = new List<ConsumeMachineMaster_cmm_Info>();
                foreach (ConsumeMachineMaster_cmm_Info macItem in listMacInfos)
                {
                    if (macItem != null)
                    {
                        DateTime dtAccess = macItem.cmm_dLastAccessTime;
                        if (Math.Abs((dtAccess - dtMacSync).TotalMinutes) > 30)
                        {
                            listUnSyncMachineInfos.Add(macItem);
                        }
                    }
                    else
                        continue;
                }
                List<ConsumeMachineMaster_cmm_Info> listUnConnMachineInfos = listMacInfos.Where(x =>
                        !x.cmm_lLastAccessRes).ToList();
                if ((listUnSyncMachineInfos != null && listUnSyncMachineInfos.Count > 0) || (listUnConnMachineInfos != null && listUnConnMachineInfos.Count > 0))
                {
                    if (base.ShowQuestionMessage("暂时不能进行换卡操作，因检测到有断线现象的消费机，请在恢复收集数据正常后重试。" + Environment.NewLine + "需要立即查看【消费数据收集情况】吗？"))
                    {
                        MenuItem menuClick = new MenuItem();
                        Sys_FormMaster_fom_Info formClick = new Sys_FormMaster_fom_Info();
                        formClick.fom_cExePath = "WindowUI.HHZX.ConsumerDevice.frmConsumptionRecordCollect";
                        menuClick.Tag = formClick;
                        base.ShowSubForm(menuClick, base.BaseDockPanel);
                    }
                    this.btnSave.Enabled = false;
                    this.lblReadNo.Text = "请读卡";
                    return;
                }

                #endregion

                this.btnSave.Enabled = false;
                this.lblReadNo.Text = "请读卡";

                UserCardPair_ucp_Info userPairInfo = new UserCardPair_ucp_Info();
                userPairInfo.ucp_cCardID = _CardInfo.CardSourceID;
                userPairInfo.ucp_iCardNo = int.Parse(_CardInfo.CardNo);
                //查询用户是否已拥有正常的消费卡
                List<UserCardPair_ucp_Info> listResUserPair = _IUserCardPairBL.SearchRecords(userPairInfo);
                if (userPairInfo != null)
                {
                    listResUserPair = listResUserPair.Where(x => x.ucp_cUseStatus != Common.DefineConstantValue.ConsumeCardStatus.Returned.ToString()).ToList();
                }

                if (listResUserPair != null && listResUserPair.Count > 0)
                {
                    string strMessage = string.Empty;

                    userPairInfo = listResUserPair[0] as UserCardPair_ucp_Info;

                    userPairInfo = _IUserCardPairBL.DisplayRecord(userPairInfo);

                    if (userPairInfo.CardOwner != null)
                    {
                        strMessage += userPairInfo.CardOwner.cus_cChaName + " " + userPairInfo.CardOwner.ClassName + " 卡号：" + userPairInfo.ucp_iCardNo;
                    }

                    base.ShowErrorMessage("该卡已在使用中。使用者：" + strMessage);
                    return;
                }

                if (!ShowQuestionMessage("是否确认换卡?"))
                {
                    return;
                }
                if (ShowQuestionMessage("是否需要重新设置【换卡工本费】？" + Environment.NewLine + "当前【换卡工本费】为：" + _ReplaceCost.ToString()))
                {
                    btnSetCost_Click(null, null);
                    if (!ShowQuestionMessage("【换卡工本费】更新完毕，是否需要继续进行换卡操作？"))
                    {
                        return;
                    }
                }

                userPairInfo = _CurrentUserInfo.PairInfo;
                int iOldCardNo = userPairInfo.ucp_iCardNo;
                userPairInfo.ucp_cUseStatus = DefineConstantValue.ConsumeCardStatus.Returned.ToString();
                userPairInfo.ucp_dReturnTime = System.DateTime.Now;

                if (!_IUserCardPairBL.Save(userPairInfo, DefineConstantValue.EditStateEnum.OE_Update).isError)
                {
                    ConsumeCardMaster_ccm_Info ccmInfo = new ConsumeCardMaster_ccm_Info();
                    ccmInfo.ccm_cCardID = _CardInfo.CardSourceID;

                    ccmInfo.ccm_cCardState = DefineConstantValue.CardUseState.InUse.ToString();
                    ccmInfo.ccm_lIsActive = true;
                    ccmInfo.ccm_cAdd = this.UserInformation.usm_cUserLoginID;
                    ccmInfo.ccm_dAddDate = System.DateTime.Now;
                    ccmInfo.ccm_cLast = this.UserInformation.usm_cUserLoginID;
                    ccmInfo.ccm_dLastDate = System.DateTime.Now;
                    ///如果新卡沒錄入系統，則先錄入新卡
                    if (_IConsumeCardMasterBL.DisplayRecord(ccmInfo) != null)
                    {
                        //如果新卡已在系統，則設為已使用
                        if (_IConsumeCardMasterBL.Save(ccmInfo, DefineConstantValue.EditStateEnum.OE_Update).isError)
                        {

                        }
                    }
                    else
                    {
                        //添加新卡信息
                        if (_IConsumeCardMasterBL.Save(ccmInfo, DefineConstantValue.EditStateEnum.OE_Insert).isError)
                        {
                            base.ShowErrorMessage("卡信息录入时发生错误，请再次尝试。");
                        }
                    }

                    //如果存在舊卡，將舊卡設為未使用
                    if (_CurrentUserInfo.PairInfo != null)
                    {
                        ConsumeCardMaster_ccm_Info oldCardInfo = new ConsumeCardMaster_ccm_Info();
                        oldCardInfo.ccm_cCardID = _CurrentUserInfo.PairInfo.ucp_cCardID;
                        oldCardInfo = _IConsumeCardMasterBL.DisplayRecord(oldCardInfo) as ConsumeCardMaster_ccm_Info;
                        if (oldCardInfo != null)
                        {
                            oldCardInfo.ccm_cCardState = DefineConstantValue.CardUseState.NotUsed.ToString();
                            _IConsumeCardMasterBL.Save(oldCardInfo, DefineConstantValue.EditStateEnum.OE_Update);
                        }
                    }

                    userPairInfo.ucp_cRecordID = Guid.NewGuid();
                    userPairInfo.ucp_cCardID = ccmInfo.ccm_cCardID;
                    userPairInfo.ucp_cAdd = this.UserInformation.usm_cUserLoginID;
                    userPairInfo.ucp_cLast = this.UserInformation.usm_cUserLoginID;
                    userPairInfo.ucp_dPairTime = DateTime.Now;
                    userPairInfo.ucp_dAddDate = DateTime.Now;
                    userPairInfo.ucp_dLastDate = DateTime.Now;
                    userPairInfo.ucp_cUseStatus = DefineConstantValue.ConsumeCardStatus.Normal.ToString();
                    userPairInfo.ucp_lIsActive = true;
                    userPairInfo.ucp_dReturnTime = null;

                    ReturnValueInfo returnInfo = _IUserCardPairBL.InsertExchargeCard(userPairInfo, _ReplaceCost);

                    userPairInfo = returnInfo.ValueObject as UserCardPair_ucp_Info;

                    if (returnInfo.isError)
                    {
                        base.ShowErrorMessage("换卡失败，请再次尝试。");
                        return;
                    }
                    else
                    {
                        //換卡成功，將新卡設為已使用
                        initValue();

                        UserCardPair_ucp_Info currentPair = this._IUserCardPairBL.DisplayRecord(new UserCardPair_ucp_Info() { ucp_cRecordID = userPairInfo.ucp_cRecordID }) as UserCardPair_ucp_Info;

                        string strCardName = string.Empty;

                        //抽取用户信息写入卡显示名称
                        if (currentPair.CardOwner != null)
                        {
                            CardUserMaster_cus_Info userSearch = new CardUserMaster_cus_Info() { cus_cRecordID = currentPair.CardOwner.cus_cRecordID };
                            CardUserMaster_cus_Info userInfo = this._ICardUserMasterBL.DisplayRecord(userSearch) as CardUserMaster_cus_Info;
                            if (userInfo != null)
                            {
                                if (userInfo.cus_cIdentityNum == DefineConstantValue.CodeMasterDefine.KEY2_SIOT_CardUserIdentity_Student)//学生
                                {
                                    if (userInfo.ClassInfo != null)
                                    {
                                        if (userInfo.ClassInfo.GradeInfo == null)
                                        {
                                            strCardName += userInfo.ClassInfo.csm_cClassName.Substring(0, 1) == "高" ? "G" : "C";
                                            strCardName += userInfo.ClassInfo.csm_cClassName.Substring(1, 1);
                                        }
                                        else
                                        {
                                            strCardName += userInfo.ClassInfo.GradeInfo.gdm_cAbbreviation;
                                        }

                                        string strTmpName = userInfo.cus_cChaName;
                                        if (userInfo.cus_cChaName.Length > 3)
                                        {
                                            strTmpName = userInfo.cus_cChaName.Substring(1, 3);
                                        }
                                        strCardName += strTmpName;
                                    }
                                    else
                                    {
                                        this.Cursor = Cursors.Default;
                                        base.ShowWarningMessage("用户班级信息不全，请重试。");
                                        return;
                                    }
                                }
                                else//老师
                                {
                                    string strTmpName = userInfo.cus_cChaName;
                                    if (userInfo.cus_cChaName.Length > 6)
                                    {
                                        strTmpName = strTmpName.Substring(0, 6);
                                    }
                                    strCardName = strTmpName;
                                }
                            }
                        }

                        CardUserAccount_cua_Info cuaInfo = new CardUserAccount_cua_Info();
                        cuaInfo.cua_cCUSID = userPairInfo.ucp_cCUSID;

                        cuaInfo = _ICardUserAccountBL.SearchRecords(cuaInfo).FirstOrDefault() as CardUserAccount_cua_Info;
                        _CardInfo.CardNo = userPairInfo.ucp_iCardNo.ToString();
                        _CardInfo.Name = strCardName;
                        _CardInfo.CardPwd = this._PayPwd;
                        //_cardInfo.CardBalance = cuaInfo.cua_fCurrentBalance;

                        decimal Balance = cuaInfo.cua_fCurrentBalance;

                        if (this._CurrentUserInfo != null)
                        {
                            if (this._CurrentUserInfo.cus_cIdentityNum == Common.DefineConstantValue.CodeMasterDefine.KEY2_SIOT_CardUserIdentity_Student)
                            {
                                CodeMaster_cmt_Info codeInfo = this._ICodeMasterBL.SearchRecords(new CodeMaster_cmt_Info() { cmt_cKey1 = Common.DefineConstantValue.CodeMasterDefine.KEY1_ConstantExpenses, cmt_cKey2 = Common.DefineConstantValue.CodeMasterDefine.KEY2_AdvanceCost }).FirstOrDefault() as CodeMaster_cmt_Info;
                                if (codeInfo != null)
                                {
                                    Balance = Balance + codeInfo.cmt_fNumber;
                                }
                            }
                        }

                        if (Balance < 0)
                        {
                            Balance = 0;
                        }

                        _CardInfo.CardBalance = Balance;

                        this._Reader.WriteCardInfo(this._CardInfoSection, this._SectionPwd, _CardInfo);

                        this.lblReadNo.Text = "已换卡";

                        userPairInfo = returnInfo.ValueObject as UserCardPair_ucp_Info;

                        _CurrentUserInfo.PairInfo = userPairInfo;

                        _CardInfo = null;

                        initValue();

                        ShowInformationMessage("换卡成功。");

                        ReturnValueInfo rvRemoveOld = RemoveOldCardFromWList(iOldCardNo);
                        ReturnValueInfo rvAddNew = AddNewCardToWList(userPairInfo.ucp_iCardNo);
                        if (rvRemoveOld.boolValue && rvAddNew.boolValue)
                        {
                            ShowInformationMessage("旧卡自动添加到黑名单列表成功，原卡已不能继续使用。");
                        }
                        else
                        {
                            ShowErrorMessage("旧卡自动添加到黑名单列表失败，可等待停餐服务收集名单添加或联系管理员手动添加。");
                        }
                    }
                }
            }
            catch
            {

            }
        }

        /// <summary>
        /// 将旧卡添加到黑名单记录中
        /// </summary>
        /// <param name="iCardNo">卡号</param>
        ReturnValueInfo AddOldCardToBList(int iCardNo)
        {
            return this.m_IBlacklistChangeRecordBL.InsertUploadCardNo(iCardNo, DefineConstantValue.EnumCardUploadListOpt.AddBlackList, DefineConstantValue.EnumCardUploadListReason.CardReplace, this.UserInformation.usm_cUserLoginID);
        }

        /// <summary>
        /// 将旧卡移出白名单记录中
        /// </summary>
        /// <param name="iCardNo">卡号</param>
        ReturnValueInfo RemoveOldCardFromWList(int iCardNo)
        {
            return this.m_IBlacklistChangeRecordBL.InsertUploadCardNo(iCardNo, DefineConstantValue.EnumCardUploadListOpt.RemoveWhiteList, DefineConstantValue.EnumCardUploadListReason.CardReplace, this.UserInformation.usm_cUserLoginID);
        }

        /// <summary>
        /// 将新卡添加到白名单记录中
        /// </summary>
        /// <param name="iCardNo">卡号</param>
        ReturnValueInfo AddNewCardToWList(int iCardNo)
        {
            return this.m_IBlacklistChangeRecordBL.InsertUploadCardNo(iCardNo, DefineConstantValue.EnumCardUploadListOpt.AddWhiteList, DefineConstantValue.EnumCardUploadListReason.CardReplace, this.UserInformation.usm_cUserLoginID);
        }

        /// <summary>
        /// 初始换卡费用
        /// </summary>
        private void initCost()
        {
            CodeMaster_cmt_Info searchCode = new CodeMaster_cmt_Info();
            searchCode.cmt_cKey1 = Common.DefineConstantValue.CodeMasterDefine.KEY1_ConstantExpenses.ToString();
            searchCode.cmt_cKey2 = Common.DefineConstantValue.CodeMasterDefine.KEY2_ExchangeCardCost;

            CodeMaster_cmt_Info codeInfo = this._ICodeMasterBL.SearchRecords(searchCode).FirstOrDefault() as CodeMaster_cmt_Info;

            if (codeInfo != null)
            {
                _ReplaceCost = codeInfo.cmt_fNumber;
                this.lblCost.Text = codeInfo.cmt_fNumber.ToString();
            }
        }

        private void btnSetCost_Click(object sender, EventArgs e)
        {
            dlgConstantExpensesSetting dlg = new dlgConstantExpensesSetting();
            dlg.SubKeyName = Common.DefineConstantValue.CodeMasterDefine.KEY2_ExchangeCardCost;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                _ReplaceCost = dlg.NewValue;
                this.lblCost.Text = dlg.NewValue.ToString();
            }
        }

        private void frmCardReplace_SizeChanged(object sender, EventArgs e)
        {
            int iFormWidth = this.Width;
            int iFormHeight = this.Height;
            int iGbxWidth = gbxMain.Width;
            int iGbxHeight = gbxMain.Height;
            gbxMain.Location = new Point((iFormWidth - iGbxWidth) / 2, (iFormHeight - iGbxHeight) / 2);
        }
    }
}
