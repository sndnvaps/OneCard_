using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.ComponentModel;

namespace Common
{
    public class BasePrinter
    {

        /// <summary>
        /// 设置默认打印机
        /// </summary>
        /// <param name="printerName">打印机名</param>
        /// <returns></returns>
        public static bool SetPrinter(string printerName)
        {
            return SetDefaultPrinter(printerName);
        }

        /// <summary>
        /// 获取默认打印机名
        /// </summary>
        /// <returns></returns>
        public static string GetPrinterName()
        {
            return GetDefaultPrinter();
        }


        [DllImport("Winspool.drv", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool SetDefaultPrinter(string printerName);
        [DllImport("winspool.drv", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool GetDefaultPrinter(StringBuilder pszBuffer, ref int pcchBuffer);
        private static string GetDefaultPrinter()
        {
            const int ERROR_FILE_NOT_FOUND = 2;
            const int ERROR_INSUFFICIENT_BUFFER = 122;
            int pcchBuffer = 0;
            if (GetDefaultPrinter(null, ref pcchBuffer))
            { return null; }
            int lastWin32Error = Marshal.GetLastWin32Error();
            if (lastWin32Error == ERROR_INSUFFICIENT_BUFFER)
            {
                StringBuilder pszBuffer = new StringBuilder(pcchBuffer);
                if (GetDefaultPrinter(pszBuffer, ref pcchBuffer))
                {
                    return pszBuffer.ToString();
                }
                lastWin32Error = Marshal.GetLastWin32Error();
            }
            if (lastWin32Error == ERROR_FILE_NOT_FOUND)
            { return null; }
            throw new Win32Exception(Marshal.GetLastWin32Error());
        }

    }
}
