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
using System.Collections;
using Common;
using BLL.IBLL.General;
using BLL.Factory.General;
using Model.IModel;
using Model.General;
using BLL.IBLL.HHZX.UserInfomation.CardUserInfo;
using BLL.Factory.HHZX;

namespace WindowUI.HHZX.UserInformation.CardUserInfo
{

    public partial class frmClassMasterDetail : BaseForm
    {
        /// <summary>
        /// 当前编辑的班级信息
        /// </summary>
        ClassMaster_csm_Info _CurrentClassInfo;
        IClassMasterBL _IClassMasterBL;

        private Hashtable _Hashtable;
        private string _CurrentGradeID;
        private string _CurrentClassNum;

        public frmClassMasterDetail()
        {
            InitializeComponent();

            this._CurrentClassInfo = null;
            this._Hashtable = new Hashtable();
            this._IClassMasterBL = MasterBLLFactory.GetBLL<IClassMasterBL>(MasterBLLFactory.ClassMaster);
        }

        public void ShowForm(ClassMaster_csm_Info editInfo, Common.DefineConstantValue.EditStateEnum editStatc)
        {
            this._CurrentClassInfo = editInfo;
            this.EditState = editStatc;
            this._CurrentGradeID = editInfo.csm_cGDMID.ToString();
            this._CurrentClassNum = editInfo.csm_cClassNum;

            if (this._CurrentClassInfo == null)
            {
                this._CurrentClassInfo = this.BaseParam as ClassMaster_csm_Info;
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
                UserInputData showData = new UserInputData(this._CurrentClassInfo);
                proUserData.SelectedObject = showData;
            }

            this.ShowDialog();
        }

        #region  属性控件用实体

        private class DataTypeComboBoxItem_GradeInfo : ComboBoxItemTypeConvert
        {
            public override void GetConvertHash()
            {
                IGeneralBL generalBL = null;

                generalBL = GeneralBLLFactory.GetBLL<IGeneralBL>(GeneralBLLFactory.General);

                try
                {
                    List<IModelObject> returnSource = generalBL.GetMasterDataInformations(DefineConstantValue.MasterType.Grade);

                    if (returnSource != null && returnSource.Count > 0)
                    {
                        foreach (ComboboxDataInfo item in returnSource)
                        {
                            base._hash.Add(item.ValueMember, item.DisplayMember);
                        }
                    }
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private class DataTypeComboBoxItem_ClassInfo : ComboBoxItemTypeConvert
        {
            public override void GetConvertHash()
            {

                IGeneralBL _generalBL;

                _generalBL = GeneralBLLFactory.GetBLL<IGeneralBL>(GeneralBLLFactory.General);

                try
                {
                    List<IModelObject> returnSource = _generalBL.GetMasterDataInformations(DefineConstantValue.MasterType.CodeMaster_Class);

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
                this.csm_cRecordID = Guid.Empty;
                this.csm_cClassNum = string.Empty;
                this.csm_cGDMID = string.Empty;
                this.csm_cMasterID = string.Empty;
                this.csm_cRemark = this.csm_cRemark;
            }

            public UserInputData(ClassMaster_csm_Info showInfo)
            {
                this.csm_cRecordID = showInfo.csm_cRecordID;
                this.csm_cClassNum = showInfo.csm_cClassNum;
                this.csm_cGDMID = showInfo.csm_cGDMID.ToString();
                this.csm_cMasterID = showInfo.csm_cMasterID.ToString();
                this.csm_cRemark = showInfo.csm_cRemark;
            }

            [ReadOnly(true), Category("班级信息"), DisplayName("班级ID")]
            public Guid csm_cRecordID { get; set; }

            [Category("班级信息"), DisplayName("年级名称"), TypeConverter(typeof(DataTypeComboBoxItem_GradeInfo))]
            public string csm_cGDMID { get; set; }

            [Category("班级信息"), DisplayName("班级名称"), TypeConverter(typeof(DataTypeComboBoxItem_ClassInfo))]
            public string csm_cClassNum { get; set; }

            [Category("班级信息"), DisplayName("班主任"), TypeConverter(typeof(DataTypeComboBoxItem_StaffInfo))]
            public string csm_cMasterID { get; set; }

            [Category("班级信息"), DisplayName("备注")]
            public string csm_cRemark { get; set; }
        }

        #endregion

        private void sysToolBar_OnItemSave_Click(object sender, EventArgs e)
        {
            if (this.EditState == DefineConstantValue.EditStateEnum.OE_Update)
            {
                if (!base.ShowQuestionMessage("是否确认要进行修改操作？"))
                {
                    return;
                }
            }
            try
            {
                UserInputData userData = proUserData.SelectedObject as UserInputData;

                if (string.IsNullOrEmpty(userData.csm_cGDMID))
                {
                    ShowWarningMessage("请先选择年级。");
                    return;
                }
                if (string.IsNullOrEmpty(userData.csm_cClassNum))
                {
                    ShowWarningMessage("请先选择班级。");
                    return;
                }
                if (string.IsNullOrEmpty(userData.csm_cClassNum))
                {
                    ShowWarningMessage("请先选择班主任。");
                    return;
                }

                this._CurrentClassInfo.csm_cClassNum = userData.csm_cClassNum;

                this._CurrentClassInfo.csm_cGDMID = new Guid(userData.csm_cGDMID);

                this._CurrentClassInfo.csm_cMasterID = new Guid(userData.csm_cMasterID);

                this._CurrentClassInfo.csm_cRemark = userData.csm_cRemark;

                this._CurrentClassInfo.lSave = true;

                bool isSame = false;

                if (this.EditState == Common.DefineConstantValue.EditStateEnum.OE_Insert)
                {
                    ClassMaster_csm_Info csmInfo = new ClassMaster_csm_Info();
                    csmInfo.csm_cGDMID = _CurrentClassInfo.csm_cGDMID;
                    csmInfo.csm_cClassNum = _CurrentClassInfo.csm_cClassNum;

                    List<ClassMaster_csm_Info> list = _IClassMasterBL.SearchRecords(csmInfo);

                    if (list != null && list.Count > 0)
                    {
                        isSame = true;
                    }
                }
                else
                {
                    if (this._CurrentClassInfo.csm_cClassNum != this._CurrentClassNum || this._CurrentClassInfo.csm_cGDMID.ToString() != this._CurrentGradeID)
                    {
                        ClassMaster_csm_Info csmInfo = new ClassMaster_csm_Info();
                        csmInfo.csm_cGDMID = _CurrentClassInfo.csm_cGDMID;
                        csmInfo.csm_cClassNum = _CurrentClassInfo.csm_cClassNum;

                        List<ClassMaster_csm_Info> list = _IClassMasterBL.SearchRecords(csmInfo);

                        if (list != null && list.Count > 0)
                        {
                            isSame = true;
                        }
                    }
                }

                if (isSame)
                {
                    MessageBox.Show("班级已存在，不能重复输入。", "提示");
                    this._CurrentClassInfo.lSave = false;
                    return;
                }

            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex);
                this._CurrentClassInfo.lSave = false;
            }

            this.Close();
        }

        private void sysToolBar_OnItemExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void sysToolBar_OnItemRefresh_Click(object sender, EventArgs e)
        {
            proUserData.Refresh();
            if (this._CurrentClassInfo == null)
            {
                this._CurrentClassInfo = this.BaseParam as ClassMaster_csm_Info;
            }
            if (this.EditState == Common.DefineConstantValue.EditStateEnum.OE_Insert)
            {
                UserInputData insertInfo = new UserInputData();
                proUserData.SelectedObject = insertInfo;
            }
            else if (this.EditState == Common.DefineConstantValue.EditStateEnum.OE_Update)
            {
                UserInputData showData = new UserInputData(this._CurrentClassInfo);
                proUserData.SelectedObject = showData;
            }
        }
    }
}
