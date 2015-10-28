using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.HHZX.Report;
using Model.IModel;

namespace DAL.IDAL.Report
{
    public interface IPaymentBalanceDA : IMainGeneralDA<PaymentBalance_Info>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchCondition"></param>
        /// <param name="lIsWithMac">是否包含打卡数据</param>
        /// <param name="lIsWithPreCost">是否包含补扣数据</param>
        /// <returns></returns>
        List<PaymentBalance_Info> SearchRecords(IModelObject searchCondition, bool lIsWithMac, bool lIsWithPreCost);
    }
}
