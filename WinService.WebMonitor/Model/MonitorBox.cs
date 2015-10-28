using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WinService.WebMonitor.Model
{
    public class MonitorBox
    {
        public int Index { get; set; }
        /// <summary>
        /// 唯一标识
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 编号
        /// </summary>
        public string Number { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// IP地址
        /// </summary>
        public string IP { get; set; }
        /// <summary>
        /// 延时
        /// </summary>
        public int DelayTimes { get; set; }
        /// <summary>
        /// 是否在线
        /// </summary>
        public bool IsOnline { get; set; }

        /// <summary>
        /// 上一次发信息时间
        /// </summary>
        public DateTime LastSetTime { get; set; }

        /// <summary>
        /// 离线时间
        /// </summary>
        public DateTime? OutLineTime { get; set; }
    }
}
