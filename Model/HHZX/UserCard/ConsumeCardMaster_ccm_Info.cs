using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.IModel;
using Model.HHZX.UserInfomation.CardUserInfo;

namespace Model.HHZX.UserCard
{
    public class ConsumeCardMaster_ccm_Info : IModelObject
    {
        #region IModelObject Members

        public int RecordID
        {
            get;
            set;
        }

        #endregion

        public ConsumeCardMaster_ccm_Info()
        {
            ccm_cCardID = string.Empty.PadLeft(36, 'F');
            ccm_lIsActive = true;
        }

        /// <summary>
        /// 卡原始ID
        /// </summary>
        public string ccm_cCardID { get; set; }
        /// <summary>
        /// 卡状态
        /// </summary>
        public string ccm_cCardState { get; set; }
        /// <summary>
        /// 卡是否有效
        /// </summary>
        public bool ccm_lIsActive { get; set; }
        public string ccm_cAdd { get; set; }
        public DateTime ccm_dAddDate { get; set; }
        public string ccm_cLast { get; set; }
        public DateTime ccm_dLastDate { get; set; }
        /// <summary>
        /// 卡持有人信息
        /// </summary>
        public CardUserMaster_cus_Info CardOwner { get; set; }

        public UserCardPair_ucp_Info UCPInfo { get; set; }
    }
}
