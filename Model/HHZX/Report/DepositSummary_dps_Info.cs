using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.IModel;

namespace Model.HHZX.Report
{
    /// <summary>
    /// 存款汇总表
    /// </summary>
    public class DepositSummary_dps_Info : IModelObject
    {
        public DepositSummary_dps_Info()
        {
            dps_cMonthName = string.Empty;
            dps_iRechargeAmount = 0;
            dps_fTotalRecharge = 0;
            dps_iRefundAmount = 0;
            dps_fTotalRefund = 0;
            dps_fTotalDeposit = 0;
        }

        /// <summary>
        /// 对象名称
        /// </summary>
        public string dps_cObjName { get; set; }
        /// <summary>
        /// 月份名称
        /// </summary>
        public string dps_cMonthName { get; set; }
        /// <summary>
        /// 每月存款笔数
        /// </summary>
        public int? dps_iRechargeAmount { get; set; }
        /// <summary>
        /// 每月存款小计
        /// </summary>
        public decimal? dps_fTotalRecharge { get; set; }
        /// <summary>
        /// 每月退款笔数
        /// </summary>
        public int? dps_iRefundAmount { get; set; }
        /// <summary>
        /// 每月退款小计
        /// </summary>
        public decimal? dps_fTotalRefund { get; set; }
        /// <summary>
        /// 每月存款合计
        /// </summary>
        public decimal? dps_fTotalDeposit { get; set; }
        /// <summary>
        /// 班级ID
        /// </summary>
        public Guid dps_cClassID { get; set; }
        /// <summary>
        /// 部门ID
        /// </summary>
        public Guid dps_cDptID { get; set; }
        /// <summary>
        /// 开始月份
        /// </summary>
        public DateTime dps_dMonthFrom { get; set; }
        /// <summary>
        /// 结束月份
        /// </summary>
        public DateTime dps_dMonthTo { get; set; }

        #region IModelObject Members

        public int RecordID
        {
            get;
            set;
        }

        #endregion
    }
}
