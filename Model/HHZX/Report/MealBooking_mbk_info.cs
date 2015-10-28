using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.HHZX.Report
{
    /// <summary>
    /// 定餐報表對象
    /// </summary>
    public class MealBooking_mbk_info : Model.IModel.IModelObject 
    {

        public int index { get; set; }
        /// <summary>
        /// 年級名稱
        /// </summary>
        public string gradeName { get; set; }
        /// <summary>
        /// 班級名稱
        /// </summary>
        public string className { get; set; }
        /// <summary>
        /// 定餐日期
        /// </summary>
        public string bookingDate { get; set; }
        /// <summary>
        /// 總人數
        /// </summary>
        public int userAmount { get; set; }
        /// <summary>
        /// 預計早餐
        /// </summary>
        public int breakfast_Est {get;set;}
        /// <summary>
        /// 預計午餐
        /// </summary>
        public int lunch_Est {get;set;}
        /// <summary>
        /// 預計晚餐
        /// </summary>
        public int dinner_Est { get; set; }
        /// <summary>
        /// 實際早餐
        /// </summary>
        public int breakfast_Act { get; set; }
        /// <summary>
        /// 實際午餐
        /// </summary>
        public int lunch_Act { get; set; }
        /// <summary>
        /// 實際晚餐
        /// </summary>
        public int dinner_Act { get; set; }

        /// <summary>
        /// 開始時間，查詢對象
        /// </summary>
        public DateTime StartTime { get; set; }
        
        /// <summary>
        /// 結束時間，查詢對象
        /// </summary>
        public DateTime EndTime { get; set; }

        /// <summary>
        /// 年級編號，非數據對象，用于查詢
        /// </summary>
        public Guid GradeID { get; set; }
        /// <summary>
        /// 班級編號，非數據對象，用于查詢
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
