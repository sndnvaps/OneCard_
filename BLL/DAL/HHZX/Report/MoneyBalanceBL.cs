using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL.IBLL.HHZX.Report;
using DAL.IDAL.Report;
using DAL.Factory.HHZX;

namespace BLL.DAL.HHZX.Report
{
    public class MoneyBalanceBL : IMoneyBalanceBL
    {
        private IMoneyBalanceDA _imbDA;

        public MoneyBalanceBL()
        {
            _imbDA = MasterDAFactory.GetDAL<IMoneyBalanceDA>(MasterDAFactory.MoneyBalance);
        }

        #region IMoneyBalanceBL 成员

        public List<Model.HHZX.ComsumeAccount.CardUserAccount_cua_Info> SearchRecords(Model.HHZX.UserInfomation.CardUserInfo.CardUserMaster_cus_Info cusInfo)
        {
            return _imbDA.SearchRecords(cusInfo);
        }

        #endregion
    }
}
