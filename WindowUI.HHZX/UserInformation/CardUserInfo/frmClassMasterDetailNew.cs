using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL.IBLL.General;
using BLL.Factory.General;
using Model.IModel;
using WindowUI.HHZX.ClassLibrary.Public;
using Model.HHZX.UserInfomation.CardUserInfo;
using Common;
using BLL.IBLL.HHZX.UserInfomation.CardUserInfo;
using BLL.Factory.HHZX;
using Model.General;

namespace WindowUI.HHZX.UserInformation.CardUserInfo
{
    public partial class frmClassMasterDetailNew : BaseForm
    {
        private IGeneralBL _IGeneralBL;
        private ClassMaster_csm_Info _CurrentClassInfo;
        private DefineConstantValue.EditStateEnum _EditOpt;

        public frmClassMasterDetailNew()
        {
            InitializeComponent();

            this._IGeneralBL = GeneralBLLFactory.GetBLL<IGeneralBL>(GeneralBLLFactory.General);

            BindComboData();
        }

        /// <summary>
        /// 绑定数据源
        /// </summary>
        void BindComboData()
        {
            List<IModelObject> listGradeInfos = this._IGeneralBL.GetMasterDataInformations(Common.DefineConstantValue.MasterType.Grade);
            cbxGradeName.SetDataSourceWithHeight(listGradeInfos, 20);
            cbxGradeName.SelectedIndex = -1;

            List<IModelObject> listClassInfos = this._IGeneralBL.GetMasterDataInformations(Common.DefineConstantValue.MasterType.CodeMaster_Class);
            cbxClassName.SetDataSourceWithHeight(listClassInfos, 20);
            cbxClassName.SelectedIndex = -1;

            List<IModelObject> listTeachers = this._IGeneralBL.GetMasterDataInformations(Common.DefineConstantValue.MasterType.TeacherInfo);
            cbxHeadTeacher.SetDataSourceWithHeight(listTeachers, 20);
            cbxHeadTeacher.SelectedIndex = -1;
        }

        /// <summary>
        /// 展示子窗体
        /// </summary>
        /// <param name="classInfo">需要更新的实体信息</param>
        /// <param name="editOpt">编辑操作</param>
        public void ShowForm(ClassMaster_csm_Info classInfo, DefineConstantValue.EditStateEnum editOpt)
        {
            this._CurrentClassInfo = classInfo;
            this._EditOpt = editOpt;

            if (editOpt == Common.DefineConstantValue.EditStateEnum.OE_Insert)
            {
                this.Text = "新增--" + this.Text;
            }
            else if (editOpt == Common.DefineConstantValue.EditStateEnum.OE_Update)
            {
                this.Text = "编辑--" + this.Text;

                labClassID.Text = classInfo.csm_cRecordID.ToString();
                cbxGradeName.SelectItemForValue(classInfo.csm_cGDMID.ToString());
                cbxClassName.SelectItemForValue(classInfo.csm_cClassNum);
                cbxHeadTeacher.SelectItemForValue(classInfo.csm_cMasterID.ToString());
                tbxRemarks.Text = classInfo.csm_cRemark;
            }
            else
            {
                return;
            }
            this.ShowDialog();
        }

        private void sysToolBar_OnItemSave_Click(object sender, EventArgs e)
        {
            if (this._EditOpt == DefineConstantValue.EditStateEnum.OE_Update)
            {
                if (!ShowQuestionMessage("是否确认保存修改？"))
                {
                    return;
                }
            }

            if (cbxGradeName.SelectedValue == null || string.IsNullOrEmpty(cbxGradeName.Text))
            {
                ShowWarningMessage("请先选择【年级】。");
                cbxGradeName.Focus();
                return;
            }
            if (cbxClassName.SelectedValue == null || string.IsNullOrEmpty(cbxClassName.Text))
            {
                ShowWarningMessage("请先选择【班级名称】。");
                cbxClassName.Focus();
                return;
            }
            if (cbxHeadTeacher.SelectedValue == null || string.IsNullOrEmpty(cbxHeadTeacher.Text))
            {
                ShowWarningMessage("请先选择【班主任】。");
                cbxHeadTeacher.Focus();
                return;
            }

            ClassMaster_csm_Info searchInfo = new ClassMaster_csm_Info();
            searchInfo.csm_cClassNum = cbxClassName.SelectedValue.ToString();
            searchInfo.csm_cGDMID = new Guid(cbxGradeName.SelectedValue.ToString());

            IClassMasterBL classBL = MasterBLLFactory.GetBLL<IClassMasterBL>(MasterBLLFactory.ClassMaster);
            List<ClassMaster_csm_Info> listClassInfos = classBL.SearchRecords(searchInfo);
            if (listClassInfos != null && listClassInfos.Count > 0)
            {
                if (this._CurrentClassInfo != null && listClassInfos[0].csm_cClassNum == this._CurrentClassInfo.csm_cClassNum && listClassInfos[0].csm_cGDMID == this._CurrentClassInfo.csm_cGDMID)
                {

                }
                else
                {
                    ShowWarningMessage("已存在相同定义的班级，请重新选择后再试。");
                    return;
                }
            }

            searchInfo.csm_cRecordID = new Guid(labClassID.Text);
            searchInfo.csm_cLast = this.UserInformation.usm_cUserLoginID;
            searchInfo.csm_cMasterID = new Guid(cbxHeadTeacher.SelectedValue.ToString());
            searchInfo.csm_cRemark = tbxRemarks.Text;

            ReturnValueInfo rvInfo = new ReturnValueInfo();
            //保存新纪录或修改记录
            if (this._EditOpt == DefineConstantValue.EditStateEnum.OE_Insert)
            {
                searchInfo.csm_cRecordID = Guid.NewGuid();
                searchInfo.csm_cAdd = this.UserInformation.usm_cUserLoginID;
                rvInfo = classBL.Save(searchInfo, DefineConstantValue.EditStateEnum.OE_Insert);
            }
            else if (this._EditOpt == DefineConstantValue.EditStateEnum.OE_Update)
            {
                rvInfo = classBL.Save(searchInfo, DefineConstantValue.EditStateEnum.OE_Update);
            }

            if (!rvInfo.isError && rvInfo.boolValue)
            {
                ShowInformationMessage("保存成功。");
                this.Close();
            }
            else
            {
                ShowErrorMessage("保存失败。" + rvInfo.messageText);
            }
        }

        private void sysToolBar_OnItemRefresh_Click(object sender, EventArgs e)
        {
            BindComboData();

            labClassID.Text = this._CurrentClassInfo.csm_cRecordID.ToString();
            cbxGradeName.SelectItemForValue(this._CurrentClassInfo.csm_cGDMID.ToString());
            cbxClassName.SelectItemForValue(this._CurrentClassInfo.csm_cClassNum);
            cbxHeadTeacher.SelectItemForValue(this._CurrentClassInfo.csm_cMasterID.ToString());
            tbxRemarks.Text = this._CurrentClassInfo.csm_cRemark;
        }
    }
}
