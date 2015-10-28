using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WinService.WebMonitor.Model;
using System.Configuration;

namespace WinService.WebMonitor.Public
{
    public class MessageOperate
    {
        /// <summary>
        /// 短信网关发送帐户
        /// </summary>
        public static string _userID = "hsyz";

        /// <summary>
        /// 短信网关发送帐户密码
        /// </summary>
        public static string _passWord = "sms~%$8a0t";

        public static ResultInfo SendSMS(string toPhone, string messageText)
        {
            ResultInfo returnInfo = new ResultInfo();

            try
            {
                //_userID = ConfigurationSettings.AppSettings["SendMessageUserID"].Trim();
                //_passWord = ConfigurationSettings.AppSettings["SendMessagePassWord"].Trim();
            }
            catch (Exception Ex)
            {
                returnInfo.boolValue = false;
                returnInfo.messageText = Ex.Message;

                return returnInfo;
            }

            if (toPhone.Trim() == "")
            {
                returnInfo.boolValue = false;
                returnInfo.messageText = "不存在接收的电话号码！";
                return returnInfo;
            }

            //SendMessage.hsyzSoapClient hsc = new WinService.WebMonitor.SendMessage.hsyzSoapClient();
            //String s = hsc.SendSms(_userID, _passWord, toPhone, messageText);

            //AbstractSendMessage sendMessage = SendMessageFactory.GetSendMessage(_userID, _passWord);

            //ResultInfo resultInfo = null;
            //resultInfo = sendMessage.SendMessageText(toPhone, messageText);


            ServiceManage.SendMessage.AbstractSendMessage msg = ServiceManage.SendMessage.SendMessageFactory.GetSendMessage(_userID, _passWord);
            ServiceManage.ResultInfo resultInfo = msg.SendMessageText(toPhone, messageText);

            //if (resultInfo != null)
            //{
            //    returnInfo.boolValue = resultInfo.boolValue;
            //    returnInfo.isError = resultInfo.isError;
            //    returnInfo.messageText = resultInfo.messageText;
            //    returnInfo.ValueObject = resultInfo.ValueObject;
            //}

            return returnInfo;
        }
    }
}
