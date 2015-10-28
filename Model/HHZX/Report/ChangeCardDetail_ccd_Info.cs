using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.HHZX.Report
{
    public class ChangeCardDetail_ccd_Info
    {
        public ChangeCardDetail_ccd_Info()
        {
            this.ccd_cName = string.Empty;

            this.ccd_cOldID = 0;

            this.ccd_cNewID = 0;

            this.ccd_dMoney = 0;

            this.ccd_cUnionName = string.Empty;

            this.ccd_dOpTime = null;

            this.startDate = null;

            this.endDate = null;
        }

        /// <summary>
        /// 姓名
        /// </summary>
        public string ccd_cName { get; set; }

        /// <summary>
        /// 旧卡号
        /// </summary>
        public int ccd_cOldID { get; set; }

        /// <summary>
        /// 新卡号
        /// </summary>
        public int ccd_cNewID { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        public decimal ccd_dMoney { get; set; }

        /// <summary>
        /// 单位名称
        /// </summary>
        public string ccd_cUnionName { get; set; }

        /// <summary>
        /// 换卡时间
        /// </summary>
        public DateTime? ccd_dOpTime { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime? startDate { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime? endDate { get; set; }

        /// <summary>
        /// 班级ID
        /// </summary>
        public Guid? classID { get; set; }
    }
}
