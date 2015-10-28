using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.HHZX.MealBooking
{
    public class PaymentUDGeneralSetting_pus_Info : Model.IModel.IModelObject
    {

        public PaymentUDGeneralSetting_pus_Info()
        {
            this.pus_cRecordID = Guid.Empty;

            this.pus_cGradeID = null;

            this.pus_cCardUserID = null;

            this.pus_cClassID = null;

            this.pus_iWeek = -1;

            this.pus_cBreakfast = null;

            this.pus_cLunch = null;

            this.pus_cDinner = null;

            this.pus_cSnack = null;

            this.pus_cAdd = string.Empty;

            this.pus_cLast = string.Empty;
        }

        /// <summary>
        /// 唯一ID
        /// </summary>
        public Guid pus_cRecordID { get; set; }

        /// <summary>
        /// 年级ID
        /// </summary>
        public Guid? pus_cGradeID { get; set; }

        /// <summary>
        /// 用户ID
        /// </summary>
        public Guid? pus_cCardUserID { get; set; }

        /// <summary>
        /// 班级ID
        /// </summary>
        public Guid? pus_cClassID { get; set; }

        /// <summary>
        /// 星期几(0-6)
        /// </summary>
        public int? pus_iWeek { get; set; }

        /// <summary>
        /// 早餐
        /// </summary>
        public Boolean? pus_cBreakfast { get; set; }

        /// <summary>
        /// 午餐
        /// </summary>
        public Boolean? pus_cLunch { get; set; }

        /// <summary>
        /// 晚餐
        /// </summary>
        public Boolean? pus_cDinner { get; set; }

        /// <summary>
        /// 宵夜
        /// </summary>
        public Boolean? pus_cSnack { get; set; }

        public string pus_cAdd { get; set; }

        public DateTime pus_dAddDate { get; set; }

        public string pus_cLast { get; set; }

        public DateTime pus_dLastDate { get; set; }

        #region IModelObject Members

        public int RecordID
        {
            get;
            set;
        }

        #endregion
    }
}
