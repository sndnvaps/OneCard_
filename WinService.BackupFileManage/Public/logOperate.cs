using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;
using System.Configuration;

namespace WinService.WebMonitor.Public
{
    public class LogOperate
    {
        /// <summary>
        /// 写log信息
        /// </summary>
        /// <param name="message"></param>
        public static void WirteLog(string message)
        {
            string stmp = "";

            string logPath = ConfigurationSettings.AppSettings["LogsPath"];
            if (String.IsNullOrEmpty(logPath))
            {
                stmp = Assembly.GetExecutingAssembly().Location;
                stmp = stmp.Substring(0, stmp.LastIndexOf('\\'));//删除文件名
            }
            else
            {
                stmp = logPath;
            }
            
            stmp += @"\Log";
            if (!Directory.Exists(stmp))//如果不存在就创建file文件夹
            {
                //Directory.Delete(stmp, true);//true代表删除文件夹及其里面的子目录和文件
                Directory.CreateDirectory(stmp);//创建该文件夹
            }

            string tody = System.DateTime.Now.ToString("yyyyMMdd");

            stmp += @"\" + tody + ".txt";

            if (!File.Exists(stmp))
            {
                StreamWriter text;
                text = File.CreateText(stmp);
                text.Close();
            }
            File.AppendAllText(stmp, message + "\r\n", Encoding.GetEncoding("UTF-8"));
        }
    }
}
