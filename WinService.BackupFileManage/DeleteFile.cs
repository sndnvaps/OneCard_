using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Configuration;
using WinService.WebMonitor.Public;

namespace WinService.BackupFileManage
{
    public class DeleteFile
    {
        public bool CheckDeleteFile(string source)
        {
            try
            {
                DateTime nowTime = System.DateTime.Now;

                int DayLong = 0;

                try
                {
                    DayLong = Int32.Parse(ConfigurationSettings.AppSettings["DeleteTimeLong"]);
                }
                catch (Exception ex)//如果獲取刪除日數失敗，則取默認值60
                {
                    DayLong = 150;
                    SetLog("获取文件存在期限配置时发生异常，现使用150天为存在上限。ex:" + ex.ToString());
                }

                string[] sourceFiles = Directory.GetFiles(source);
                if(sourceFiles != null && sourceFiles.Length > 0)
                {
                    for (int index = 0; index < sourceFiles.Length;index ++ )
                    {
                        FileInfo file = new FileInfo(sourceFiles[index]);
                        if(file.Exists)
                        {
                            DateTime lastTime = file.LastAccessTime;
                            System.TimeSpan ts = nowTime.Subtract(lastTime);
                            double count = ts.TotalDays;

                            if(count >= DayLong)
                            {
                                SetLog("检查到需要删除的文件，" + sourceFiles[index] + "。文件最后修改时间："+lastTime.ToString("yyyy/MM/dd HH:mm:ss"));
                                SetLog("开始删除文件");
                                file.Delete();
                                SetLog("已删除文件，" + sourceFiles[index].Substring(sourceFiles[index].LastIndexOf('\\'), sourceFiles[index].Length - sourceFiles[index].LastIndexOf('\\')));
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                SetLog("运行文件检查时发生异常："+ex.ToString());
                return false;
            }
            return true;
        }

        /// <summary>
        /// Log信息
        /// </summary>
        /// <param name="message"></param>
        private void SetLog(string message)
        {
            string time = System.DateTime.Now.ToString("[dd/MM/yyyy HH:mm:ss]D:");

            message = time + message;

            LogOperate.WirteLog(message);
        }
    }
}
