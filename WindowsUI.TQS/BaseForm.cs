using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WindowsUI.TQS.SystemForm;
using Common;

namespace WindowsUI.TQS
{
    public partial class BaseForm : Form
    {
        private MessageDialog _DialogForm;
        private readonly DefineConstantValue.SystemMessage SystemMessageText;

        public BaseForm()
        {
            InitializeComponent();

            this.SystemMessageText = new DefineConstantValue.SystemMessage(string.Empty);
        }

        /// <summary>
        /// 显示提示框
        /// </summary>
        /// <param name="title"></param>
        /// <param name="message"></param>
        public void MessageDialog(string title, string message)
        {
            try
            {
                if (_DialogForm == null)
                {
                    _DialogForm = new MessageDialog();
                }

                GlobalVar.OpenFormList.Add(_DialogForm);

                _DialogForm.Show(title, message);
            }
            catch
            {

            }
            
        }

        /// <summary>
        /// 显示错误信息
        /// </summary>
        /// <param name="Ex"></param>
        public void ShowErrorMessage(Exception Ex)
        {
            MessageBox.Show(Ex.Message.Trim(), this.SystemMessageText.strMessageTitle + this.SystemMessageText.strSystemError.Trim(), MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// 显示错误信息
        /// </summary>
        /// <param name="Ex"></param>
        public void ShowErrorMessage(string text)
        {
            MessageBox.Show(text.Trim(), this.SystemMessageText.strMessageTitle + this.SystemMessageText.strSystemError.Trim(), MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// 显示提示信息
        /// </summary>
        /// <param name="text"></param>
        public void ShowInformationMessage(string text)
        {
            MessageBox.Show(text, this.SystemMessageText.strMessageTitle + this.SystemMessageText.strInformation.Trim(), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// 显示警告信息
        /// </summary>
        /// <param name="text"></param>
        public void ShowWarningMessage(string text)
        {
            MessageBox.Show(text, this.SystemMessageText.strMessageTitle + this.SystemMessageText.strWarning.Trim(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        /// <summary>
        /// 显示确认信息
        /// </summary>
        /// <param name="text"></param>
        public bool ShowQuestionMessage(string text)
        {
            bool isYes = false;
            if (MessageBox.Show(text, this.SystemMessageText.strMessageTitle + this.SystemMessageText.strQuestion.Trim(), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                isYes = true;
            }

            return isYes;
        }

        /// <summary>
        /// 显示窗口
        /// </summary>
        public virtual void Show()
        {

        }
    }
}
