using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.IModel;

namespace Model.HHZX.Report
{
    /// <summary>
    /// 每月饭卡汇总表
    /// </summary>
    public class CardFeeSummary_cfs_Info : IModelObject
    {
        #region IModelObject Members

        public int RecordID
        {
            get;
            set;
        }

        #endregion

        /// <summary>
        /// 月份名称
        /// </summary>
        public string cfs_cMonthName { get; set; }
        /// <summary>
        /// 每月卡收入笔数
        /// </summary>
        public int? cfs_iCardIncomeCount { get; set; }
        /// <summary>
        /// 每月卡收入
        /// </summary>
        public decimal? cfs_fCardIncome { get; set; }
        /// <summary>
        /// 每月卡支出笔数
        /// </summary>
        public int? cfs_iCardPayCount { get; set; }
        /// <summary>
        /// 每月卡支出
        /// </summary>
        public decimal? cfs_fCardPay { get; set; }

        /// <summary>
        /// 开始月份
        /// </summary>
        public DateTime cfs_dMonthFrom { get; set; }
        /// <summary>
        /// 结束月份
        /// </summary>
        public DateTime cfs_dMonthTo { get; set; }
    }
}
