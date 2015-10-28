using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.HHZX.MealBooking;
using Model.IModel;

namespace BLL.IBLL.HHZX.MealBooking
{
    public interface IPaymentUDMealStateBL : IBaseBL<PaymentUDMealState_pms_Info>
    {
        /// <summary>
        /// 查詢定餐情況，整合自定義和默認設置
        /// </summary>
        /// <param name="itemEntity"></param>
        /// <returns></returns>
        List<PaymentUDMealState_pms_Info> SearchMealRecords(IModelObject itemEntity);
    }
}
