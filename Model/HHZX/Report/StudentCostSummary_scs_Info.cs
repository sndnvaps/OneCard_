using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.IModel;
using Model.HHZX.UserInfomation.CardUserInfo;

namespace Model.HHZX.Report
{
    /// <summary>
    /// 学生消费汇总表
    /// </summary>
    public class StudentCostSummary_scs_Info
    {
        /// <summary>
        /// 统计月份
        /// </summary>
        public string scs_cMonthName { get; set; }
        /// <summary>
        /// 学生姓名
        /// </summary>
        public string scs_cUserName { get; set; }
        /// <summary>
        /// 学号
        /// </summary>
        public string scs_cUserNum { get; set; }
        /// <summary>
        /// 班别
        /// </summary>
        public string scs_cClassName { get; set; }
        /// <summary>
        /// 家长姓名
        /// </summary>
        public string scs_cParentName { get; set; }
        /// <summary>
        /// 家长电话
        /// </summary>
        public string scs_cParentPhone { get; set; }
        /// <summary>
        /// 银行账号
        /// </summary>
        public string scs_cAccountNum { get; set; }
        /// <summary>
        /// 统计开始时间
        /// </summary>
        public DateTime scs_dStartDate { get; set; }
        /// <summary>
        /// 统计结束时间
        /// </summary>
        public DateTime scs_dEndDate { get; set; }
        /// <summary>
        /// 总花费
        /// </summary>
        public decimal scs_fTotalCost { get; set; }
        /// <summary>
        /// 月定餐消费额
        /// </summary>
        public decimal scs_fHistoryMealCost { get; set; }
        /// <summary>
        /// 月餐外消费额
        /// </summary>
        public decimal scs_fHistoryFreeCost { get; set; }
        /// <summary>
        /// 下月预计定餐消费额
        /// </summary>
        public decimal scs_fPreMealCost { get; set; }
        /// <summary>
        ///  账户当前余额
        /// </summary>
        public decimal scs_fAccountBalance { get; set; }
        /// <summary>
        /// 补充预算
        /// </summary>
        public decimal scs_fSupplement { get; set; }
        /// <summary>
        /// 家长短信
        /// </summary>
        public string scs_cSMSContent { get; set; }
        /// <summary>
        /// 指定用户ID
        /// </summary>
        public Guid? UserID { get; set; }
        /// <summary>
        /// 指定班别ID
        /// </summary>
        public Guid? ClassID { get; set; }
        /// <summary>
        /// 指定年级ID
        /// </summary>
        public Guid? GradeID { get; set; }

        #region IModelObject Members

        public int RecordID
        {
            get;
            set;
        }

        #endregion
    }
}
