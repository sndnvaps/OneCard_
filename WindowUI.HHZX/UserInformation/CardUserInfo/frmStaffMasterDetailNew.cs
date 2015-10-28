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
using Model.HHZX.UserInfomation.CardUserInfo;
using BLL.Factory.General;
using BLL.Factory.HHZX;
using Model.IModel;
using Common;
using WindowUI.HHZX.ClassLibrary.Public;
using Model.General;

namespace WindowUI.HHZX.UserInformation.CardUserInfo
{
    public partial class frmStaffMasterDetailNew : BaseForm
    {
        private IGeneralBL _IGeneralBL;
        private ICardUserMasterBL _ICardUserMasterBL;
        private CardUserMaster_cus_Info _CurrentUserInfo;
        private DefineConstantValue.EditStateEnum _EditOpt;

        public frmStaffMasterDetailNew()
        {
            InitializeComponent();

            this._IGeneralBL = GeneralBLLFactory.GetBLL<IGeneralBL>(GeneralBLLFactory.General);
            this._ICardUserMasterBL = MasterBLLFactory.GetBLL<ICardUserMasterBL>(MasterBLLFactory.CardUserMaster);

            BindComboData();
        }

        void BindComboData()
        {
            List<IModelObject> listClassName = this._IGeneralBL.GetMasterDataInformations(DefineConstantValue.MasterType.UserDepartment);
            cbxDptName.SetDataSourceWithHeight(listClassName, 20);
            cbxDptName.SelectedIndex = -1;

            List<IModelObject> listSex = this._IGeneralBL.GetMasterDataInformations(DefineConstantValue.MasterType.CardUserSex);
            cbxSexName.SetDataSourceWithHeight(listSex, 20);
            cbxSexName.SelectedIndex = -1;

            List<IModelObject> listValid = this._IGeneralBL.GetMasterDataInformations(DefineConstantValue.MasterType.UserValid);
            cbxIsActive.SetDataSourceWithHeight(listValid, 20);
            cbxIsActive.SelectedIndex = -1;
        }

        private void btnAutoNum_Click(object sender, EventArgs e)
        {
            try
            {
                string strStaffNum = this._ICardUserMasterBL.GetLastAutoUserCode(DefineConstantValue.CodeMasterDefine.KEY2_SIOT_CardUserIdentity_Staff);
                if (string.IsNullOrEmpty(strStaffNum))
                {
                    ShowWarningMessage("获取教师自动编号失败。");
                    strStaffNum = string.Empty;
                }
                tbxStaffNum.Text = strStaffNum;
            }
            catch (Exception ex)
            {
                ShowErrorMessage("获取教师自动编号失败。" + ex);
            }
        }

        public void ShowForm(CardUserMaster_cus_Info userInfo, DefineConstantValue.EditStateEnum editOpt)
        {
            this._CurrentUserInfo = userInfo;
            this._EditOpt = editOpt;

            if (editOpt == Common.DefineConstantValue.EditStateEnum.OE_Insert)
            {
                this.Text = "新增--" + this.Text;

                cbxIsActive.SelectItemForValue("true");
            }
            else if (editOpt == Common.DefineConstantValue.EditStateEnum.OE_Update)
            {
                this.Text = "编辑--" + this.Text;

                labUserID.Text = userInfo.cus_cRecordID.ToString();
                tbxUserName.Text = userInfo.cus_cChaName;
                cbxDptName.SelectItemForValue(userInfo.cus_cClassID.ToString());
                tbxStaffNum.Text = userInfo.cus_cStudentID;
                cbxSexName.SelectItemForValue(userInfo.cus_cSexNum);
                cbxIsActive.SelectItemForValue(userInfo.cus_lValid.ToString().ToLower());
                tbxContactNum.Text = userInfo.cus_cContractPhone;
                tbxRemarks.Text = userInfo.cus_cRemark;
            }
            else
            {
                return;
            }

            this.ShowDialog();
        }

        private void sysToolBar_OnItemRefresh_Click(object sender, EventArgs e)
        {

        }

        private void sysToolBar_OnItemSave_Click(object sender, EventArgs e)
        {
            #region 验证数据是否为空

            if (string.IsNullOrEmpty(tbxUserName.Text))
            {
                ShowWarningMessage("请先输入【姓名】。");
                tbxUserName.SelectAll();
                tbxUserName.Focus();
                return;
            }
            if (cbxDptName.SelectedValue == null || string.IsNullOrEmpty(cbxDptName.Text))
            {
                ShowWarningMessage("请先选择【部门】。");
                cbxDptName.Focus();
                return;
            }
            if (string.IsNullOrEmpty(tbxStaffNum.Text))
            {
                ShowWarningMessage("请先输入【工号】。");
                tbxStaffNum.Focus();
                return;
            }
            if (cbxSexName.SelectedValue == null || string.IsNullOrEmpty(cbxSexName.Text))
            {
                ShowWarningMessage("请先选择【性别】。");
                cbxSexName.Focus();
                return;
            }
            if (cbxIsActive.SelectedValue == null || string.IsNullOrEmpty(cbxIsActive.Text))
            {
                ShowWarningMessage("请先选择【是否有效】。");
                cbxIsActive.Focus();
                return;
            }

            #endregion

            CardUserMaster_cus_Info searchInfo = new CardUserMaster_cus_Info();
            searchInfo.cus_cStudentID = tbxStaffNum.Text;

            List<CardUserMaster_cus_Info> listRes = this._ICardUserMasterBL.SearchRecord_ForMaster(searchInfo);
            if (listRes != null && listRes.Count > 0 && listRes[0].cus_cStudentID == tbxStaffNum.Text)
            {
                if (this._CurrentUserInfo != null && listRes[0].cus_cStudentID == this._CurrentUserInfo.cus_cStudentID)
                {

                }
                else
                {
                    ShowWarningMessage("工号重复，请重新输入。");
                    tbxStaffNum.SelectAll();
                    tbxStaffNum.Focus();
                    return;
                }
            }

            searchInfo.cus_cChaName = tbxUserName.Text;
            searchInfo.cus_cClassID = new Guid(cbxDptName.SelectedValue.ToString());
            searchInfo.cus_cSexNum = cbxSexName.SelectedValue.ToString();
            searchInfo.cus_lValid = Convert.ToBoolean(cbxIsActive.SelectedValue);
            searchInfo.cus_cContractPhone = tbxContactNum.Text;
            searchInfo.cus_cRemark = tbxRemarks.Text;
            searchInfo.cus_cLast = this.UserInformation.usm_cUserLoginID;

            ReturnValueInfo rvInfo = new ReturnValueInfo();

            if (this._EditOpt == DefineConstantValue.EditStateEnum.OE_Insert)
            {
                searchInfo.cus_cRecordID = Guid.NewGuid();
                searchInfo.cus_cIdentityNum = Common.DefineConstantValue.CodeMasterDefine.KEY2_SIOT_CardUserIdentity_Staff;
                searchInfo.cus_cAdd = this.UserInformation.usm_cUserLoginID;

                rvInfo = this._ICardUserMasterBL.Save(searchInfo, DefineConstantValue.EditStateEnum.OE_Insert);
            }
            else if (this._EditOpt == DefineConstantValue.EditStateEnum.OE_Update)
            {
                searchInfo.cus_cRecordID = this._CurrentUserInfo.cus_cRecordID;
                searchInfo.cus_cIdentityNum = this._CurrentUserInfo.cus_cIdentityNum;
                searchInfo.cus_lIsGraduate = this._CurrentUserInfo.cus_lIsGraduate;

                rvInfo = this._ICardUserMasterBL.Save(searchInfo, DefineConstantValue.EditStateEnum.OE_Update);
            }

            if (rvInfo.boolValue && !rvInfo.isError)
            {
                ShowInformationMessage("保存成功。");
                this.Close();
            }
            else
            {
                ShowInformationMessage("保存失败。" + rvInfo.messageText);
            }
        }
    }
}
