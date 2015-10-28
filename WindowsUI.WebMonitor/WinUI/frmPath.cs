using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsUI.WebMonitor.WinUI
{
    public partial class frmPath : Form
    {
        public string FileName
        {
            get;
            set;
        }

        public frmPath()
        {
            InitializeComponent();
            this.lblPath.Text = "";
        }

        private void btnPath_Click(object sender, EventArgs e)
        {
            this.ofdPath.ShowDialog();
            FileName = this.ofdPath.FileName;
            this.lblPath.Text = this.ofdPath.FileName;
        }
    }
}
