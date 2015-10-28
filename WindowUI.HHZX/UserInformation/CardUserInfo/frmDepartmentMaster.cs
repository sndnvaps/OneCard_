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
using BLL.IBLL.HHZX;
using BLL.Factory.HHZX;
using Model.HHZX;
using BLL.IBLL.HHZX.UserInfomation.CardUserInfo;
using Model.HHZX.UserInfomation.CardUserInfo;
using Model.General;

namespace WindowUI.HHZX.UserInformation.CardUserInfo
{
    public partial class frmDepartmentMaster : BaseForm
    {
        List<DepartmentMaster_dpm_Info> _ListDeptAllInfos;

        private IDepartmentMasterBL _IDepartmentMasterBL;

        private ICardUserMasterBL _ICardUserMasterBL;

        public frmDepartmentMaster()
        {
            InitializeComponent();

            this._ListDeptAllInfos = null;
            _IDepartmentMasterBL = MasterBLLFactory.GetBLL<IDepartmentMasterBL>(MasterBLLFactory.DepartmentMaster);
            _ICardUserMasterBL = MasterBLLFactory.GetBLL<ICardUserMasterBL>(MasterBLLFactory.CardUserMaster);
        }

        private void frmDepartmentMaster_Load(object sender, EventArgs e)
        {
            loadAllDepartmentList();
        }

        private void loadAllDepartmentList()
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                _ListDeptAllInfos = _IDepartmentMasterBL.AllRecords();

                this.lvDepartmentList.SetDataSource(_ListDeptAllInfos);

                //ListViewSorter sorter = new ListViewSorter(1, SortOrder.Ascending);
                //lvDepartmentList.ListViewItemSorter = sorter;
                //lvDepartmentList.Sorting = SortOrder.Ascending;

                for (int index = 0; index < _ListDeptAllInfos.Count; index++)
                {
                    this.lvDepartmentList.Items[index].SubItems[0].Text = (index + 1).ToString();
                }
            }
            catch (Exception ex)
            {
                this.ShowErrorMessage(ex);
            }

            sysToolBar.BtnModify_IsEnabled = false;
            sysToolBar.BtnDelete_IsEnabled = false;
            sysToolBar.BtnNew_IsEnabled = true;
            sysToolBar.BtnRefresh_IsEnabled = true;

            this.Cursor = Cursors.Default;
        }

        private void ShowDetailForm(Common.DefineConstantValue.EditStateEnum editStatc)
        {
            DepartmentMaster_dpm_Info info = null;

            if (editStatc == Common.DefineConstantValue.EditStateEnum.OE_Update)
            {
                if (lvDepartmentList.SelectedItems.Count > 0)
                {
                    int index = lvDepartmentList.SelectedItems[0].Index;
                    info = _ListDeptAllInfos[index];

                }
                else
                {
                    base.ShowWarningMessage("请先选择一条记录。");
                    return;
                }
            }
            else if ((editStatc == Common.DefineConstantValue.EditStateEnum.OE_Insert))
            {
                info = new DepartmentMaster_dpm_Info();
            }

            frmDepartmentMasterDetail frm = new frmDepartmentMasterDetail();
            frm.UserInformation = this.UserInformation;

            frm.ShowForm(info, editStatc);

            loadAllDepartmentList();
        }

        private void sysToolBar_OnItemModify_Click(object sender, EventArgs e)
        {
            ShowDetailForm(Common.DefineConstantValue.EditStateEnum.OE_Update);
        }

        private void sysToolBar_OnItemNew_Click(object sender, EventArgs e)
        {
            ShowDetailForm(Common.DefineConstantValue.EditStateEnum.OE_Insert);
        }

        private void sysToolBar_OnItemRefresh_Click(object sender, EventArgs e)
        {
            loadAllDepartmentList();
        }

        private void sysToolBar_OnItemDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (lvDepartmentList.SelectedItems.Count > 0)
                {
                    if (base.ShowQuestionMessage("是否确认删除选中部门?"))
                    {
                        //int index = lvDepartmentList.SelectedItems[0].Index;
                        //DepartmentMaster_dpm_Info info = _ListDeptAllInfos[index];
                        string strID = lvDepartmentList.SelectedItems[0].SubItems[1].Text;
                        Guid gRecordId = new Guid(strID);
                        DepartmentMaster_dpm_Info info = new DepartmentMaster_dpm_Info();
                        info.dpm_RecordID = gRecordId;

                        List<CardUserMaster_cus_Info> listCardUserLeft = this._ICardUserMasterBL.SearchRecords(new CardUserMaster_cus_Info() { cus_cClassID = gRecordId });
                        if (listCardUserLeft != null && listCardUserLeft.Count > 0)
                        {
                            ShowWarningMessage("此部门仍存在相关联的教师信息，请更新或删除教师信息后重试。");
                            return;
                        }

                        ReturnValueInfo rvInfo = _IDepartmentMasterBL.Save(info, Common.DefineConstantValue.EditStateEnum.OE_Delete);

                        if (rvInfo.boolValue && !rvInfo.isError)
                        {
                            base.ShowInformationMessage("删除成功。");
                        }
                        else
                        {
                            base.ShowErrorMessage("删除失败。" + rvInfo.messageText);
                        }

                        loadAllDepartmentList();

                        sysToolBar.BtnModify_IsEnabled = false;
                        sysToolBar.BtnDelete_IsEnabled = false;
                        sysToolBar.BtnNew_IsEnabled = true;
                        sysToolBar.BtnRefresh_IsEnabled = true;
                    }
                }
                else
                {
                    base.ShowWarningMessage("请先选择一条记录。");
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex);
            }
        }

        private void lvDepartmentList_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            //if (lvDepartmentList.Sorting == SortOrder.Ascending)
            //{
            //    ListViewSorter sorter = new ListViewSorter(e.Column, SortOrder.Descending);
            //    lvDepartmentList.ListViewItemSorter = sorter;
            //    lvDepartmentList.Sorting = SortOrder.Descending;
            //}
            //else
            //{
            //    ListViewSorter sorter = new ListViewSorter(e.Column, SortOrder.Ascending);
            //    lvDepartmentList.ListViewItemSorter = sorter;
            //    lvDepartmentList.Sorting = SortOrder.Ascending;
            //}
        }

        private void lvDepartmentList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvDepartmentList.SelectedItems.Count > 0)
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

        private void lvDepartmentList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lvDepartmentList.SelectedItems.Count > 0)
            {
                sysToolBar_OnItemModify_Click(null, null);
            }
        }
    }
}
