using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PaymentEquipment.Enum
{
    /// <summary>
    /// IC卡格式
    /// </summary>
    public enum EnumCardFormat
    {
        /// <summary>
        /// 未知卡号格式(可能为空)   
        /// </summary>
        CARDVER_UNKNOWN = 0,
        /// <summary>
        /// ID卡格式 
        /// </summary>
        CARDVER_IDCARD = 1,
        /// <summary>
        /// 依时利标准IC卡格式, 最大6位卡号
        /// </summary>
        CARDVER_STDCARD = 830,
        /// <summary>
        /// //新ER-880C卡格式, 不支持消费, 最大16位卡号
        /// </summary>
        CARDVER_NEWCARD = 880,
        /// <summary>
        /// 新消费机ER-690C卡格式, 最大7位卡号
        /// </summary>
        CARDVER_690CARD = 690
    }
}
