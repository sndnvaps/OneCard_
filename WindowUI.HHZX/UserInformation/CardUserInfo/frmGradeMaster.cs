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
using BLL.IBLL.HHZX.UserInfomation.CardUserInfo;
using BLL.Factory.HHZX;
using Model.HHZX.UserInfomation.CardUserInfo;
using Model.General;

namespace WindowUI.HHZX.UserInformation.CardUserInfo
{
    public partial class frmGradeMaster : BaseForm
    {
        /// <summary>
        /// 缓存的年级信息
        /// </summary>
        List<GradeMaster_gdm_Info> _listGradeInfos;

        IGradeMasterBL _IGradeMasterBL;
        IClassMasterBL _IClassMasterBL;

        public frmGradeMaster()
        {
            InitializeComponent();

            this._listGradeInfos = null;

            this._IGradeMasterBL = MasterBLLFactory.GetBLL<IGradeMasterBL>(MasterBLLFactory.GradeMaster);
            this._IClassMasterBL = MasterBLLFactory.GetBLL<IClassMasterBL>(MasterBLLFactory.ClassMaster);
        }

        class GradeInfo
        {
            public GradeInfo()
            {
                ID = 0;

                grade = string.Empty;
            }

            public int ID { get; set; }

            public string grade { get; set; }
        }

        private void frmGradeMaster_Load(object sender, EventArgs e)
        {
            loadAllGradeList();
        }

        /// <summary>
        /// 绑定年级信息
        /// </summary>
        void loadAllGradeList()
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                this._listGradeInfos = this._IGradeMasterBL.AllRecords();

                lvGradeList.SetDataSource(_listGradeInfos);
            }
            catch (Exception Ex)
            {
                ShowErrorMessage(Ex.Message);
            }

            sysToolBar.BtnModify_IsEnabled = false;
            sysToolBar.BtnDelete_IsEnabled = false;
            sysToolBar.BtnNew_IsEnabled = true;
            sysToolBar.BtnRefresh_IsEnabled = true;

            this.Cursor = Cursors.Default;
        }

        private void ShowDetailForm(Common.DefineConstantValue.EditStateEnum editStatc)
        {
            if (lvGradeList.SelectedItems.Count >= 0)
            {
                frmGradeMasterDetail frm = new frmGradeMasterDetail();

                GradeMaster_gdm_Info showInfo = new GradeMaster_gdm_Info();

                ReturnValueInfo returnInfo = new ReturnValueInfo(false);

                try
                {
                    switch (editStatc)
                    {
                        case Common.DefineConstantValue.EditStateEnum.OE_Insert:

                            showInfo.gdm_cRecordID = Guid.NewGuid();

                            frm.ShowForm(showInfo, editStatc);

                            if (showInfo.lSave)
                            {
                                returnInfo = this._IGradeMasterBL.Save(showInfo, Common.DefineConstantValue.EditStateEnum.OE_Insert);
                            }

                            break;
                        case Common.DefineConstantValue.EditStateEnum.OE_Update:

                            if (lvGradeList.SelectedItems.Count > 0)
                            {
                                showInfo.gdm_cRecordID = new Guid(lvGradeList.SelectedItems[0].Text);

                                showInfo = this._IGradeMasterBL.DisplayRecord(showInfo) as GradeMaster_gdm_Info;

                                frm.ShowForm(showInfo, editStatc);

                                if (showInfo.lSave)
                                {
                                    returnInfo = this._IGradeMasterBL.Save(showInfo, Common.DefineConstantValue.EditStateEnum.OE_Update);
                                }
                            }

                            break;

                        default:
                            break;
                    }

                    if (showInfo.lSave)
                    {
                        if (!returnInfo.boolValue)
                        {
                            ShowErrorMessage(returnInfo.messageText);
                        }
                        //else
                        //{
                        //    loadAllGradeList();
                        //}
                    }
                }
                catch (Exception Ex)
                {

                    ShowErrorMessage(Ex.Message);
                }
                loadAllGradeList();
            }
        }

        private void sysToolBar_OnItemModify_Click(object sender, EventArgs e)
        {
            ShowDetailForm(Common.DefineConstantValue.EditStateEnum.OE_Update);
        }

        private void sysToolBar_OnItemNew_Click(object sender, EventArgs e)
        {
            ShowDetailForm(Common.DefineConstantValue.EditStateEnum.OE_Insert);
        }

        private void sysToolBar_OnItemDelete_Click(object sender, EventArgs e)
        {
            if (lvGradeList.SelectedItems != null && lvGradeList.SelectedItems.Count > 0)
            {
                if (!ShowQuestionMessage("是否确认需要删除选中项？"))
                {
                    return;
                }

                try
                {
                    GradeMaster_gdm_Info delInfo = new GradeMaster_gdm_Info();

                    delInfo.gdm_cRecordID = new Guid(lvGradeList.SelectedItems[0].SubItems[0].Text);

                    List<ClassMaster_csm_Info> listSubClass = this._IClassMasterBL.SearchRecords(new ClassMaster_csm_Info() { csm_cGDMID = delInfo.gdm_cRecordID });
                    if (listSubClass != null && listSubClass.Count > 0)
                    {
                        ShowWarningMessage("此年级仍与部分班级关联，请更新或删除相关班级信息后再试。");
                        return;
                    }

                    ReturnValueInfo returnInfo = this._IGradeMasterBL.Save(delInfo, Common.DefineConstantValue.EditStateEnum.OE_Delete);

                    if (returnInfo.boolValue)
                    {
                        ShowInformationMessage("删除成功。");

                        loadAllGradeList();
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
                ShowWarningMessage("请先选择一条记录。");
            }
        }

        private void lvGradeList_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (lvGradeList.Sorting == SortOrder.Descending)
            {
                ListViewSorter sorter = new ListViewSorter(e.Column, SortOrder.Ascending);
                lvGradeList.ListViewItemSorter = sorter;
                lvGradeList.Sorting = SortOrder.Ascending;
            }
            else
            {
                ListViewSorter sorter = new ListViewSorter(e.Column, SortOrder.Descending);
                lvGradeList.ListViewItemSorter = sorter;
                lvGradeList.Sorting = SortOrder.Descending;
            }
        }

        private void lvGradeList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvGradeList.SelectedItems.Count > 0)
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

        private void sysToolBar_OnItemRefresh_Click(object sender, EventArgs e)
        {
            loadAllGradeList();
        }

        private void lvGradeList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lvGradeList.SelectedItems.Count > 0)
            {
                sysToolBar_OnItemModify_Click(null, null);
            }
        }
    }
}
