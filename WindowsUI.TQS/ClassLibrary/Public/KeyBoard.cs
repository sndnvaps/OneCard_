using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Configuration;
using System.Diagnostics;
using System.Threading;

namespace WindowsUI.TQS.ClassLibrary.Public
{
    public class KeyBoard
    {
        private const string CLASSNAME = "WindowsForms10.Window.8.app.0.378734a";
        private const string WINDOWNAME = "鍵盤Keyboard";
        private static Process m_KeyBoardProcess = null;

        public static void OpenKeyBoard()
        {
            try
            {
                int result = FindWindow(CLASSNAME, WINDOWNAME);
                if (result == 0)
                {
                    string path = @"keyboard\ScreenKeyboard.exe";
                    try
                    {
                        path = ConfigurationManager.AppSettings["KeyBoardSetupPath"].ToString();
                    }
                    catch (Exception ex)
                    {
                        //TraceLog.Instance.Error("WinApi.cs", "加载配置文件<KeyBoardSetupPath>错误", ex, "OpenKeyBoard");
                    }
                    path = AppDomain.CurrentDomain.BaseDirectory + "\\" + path;
                    m_KeyBoardProcess = Process.Start(path);
                    Thread.Sleep(500);
                    result = FindWindow(CLASSNAME, WINDOWNAME);
                }
                if (result > 0)
                {

                    IntPtr intptr = new IntPtr(result);
                    //WinApi.SetWindowPos(intptr, -1, 0, 0, 726, 295,4000);
                    SetWindowPos(intptr, -1, 0, 0, 0, 0, 2000);
                    ShowWindow(intptr, 1);
                }

            }
            catch
            {
                throw;
            }
        }

        public static void CloseKeyBoard()
        {
            try
            {
                int result = FindWindow(CLASSNAME, WINDOWNAME);
                if (result > 0)
                {
                    IntPtr intptr = new IntPtr(result);

                    ShowWindow(intptr, 0);
                }
                //IntPtr intptr = new IntPtr(result);
                //CloseWindow(intptr);
            }
            catch (Exception ex)
            {

            }
        }

        [DllImport("user32.dll", EntryPoint = "FindWindow")]
        public static extern int FindWindow(
            string lpClassName,
            string lpWindowName
        );

        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        public static extern bool SetWindowPos(IntPtr hWnd, int hWndlnsertAfter, int X, int Y, int cx, int cy, int Flags);

        [DllImport("user32.dll", EntryPoint = "ShowWindow")]
        public static extern bool ShowWindow(
            IntPtr hwnd,
            int nCmdShow
        );

        [DllImport("user32.dll", EntryPoint = "CloseWindow")]
        public static extern bool CloseWindow(
            IntPtr hwnd
        );
    }
}
