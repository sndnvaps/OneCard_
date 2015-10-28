using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.IModel;
using Model.HHZX.UserInfomation.CardUserInfo;
using Model.HHZX.UserCard;

namespace Model.HHZX.ComsumeAccount
{
    /// <summary>
    /// 卡充值记录
    /// </summary>
    public class RechargeRecord_rcr_Info : IModelObject
    {
        #region IModelObject Members

        public int RecordID
        {
            get;
            set;
        }

        #endregion

        public Guid rcr_cRecordID { get; set; }
        /// <summary>
        /// 消费卡ID
        /// </summary>
        public string rcr_cCardID { get; set; }
        /// <summary>
        /// 充值金额
        /// </summary>
        public decimal rcr_fRechargeMoney { get; set; }
        /// <summary>
        /// 卡余额
        /// </summary>
        public decimal rcr_fBalance { get; set; }
        /// <summary>
        /// 充值时间
        /// </summary>
        public DateTime rcr_dRechargeTime { get; set; }
        /// <summary>
        /// 充值类型
        /// </summary>
        public string rcr_cRechargeType { get; set; }
        /// <summary>
        /// 充值状态
        /// </summary>
        public string rcr_cStatus { get; set; }
        /// <summary>
        /// 持卡人用户ID
        /// </summary>
        public Guid rcr_cUserID { get; set; }
        /// <summary>
        /// 记录描述
        /// </summary>
        public string rcr_cDesc { get; set; }
        /// <summary>
        /// 新增人
        /// </summary>
        public string rcr_cAdd { get; set; }
        /// <summary>
        /// 最后操作人
        /// </summary>
        public string rcr_cLast { get; set; }
        /// <summary>
        /// 最后操作时间
        /// </summary>
        public DateTime rcr_dLastDate { get; set; }

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
        /// 是否需要同步账户信息
        /// </summary>
        public bool IsNeedSyncAccount { get; set; }

        /// <summary>
        /// 要支付的预付款金额
        /// </summary>
        public decimal PreCostMoney { get; set; }

        /// <summary>
        /// 充值后余额
        /// </summary>
        public decimal CurrentBalance { get; set; }

        /// <summary>
        ///  对应账户资金流动记录
        /// </summary>
        public CardUserAccountDetail_cuad_Info AccountDetail;

        /// <summary>
        /// 已发卡资料
        /// </summary>
        public UserCardPair_ucp_Info PairInfo;
    }
}
