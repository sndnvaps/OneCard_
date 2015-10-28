using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.HHZX.Report
{
    public class AmountOfChange_aoc_Info
    {
        public AmountOfChange_aoc_Info()
        {
            this.aoc_cName = string.Empty;

            this.aoc_cDepartment = string.Empty;

            this.aoc_dMoney = 0;

            this.aoc_dAmount = 0;

            this.startDate = null;

            this.endDate = null;

            this.aoc_opTime = null;
        }

        public string cus_cIdentityNum { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string aoc_cName { get; set; }

        /// <summary>
        /// 号学、工号
        /// </summary>
        public string cus_cStudentID { get; set; }

        /// <summary>
        /// 部门
        /// </summary>
        public string aoc_cDepartment { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        public decimal aoc_dMoney { get; set; }

        /// <summary>
        /// 余额
        /// </summary>
        public decimal aoc_dAmount { get; set; }

        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime? aoc_opTime { get; set; }

        public string aoc_cFlowType { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime? startDate { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime? endDate { get; set; }

        /// <summary>
        /// 部门ID
        /// </summary>
        public Guid classID { get; set; }

        /// <summary>
        /// 查询类型，非数据类型
        /// </summary>
        public string selectMenu { get; set; }
        /// <summary>
        /// 是否转帐充值
        /// </summary>
        public bool IsRechargeTransfer { get; set; }
        /// <summary>
        /// 是否转账退款
        /// </summary>
        public bool IsRefundTransfer { get; set; }
    }
}
