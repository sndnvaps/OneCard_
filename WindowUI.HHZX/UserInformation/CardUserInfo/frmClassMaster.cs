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
using Model.HHZX.UserInfomation.CardUserInfo;
using BLL.IBLL.HHZX.UserInfomation.CardUserInfo;
using BLL.Factory.HHZX;
using Model.IModel;
using Model.General;
using Common;

namespace WindowUI.HHZX.UserInformation.CardUserInfo
{
    public partial class frmClassMaster : BaseForm
    {
        List<ClassMaster_csm_Info> _ListAllClassInfos;

        IClassMasterBL _IClassMasterBL;
        ICardUserMasterBL _ICardUserMasterBL;

        public frmClassMaster()
        {
            InitializeComponent();

            this._ListAllClassInfos = null;

            this._IClassMasterBL = MasterBLLFactory.GetBLL<IClassMasterBL>(MasterBLLFactory.ClassMaster);
            this._ICardUserMasterBL = MasterBLLFactory.GetBLL<ICardUserMasterBL>(MasterBLLFactory.CardUserMaster);
        }

        /// <summary>
        /// 加载班级信息
        /// </summary>
        void loadAllClassList()
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                this._ListAllClassInfos = this._IClassMasterBL.AllRecords();

                lvClassList.SetDataSource(_ListAllClassInfos);

                ListViewSorter sorter = new ListViewSorter(1, SortOrder.Ascending);
                lvClassList.ListViewItemSorter = sorter;
                lvClassList.Sorting = SortOrder.Ascending;
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

        private void frmClassMaster_Load(object sender, EventArgs e)
        {
            loadAllClassList();
        }

        /// <summary>
        /// 弹出子界面（新增、修改）
        /// </summary>
        /// <param name="editStatc"></param>
        private void ShowDetailForm(DefineConstantValue.EditStateEnum editStatc)
        {
            ReturnValueInfo returnInfo = null;
            ClassMaster_csm_Info classInfo = new ClassMaster_csm_Info();
            frmClassMasterDetailNew frmNew = new frmClassMasterDetailNew();
            frmNew.UserInformation = this.UserInformation;

            try
            {
                switch (editStatc)
                {
                    case Common.DefineConstantValue.EditStateEnum.OE_Insert:
                        {
                            classInfo.csm_cRecordID = Guid.NewGuid();
                            frmNew.ShowForm(classInfo, editStatc);
                            break;
                        }
                    case Common.DefineConstantValue.EditStateEnum.OE_Update:
                        {
                            if (lvClassList.SelectedItems != null && lvClassList.SelectedItems.Count > 0)
                            {
                                classInfo.csm_cRecordID = new Guid(lvClassList.SelectedItems[0].Text);
                                classInfo = this._IClassMasterBL.DisplayRecord(classInfo) as ClassMaster_csm_Info;
                                frmNew.ShowForm(classInfo, editStatc);
                            }
                            else
                            {
                                ShowWarningMessage("请先选择一条记录。");
                            }
                            break;
                        }
                    default:
                        break;
                }
            }
            catch (Exception Ex)
            {
                ShowErrorMessage(Ex.Message);
            }

            loadAllClassList();
        }

        private void sysToolBar_OnItemModify_Click(object sender, EventArgs e)
        {
            if (lvClassList.SelectedItems.Count > 0)
            {
                ShowDetailForm(Common.DefineConstantValue.EditStateEnum.OE_Update);
            }
        }

        private void sysToolBar_OnItemNew_Click(object sender, EventArgs e)
        {
            ShowDetailForm(Common.DefineConstantValue.EditStateEnum.OE_Insert);
        }

        private void lvClassList_DoubleClick(object sender, EventArgs e)
        {
            if (lvClassList.SelectedItems.Count > 0)
            {
                ShowDetailForm(Common.DefineConstantValue.EditStateEnum.OE_Update);
            }
        }

        private void sysToolBar_OnItemDelete_Click(object sender, EventArgs e)
        {
            if (lvClassList.SelectedItems != null && lvClassList.SelectedItems.Count > 0)
            {
                if (!ShowQuestionMessage("是否确认需要删除选中项？"))
                {
                    return;
                }

                try
                {
                    ClassMaster_csm_Info delInfo = new ClassMaster_csm_Info();

                    delInfo.csm_cRecordID = new Guid(lvClassList.SelectedItems[0].SubItems[0].Text);

                    List<CardUserMaster_cus_Info> listSubCardUser = this._ICardUserMasterBL.SearchRecords(new CardUserMaster_cus_Info() { cus_cClassID = delInfo.csm_cRecordID });
                    if (listSubCardUser != null && listSubCardUser.Count > 0)
                    {
                        ShowWarningMessage("此班级仍与部分学生关联，请更新或删除相关学生信息后再试。");
                        return;
                    }

                    ReturnValueInfo returnInfo = this._IClassMasterBL.Save(delInfo, Common.DefineConstantValue.EditStateEnum.OE_Delete);

                    if (returnInfo.boolValue)
                    {
                        ShowInformationMessage("删除成功！");

                        loadAllClassList();
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
        }

        private void lvClassList_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (lvClassList.Sorting == SortOrder.Ascending)
            {
                ListViewSorter sorter = new ListViewSorter(e.Column, SortOrder.Descending);
                lvClassList.ListViewItemSorter = sorter;
                lvClassList.Sorting = SortOrder.Descending;
            }
            else
            {
                ListViewSorter sorter = new ListViewSorter(e.Column, SortOrder.Ascending);
                lvClassList.ListViewItemSorter = sorter;
                lvClassList.Sorting = SortOrder.Ascending;
            }
        }

        private void lvClassList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvClassList.SelectedItems.Count > 0)
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
            loadAllClassList();
        }

        private void lvClassList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lvClassList.SelectedItems.Count > 0)
            {
                sysToolBar_OnItemModify_Click(null, null);
            }
        }
    }
}
