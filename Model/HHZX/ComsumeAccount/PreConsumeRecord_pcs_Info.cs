using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.IModel;

namespace Model.HHZX.ComsumeAccount
{
    /// <summary>
    /// 预消费记录
    /// </summary>
    public class PreConsumeRecord_pcs_Info : IModelObject
    {
        /// <summary>
        /// 记录ID
        /// </summary>
        public Guid pcs_cRecordID { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public Guid pcs_cUserID { get; set; }
        /// <summary>
        /// 消费记录来源记录ID
        /// </summary>
        public Guid pcs_cAccountID { get; set; }
        /// <summary>
        /// 消费产生记录ID（发卡、换卡、定餐）
        /// </summary>
        public Guid? pcs_cSourceID { get; set; }
        /// <summary>
        /// 消费金额
        /// </summary>
        public decimal pcs_fCost { get; set; }
        /// <summary>
        /// 消费类型
        /// </summary>
        public string pcs_cConsumeType { get; set; }
        /// <summary>
        /// 消费时间
        /// </summary>
        public DateTime pcs_dConsumeDate { get; set; }
        /// <summary>
        /// 是否已结算
        /// </summary>
        public bool pcs_lIsSettled { get; set; }
        /// <summary>
        /// 结算时间
        /// </summary>
        public DateTime? pcs_dSettleTime { get; set; }
        /// <summary>
        /// 新增人
        /// </summary>
        public string pcs_cAdd { get; set; }
        /// <summary>
        /// 新增时间
        /// </summary>
        public DateTime pcs_dAddDate { get; set; }

        /// <summary>
        /// 就餐类型(非定餐数据则为空)
        /// </summary>
        public string MealType { get; set; }

        #region IModelObject 成员

        public int RecordID
        {
            get;
            set;
        }

        #endregion
    }
}
