using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using WinService.WebMonitor.Public;
using System.Configuration;
using System.Threading;

namespace WinService.BackupFileManage
{
    partial class FileManage : ServiceBase
    {
        private System.Timers.Timer _CopyTir;
        private System.Timers.Timer _DeleteTir;

        public FileManage()
        {
            InitializeComponent();

            _CopyTir = new System.Timers.Timer();
            _CopyTir.Interval = 3000;
            _CopyTir.Elapsed += new System.Timers.ElapsedEventHandler(tirCopyFile_Tick);

            _DeleteTir = new System.Timers.Timer();
            _DeleteTir.Interval = 3000;
            _DeleteTir.Elapsed += new System.Timers.ElapsedEventHandler(tirDeleteTir_Tick);
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                SetLog("启动文件复制功能");
                _CopyTir.Start();

                SetLog("启动文件删除功能");
                _DeleteTir.Start();
            }
            catch (Exception e)
            {
                SetLog(e.ToString());
            }
        }

        protected override void OnStop()
        {
            try
            {
                SetLog("停止文件复制功能");
                _CopyTir.Stop();
                SetLog("停止文件删除功能");
                _DeleteTir.Stop();
            }
            catch (Exception e)
            {
                SetLog(e.ToString());
            }
            
        }

        private void tirCopyFile_Tick(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                BackupFile bf = new BackupFile();

                string isCopy = ConfigurationSettings.AppSettings["IsCopy"];

                string SourcePath = ConfigurationSettings.AppSettings["CopySourcePath"];
                string TargetPath = ConfigurationSettings.AppSettings["CopyTargetPath"];

                string copyTime = ConfigurationSettings.AppSettings["CopyTimes"];


                DateTime nowTime = System.DateTime.Now;

                if (!String.IsNullOrEmpty(copyTime) & isCopy.Equals("1"))
                {
                    string[] copyTimes = copyTime.Split(';');

                    if(copyTimes.Length > 0)
                    {
                        string thisTime = "";

                        for (int index = 0; index < copyTimes.Length;index ++ )
                        {
                            thisTime = System.DateTime.Now.ToString("yyy/MM/dd ")+copyTimes[index]+":00";

                            try
                            {
                                DateTime dt = DateTime.Parse(thisTime);

                                System.TimeSpan ts = nowTime.Subtract(dt);
                                double count = ts.TotalMinutes;

                                if (count > 0 & count < 30)
                                {
                                    bf.CheckFileCopy(SourcePath, TargetPath);
                                }
                            }
                            catch
                            {

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                SetLog(ex.ToString());
            }
        }

        private void tirDeleteTir_Tick(object sender, System.Timers.ElapsedEventArgs e)
        {
            Thread.Sleep(5000);
            try
            {
                string isDelete = ConfigurationSettings.AppSettings["IsDelete"];
                string TargetPath = ConfigurationSettings.AppSettings["DeleteTargetPath"];
                string deleteTime = ConfigurationSettings.AppSettings["DeleteTimes"];

                if (!String.IsNullOrEmpty(deleteTime) & isDelete.Equals("1"))
                {
                    string[] copyTimes = deleteTime.Split(';');
                    DateTime nowTime = System.DateTime.Now;

                    for(int index = 0; index < copyTimes.Length; index ++)
                    {
                        string thisTime = ""; 
                        thisTime = System.DateTime.Now.ToString("yyy/MM/dd ")+copyTimes[index]+":00";

                        try
                        {
                            DateTime dt = DateTime.Parse(thisTime);
                            System.TimeSpan ts = nowTime.Subtract(dt);
                            double count = ts.TotalMinutes;

                            if (count > 0 & count < 30)
                            {
                                DeleteFile df = new DeleteFile();
                                df.CheckDeleteFile(TargetPath);
                            }
                        }
                        catch
                        {

                        }
                        
                    }
                }

            }
            catch
            {

            }
        }

        /// <summary>
        /// Log信息
        /// </summary>
        /// <param name="message"></param>
        private void SetLog(string message)
        {
            string time = System.DateTime.Now.ToString("[dd/MM/yyyy HH:mm:ss]:");

            message = time + message;

            LogOperate.WirteLog(message);
        }

    }
}
