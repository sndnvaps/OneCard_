using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.IModel;
using Model.HHZX.UserInfomation.CardUserInfo;

namespace Model.HHZX.UserCard
{
    /// <summary>
    /// 用户卡发卡情况（发卡表）
    /// </summary>
    public class UserCardPair_ucp_Info : IModelObject
    {
        #region IModelObject Members

        public int RecordID
        {
            get;
            set;
        }

        #endregion

        public UserCardPair_ucp_Info()
        {
            ucp_dPairTime = DateTime.MinValue;
            ucp_lIsActive = true;
        }

        public Guid ucp_cRecordID { get; set; }
        /// <summary>
        /// 已发卡的卡号
        /// </summary>
        public int ucp_iCardNo { get; set; }
        /// <summary>
        /// 卡原始ID
        /// </summary>
        public string ucp_cCardID { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public Guid ucp_cCUSID { get; set; }
        /// <summary>
        /// 发卡时间
        /// </summary>
        public DateTime ucp_dPairTime { get; set; }
        /// <summary>
        /// 退卡时间
        /// </summary>
        public DateTime? ucp_dReturnTime { get; set; }
        /// <summary>
        /// 卡使用状态
        /// </summary>
        public string ucp_cUseStatus { get; set; }
        /// <summary>
        /// 记录是否有效
        /// </summary>
        public bool ucp_lIsActive { get; set; }

        public string ucp_cAdd { get; set; }
        public DateTime ucp_dAddDate { get; set; }
        public string ucp_cLast { get; set; }
        public DateTime ucp_dLastDate { get; set; }

        /// <summary>
        /// 持卡人信息
        /// </summary>
        public CardUserMaster_cus_Info CardOwner { get; set; }
        /// <summary>
        /// 消费卡信息
        /// </summary>
        public ConsumeCardMaster_ccm_Info CardInfo { get; set; }


        /// <summary>
        /// 非數據庫對象。用于查詢
        /// </summary>
        /// 發卡日期開始
        public DateTime? PairTime_From{ get;set; }

        /// <summary>
        /// 非數據庫對象。用于查詢
        /// </summary>
        /// 發卡日期結束
        public DateTime? PairTime_To { get; set; }
    }
}
