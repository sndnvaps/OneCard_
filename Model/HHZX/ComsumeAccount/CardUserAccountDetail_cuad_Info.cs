using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.IModel;

namespace Model.HHZX.ComsumeAccount
{
    /// <summary>
    /// 卡用户账户资金流动详细
    /// </summary>
    public class CardUserAccountDetail_cuad_Info : IModelObject
    {
        #region IModelObject Members

        public int RecordID
        {
            get;
            set;
        }

        #endregion

        public CardUserAccountDetail_cuad_Info()
        {
        }

        public Guid cuad_cRecordID { get; set; }
        /// <summary>
        /// 账户ID
        /// </summary>
        public Guid cuad_cCUAID { get; set; }
        /// <summary>
        /// 流动资金
        /// </summary>
        public decimal cuad_fFlowMoney { get; set; }
        /// <summary>
        /// 流动类型
        /// </summary>
        public string cuad_cFlowType { get; set; }
        /// <summary>
        /// 消费记录ID（当本记录由充值或消费产生时才会有）
        /// </summary>
        public Guid? cuad_cConsumeID { get; set; }
        /// <summary>
        /// 操作人
        /// </summary>
        public string cuad_cOpt { get; set; }
        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime cuad_dOptTime { get; set; }

        /// <summary>
        /// 用户名称
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 用户所属部门\班别名称
        /// </summary>
        public string GroupName { get; set; }
        /// <summary>
        /// 充值类型
        /// </summary>
        public string RechargeType { get; set; }
        /// <summary>
        /// 流金额
        /// </summary>
        public decimal FlowMoney { get; set; }
        /// <summary>
        /// 打卡所在消费机机号
        /// </summary>
        public int? MacNo { get; set; }

        /// <summary>
        /// 操作時間開始，非數據庫對象，用于查詢
        /// </summary>
        public DateTime? OptTime_From { get; set; }
        /// <summary>
        /// 操作時間結束，非數據庫對象，用于查詢
        /// </summary>
        public DateTime? OptTime_To { get; set; }

        #region 部门统计表
        public DateTime? CostDate { get; set; }

        public Guid? CostID { get; set; }

        public string TypeNum { get; set; }
        #endregion

        /// <summary>
        /// 资金流对应消费记录
        /// </summary>
        public ConsumeRecord_csr_Info ConsumeRecord { get; set; }
        /// <summary>
        /// 资金流对应充值记录
        /// </summary>
        public RechargeRecord_rcr_Info RechargeRecord { get; set; }
    }
}
