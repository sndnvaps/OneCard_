using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.IModel;
using Model.HHZX.UserInfomation.CardUserInfo;
using Model.HHZX.ConsumerDevice;
using Model.HHZX.UserCard;

namespace Model.HHZX.ComsumeAccount
{
    /// <summary>
    /// 消费记录
    /// </summary>
    public class ConsumeRecord_csr_Info : IModelObject
    {
        #region IModelObject Members

        public int RecordID
        {
            get;
            set;
        }

        #endregion

        public Guid csr_cRecordID { get; set; }
        /// <summary>
        /// 原始消费记录ID
        /// </summary>
        public Guid csr_cSourceID { get; set; }
        /// <summary>
        /// 消费卡ID
        /// </summary>
        public string csr_cCardID { get; set; }
        /// <summary>
        /// 消费机ID
        /// </summary>
        public Guid csr_cMachineID { get; set; }
        /// <summary>
        /// 消费金额
        /// </summary>
        public decimal csr_fConsumeMoney { get; set; }
        /// <summary>
        /// 卡余额
        /// </summary>
        public decimal csr_fCardBalance { get; set; }
        /// <summary>
        /// 消费时间
        /// </summary>
        public DateTime csr_dConsumeDate { get; set; }
        /// <summary>
        /// 消费人员ID
        /// </summary>
        public Guid csr_cCardUserID { get; set; }
        /// <summary>
        /// 消费类型
        /// </summary>
        public string csr_cConsumeType { get; set; }
        /// <summary>
        /// 是否已结算
        /// </summary>
        public bool csr_lIsSettled { get; set; }
        /// <summary>
        /// 是否已结算(查询用)
        /// </summary>
        public bool? IsSettled { get; set; }
        /// <summary>
        /// 结算时间
        /// </summary>
        public DateTime? csr_dSettleTime { get; set; }
        /// <summary>
        /// 就餐类型
        /// </summary>
        public string csr_cMealType { get; set; }
        /// <summary>
        /// 新增时间
        /// </summary>
        public DateTime csr_dAddDate { get; set; }

        /// <summary>
        /// 卡號
        /// </summary>
        public int csr_iCardNo { get; set; }

        /// <summary>
        /// 原始消费记录
        /// </summary>
        public SourceConsumeRecord_scr_Info SourceRecord { get; set; }
        /// <summary>
        /// 消费用卡信息
        /// </summary>
        public ConsumeCardMaster_ccm_Info CardInfo { get; set; }
        /// <summary>
        /// 卡持有人信息
        /// </summary>
        public CardUserMaster_cus_Info CardOwner { get; set; }
        /// <summary>
        /// 消费所在消费机信息
        /// </summary>
        public ConsumeMachineMaster_cmm_Info MachineInfo { get; set; }

        #region 查询用字段

        /// <summary>
        /// 消费时间（开始），非数据库对像，用于查询
        /// </summary>
        public DateTime? AddDate_From { get; set; }

        /// <summary>
        /// 消费时间（结束），非数据库对像，用于查询
        /// </summary>
        public DateTime? AddDate_To { get; set; }

        /// <summary>
        /// 消费金额（开始），非数据库对像，用于查询
        /// </summary>
        public decimal? ConsumeMoney_From { get; set; }

        /// <summary>
        /// 消费金额（结束），非数据库对像，用于查询
        /// </summary>
        public decimal? ConsumeMoney_To { get; set; }

        #endregion
    }
}
