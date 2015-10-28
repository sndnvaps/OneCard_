using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowUI.HHZX.UserCard.Refund
{
    public partial class frmRefundToCard : BaseForm
    {
        public frmRefundToCard()
        {
            InitializeComponent();
        }

        private void btnRefundRealtime_Click(object sender, EventArgs e)
        {
            frmRefundRealTimeDetail frmReal = new frmRefundRealTimeDetail();
            frmReal.UserInformation = this.UserInformation;
            frmReal.ShowDialog();
            this.Close();
        }

        private void btnReFundOffline_Click(object sender, EventArgs e)
        {
            frmReFundOfflineFirst frmOff = new frmReFundOfflineFirst();
            frmOff.UserInformation = this.UserInformation;
            frmOff.ShowDialog();
            this.Close();
        }
    }
}
