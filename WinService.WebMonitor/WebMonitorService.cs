using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using WinService.WebMonitor.Public;
using WinService.WebMonitor.Model;
using System.Net.NetworkInformation;
using System.Configuration;
using System.Threading;

namespace WinService.WebMonitor
{
    public partial class WebMonitorService : ServiceBase
    {
        private List<MonitorBox> _mbList;
        private List<MonitorBox> _outLineList;

        private MailOperate _mailOperate;
        private MessageOperate _messageOperate;


        private System.Timers.Timer _OnlineTir;
        private System.Timers.Timer _OutlineTir;
        private System.Timers.Timer _SetMailTir;

        /// <summary>
        /// 短信邮件发送间隔，分钟
        /// </summary>
        private int _IntervalTime = 60;

        public WebMonitorService()
        {

            // _mailOperate = new MailOperate();
            // _messageOperate = new MessageOperate();

            _OnlineTir = new System.Timers.Timer();
            _OnlineTir.Interval = 3000;
            _OnlineTir.Elapsed += new System.Timers.ElapsedEventHandler(tirCheckOnline_Tick);

            _OutlineTir = new System.Timers.Timer();
            _OutlineTir.Interval = 3000;
            _OutlineTir.Elapsed += new System.Timers.ElapsedEventHandler(tirCheckOutLine_Tick);

            _SetMailTir = new System.Timers.Timer();
            _SetMailTir.Interval = 3000;
            _SetMailTir.Elapsed += new System.Timers.ElapsedEventHandler(tirSetMail_Tick);

        }

        protected override void OnStart(string[] args)
        {
            Thread.Sleep(5000);
            try
            {
                if (_mailOperate == null)
                {
                    _mailOperate = new MailOperate();
                }

                //if (_messageOperate == null)
                //{
                //    _messageOperate = new MessageOperate();
                //}

                SetMessage("\n\r****************启用监听******************");
                //SetMessage(ConfigurationSettings.AppSettings["SMSTitle"]);
                _OnlineTir.Start();
                _OutlineTir.Start();
                _SetMailTir.Start();

                SetMessage("正在监听");


            }
            catch
            {

            }

        }

        protected override void OnStop()
        {

            _OnlineTir.Stop();
            _OutlineTir.Stop();
            _SetMailTir.Stop();

            SetMessage("\n\r\n\r****************已停止监听******************");

        }

        private void initList()
        {
            try
            {
                XMLOperate xml = new XMLOperate();
                _outLineList = new List<MonitorBox>();
                _mbList = xml.GetMonitorList();
            }
            catch (Exception ex)
            {
                SetMessage(ex.ToString());
            }

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
                int outTime = 30000;

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
            catch (Exception e)
            {
                SetMessage("Ping錯：" + e.ToString());
                return -1;
            }
        }

        /// <summary>
        /// 监听IP
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tirCheckOnline_Tick(object sender, System.Timers.ElapsedEventArgs e)
        {
            Thread.Sleep(10000);
            try
            {
                if (_mbList == null)
                {
                    initList();
                    SetMessage("共监听" + _mbList.Count + "台机器");
                }

                if (_mbList != null && _mbList.Count > 0)
                {
                    //tirCheckOnline.Enabled = false;

                    for (int index = 0; index < _mbList.Count; index++)
                    {
                        MonitorBox info = _mbList[index];

                        long times = PingIp(info.IP);

                        info.DelayTimes = Int32.Parse(times.ToString());

                        if (times < 0)//如果IP离线，移到离线表中
                        {
                            //if (info.OutLineTime != null)
                            //{
                                info.OutLineTime = System.DateTime.Now;
                            //}

                            _outLineList.Add(info);
                            _mbList.Remove(info);

                            SetMessage(info.Name + ",机号：" + info.Number + ",IP:" + info.IP + " 离线。");
                        }
                        else
                        {

                        }
                    }

                    //tirCheckOnline.Enabled = true;
                }
            }
            catch
            {

            }
        }

        /// <summary>
        /// 检查离线IP
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tirCheckOutLine_Tick(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                if (_outLineList != null && _outLineList.Count > 0)
                {
                    //this.tirCheckOutLine.Enabled = false;

                    for (int index = 0; index < _outLineList.Count; index++)
                    {
                        MonitorBox info = _outLineList[index];

                        long times = PingIp(info.IP);

                        info.DelayTimes = Int32.Parse(times.ToString());

                        if (times >= 0)
                        {
                            info.OutLineTime = null;

                            _mbList.Add(info);
                            _outLineList.Remove(info);

                            SetMessage(info.Name + ",机号：" + info.Number + ",IP:" + info.IP + " 已重新连接。");
                        }
                    }

                    //this.tirCheckOutLine.Enabled = true;
                }
            }
            catch
            {

            }
        }


        /// <summary>
        /// 顯示信息
        /// </summary>
        /// <param name="message"></param>
        private void SetMessage(string message)
        {
            string time = System.DateTime.Now.ToString("[dd/MM/yyyy HH:mm:ss]:");

            message = time + message;

            LogOperate.WirteLog(message);
        }

        private void tirSetMail_Tick(object sender, System.Timers.ElapsedEventArgs e)
        {
            Thread.Sleep(5000);
            try
            {
                if (_outLineList != null)
                {
                    DateTime NowTime = System.DateTime.Now;

                    string mailStr = "";
                    string messageStr = "";

                    bool isSet = false;//是否需要发送
                    for (int index = 0; index < _outLineList.Count; index++)
                    {
                        if (_outLineList[index].OutLineTime != null)
                        {
                            System.TimeSpan outts = NowTime.Subtract((DateTime)_outLineList[index].OutLineTime);
                            double count = outts.TotalSeconds;
                            if (count < 30)
                            {
                                break;
                            }


                            if (_outLineList[index].LastSetTime == null)
                            {
                                isSet = true;
                            }
                            else
                            {
                                System.TimeSpan ts = NowTime.Subtract(_outLineList[index].LastSetTime);
                                count = ts.TotalMinutes;

                                if (count > _IntervalTime)
                                {
                                    isSet = true;
                                }
                            }

                            if (isSet)
                            {
                                messageStr += _outLineList[index].Name + ",机号：" + _outLineList[index].Number + "，已离线,";
                                mailStr += _outLineList[index].Name + "，" + _outLineList[index].IP + "已离线<br/>";

                                _outLineList[index].LastSetTime = NowTime;
                            }

                            isSet = false;
                        }
                    }



                    if (!String.IsNullOrEmpty(messageStr))
                    {
                        SetSMS(messageStr);
                        SetMessage("發短信");
                    }

                    if (!String.IsNullOrEmpty(mailStr))
                    {
                        SetMail(mailStr);
                    }
                }
            }
            catch
            {

            }
        }

        /// <summary>
        /// 发短信息
        /// </summary>
        /// <param name="message"></param>
        private void SetSMS(string message)
        {
            try
            {
                string ToMessage = ConfigurationSettings.AppSettings["SetMessage"];
                string title = ConfigurationSettings.AppSettings["SMSTitle"];

                if (ToMessage != null)
                {
                    string[] tos = ToMessage.Split(';');

                    for (int index = 0; index < tos.Length; index++)
                    {
                        MessageOperate.SendSMS(tos[index], message + " - " + title);
                        Thread.Sleep(3000);
                    }
                }
            }
            catch
            {

            }
        }
        /// <summary>
        /// 发邮件
        /// </summary>
        /// <param name="message"></param>
        private void SetMail(string message)
        {
            try
            {
                string ToMail = ConfigurationSettings.AppSettings["SetMail"];

                if (ToMail != null)
                {
                    string title = ConfigurationSettings.AppSettings["MailTitle"];

                    string[] tos = ToMail.Split(';');

                    message = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "<br/>" + message;

                    for (int index = 0; index < tos.Length; index++)
                    {
                        _mailOperate.Send(tos[index], "", title, message);
                    }
                }
            }
            catch
            {

            }
        }

        private void InitializeComponent()
        {

        }
    }
}
