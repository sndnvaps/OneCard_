using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Model.IModel;
using Model.SysMaster;
using BLL.IBLL.SysMaster;
using Model.General;
using WindowUI.HHZX.ClassLibrary.Public;

namespace WindowUI.HHZX.ConsumerDevice
{
    public partial class frmRecordCollectSet : BaseForm
    {
        private CodeMaster_cmt_Info _cmtInfo;
        private Common.DefineConstantValue.EditStateEnum _editState;
        private ICodeMasterBL _icmBL;

        public frmRecordCollectSet()
        {
            InitializeComponent();
            _icmBL = BLL.Factory.SysMaster.MasterBLLFactory.GetBLL<ICodeMasterBL>(BLL.Factory.SysMaster.MasterBLLFactory.CodeMaster_cmt);
            _editState = Common.DefineConstantValue.EditStateEnum.OE_Insert;
            BindMealTypeCombo();
            this.lblTitle.Text = "添加消费数据收集时间";
        }

        public frmRecordCollectSet(CodeMaster_cmt_Info infoObj)
        {
            InitializeComponent();
            _icmBL = BLL.Factory.SysMaster.MasterBLLFactory.GetBLL<ICodeMasterBL>(BLL.Factory.SysMaster.MasterBLLFactory.CodeMaster_cmt);
            _editState = Common.DefineConstantValue.EditStateEnum.OE_Update;
            this._cmtInfo = infoObj;
            BindMealTypeCombo();
            SetControlValue();
            this.lblTitle.Text = "修改消费数据收集时间";
        }

        /// <summary>
        /// 绑定用餐时间类型
        /// </summary>
        void BindMealTypeCombo()
        {
            List<IModelObject> listValues = new List<IModelObject>();
            foreach (Common.DefineConstantValue.MealType item in Enum.GetValues(typeof(Common.DefineConstantValue.MealType)))
            {
                if (item != Common.DefineConstantValue.MealType.UnKnown)
                {
                    ComboboxDataInfo value = new ComboboxDataInfo();
                    value.ValueMember = item.ToString();
                    value.DisplayMember = Common.DefineConstantValue.GetMealTypeDesc(item);
                    listValues.Add(value);
                }
            }

            cbbMealType.SetDataSource(listValues);
            cbbMealType.SelectedIndex = -1;
        }

        private void SetControlValue()
        {
            if (_cmtInfo != null)
            {
                this.txtName.Text = _cmtInfo.cmt_cRemark2;
                this.dtpStartTime.Text = _cmtInfo.cmt_cRemark;
                this.cbbMealType.SelectItemForValue(_cmtInfo.cmt_cValue);

                if (_cmtInfo.cmt_fNumber > 0)
                {
                    this.ckbEnable.Checked = true;
                }
                else
                {
                    this.ckbEnable.Checked = false;
                }
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否确认保存?", "提示", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }
            else
            {
                if (cbbMealType.SelectedIndex < 0)
                {
                    this.ShowWarningMessage("请选择时间类型。");
                    cbbMealType.Focus();
                    return;
                }

                if (_cmtInfo == null)
                {
                    _cmtInfo = new CodeMaster_cmt_Info();
                    _cmtInfo.cmt_cAdd = this.UserInformation.usm_cUserLoginID;
                    _cmtInfo.cmt_dAddDate = System.DateTime.Now;
                    _cmtInfo.cmt_cKey1 = Common.DefineConstantValue.CodeMasterDefine.KEY1_RecordCollectInterval.ToString();
                    _cmtInfo.cmt_cKey2 = Guid.NewGuid().ToString().Substring(0, 30);
                }

                _cmtInfo.cmt_cLast = this.UserInformation.usm_cUserLoginID;
                _cmtInfo.cmt_dLastDate = System.DateTime.Now;

                if (String.IsNullOrEmpty(this.txtName.Text.Trim()))
                {
                    base.ShowErrorMessage("请输入时段名称。");
                    return;
                }
                _cmtInfo.cmt_cRemark2 = this.txtName.Text.Trim();

                //if (this.dtpStartTime.Value > this.dtpEndTime.Value)
                //{
                //    base.ShowErrorMessage("开始时间要少于结束时间。");
                //    return;
                //}

                _cmtInfo.cmt_cRemark = this.dtpStartTime.Value.ToString("HH:mm");
                _cmtInfo.cmt_cValue = cbbMealType.SelectedValue.ToString();

                if (this.ckbEnable.Checked)
                {
                    _cmtInfo.cmt_fNumber = 1;
                }
                else
                {
                    _cmtInfo.cmt_fNumber = 0;
                }

                ReturnValueInfo returnInfo = _icmBL.Save(_cmtInfo, _editState);

                if (returnInfo.isError)
                {
                    base.ShowErrorMessage("保存失败！");
                }
                else
                {
                    MessageBox.Show("保存成功。", "提示");
                    this.Close();
                }
            }
        }
    }
}
