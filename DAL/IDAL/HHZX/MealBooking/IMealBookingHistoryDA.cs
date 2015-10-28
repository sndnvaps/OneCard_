using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.HHZX.MealBooking;
using Model.General;

namespace DAL.IDAL.HHZX.MealBooking
{
    /// <summary>
    /// 学生定餐计划信息
    /// </summary>
    public interface IMealBookingHistoryDA : IMainGeneralDA<MealBookingHistory_mbh_Info>
    {
        /// <summary>
        /// 批量插入定餐历史记录
        /// </summary>
        /// <param name="listHistory"></param>
        /// <returns></returns>
        ReturnValueInfo InsertBatchRecords(List<MealBookingHistory_mbh_Info> listHistory);

        ReturnValueInfo UpdateRecordWithPreCost(MealBookingHistory_mbh_Info infoObject);

        /// <summary>
        /// 获取所有卡用户的定餐计划信息
        /// </summary>
        /// <param name="dtPlan">定餐计划日期</param>
        /// <param name="strMealType">用餐类型</param>
        /// <returns></returns>
        List<MealBookingHistory_mbh_Info> GetAllCardUsersMealPlan(DateTime dtPlan, string strMealType, decimal fCost, string strAdd);

        /// <summary>
        /// 获取指定卡用户的定餐计划信息
        /// </summary>
        /// <param name="UserID">用户ID</param>
        /// <param name="dtPlan">定餐计划日期</param>
        /// <param name="strMealType">用餐类型</param>
        /// <returns></returns>
        MealBookingHistory_mbh_Info GetCardUserMealPlan(Guid UserID, DateTime dtPlan, string strMealType, decimal fCost, string strAdd);
    }
}
