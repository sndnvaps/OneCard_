using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL.IBLL.General;
using Model.HHZX.UserInfomation.CardUserInfo;
using Common;
using BLL.Factory.General;
using BLL.IBLL.HHZX.UserInfomation.CardUserInfo;
using BLL.Factory.HHZX;
using Model.IModel;
using WindowUI.HHZX.ClassLibrary.Public;
using Model.General;

namespace WindowUI.HHZX.UserInformation.CardUserInfo
{
    public partial class frmStudentMasterDetailNew : BaseForm
    {
        private IGeneralBL _IGeneralBL;
        private ICardUserMasterBL _ICardUserMasterBL;
        private CardUserMaster_cus_Info _CurrentUserInfo;
        private List<CardUserMaster_cus_Info> _ListUserInfo;
        private DefineConstantValue.EditStateEnum _EditOpt;
        private bool _IsBatchModify;

        public frmStudentMasterDetailNew()
        {
            InitializeComponent();

            this._IGeneralBL = GeneralBLLFactory.GetBLL<IGeneralBL>(GeneralBLLFactory.General);
            this._ICardUserMasterBL = MasterBLLFactory.GetBLL<ICardUserMasterBL>(MasterBLLFactory.CardUserMaster);

            BindComboData();
        }

        void BindComboData()
        {
            List<IModelObject> listClassName = this._IGeneralBL.GetMasterDataInformations(DefineConstantValue.MasterType.UserClass);
            cbxClassName.SetDataSourceWithHeight(listClassName, 20);
            cbxClassName.SelectedIndex = -1;

            List<IModelObject> listSex = this._IGeneralBL.GetMasterDataInformations(DefineConstantValue.MasterType.CardUserSex);
            cbxSexName.SetDataSourceWithHeight(listSex, 20);
            cbxSexName.SelectedIndex = -1;

            List<IModelObject> listValid = this._IGeneralBL.GetMasterDataInformations(DefineConstantValue.MasterType.UserValid);
            cbxIsActive.SetDataSourceWithHeight(listValid, 20);
            cbxIsActive.SelectedIndex = -1;
        }

        public void ShowForm(CardUserMaster_cus_Info userInfo, DefineConstantValue.EditStateEnum editOpt)
        {
            this._CurrentUserInfo = userInfo;
            this._EditOpt = editOpt;

            if (editOpt == Common.DefineConstantValue.EditStateEnum.OE_Insert)
            {
                this.Text = "新增--" + this.Text;

                tbxYear.Text = DateTime.Now.Year.ToString();
                tbxGraduation.Text = tbxYear.Text;
                cbxIsActive.SelectItemForValue("true");
            }
            else if (editOpt == Common.DefineConstantValue.EditStateEnum.OE_Update)
            {
                this.Text = "编辑--" + this.Text;

                labUserID.Text = userInfo.cus_cRecordID.ToString();
                tbxUserName.Text = userInfo.cus_cChaName;
                cbxClassName.SelectItemForValue(userInfo.cus_cClassID.ToString());
                tbxStuNum.Text = userInfo.cus_cStudentID;
                cbxSexName.SelectItemForValue(userInfo.cus_cSexNum);
                tbxYear.Text = userInfo.cus_cComeYear;
                tbxGraduation.Text = userInfo.cus_cGraduationPeriod;
                cbxIsActive.SelectItemForValue(userInfo.cus_lValid.ToString().ToLower());
                tbxContactName.Text = userInfo.cus_cContractName;
                tbxContactNum.Text = userInfo.cus_cContractPhone;
                tbxRemarks.Text = userInfo.cus_cRemark;
                nbxBankAccount.Text = userInfo.cus_cBankAccount;
            }
            else
            {
                return;
            }

            this.ShowDialog();
        }

        public void ShowForm(List<CardUserMaster_cus_Info> listUserInfos)
        {
            this.Text = "批量编辑--" + this.Text;
            this._IsBatchModify = true;
            this._ListUserInfo = listUserInfos;

            tbxUserName.Enabled = false;
            tbxStuNum.Enabled = false;
            btnAutoCode.Enabled = false;
            cbxIsActive.Enabled = false;
            tbxContactName.Enabled = false;
            tbxContactNum.Enabled = false;
            tbxGraduation.Enabled = false;
            tbxRemarks.Enabled = false;
            tbxStuNum.Enabled = false;
            tbxYear.Enabled = false;
            cbxSexName.Enabled = false;
            nbxBankAccount.Enabled = false;

            this.ShowDialog();
        }

        private void btnAutoCode_Click(object sender, EventArgs e)
        {
            try
            {
                string strStuNum = this._ICardUserMasterBL.GetLastAutoUserCode(DefineConstantValue.CodeMasterDefine.KEY2_SIOT_CardUserIdentity_Student);
                if (string.IsNullOrEmpty(strStuNum))
                {
                    ShowWarningMessage("获取学生自动编号失败。");
                    strStuNum = string.Empty;
                }
                tbxStuNum.Text = strStuNum;
            }
            catch (Exception ex)
            {
                ShowErrorMessage("获取学生自动编号失败。" + ex);
            }
        }

        private void sysToolBar_OnItemSave_Click(object sender, EventArgs e)
        {
            if (!this._IsBatchModify)
            {
                #region 验证数据是否为空

                if (string.IsNullOrEmpty(tbxUserName.Text))
                {
                    ShowWarningMessage("请先输入【姓名】。");
                    tbxUserName.SelectAll();
                    tbxUserName.Focus();
                    return;
                }
                if (cbxClassName.SelectedValue == null || string.IsNullOrEmpty(cbxClassName.Text))
                {
                    ShowWarningMessage("请先选择【班别】。");
                    cbxClassName.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(tbxStuNum.Text))
                {
                    ShowWarningMessage("请先输入【学号】。");
                    tbxStuNum.Focus();
                    return;
                }
                if (cbxSexName.SelectedValue == null || string.IsNullOrEmpty(cbxSexName.Text))
                {
                    ShowWarningMessage("请先选择【性别】。");
                    cbxSexName.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(tbxYear.Text))
                {
                    ShowWarningMessage("请先输入【入学时间】。");
                    tbxYear.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(tbxGraduation.Text))
                {
                    ShowWarningMessage("请先输入【届别】。");
                    tbxGraduation.Focus();
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
                searchInfo.cus_cStudentID = tbxStuNum.Text;

                List<CardUserMaster_cus_Info> listRes = this._ICardUserMasterBL.SearchRecord_ForMaster(searchInfo);
                if (listRes != null && listRes.Count > 0 && listRes[0].cus_cStudentID == tbxStuNum.Text)
                {
                    if (this._CurrentUserInfo != null && listRes[0].cus_cStudentID == this._CurrentUserInfo.cus_cStudentID)
                    {

                    }
                    else
                    {
                        ShowWarningMessage("学号重复，请重新输入。");
                        tbxStuNum.SelectAll();
                        tbxStuNum.Focus();
                        return;
                    }
                }

                searchInfo.cus_cChaName = tbxUserName.Text;
                searchInfo.cus_cClassID = new Guid(cbxClassName.SelectedValue.ToString());
                searchInfo.cus_cSexNum = cbxSexName.SelectedValue.ToString();
                searchInfo.cus_cComeYear = tbxYear.Text;
                searchInfo.cus_cGraduationPeriod = tbxGraduation.Text;
                searchInfo.cus_lValid = Convert.ToBoolean(cbxIsActive.SelectedValue);
                searchInfo.cus_cContractName = tbxContactName.Text;
                searchInfo.cus_cContractPhone = tbxContactNum.Text;
                searchInfo.cus_cBankAccount = nbxBankAccount.Text;
                searchInfo.cus_cRemark = tbxRemarks.Text;
                searchInfo.cus_cLast = this.UserInformation.usm_cUserLoginID;

                ReturnValueInfo rvInfo = new ReturnValueInfo();

                if (this._EditOpt == DefineConstantValue.EditStateEnum.OE_Insert)
                {
                    searchInfo.cus_cRecordID = Guid.NewGuid();
                    searchInfo.cus_cIdentityNum = Common.DefineConstantValue.CodeMasterDefine.KEY2_SIOT_CardUserIdentity_Student;
                    searchInfo.cus_cAdd = this.UserInformation.usm_cUserLoginID;
                    searchInfo.cus_lIsGraduate = false;

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
            else
            {
                if (cbxClassName.SelectedValue == null || string.IsNullOrEmpty(cbxClassName.Text))
                {
                    ShowWarningMessage("请先选择【班别】。");
                    cbxClassName.Focus();
                    return;
                }

                ReturnValueInfo rvInfo = this._ICardUserMasterBL.UpdateStudentsInfo(this._ListUserInfo, new Guid(cbxClassName.SelectedValue.ToString()));
                if (rvInfo.boolValue && !rvInfo.isError)
                {
                    ShowInformationMessage("批量保存成功。");
                    this.Close();
                }
                else
                {
                    ShowInformationMessage("批量保存失败。" + rvInfo.messageText);
                }
            }
        }

        private void sysToolBar_OnItemRefresh_Click(object sender, EventArgs e)
        {
            BindComboData();
        }
    }
}
