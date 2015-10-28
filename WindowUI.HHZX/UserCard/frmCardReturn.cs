using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL.IBLL.General;
using BLL.IBLL.HHZX.UserInfomation.CardUserInfo;
using BLL.IBLL.HHZX.UserCard;
using Model.HHZX.UserInfomation.CardUserInfo;
using BLL.Factory.General;
using BLL.Factory.HHZX;
using Model.IModel;
using Common;
using WindowUI.HHZX.ClassLibrary.Public;
using Model.HHZX.UserCard;
using PaymentEquipment.Entity;
using BLL.IBLL.HHZX.ConsumeAccount;
using Model.General;
using Model.HHZX.ComsumeAccount;

namespace WindowUI.HHZX.UserCard
{
    public partial class frmCardReturn : BaseReaderForm
    {
        #region 自定义变量

        IGeneralBL _IGeneralBL;
        ICardUserMasterBL _ICardUserMasterBL;
        IUserCardPairBL _IUserCardPairBL;
        ICardUserAccountBL _ICardUserAccountBL;
        IPreConsumeRecordBL _IPreConsumeRecordBL;

        bool _IsBatchModify;

        /// <summary>
        /// 缓存中的查询用户记录
        /// </summary>
        List<CardUserMaster_cus_Info> _ListQueryStuInfo;

        #endregion

        public frmCardReturn()
        {
            InitializeComponent();

            this._ListQueryStuInfo = new List<CardUserMaster_cus_Info>();

            this._IGeneralBL = GeneralBLLFactory.GetBLL<IGeneralBL>(GeneralBLLFactory.General);

            this._ICardUserMasterBL = MasterBLLFactory.GetBLL<ICardUserMasterBL>(MasterBLLFactory.CardUserMaster);
            this._IUserCardPairBL = MasterBLLFactory.GetBLL<IUserCardPairBL>(MasterBLLFactory.UserCardPair);
            this._ICardUserAccountBL = MasterBLLFactory.GetBLL<ICardUserAccountBL>(MasterBLLFactory.CardUserAccount);
            this._IPreConsumeRecordBL = MasterBLLFactory.GetBLL<IPreConsumeRecordBL>(MasterBLLFactory.PreConsumeRecord);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            resetAllControllStatus();

            bindComboBox(DefineConstantValue.MasterType.UserDepartment);
            bindComboBox(DefineConstantValue.MasterType.UserClass);
            bindComboBox(DefineConstantValue.MasterType.CardUserSex);
        }

        private void sysToolBar_OnItemRefresh_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                resetAllControllStatus();

                bindComboBox(DefineConstantValue.MasterType.UserDepartment);
                bindComboBox(DefineConstantValue.MasterType.UserClass);
                bindComboBox(DefineConstantValue.MasterType.CardUserSex);
            }
            catch (Exception ex)
            { ShowErrorMessage(ex); }

            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// 绑定COMBO控件
        /// </summary>
        /// <param name="mType"></param>
        void bindComboBox(DefineConstantValue.MasterType mType)
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
                case DefineConstantValue.MasterType.CardUserSex:
                    cbbSex.SetDataSource(result, 0);
                    cbbSex.SelectItemForValue(string.Empty);
                    break;
                case DefineConstantValue.MasterType.UserClass:
                    cbbClass.SetDataSource(result, 0);
                    cbbClass.SelectItemForValue(string.Empty);
                    break;
                case DefineConstantValue.MasterType.UserDepartment:
                    cbbDepartment.SetDataSource(result, 0);
                    cbbDepartment.SelectItemForValue(string.Empty);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 重设所有控件状态
        /// </summary>
        void resetAllControllStatus()
        {
            pnlQueryArea.Enabled = true;
            cbbClass.SelectedIndex = -1;
            cbbDepartment.SelectedIndex = -1;
            tbxUserNum.Text = string.Empty;
            tbxUserName.Text = string.Empty;
            cbbSex.SelectedIndex = -1;
            btnQuery.Enabled = true;
            btnSingleReturn.Enabled = false;
            btnBatchReturn.Enabled = false;
            btnCancel.Enabled = false;
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            searchUsers();
        }

        /// <summary>
        /// 搜索用户
        /// </summary>
        void searchUsers()
        {
            try
            {
                CardUserMaster_cus_Info queryInfo = new CardUserMaster_cus_Info();
                List<CardUserMaster_cus_Info> listUserInfos = new List<CardUserMaster_cus_Info>();

                this.Cursor = Cursors.WaitCursor;
                bool resSearchInfo = true;
                if (!string.IsNullOrEmpty(nudCardNo.Text))
                {
                    #region  定向查询，卡号查人

                    List<UserCardPair_ucp_Info> listPairInfo = this._IUserCardPairBL.SearchRecords(new UserCardPair_ucp_Info()
                    {
                        ucp_iCardNo = int.Parse(nudCardNo.Text)
                    });
                    if (listPairInfo == null || (listPairInfo != null && listPairInfo.Count < 1))
                    {
                        base.ShowInformationMessage(Common.DefineConstantValue.SystemMessageText.strMessageText_W_RecordIsEmpty);
                        this.Cursor = Cursors.Default;
                        return;
                    }
                    else
                    {
                        UserCardPair_ucp_Info pairInfo = listPairInfo.Where(x => x.ucp_dReturnTime == null).FirstOrDefault();
                        if (pairInfo != null)
                        {
                            queryInfo.cus_cRecordID = pairInfo.ucp_cCUSID;
                            CardUserMaster_cus_Info userInfo = this._ICardUserMasterBL.DisplayRecord(queryInfo);
                            if (userInfo != null)
                            {
                                listUserInfos.Add(userInfo);
                            }
                            else
                            {
                                base.ShowInformationMessage(Common.DefineConstantValue.SystemMessageText.strMessageText_W_RecordIsEmpty);
                                this.Cursor = Cursors.Default;
                                return;
                            }
                        }
                        else
                        {
                            base.ShowInformationMessage(Common.DefineConstantValue.SystemMessageText.strMessageText_W_RecordIsEmpty);
                            this.Cursor = Cursors.Default;
                            return;
                        }
                    }

                    #endregion
                }
                else
                {
                    #region 条件查询

                    if (cbbClass.SelectedValue != null && !string.IsNullOrEmpty(cbbClass.Text))
                    {
                        queryInfo.cus_cClassID = new Guid(cbbClass.SelectedValue.ToString());
                        queryInfo.cus_cIdentityNum = Common.DefineConstantValue.CodeMasterDefine.KEY2_SIOT_CardUserIdentity_Student;

                        resSearchInfo = resSearchInfo && false;
                    }
                    if (cbbDepartment.SelectedValue != null && !string.IsNullOrEmpty(cbbDepartment.Text))
                    {
                        queryInfo.cus_cClassID = new Guid(cbbDepartment.SelectedValue.ToString());
                        queryInfo.cus_cIdentityNum = Common.DefineConstantValue.CodeMasterDefine.KEY2_SIOT_CardUserIdentity_Staff;

                        resSearchInfo = resSearchInfo && false;
                    }
                    if (!string.IsNullOrEmpty(tbxUserNum.Text))
                    {
                        queryInfo.cus_cStudentID = tbxUserNum.Text.Trim();

                        resSearchInfo = resSearchInfo && false;
                    }
                    if (!string.IsNullOrEmpty(tbxUserName.Text))
                    {
                        queryInfo.cus_cChaName = tbxUserName.Text.Trim();

                        resSearchInfo = resSearchInfo && false;
                    }
                    if (cbbSex.SelectedValue != null && !string.IsNullOrEmpty(cbbSex.Text))
                    {
                        queryInfo.cus_cSexNum = cbbSex.SelectedValue.ToString();

                        resSearchInfo = resSearchInfo && false;
                    }

                    if (resSearchInfo)
                    {
                        if (!base.ShowQuestionMessage("未有选择任何筛选条件，可能导致搜索记录时间较长，是否要继续？"))
                        {
                            this.Cursor = Cursors.Default;
                            return;
                        }
                    }

                    listUserInfos = this._ICardUserMasterBL.SearchRecords(queryInfo);
                    listUserInfos = listUserInfos.Where(x => x.PairInfo != null).ToList();

                    #endregion
                }

                listUserInfos = listUserInfos.Where(x => x.PairInfo != null).ToList();
                if (listUserInfos == null || (listUserInfos != null && listUserInfos.Count < 1))
                {
                    this.Cursor = Cursors.Default;
                    base.ShowWarningMessage(Common.DefineConstantValue.SystemMessageText.strMessageText_I_strNotFindRecord);
                    return;
                }
                List<UserCardInfo> listDisplayInfos = exchangeDisplayInfo(listUserInfos);

                if (listDisplayInfos != null && listDisplayInfos.Count > 0)
                {
                    this._ListQueryStuInfo.Clear();
                    this._ListQueryStuInfo.AddRange(listUserInfos);
                    lvStudentList.SetDataSource(listDisplayInfos);

                    bool res = true;
                    foreach (ListViewItem item in lvStudentList.Items)
                    {
                        if (Convert.ToBoolean(item.SubItems[7].Text))
                        {
                            item.BackColor = Color.LightGreen;
                        }
                        else
                        {
                            item.BackColor = Color.Tomato;
                            res = res && false;
                        }
                    }

                    btnBatchReturn.Enabled = true;
                }
                else
                {

                    lvStudentList.Items.Clear();
                    this._ListQueryStuInfo = new List<CardUserMaster_cus_Info>();

                    btnBatchReturn.Enabled = false;

                    ShowInformationMessage(Common.DefineConstantValue.SystemMessageText.strMessageText_W_RecordIsEmpty);

                }
            }
            catch (Exception exx)
            {
                ShowErrorMessage(exx);
            }
            this.Cursor = Cursors.Default;
        }

        private void btnSingleReturn_Click(object sender, EventArgs e)
        {
            if (this._ListQueryStuInfo == null)
            {
                ShowWarningMessage("查询结果已超时，请重新查询后再进行退卡操作。");
                return;
            }
            if (lvStudentList.SelectedItems.Count > 0)
            {
                try
                {
                    string strRecordID = lvStudentList.SelectedItems[0].SubItems[0].Text;
                    Guid guidRecordID = new Guid(strRecordID);
                    CardUserMaster_cus_Info userInfo = this._ListQueryStuInfo.Find(x => x.cus_cRecordID == guidRecordID);
                    if (userInfo != null)
                    {
                        dlgCardReturnCheck dlg = new dlgCardReturnCheck(userInfo);
                        dlg.UserInformation = base.UserInformation;
                        dlg.ShowDialog();
                    }
                    else
                    {
                        ShowErrorMessage("没有找到可用记录。");
                        return;
                    }
                }
                catch (Exception ex)
                {
                    ShowErrorMessage("本地记录异常，请重新查询后再试。" + Environment.NewLine + ex.Message);
                    return;
                }
            }
            else
            {
                ShowWarningMessage("请先选中一条记录。");
                return;
            }
        }

        private void btnBatchReturn_Click(object sender, EventArgs e)
        {
            if (!this._IsBatchModify)
            {
                if (lvStudentList.Items.Count > 0)
                {
                    btnBatchReturn.Text = "确定选择";
                    this._IsBatchModify = true;

                    lvStudentList.CheckBoxes = true;
                    lvStudentList.Columns[0].Width = 22;
                    ckbSelectAll.Enabled = true;
                    ckbSelectAll.Visible = true;

                    pnlQueryArea.Enabled = false;
                    btnQuery.Enabled = false;
                    btnSingleReturn.Enabled = false;
                    btnCancel.Enabled = true;
                }
                else
                {
                    ShowWarningMessage("没有可选的项。");
                }
            }
            else
            {
                //显示确认窗口
                if (lvStudentList.CheckedItems.Count > 0)
                {
                    List<CardUserMaster_cus_Info> listUserList = new List<CardUserMaster_cus_Info>();
                    foreach (ListViewItem item in lvStudentList.CheckedItems)
                    {
                        string strRecordID = item.SubItems[0].Text;
                        Guid guidRecordID = new Guid(strRecordID);
                        CardUserMaster_cus_Info userInfo = this._ListQueryStuInfo.Find(x => x.cus_cRecordID == guidRecordID);
                        if (userInfo != null)
                        {
                            listUserList.Add(userInfo);
                        }
                    }
                    dlgCardReturnCheck dlg = new dlgCardReturnCheck(listUserList);
                    dlg.UserInformation = base.UserInformation;
                    dlg.ShowDialog();
                }
                else
                {
                    ShowWarningMessage("没有选中的项。");
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (this._IsBatchModify)
            {
                btnBatchReturn.Text = "批量退卡";
                this._IsBatchModify = false;

                lvStudentList.CheckBoxes = false;
                lvStudentList.Columns[0].Width = 0;
                ckbSelectAll.Enabled = false;
                ckbSelectAll.Visible = false;
                if (lvStudentList.CheckedItems.Count > 0)
                {
                    foreach (ListViewItem item in lvStudentList.CheckedItems)
                    {
                        item.Checked = false;
                    }
                }

                pnlQueryArea.Enabled = true;
                btnQuery.Enabled = true;
                btnSingleReturn.Enabled = false;
                btnCancel.Enabled = false;
            }
            else
            {
                lvStudentList.SelectedItems.Clear();
                btnSingleReturn.Enabled = false;
                btnBatchReturn.Enabled = true;
            }
        }

        private void lvStudentList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this._IsBatchModify)
            {
                if (lvStudentList.SelectedItems.Count > 0)
                {
                    btnSingleReturn.Enabled = true;
                    btnBatchReturn.Enabled = false;
                    btnCancel.Enabled = true;
                }
                else
                {
                    btnSingleReturn.Enabled = false;
                    btnBatchReturn.Enabled = true;
                    btnCancel.Enabled = false;
                }
            }
        }

        private void lvStudentList_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (lvStudentList.Sorting == SortOrder.Ascending)
            {
                ListViewSorter sorter = new ListViewSorter(e.Column, SortOrder.Descending);
                lvStudentList.ListViewItemSorter = sorter;
                lvStudentList.Sorting = SortOrder.Descending;
            }
            else
            {
                ListViewSorter sorter = new ListViewSorter(e.Column, SortOrder.Ascending);
                lvStudentList.ListViewItemSorter = sorter;
                lvStudentList.Sorting = SortOrder.Ascending;
            }
        }

        private void ckbSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chkTarget = sender as CheckBox;
            if (chkTarget == null)
            {
                return;
            }
            if (lvStudentList.Items.Count < 1)
            {
                return;
            }
            foreach (ListViewItem item in lvStudentList.Items)
            {
                item.Checked = chkTarget.Checked;
            }
        }

        /// <summary>
        /// ListView显示信息
        /// </summary>
        class UserCardInfo
        {
            public UserCardInfo(CardUserMaster_cus_Info user)
            {
                this.userInfo = user;
                this.Ext_RecordID = user.cus_cRecordID;
                this.Ext_UserName = user.cus_cChaName;
                this.Ext_UserNum = user.cus_cStudentID;
                if (user.cus_cIdentityNum == Common.DefineConstantValue.CodeMasterDefine.KEY2_SIOT_CardUserIdentity_Student)
                {
                    this.Ext_GroupName = user.ClassInfo == null ? string.Empty : user.ClassInfo.csm_cClassName;
                }
                else
                {
                    this.Ext_GroupName = user.DeptInfo == null ? string.Empty : user.DeptInfo.dpm_cName;
                }
                if (user.PairInfo != null)
                {
                    this.Ext_CardNo = user.PairInfo.ucp_iCardNo.ToString();
                    this.Ext_PairTime = user.PairInfo.ucp_dPairTime;
                }
            }

            public Guid Ext_RecordID { get; set; }
            public string Ext_UserNum { get; set; }
            public string Ext_UserName { get; set; }
            /// 持有卡号
            /// </summary>
            public string Ext_CardNo { get; set; }
            /// <summary>
            /// 发卡时间
            /// </summary>
            public DateTime? Ext_PairTime { get; set; }
            /// <summary>
            /// 所属组织名称
            /// </summary>
            public string Ext_GroupName { get; set; }
            /// <summary>
            /// 验证信息
            /// </summary>
            public string Ext_ValidMsg { get; set; }
            /// <summary>
            /// 验证结果
            /// </summary>
            public bool Ext_Valid { get; set; }

            private CardUserMaster_cus_Info userInfo;

            public CardUserMaster_cus_Info UserInfo
            {
                get { return userInfo; }
            }
        }

        /// <summary>
        /// 转换加工需要显示的用户信息
        /// </summary>
        /// <param name="listSource"></param>
        /// <returns></returns>
        List<UserCardInfo> exchangeDisplayInfo(List<CardUserMaster_cus_Info> listSource)
        {
            if (listSource == null)
            {
                return null;
            }
            try
            {
                List<UserCardInfo> listReturn = new List<UserCardInfo>();

                foreach (CardUserMaster_cus_Info item in listSource)
                {
                    UserCardInfo displayInfo = new UserCardInfo(item);

                    bool res = true;

                    //账户信息
                    if (displayInfo.UserInfo.AccountInfo == null)
                    {
                        displayInfo.UserInfo.AccountInfo = this._ICardUserAccountBL.SearchRecords(new CardUserAccount_cua_Info() { cua_cCUSID = item.cus_cRecordID }).FirstOrDefault();
                    }
                    if (displayInfo.UserInfo.AccountInfo.cua_fCurrentBalance != decimal.Zero)
                    {
                        res = res && false;
                        displayInfo.Ext_ValidMsg = "不能退卡：账户余额不为零。";
                    }

                    //检查未缴款项
                    List<PreConsumeRecord_pcs_Info> listPreCost = this._IPreConsumeRecordBL.SearchRecords(new PreConsumeRecord_pcs_Info()
                    {
                        pcs_cAccountID = displayInfo.UserInfo.AccountInfo.cua_cRecordID,
                        pcs_cUserID = item.cus_cRecordID
                    });

                    if (listPreCost != null && listPreCost.Count > 0)
                    {
                        listPreCost = listPreCost.Where(x => x.pcs_lIsSettled == false).ToList();
                        if (listPreCost != null && listPreCost.Count > 0)
                        {
                            res = res && false;
                            displayInfo.Ext_ValidMsg = "不能退卡：存在未结算的预收款记录。";
                        }
                    }

                    displayInfo.Ext_Valid = res;
                    if (res)
                    {
                        displayInfo.Ext_ValidMsg = "可以退卡。";
                    }

                    listReturn.Add(displayInfo);
                }
                return listReturn;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void cbbClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbClass.SelectedIndex != -1)
            {
                cbbDepartment.SelectedIndex = -1;
                cbxIsGraduation.Enabled = true;
            }
        }

        private void cbbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbDepartment.SelectedIndex != -1)
            {
                cbbClass.SelectedIndex = -1;
                cbxIsGraduation.Enabled = false;
            }
        }

        private void btnReadCard_Click(object sender, EventArgs e)
        {
            try
            {
                bool resUkey = base.CheckUKey();
                if (!resUkey)
                {
                    return;
                }
                if (_IsConnected)
                {
                    this.Cursor = Cursors.WaitCursor;

                    ConsumeCardInfo cardInfo = base._Reader.ReadCardInfo(base._CardInfoSection, base._SectionPwd);
                    if (cardInfo != null)
                    {
                        this.nudCardNo.Text = cardInfo.CardNo;
                        btnQuery_Click(btnQuery, null);
                        if (lvStudentList.Items.Count == 1)
                        {
                            lvStudentList.Items[0].Selected = true;
                        }
                    }
                    else
                    {
                        base.ShowWarningMessage("找不到卡片，请确认读卡器是否已连接或是否将卡片放在读卡器的感应区内。");
                        this.nudCardNo.Text = string.Empty;
                        lvStudentList.Items.Clear();
                    }
                }
                else
                {
                    base.ShowErrorMessage("找不到读卡器，请确认读卡器是否已连接。");
                    this.nudCardNo.Text = string.Empty;
                    lvStudentList.Items.Clear();
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex);
            }
            this.Cursor = Cursors.Default;
        }
    }
}
