using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.IDAL.HHZX.MealBooking;
using Model.HHZX.MealBooking;
using Model.General;
using Model.IModel;
using LinqToSQLModel;
using System.Data.SqlClient;

namespace DAL.SqlDAL.HHZX.MealBooking
{
    /// <summary>
    /// 学生定餐过往记录
    /// </summary>
    public class MealBookingHistoryDA : IMealBookingHistoryDA
    {
        public ReturnValueInfo InsertRecord(MealBookingHistory_mbh_Info infoObject)
        {
            ReturnValueInfo rvInfo = new ReturnValueInfo();
            try
            {
                if (infoObject != null)
                {
                    using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                    {
                        MealBookingHistory_mbh history = Common.General.CopyObjectValue<MealBookingHistory_mbh_Info, MealBookingHistory_mbh>(infoObject);
                        if (history != null)
                        {
                            db.MealBookingHistory_mbh.InsertOnSubmit(history);
                            db.SubmitChanges();
                            rvInfo.boolValue = true;
                            rvInfo.ValueObject = infoObject;
                        }
                        else
                        {
                            rvInfo.messageText = "TransEntity is null";
                        }
                    }
                }
                else
                {
                    rvInfo.messageText = Common.DefineConstantValue.SystemMessageText.strMessageText_E_ObjectNull;
                }
            }
            catch (Exception ex)
            {
                rvInfo.isError = true;
                rvInfo.messageText = ex.Message;
            }
            return rvInfo;
        }

        public ReturnValueInfo UpdateRecord(MealBookingHistory_mbh_Info infoObject)
        {
            ReturnValueInfo rvInfo = new ReturnValueInfo();
            try
            {
                if (infoObject != null)
                {
                    using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                    {
                        MealBookingHistory_mbh history = db.MealBookingHistory_mbh.Where(x => x.mbh_cRecordID == infoObject.mbh_cRecordID).FirstOrDefault();

                        if (history != null)
                        {
                            history.mbh_cAdd = infoObject.mbh_cAdd;
                            history.mbh_cMealType = infoObject.mbh_cMealType;
                            history.mbh_cTargetID = infoObject.mbh_cTargetID;
                            history.mbh_cTargetType = infoObject.mbh_cTargetType;
                            history.mbh_dAddDate = infoObject.mbh_dAddDate;
                            history.mbh_dMealDate = infoObject.mbh_dMealDate;
                            history.mbh_lIsSet = infoObject.mbh_lIsSet;
                            history.mbh_fMealCost = infoObject.mbh_fMealCost;

                            db.SubmitChanges();
                            rvInfo.boolValue = true;
                        }
                        else
                        {
                            rvInfo.messageText = "GetEntity is null";
                        }
                    }
                }
                else
                {
                    rvInfo.messageText = Common.DefineConstantValue.SystemMessageText.strMessageText_E_ObjectNull;
                }
            }
            catch (Exception ex)
            {
                rvInfo.isError = true;
                rvInfo.messageText = ex.Message;
            }
            return rvInfo;
        }

        public ReturnValueInfo UpdateRecordWithPreCost(MealBookingHistory_mbh_Info infoObject)
        {
            ReturnValueInfo rvInfo = new ReturnValueInfo();
            try
            {
                if (infoObject != null)
                {
                    using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                    {
                        db.Connection.Open();
                        db.Transaction = db.Connection.BeginTransaction();
                        try
                        {
                            MealBookingHistory_mbh history = db.MealBookingHistory_mbh.Where(x => x.mbh_cRecordID == infoObject.mbh_cRecordID).FirstOrDefault();

                            if (history != null)
                            {
                                history.mbh_cAdd = infoObject.mbh_cAdd;
                                history.mbh_cMealType = infoObject.mbh_cMealType;
                                history.mbh_cTargetID = infoObject.mbh_cTargetID;
                                history.mbh_cTargetType = infoObject.mbh_cTargetType;
                                history.mbh_dAddDate = infoObject.mbh_dAddDate;
                                history.mbh_dMealDate = infoObject.mbh_dMealDate;
                                history.mbh_lIsSet = infoObject.mbh_lIsSet;
                                history.mbh_fMealCost = infoObject.mbh_fMealCost;

                                CardUserAccount_cua accountInfo = db.CardUserAccount_cua.Where(x => x.cua_cCUSID == infoObject.mbh_cTargetID).FirstOrDefault();

                                PreConsumeRecord_pcs preCostInfo = new PreConsumeRecord_pcs();
                                preCostInfo.pcs_cAccountID = accountInfo.cua_cRecordID;
                                preCostInfo.pcs_cAdd = infoObject.mbh_cAdd;
                                preCostInfo.pcs_cConsumeType = Common.DefineConstantValue.ConsumeMoneyFlowType.AdvanceMealCost.ToString();
                                preCostInfo.pcs_cRecordID = Guid.NewGuid();
                                preCostInfo.pcs_cSourceID = history.mbh_cRecordID;
                                preCostInfo.pcs_cUserID = history.mbh_cTargetID;
                                preCostInfo.pcs_dAddDate = DateTime.Now;
                                preCostInfo.pcs_dConsumeDate = DateTime.Now;
                                preCostInfo.pcs_fCost = history.mbh_fMealCost;
                                preCostInfo.pcs_lIsSettled = false;
                                db.PreConsumeRecord_pcs.InsertOnSubmit(preCostInfo);

                                db.SubmitChanges();
                                db.Transaction.Commit();
                                rvInfo.boolValue = true;
                                return rvInfo;
                            }
                            else
                            {
                                rvInfo.messageText = "GetEntity is null";
                            }
                            db.Transaction.Rollback();
                            db.Connection.Close();
                        }
                        catch (Exception exx)
                        {
                            db.Transaction.Rollback();
                            db.Connection.Close();
                            throw exx;
                        }
                    }
                }
                else
                {
                    rvInfo.messageText = Common.DefineConstantValue.SystemMessageText.strMessageText_E_ObjectNull;
                }
            }
            catch (Exception ex)
            {
                rvInfo.isError = true;
                rvInfo.messageText = ex.Message;
            }
            return rvInfo;
        }

        public ReturnValueInfo DeleteRecord(IModelObject KeyObject)
        {
            ReturnValueInfo rvInfo = new ReturnValueInfo();
            try
            {
                MealBookingHistory_mbh_Info infoObject = KeyObject as MealBookingHistory_mbh_Info;
                if (infoObject != null)
                {
                    using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                    {
                        MealBookingHistory_mbh history = db.MealBookingHistory_mbh.Where(x => x.mbh_cRecordID == infoObject.mbh_cRecordID).FirstOrDefault();

                        if (history != null)
                        {
                            db.MealBookingHistory_mbh.DeleteOnSubmit(history);

                            db.SubmitChanges();
                            rvInfo.boolValue = true;
                            rvInfo.ValueObject = infoObject;
                        }
                        else
                        {
                            rvInfo.messageText = "GetEntity is null";
                        }
                    }
                }
                else
                {
                    rvInfo.messageText = Common.DefineConstantValue.SystemMessageText.strMessageText_E_ObjectNull;
                }
            }
            catch (Exception ex)
            {
                rvInfo.isError = true;
                rvInfo.messageText = ex.Message;
            }
            return rvInfo;
        }

        public MealBookingHistory_mbh_Info DisplayRecord(IModelObject KeyObject)
        {
            MealBookingHistory_mbh_Info resInfo = null;
            try
            {
                MealBookingHistory_mbh_Info infoObject = KeyObject as MealBookingHistory_mbh_Info;
                if (infoObject != null)
                {
                    using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                    {
                        MealBookingHistory_mbh history = db.MealBookingHistory_mbh.Where(x => x.mbh_cRecordID == infoObject.mbh_cRecordID).FirstOrDefault();

                        if (history != null)
                        {
                            resInfo = Common.General.CopyObjectValue<MealBookingHistory_mbh, MealBookingHistory_mbh_Info>(history);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return resInfo;
        }

        public List<MealBookingHistory_mbh_Info> SearchRecords(IModelObject searchCondition)
        {
            List<MealBookingHistory_mbh_Info> listPairInfo = null;
            try
            {
                StringBuilder sbSQL = new StringBuilder();
                sbSQL.AppendLine("SELECT TOP");
                sbSQL.AppendLine(Common.DefineConstantValue.ListRecordMaxCount.ToString());
                sbSQL.AppendLine("mbh_cRecordID,mbh_cMealType,mbh_lIsSet,mbh_cTargetID,mbh_cTargetType,mbh_dMealDate,mbh_fMealCost,mbh_cAdd,mbh_dAddDate FROM MealBookingHistory_mbh WHERE 1 = 1");

                MealBookingHistory_mbh_Info searchInfo = searchCondition as MealBookingHistory_mbh_Info;
                if (searchInfo != null)
                {
                    if (!string.IsNullOrEmpty(searchInfo.mbh_cMealType))
                        sbSQL.AppendLine("AND mbh_cMealType ='" + searchInfo.mbh_cMealType + "'");
                    if (searchInfo.mbh_cTargetID != Guid.Empty)
                        sbSQL.AppendLine("AND mbh_cTargetID ='" + searchInfo.mbh_cTargetID.ToString() + "'");
                    if (!string.IsNullOrEmpty(searchInfo.mbh_cTargetType))
                        sbSQL.AppendLine("AND mbh_cTargetType ='" + searchInfo.mbh_cTargetType + "'");
                    if (searchInfo.mbh_dMealDate != DateTime.MinValue)
                        sbSQL.AppendLine("AND mbh_dMealDate ='" + searchInfo.mbh_dMealDate.Date.ToString("yyyy-MM-dd 00:00:00") + "'");

                    if (searchInfo.StartTime != null && searchInfo.EndTime != null)
                    {
                        sbSQL.AppendLine("AND mbh_dMealDate between '" + ((DateTime)(searchInfo.StartTime)).ToString("yyyy-MM-dd") + "' and '" + ((DateTime)(searchInfo.EndTime)).ToString("yyyy-MM-dd") + "'");
                    }
                }
                sbSQL.AppendLine("order by mbh_dMealDate desc");

                using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                {
                    IEnumerable<MealBookingHistory_mbh_Info> query = db.ExecuteQuery<MealBookingHistory_mbh_Info>(sbSQL.ToString(), new object[] { });
                    if (query != null)
                    {
                        listPairInfo = query.ToList<MealBookingHistory_mbh_Info>();
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return listPairInfo;
        }

        public List<MealBookingHistory_mbh_Info> AllRecords()
        {
            List<MealBookingHistory_mbh_Info> listPairInfo = null;
            try
            {
                StringBuilder sbSQL = new StringBuilder();
                sbSQL.AppendLine("SELECT ");
                sbSQL.AppendLine("* FROM MealBookingHistory_mbh WHERE 1 = 1");

                using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                {
                    IEnumerable<MealBookingHistory_mbh_Info> query = db.ExecuteQuery<MealBookingHistory_mbh_Info>(sbSQL.ToString(), new object[] { });
                    if (query != null)
                    {
                        listPairInfo = query.ToList<MealBookingHistory_mbh_Info>();
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return listPairInfo;
        }

        public ReturnValueInfo InsertBatchRecords(List<MealBookingHistory_mbh_Info> listHistory)
        {
            ReturnValueInfo rvInfo = new ReturnValueInfo();
            try
            {
                if (listHistory == null)
                {
                    rvInfo.messageText = Common.DefineConstantValue.SystemMessageText.strMessageText_E_ObjectNull;
                    rvInfo.isError = true;
                    return rvInfo;
                }

                using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                {
                    try
                    {

                        List<PreConsumeRecord_pcs> listPreMealCost = new List<PreConsumeRecord_pcs>();
                        List<MealBookingHistory_mbh> listHistoryInfo = new List<MealBookingHistory_mbh>();
                        List<MealBookingHistory_mbh_Info> listReturnHistoryInfo = new List<MealBookingHistory_mbh_Info>();

                        DateTime dtMinChkDate = listHistory.Min(x => x.mbh_dMealDate);
                        List<MealBookingHistory_mbh> listChkAll = db.MealBookingHistory_mbh.Where(x => x.mbh_dMealDate.Date >= dtMinChkDate.Date).ToList();

                        foreach (MealBookingHistory_mbh_Info item in listHistory)
                        {
                            MealBookingHistory_mbh hisComp = listChkAll.Where(x =>
                                x.mbh_cMealType == item.mbh_cMealType
                                && x.mbh_cTargetID == item.mbh_cTargetID
                                && x.mbh_dMealDate.Date == item.mbh_dMealDate.Date).FirstOrDefault();
                            if (hisComp != null)//检查到有同一天、同一人、同一餐种的记录，则进行更新操作
                            {
                                hisComp.mbh_fMealCost = item.mbh_fMealCost;//餐费用
                                hisComp.mbh_cAdd = item.mbh_cAdd;
                                hisComp.mbh_cTargetType = item.mbh_cTargetType;//设置源类型
                                hisComp.mbh_dAddDate = item.mbh_dAddDate;
                                hisComp.mbh_lIsSet = item.mbh_lIsSet;//是否定餐
                            }
                            else
                            {
                                //插入新纪录
                                MealBookingHistory_mbh history = Common.General.CopyObjectValue<MealBookingHistory_mbh_Info, MealBookingHistory_mbh>(item);
                                if (history != null)
                                {
                                    history.mbh_dAddDate = DateTime.Now;

                                    //开餐则预添加待付款消费记录
                                    if (history.mbh_lIsSet)
                                    {
                                        CardUserAccount_cua userAccount = db.CardUserAccount_cua.Where(x => x.cua_cCUSID == item.mbh_cTargetID).FirstOrDefault();
                                        if (userAccount == null)
                                        {
                                            rvInfo.messageText = "用户账户信息缺失。";
                                            rvInfo.isError = true;
                                            return rvInfo;
                                        }

                                        //同步插入一条待扣费记录，待餐后收数时再根据收数结果更新此条记录的状态
                                        PreConsumeRecord_pcs preCost = new PreConsumeRecord_pcs();
                                        preCost.pcs_cAccountID = userAccount.cua_cRecordID;
                                        preCost.pcs_cAdd = item.mbh_cAdd;
                                        //类型为【定餐待扣费】
                                        preCost.pcs_cConsumeType = Common.DefineConstantValue.ConsumeMoneyFlowType.AdvanceMealCost.ToString();
                                        preCost.pcs_cRecordID = Guid.NewGuid();
                                        preCost.pcs_cSourceID = item.mbh_cRecordID;
                                        preCost.pcs_cUserID = userAccount.cua_cCUSID;
                                        preCost.pcs_dAddDate = DateTime.Now;
                                        preCost.pcs_dConsumeDate = DateTime.Now;
                                        preCost.pcs_fCost = item.mbh_fMealCost;
                                        listPreMealCost.Add(preCost);
                                    }
                                    #region 多余逻辑
                                    //else
                                    //{
                                    //    //如果原来没有定餐历史记录，且请求添加的历史记录的设置类型为欠款自动停餐时，需要再次检查用户的余额是否正常
                                    //    if (history.mbh_cTargetType == Common.DefineConstantValue.MealType.DebtAuto.ToString())
                                    //    {
                                    //        //查余额
                                    //        CardUserAccount_cua userAccount = db.CardUserAccount_cua.Where(x => x.cua_cCUSID == item.mbh_cTargetID).FirstOrDefault();
                                    //        if (userAccount == null)
                                    //        {
                                    //            rvInfo.messageText = "用户账户信息缺失。";
                                    //            rvInfo.isError = true;
                                    //            return rvInfo;
                                    //        }
                                    //        decimal fBalance = userAccount.cua_fCurrentBalance;

                                    //        RechargeRecord_rcr advanceRecharge = db.RechargeRecord_rcr.Where(x => x.rcr_cUserID == userAccount.cua_cCUSID && x.rcr_cRechargeType == Common.DefineConstantValue.ConsumeMoneyFlowType.Recharge_AdvanceMoney.ToString()).OrderByDescending(x => x.rcr_dRechargeTime).FirstOrDefault();
                                    //        decimal fAdvanceRecharge = decimal.Zero;
                                    //        if (advanceRecharge != null)
                                    //        {
                                    //            fAdvanceRecharge = advanceRecharge.rcr_fRechargeMoney;
                                    //        }

                                    //        decimal fPreCost = decimal.Zero;
                                    //        var query = db.PreConsumeRecord_pcs.Where(x => x.pcs_lIsSettled == false
                                    //    && x.pcs_cConsumeType != Common.DefineConstantValue.ConsumeMoneyFlowType.HedgeFund.ToString()
                                    //    && x.pcs_cConsumeType != Common.DefineConstantValue.ConsumeMoneyFlowType.AdvanceMealCost.ToString()
                                    //    && x.pcs_cConsumeType != Common.DefineConstantValue.ConsumeMoneyFlowType.Recharge_AdvanceMoney.ToString()
                                    //    && x.pcs_cUserID == userAccount.cua_cCUSID);
                                    //        var listQuery = query.ToList();
                                    //        if (listQuery != null && listQuery.Count > 0)
                                    //        {
                                    //            fPreCost = query.Sum(x => x.pcs_fCost);
                                    //        }

                                    //        if ((fBalance + fAdvanceRecharge - Math.Abs(fPreCost)) > 0)
                                    //        {
                                    //            history.mbh_lIsSet = true;

                                    //            //同步插入一条待扣费记录，待餐后收数时再根据收数结果更新此条记录的状态
                                    //            PreConsumeRecord_pcs preCost = new PreConsumeRecord_pcs();
                                    //            preCost.pcs_cAccountID = userAccount.cua_cRecordID;
                                    //            preCost.pcs_cAdd = item.mbh_cAdd;
                                    //            //类型为【定餐待扣费】
                                    //            preCost.pcs_cConsumeType = Common.DefineConstantValue.ConsumeMoneyFlowType.AdvanceMealCost.ToString();
                                    //            preCost.pcs_cRecordID = Guid.NewGuid();
                                    //            preCost.pcs_cSourceID = item.mbh_cRecordID;
                                    //            preCost.pcs_cUserID = userAccount.cua_cCUSID;
                                    //            preCost.pcs_dAddDate = DateTime.Now;
                                    //            preCost.pcs_dConsumeDate = DateTime.Now;
                                    //            preCost.pcs_fCost = item.mbh_fMealCost;
                                    //            listPreMealCost.Add(preCost);

                                    //            MealBookingHistory_mbh_Info mealReturn = Common.General.CopyObjectValue<MealBookingHistory_mbh, MealBookingHistory_mbh_Info>(history);
                                    //            listReturnHistoryInfo.Add(mealReturn);
                                    //        }
                                    //    }
                                    //}

                                    #endregion

                                    listHistoryInfo.Add(history);//最后才添加定餐计划记录
                                }
                            }
                        }

                        db.Connection.Open();
                        db.Transaction = db.Connection.BeginTransaction();

                        if (listHistoryInfo.Count > 0)
                        {
                            db.MealBookingHistory_mbh.InsertAllOnSubmit(listHistoryInfo);
                            db.SubmitChanges();
                        }
                        if (listPreMealCost.Count > 0)
                        {
                            db.PreConsumeRecord_pcs.InsertAllOnSubmit(listPreMealCost);
                            db.SubmitChanges();
                        }


                        db.Transaction.Commit();
                        db.Connection.Close();

                        rvInfo.boolValue = true;
                        rvInfo.ValueObject = listReturnHistoryInfo;
                    }
                    catch (Exception exx)
                    {
                        db.Transaction.Rollback();
                        db.Connection.Close();
                        throw exx;
                    }
                }
            }
            catch (Exception ex)
            {
                rvInfo.isError = true;
                rvInfo.messageText = ex.Message;
            }
            return rvInfo;
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
                List<MealBookingHistory_mbh_Info> listMealPlanInfo = GetMealPlan(Guid.Empty, dtPlan, strMealType, fCost, strAdd);
                return listMealPlanInfo;
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
                MealBookingHistory_mbh_Info mealPlanInfo = null;
                List<MealBookingHistory_mbh_Info> listMealPlanInfo = GetMealPlan(UserID, dtPlan, strMealType, fCost, strAdd);
                if (listMealPlanInfo != null && listMealPlanInfo.Count > 0)
                {
                    mealPlanInfo = listMealPlanInfo[0];
                }

                return mealPlanInfo;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// 获取卡用户的定餐计划信息列表
        /// </summary>
        /// <param name="UserID">用户ID（输入空值时为查询所有卡用户）</param>
        /// <param name="dtPlan">定餐计划日期</param>
        /// <param name="strMealType">用餐类型</param>
        /// <returns></returns>
        private List<MealBookingHistory_mbh_Info> GetMealPlan(Guid UserID, DateTime dtPlan, string strMealType, decimal fCost, string strAdd)
        {
            List<MealBookingHistory_mbh_Info> listMealPlanInfos = new List<MealBookingHistory_mbh_Info>();

            string strMealTypeAb = string.Empty;
            if (strMealType == Common.DefineConstantValue.MealType.Breakfast.ToString())
            {
                strMealTypeAb = "B";
            }
            else if (strMealType == Common.DefineConstantValue.MealType.Lunch.ToString())
            {
                strMealTypeAb = "L";
            }
            else if (strMealType == Common.DefineConstantValue.MealType.Supper.ToString())
            {
                strMealTypeAb = "D";
            }

            if (string.IsNullOrEmpty(strMealType))
            {
                return listMealPlanInfos;
            }

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("EXEC usp_GetUserSetMealPlanLists ");
            strSql.AppendFormat("'" + UserID.ToString() + "',");
            strSql.AppendFormat("'" + dtPlan.ToString("yyyy-MM-dd 00:00") + "',");
            strSql.AppendFormat(((int)dtPlan.DayOfWeek).ToString() + ",");
            strSql.AppendFormat("'" + strMealTypeAb + "'");

            using (SqlDataReader reader = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                while (reader.Read())
                {
                    MealBookingHistory_mbh_Info mealInfo = new MealBookingHistory_mbh_Info();
                    mealInfo.mbh_cRecordID = Guid.NewGuid();
                    mealInfo.mbh_cTargetID = new Guid(reader["UserID"].ToString());
                    mealInfo.mbh_cMealType = strMealType;
                    mealInfo.mbh_fMealCost = fCost;
                    mealInfo.mbh_dMealDate = dtPlan.Date;
                    mealInfo.mbh_cTargetType = reader["SetFrom"].ToString();
                    mealInfo.mbh_lIsSet = int.Parse(reader["FinalMealSet"].ToString()) == 1 ? true : false;
                    mealInfo.mbh_cAdd = strAdd;
                    mealInfo.mbh_dAddDate = DateTime.Now;
                    listMealPlanInfos.Add(mealInfo);
                }
            }

            return listMealPlanInfos;
        }

        /// <summary>
        /// 获取默认的用餐计划信息
        /// </summary>
        /// <param name="UserID">用户ID（</param>
        /// <param name="dtPlan">定餐计划日期</param>
        /// <param name="strMealType">用餐类型</param>
        /// <returns></returns>
        private MealBookingHistory_mbh_Info GetDefalutMealPlan(Guid UserID, DateTime dtPlan, string strMealType, bool lIsSetMeal, decimal fCost, string strAdd)
        {
            MealBookingHistory_mbh_Info mealInfo = new MealBookingHistory_mbh_Info();

            mealInfo.mbh_cRecordID = Guid.NewGuid();
            mealInfo.mbh_cTargetID = UserID;
            mealInfo.mbh_cTargetType = Common.DefineConstantValue.StuMealBookingType.Unknown.ToString();
            mealInfo.mbh_cMealType = strMealType;
            mealInfo.mbh_dMealDate = dtPlan.Date;
            mealInfo.mbh_lIsSet = lIsSetMeal;
            mealInfo.mbh_fMealCost = fCost;
            mealInfo.mbh_cAdd = strAdd;
            mealInfo.mbh_dAddDate = DateTime.Now;

            return mealInfo;
        }
    }
}
