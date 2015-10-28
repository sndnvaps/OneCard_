using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Model.TestModel;
using System.Collections;
using BLL.IBLL.General;
using BLL.Factory.General;
using Model.IModel;
using Common;
using Model.General;
using Model.HHZX.UserInfomation.CardUserInfo;
using BLL.IBLL.HHZX.UserInfomation.CardUserInfo;
using BLL.Factory.HHZX;

namespace WindowUI.HHZX.UserInformation.CardUserInfo
{
    public partial class frmStudentMasterDetail : BaseForm
    {
        CardUserMaster_cus_Info _editInfo;

        List<CardUserMaster_cus_Info> _userInfos;

        ICardUserMasterBL _cardUserMaster;

        bool _isBatchmodify;

        public Hashtable _hash = null;

        public frmStudentMasterDetail()
        {
            InitializeComponent();

            this._editInfo = null;

            this._userInfos = null;

            this._cardUserMaster = MasterBLLFactory.GetBLL<ICardUserMasterBL>(MasterBLLFactory.CardUserMaster);

            _hash = new Hashtable();
        }

        public void ShowForm(CardUserMaster_cus_Info editInfo, Common.DefineConstantValue.EditStateEnum editStatc, bool isBatchmodify)
        {
            this._editInfo = editInfo;

            this.EditState = editStatc;

            this._isBatchmodify = isBatchmodify;

            this.ShowDialog();
        }

        public void ShowForm(List<CardUserMaster_cus_Info> userList, bool isBatchmodify)
        {
            this._userInfos = userList;

            this._isBatchmodify = isBatchmodify;

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

        private class DataTypeComboBoxItem_CardUserClass : ComboBoxItemTypeConvert
        {
            public override void GetConvertHash()
            {

                IGeneralBL _generalBL;

                _generalBL = GeneralBLLFactory.GetBLL<IGeneralBL>(GeneralBLLFactory.General);

                try
                {
                    List<IModelObject> returnSource = _generalBL.GetMasterDataInformations(DefineConstantValue.MasterType.UserClass);

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
                try
                {
                    _hash.Add("是", "是");
                    _hash.Add("否", "否");
                }
                catch (Exception Ex)
                {

                    MessageBox.Show(Ex.Message);
                }
            }
        }

        /// <summary>
        /// 年份
        /// </summary>
        private class DataTypeComboBoxItem_Year : ComboBoxItemTypeConvert
        {
            public override void GetConvertHash()
            {
                try
                {
                    DateTime now = System.DateTime.Now;

                    for (int index = -3; index < 3; index++)
                    {
                        _hash.Add(now.AddYears(index).ToString("yyyy"), now.AddYears(index).ToString("yyyy"));
                    }

                    //_hash.Add("是", "是");
                    //_hash.Add("否", "否");
                }
                catch (Exception Ex)
                {

                    MessageBox.Show(Ex.Message);
                }
            }
        }

        public class BatchUserInfo
        {

            public BatchUserInfo()
            {

            }

            [Category("学生信息"), DisplayName("班别"), TypeConverter(typeof(DataTypeComboBoxItem_CardUserClass))]
            public string cus_cClassID { get; set; }
        }

        public class UserInputData
        {
            public UserInputData()
            {
                this.cus_cRecordID = string.Empty;

                this.cus_cStudentID = string.Empty;

                this.cus_cChaName = string.Empty;

                this.cus_cSexNum = string.Empty;

                this.cus_cComeYear = string.Empty;

                this.cus_cGraduationPeriod = string.Empty;

                this.cus_cClassID = string.Empty;

                this.cus_cContractName = string.Empty;

                this.cus_cContractPhone = string.Empty;

                this.cus_cRemark = string.Empty;

                this.cus_lValid = string.Empty;

            }

            public UserInputData(CardUserMaster_cus_Info showInfo)
            {
                this.cus_cRecordID = showInfo.cus_cRecordID.ToString();

                this.cus_cStudentID = showInfo.cus_cStudentID;

                this.cus_cChaName = showInfo.cus_cChaName;

                this.cus_cSexNum = showInfo.cus_cSexNum;

                this.cus_cComeYear = showInfo.cus_cComeYear;

                this.cus_cGraduationPeriod = showInfo.cus_cGraduationPeriod;

                this.cus_cClassID = showInfo.cus_cClassID.ToString();

                this.cus_cContractName = showInfo.cus_cContractName;

                this.cus_cContractPhone = showInfo.cus_cContractPhone;

                this.cus_cRemark = showInfo.cus_cRemark;

                this.cus_lValid = showInfo.cus_lValid == true ? "是" : "否";
            }

            [Category("学生信息"), DisplayName("ID"), ReadOnly(true)]
            public string cus_cRecordID { get; set; }

            [Category("学生信息"), DisplayName("学号*")]
            public string cus_cStudentID { get; set; }

            [Category("学生信息"), DisplayName("姓名*")]
            public string cus_cChaName { get; set; }

            [Category("学生信息"), DisplayName("性别*"), TypeConverter(typeof(DataTypeComboBoxItem_CardUserSex))]
            public string cus_cSexNum { get; set; }

            [Category("学生信息"), DisplayName("入学时间*"), TypeConverter(typeof(DataTypeComboBoxItem_Year))]
            public string cus_cComeYear { get; set; }

            [Category("学生信息"), DisplayName("届别*"), TypeConverter(typeof(DataTypeComboBoxItem_Year))]
            public string cus_cGraduationPeriod { get; set; }

            [Category("学生信息"), DisplayName("班别*"), TypeConverter(typeof(DataTypeComboBoxItem_CardUserClass))]
            public string cus_cClassID { get; set; }

            [Category("学生信息"), DisplayName("是否有效*"), TypeConverter(typeof(DataTypeComboBoxItem_Valid))]
            public string cus_lValid { get; set; }

            [Category("学生信息"), DisplayName("家长姓名")]
            public string cus_cContractName { get; set; }

            [Category("学生信息"), DisplayName("家长联系电话")]
            public string cus_cContractPhone { get; set; }

            [Category("学生信息"), DisplayName("备注")]
            public string cus_cRemark { get; set; }
        }

        private void frmStudentMasterDetail_Load(object sender, EventArgs e)
        {
            if (!this._isBatchmodify)
            {
                if (_editInfo == null)
                {
                    _editInfo = this.BaseParam as CardUserMaster_cus_Info;
                }

                if (this.EditState == Common.DefineConstantValue.EditStateEnum.OE_Insert)
                {
                    this.Text = "新增 - " + this.Text;

                    UserInputData insertInfo = new UserInputData();
                    insertInfo.cus_cGraduationPeriod = DateTime.Now.Year.ToString();
                    insertInfo.cus_cComeYear = DateTime.Now.Year.ToString();
                    insertInfo.cus_lValid = "是";
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
            else
            {
                BatchUserInfo userInfo = new BatchUserInfo();

                proUserData.SelectedObject = userInfo;
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
            if (!this._isBatchmodify)
            {
                UserInputData userData = proUserData.SelectedObject as UserInputData;

                this._editInfo.IsSaved = false;

                if (this.EditState == DefineConstantValue.EditStateEnum.OE_Insert)
                {
                    this._editInfo.cus_cRecordID = Guid.NewGuid();
                }

                this._editInfo.cus_cStudentID = userData.cus_cStudentID;

                if (String.IsNullOrEmpty(userData.cus_cChaName))
                {
                    base.ShowInformationMessage("请输入学生姓名。");
                    return;
                }
                this._editInfo.cus_cChaName = userData.cus_cChaName;

                if (String.IsNullOrEmpty(userData.cus_cSexNum))
                {
                    base.ShowInformationMessage("请输入学生姓别。");
                    return;
                }
                this._editInfo.cus_cSexNum = userData.cus_cSexNum;

                this._editInfo.cus_cIdentityNum = Common.DefineConstantValue.CodeMasterDefine.KEY2_SIOT_CardUserIdentity_Student;

                if (String.IsNullOrEmpty(userData.cus_cComeYear))
                {
                    base.ShowInformationMessage("请输入入学时间。");
                    return;
                }
                this._editInfo.cus_cComeYear = userData.cus_cComeYear;

                if (String.IsNullOrEmpty(userData.cus_cGraduationPeriod))
                {
                    base.ShowInformationMessage("请输入届别。");
                    return;
                }
                this._editInfo.cus_cGraduationPeriod = userData.cus_cGraduationPeriod;

                if (String.IsNullOrEmpty(userData.cus_cClassID))
                {
                    base.ShowInformationMessage("请选择班别。");
                    return;
                }
                this._editInfo.cus_cClassID = new Guid(userData.cus_cClassID);

                this._editInfo.cus_cContractPhone = userData.cus_cContractPhone;

                this._editInfo.cus_cContractName = userData.cus_cContractName;

                if (string.IsNullOrEmpty(userData.cus_lValid))
                {
                    base.ShowInformationMessage("请选择用户是否启用。");
                    return;
                }
                this._editInfo.cus_lValid = userData.cus_lValid == "是" ? true : false;

                this._editInfo.cus_cRemark = userData.cus_cRemark;

                this._editInfo.IsSaved = true;
            }
            else
            {
                BatchUserInfo batchUserInfo = proUserData.SelectedObject as BatchUserInfo;

                if (!string.IsNullOrEmpty(batchUserInfo.cus_cClassID))
                {
                    ReturnValueInfo returnInfo = this._cardUserMaster.UpdateStudentsInfo(this._userInfos, new Guid(batchUserInfo.cus_cClassID));

                    if (returnInfo.boolValue)
                    {
                        ShowInformationMessage(Common.DefineConstantValue.SystemMessageText.strMessageText_I_UpdateSuccess);
                    }
                    else
                    {
                        ShowErrorMessage(Common.DefineConstantValue.SystemMessageText.strMessageText_I_UpdateFail);
                    }
                }
                else
                {
                    ShowWarningMessage("请先选择班级。");
                }
            }

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
                userData.cus_cStudentID = this._cardUserMaster.GetLastAutoUserCode(Common.DefineConstantValue.CodeMasterDefine.KEY2_SIOT_CardUserIdentity_Student);
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
