using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.HHZX.Report
{
    public class PaymentBalance_Info : Model.IModel.IModelObject
    {
        /// <summary>
        /// 人员身份
        /// </summary>
        public string cus_cIdentityNum
        {
            get;
            set;
        }

        /// <summary>
        /// 学号
        /// </summary>
        public string cus_cStudentID
        {
            get;
            set;
        }
        /// <summary>
        /// 姓名
        /// </summary>
        public string cus_cChaName
        {
            get;
            set;
        }
        /// <summary>
        /// 部门
        /// </summary>
        public string csm_cClassName
        {
            get;
            set;
        }
        /// <summary>
        /// 金额
        /// </summary>
        public decimal csr_fConsumeMoney
        {
            get;
            set;
        }
        /// <summary>
        /// 消费日期
        /// </summary>
        public DateTime csr_dConsumeDate
        {
            get;
            set;
        }

        /// <summary>
        /// 机号
        /// </summary>
        public string MacNo
        {
            get;
            set;
        }

        /// <summary>
        /// 余额
        /// </summary>
        public decimal? csr_fCardBalance
        {
            get;
            set;
        }

        /// <summary>
        /// 開始時間，非數據庫對象用于查詢
        /// </summary>
        public DateTime? TimeFrom
        {
            get;
            set;
        }
        /// <summary>
        /// 結束時間，非數據庫對象用于查詢
        /// </summary>
        public DateTime? TimeTo
        {
            get;
            set;
        }
        /// <summary>
        /// 班級ID，非數據庫對象用于查詢
        /// </summary>
        public Guid ClassID
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        //public string MacNo
        //{
        //    get
        //    {
        //        if (MacNo == null)
        //        {
        //            return "补扣";
        //        }
        //        else
        //        {
        //            return MacNo.ToString();
        //        }
        //    }
        //    set
        //    {

        //    }
        //}

        #region IModelObject 成员

        int Model.IModel.IModelObject.RecordID
        {
            get;
            set;
        }

        #endregion
    }
}
