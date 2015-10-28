using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Threading;

namespace WinCA.UserAccountFundSync
{
    class Program
    {
        static Common.General _LocalLogger;

        static void Main(string[] args)
        {
            try
            {
                _LocalLogger = new Common.General(Common.General.BindLocalLogInfo());

                Console.WriteLine(getCWStyle("账户金额同步服务启动", SystemLog.SystemLog.LogType.Trace));
                Console.WriteLine(getCWStyle("开始配置服务", SystemLog.SystemLog.LogType.Trace));
                int iRetryTimes;//服务运行失败后重试最大次数
                string strRetryTimes = ConfigurationSettings.AppSettings["iRetryTimes"];
                bool blnRetryTimes = int.TryParse(strRetryTimes, out  iRetryTimes);
                if (!blnRetryTimes)
                    iRetryTimes = 5;
                else
                    if (iRetryTimes < 1)
                        iRetryTimes = 5;
                Console.WriteLine(getCWStyle("配置【失败重试次数】：" + iRetryTimes.ToString() + "次。", SystemLog.SystemLog.LogType.Trace));

                int iRetryInterval;//服务运行失败后重试的时间间隔
                string strRetryInterval = ConfigurationSettings.AppSettings["iRetryInterval"];
                bool blnRetryInterval = int.TryParse(strRetryInterval, out  iRetryInterval);
                if (!blnRetryInterval)
                    iRetryInterval = 5000;
                else
                    if (iRetryInterval < 1)
                        iRetryInterval = 5000;
                Console.WriteLine(getCWStyle("配置【失败重试每次时间间隔】：" + iRetryInterval.ToString() + "ms。", SystemLog.SystemLog.LogType.Trace));

                UserAccountFundSyncService service = new UserAccountFundSyncService();
                service.LocalLogger = _LocalLogger;
                service.ErrRetryTimes = iRetryTimes;
                service.ErrRetryInterval = iRetryInterval;

                bool blnRes = service.AccountSync();
                if (blnRes)
                    Console.WriteLine(getCWStyle("账户金额同步成功", SystemLog.SystemLog.LogType.Trace));
                else
                {
                    Console.WriteLine(getCWStyle("账户金额同步失败", SystemLog.SystemLog.LogType.Trace));
                    Console.WriteLine(getCWStyle("准备进行失败重试", SystemLog.SystemLog.LogType.Trace));
                }

                int iRetryIdx = 1;
                while (iRetryIdx <= iRetryTimes && !blnRes)
                {
                    Console.WriteLine(getCWStyle("重试第 " + iRetryIdx.ToString() + " 次", SystemLog.SystemLog.LogType.Trace));
                    blnRes = service.AccountSync();
                    if (blnRes)
                        Console.WriteLine(getCWStyle("成功", SystemLog.SystemLog.LogType.Trace));
                    else
                        Console.WriteLine(getCWStyle("失败", SystemLog.SystemLog.LogType.Trace));
                    iRetryIdx++;
                    Thread.Sleep(iRetryInterval);
                }
                Console.WriteLine(getCWStyle("账户金额同步服务完毕", SystemLog.SystemLog.LogType.Trace));
                //Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(getCWStyle(ex.Message, SystemLog.SystemLog.LogType.Error));
            }
        }

        static string getCWStyle(string strContent, SystemLog.SystemLog.LogType logType)
        {
            strContent = "* " + strContent + " " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            _LocalLogger.WriteLog(strContent, string.Empty, logType);
            return strContent;
        }
    }
}
