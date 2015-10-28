using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL.IBLL.General;
using BLL.Factory.General;
using Model.IModel;
using Common;
using WindowUI.HHZX.ClassLibrary.Public;
using Model.HHZX.UserInfomation.CardUserInfo;
using BLL.IBLL.HHZX.UserInfomation.CardUserInfo;
using BLL.Factory.HHZX;
using Model.HHZX.UserCard;
using Model.General;
using BLL.IBLL.HHZX.UserCard;
using BLL.IBLL.HHZX.UserInfomation.UserCard;
using BLL.IBLL.HHZX.ConsumeAccount;
using Model.HHZX.ComsumeAccount;
using PaymentEquipment.Entity;
using sysBL = BLL.IBLL.SysMaster;
using sysFac = BLL.Factory.SysMaster;
using Model.SysMaster;
using WindowUI.HHZX.SystemSettings;

namespace WindowUI.HHZX.UserCard
{
    /*
     * 05-29 Donald FINISH：单卡发卡流程，TODO：1、发卡时检查是否新卡，如是，先录入新卡信息，2、发卡时卡号自动更新并返回，写入卡内；3、预充值款充值成功后，添加充值记录和资金流记录；4、批量发卡
     * 06-01 Donald FINISH：1、发卡时检查是否新卡，如是，先录入新卡信息，2、发卡时卡号自动更新并返回，写入卡内；3、预充值款充值成功后，添加充值记录和资金流记录；
     *                      TODO： 批量发卡
     * 06-01 Donald FINISH：批量发卡 TODO:当打开本窗口后，再打开其他窗口进行关闭读卡设备的操作的话，本窗口的读卡器需重新连接才能使用
     * 06-27 Donald FINISH：1、多窗口操作读写器均不会互相影响重用；2、设置预充值费用
     */
    /// <summary>
    /// 用户信息与卡信息配对(发卡)
    /// </summary>
    public partial class frmUserCardMatch : BaseReaderForm
    {
        #region 自定义变量

        private delegate void DelegateBatchRead();
        private IGeneralBL _IGeneralBL;
        private ICardUserMasterBL _ICardUserMasterBL;
        private IUserCardPairBL _IUserCardPairBL;
        private IConsumeCardMasterBL _IConsumeCardMasterBL;
        private IRechargeRecordBL _IRechargeRecordBL;
        private sysBL.ICodeMasterBL _ICodeMasterBL;
        private Timer _tmrMatchCard;
        private ICardUserAccountBL _ICardUserAccountBL;
        private IPreRechargeRecordBL _IPreRechargeRecordBL;
        private IPreConsumeRecordBL _IPreConsumeRecordBL;
        /// <summary>
        /// 是否正在批量发卡
        /// </summary>
        private bool _IsBatchReading;
        /// <summary>
        /// 读写器是否被占用中
        /// </summary>
        private bool _IsReaderReading;
        /// <summary>
        /// 是否在读新卡
        /// </summary>
        private bool _IsReadingNew;
        /// <summary>
        /// 最后读到的卡号
        /// </summary>
        private string _CurrentCardID;

        #endregion

        public frmUserCardMatch()
            : base()
        {
            InitializeComponent();

            this._IGeneralBL = GeneralBLLFactory.GetBLL<IGeneralBL>(GeneralBLLFactory.General);
            this._ICardUserMasterBL = MasterBLLFactory.GetBLL<ICardUserMasterBL>(MasterBLLFactory.CardUserMaster);
            this._IUserCardPairBL = MasterBLLFactory.GetBLL<IUserCardPairBL>(MasterBLLFactory.UserCardPair);
            this._IConsumeCardMasterBL = MasterBLLFactory.GetBLL<IConsumeCardMasterBL>(MasterBLLFactory.ConsumeCardMaster);
            this._IRechargeRecordBL = MasterBLLFactory.GetBLL<IRechargeRecordBL>(MasterBLLFactory.RechargeRecord);
            this._ICodeMasterBL = sysFac.MasterBLLFactory.GetBLL<sysBL.ICodeMasterBL>(sysFac.MasterBLLFactory.CodeMaster_cmt);
            this._ICardUserAccountBL = MasterBLLFactory.GetBLL<ICardUserAccountBL>(MasterBLLFactory.CardUserAccount);
            this._IPreRechargeRecordBL = MasterBLLFactory.GetBLL<IPreRechargeRecordBL>(MasterBLLFactory.PreRechargeRecord);
            this._IPreConsumeRecordBL = MasterBLLFactory.GetBLL<IPreConsumeRecordBL>(MasterBLLFactory.PreConsumeRecord);

            labConnDetail.Click += new EventHandler(base.labReaderState_Click);

            this._tmrMatchCard = new Timer();
            this._tmrMatchCard.Interval = 1200;
            this._tmrMatchCard.Tick += new EventHandler(_tmrMatchCard_Tick);

            this._IsReadingNew = true;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.Cursor = Cursors.WaitCursor;
            try
            {
                loadAllControls();
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex);
                gbxAll.Enabled = false;
            }
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// 加载控件资料
        /// </summary>
        private void loadAllControls()
        {
            if (this._IsConnected)
            {
                labConnDetail.Text = "读卡器已连接";
            }
            else
            {
                labConnDetail.Text = "读卡器未连接";
            }

            BindComboData(DefineConstantValue.MasterType.UserDepartment);
            BindComboData(DefineConstantValue.MasterType.UserClass);

            BindAdvanceCost();
            BindNewCardCost();

            tbxUserName.Text = string.Empty;
            tbxUserNum.Text = string.Empty;
            ckbNoPaired.Checked = true;
            resetBatchReadStatus();
            rBtnSingleMatch.Checked = true;

            lvUserCardDetail.Items.Clear();

            gbxAll.Enabled = true;
        }

        void _tmrMatchCard_Tick(object sender, EventArgs e)
        {
            this.Invoke(new DelegateBatchRead(BatchMatchProfile));
        }

        /// <summary>
        /// 批量发卡操作
        /// </summary>
        void BatchMatchProfile()
        {
            if (base._IsConnected)
            {
                string strCardID = null;
                if (!this._IsReaderReading)
                {
                    strCardID = getCardID();
                    if (!string.IsNullOrEmpty(strCardID))
                    {
                        if (!this._IsBatchReading && this._IsReadingNew)
                        {
                            BatchMatchCard(strCardID);
                        }
                    }
                    else
                    {
                        //tbxContent.Text = string.Empty;
                        this._IsReadingNew = true;
                    }
                }
            }
        }

        /// <summary>
        /// 获取卡ID
        /// </summary>
        /// <returns></returns>
        string getCardID()
        {
            string strCardID = null;
            try
            {
                this._IsReaderReading = true;

                strCardID = this._Reader.ReadCardOriginalID();
                if (string.IsNullOrEmpty(strCardID))
                {
                    this._IsReadingNew = true;
                    this._IsReaderReading = false;
                    return strCardID;
                }
                if (this._CurrentCardID == strCardID)
                {
                    this._IsReadingNew = false;
                }
                else
                {
                    this._CurrentCardID = strCardID;
                    this._IsReadingNew = true;
                }

                this._IsReaderReading = false;
            }
            catch (Exception ex)
            {
                this._tmrMatchCard.Stop();
                btnBatchBegin.Enabled = true;
                btnBatchEnd.Enabled = false;
                this._IsBatchReading = false;

                base.ShowWarningMessage("卡片已损坏或摆放位置不正确，请重试。" + ex.Message);
            }
            return strCardID;
        }

        /// <summary>
        /// 连续自动发卡
        /// </summary>
        void BatchMatchCard(string strCardID)
        {
            if (lvUserCardDetail.SelectedItems.Count > 0)
            {
                this._IsReaderReading = true;
                this._IsBatchReading = true;

                try
                {
                    decimal fAdvanceMoney = decimal.Parse(labAdvanceMoney.Text.Trim());
                    decimal fNewCardCost = decimal.Parse(labNewCardCost.Text.Trim());
                    Guid userID = new Guid(lvUserCardDetail.SelectedItems[0].SubItems[1].Text);

                    //发卡
                    ReturnValueInfo rvInfo = pairCardLogic(userID, fNewCardCost, fAdvanceMoney);

                    if (rvInfo.boolValue && !rvInfo.isError)
                    {
                        UserCardPair_ucp_Info currentPair = rvInfo.ValueObject as UserCardPair_ucp_Info;
                        tbxContent.Text = rvInfo.messageText + Environment.NewLine + string.Empty.PadLeft(15, '-') + DateTime.Now.ToString() + Environment.NewLine + tbxContent.Text;

                        //发卡成功后，发卡对象向下选择
                        lvUserCardDetail.SelectedItems[0].SubItems[5].Text = currentPair.ucp_iCardNo.ToString();
                        lvUserCardDetail.SelectedItems[0].SubItems[6].Text = currentPair.ucp_dPairTime.ToString();
                        int iSelectedIndex = lvUserCardDetail.SelectedItems[0].Index;
                        iSelectedIndex++;
                        if (this.lvUserCardDetail.Items.Count > iSelectedIndex)
                        {
                            this.lvUserCardDetail.Items[iSelectedIndex - 1].Selected = false;
                            this.lvUserCardDetail.Items[iSelectedIndex].Selected = true;

                            this._IsReaderReading = false;
                            this._IsBatchReading = false;
                        }
                        else
                        {
                            resetBatchReadStatus();

                            //btnSelectUser_Click(null, null);
                            this.ShowInformationMessage("发卡结束。");
                        }
                    }
                    else
                    {
                        resetBatchReadStatus();
                        if (rvInfo.isError)
                        {
                            ShowErrorMessage(rvInfo.messageText);
                        }
                        else if (!rvInfo.boolValue)
                        {
                            ShowWarningMessage(rvInfo.messageText);
                        }
                        //btnSelectUser_Click(null, null);
                    }
                }
                catch (Exception exFirst)
                {
                    resetBatchReadStatus();

                    this.ShowErrorMessage(exFirst);
                }
            }
        }

        /// <summary>
        /// 重置结束连续读卡后的控件状态
        /// </summary>
        private void resetBatchReadStatus()
        {
            this._tmrMatchCard.Stop();

            sysToolBar.Enabled = true;
            btnBatchBegin.Enabled = true;
            btnBatchEnd.Enabled = false;
            lvUserCardDetail.Enabled = true;
            gbxSearch.Enabled = true;

            this.pnlContent.Visible = false;
            tbxContent.Text = string.Empty;

            this._IsReaderReading = false;
            this._IsBatchReading = false;
            this._IsReadingNew = true;
            this._CurrentCardID = null;
        }

        /// <summary>
        /// 绑定透支款费用
        /// </summary>
        private void BindAdvanceCost()
        {
            CodeMaster_cmt_Info codeInfo = this._ICodeMasterBL.SearchRecords(new CodeMaster_cmt_Info() { cmt_cKey1 = Common.DefineConstantValue.CodeMasterDefine.KEY1_ConstantExpenses, cmt_cKey2 = Common.DefineConstantValue.CodeMasterDefine.KEY2_AdvanceCost }).FirstOrDefault() as CodeMaster_cmt_Info;
            if (codeInfo != null)
            {
                labAdvanceMoney.Text = codeInfo.cmt_fNumber.ToString();
            }
            else
            {
                labAdvanceMoney.Text = "设置异常";
            }
        }

        /// <summary>
        /// 绑定新卡工本费
        /// </summary>
        private void BindNewCardCost()
        {
            CodeMaster_cmt_Info codeInfo = this._ICodeMasterBL.SearchRecords(new CodeMaster_cmt_Info() { cmt_cKey1 = Common.DefineConstantValue.CodeMasterDefine.KEY1_ConstantExpenses, cmt_cKey2 = Common.DefineConstantValue.CodeMasterDefine.KEY2_NewCardCost }).FirstOrDefault() as CodeMaster_cmt_Info;
            if (codeInfo != null)
            {
                labNewCardCost.Text = codeInfo.cmt_fNumber.ToString();
            }
            else
            {
                labNewCardCost.Text = "设置异常";
            }
        }

        /// <summary>
        /// 绑定下拉框数据
        /// </summary>
        void BindComboData(DefineConstantValue.MasterType mType)
        {
            List<IModelObject> result = new List<IModelObject>();
            try
            {
                result = this._IGeneralBL.GetMasterDataInformations(mType);
            }
            catch (Exception Ex)
            {
                ShowErrorMessage(Ex);
            }
            switch (mType)
            {
                case DefineConstantValue.MasterType.UserDepartment:
                    cbxDept.SetDataSource(result, -1);
                    cbxDept.SelectItemForValue(string.Empty);
                    break;

                case DefineConstantValue.MasterType.UserClass:
                    cbxClass.SetDataSource(result, -1);
                    cbxClass.SelectItemForValue(string.Empty);
                    break;

                default:
                    break;
            }
        }

        private void rBtnSingleMatch_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rBtnTarget = sender as RadioButton;
            if (rBtnTarget.Checked)
            {
                btnSingleMatch.Enabled = true;

                btnBatchBegin.Enabled = false;
                btnBatchEnd.Enabled = false;
            }
        }

        private void rBtnBatchMatch_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rBtnTarget = sender as RadioButton;
            if (rBtnTarget.Checked)
            {
                btnSingleMatch.Enabled = false;

                btnBatchBegin.Enabled = true;
                btnBatchEnd.Enabled = false;
            }
        }

        private void btnBatchBegin_Click(object sender, EventArgs e)
        {
            try
            {
                bool resUkey = base.CheckUKey();
                if (!resUkey)
                {
                    return;
                }
                if (lvUserCardDetail.Items.Count > 0)
                {
                    gbxSearch.Enabled = false;
                    sysToolBar.Enabled = false;
                    btnBatchBegin.Enabled = false;
                    btnBatchEnd.Enabled = true;
                    lvUserCardDetail.Enabled = false;
                    if (lvUserCardDetail.SelectedItems.Count < 1)
                    {
                        lvUserCardDetail.Items[0].Selected = true;
                    }

                    this._tmrMatchCard.Start();

                    this.pnlContent.Visible = true;
                    tbxContent.Text = "连续发卡开始。";
                }
                else
                {
                    this.ShowWarningMessage("没有可以发卡的用户信息。");
                }
            }
            catch (Exception ex)
            {
                this._tmrMatchCard.Stop();

                gbxSearch.Enabled = true;
                sysToolBar.Enabled = true;
                btnBatchBegin.Enabled = true;
                btnBatchEnd.Enabled = false;
                lvUserCardDetail.Enabled = true;

                this.ShowErrorMessage("启动连续发卡操作失败。" + Environment.NewLine + ex);
            }
        }

        private void btnBatchEnd_Click(object sender, EventArgs e)
        {
            resetBatchReadStatus();

            //btnSelectUser_Click(null, null);
        }

        private void btnSingleMatch_Click(object sender, EventArgs e)
        {
            bool resUkey = base.CheckUKey();
            if (!resUkey)
            {
                return;
            }
            if (!this._IsConnected)
            {
                this.ShowWarningMessage("读卡器未连接，请重试。");
                labConnDetail.Focus();
                return;
            }

            if (lvUserCardDetail.SelectedItems.Count > 0)
            {
                try
                {
                    #region 发卡逻辑

                    //透支款
                    decimal fAdvanceMoney = decimal.Parse(labAdvanceMoney.Text.Trim());
                    //新发卡工本费
                    decimal fNewCardCost = decimal.Parse(labNewCardCost.Text.Trim());
                    //用户记录ID
                    Guid userID = new Guid(lvUserCardDetail.SelectedItems[0].SubItems[1].Text);

                    this.Cursor = Cursors.WaitCursor;

                    //发卡
                    ReturnValueInfo rvInfo = pairCardLogic(userID, fNewCardCost, fAdvanceMoney);
                    if (rvInfo.boolValue && !rvInfo.isError)
                    {
                        ShowInformationMessage(rvInfo.messageText);
                    }
                    else
                    {
                        if (rvInfo.isError)
                        {
                            ShowErrorMessage(rvInfo.messageText);
                        }
                        else
                        {
                            ShowWarningMessage(rvInfo.messageText);
                        }
                    }

                    btnSingleMatch.Enabled = false;
                    //btnSelectUser_Click(null, null);
                    this.Cursor = Cursors.Default;

                    #endregion
                }
                catch (Exception ex)
                {
                    this.ShowErrorMessage(ex);
                }
            }
        }

        /// <summary>
        /// 单卡发卡逻辑
        /// </summary>
        /// <param name="userID">用户信息记录ID</param>
        /// <param name="fNewCardCost">新卡工本费</param>
        /// <param name="fAdvanceCost">可透支额</param>
        /// <returns></returns>
        ReturnValueInfo pairCardLogic(Guid userID, decimal fNewCardCost, decimal fAdvanceCost)
        {
            ReturnValueInfo rvInfo = new ReturnValueInfo();
            try
            {
                ConsumeCardInfo sourceCardInfo = this._Reader.ReadCardInfo(base._CardInfoSection, base._SectionPwd);
                if (sourceCardInfo == null)
                {
                    sourceCardInfo = this._Reader.ReadCardInfo(base._CardInfoSection, base._OrganizeSectionPwd);
                    if (sourceCardInfo != null)
                    {
                        rvInfo = this._Reader.ModifySectionPwd(base._CardInfoSection, base._OrganizeSectionPwd, base._SectionPwd);
                    }
                }

                if (sourceCardInfo == null)
                {
                    rvInfo.messageText = "卡片已损坏，请重试。";
                    rvInfo.isError = true;
                    return rvInfo;
                }

                string strCardID = sourceCardInfo.CardSourceID;
                if (strCardID == null)
                {
                    rvInfo.messageText = "卡片已损坏或摆放位置不正确，请重试。";
                    rvInfo.isError = true;
                    return rvInfo;
                }

                ConsumeCardMaster_ccm_Info cardSearch = null;
                ConsumeCardMaster_ccm_Info cardInfo = new ConsumeCardMaster_ccm_Info();
                cardInfo.ccm_cCardID = strCardID;

                // *********1、搜索卡主档，检查是否存在此卡资料*********
                #region 卡主档信息检查
                cardSearch = this._IConsumeCardMasterBL.DisplayRecord(cardInfo) as ConsumeCardMaster_ccm_Info;
                if (cardSearch == null)
                {
                    //无相应卡主档记录则先添加此卡
                    cardInfo.ccm_cCardState = DefineConstantValue.CardUseState.NotUsed.ToString();
                    cardInfo.ccm_cAdd = base.UserInformation.usm_cUserLoginID;
                    cardInfo.ccm_dAddDate = DateTime.Now;
                    cardInfo.ccm_cLast = cardInfo.ccm_cAdd;
                    cardInfo.ccm_dLastDate = cardInfo.ccm_dAddDate;

                    rvInfo = this._IConsumeCardMasterBL.Save(cardInfo, DefineConstantValue.EditStateEnum.OE_Insert);
                    if (!rvInfo.boolValue || rvInfo.isError)
                    {
                        rvInfo.messageText = "录入本卡信息失败，请重试。";
                        rvInfo.isError = true;
                        return rvInfo;
                    }
                }

                #endregion

                try
                {
                    //*********2、插入发卡信息************
                    UserCardPair_ucp_Info pairInfo = new UserCardPair_ucp_Info();

                    #region 检查是否已发卡

                    pairInfo = new UserCardPair_ucp_Info();
                    pairInfo.ucp_cCUSID = userID;
                    List<UserCardPair_ucp_Info> listSearch = this._IUserCardPairBL.SearchRecords(pairInfo);
                    listSearch = listSearch.Where(x => x.ucp_cUseStatus != Common.DefineConstantValue.ConsumeCardStatus.Returned.ToString()).ToList();
                    if (listSearch.Count > 0)
                    {
                        //此人已发卡
                        rvInfo.messageText = "此用户已被发卡。" + Environment.NewLine + "拥有卡号：" + listSearch[0].ucp_iCardNo.ToString();
                        return rvInfo;
                    }

                    pairInfo = new UserCardPair_ucp_Info();
                    pairInfo.ucp_iCardNo = int.Parse(sourceCardInfo.CardNo);
                    pairInfo.ucp_cCardID = cardInfo.ccm_cCardID;
                    listSearch = this._IUserCardPairBL.SearchRecords(pairInfo);
                    listSearch = listSearch.Where(x => x.ucp_cUseStatus != Common.DefineConstantValue.ConsumeCardStatus.Returned.ToString()).ToList();
                    if (listSearch.Count > 0)
                    {
                        //此卡已发卡
                        rvInfo.messageText = "此卡已被发卡。" + Environment.NewLine + "卡拥有人：" + listSearch[0].CardOwner.cus_cStudentID + " " + listSearch[0].CardOwner.cus_cChaName;
                        return rvInfo;
                    }

                    #endregion

                    pairInfo = new UserCardPair_ucp_Info();
                    pairInfo.ucp_cRecordID = Guid.NewGuid();
                    pairInfo.ucp_cCardID = cardInfo.ccm_cCardID;
                    pairInfo.ucp_cCUSID = userID;
                    pairInfo.ucp_dPairTime = DateTime.Now;
                    pairInfo.ucp_cUseStatus = Common.DefineConstantValue.ConsumeCardStatus.Normal.ToString();
                    pairInfo.ucp_cAdd = base.UserInformation.usm_cUserLoginID;
                    pairInfo.ucp_dAddDate = pairInfo.ucp_dPairTime;
                    pairInfo.ucp_cLast = pairInfo.ucp_cAdd;
                    pairInfo.ucp_dLastDate = pairInfo.ucp_dAddDate;

                    rvInfo = this._IUserCardPairBL.InsertNewCard(pairInfo, fNewCardCost);

                    if (rvInfo.boolValue && !rvInfo.isError)
                    {
                        // *********3、写入卡物理信息*********
                        #region 发卡

                        UserCardPair_ucp_Info currentPair = this._IUserCardPairBL.DisplayRecord(new UserCardPair_ucp_Info()
                        {
                            ucp_cRecordID = pairInfo.ucp_cRecordID
                        });

                        CardUserMaster_cus_Info userInfo = null;

                        //抽取用户资料【写入卡显示名称】
                        string strCardName = string.Empty;//卡片显示信息
                        #region 写入卡显示信息

                        if (currentPair.CardOwner != null)
                        {
                            CardUserMaster_cus_Info userSearch = new CardUserMaster_cus_Info()
                            {
                                cus_cRecordID = currentPair.CardOwner.cus_cRecordID
                            };
                            userInfo = this._ICardUserMasterBL.DisplayRecord(userSearch);

                            if (userInfo != null)
                            {
                                #region 判断身份

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
                                        rvInfo.messageText = "用户班级信息不全，请重试。";
                                        rvInfo.isError = true;
                                        return rvInfo;
                                    }
                                }
                                else if (userInfo.cus_cIdentityNum == DefineConstantValue.CodeMasterDefine.KEY2_SIOT_CardUserIdentity_Staff)//老师
                                {
                                    string strTmpName = userInfo.cus_cChaName;
                                    if (userInfo.cus_cChaName.Length > 6)
                                    {
                                        strTmpName = strTmpName.Substring(0, 6);
                                    }
                                    strCardName = strTmpName;
                                }
                                else
                                {
                                    rvInfo.messageText = "有未知身份的用户。" + Environment.NewLine + userInfo.cus_cStudentID + " " + userInfo.cus_cChaName;
                                    rvInfo.isError = true;
                                    return rvInfo;
                                }

                                #endregion

                                ConsumeCardInfo writeCardInfo = new ConsumeCardInfo() { CardBalance = 0, CardNo = currentPair.ucp_iCardNo.ToString(), CardPwd = base._PayPwd, ConsumeTimes = 0, Name = strCardName };
                                //写入卡显示信息
                                rvInfo = this._Reader.WriteCardInfo(base._CardInfoSection, base._SectionPwd, writeCardInfo);
                                if (!rvInfo.boolValue || rvInfo.isError)
                                {
                                    rvInfo = this._IUserCardPairBL.Save(pairInfo, DefineConstantValue.EditStateEnum.OE_Delete);
                                    if (rvInfo.boolValue && rvInfo.isError)
                                    {
                                        rvInfo.messageText = "写入用户卡信息时出现异常，当前发卡记录已重置，请重新进行发卡操作。";
                                        rvInfo.isError = true;
                                        return rvInfo;
                                    }
                                    else
                                    {
                                        rvInfo.messageText = "写入用户卡信息时出现异常，当前发卡记录未能重置，请联系系统管理员重置发卡记录后重新发卡。";
                                        rvInfo.isError = true;
                                        return rvInfo;
                                    }
                                }
                            }
                            else
                            {
                                rvInfo.messageText = "用户信息异常，请检查该用户信息后重试。";
                                rvInfo.isError = true;
                                return rvInfo;
                            }
                        }

                        #endregion

                        if (userInfo.cus_cIdentityNum == DefineConstantValue.CodeMasterDefine.KEY2_SIOT_CardUserIdentity_Student)
                        {
                            #region 学生发卡，需预充透支金额

                            //插入发卡信息后，充入透支金额
                            rvInfo = this._Reader.Recharge((short)base._CardInfoSection, base._SectionPwd, fAdvanceCost);

                            if (rvInfo.boolValue && !rvInfo.isError)
                            {
                                RechargeRecord_rcr_Info record = new RechargeRecord_rcr_Info();

                                record.rcr_cRecordID = Guid.NewGuid();
                                record.rcr_cCardID = cardInfo.ccm_cCardID;
                                record.rcr_cRechargeType = DefineConstantValue.ConsumeMoneyFlowType.Recharge_AdvanceMoney.ToString();
                                record.rcr_cStatus = DefineConstantValue.ConsumeMoneyFlowStatus.Finished.ToString();
                                record.rcr_cUserID = userID;
                                record.rcr_dRechargeTime = DateTime.Now;
                                record.rcr_cAdd = base.UserInformation.usm_cUserLoginID;
                                record.rcr_cLast = record.rcr_cAdd;
                                record.rcr_dLastDate = record.rcr_dRechargeTime;
                                record.rcr_fRechargeMoney = fAdvanceCost;

                                //成功充值后，将充值信息计入相应记录表
                                rvInfo = this._IRechargeRecordBL.Save(record, DefineConstantValue.EditStateEnum.OE_Insert);
                                if (!rvInfo.boolValue || rvInfo.isError)
                                {
                                    //卡充值失败，将原金额扣除
                                    rvInfo = this._Reader.Recharge((short)base._CardInfoSection, base._SectionPwd, fAdvanceCost * -1);

                                    rvInfo.messageText = "发卡成功，保存预充透支金额失败。";
                                    rvInfo.isError = true;
                                    return rvInfo;
                                }

                                ConsumeCardInfo cardCurrentInfo = this._Reader.ReadCardInfo(base._CardInfoSection, base._SectionPwd);
                                string strContent = "发卡成功。" + Environment.NewLine + "学生姓名：" + userInfo.cus_cChaName;
                                if (cardCurrentInfo != null)
                                {
                                    strContent += Environment.NewLine + "卡可用余额：￥" + cardCurrentInfo.CardBalance.ToString() + "元。";
                                    strContent += Environment.NewLine + "（包含可透支金额：￥" + fAdvanceCost.ToString() + "元）";
                                    strContent += Environment.NewLine + "新卡工本费：￥" + fNewCardCost.ToString() + "元。";
                                }

                                rvInfo.messageText = strContent;
                            }//CardRecharge
                            else
                            {
                                rvInfo.messageText = "发卡成功，消费卡充入预支款失败。";
                                rvInfo.isError = true;
                                return rvInfo;
                            }

                            #endregion
                        }
                        else if (userInfo.cus_cIdentityNum == DefineConstantValue.CodeMasterDefine.KEY2_SIOT_CardUserIdentity_Staff)
                        {
                            #region 老师卡发卡

                            rvInfo.messageText = "发卡成功。" + Environment.NewLine
                                + "老师姓名：" + userInfo.cus_cChaName + "。" + Environment.NewLine
                                + "新卡工本费：" + fNewCardCost.ToString() + "。";

                            #endregion
                        }

                        #endregion
                        rvInfo.ValueObject = currentPair;

                        //*********4、查询是否有预充值款项，有则进行预充值*********
                        //查找该用户是否有【转账充值】款项 
                        List<PreRechargeRecord_prr_Info> listPreRecharge = this._IPreRechargeRecordBL.SearchRecords(new PreRechargeRecord_prr_Info()
                        {
                            prr_cUserID = userID,
                            prr_cStatus = Common.DefineConstantValue.ConsumeMoneyFlowStatus.WaitForAcceptTransfer.ToString()
                        });
                        if (listPreRecharge != null && listPreRecharge.Count > 0)
                        {
                            #region 预充值

                            //查找该用户是否有未付的【预消费】款项
                            decimal fSumPreCost = decimal.Zero;//未结算消费总额
                            List<PreConsumeRecord_pcs_Info> listPreCost = this._IPreConsumeRecordBL.SearchRecords(new PreConsumeRecord_pcs_Info()
                            {
                                pcs_cUserID = userID,
                            });
                            if (listPreCost != null)
                            {
                                listPreCost = listPreCost.Where(x =>
                                    x.pcs_lIsSettled == false
                                    && x.pcs_cConsumeType != Common.DefineConstantValue.ConsumeMoneyFlowType.IndeterminateCost.ToString()
                                    && x.pcs_cConsumeType != Common.DefineConstantValue.ConsumeMoneyFlowType.AdvanceMealCost.ToString()
                                    && x.pcs_cConsumeType != Common.DefineConstantValue.ConsumeMoneyFlowType.HedgeFund.ToString()
                                    ).ToList();
                                if (listPreCost.Count > 0)
                                {
                                    fSumPreCost = listPreCost.Sum(x => x.pcs_fCost);
                                }
                            }

                            ConsumeCardInfo CardInfo = this._Reader.ReadCardInfo(base._CardInfoSection, base._SectionPwd);
                            if (CardInfo == null)
                            {
                                rvInfo.messageText += Environment.NewLine + "确认卡片信息失败，无法继续进行预充值操作。";
                                rvInfo.boolValue = false;
                                return rvInfo;
                            }
                            decimal fCardBalance = CardInfo.CardBalance;//卡片现可用余额
                            decimal fPreRecharge = listPreRecharge.Sum(x => x.prr_fRechargeMoney);//预充值累积款
                            decimal fCardRecharge = fPreRecharge + fSumPreCost;//预充值款 + 未结算预付款  = 卡片应充值金额                            

                            if (fPreRecharge > 0 && fCardRecharge >= 0)
                            {
                                #region 存在预充值记录，并且足以扣除未结算款项

                                ReturnValueInfo rvInfoPreRecharge = this._Reader.Recharge(base._CardInfoSection, base._SectionPwd, fCardRecharge);
                                if (rvInfoPreRecharge.boolValue && !rvInfoPreRecharge.isError)
                                {
                                    List<RechargeRecord_rcr_Info> listRechargeInsert = new List<RechargeRecord_rcr_Info>();
                                    decimal fPerTimeRecharge = fSumPreCost;

                                    //foreach (PreRechargeRecord_prr_Info preRecItem in listPreRecharge)
                                    //{
                                    //    RechargeRecord_rcr_Info rechargeRecord = new RechargeRecord_rcr_Info();
                                    //    rechargeRecord.rcr_cAdd = base.UserInformation.usm_cUserLoginID;
                                    //    rechargeRecord.rcr_cCardID = pairInfo.ucp_cCardID;
                                    //    rechargeRecord.rcr_cLast = base.UserInformation.usm_cUserLoginID;
                                    //    rechargeRecord.rcr_cRechargeType = preRecItem.prr_cRechargeType;
                                    //    rechargeRecord.rcr_cRecordID = Guid.NewGuid();
                                    //    rechargeRecord.rcr_cStatus = DefineConstantValue.ConsumeMoneyFlowStatus.Finished.ToString();
                                    //    rechargeRecord.rcr_cUserID = pairInfo.ucp_cCUSID;
                                    //    rechargeRecord.rcr_dLastDate = DateTime.Now;
                                    //    rechargeRecord.rcr_dRechargeTime = DateTime.Now;
                                    //    rechargeRecord.rcr_fRechargeMoney = preRecItem.prr_fRechargeMoney;

                                    //    fPerTimeRecharge += preRecItem.prr_fRechargeMoney;
                                    //    if (fPerTimeRecharge < 0)
                                    //    {
                                    //        rechargeRecord.rcr_fBalance = fCardBalance;
                                    //    }
                                    //    else
                                    //    {
                                    //        rechargeRecord.rcr_fBalance = fCardBalance + fPerTimeRecharge;
                                    //    }

                                    //    preRecItem.prr_cRCRID = rechargeRecord.rcr_cRecordID;
                                    //    listRechargeInsert.Add(rechargeRecord);
                                    //}

                                    for (int i = 0; i < listPreRecharge.Count; i++)
                                    {
                                        RechargeRecord_rcr_Info rechargeRecord = new RechargeRecord_rcr_Info();
                                        rechargeRecord.rcr_cAdd = base.UserInformation.usm_cUserLoginID;
                                        rechargeRecord.rcr_cCardID = pairInfo.ucp_cCardID;
                                        rechargeRecord.rcr_cLast = base.UserInformation.usm_cUserLoginID;
                                        rechargeRecord.rcr_cRechargeType = listPreRecharge[i].prr_cRechargeType;
                                        rechargeRecord.rcr_cRecordID = Guid.NewGuid();
                                        rechargeRecord.rcr_cStatus = DefineConstantValue.ConsumeMoneyFlowStatus.Finished.ToString();
                                        rechargeRecord.rcr_cUserID = pairInfo.ucp_cCUSID;
                                        rechargeRecord.rcr_dLastDate = DateTime.Now;
                                        rechargeRecord.rcr_dRechargeTime = DateTime.Now;
                                        rechargeRecord.rcr_fRechargeMoney = listPreRecharge[i].prr_fRechargeMoney;

                                        fPerTimeRecharge += listPreRecharge[i].prr_fRechargeMoney;
                                        if (fPerTimeRecharge < 0)
                                        {
                                            //rechargeRecord.rcr_fBalance = fCardBalance;

                                            if (i != listPreRecharge.Count - 1)
                                            {
                                                rechargeRecord.rcr_fBalance = fCardBalance;
                                            }
                                            else
                                            {
                                                rechargeRecord.rcr_fBalance = fCardBalance + fPerTimeRecharge;
                                            }
                                        }
                                        else
                                        {
                                            rechargeRecord.rcr_fBalance = fCardBalance + fPerTimeRecharge;
                                        }

                                        listPreRecharge[i].prr_cRCRID = rechargeRecord.rcr_cRecordID;
                                        listRechargeInsert.Add(rechargeRecord);
                                    }

                                    rvInfoPreRecharge = this._IRechargeRecordBL.UpdateRechargeRecord(listPreRecharge, listRechargeInsert, fSumPreCost);

                                    if (rvInfoPreRecharge.boolValue && !rvInfoPreRecharge.isError)
                                    {
                                        rvInfo.messageText += Environment.NewLine + "存在预转账记录" + listPreRecharge.Count.ToString() + "条，款项合共：￥" + fPreRecharge.ToString() + "元，已成功充入。";
                                        rvInfo.boolValue = true;
                                        return rvInfo;
                                    }
                                    else
                                    {
                                        rvInfoPreRecharge = this._Reader.Recharge(base._CardInfoSection, base._SectionPwd, fPreRecharge);
                                        if (rvInfoPreRecharge.isError || !rvInfoPreRecharge.boolValue)
                                        {
                                            rvInfo.messageText += Environment.NewLine + "保存预充值记录失败，卡片金额已更新，请联系管理员扣减卡金额。";
                                        }
                                    }
                                }
                                else
                                {
                                    rvInfo.messageText += Environment.NewLine + "预充值操作失败，无法将该用户的待转账款项充入卡内，请稍后手动转账充值。" + Environment.NewLine + rvInfoPreRecharge.messageText;
                                    rvInfo.boolValue = false;
                                }

                                #endregion
                            }
                            else
                            {
                                if (fCardRecharge < 0)
                                {
                                    rvInfo.messageText += Environment.NewLine + "本用户有转账充值记录" + listPreRecharge.Count.ToString() + "条，但不足以抵扣未结算预付款，请充值。";
                                    rvInfo.boolValue = true;
                                    return rvInfo;
                                }
                            }

                            #endregion
                        }
                        else
                        {
                            rvInfo.boolValue = true;
                            return rvInfo;
                        }
                    }
                    else
                    {
                        rvInfo.messageText = "保存新发卡资料失败。" + rvInfo.messageText;
                        rvInfo.isError = true;
                        return rvInfo;
                    }
                }
                catch (Exception ex)
                {
                    rvInfo.messageText = ex.Message;
                    rvInfo.isError = true;
                    return rvInfo;
                }
            }
            catch (Exception exAll)
            {
                rvInfo.messageText = exAll.Message;
                rvInfo.isError = true;
            }
            return rvInfo;
        }

        private void cbxClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxClass.SelectedIndex != -1 && !string.IsNullOrEmpty(cbxClass.Text))
            {
                //选择班级时，取消部门的选择
                cbxDept.SelectedIndex = -1;
            }
        }

        private void cbxDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxDept.SelectedIndex != -1 && !string.IsNullOrEmpty(cbxDept.Text))
            {
                //选择部门时，取消班级的选择
                cbxClass.SelectedIndex = -1;
            }
        }

        private void btnSelectUser_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                CardUserMaster_cus_Info searchInfo = new CardUserMaster_cus_Info();
                if (cbxClass.SelectedIndex > 0)
                {
                    searchInfo.cus_cIdentityNum = DefineConstantValue.CodeMasterDefine.KEY2_SIOT_CardUserIdentity_Student;
                    //班别
                    searchInfo.cus_cClassID = new Guid(cbxClass.SelectedValue.ToString());
                }
                if (cbxDept.SelectedIndex > 0)
                {
                    searchInfo.cus_cIdentityNum = DefineConstantValue.CodeMasterDefine.KEY2_SIOT_CardUserIdentity_Staff;
                    //部门
                    searchInfo.cus_cClassID = new Guid(cbxDept.SelectedValue.ToString());
                }
                if (!string.IsNullOrEmpty(tbxUserNum.Text.Trim()))
                {
                    //学号\工号
                    searchInfo.cus_cStudentID = tbxUserNum.Text.Trim();
                }
                if (!string.IsNullOrEmpty(tbxUserName.Text.Trim()))
                {
                    //姓名
                    searchInfo.cus_cChaName = tbxUserName.Text.Trim();
                }

                List<CardUserMaster_cus_Info> listCardUsers = this._ICardUserMasterBL.SearchRecordsWithCardInfo(searchInfo);
                if (listCardUsers != null)
                {
                    if (ckbNoPaired.Checked)
                    {
                        listCardUsers = listCardUsers.FindAll(x => x.PairCardNo == null).ToList();
                    }
                }
                if (listCardUsers != null && listCardUsers.Count < 1)
                {
                    this.ShowInformationMessage("无合符条件的记录。");
                }

                listCardUsers = listCardUsers.OrderBy(x => x.cus_cStudentID).ToList();

                lvUserCardDetail.SetDataSource<CardUserMaster_cus_Info>(listCardUsers);
            }
            catch (Exception ex)
            {
                this.ShowErrorMessage(ex);
            }
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// 发卡情况详细信息
        /// </summary>
        //class CardUserDetail : CardUserMaster_cus_Info
        //{
        //    public string CardID { get; set; }
        //    //public int CardNo { get; set; }
        //    public DateTime? PairTime { get; set; }
        //    //public string ClassName { get; set; }
        //    public string PairStatus { get; set; }
        //}

        private void lvUserCardDetail_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvUserCardDetail.SelectedItems.Count > 0)
            {
                if (rBtnSingleMatch.Checked)
                {
                    btnSingleMatch.Enabled = true;
                }
            }
            else
            {
                if (rBtnSingleMatch.Checked)
                {
                    btnSingleMatch.Enabled = false;
                }
            }
        }

        private void btnSetNewCardCost_Click(object sender, EventArgs e)
        {
            dlgConstantExpensesSetting dlg = new dlgConstantExpensesSetting();
            dlg.SubKeyName = Common.DefineConstantValue.CodeMasterDefine.KEY2_NewCardCost;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                labNewCardCost.Text = dlg.NewValue.ToString();
            }
        }

        private void lvUserCardDetail_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (lvUserCardDetail.Sorting == SortOrder.Descending)
            {
                ListViewSorter sorter = new ListViewSorter(e.Column, SortOrder.Ascending);
                lvUserCardDetail.ListViewItemSorter = sorter;
                lvUserCardDetail.Sorting = SortOrder.Ascending;
            }
            else
            {
                ListViewSorter sorter = new ListViewSorter(e.Column, SortOrder.Descending);
                lvUserCardDetail.ListViewItemSorter = sorter;
                lvUserCardDetail.Sorting = SortOrder.Descending;
            }
        }

        private void sysToolBar_OnItemRefresh_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                loadAllControls();
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex);
                gbxAll.Enabled = false;
            }
            this.Cursor = Cursors.Default;
        }
    }
}
