using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Windows.Forms;

namespace WindowsUI.TQS
{
    /// <summary>
    /// 运行参数
    /// </summary>
    public class GlobalVar
    {
        /// <summary>
        /// 是否自动关闭用户打开窗口
        /// </summary>
        public static bool AutoClose = true;


        private static List<Form> _openFormList;
        public static List<Form> OpenFormList
        {
            get
            {
                if (_openFormList == null)
                {
                    _openFormList = new List<Form>();
                }

                return _openFormList;
            }
            set
            {
                _openFormList = value;
            }
        }
    }
}
