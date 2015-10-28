using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.HHZX.Report
{
    public class DepartmentBalance_dtb_Info
    {
        public DepartmentBalance_dtb_Info()
        {
            this.dtb_iSetmealIncome = 0;

            this.dtb_iSetmealPay = 0;

            this.dtb_iStudentPlusIncome = 0;

            this.dtb_iCardDepartmentIncome = 0;

            this.dtb_iHotWaterIncome = 0;

            this.dtb_iOtherIncome = 0;

            this.dtb_iTeacherSetmealIncome = 0;

            this.dtb_fUnpayPreCost = 0;
        }

        /// <summary>
        /// 定餐部收入
        /// </summary>
        public decimal dtb_iSetmealIncome { get; set; }

        /// <summary>
        /// 定餐部支出
        /// </summary>
        public decimal dtb_iSetmealPay { get; set; }

        /// <summary>
        /// 加菜机收入
        /// </summary>
        public decimal dtb_iStudentPlusIncome { get; set; }

        /// <summary>
        /// 发卡部收入
        /// </summary>
        public decimal dtb_iCardDepartmentIncome { get; set; }

        /// <summary>
        /// 热水部收入
        /// </summary>
        public decimal dtb_iHotWaterIncome { get; set; }

        /// <summary>
        /// 其他收入
        /// </summary>
        public decimal dtb_iOtherIncome { get; set; }

        /// <summary>
        /// 饮料收入
        /// </summary>
        public decimal dtb_fDrinkIncome { get; set; }

        /// <summary>
        /// 教职工用餐收入
        /// </summary>
        public decimal dtb_iTeacherSetmealIncome { get; set; }

        /// <summary>
        /// 未付款总额
        /// </summary>
        public decimal dtb_fUnpayPreCost { get; set; }

        /// <summary>
        /// 开始日期
        /// </summary>
        public DateTime? startDate { get; set; }

        /// <summary>
        /// 结束日期
        /// </summary>
        public DateTime? endDate { get; set; }
    }
}
