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
using BLL.IBLL.HHZX.UserInfomation.CardUserInfo;
using BLL.Factory.HHZX;
using BLL.IBLL.General;
using BLL.Factory.General;
using Model.IModel;
using Common;
using Model.General;

namespace WindowUI.HHZX.UserInformation.CardUserInfo
{
    public partial class frmGradeMasterDetail : BaseForm
    {
        GradeMaster_gdm_Info _editInfo;

        IGradeMasterBL _gradeMasterBL;
        IClassMasterBL _IClassMasterBL;

        public frmGradeMasterDetail()
        {
            InitializeComponent();

            this._editInfo = null;

            this._gradeMasterBL = MasterBLLFactory.GetBLL<IGradeMasterBL>(MasterBLLFactory.GradeMaster);
            this._IClassMasterBL = MasterBLLFactory.GetBLL<IClassMasterBL>(MasterBLLFactory.ClassMaster);
        }

        public void ShowForm(GradeMaster_gdm_Info editInfo, Common.DefineConstantValue.EditStateEnum editStatc)
        {
            this._editInfo = editInfo;

            this.EditState = editStatc;

            this.ShowDialog();
        }

        private class DataTypeComboBoxItem_StaffInfo : ComboBoxItemTypeConvert
        {
            public override void GetConvertHash()
            {

                IGeneralBL _generalBL;

                _generalBL = GeneralBLLFactory.GetBLL<IGeneralBL>(GeneralBLLFactory.General);

                try
                {
                    List<IModelObject> returnSource = _generalBL.GetMasterDataInformations(DefineConstantValue.MasterType.Staff);

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

        public class UserInputData
        {
            public UserInputData()
            {
                this.gdm_cRecordID = Guid.Empty;

                this.gdm_cGradeName = string.Empty;

                this.gdm_cPraepostorID = string.Empty;

                this.gdm_cRemark = string.Empty;

                this.gdm_cAbbreviation = string.Empty;
            }

            public UserInputData(GradeMaster_gdm_Info showInfo)
            {
                this.gdm_cRecordID = showInfo.gdm_cRecordID;

                this.gdm_cGradeName = showInfo.gdm_cGradeName;

                this.gdm_cPraepostorID = showInfo.gdm_cPraepostorID.ToString();

                this.gdm_cRemark = showInfo.gdm_cRemark;

                this.gdm_cAbbreviation = showInfo.gdm_cAbbreviation;
            }

            [ReadOnly(true), Category("年级信息"), DisplayName("年级ID")]
            public Guid gdm_cRecordID { get; set; }

            [Category("年级信息"), DisplayName("名称")]
            public string gdm_cGradeName { get; set; }

            [Category("年级信息"), DisplayName("级长"), TypeConverter(typeof(DataTypeComboBoxItem_StaffInfo))]
            public string gdm_cPraepostorID { get; set; }

            [Category("年级信息"), DisplayName("年级缩写")]
            public string gdm_cAbbreviation { get; set; }

            [Category("年级信息"), DisplayName("备注")]
            public string gdm_cRemark { get; set; }
        }

        private void frmGradeMasterDetail_Load(object sender, EventArgs e)
        {
            if (_editInfo == null)
            {
                _editInfo = this.BaseParam as GradeMaster_gdm_Info;
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

                UserInputData showData = new UserInputData(_editInfo);

                proUserData.SelectedObject = showData;
            }
        }

        private void sysToolBar_OnItemSave_Click(object sender, EventArgs e)
        {
            try
            {
                UserInputData saveData = proUserData.SelectedObject as UserInputData;
                List<ClassMaster_csm_Info> listClassInfos = this._IClassMasterBL.SearchRecords(new ClassMaster_csm_Info() { csm_cGDMID = this._editInfo.gdm_cRecordID });

                if (string.IsNullOrEmpty(saveData.gdm_cGradeName))
                {
                    ShowWarningMessage("请输入年级名称。");
                    return;
                }
                if (string.IsNullOrEmpty(saveData.gdm_cPraepostorID))
                {
                    ShowWarningMessage("请先选择年级长。");
                    return;
                }

                if (this._editInfo.gdm_cGradeName != saveData.gdm_cGradeName && this.EditState == DefineConstantValue.EditStateEnum.OE_Update)
                {
                    if (listClassInfos != null && listClassInfos.Count > 0)
                    {
                        if (!ShowQuestionMessage("本年级与多个班级相关联，如修改【年级名称】，会同时修改班级显示的名称信息，是否确认需要继续？"))
                        {
                            return;
                        }
                    }
                }
                this._editInfo.gdm_cGradeName = saveData.gdm_cGradeName;

                this._editInfo.gdm_cPraepostorID = new Guid(saveData.gdm_cPraepostorID);

                this._editInfo.gdm_cRemark = saveData.gdm_cRemark;

                if (this._editInfo.gdm_cAbbreviation != saveData.gdm_cAbbreviation && this.EditState == DefineConstantValue.EditStateEnum.OE_Update)
                {
                    if (listClassInfos != null && listClassInfos.Count > 0)
                    {
                        if (!ShowQuestionMessage("本年级与多个班级相关联，如修改【年级缩写】，对应的学生发卡信息会变更，是否确认需要继续？"))
                        {
                            return;
                        }
                    }
                }
                this._editInfo.gdm_cAbbreviation = saveData.gdm_cAbbreviation;

                this._editInfo.lSave = true;
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex);
                this._editInfo.lSave = false;
            }

            this.Close();
        }

        private void sysToolBar_OnItemExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
