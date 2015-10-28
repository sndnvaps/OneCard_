using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace WinService.BackupFileManage.Public
{
    public class FileControl
    {
        /// <summary>
        /// 创建文件
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool CreateFile(string path)
        {
            bool ret = false;
            FileInfo file = new FileInfo(path);
            try
            {
                if (!file.Exists)
                {
                    file.Create();
                    ret = true;
                }
            }
            catch
            {
                throw;
            }
            return ret;
        }

        /// <summary>
        /// 刪除文件
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool DeleteFile(string path)
        {
            bool ret = false;
            FileInfo file = new FileInfo(path);
            try
            {
                if (file.Exists)
                {
                    file.Delete();
                    ret = true;
                }
            }
            catch
            {
                throw;
            }
            return ret;
        }

        /// <summary>
        /// 複製文件
        /// </summary>
        /// <param name="source">源路徑</param>
        /// <param name="destination">目標路徑</param>
        /// <returns></returns>
        public static bool CopyFile(string source, string destination)
        {
            bool ret = false;
            FileInfo file_s = new FileInfo(source);
            FileInfo file_d = new FileInfo(destination);
            try
            {
                if (file_s.Exists)
                {
                    if (!file_d.Exists)
                    {
                        file_s.CopyTo(destination);
                        ret = true;
                    }
                }
            }
            catch
            {
                throw;
            }
            return ret;
        }

        /// <summary>
        /// 剪切文件
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        /// <returns></returns>
        public static bool CutFile(string source, string destination)
        {
            bool ret = false;
            FileInfo file_s = new FileInfo(source);
            FileInfo file_d = new FileInfo(destination);
            try
            {
                if (file_s.Exists)
                {
                    if (!file_d.Exists)
                    {
                        file_s.MoveTo(destination);
                        ret = true;
                    }

                }
            }
            catch
            {
                throw;
            }
            return ret;
        }

        /// <summary>
        /// 創建文件夾
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool CreateFolder(string path)
        {
            bool ret = false;
            try
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
            }
            catch
            {
                throw;
            }
            return ret;
        }

        /// <summary>
        /// 刪除文件夾
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private static bool DeleteFolder(string path)
        {
            bool ret = false;

            try
            {
                if (Directory.Exists(path))
                {
                    Directory.Delete(path, true);
                }
            }
            catch
            {
                throw;
            }
            return ret;
        }
    }
}
