using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Common;

namespace WindowControls.HBPMS
{
    public partial class SystemToolBar : UserControl
    {
        public SystemToolBar()
        {
            InitializeComponent();
        }

        public void FormClosing(Form frmSource)
        {
            if (frmSource != null)
            {
                frmSource.Close();
            }
        }

        private void tsBtnExit_Click(object sender, EventArgs e)
        {
            if (OnItemExit_Click != null)
            {
                OnItemExit_Click(sender, e);
            }
            else
            {
                if (this.ShowQuestionMessage(Common.DefineConstantValue.SystemMessageText.strMessageText_Q_ExitWinForm))
                {

                    this.Parent.Dispose();
                }
            }
        }

        private void tsBtnNew_Click(object sender, EventArgs e)
        {
            if (OnItemNew_Click != null)
            {
                OnItemNew_Click(sender, e);
            }
        }

        private void tsBtnModify_Click(object sender, EventArgs e)
        {
            if (OnItemModify_Click != null)
            {
                OnItemModify_Click(sender, e);
            }
        }

        private void tsBtnSave_Click(object sender, EventArgs e)
        {
            if (OnItemSave_Click != null)
            {
                OnItemSave_Click(sender, e);
            }
        }

        private void tsBtnDelete_Click(object sender, EventArgs e)
        {
            if (OnItemDelete_Click != null)
            {
                OnItemDelete_Click(sender, e);
            }
        }

        private void tsBtnDetail_Click(object sender, EventArgs e)
        {
            if (OnItemDetail_Click != null)
            {
                OnItemDetail_Click(sender, e);
            }
        }

        private void tsBtnRefresh_Click(object sender, EventArgs e)
        {
            if (OnItemRefresh_Click != null)
            {
                OnItemRefresh_Click(sender, e);
            }
        }

        /// <summary>
        /// 顯示確認信息
        /// </summary>
        /// <param name="text"></param>
        public bool ShowQuestionMessage(string text)
        {
            bool isYes = false;
            DefineConstantValue.SystemMessage SystemMessageText = new DefineConstantValue.SystemMessage(string.Empty);
            if (MessageBox.Show(text, SystemMessageText.strMessageTitle + SystemMessageText.strQuestion.Trim(), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                isYes = true;
            }

            return isYes;
        }
    }
}
