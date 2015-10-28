using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WindowsUI.WebMonitor.WinUI;
using WindowsUI.WebMonitor.Public;
using WindowsUI.WebMonitor.Model;
using System.Net.NetworkInformation;
using System.Threading;
using WindowsUI.WebMonitor.IPList;

namespace WindowsUI.WebMonitor
{
    public partial class MainForm : Form
    {
        private List<MonitorBox> _mbList;
        private List<MonitorBox> _outLineList;
        // private List<WebStatusBox> _wsbList;

        private bool _isStart;

        public MainForm()
        {
            InitializeComponent();
            initList();
        }

        private enum FormStatus
        {
            Start,
            Stop
        }

        private void StartMonitor()
        {
            SetControlStatus(FormStatus.Start);

            try
            {
                SetMessage("\n\r****************启用监听******************", Color.Black);

                initList();

                SetMessage("共监听" + _mbList.Count + "台机器", Color.Black);

                this._isStart = true;


                this.bgwCheckWeb.RunWorkerAsync();
                this.bgwCheckOutLint.RunWorkerAsync();

                SetMessage("正在监听", Color.Black);
            }
            catch
            {
                SetMessage("启动失败", Color.Red);
                SetControlStatus(FormStatus.Stop);
            }


        }

        private void SetControlStatus(FormStatus status)
        {
            switch (status)
            {
                case FormStatus.Start:
                    //关闭编辑功能
                    this.mspMenu.Items[1].Enabled = false;
                    this.btnStart.Enabled = false;
                    this.btnStop.Enabled = true;

                    this.lblSysStatus.Text = "已运行";
                    this.lblSysStatus.ForeColor = Color.Blue;

                    this.rtbMessage.Text = "";

                    this.lblStartTime.Text = System.DateTime.Now.ToString("yyyy/MM/dd HH:mm");

                    break;
                case FormStatus.Stop:
                    this.mspMenu.Items[1].Enabled = true;
                    this.btnStart.Enabled = true;
                    this.btnStop.Enabled = false;

                    this.lblSysStatus.Text = "已停止";
                    this.lblSysStatus.ForeColor = Color.Red;

                    break;
            }
        }

        private void initList()
        {
            WindowsUI.WebMonitor.Public.XMLOperate xml = new WindowsUI.WebMonitor.Public.XMLOperate();
            _outLineList = new List<MonitorBox>();
            _mbList = xml.GetMonitorList();
            if (_mbList != null)
            {
                _mbList = _mbList.OrderBy(x => x.Number).ToList();
            }

            this.lvwIPList.Items.Clear();

            for (int index = 0; index < _mbList.Count; index++)
            {
                ListViewItem item = new ListViewItem();

                item.SubItems.Add("");
                item.SubItems.Add("");
                item.SubItems.Add("");
                item.SubItems.Add("");

                item.SubItems[0].Text = _mbList[index].Name;
                item.SubItems[1].Text = _mbList[index].Number;
                item.SubItems[2].Text = _mbList[index].IP;
                item.SubItems[3].Text = "0ms";

                item.ForeColor = Color.Blue;

                this.lvwIPList.Items.Add(item);

                //_wsbList.Add(wsb);
            }

            this.lblTotle.Text = _mbList.Count.ToString();
        }

        /// <summary>
        /// ping IP,返回延時，-1為不通
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        private long PingIp(string ip)
        {
            try
            {
                long time = -1;
                int outTime = 3000;

                try
                {
                    Ping p = new Ping();
                    PingReply r = p.Send(ip, outTime);

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

        private void tsmiIPList_Click(object sender, EventArgs e)
        {
            frmIPOperate fio = new frmIPOperate();
            fio.ShowDialog();

            initList();
        }

        private void bgwCheckWeb_DoWork(object sender, DoWorkEventArgs e)
        {
            while (_isStart)
            {
                try
                {
                    if (_mbList != null)
                    {
                        for (int index = 0; index < _mbList.Count; index++)
                        {
                            long times = PingIp(_mbList[index].IP);

                            _mbList[index].DelayTimes = Int32.Parse(times.ToString());

                            this.bgwCheckWeb.ReportProgress(index, _mbList[index]);
                        }
                    }

                }
                catch
                {

                }

                Thread.Sleep(1000);
            }
        }

        private void bgwCheckWeb_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            try
            {
                int index = e.ProgressPercentage;
                MonitorBox mbInfo = e.UserState as MonitorBox;

                if (mbInfo != null)
                {
                    this.lvwIPList.Items[mbInfo.Index - 1].SubItems[3].Text = mbInfo.DelayTimes + "ms";

                    if (mbInfo.DelayTimes < 0)
                    {
                        this.lvwIPList.Items[mbInfo.Index - 1].ForeColor = Color.Red;

                        this._mbList.Remove(mbInfo);
                        this._outLineList.Add(mbInfo);

                        SetMessage(mbInfo.Name + ",机号：" + mbInfo.Number + ",IP:" + mbInfo.IP + " 离线。", Color.Red);
                    }
                    else
                    {
                        this.lvwIPList.Items[mbInfo.Index - 1].ForeColor = Color.Blue;


                    }
                }

                this.lblOnLine.Text = this._mbList.Count.ToString();
            }
            catch
            {

            }
        }

        private void tirCheckLine_Tick(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 顯示信息
        /// </summary>
        /// <param name="message"></param>
        private void SetMessage(string message, Color color)
        {
            string time = System.DateTime.Now.ToString("[dd/MM/yyyy HH:mm:ss]:");

            message = time + message;

            WindowsUI.WebMonitor.Public.LogOperate.WirteLog(message);

            int startIndex = rtbMessage.TextLength;
            this.rtbMessage.AppendText(message + "\n");
            int strLong = message.Length;
            rtbMessage.Select(startIndex, strLong);
            rtbMessage.SelectionColor = color;

            string meStr = this.rtbMessage.Text;
            string[] longStr = meStr.Split('\n');

            //显示最多条数
            int maxRow = 300;

            if (longStr.Length > maxRow)
            {
                int startLong = 0;
                for (int index = 0; index < longStr.Length - maxRow; index++)
                {
                    startLong += longStr[index].Length;
                }

                meStr = meStr.Substring(startLong, meStr.Length - startLong);
                this.rtbMessage.Text = meStr;
            }

            this.rtbMessage.Focus();
            this.rtbMessage.Select(this.rtbMessage.TextLength, 0);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            //MessageOperate.SendSMS("13760507671", "214");

            //MailOperate mp =new MailOperate();
            //mp.Send("Xiaofengmak@leothlink.com","","a","b");

            StartMonitor();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            this._isStart = false;

            this.bgwCheckWeb.CancelAsync();
            this.bgwCheckOutLint.CancelAsync();

            SetMessage("正在停止", Color.Blue);

            tirCheckClose.Enabled = true;

        }

        /// <summary>
        /// 检查离线IP
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgwCheckOutLint_DoWork(object sender, DoWorkEventArgs e)
        {
            while (_isStart)
            {
                try
                {
                    if (this._outLineList != null)
                    {
                        for (int index = 0; index < this._outLineList.Count; index++)
                        {
                            long times = PingIp(this._outLineList[index].IP);
                            _outLineList[index].DelayTimes = Int32.Parse(times.ToString());

                            this.bgwCheckOutLint.ReportProgress(index, _outLineList[index]);
                        }
                    }
                }
                catch
                {

                }

                Thread.Sleep(1000);
            }
        }

        private void bgwCheckOutLint_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            try
            {
                int index = e.ProgressPercentage;
                MonitorBox mbInfo = e.UserState as MonitorBox;

                if (mbInfo != null)
                {
                    this.lvwIPList.Items[mbInfo.Index - 1].SubItems[3].Text = mbInfo.DelayTimes + "ms";
                    if (mbInfo.DelayTimes >= 0)
                    {
                        this.lvwIPList.Items[mbInfo.Index - 1].ForeColor = Color.Blue;

                        this._outLineList.Remove(mbInfo);
                        this._mbList.Add(mbInfo);

                        SetMessage(mbInfo.Name + ",机号：" + mbInfo.Number + ",IP:" + mbInfo.IP + " 已重新连接。", Color.Blue);
                    }
                }

                this.lblOutLine.Text = this._outLineList.Count.ToString();
            }
            catch
            {

            }
        }

        /// <summary>
        /// 检查监听线程是否关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tirCheckClose_Tick(object sender, EventArgs e)
        {
            if (!this.bgwCheckWeb.IsBusy && !this.bgwCheckOutLint.IsBusy)
            {
                tirCheckClose.Enabled = false;

                SetMessage("\n\r\n\r****************已停止监听******************", Color.Blue);

                SetControlStatus(FormStatus.Stop);
            }
        }

        private void tsmiExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tirSetMail_Tick(object sender, EventArgs e)
        {

        }

        private void tsmiPath_Click(object sender, EventArgs e)
        {
            frmPath fp = new frmPath();
            fp.ShowDialog();


        }

        private void menuItemOpen_Click(object sender, EventArgs e)
        {
            if (this.Visible == false)
            {
                this.Visible = true;
                menuItemHide.Enabled = true;
                menuItemOpen.Enabled = false;
            }
        }

        private void menuItemHide_Click(object sender, EventArgs e)
        {
            this.Hide();
            menuItemOpen.Enabled = true;
            menuItemHide.Enabled = false;
        }

        private void menuItemExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否确定需要关闭程序？", "提醒", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                btnStop_Click(null, null);
                this.Close();
            }
        }
    }
}
