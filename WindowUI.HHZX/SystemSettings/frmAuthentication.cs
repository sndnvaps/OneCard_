using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UKey;

namespace WindowUI.HHZX.SystemSettings
{
    public partial class frmAuthentication : BaseForm
    {
        AbstractUKey _UKey;
        bool _IsLogined;

        public frmAuthentication()
        {
            InitializeComponent();

            this._UKey = UKeyFactory.GetUKey();
        }

        private void btnSearchUDog_Click(object sender, EventArgs e)
        {
            UKey.Entity.ReturnValueInfo rvInfo = this._UKey.FindUKeyFirst();
            if (rvInfo.IsSuccess)
            {
                labUDogMsg.Text = "已找到U盾。";
                labUDogMsg.BackColor = Color.Green;
                labUDogMsg.ForeColor = Color.Black;

                plnCode.Enabled = true;
                pnlPayPwd.Enabled = true;
                this._IsLogined = true;
            }
            else
            {
                labUDogMsg.Text = "未找到U盾。";
                labUDogMsg.BackColor = Color.Red;
                labUDogMsg.ForeColor = Color.White;

                plnCode.Enabled = false;
                pnlPayPwd.Enabled = false;
                this._IsLogined = false;
            }
        }

        private void btnReadUKeyCode_Click(object sender, EventArgs e)
        {
            if (this._UKey != null && this._IsLogined)
            {
                string strCode = this._UKey.UKeyCode;
                labCode.Text = strCode;
            }
            else
            {
                labUDogMsg.Text = "U盾登录失败";
                btnSearch.Focus();
            }
        }

        private void btnWritePayPwd_Click(object sender, EventArgs e)
        {
            if (this._UKey != null && this._IsLogined)
            {
                string strPwd = tbxPayPwd.Text.Trim();
                string strConfirmPwd = tbxConfirmPayPwd.Text.Trim();
                if (strPwd.Length != 12)
                {
                    this.ShowWarningMessage("消费密码需要为12位的16进制整数，请重新输入。");
                    tbxPayPwd.SelectAll();
                    tbxPayPwd.Focus();
                    return;
                }
                try
                {
                    Convert.ToInt64(strPwd, 16);
                }
                catch (Exception ex)
                {
                    this.ShowWarningMessage("消费密码只能为十六进制整数，请重新输入。");
                    tbxPayPwd.SelectAll();
                    tbxPayPwd.Focus();
                    return;
                }
                if (strPwd != strConfirmPwd)
                {
                    this.ShowWarningMessage("消费密码前后不一致，请重新输入。");
                    tbxPayPwd.SelectAll();
                    tbxPayPwd.Focus();
                    return;
                }

                UKey.Entity.ReturnValueInfo rvInfo = this._UKey.WritePaymentPassword(strPwd);
                if (rvInfo.IsSuccess)
                {
                    this.ShowInformationMessage("设置消费密码成功。");
                    tbxPayPwd.Text = string.Empty;
                    tbxConfirmPayPwd.Text = string.Empty;
                    return;
                }
                else
                {
                    this.ShowInformationMessage("设置消费密码失败。" + rvInfo.MessageText);
                    tbxPayPwd.SelectAll();
                    tbxPayPwd.Focus();
                    return;
                }
            }
            else
            {
                labUDogMsg.Text = "U盾登录失败";
                btnSearch.Focus();
                return;
            }
        }
    }
}
