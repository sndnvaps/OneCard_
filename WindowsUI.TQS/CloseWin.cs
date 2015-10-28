using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Model.General;
using WindowsUI.TQS.ClassLibrary.Public;

namespace WindowsUI.TQS
{
    public partial class CloseWin : Form
    {
        ReturnValueInfo _valueInfo = new ReturnValueInfo();
        public CloseWin()
        {
            InitializeComponent();
        }

        public void ShowForm(ReturnValueInfo valueInfo)
        {
            //KeyBoard.OpenKeyBoard();
            _valueInfo = valueInfo;
            this.ShowDialog();
            tbxPwd.SelectAll();
            tbxPwd.Focus();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (tbxPwd.Text == DateTime.Now.ToString("yyyy,MM,dd"))
            {
                ShowMessage("");
                _valueInfo.boolValue = true;
                CloseForm();
                //this.Close();
            }
            else
            {
                //KeyBoard.CloseKeyBoard();
                //MessageBox.Show("密码错误。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);

                ShowMessage("密码错误。");

                //KeyBoard.OpenKeyBoard();
                tbxPwd.SelectAll();
                tbxPwd.Focus();
            }
        }

        private void CloseWin_KeyDown(object sender, KeyEventArgs e)
        {
            if (!e.Alt && !e.Control)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnExit_Click(null, null);
                }

                if (e.KeyCode == Keys.Escape)
                {
                    CloseForm();
                    //this.Close();
                }
            }
        }

        private void tbxPwd_TextChanged(object sender, EventArgs e)
        {
            TextBox tbxTarget = sender as TextBox;
            if (!string.IsNullOrEmpty(tbxTarget.Text.Trim()))
            {
                btnExit.Enabled = true;
            }
            else
            {
                btnExit.Enabled = false;
            }
        }

        private void CloseForm()
        {
            //KeyBoard.CloseKeyBoard();
            this.Close();
        }

        private void ShowMessage(String message)
        {
            lblPassWord.Text = message;
        }
    }
}
