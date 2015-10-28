using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.HHZX.Report
{
    public class PayRecord_prd_Info : Model.IModel.IModelObject
    {

        public PayRecord_prd_Info()
        {
            this.prd_cRecordID = Guid.Empty;

            this.prd_cPayType = string.Empty;

            this.prd_fPayMoney = 0;

            this.prd_iPayCount = 1;

            this.prd_cDepartmentID = Guid.Empty;

            this.prd_cCertificateID = string.Empty;

            this.prd_cAdd = string.Empty;

            this.prd_cLast = string.Empty;

            this.prd_cPayTypeName = string.Empty;

            this.prd_cDepartmentName = string.Empty;

            this.prd_cCertificateDate = string.Empty;

            this.RecordID = 0;

            this.prd_dStartDate = null;

            this.prd_dEndDate = null;
        }

        /// <summary>
        /// 记录ID
        /// </summary>
        public Guid prd_cRecordID { get; set; }

        /// <summary>
        /// 支出类型 
        /// </summary>
        public string prd_cPayType { get; set; }

        /// <summary>
        /// 支出类型描述
        /// </summary>
        public string prd_cPayTypeName { get; set; }

        /// <summary>
        /// 支出金额
        /// </summary>
        public decimal prd_fPayMoney { get; set; }

        /// <summary>
        /// 支出数量
        /// </summary>
        public int prd_iPayCount { get; set; }

        /// <summary>
        /// 部门ID
        /// </summary>
        public Guid prd_cDepartmentID { get; set; }

        /// <summary>
        /// 部门名称
        /// </summary>
        public string prd_cDepartmentName { get; set; }

        /// <summary>
        /// 凭证编号
        /// </summary>
        public string prd_cCertificateID { get; set; }

        /// <summary>
        /// 凭证日期
        /// </summary>
        public DateTime prd_dCertificateDate { get; set; }

        /// <summary>
        /// 凭证日期 格式化输出
        /// </summary>
        public string prd_cCertificateDate { get; set; }

        /// <summary>
        /// 新增人
        /// </summary>
        public string prd_cAdd { get; set; }

        /// <summary>
        /// 新增时间
        /// </summary>
        public DateTime prd_dAddDate { get; set; }

        /// <summary>
        /// 最后修改人
        /// </summary>
        public string prd_cLast { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        public DateTime prd_dLastDate { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime? prd_dStartDate { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime? prd_dEndDate { get; set; }

        #region IModelObject Members

        public int RecordID
        {
            get;
            set;
        }

        #endregion
    }
}
