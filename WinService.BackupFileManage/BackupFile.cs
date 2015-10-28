using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using WinService.BackupFileManage.Public;
using WinService.WebMonitor.Public;

namespace WinService.BackupFileManage
{
    public class BackupFile
    {

        public bool CheckFileCopy(string source, string target)
        {
            try
            {
                string[] sourceFiles = Directory.GetFiles(source);
                //string[] targetFiles = Directory.GetFiles(target);

                if (sourceFiles.Length > 0)
                {
                    for (int index = 0; index < sourceFiles.Length; index++)
                    {
                        //取得在目标文件夹内的文件路径
                        string path = sourceFiles[index];
                        path = path.Substring(path.LastIndexOf('\\'), path.Length - path.LastIndexOf('\\'));
                        path = target + path;

                        if (!File.Exists(path))//如果目标文件夹内无此文件则复制
                        {
                            SetLog("检查到需要复制的文件：" + path);
                            SetLog("开始复制");
                            FileControl.CopyFile(sourceFiles[index], path);
                            SetLog("复制完成");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                SetLog("运行文件检查时，发现异常：" + ex.ToString());
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
            string time = System.DateTime.Now.ToString("[dd/MM/yyyy HH:mm:ss]C:");

            message = time + message;

            LogOperate.WirteLog(message);
        }
    }
}
