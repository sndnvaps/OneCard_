using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL.IBLL.SysMaster;
using BLL.Factory.SysMaster;
using Model.SysMaster;
using Model.General;

namespace WindowUI.HHZX.SystemSettings
{
    /// <summary>
    /// 系统固定费用设置
    /// </summary>
    public partial class dlgConstantExpensesSetting : BaseForm
    {
        /// <summary>
        /// 费用子键键名
        /// </summary>
        public string SubKeyName { get; set; }

        /// <summary>
        /// 修改后的费用
        /// </summary>
        public decimal NewValue { get; set; }

        private ICodeMasterBL _ICodeMasterBL;

        private int _CurrentCodeIndex;

        public dlgConstantExpensesSetting()
        {
            InitializeComponent();

            this._ICodeMasterBL = MasterBLLFactory.GetBLL<ICodeMasterBL>(MasterBLLFactory.CodeMaster_cmt);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (string.IsNullOrEmpty(SubKeyName))
            {
                this.ShowErrorMessage("费用类型不能为空。");
                return;
            }

            CodeMaster_cmt_Info searchCode = new CodeMaster_cmt_Info();
            searchCode.cmt_cKey1 = Common.DefineConstantValue.CodeMasterDefine.KEY1_ConstantExpenses.ToString();
            searchCode.cmt_cKey2 = this.SubKeyName;

            CodeMaster_cmt_Info codeInfo = this._ICodeMasterBL.SearchRecords(searchCode).FirstOrDefault() as CodeMaster_cmt_Info;
            if (codeInfo == null)
            {
                this.ShowErrorMessage("未能找到可以设置的费用类型。");
                return;
            }

            this._CurrentCodeIndex = codeInfo.cmt_iRecordID;
            gbxName.Text = codeInfo.cmt_cRemark;
            labOldCost.Text = codeInfo.cmt_fNumber.ToString();
            ntbxNewCost.Enabled = true;
        }

        private void ntbxNewCost_TextChanged(object sender, EventArgs e)
        {
            if (ntbxNewCost.Enabled && !string.IsNullOrEmpty(ntbxNewCost.Text))
            {
                try
                {
                    decimal dCost = Convert.ToDecimal(ntbxNewCost.Text);
                    btnSave.Enabled = true;
                }
                catch (Exception ex)
                {
                    btnSave.Enabled = false;
                    return;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                FormDialogResult(DialogResult.No);

                decimal dCost = Convert.ToDecimal(ntbxNewCost.Text);

                CodeMaster_cmt_Info codeInfo = this._ICodeMasterBL.DisplayRecord(new CodeMaster_cmt_Info() { cmt_iRecordID = this._CurrentCodeIndex }) as CodeMaster_cmt_Info;
                if (codeInfo != null)
                {
                    codeInfo.cmt_fNumber = dCost;
                    ReturnValueInfo rvInfo = this._ICodeMasterBL.Save(codeInfo, Common.DefineConstantValue.EditStateEnum.OE_Update);
                    if (rvInfo.boolValue && !rvInfo.isError)
                    {
                        this.ShowInformationMessage("设置成功。");
                        NewValue = dCost;
                        FormDialogResult(DialogResult.OK);
                        this.Close();
                        return;
                    }
                    else
                    {
                        this.ShowWarningMessage("设置失败。" + rvInfo.messageText);
                        return;
                    }
                }
                else
                {
                    this.ShowErrorMessage("寻找当前费用设置信息失败。");
                    return;
                }
            }
            catch (Exception ex)
            {
                this.ShowErrorMessage(ex);
                return;
            }
        }

        private void FormDialogResult(DialogResult diaType)
        {
            this.DialogResult = diaType;
        }

        private void dlgConstantExpensesSetting_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (btnSave.Enabled)
                {
                    btnSave_Click(btnSave, null);
                }
            }
            else if (e.KeyCode == Keys.Escape)
            {
                if (btnSave.Enabled)
                {
                    bool res = this.ShowQuestionMessage("结果没有保存，确认需要离开？");
                    if (res)
                    {
                        this.Close();
                    }
                }
                else
                {
                    this.Close();
                }
            }
        }
    }
}
