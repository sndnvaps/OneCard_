using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.IModel;

namespace Model.HHZX.ComsumeAccount
{
    /// <summary>
    /// 卡用户账户信息
    /// </summary>
    public class CardUserAccount_cua_Info : IModelObject
    {
        public CardUserAccount_cua_Info()
        {
            cua_lIsActive = true;

            cua_cUserName = string.Empty;

            cua_cClassName = string.Empty;

            cua_dCardBlance = 0;

            cua_dCostMoney = 0;

            cua_cCardNo = 0;
        }

        #region IModelObject Members

        public int RecordID
        {
            get;
            set;
        }

        #endregion

        public Guid cua_cRecordID { get; set; }
        /// <summary>
        /// 卡用户ID
        /// </summary>
        public Guid cua_cCUSID { get; set; }
        /// <summary>
        /// 账户起始金额
        /// </summary>
        public decimal cua_fOriginalBalance { get; set; }
        /// <summary>
        /// 账户余额
        /// </summary>
        public decimal cua_fCurrentBalance { get; set; }
        /// <summary>
        /// 账户是否有效
        /// </summary>
        public bool cua_lIsActive { get; set; }
        /// <summary>
        /// 账户最新同步时间
        /// </summary>
        public DateTime cua_dLastSyncTime { get; set; }
        /// <summary>
        /// 新增人
        /// </summary>
        public string cua_cAdd { get; set; }
        /// <summary>
        /// 新增时间
        /// </summary>
        public DateTime cua_dAddDate { get; set; }

        /// <summary>
        /// 账户所有人信息
        /// </summary>
        public CardUserAccount_cua_Info AccountUserInfo { get; set; }

        /// <summary>
        /// 账户资金流动详细列表
        /// </summary>
        public List<CardUserAccountDetail_cuad_Info> ListMoneyFlowDetail { get; set; }

        /// <summary>
        /// 卡用户姓名
        /// </summary>
        public string cua_cUserName { get; set; }

        /// <summary>
        /// 学号
        /// </summary>
        public string cus_cStudentID { get; set; }

        /// <summary>
        /// 卡用户班级名称
        /// </summary>
        public string cua_cClassName { get; set; }

        /// <summary>
        /// 卡余额
        /// </summary>
        public decimal cua_dCardBlance { get; set; }

        /// <summary>
        /// 消费金额
        /// </summary>
        public decimal cua_dCostMoney { get; set; }

        /// <summary>
        /// 卡号
        /// </summary>
        public int cua_cCardNo { get; set; }

        /// <summary>
        /// 未结算金额
        /// </summary>
        public decimal Pcscost { get; set; }

        /// <summary>
        /// 预存金额
        /// </summary>
        public decimal PreRechargeMoney { get; set; }

        /// <summary>
        /// 小计余额
        /// </summary>
        public decimal TotalBalance { get; set; }

        /// <summary>
        /// 下月存款预算
        /// </summary>
        public decimal NextMonthPreRecharge { get; set; }

        /// <summary>
        /// 银行账号
        /// </summary>
        public string BankAccount { get; set; }
        /// <summary>
        /// 家长名称
        /// </summary>
        public string ParentName { get; set; }
        /// <summary>
        /// 家长电话
        /// </summary>
        public string ParentPhone { get; set; }
    }
}
