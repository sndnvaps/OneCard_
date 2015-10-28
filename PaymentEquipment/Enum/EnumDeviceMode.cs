using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PaymentEquipment.Enum
{
    /// <summary>
    /// 消费机工作模式
    /// </summary>
    public enum EnumDeviceMode
    {
        /// <summary>
        /// 未确定
        /// </summary>
        Unknown = -1,
        /// <summary>
        /// 普通消费模式
        /// </summary>
        CustomMoney = 0,
        /// <summary>
        /// 定值消费模式
        /// </summary>
        FixedMoney = 1
    }
}
