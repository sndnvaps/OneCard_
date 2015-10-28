using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.IModel;

namespace Model.HHZX.MealBooking
{
    public class BlacklistChangeRecord_blc_Info : IModelObject
    {
        #region IModelObject Members

        public int RecordID
        {
            get;
            set;
        }

        #endregion

        public Guid blc_cRecordID { get; set; }
        /// <summary>
        /// 卡号
        /// </summary>
        public int blc_iCardNo { get; set; }
        /// <summary>
        /// 挂失\解挂
        /// </summary>
        public string blc_cOperation { get; set; }
        /// <summary>
        /// 操作类型
        /// </summary>
        public string blc_cOptReason { get; set; }
        /// <summary>
        ///  是否已经完成
        /// </summary>
        public bool blc_lIsFinished { get; set; }
        /// <summary>
        ///  新增人
        /// </summary>
        public string blc_cAdd { get; set; }
        /// <summary>
        /// 新增时间
        /// </summary>
        public DateTime blc_dAddDate { get; set; }
        /// <summary>
        /// 完成时间
        /// </summary>
        public DateTime? blc_dFinishDate { get; set; }
    }
}
