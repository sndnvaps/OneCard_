using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.IModel;

namespace Model.HHZX.ComsumeAccount
{
    /// <summary>
    /// 系统账户资金明细
    /// </summary>
    public class SystemAccountDetail_sad_Info : IModelObject
    {
        #region IModelObject Members

        public int RecordID
        {
            get;
            set;
        }

        #endregion

        public SystemAccountDetail_sad_Info()
        { }

        public Guid sad_cRecordID { get; set; }
        /// <summary>
        /// 流动资金额
        /// </summary>
        public decimal sad_cFLowMoney { get; set; }
        /// <summary>
        /// 流动类型
        /// </summary>
        public string sad_cFlowType { get; set; }
        /// <summary>
        /// 消费记录ID（当此资金流是由消费或充值产生时才不为空）
        /// </summary>
        public Guid? sad_cConsumeID { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string sad_cDesc { get; set; }
        /// <summary>
        /// 操作人
        /// </summary>
        public string sad_cOpt { get; set; }
        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime sad_dOptTime { get; set; }
    }
}
