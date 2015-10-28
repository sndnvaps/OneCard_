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
using BLL.IBLL.HHZX.UserInfomation.CardUserInfo;
using Model.HHZX.UserInfomation.CardUserInfo;
using BLL.IBLL.HHZX.UserCard;
using Model.HHZX.UserCard;
using Model.HHZX.ComsumeAccount;
using WindowUI.HHZX.ClassLibrary.Public;
using Model.General;
using Model.IModel;
using BLL.IBLL.General;
using BLL.Factory.General;
using Common;

namespace WindowUI.HHZX.UserCard
{
    /// <summary>
    /// 转换未确定结算的预付款记录状态
    /// </summary>
    public partial class frmChangePreCostStatus : BaseReaderForm
    {
        private IPreConsumeRecordBL _IPreConsumeRecordBL;
        private ICardUserMasterBL _ICardUserMasterBL;
        private IUserCardPairBL _IUserCardPairBL;
        private List<PreConsumeRecord_pcs_Info> _CurrentListPreCost;
        private IGeneralBL _IGeneralBL;

        public frmChangePreCostStatus()
        {
            InitializeComponent();

            this._IPreConsumeRecordBL = MasterBLLFactory.GetBLL<IPreConsumeRecordBL>(MasterBLLFactory.PreConsumeRecord);
            this._ICardUserMasterBL = MasterBLLFactory.GetBLL<ICardUserMasterBL>(MasterBLLFactory.CardUserMaster);
            this._IUserCardPairBL = MasterBLLFactory.GetBLL<IUserCardPairBL>(MasterBLLFactory.UserCardPair);
            this._IGeneralBL = GeneralBLLFactory.GetBLL<IGeneralBL>(GeneralBLLFactory.General);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            bindComboBox(DefineConstantValue.MasterType.UserDepartment);
            bindComboBox(DefineConstantValue.MasterType.UserClass);
            bindComboBox(DefineConstantValue.MasterType.CardUserSex);

            resetControlsState();
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
                List<UnconfirmMealCostInfo> listPreCost = new List<UnconfirmMealCostInfo>();

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

                try
                {
                    if (listUserInfos == null || (listUserInfos != null && listUserInfos.Count < 1))
                    {
                        base.ShowInformationMessage(Common.DefineConstantValue.SystemMessageText.strMessageText_I_strNotFindRecord);
                    }
                    else
                    {
                        PreConsumeRecord_pcs_Info preCostQuery = new PreConsumeRecord_pcs_Info();
                        //查找时，只需要显示【定餐未确定扣款】类型
                        preCostQuery.pcs_cConsumeType = Common.DefineConstantValue.ConsumeMoneyFlowType.IndeterminateCost.ToString();
                        List<PreConsumeRecord_pcs_Info> listPreCostQuery = this._IPreConsumeRecordBL.SearchRecords(preCostQuery);
                        if (listPreCostQuery != null)
                        {
                            listPreCostQuery = listPreCostQuery.Where(x => x.pcs_lIsSettled == false).ToList();
                        }
                        if (listPreCostQuery == null || (listPreCostQuery != null && listPreCostQuery.Count < 1))
                        {
                            base.ShowInformationMessage(Common.DefineConstantValue.SystemMessageText.strMessageText_W_RecordIsEmpty);
                        }
                        else
                        {
                            foreach (CardUserMaster_cus_Info userQuery in listUserInfos)
                            {
                                List<PreConsumeRecord_pcs_Info> listInsertPreCost = listPreCostQuery.Where(x => x.pcs_cUserID == userQuery.cus_cRecordID).ToList();
                                if (listInsertPreCost != null && listInsertPreCost.Count > 0)
                                {
                                    this._CurrentListPreCost.AddRange(listInsertPreCost);

                                    foreach (PreConsumeRecord_pcs_Info preCostItem in listInsertPreCost)
                                    {
                                        UnconfirmMealCostInfo unconfirmInfo = Common.General.CopyObjectValue<PreConsumeRecord_pcs_Info, UnconfirmMealCostInfo>(preCostItem);
                                        unconfirmInfo.CardNo = userQuery.PairInfo.ucp_iCardNo.ToString();
                                        unconfirmInfo.GroupName = userQuery.ClassInfo == null ? userQuery.DeptInfo.dpm_cName : userQuery.ClassInfo.csm_cClassName;
                                        unconfirmInfo.UserName = userQuery.cus_cChaName;
                                        unconfirmInfo.UserNum = userQuery.cus_cStudentID;
                                        listPreCost.Add(unconfirmInfo);
                                    }

                                    if (listPreCost.Count > 0)
                                    {
                                        lvPreCostList.SetDataSource<UnconfirmMealCostInfo>(listPreCost);
                                        gbxLeftDown.Enabled = true;
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception Ex)
                {
                    ShowErrorMessage(Ex);
                }
            }
            catch (Exception exx)
            {
                ShowErrorMessage(exx);
            }
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// 重置控件状态
        /// </summary>
        private void resetControlsState()
        {
            nudCardNo.Text = string.Empty;
            cbbClass.SelectedIndex = -1;
            cbbDepartment.SelectedIndex = -1;
            tbxUserNum.Text = string.Empty;
            tbxUserName.Text = string.Empty;
            cbbSex.SelectedIndex = -1;
            gbxLeftDown.Enabled = false;
            rBtnUnsettledSetMeal.Checked = true;
            rBtnSetMealSettled.Checked = false;
            ckbSelectAll.Checked = false;
            ckbSelectAll.Visible = false;
            lvPreCostList.Columns[0].Width = 0;
            lvPreCostList.Items.Clear();
            pnlOptChange.Enabled = false;
            btnCancel.Enabled = false;

            this._CurrentListPreCost = new List<PreConsumeRecord_pcs_Info>();
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
                if (base._IsConnected)
                {
                    this.Cursor = Cursors.WaitCursor;

                    resetControlsState();

                    ConsumeCardInfo cardInfo = base._Reader.ReadCardInfo(base._CardInfoSection, base._SectionPwd);
                    if (cardInfo != null)
                    {
                        this.nudCardNo.Text = cardInfo.CardNo;
                        btnQuery_Click(btnQuery, null);
                        if (lvPreCostList.Items.Count > 0)
                        {
                            pnlQueryArea.Enabled = true;
                        }
                    }
                    else
                    {
                        base.ShowWarningMessage("找不到卡片，请确认读卡器是否已连接或是否将卡片放在读卡器的感应区内。");
                        this.nudCardNo.Text = string.Empty;
                        lvPreCostList.Items.Clear();
                        pnlQueryArea.Enabled = false;
                    }
                }
                else
                {
                    base.ShowErrorMessage("找不到读卡器，请确认读卡器是否已连接。");
                    this.nudCardNo.Text = string.Empty;
                    lvPreCostList.Items.Clear();
                    pnlQueryArea.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex);
            }
            this.Cursor = Cursors.Default;
        }

        private void cbbClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbClass.SelectedIndex != -1)
            {
                cbbDepartment.SelectedIndex = -1;
            }
        }

        private void cbbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbDepartment.SelectedIndex != -1)
            {
                cbbClass.SelectedIndex = -1;
            }
        }

        class UnconfirmMealCostInfo : PreConsumeRecord_pcs_Info
        {
            public string UserNum { get; set; }
            public string GroupName { get; set; }
            public string UserName { get; set; }
            public string CardNo { get; set; }
        }

        private void btnSelectUsers_Click(object sender, EventArgs e)
        {
            lvPreCostList.Columns[0].Width = 22;
            ckbSelectAll.Visible = true;
            btnSelectUsers.Enabled = false;
            btnCancel.Enabled = true;
        }

        private void lvPreCostList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            checkLvItemChecked();
        }

        private void lvPreCostList_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            checkLvItemChecked();
        }

        void checkLvItemChecked()
        {
            if (lvPreCostList.CheckedItems.Count > 0)
            {
                pnlOptChange.Enabled = true;
            }
            else
            {
                pnlOptChange.Enabled = false; ;
            }
        }

        private void ckbSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chkTarget = sender as CheckBox;
            if (chkTarget == null)
            {
                return;
            }
            if (lvPreCostList.Items.Count < 1)
            {
                return;
            }
            foreach (ListViewItem item in lvPreCostList.Items)
            {
                item.Checked = chkTarget.Checked;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            lvPreCostList.Columns[0].Width = 0;
            ckbSelectAll.Checked = false;
            btnSelectUsers.Enabled = true;
            btnCancel.Enabled = false;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            bool isSettled = false;
            string strStatusType = string.Empty;
            string strConsumeType = Common.DefineConstantValue.ConsumeMoneyFlowType.SetMealCost.ToString();
            if (rBtnSetMealSettled.Checked)
            {
                isSettled = true;
                strStatusType = rBtnSetMealSettled.Text;
            }
            else if (rBtnUnsettledSetMeal.Checked)
            {
                isSettled = false;
                strStatusType = rBtnUnsettledSetMeal.Text;
            }

            if (base.ShowQuestionMessage("是否确定将已选记录转变为" + strStatusType + "状态？"))
            {
                List<PreConsumeRecord_pcs_Info> listSelected = new List<PreConsumeRecord_pcs_Info>();
                foreach (ListViewItem item in lvPreCostList.CheckedItems)
                {
                    Guid recordID = new Guid(item.SubItems[0].Text);
                    PreConsumeRecord_pcs_Info itemSelected = this._CurrentListPreCost.Find(x => x.pcs_cRecordID == recordID);
                    if (itemSelected != null)
                    {
                        itemSelected.pcs_cAdd = this.UserInformation.usm_cUserLoginID;
                        itemSelected.pcs_cConsumeType = strConsumeType;
                    }
                    listSelected.Add(itemSelected);
                }
                if (listSelected.Count > 0)
                {
                    ReturnValueInfo rvInfo = this._IPreConsumeRecordBL.BatchSolveUncertainRecord(listSelected, isSettled);
                    if (rvInfo.boolValue && !rvInfo.isError)
                    {
                        base.ShowInformationMessage("转换成功。");
                        btnQuery_Click(null, null);
                    }
                    else
                    {
                        base.ShowErrorMessage("转换失败。" + Environment.NewLine + rvInfo.messageText);
                    }
                }
            }
        }

        private void sysToolBar_OnItemRefresh_Click(object sender, EventArgs e)
        {
            resetControlsState();
        }
    }
}
