using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Model.HHZX.ComsumeAccount;
using BLL.IBLL.HHZX.ConsumeAccount;
using BLL.Factory.HHZX;
using Model.General;

namespace WindowUI.HHZX.UserCard
{
    public partial class frmResetOverdraft : BaseForm
    {
        public frmResetOverdraft()
        {
            InitializeComponent();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (ShowQuestionMessage("是否确认修改学生账户可透支额？" + Environment.NewLine + "修改过程需时几分钟，期间不能进行其他操作！"))
            {
                decimal fOverdraft = Convert.ToDecimal(nbxOverdraft.Text);
                if (!ShowQuestionMessage("准备修改的学生账户可透支额为：" + fOverdraft.ToString() + "，是否确认继续？"))
                {
                    return;
                }
                this.Cursor = Cursors.WaitCursor;
                try
                {
                    RechargeRecord_rcr_Info rechrage = new RechargeRecord_rcr_Info();
                    rechrage.rcr_fRechargeMoney = fOverdraft;
                    rechrage.rcr_cAdd = this.UserInformation.usm_cUserLoginID;
                    rechrage.rcr_cLast = this.UserInformation.usm_cUserLoginID;
                    ICardUserAccountBL accountBL = MasterBLLFactory.GetBLL<ICardUserAccountBL>(MasterBLLFactory.CardUserAccount);
                    ReturnValueInfo rvInfo = accountBL.ResetAccountOverdraft(rechrage);
                    this.Cursor = Cursors.Default;
                    if (rvInfo.boolValue && !rvInfo.isError)
                    {
                        ShowInformationMessage("修改成功，学生账户当前可透支额为：" + nbxOverdraft.Text);
                    }
                    else
                    {
                        ShowInformationMessage("修改失败。" + rvInfo.messageText);
                    }
                }
                catch (Exception ex)
                {
                    ShowErrorMessage(ex);
                    this.Cursor = Cursors.Default;
                }
            }
        }
    }
}
