using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PaymentEquipment.Enum
{
    /// <summary>
    /// 枚举类型值转换工具
    /// </summary>
    public class EumExchangeTool
    {
        /// <summary>
        /// 获取消费模式名称
        /// </summary>
        /// <param name="mode"></param>
        /// <returns></returns>
        public static string GetEumModeName(EnumDeviceMode mode)
        {
            string strName = string.Empty;
            switch (mode)
            {
                case EnumDeviceMode.Unknown:
                    strName = "未知模式";
                    break;
                case EnumDeviceMode.CustomMoney:
                    strName = "输入金额模式";
                    break;
                case EnumDeviceMode.FixedMoney:
                    strName = "定值消费模式";
                    break;
                default:
                    strName = "未知模式";
                    break;
            }
            return strName;
        }
    }
}
