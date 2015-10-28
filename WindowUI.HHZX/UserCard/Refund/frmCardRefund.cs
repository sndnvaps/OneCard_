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
    public partial class frmCardRefund : BaseForm
    {
        public frmCardRefund()
        {
            InitializeComponent();
        }

        private void btnRefundCash_Click(object sender, EventArgs e)
        {
            frmRefundCash dlgDetail = new frmRefundCash();
            dlgDetail.UserInformation = this.UserInformation;
            dlgDetail.ShowDialog();
            this.Close();
        }

        private void btnRefundToCard_Click(object sender, EventArgs e)
        {
            frmRefundToCard dlgDetail = new frmRefundToCard();
            dlgDetail.UserInformation = this.UserInformation;
            dlgDetail.ShowDialog();
            this.Close();
        }
    }
}
