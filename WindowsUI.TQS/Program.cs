﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using WindowsUI.TQS.UserCard;

namespace WindowsUI.TQS
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。

        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new frmUserAccountDetail());
           // Application.Run(new frmCardInfo());
           // Application.Run(new frmPaymentUDMeal());
            Application.Run(new MainForm());
        }
    }
}
