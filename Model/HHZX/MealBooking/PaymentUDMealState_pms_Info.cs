using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.HHZX.MealBooking
{
    public class PaymentUDMealState_pms_Info : Model.IModel.IModelObject
    {

        public PaymentUDMealState_pms_Info()
        {
            this.pms_cRecordID = Guid.Empty;

            this.pms_dStartDate = null;

            this.pms_dEndDate = null;

            this.pms_cCardUserID = null;

            this.pms_cClassID = null;

            this.pms_cGradeID = null;

            this.pms_cBreakfast = null;

            this.pms_cLunch = null;

            this.pms_cDinner = null;

            this.pms_cSnack = null;

            this.pms_cAdd = string.Empty;

            this.pms_cLast = string.Empty;
        }

        /// <summary>
        /// 唯一ID
        /// </summary>
        public Guid pms_cRecordID { get; set; }

        /// <summary>
        /// 开始日期
        /// </summary>
        public DateTime? pms_dStartDate { get; set; }

        /// <summary>
        /// 开始日期 字串
        /// </summary>
        public string pms_dSD
        {

            get { return (pms_dStartDate != null ? pms_dStartDate.Value.ToString("yyyy-MM-dd") : ""); }
        }

        /// <summary>
        /// 结束日期
        /// </summary>
        public DateTime? pms_dEndDate { get; set; }

        /// <summary>
        /// 结束日期 字串
        /// </summary>
        public string pms_dED
        {
            get { return (pms_dEndDate != null ? pms_dEndDate.Value.ToString("yyyy-MM-dd") : ""); }
        }

        /// <summary>
        /// 用户ID
        /// </summary>
        public Guid? pms_cCardUserID { get; set; }

        /// <summary>
        /// 班级ID
        /// </summary>
        public Guid? pms_cClassID { get; set; }

        /// <summary>
        /// 年级ID
        /// </summary>
        public Guid? pms_cGradeID { get; set; }

        /// <summary>
        /// 早餐
        /// </summary>
        public Boolean? pms_cBreakfast { get; set; }

        /// <summary>
        /// 早餐 订餐情况
        /// </summary>
        public string pms_cBreakfastStatc
        {
            get
            {
                return GetMealBookingDesc(pms_cBreakfast);
            }
        }

        /// <summary>
        /// 午餐
        /// </summary>
        public Boolean? pms_cLunch { get; set; }

        /// <summary>
        /// 午餐 订餐情况
        /// </summary>
        public string pms_cLunchStatc
        {
            get { return GetMealBookingDesc(pms_cLunch); }
        }

        /// <summary>
        /// 晚餐 
        /// </summary>
        public Boolean? pms_cDinner { get; set; }

        /// <summary>
        /// 晚餐 订餐情况
        /// </summary>
        public string pms_cDinnerStatc
        {
            get { return GetMealBookingDesc(pms_cDinner); }
        }

        /// <summary>
        /// 宵夜
        /// </summary>
        public Boolean? pms_cSnack { get; set; }

        public string pms_cAdd { get; set; }

        public DateTime pms_dAddDate { get; set; }

        public string pms_cLast { get; set; }

        public DateTime pms_dLastDate { get; set; }

        /// <summary>
        /// 時間段開始，非數據庫對象，用于查詢
        /// </summary>
        public DateTime? TimeFrom { get; set; }

        public DateTime? TimeTo { get; set; }

        /// <summary>
        /// 获得中文描述
        /// </summary>
        /// <returns></returns>
        private string GetMealBookingDesc(bool? isSet)
        {
            string strDesc = string.Empty;
            if (isSet == null)
            {
                strDesc = "无设置";
            }
            else
            {
                if (isSet.Value)
                {
                    strDesc = "定餐";
                }
                else
                {
                    strDesc = "停餐";
                }
            }
            return strDesc;
        }

        #region IModelObject Members

        public int RecordID
        {
            get;
            set;
        }

        #endregion
    }
}
