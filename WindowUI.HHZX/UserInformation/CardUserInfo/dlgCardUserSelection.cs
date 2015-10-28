using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Model.HHZX.UserInfomation.CardUserInfo;
using BLL.IBLL.General;
using BLL.IBLL.HHZX.UserInfomation.CardUserInfo;
using BLL.Factory.General;
using BLL.Factory.HHZX;
using Common;
using Model.IModel;
using WindowUI.HHZX.ClassLibrary.Public;

namespace WindowUI.HHZX.UserInformation.CardUserInfo
{
    public partial class dlgCardUserSelection : BaseForm
    {
        /// <summary>
        /// 选中的用户
        /// </summary>
        public CardUserMaster_cus_Info SelectedUser;

        private IGeneralBL _IGeneralBL;
        private ICardUserMasterBL _ICardUserMasterBL;

        public dlgCardUserSelection()
        {
            InitializeComponent();

            this._IGeneralBL = GeneralBLLFactory.GetBLL<IGeneralBL>(GeneralBLLFactory.General);
            this._ICardUserMasterBL = MasterBLLFactory.GetBLL<ICardUserMasterBL>(MasterBLLFactory.CardUserMaster);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            BindComboData(DefineConstantValue.MasterType.UserDepartment);
            BindComboData(DefineConstantValue.MasterType.UserClass);
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
                    cbxDeptInfo.SetDataSource(result, -1);
                    cbxDeptInfo.SelectItemForValue("");
                    break;

                case DefineConstantValue.MasterType.UserClass:
                    cbxClassInfo.SetDataSource(result, -1);
                    cbxClassInfo.SelectItemForValue("");
                    break;

                default:
                    break;
            }
        }

        private void cbxClassInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxClassInfo.SelectedIndex != -1 && !string.IsNullOrEmpty(cbxClassInfo.Text))
            {
                cbxDeptInfo.SelectedIndex = -1;
            }
        }

        private void cbxDeptInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxDeptInfo.SelectedIndex != -1 && !string.IsNullOrEmpty(cbxDeptInfo.Text))
            {
                cbxClassInfo.SelectedIndex = -1;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {

                CardUserMaster_cus_Info searchInfo = new CardUserMaster_cus_Info();

                if (cbxClassInfo.SelectedIndex <= 0 && cbxDeptInfo.SelectedIndex <= 0
                    && string.IsNullOrEmpty(tbxUserNum.Text.Trim()) && string.IsNullOrEmpty(tbxName.Text.Trim()))
                {
                    MessageBox.Show("请输入一个查找条件！", "提示");
                    this.Cursor = Cursors.Default;
                    return;
                }

                if (cbxClassInfo.SelectedIndex > 0)
                {
                    searchInfo.cus_cIdentityNum = DefineConstantValue.CodeMasterDefine.KEY2_SIOT_CardUserIdentity_Student;
                    searchInfo.cus_cClassID = new Guid(cbxClassInfo.SelectedValue.ToString());
                }
                if (cbxDeptInfo.SelectedIndex > 0)
                {
                    searchInfo.cus_cIdentityNum = DefineConstantValue.CodeMasterDefine.KEY2_SIOT_CardUserIdentity_Staff;
                    searchInfo.cus_cClassID = new Guid(cbxDeptInfo.SelectedValue.ToString());
                }

                if (!string.IsNullOrEmpty(tbxUserNum.Text.Trim()))
                {
                    searchInfo.cus_cStudentID = tbxUserNum.Text.Trim();
                }
                if (!string.IsNullOrEmpty(tbxName.Text.Trim()))
                {
                    searchInfo.cus_cChaName = tbxName.Text.Trim();
                }

                List<CardUserMaster_cus_Info> listUsers = this._ICardUserMasterBL.SearchRecord_ForMaster(searchInfo);
                if (listUsers != null)
                {
                    listUsers = listUsers.OrderBy(x => x.cus_cStudentID).ToList();
                }
                lvUserList.SetDataSource<CardUserMaster_cus_Info>(listUsers);
            }
            catch (Exception ex)
            {
                this.ShowErrorMessage(ex);
            }

            this.Cursor = Cursors.Default;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (lvUserList.SelectedItems.Count > 0)
            {
                Guid recordID = new Guid(lvUserList.SelectedItems[0].SubItems[0].Text);
                this.SelectedUser = this._ICardUserMasterBL.DisplayRecord(new CardUserMaster_cus_Info() { cus_cRecordID = recordID }) as CardUserMaster_cus_Info;
            }
        }

        private void lvUserList_DoubleClick(object sender, EventArgs e)
        {
            if (lvUserList.SelectedItems.Count > 0)
            {
                btnSelect_Click(btnSelect, null);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void lvUserList_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (lvUserList.Sorting == SortOrder.Descending)
            {
                ListViewSorter sorter = new ListViewSorter(e.Column, SortOrder.Ascending);
                lvUserList.ListViewItemSorter = sorter;
                lvUserList.Sorting = SortOrder.Ascending;
            }
            else
            {
                ListViewSorter sorter = new ListViewSorter(e.Column, SortOrder.Descending);
                lvUserList.ListViewItemSorter = sorter;
                lvUserList.Sorting = SortOrder.Descending;
            }
        }
    }
}
