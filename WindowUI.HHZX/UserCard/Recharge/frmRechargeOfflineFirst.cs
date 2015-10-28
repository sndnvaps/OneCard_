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
    /// <summary>
    /// 选择转账充值方式
    /// </summary>
    public partial class frmRechargeOfflineFirst : BaseForm
    {
        public frmRechargeOfflineFirst()
        {
            InitializeComponent();
        }

        private void btnSingleTrans_Click(object sender, EventArgs e)
        {
            frmRechargeOfflineSingle dlgSingle = new frmRechargeOfflineSingle();
            dlgSingle.UserInformation = this.UserInformation;
            dlgSingle.ShowDialog();
            this.Close();
        }

        private void btnBatchTrans_Click(object sender, EventArgs e)
        {
            frmTransferBatchRecharge dlgBatch = new frmTransferBatchRecharge();
            dlgBatch.UserInformation = this.UserInformation;
            dlgBatch.ShowDialog();
            this.Close();
        }
    }
}
