using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PaymentEquipment.Enum;

namespace PaymentEquipment.Entity
{
    /// <summary>
    /// 消费时段信息
    /// </summary>
    public class ConsumeTimeSpan
    {
        /// <summary>
        /// 开始时段
        /// </summary>
        public TimeSpan BeginTime { get; set; }
        /// <summary>
        /// 结束时段
        /// </summary>
        public TimeSpan EndTime { get; set; }
        /// <summary>
        /// 机器模式
        /// </summary>
        public EnumDeviceMode DeviceMode { get; set; }
        /// <summary>
        /// 时段限次
        /// </summary>
        public int LimitedTimes { get; set; }
        /// <summary>
        /// 定值额
        /// </summary>
        public decimal SetMoney { get; set; }
    }
}
