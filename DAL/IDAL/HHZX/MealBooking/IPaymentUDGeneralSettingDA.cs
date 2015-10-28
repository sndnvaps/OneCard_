using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.HHZX.MealBooking;
using Model.General;

namespace DAL.IDAL.HHZX.MealBooking
{
    public interface IPaymentUDGeneralSettingDA : IMainGeneralDA<PaymentUDGeneralSetting_pus_Info>, IExtraDA
    {
        ReturnValueInfo Save(List<PaymentUDGeneralSetting_pus_Info> objList);
        /// <summary>
        /// 批量删除指定条件的默认定餐记录
        /// </summary>
        /// <param name="searchInfo">条件</param>
        /// <returns></returns>
        ReturnValueInfo BatchDeleteRecords(PaymentUDGeneralSetting_pus_Info searchInfo);
    }
}
