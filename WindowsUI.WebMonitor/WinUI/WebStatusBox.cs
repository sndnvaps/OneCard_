using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WindowsUI.WebMonitor.Model;

namespace WindowsUI.WebMonitor.WinUI
{
    public partial class WebStatusBox : UserControl
    {
        private Image Red = global::WindowsUI.WebMonitor.Properties.Resources.webstatus_r;
        private Image Yellow = global::WindowsUI.WebMonitor.Properties.Resources.webstatus_y;
        private Image Green = global::WindowsUI.WebMonitor.Properties.Resources.webstatus_g;
        private Image OutLine = global::WindowsUI.WebMonitor.Properties.Resources.webstatus_o;

        /// <summary>
        /// 设备对象
        /// </summary>
        private MonitorBox minfo;
        public MonitorBox Info
        {
            get
            {
                return minfo;
            }
            set
            {
                this.minfo = value;
                ShowInfo();
            }
        }

        public WebStatusBox()
        {
            InitializeComponent();
        }

        private void ShowInfo()
        {
            if (Info != null)
            {
                this.lblNo.Text = Info.Number.ToString();
                this.lblName.Text = Info.Name;
                this.lblTimes.Text = Info.DelayTimes.ToString()+"ms";
                this.lblIP.Text = Info.IP;

                if (Info.DelayTimes < 0)
                {
                    this.ptbStatus.Image = OutLine;

                    //如果离线，将控件的字颜色改成红色
                    for (int index = 0; index < this.Controls.Count;index++ )
                    {
                        this.Controls[index].ForeColor = Color.Red;
                    }
                }
                else
                {
                    if(this.Controls[0].ForeColor == Color.Red)
                    {
                        for (int index = 0; index < this.Controls.Count;index++ )
                        {
                            this.Controls[index].ForeColor = Color.Black;
                        }
                    }

                    if (Info.DelayTimes >= 0 && Info.DelayTimes <= 250)
                    {
                        this.ptbStatus.Image = Green;
                    }
                    else if (Info.DelayTimes > 250 && Info.DelayTimes <= 500)
                    {
                        this.ptbStatus.Image = Yellow;
                    }
                    else if (Info.DelayTimes > 500)
                    {
                        this.ptbStatus.Image = Red;
                    }
                }
            }
        }

        public string FormatName(string name)
        {
            string returnStr = "";

            if (name.Length > 6)
            {
                for (int index = 0; index < name.Length; index = index + 6)
                {
                    int strLeng = 6;
                    if (name.Length - index < 6)
                    {
                        strLeng = name.Length - index;
                    }

                    returnStr += name.Substring(index, strLeng);
                    returnStr += "\r\n";
                }
            }
            else
            {
                returnStr = name;
            }

            return returnStr;
        }
    }
}
