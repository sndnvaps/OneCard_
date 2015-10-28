using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Model.TestModel;
using Model.HHZX.UserInfomation.CardUserInfo;
using BLL.IBLL.General;
using BLL.Factory.General;
using Model.IModel;
using Model.General;
using Common;
using System.Collections;
using BLL.IBLL.HHZX.UserInfomation.CardUserInfo;
using BLL.Factory.HHZX;

namespace WindowUI.HHZX.UserInformation.CardUserInfo
{
    public partial class frmStaffMasterDetail : BaseForm
    {
        public ICardUserMasterBL _ICardUserMasterBL;
        public Hashtable _hash = null;

        CardUserMaster_cus_Info _editInfo;

        public frmStaffMasterDetail()
        {
            InitializeComponent();

            this._editInfo = null;

            this._hash = new Hashtable();
            this._ICardUserMasterBL = MasterBLLFactory.GetBLL<ICardUserMasterBL>(MasterBLLFactory.CardUserMaster);
        }

        public void ShowForm(CardUserMaster_cus_Info editInfo, Common.DefineConstantValue.EditStateEnum editStatc)
        {
            this._editInfo = editInfo;

            this.EditState = editStatc;

            this.ShowDialog();
        }

        private class DataTypeComboBoxItem_CardUserSex : ComboBoxItemTypeConvert
        {
            public override void GetConvertHash()
            {

                IGeneralBL _generalBL;

                _generalBL = GeneralBLLFactory.GetBLL<IGeneralBL>(GeneralBLLFactory.General);

                try
                {
                    List<IModelObject> returnSource = _generalBL.GetMasterDataInformations(DefineConstantValue.MasterType.CardUserSex);

                    if (returnSource != null && returnSource.Count > 0)
                    {
                        foreach (ComboboxDataInfo item in returnSource)
                        {
                            _hash.Add(item.ValueMember, item.DisplayMember);
                        }
                    }
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private class DataTypeComboBoxItem_DepartMent : ComboBoxItemTypeConvert
        {
            public override void GetConvertHash()
            {
                IGeneralBL _generalBL;

                _generalBL = GeneralBLLFactory.GetBLL<IGeneralBL>(GeneralBLLFactory.General);

                try
                {
                    List<IModelObject> returnSource = _generalBL.GetMasterDataInformations(DefineConstantValue.MasterType.UserDepartment);

                    if (returnSource != null && returnSource.Count > 0)
                    {
                        foreach (ComboboxDataInfo item in returnSource)
                        {
                            _hash.Add(item.ValueMember, item.DisplayMember);
                        }
                    }
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        /// <summary>
        /// 是否有效
        /// </summary>
        private class DataTypeComboBoxItem_Valid : ComboBoxItemTypeConvert
        {
            public override void GetConvertHash()
            {
                _hash.Add("是", "是");
                _hash.Add("否", "否");
            }
        }

        public class UserInputData
        {
            public UserInputData()
            {
                this.cus_cRecordID = Guid.Empty;
                this.cus_cChaName = string.Empty;
                this.cus_cStudentID = string.Empty;
                this.cus_cContractPhone = string.Empty;
                this.cus_cRemark = string.Empty;
                this.cus_lValid = "是";
            }

            public UserInputData(CardUserMaster_cus_Info showInfo)
            {
                this.cus_cRecordID = showInfo.cus_cRecordID;
                this.cus_cChaName = showInfo.cus_cChaName;
                this.cus_cSexNum = showInfo.cus_cSexNum;
                this.cus_cStudentID = showInfo.cus_cStudentID;
                this.cus_cClassID = showInfo.cus_cClassID.ToString();
                this.cus_cContractPhone = showInfo.cus_cContractPhone;
                this.cus_cRemark = showInfo.cus_cRemark;
                this.cus_lValid = showInfo.cus_lValid == true ? "是" : "否";
            }

            [Category("教师信息"), DisplayName("ID"), ReadOnly(true)]
            public Guid cus_cRecordID { get; set; }

            [Category("教师信息"), DisplayName("姓名")]
            public string cus_cChaName { get; set; }

            [Category("教师信息"), DisplayName("工号")]
            public string cus_cStudentID { get; set; }

            [Category("教师信息"), DisplayName("性别"), TypeConverter(typeof(DataTypeComboBoxItem_CardUserSex))]
            public string cus_cSexNum { get; set; }

            [Category("教师信息"), DisplayName("部门"), TypeConverter(typeof(DataTypeComboBoxItem_DepartMent))]
            public string cus_cClassID { get; set; }

            [Category("教师信息"), DisplayName("联系电话")]
            public string cus_cContractPhone { get; set; }

            [Category("教师信息"), DisplayName("备注")]
            public string cus_cRemark { get; set; }

            [Category("教师信息"), DisplayName("有效"), TypeConverter(typeof(DataTypeComboBoxItem_Valid))]
            public string cus_lValid { get; set; }
        }

        private void frmStaffMasterDetail_Load(object sender, EventArgs e)
        {
            if (_editInfo == null)
            {
                _editInfo = this.BaseParam as CardUserMaster_cus_Info;
            }

            if (this.EditState == Common.DefineConstantValue.EditStateEnum.OE_Insert)
            {
                this.Text = "新增 - " + this.Text;

                UserInputData insertInfo = new UserInputData();

                proUserData.SelectedObject = insertInfo;
            }
            else if (this.EditState == Common.DefineConstantValue.EditStateEnum.OE_Update)
            {
                this.Text = "查看 - " + this.Text;
                btnAutoNum.Enabled = false;

                UserInputData showData = new UserInputData(_editInfo);

                proUserData.SelectedObject = showData;
            }
        }

        private void sysToolBar_OnItemSave_Click(object sender, EventArgs e)
        {
            if (this.EditState == DefineConstantValue.EditStateEnum.OE_Update)
            {
                if (!base.ShowQuestionMessage("是否确认要进行修改操作？"))
                {
                    return;
                }
            }
            UserInputData userData = proUserData.SelectedObject as UserInputData;

            if (this.EditState == DefineConstantValue.EditStateEnum.OE_Insert)
            {
                this._editInfo.cus_cRecordID = Guid.NewGuid();
            }

            if (String.IsNullOrEmpty(userData.cus_cStudentID))
            {
                MessageBox.Show("请输入工号。", "提示");
                return;
            }
            this._editInfo.cus_cStudentID = userData.cus_cStudentID;

            if (String.IsNullOrEmpty(userData.cus_cChaName))
            {
                MessageBox.Show("请输入姓名。", "提示");
                return;
            }
            this._editInfo.cus_cChaName = userData.cus_cChaName;

            if (String.IsNullOrEmpty(userData.cus_cSexNum))
            {
                MessageBox.Show("请选择性别。", "提示");
                return;
            }
            this._editInfo.cus_cSexNum = userData.cus_cSexNum;

            this._editInfo.cus_cIdentityNum = Common.DefineConstantValue.CodeMasterDefine.KEY2_SIOT_CardUserIdentity_Staff;

            if (String.IsNullOrEmpty(userData.cus_cClassID))
            {
                MessageBox.Show("请选择部门。", "提示");
                return;
            }
            this._editInfo.cus_cClassID = new Guid(userData.cus_cClassID);

            this._editInfo.cus_cContractPhone = userData.cus_cContractPhone;

            this._editInfo.cus_lValid = userData.cus_lValid == "是" ? true : false;

            this._editInfo.cus_cRemark = userData.cus_cRemark;

            this._editInfo.IsSaved = true;

            this.Close();
        }

        private void sysToolBar_OnItemExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAutoNum_Click(object sender, EventArgs e)
        {
            try
            {
                UserInputData userData = proUserData.SelectedObject as UserInputData;
                userData.cus_cStudentID = this._ICardUserMasterBL.GetLastAutoUserCode(Common.DefineConstantValue.CodeMasterDefine.KEY2_SIOT_CardUserIdentity_Staff);
                if (string.IsNullOrEmpty(userData.cus_cStudentID))
                {
                    userData.cus_cStudentID = "自动编号失败";
                }
                proUserData.SelectedObject = userData;
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex);
            }
        }
    }
}
