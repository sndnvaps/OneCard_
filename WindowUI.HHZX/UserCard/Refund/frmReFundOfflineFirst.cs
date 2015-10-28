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
    public partial class frmReFundOfflineFirst : BaseForm
    {
        public frmReFundOfflineFirst()
        {
            InitializeComponent();
        }

        private void btnSingleTrans_Click(object sender, EventArgs e)
        {
            frmRefundOfflineSingle dlgSingle = new frmRefundOfflineSingle();
            dlgSingle.UserInformation = this.UserInformation;
            dlgSingle.ShowDialog();
            this.Close();
        }

        private void btnBatchTrans_Click(object sender, EventArgs e)
        {
            frmTransferBatchRefund dlgBatch = new frmTransferBatchRefund();
            dlgBatch.UserInformation = this.UserInformation;
            dlgBatch.ShowDialog();
            this.Close();
        }
    }
}
