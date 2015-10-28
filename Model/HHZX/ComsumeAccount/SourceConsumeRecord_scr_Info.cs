using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.IModel;

namespace Model.HHZX.ComsumeAccount
{
    /// <summary>
    /// 原始消费记录
    /// </summary>
    public class SourceConsumeRecord_scr_Info : IModelObject
    {
        public SourceConsumeRecord_scr_Info()
        {
            scr_dRecordTime = DateTime.MinValue;
            scr_dAddDate = DateTime.MinValue;
        }

        public Guid scr_cRecordID { get; set; }
        /// <summary>
        /// 消费卡号
        /// </summary>
        public string scr_cCardNo { get; set; }
        /// <summary>
        /// 余额
        /// </summary>
        public decimal scr_fBalance { get; set; }
        /// <summary>
        /// 消费金额
        /// </summary>
        public decimal scr_fConsume { get; set; }
        /// <summary>
        /// 消费时间
        /// </summary>
        public DateTime scr_dRecordTime { get; set; }
        /// <summary>
        /// 使用消费机号
        /// </summary>
        public int scr_iMacNo { get; set; }
        public string scr_cAdd { get; set; }
        public DateTime scr_dAddDate { get; set; }
        /// <summary>
        /// 是否已同步
        /// </summary>
        public bool src_lIsSync { get; set; }

        #region IModelObject Members

        public int RecordID
        {
            get;
            set;
        }

        #endregion
    }
}
