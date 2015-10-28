using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL.IBLL.HHZX.MealBooking;
using Model.IModel;
using Model.General;
using DAL.IDAL.HHZX.MealBooking;
using DAL.Factory.HHZX;
using Model.HHZX.MealBooking;

namespace BLL.DAL.HHZX.MealBooking
{
    /// <summary>
    /// 学生定餐情况过往记录
    /// </summary>
    public class MealBookingHistoryBL : IMealBookingHistoryBL
    {
        private IMealBookingHistoryDA _IMealBookingHistoryDA;

        public MealBookingHistoryBL()
        {
            this._IMealBookingHistoryDA = MasterDAFactory.GetDAL<IMealBookingHistoryDA>(MasterDAFactory.MealBookingHistory);
        }

        #region IMainGeneralBL Members

        public List<MealBookingHistory_mbh_Info> AllRecords()
        {
            try
            {
                List<MealBookingHistory_mbh_Info> listHistory = this._IMealBookingHistoryDA.AllRecords();
                return listHistory;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion

        #region IMainBL Members

        public MealBookingHistory_mbh_Info DisplayRecord(IModelObject itemEntity)
        {
            try
            {
                return this._IMealBookingHistoryDA.DisplayRecord(itemEntity);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<MealBookingHistory_mbh_Info> SearchRecords(IModelObject itemEntity)
        {
            try
            {
                List<MealBookingHistory_mbh_Info> listHistory = this._IMealBookingHistoryDA.SearchRecords(itemEntity);

                return listHistory;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public ReturnValueInfo Save(IModelObject itemEntity, Common.DefineConstantValue.EditStateEnum EditMode)
        {
            try
            {
                ReturnValueInfo rvInfo = new ReturnValueInfo();

                MealBookingHistory_mbh_Info historyInfo = itemEntity as MealBookingHistory_mbh_Info;
                if (historyInfo == null)
                {
                    rvInfo.messageText = Common.DefineConstantValue.SystemMessageText.strMessageText_E_ObjectNull;
                    rvInfo.isError = true;
                    return rvInfo;
                }

                switch (EditMode)
                {
                    case Common.DefineConstantValue.EditStateEnum.OE_Insert:
                        rvInfo = this._IMealBookingHistoryDA.InsertRecord(historyInfo);
                        break;
                    case Common.DefineConstantValue.EditStateEnum.OE_Update:
                        rvInfo = this._IMealBookingHistoryDA.UpdateRecord(historyInfo);
                        break;
                    case Common.DefineConstantValue.EditStateEnum.OE_Delete:
                        rvInfo = this._IMealBookingHistoryDA.DeleteRecord(historyInfo);
                        break;
                    default:
                        break;
                }

                return rvInfo;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public ReturnValueInfo InsertBatchRecords(List<MealBookingHistory_mbh_Info> listHistory)
        {
            try
            {
                return this._IMealBookingHistoryDA.InsertBatchRecords(listHistory);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public ReturnValueInfo UpdateRecordWithPreCost(MealBookingHistory_mbh_Info infoObject)
        {
            try
            {
                return this._IMealBookingHistoryDA.UpdateRecordWithPreCost(infoObject);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// 获取所有卡用户的定餐计划信息
        /// </summary>
        /// <param name="dtPlan">定餐计划日期</param>
        /// <param name="strMealType">用餐类型</param>
        /// <returns></returns>
        public List<MealBookingHistory_mbh_Info> GetAllCardUsersMealPlan(DateTime dtPlan, string strMealType, decimal fCost, string strAdd)
        {
            try
            {
                return this._IMealBookingHistoryDA.GetAllCardUsersMealPlan(dtPlan, strMealType, fCost, strAdd);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// 获取指定卡用户的定餐计划信息
        /// </summary>
        /// <param name="UserID">用户ID</param>
        /// <param name="dtPlan">定餐计划日期</param>
        /// <param name="strMealType">用餐类型</param>
        /// <returns></returns>
        public MealBookingHistory_mbh_Info GetCardUserMealPlan(Guid UserID, DateTime dtPlan, string strMealType, decimal fCost, string strAdd)
        {
            try
            {
                return this._IMealBookingHistoryDA.GetCardUserMealPlan(UserID, dtPlan, strMealType, fCost, strAdd);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        #endregion
    }
}
