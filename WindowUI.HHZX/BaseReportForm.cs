﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace WindowUI.HHZX
{
    public partial class BaseReportForm : BaseForm
    {
        private int _alcf;
        protected override void OnLoad(EventArgs e)
        {
            _alcf = HotKey.GlobalAddAtom("Ctrl-D");
            HotKey.RegisterHotKey(this.Handle, _alcf, HotKey.KeyModifiers.Ctrl, (int)Keys.Enter);
        }
        protected override void WndProc(ref Message m)// 监视Windows消息 
        {
            switch (m.Msg)
            {
                case HotKey.WM_HOTKEY:
                    ProcessHotkey(m);//按下热键时调用ProcessHotkey()函数 
                    break;
            }
            base.WndProc(ref m); //将系统消息传递自父类的WndProc 
        }
        private void ProcessHotkey(Message m) //按下设定的键时调用该函数 
        {
            IntPtr id = m.WParam;//IntPtr用于表示指针或句柄的平台特定类型 
            int sid = id.ToInt32();
            if (sid == _alcf)
            {
                OnItem();
                //MessageBox.Show("aaaa","");
            }
        }



        public delegate void ItemNew();
        /// <summary>
        /// 新增 按鈕點擊
        /// </summary>
        public event ItemNew OnItem;





        class HotKey
        {
            /// <summary> 
            /// 如果函数执行成功，返回值不为0。 
            /// 如果函数执行失败，返回值为0。要得到扩展错误信息，调用GetLastError。.NET方法:Marshal.GetLastWin32Error() 
            /// </summary> 
            /// <param name="hWnd">要定义热键的窗口的句柄</param> 
            /// <param name="id">定义热键ID（不能与其它ID重复） </param> 
            /// <param name="fsModifiers">标识热键是否在按Alt、Ctrl、Shift、Windows等键时才会生效</param> 
            /// <param name="vk">定义热键的内容,WinForm中可以使用Keys枚举转换， 
            /// WPF中Key枚举是不正确的,应该使用System.Windows.Forms.Keys枚举，或者自定义正确的枚举或int常量</param> 
            /// <returns></returns> 
            [DllImport("user32.dll", SetLastError = true)]
            public static extern bool RegisterHotKey(
            IntPtr hWnd,
            int id,
            KeyModifiers fsModifiers,
            int vk
            );
            /// <summary> 
            /// 取消注册热键 
            /// </summary> 
            /// <param name="hWnd">要取消热键的窗口的句柄</param> 
            /// <param name="id">要取消热键的ID</param> 
            /// <returns></returns> 
            [DllImport("user32.dll", SetLastError = true)]
            public static extern bool UnregisterHotKey(
            IntPtr hWnd,
            int id
            );
            /// <summary> 
            /// 向全局原子表添加一个字符串，并返回这个字符串的唯一标识符,成功则返回值为新创建的原子ID,失败返回0 
            /// </summary> 
            /// <param name="lpString"></param> 
            /// <returns></returns> 
            [DllImport("kernel32", SetLastError = true)]
            public static extern short GlobalAddAtom(string lpString);
            [DllImport("kernel32", SetLastError = true)]
            public static extern short GlobalDeleteAtom(short nAtom);
            /// <summary> 
            /// 定义了辅助键的名称（将数字转变为字符以便于记忆，也可去除此枚举而直接使用数值） 
            /// </summary> 
            [Flags()]
            public enum KeyModifiers
            {
                None = 0,
                Alt = 1,
                Ctrl = 2,
                Shift = 4,
                WindowsKey = 8
            }
            /// <summary> 
            /// 热键的对应的消息ID 
            /// </summary> 
            public const int WM_HOTKEY = 0x312;
        }

    }






}

