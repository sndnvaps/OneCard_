using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WindowUI.HHZX.ClassLibrary.Public;
using Model.TestModel;
using BLL.IBLL.General;
using BLL.Factory.General;
using Model.IModel;
using Common;
using BLL.IBLL.HHZX.UserInfomation.CardUserInfo;
using BLL.Factory.HHZX;
using Model.HHZX.UserInfomation.CardUserInfo;
using Model.General;
using BLL.IBLL.HHZX.UserCard;
using Model.HHZX.UserCard;

namespace WindowUI.HHZX.UserInformation.CardUserInfo
{
    public partial class frmStaffMaster : BaseForm
    {
        #region 自定义变量

        IGeneralBL _IGeneralBL;
        ICardUserMasterBL _ICardUserMasterBL;
        IGradeMasterBL _IGradeMasterBL;
        IClassMasterBL _IClassMasterBL;
        IUserCardPairBL _IUserCardPairBL;

        /// <summary>
        /// 查询结果
        /// </summary>
        List<CardUserMaster_cus_Info> _ListQueryUserInfos;

        #endregion

        public frmStaffMaster()
        {
            InitializeComponent();

            this._IGeneralBL = GeneralBLLFactory.GetBLL<IGeneralBL>(GeneralBLLFactory.General);

            this._ICardUserMasterBL = MasterBLLFactory.GetBLL<ICardUserMasterBL>(MasterBLLFactory.CardUserMaster);
            this._IGradeMasterBL = MasterBLLFactory.GetBLL<IGradeMasterBL>(MasterBLLFactory.GradeMaster);
            this._IClassMasterBL = MasterBLLFactory.GetBLL<IClassMasterBL>(MasterBLLFactory.ClassMaster);
            this._IUserCardPairBL = MasterBLLFactory.GetBLL<IUserCardPairBL>(MasterBLLFactory.UserCardPair);

            this._ListQueryUserInfos = null;
        }

        private void BindComboBox(DefineConstantValue.MasterType mType)
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
                    cbxDeparment.SetDataSource(result, 0);
                    cbxDeparment.SelectItemForValue(string.Empty);
                    break;

                case DefineConstantValue.MasterType.CardUserSex:
                    cbxSex.SetDataSource(result, 0);
                    cbxSex.SelectItemForValue(string.Empty);
                    break;
                default:
                    break;
            }
        }

        private void SearchStaffList(CardUserMaster_cus_Info query)
        {
            this.Cursor = Cursors.WaitCursor;

            this._ListQueryUserInfos = new List<CardUserMaster_cus_Info>();
            try
            {
                List<CardUserMaster_cus_Info> result = this._ICardUserMasterBL.SearchRecord_ForMaster(query);

                if (result != null)
                {
                    if (result.Count < 1)
                    {
                        ShowInformationMessage("没有合符条件的记录。");
                    }
                    //foreach (CardUserMaster_cus_Info item in result)
                    //{
                    //    if (item.DeptInfo != null)
                    //    {
                    //        item.DepartmentName = item.DeptInfo.dpm_cName;
                    //        item.SexName = item.cus_cSexNum == Common.DefineConstantValue.CodeMasterDefine.KEY2_SIOT_CardUserSex_MALE ? "男" : "女";
                    //    }
                    //    this._ListQueryUserInfos.Add(item);
                    //}
                    this._ListQueryUserInfos.Clear();
                    this._ListQueryUserInfos.AddRange(result);
                    gbxRes.Text = "查询结果：共 " + result.Count + " 条";
                }
                else
                {
                    this._ListQueryUserInfos.Clear();
                }

                lvStaffList.SetDataSource(result);

                ListViewSorter sorter = new ListViewSorter(1, SortOrder.Ascending);
                lvStaffList.ListViewItemSorter = sorter;
                lvStaffList.Sorting = SortOrder.Ascending;
            }
            catch (Exception Ex)
            {
                ShowErrorMessage(Ex.Message);
            }

            sysToolBar.BtnNew_IsEnabled = true;
            sysToolBar.BtnModify_IsEnabled = false;
            sysToolBar.BtnDelete_IsEnabled = false;
            sysToolBar.BtnRefresh_IsEnabled = true;

            this.Cursor = Cursors.Default;
        }

        private void frmStaffMaster_Load(object sender, EventArgs e)
        {
            BindComboBox(DefineConstantValue.MasterType.UserDepartment);

            BindComboBox(DefineConstantValue.MasterType.CardUserSex);
        }

        private void ShowDetailForm(Common.DefineConstantValue.EditStateEnum editStatc)
        {
            ReturnValueInfo returnInfo = new ReturnValueInfo(false);
            CardUserMaster_cus_Info showInfo = new CardUserMaster_cus_Info();
            frmStaffMasterDetailNew frm = new frmStaffMasterDetailNew();
            frm.UserInformation = this.UserInformation;

            if (editStatc == DefineConstantValue.EditStateEnum.OE_Update)
            {
                if (lvStaffList.SelectedItems.Count > 0)
                {
                    showInfo.cus_cRecordID = new Guid(lvStaffList.SelectedItems[0].SubItems[0].Text);
                    showInfo = this._ListQueryUserInfos.FirstOrDefault(t => t.cus_cRecordID == showInfo.cus_cRecordID);
                    if (showInfo != null)
                    {
                        frm.ShowForm(showInfo, editStatc);
                        if (showInfo.IsSaved)
                        {
                            showInfo.cus_cLast = this.UserInformation.usm_cUserLoginID;
                            try
                            {
                                returnInfo = this._ICardUserMasterBL.Save(showInfo, DefineConstantValue.EditStateEnum.OE_Update);
                            }
                            catch (Exception Ex)
                            {
                                ShowErrorMessage(Ex.Message);
                            }
                        }
                        else
                        {
                            sysToolBar.BtnModify_IsEnabled = false;
                            sysToolBar.BtnNew_IsEnabled = true;
                            sysToolBar.BtnRefresh_IsEnabled = true;
                            sysToolBar.BtnDelete_IsEnabled = false;
                            lvStaffList.SelectedItems.Clear();
                        }
                    }
                }
                else
                {
                    ShowWarningMessage("请先选择需要查看的教师。");
                }
            }
            else if (editStatc == DefineConstantValue.EditStateEnum.OE_Insert)
            {
                frm.ShowForm(showInfo, editStatc);
                if (showInfo.IsSaved)
                {
                    showInfo.cus_cAdd = this.UserInformation.usm_cUserLoginID;
                    showInfo.cus_cLast = this.UserInformation.usm_cUserLoginID;

                    try
                    {
                        returnInfo = this._ICardUserMasterBL.Save(showInfo, DefineConstantValue.EditStateEnum.OE_Insert);

                        if (returnInfo.boolValue)
                        {
                            ShowInformationMessage(Common.DefineConstantValue.SystemMessageText.strMessageText_I_SaveSuccess);
                        }
                        else
                        {
                            ShowErrorMessage(returnInfo.messageText);
                        }
                    }
                    catch (Exception Ex)
                    {

                        ShowErrorMessage(Ex.Message);
                    }
                }
                else
                {
                    sysToolBar.BtnModify_IsEnabled = false;
                    sysToolBar.BtnNew_IsEnabled = true;
                    sysToolBar.BtnRefresh_IsEnabled = true;
                    sysToolBar.BtnDelete_IsEnabled = false;
                    lvStaffList.SelectedItems.Clear();
                }
            }

            //btnQuery_Click(null, null);
        }

        private void sysToolBar_OnItemNew_Click(object sender, EventArgs e)
        {
            ShowDetailForm(Common.DefineConstantValue.EditStateEnum.OE_Insert);
        }

        private void sysToolBar_OnItemModify_Click(object sender, EventArgs e)
        {
            ShowDetailForm(Common.DefineConstantValue.EditStateEnum.OE_Update);
        }

        private CardUserMaster_cus_Info InputToInfo()
        {
            CardUserMaster_cus_Info query = new CardUserMaster_cus_Info();

            query.cus_cIdentityNum = DefineConstantValue.CodeMasterDefine.KEY2_SIOT_CardUserIdentity_Staff;

            if (cbxDeparment.SelectedValue != null && !string.IsNullOrEmpty(cbxDeparment.Text))
            {
                query.cus_cClassID = new Guid(cbxDeparment.SelectedValue.ToString());
            }

            if (!string.IsNullOrEmpty(tbxStaffID.Text))
            {
                query.cus_cStudentID = tbxStaffID.Text.Trim();
            }

            if (!string.IsNullOrEmpty(tbxName.Text))
            {
                query.cus_cChaName = tbxName.Text.Trim();
            }

            if (cbxSex.SelectedValue != null && !string.IsNullOrEmpty(cbxSex.Text))
            {
                query.cus_cSexNum = cbxSex.SelectedValue.ToString();
            }
            return query;
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            SearchStaffList(InputToInfo());
        }

        private void sysToolBar_OnItemDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (lvStaffList.SelectedItems != null && lvStaffList.SelectedItems.Count > 0)
                {
                    if (!ShowQuestionMessage("是否确认需要删除此条记录？"))
                    {
                        return;
                    }

                    CardUserMaster_cus_Info delInfo = new CardUserMaster_cus_Info();
                    delInfo.cus_cRecordID = new Guid(lvStaffList.SelectedItems[0].SubItems[0].Text);

                    //级长检查
                    List<GradeMaster_gdm_Info> listGrade = this._IGradeMasterBL.SearchRecords(new GradeMaster_gdm_Info() { gdm_cPraepostorID = delInfo.cus_cRecordID });
                    if (listGrade != null && listGrade.Count > 0)
                    {
                        string strContent = "删除失败。该用户为年级长，请更新相关年级信息后重试。" + Environment.NewLine;
                        foreach (GradeMaster_gdm_Info gradeItem in listGrade)
                        {
                            strContent += gradeItem.gdm_cGradeName + Environment.NewLine;
                        }
                        ShowWarningMessage(strContent);
                        return;
                    }

                    //班级检查
                    List<ClassMaster_csm_Info> listClass = this._IClassMasterBL.SearchRecords(new ClassMaster_csm_Info() { csm_cMasterID = delInfo.cus_cRecordID });
                    if (listClass != null && listClass.Count > 0)
                    {
                        string strContent = "删除失败。该用户为班主任，请更新相关班级信息后重试。" + Environment.NewLine;
                        foreach (ClassMaster_csm_Info classItem in listClass)
                        {
                            strContent += classItem.csm_cClassName + Environment.NewLine;
                        }
                        ShowWarningMessage(strContent);
                        return;
                    }

                    //退卡检查
                    List<UserCardPair_ucp_Info> listCardUser = this._IUserCardPairBL.SearchRecords(new UserCardPair_ucp_Info() { ucp_cCUSID = delInfo.cus_cRecordID });
                    if (listCardUser != null)
                    {
                        listCardUser = listCardUser.Where(x => x.ucp_cUseStatus == Common.DefineConstantValue.ConsumeCardStatus.Normal.ToString() || x.ucp_cUseStatus == Common.DefineConstantValue.ConsumeCardStatus.LoseReporting.ToString()).ToList();
                        if (listCardUser.Count > 1)
                        {
                            string strContent = "删除失败。该用户未退卡，请退卡后重试。";
                            ShowWarningMessage(strContent);
                            return;
                        }
                    }

                    try
                    {
                        ReturnValueInfo returnInfo = this._ICardUserMasterBL.Save(delInfo, DefineConstantValue.EditStateEnum.OE_Delete);

                        if (returnInfo.boolValue)
                        {
                            ShowInformationMessage("删除成功。");

                            SearchStaffList(InputToInfo());
                        }
                        else
                        {
                            ShowWarningMessage(returnInfo.messageText);
                        }
                    }
                    catch (Exception Ex)
                    {

                        ShowErrorMessage(Ex.Message);
                    }
                }
                else
                {
                    ShowWarningMessage("请先选择删除的老师记录。");
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex);
            }

            sysToolBar.BtnModify_IsEnabled = false;
            sysToolBar.BtnNew_IsEnabled = true;
            sysToolBar.BtnRefresh_IsEnabled = true;
            sysToolBar.BtnDelete_IsEnabled = false;
            lvStaffList.SelectedItems.Clear();
        }

        private void lvStaffList_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (lvStaffList.Sorting == SortOrder.Ascending)
            {
                ListViewSorter sorter = new ListViewSorter(e.Column, SortOrder.Descending);
                lvStaffList.ListViewItemSorter = sorter;
                lvStaffList.Sorting = SortOrder.Descending;
            }
            else
            {
                ListViewSorter sorter = new ListViewSorter(e.Column, SortOrder.Ascending);
                lvStaffList.ListViewItemSorter = sorter;
                lvStaffList.Sorting = SortOrder.Ascending;
            }
        }

        private void sysToolBar_OnItemRefresh_Click(object sender, EventArgs e)
        {
            //BindComboBox(DefineConstantValue.MasterType.UserDepartment);
            //BindComboBox(DefineConstantValue.MasterType.CardUserSex);
            //tbxStaffID.Text = string.Empty;
            //tbxName.Text = string.Empty;
            //cbxDeparment.SelectedIndex = -1;
            //cbxSex.SelectedIndex = -1;
            //lvStaffList.SetDataSource(new List<CardUserMaster_cus_Info>());

            SearchStaffList(InputToInfo());
        }

        private void lvStaffList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvStaffList.SelectedItems.Count > 0)
            {
                sysToolBar.BtnModify_IsEnabled = true;
                sysToolBar.BtnDelete_IsEnabled = true;
                sysToolBar.BtnNew_IsEnabled = false;
                sysToolBar.BtnRefresh_IsEnabled = false;
            }
            else
            {
                sysToolBar.BtnModify_IsEnabled = false;
                sysToolBar.BtnDelete_IsEnabled = false;
                sysToolBar.BtnNew_IsEnabled = true;
                sysToolBar.BtnRefresh_IsEnabled = true;
            }
        }

        private void lvStaffList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lvStaffList.SelectedItems.Count > 0)
            {
                sysToolBar_OnItemModify_Click(null, null);
            }
        }
    }
}
