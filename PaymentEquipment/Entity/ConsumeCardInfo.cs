using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PaymentEquipment.Entity
{
    /// <summary>
    /// 消费卡信息
    /// </summary>
    public class ConsumeCardInfo
    {
        /// <summary>
        /// 卡原始ID
        /// </summary>
        public string CardSourceID { get; set; }
        /// <summary>
        /// 卡号
        /// </summary>
        public string CardNo { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 卡余额
        /// </summary>
        public decimal CardBalance { get; set; }
        /// <summary>
        /// 消费次数
        /// </summary>
        public int ConsumeTimes { get; set; }
        /// <summary>
        /// 消费密码
        /// </summary>
        public string CardPwd { get; set; }
    }
}
