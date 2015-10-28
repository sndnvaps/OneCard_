using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Model.TestModel;
using Model.HHZX;
using BLL.IBLL.HHZX;
using BLL.Factory.HHZX;
using BLL.IBLL.HHZX.UserInfomation.CardUserInfo;
using Model.HHZX.UserInfomation.CardUserInfo;
using BLL.IBLL.General;
using BLL.Factory.General;
using Model.IModel;
using Common;
using Model.General;

namespace WindowUI.HHZX.UserInformation.CardUserInfo
{
    public partial class frmDepartmentMasterDetail : BaseForm
    {
        private DepartmentMaster_dpm_Info _CurrentDptInfo;
        private IDepartmentMasterBL _IDepartmentMasterBL;

        public frmDepartmentMasterDetail()
        {
            InitializeComponent();

            this._CurrentDptInfo = null;
            _IDepartmentMasterBL = MasterBLLFactory.GetBLL<IDepartmentMasterBL>(MasterBLLFactory.DepartmentMaster);
        }

        public void ShowForm(DepartmentMaster_dpm_Info editInfo, Common.DefineConstantValue.EditStateEnum editStatc)
        {
            this._CurrentDptInfo = editInfo;

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
                this.dpm_RecordID = string.Empty;
                this.dpm_cName = string.Empty;
                this.dpm_cRemark = string.Empty;
                this.dpm_cAdd = string.Empty;
                this.dpm_dAddDate = string.Empty;
                this.dpm_cLast = string.Empty;
                this.dpm_dLastDate = string.Empty;
            }

            public UserInputData(DepartmentMaster_dpm_Info showInfo)
            {
                this.dpm_RecordID = showInfo.dpm_RecordID.ToString();
                this.dpm_cName = showInfo.dpm_cName;
                this.dpm_cRemark = showInfo.dpm_cRemark;
                this.dpm_cAdd = showInfo.dpm_cAdd;
                this.dpm_dAddDate = showInfo.dpm_dAddDate.ToString("yyyy/MM/dd HH:mm:ss");
                this.dpm_cLast = showInfo.dpm_cLast;
                this.dpm_dLastDate = showInfo.dpm_dLastDate.ToString("yyyy/MM/dd HH:mm:ss");
            }

            [ReadOnly(true), Category("部门信息"), DisplayName("部门ID")]
            public string dpm_RecordID { get; set; }

            [Category("部门信息"), DisplayName("部门名称")]
            public string dpm_cName { get; set; }

            [Category("部门信息"), DisplayName("备注")]
            public string dpm_cRemark { get; set; }

            [ReadOnly(true), Category("部门信息"), DisplayName("新增人")]
            public string dpm_cAdd { get; set; }

            [ReadOnly(true), Category("部门信息"), DisplayName("新增时间")]
            public string dpm_dAddDate { get; set; }

            [ReadOnly(true), Category("部门信息"), DisplayName("最后修改人")]
            public string dpm_cLast { get; set; }

            [ReadOnly(true), Category("部门信息"), DisplayName("最后修改时间")]
            public string dpm_dLastDate { get; set; }
        }

        private void frmDepartmentMasterDetail_Load(object sender, EventArgs e)
        {
            //if (_editInfo == null)
            //{
            //    _editInfo = this.BaseParam as testModel;
            //}

            if (this.EditState == Common.DefineConstantValue.EditStateEnum.OE_Insert)
            {
                this.Text = "新增 - " + this.Text;

                UserInputData insertInfo = new UserInputData();

                proUserData.SelectedObject = insertInfo;
            }
            else if (this.EditState == Common.DefineConstantValue.EditStateEnum.OE_Update)
            {
                this.Text = "修改 - " + this.Text;

                UserInputData showData = new UserInputData(_CurrentDptInfo);

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
            UserInputData obj = (UserInputData)proUserData.SelectedObject;
            if (obj != null)
            {
                ReturnValueInfo rvInfo = new ReturnValueInfo();

                DepartmentMaster_dpm_Info info = GetDataInfo(obj);

                if(String.IsNullOrEmpty(info.dpm_cName))
                {
                    MessageBox.Show("请输入名称。","提示");
                    return;
                }

                string strOptName = string.Empty;
                if (this.EditState == Common.DefineConstantValue.EditStateEnum.OE_Insert)
                {
                    rvInfo = _IDepartmentMasterBL.Save(info, DefineConstantValue.EditStateEnum.OE_Insert);
                    strOptName = "新增";
                }
                else if (this.EditState == Common.DefineConstantValue.EditStateEnum.OE_Update)
                {
                    rvInfo = _IDepartmentMasterBL.Save(info, DefineConstantValue.EditStateEnum.OE_Update);
                    strOptName = "更新";
                }

                if (rvInfo.boolValue && !rvInfo.isError)
                {
                    this.ShowInformationMessage(strOptName + "成功。");
                    this.Close();
                }
                else
                {
                    this.ShowErrorMessage(strOptName + "失败。" + rvInfo.messageText);
                }
            }
        }

        private void sysToolBar_OnItemExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private DepartmentMaster_dpm_Info GetDataInfo(UserInputData info)
        {
            DepartmentMaster_dpm_Info dpmInfo = new DepartmentMaster_dpm_Info();
            dpmInfo.dpm_cName = info.dpm_cName;
            dpmInfo.dpm_cRemark = info.dpm_cRemark;
            dpmInfo.dpm_lEnable = true;
            dpmInfo.dpm_cLast = UserInformation.usm_cUserLoginID;
            dpmInfo.dpm_dLastDate = System.DateTime.Now;
            if (this.EditState == Common.DefineConstantValue.EditStateEnum.OE_Insert)
            {
                dpmInfo.dpm_cAdd = this.UserInformation.usm_cUserLoginID;
                dpmInfo.dpm_dAddDate = System.DateTime.Now;

            }
            else if (this.EditState == Common.DefineConstantValue.EditStateEnum.OE_Update)
            {
                dpmInfo.dpm_RecordID = new Guid(info.dpm_RecordID);
                dpmInfo.dpm_cAdd = info.dpm_cAdd;
                dpmInfo.dpm_dAddDate = DateTime.Parse(info.dpm_dAddDate);
            }

            return dpmInfo;
        }
    }
}
