using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.NetworkInformation;

namespace WindowsUI.TQS.SystemForm
{
    public partial class WebStatusBox : UserControl
    {
        public Control OutWebForm
        {
            get;
            set;
        }

        /// <summary>
        /// 檢查網絡的IP地址
        /// </summary>
        public string IPAddress { get; set; }

        /// <summary>
        /// 超時時間（秒）
        /// </summary>
        public int OutTime { get; set; }

        /// <summary>
        /// 設置網絡正常時顯示圖標
        /// </summary>
        public Image Green
        {
            get;
            set;
        }
        /// <summary>
        /// 設置網絡較差時顯示圖標
        /// </summary>
        public Image Red
        {
            get;
            set;
        }
        /// <summary>
        /// 設置網絡一般時顯示圖標
        /// </summary>
        public Image Yellow
        {
            get;
            set;
        }
        /// <summary>
        /// 設置網絡離線時顯示圖標
        /// </summary>
        public Image Out
        {
            get;
            set;
        }

        private enum OutWeb
        {
            OnLine,
            OutLine
        }

        public WebStatusBox()
        {
            InitializeComponent();
        }

        private void tirCheckWeb_Tick(object sender, EventArgs e)
        {
            try
            {
                if(IPAddress != null)
                {
                    long times = PingIp(IPAddress);
                    if(times <0){
                        this.ptbStatus.Image = Out;
                        this.lblStatus.Text = "离线";

                        SetOutWebFormStatus(OutWeb.OutLine);
                    }
                    if (times < 200 && times >= 0)
                    {
                        this.ptbStatus.Image = Green;
                        this.lblStatus.Text = "良好";

                        SetOutWebFormStatus(OutWeb.OnLine);
                    }
                    else if(times >= 200 && times < 600)
                    {
                        this.ptbStatus.Image = Yellow;
                        this.lblStatus.Text = "一般";

                        SetOutWebFormStatus(OutWeb.OnLine);
                    }
                    else if(times >=600)
                    {
                        this.ptbStatus.Image = Red;
                        this.lblStatus.Text = "较差";

                        SetOutWebFormStatus(OutWeb.OnLine);
                    }
                }
            }
            catch
            {

            }
        }

        private long PingIp(string ip)
        {
            try
            {
                long time = -1;

                try
                {
                    Ping p = new Ping();
                    PingReply r = p.Send(ip, OutTime * 1000);

                    if (r.Status == IPStatus.Success)
                    {
                        time = r.RoundtripTime;
                    }
                }
                catch (System.Net.WebException)
                {

                }

                return time;
            }
            catch
            {
                return -1;
            }
        }

        private void SetOutWebFormStatus(OutWeb status)
        {
            if (OutWebForm != null)
            {
                switch (status)
                {
                    case OutWeb.OnLine:
                        OutWebForm.Width = 0;
                        OutWebForm.Height = 0;
                        OutWebForm.Location = new Point(0, 0);
                        break;
                    case OutWeb.OutLine:
                        OutWebForm.Width = 1024;
                        OutWebForm.Height = 738;
                        OutWebForm.Location = new Point(0, 0);
                        break;
                }
            }
        }
    }
}
