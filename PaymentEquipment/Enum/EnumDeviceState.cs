using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PaymentEquipment.Enum
{
    /// <summary>
    /// 消费机工作状态
    /// </summary>
    public enum EnumDeviceState
    {
        /// <summary>
        /// 未确定
        /// </summary>
        Unknown = -1,
        /// <summary>
        /// 普通交易状态
        /// </summary>
        Common = 0,
        /// <summary>
        /// 联机交易状态
        /// </summary>
        Online = 1
    }
}
