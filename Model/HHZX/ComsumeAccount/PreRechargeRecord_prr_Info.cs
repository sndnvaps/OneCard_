using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.IModel;

namespace Model.HHZX.ComsumeAccount
{
    /// <summary>
    /// 预充值记录
    /// </summary>
    public class PreRechargeRecord_prr_Info : IModelObject
    {
        #region IModelObject Members

        public int RecordID
        {
            get;
            set;
        }

        #endregion

        public Guid prr_cRecordID { get; set; }
        /// <summary>
        /// 持卡人用户ID
        /// </summary>
        public Guid prr_cUserID { get; set; }
        /// <summary>
        /// 实际充值记录ID
        /// </summary>
        public Guid? prr_cRCRID { get; set; }
        /// <summary>
        /// 充值金额
        /// </summary>
        public decimal prr_fRechargeMoney { get; set; }
        /// <summary>
        /// 充值时间
        /// </summary>
        public DateTime prr_dRechargeTime { get; set; }
        /// <summary>
        /// 充值类型
        /// </summary>
        public string prr_cRechargeType { get; set; }
        /// <summary>
        /// 充值状态
        /// </summary>
        public string prr_cStatus { get; set; }
        /// <summary>
        /// 记录描述
        /// </summary>
        public string prr_cDesc { get; set; }
        /// <summary>
        /// 新增人
        /// </summary>
        public string prr_cAdd { get; set; }
        /// <summary>
        /// 新增时间
        /// </summary>
        public DateTime prr_dAddDate { get; set; }
        /// <summary>
        /// 最后操作人
        /// </summary>
        public string prr_cLast { get; set; }
        /// <summary>
        /// 最后操作时间
        /// </summary>
        public DateTime prr_dLastDate { get; set; }
    }
}
