using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowUI.HHZX.UserCard.Recharge
{
    public partial class frmCardRecharge : BaseForm
    {
        public frmCardRecharge()
        {
            InitializeComponent();
        }

        private void btnRechargeRealtime_Click(object sender, EventArgs e)
        {
            frmRechargeRealTimeDetail dlgDetail = new frmRechargeRealTimeDetail();
            dlgDetail.UserInformation = this.UserInformation;
            dlgDetail.ShowDialog();
            //this.Close();
        }

        private void btnRechargeOffline_Click(object sender, EventArgs e)
        {
            frmRechargeOfflineFirst dlgDetail = new frmRechargeOfflineFirst();
            dlgDetail.UserInformation = this.UserInformation;
            dlgDetail.ShowDialog();
            //this.Close();
        }

        private void frmCardRecharge_SizeChanged(object sender, EventArgs e)
        {
            int iFormWidth = this.Width;
            int iFormHeight = this.Height;
            int iGbxWidth = gbxMain.Width;
            int iGbxHeight = gbxMain.Height;
            gbxMain.Location = new Point((iFormWidth - iGbxWidth) / 2, (iFormHeight - iGbxHeight) / 2);
        }
    }
}
