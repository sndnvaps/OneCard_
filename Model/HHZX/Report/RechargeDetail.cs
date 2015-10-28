using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.HHZX.Report
{
    public class RechargeDetail : Model.IModel.IModelObject
    {
        /// <summary>
        /// 班别
        /// </summary>
        public string ClassName { get; set; }
        /// <summary>
        /// 充值人
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 卡号
        /// </summary>
        public int CardNo { get; set; }
        /// <summary>
        /// 充值金額
        /// </summary>
        public decimal RechargeValue { get; set; }
        /// <summary>
        /// 充值后余额
        /// </summary>
        public decimal BalanceValue { get; set; }
        /// <summary>
        /// 操作人
        /// </summary>
        public string Operator { get; set; }
        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime OperationTime { get; set; }

        #region IModelObject 成员

        public int RecordID
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        #endregion
    }
}
