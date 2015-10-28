using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PaymentEquipment.Entity
{
    /// <summary>
    /// 消费记录
    /// </summary>
    public class PosRecord
    {
        public int RecordIndex { get; set; }
        public string CardNo { get; set; }
        public decimal Balance { get; set; }
        public decimal Consume { get; set; }
        public DateTime RecordTime { get; set; }
    }
}
