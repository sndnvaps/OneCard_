using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.HHZX.Report
{
    public class AccoumtBalance_atb_info : Model.IModel.IModelObject
    {
        /// <summary>
        /// 统计日期
        /// </summary>
        public DateTime StatisticsDate { get; set; }
        /// <summary>
        /// 结算时间
        /// </summary>
        public DateTime AccountDate { get; set; }
        /// <summary>
        /// 截止至今的账户余额
        /// </summary>
        public decimal SoFarMoney { get; set; }
        /// <summary>
        /// 定餐金额
        /// </summary>
        public decimal BookingMoney { get; set; }
        /// <summary>
        /// 加菜金额
        /// </summary>
        public decimal MealPayMoney { get; set; }
        /// <summary>
        /// 热水消费统计
        /// </summary>
        public decimal HotWaterMoney { get; set; }
        /// <summary>
        /// 饮料消费统计
        /// </summary>
        public decimal DrinkMoney { get; set; }
        /// <summary>
        /// 宵夜消费统计
        /// </summary>
        public decimal NightMealMoney { get; set; }
        /// <summary>
        /// 部门支出统计
        /// </summary>
        public decimal ExpendMoney { get; set; }
        /// <summary>
        /// 充值金额
        /// </summary>
        public decimal BankSavings { get; set; }
        /// <summary>
        /// 人员账户金额
        /// </summary>
        public decimal TotalMoney { get; set; }
        /// <summary>
        /// 早餐计划数
        /// </summary>
        public int Breakfast_Est { get; set; }
        /// <summary>
        /// 午餐计划数
        /// </summary>
        public int Lunch_Est { get; set; }
        /// <summary>
        /// 晚餐计划数
        /// </summary>
        public int Dinner_Est { get; set; }
        /// <summary>
        /// 早餐实际数
        /// </summary>
        public int Breakfast_Act { get; set; }
        /// <summary>
        /// 午餐实际数
        /// </summary>
        public int Lunch_Act { get; set; }
        /// <summary>
        /// 晚餐实际数
        /// </summary>
        public int Dinner_Act { get; set; }
        /// <summary>
        /// 开始时间，用于查询条件
        /// </summary>
        public DateTime AccountDate_From { get; set; }
        /// <summary>
        /// 结束时间，用于查询条件
        /// </summary>
        public DateTime AccountDate_To { get; set; }
        /// <summary>
        /// 年级编号，用于查询条件
        /// </summary>
        public Guid GradeID { get; set; }
        /// <summary>
        /// 班级编号，用于查询条件
        /// </summary>
        public Guid ClassID { get; set; }

        #region IModelObject 成员

        public int RecordID
        {
            get;
            set;
        }

        #endregion
    }
}
