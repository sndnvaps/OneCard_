using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.IModel;

namespace Model.HHZX.MealBooking
{
    /// <summary>
    /// 学生定餐情况过往记录
    /// </summary>
    public class MealBookingHistory_mbh_Info : IModelObject
    {
        #region IModelObject Members

        public int RecordID
        {
            get;
            set;
        }

        #endregion

        public MealBookingHistory_mbh_Info()
        { }

        public Guid mbh_cRecordID { get; set; }
        /// <summary>
        /// 餐类型
        /// </summary>
        public string mbh_cMealType { get; set; }
        /// <summary>
        /// 是否定餐
        /// </summary>
        public bool mbh_lIsSet { get; set; }
        /// <summary>
        /// 人员ID
        /// </summary>
        public Guid mbh_cTargetID { get; set; }
        /// <summary>
        /// 设置源类型
        /// </summary>
        public string mbh_cTargetType { get; set; }
        /// <summary>
        /// 定餐日期
        /// </summary>
        public DateTime mbh_dMealDate { get; set; }
        /// <summary>
        /// 定餐金额
        /// </summary>
        public decimal mbh_fMealCost { get; set; }
        /// <summary>
        /// 添加人
        /// </summary>
        public string mbh_cAdd { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime mbh_dAddDate { get; set; }

        /// <summary>
        /// 开始时间，非数据库字段，用于查询
        /// </summary>
        public DateTime? StartTime { get; set; }
        /// <summary>
        /// 结束时间，非数据库字段，用于查询
        /// </summary>
        public DateTime? EndTime { get; set; }
    }
}
