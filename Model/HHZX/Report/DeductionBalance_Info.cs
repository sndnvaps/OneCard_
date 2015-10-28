using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.HHZX.Report
{
    public class DeductionBalance_Info : Model.IModel.IModelObject
    {
        /// <summary>
        /// 部門名稱
        /// </summary>
        public string csm_cClassName
        {
            get;
            set;
        }
        /// <summary>
        /// 卡號
        /// </summary>
        public int ucp_iCardNo
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
        /// 消費時間
        /// </summary>
        public DateTime pcs_dConsumeDate
        {
            get;
            set;
        }
        /// <summary>
        /// 消費金額
        /// </summary>
        public decimal pcs_fCost
        {
            get;
            set;
        }
        /// <summary>
        /// 消費后余額
        /// </summary>
        public decimal Balance
        {
            get;
            set;
        }


        /// <summary>
        /// 學號，非數據庫對象，用于查詢
        /// </summary>
        public string StudentID
        {
            get;
            set;
        }
        /// <summary>
        /// 姓名，非數據庫對象，用于查詢
        /// </summary>
        public string ChaName
        {
            get;
            set;
        }
        /// <summary>
        /// 卡號，非數據庫對象，用于查詢
        /// </summary>
        public int CardNo
        {
            get;
            set;
        }
        /// <summary>
        /// 班級，非數據庫對象，用于查詢
        /// </summary>
        public Guid ClassID
        {
            get;
            set;
        }
        /// <summary>
        /// 開始時間。非數據庫對象，用于查詢
        /// </summary>
        public DateTime FromTime
        {
            get;
            set;
        }
        /// <summary>
        /// 結束時間，非數據庫對象，用于查詢
        /// </summary>
        public DateTime ToTime
        {
            get;
            set;
        }

        #region IModelObject 成员
        public int RecordID
        {
            get;
            set;
        }
        #endregion
    }
}
