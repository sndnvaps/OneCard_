using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WinService.WebMonitor.Model;
using System.Net.Mail;
using System.Configuration;
using ServiceManage.SendEmail;
//using ServiceManage.SendEmail;

namespace WinService.WebMonitor.Public
{
    /// <summary>
    /// 邮件类
    /// </summary>
    public class MailOperate// : AbstractSendEmail
    {
        ResultInfo resultInfo = new ResultInfo();

        //private SendDelayMessage.wsMsgSending _MsgDelaySender;

        string ServiceAddress;
        string User;
        string Password;

        AbstractSendEmail _asbe;

        public MailOperate()
        {
            this.ServiceAddress = "smtp.126.com";
            this.User = "leotest@126.com";
            this.Password = "leotest123";

            try
            {
                //this._MsgDelaySender = new SendDelayMessage.wsMsgSending();
               // this._MsgDelaySender.Url = ConfigurationSettings.AppSettings["MsgDelaySenderWebService"];

                _asbe = SendEmailFactory.GetSendSendEmail(ServiceAddress, User, Password);
            }
            catch (Exception ex)
            {

            }
        }

        public ResultInfo Send(string to, string cc, string subject, string body)
        {
            if (!CheckMail(this.User))
            {
                resultInfo.messageText = "发件人不能为空！";
            }
            else
            {
                if (CheckIsMail(this.User))
                {
                    if (to == "")
                    {
                        resultInfo.messageText = "收件人不能为空！";
                    }
                    else
                    {
                        if (CheckIsMail(to))
                        {
                            System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage(this.User, to, subject, body);
                            if (cc != "")
                            {
                                if (CheckIsMail(cc))
                                {
                                    message.CC.Add(cc);
                                }
                            }

                            SendMail(message);
                        }
                    }
                }
            }

            return resultInfo;
        }

        public ResultInfo Send(List<string> to, List<string> cc, string subject, string body)
        {
            if (!CheckMail(this.User))
            {
                resultInfo.messageText = "发件人不能为空！";
            }
            else
            {
                if (CheckIsMail(this.User))
                {
                    if (to.Count <= 0)
                    {
                        resultInfo.messageText = "收件人不能为空！";
                    }
                    else
                    {
                        System.Net.Mail.MailMessage message = new MailMessage();
                        if (CheckIsMail(to[0]))
                        {
                            _asbe.Send(this.User, to[0], subject, body);

                            //message = new System.Net.Mail.MailMessage(this.User, to[0], subject, body);
                            //for (int i = 1; i < to.Count; i++)
                            //{
                            //    if (CheckIsMail(to[i]))
                            //    {
                            //        message.To.Add(to[i]);
                            //    }
                            //}
                            //if (cc.Count > 0)
                            //{
                            //    foreach (string item in cc)
                            //    {
                            //        if (CheckIsMail(item))
                            //        {
                            //            message.CC.Add(item);
                            //        }
                            //    }
                            //}

                           // SendMail(message);
                        }
                    }
                }
            }

            return resultInfo;
        }

        private ResultInfo SendMail(System.Net.Mail.MailMessage message)
        {
            if (this.ServiceAddress == "")
            {
                resultInfo.messageText = "smtp地址不能为空！";
                //return;
            }
            else
            {
                message.BodyEncoding = System.Text.Encoding.UTF8;
                message.IsBodyHtml = true;

                try
                {
                    SmtpClient client = new SmtpClient(ServiceAddress);
                    client.UseDefaultCredentials = true;
                    client.Credentials = new System.Net.NetworkCredential(User, Password);
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;

                    client.Send(message);

                    resultInfo.boolValue = true;
                }
                catch (Exception ex)
                {
                    resultInfo.isError = true;
                    resultInfo.messageText = ex.ToString();
                }
            }

            return resultInfo;
        }

        /// <summary>
        /// 检查邮箱格式
        /// </summary>
        /// <param name="mail"></param>
        /// <returns></returns>
        private bool CheckIsMail(string mail)
        {
            string regexEmail = "\\w{1,}@\\w{1,}\\.\\w{1,}";

            System.Text.RegularExpressions.RegexOptions options = ((System.Text.RegularExpressions.RegexOptions.IgnorePatternWhitespace

                | System.Text.RegularExpressions.RegexOptions.Multiline)

                        | System.Text.RegularExpressions.RegexOptions.IgnoreCase);

            System.Text.RegularExpressions.Regex regEmail = new System.Text.RegularExpressions.Regex(regexEmail, options);

            string email = mail;

            if (regEmail.IsMatch(email))
            {
                return true;
            }
            else
            {
                resultInfo.messageText = "邮箱填写有误！";
                return false;
            }
        }

        /// <summary>
        /// 检查邮箱是否空
        /// </summary>
        /// <param name="mail"></param>
        /// <returns></returns>
        private bool CheckMail(string mail)
        {
            if (mail == "")
                return false;
            else
                return true;
        }

        public ResultInfo SendDelayEmail(List<string> listRecAddr, string strTitle, string strMsg, string strServName)
        {
            ResultInfo rvInfo = new ResultInfo();
            try
            {
                if (listRecAddr == null)
                {
                    rvInfo.isError = true;
                    rvInfo.messageText = "Params Invalid : data list is null";
                    return rvInfo;
                }
                if (listRecAddr.Count == 0)
                {
                    rvInfo.isError = true;
                    rvInfo.messageText = "Params Invalid : data list is empty";
                    return rvInfo;
                }

               // rvInfo.boolValue = this._MsgDelaySender.SendBatchEmail(listRecAddr.ToArray(), strTitle, strMsg, strServName);

            }
            catch (Exception ex)
            {
                rvInfo.messageText = ex.Message;
                rvInfo.isError = true;
            }
            return rvInfo;
        }

        public ResultInfo SendDelayEmail(string strAddr, string strTitle, string strMsg, string strServName)
        {
            List<string> listUserAddr = new List<string>();
            listUserAddr.Add(strAddr);
            return SendDelayEmail(listUserAddr, strTitle, strMsg, strServName);
        }
    }
}
