using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Model.General;
using WindowsUI.TQS.UserCard;
using WeifenLuo.WinFormsUI.Docking;
using WindowsUI.TQS.ClassLibrary.Public;
using System.Configuration;

namespace WindowsUI.TQS
{
    public partial class MainForm : Form
    {
        private string _UKeyCode = "65595D7A7F7C";
        public string UKeyCode
        {
            get
            {
                return _UKeyCode;
            }
        }

        public MainForm()
        {
            InitializeComponent();
            Common.Util.KeyboardUtil.KeyMaskStart();
            init();
            initUKeyRemote();
            labVersion.Text = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        private void initUKeyRemote()
        {
            string strCode = string.Empty;
            try
            {
                UKeyRemote.ServiceUKeyRemote serv = new WindowsUI.TQS.UKeyRemote.ServiceUKeyRemote();
                string strURL = ConfigurationSettings.AppSettings["WebServUKey"];
                if (!string.IsNullOrEmpty(strURL))
                {
                    serv.Url = strURL;
                }
                strCode = serv.GetUKeyCode("Leoth", "!!!aaa111@@@sss222");
                if (!string.IsNullOrEmpty(strCode))
                {
                    this._UKeyCode = strCode;
                }
            }
            catch (Exception ex)
            { }
        }

        private void init()
        {
            initIP();
        }

        private void initIP()
        {
            string ip = System.Configuration.ConfigurationManager.AppSettings["ServerIP"].ToString();
            this.wsbWebStatus.IPAddress = ip;
            this.wsbWebStatus.OutWebForm = this.outWebForm;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            ReturnValueInfo valueInfo = new ReturnValueInfo();
            valueInfo.boolValue = false;
            CloseWin win = new CloseWin();
            win.Location = new Point(512, 512);
            win.ShowForm(valueInfo);
            if (valueInfo.boolValue)
            {
                this.Close();
            }
        }

        private void imbCardInfo_OnImageClick(object sender, EventArgs e)
        {
            this.mplMain.Show(new frmCardInfo(this._UKeyCode));
        }

        private void imbPaymentUDMeal_OnImageClick(object sender, EventArgs e)
        {
            this.mplMain.Show(new frmPaymentUDMeal(this._UKeyCode));
        }

        private void imbUserAccountDetail_OnImageClick(object sender, EventArgs e)
        {
            this.mplMain.Show(new frmUserAccountDetail(this._UKeyCode));
        }

        private void tirRunTime_Tick(object sender, EventArgs e)
        {
            this.lblTime.Text = System.DateTime.Now.ToString("yyyy年MM月dd日 HH:mm:ss");
        }

        private void imbfrmRechargeDetail_OnImageClick(object sender, EventArgs e)
        {
            this.mplMain.Show(new frmRechargeDetail(this._UKeyCode));
        }

        private void imbRecharge_OnImageClick(object sender, EventArgs e)
        {
            frmCardRecharge frmRec = new frmCardRecharge(this._UKeyCode);
            this.mplMain.Show(frmRec);
        }

        private void MainForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            int a = 0;
        }

        protected override bool ProcessCmdKey(ref       System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                ReturnValueInfo valueInfo = new ReturnValueInfo();
                valueInfo.boolValue = false;
                CloseWin win = new CloseWin();
                win.Location = new Point(512, 512);
                win.ShowForm(valueInfo);
                if (valueInfo.boolValue)
                {
                    this.Close();
                }
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

    }
}
