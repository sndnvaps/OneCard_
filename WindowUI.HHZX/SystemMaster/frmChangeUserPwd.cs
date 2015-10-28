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

namespace WindowUI.HHZX.SystemMaster
{
    public partial class frmChangeUserPwd : BaseForm
    {
        ISysUserMasterBL _ISysUserMasterBL;

        public frmChangeUserPwd()
        {
            InitializeComponent();

            this._ISysUserMasterBL = MasterBLLFactory.GetBLL<ISysUserMasterBL>(MasterBLLFactory.SysUserMaster);
        }

        public void ShowForm(Sys_UserMaster_usm_Info baseInfo)
        {
            this.UserInformation = baseInfo;

            ShowDialog();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            string strNewPwd = tbxNewPwd.Text.Trim();
            if (string.IsNullOrEmpty(strNewPwd))
            {
                labWarningNewPwd.Visible = true;
                return;
            }
            string strNewPwdConfirm = tbxNewPwdConfirm.Text;
            if (string.IsNullOrEmpty(strNewPwdConfirm))
            {
                labWarningNewPwdConfirm.Visible = true;
                return;
            }
            if (strNewPwd != strNewPwdConfirm)
            {
                this.ShowWarningMessage("密码不一致，请重新输入。");
                return;
            }

            if (base.UserInformation == null)
            {
                this.ShowWarningMessage("用户信息异常，请重新登录。");
                return;
            }
            else
            {
                if (string.IsNullOrEmpty(base.UserInformation.usm_cUserLoginID))
                {
                    this.ShowWarningMessage("用戶信息丟失，請重新登錄。");
                    return;
                }
            }

            Sys_UserMaster_usm_Info user = base.UserInformation;
            user.usm_cLast = base.UserInformation.usm_cUserLoginID;
            user.usm_dLastDate = DateTime.Now;
            user.usm_cPwd = strNewPwd;
            ReturnValueInfo res = this._ISysUserMasterBL.Save(user, Common.DefineConstantValue.EditStateEnum.OE_Update);

            if (res.boolValue && !res.isError)
            {
                this.ShowInformationMessage("密码修改成功。");
                this.Dispose();
            }
            else
            {
                this.ShowErrorMessage("密码修改失败，请重试。異常信息:" + res.messageText);
            }
        }

        private void tbxNewPwd_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbxNewPwd.Text.Trim()))
                this.labWarningNewPwd.Visible = true;
            else
                this.labWarningNewPwd.Visible = false;
        }

        private void tbxNewPwdConfirm_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbxNewPwdConfirm.Text.Trim()))
                this.labWarningNewPwdConfirm.Visible = true;
            else
                this.labWarningNewPwdConfirm.Visible = false;
        }
    }
}
