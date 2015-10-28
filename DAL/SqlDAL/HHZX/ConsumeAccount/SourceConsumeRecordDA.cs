using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.IDAL.HHZX.ConsumeAccount;
using Model.General;
using Model.HHZX.ComsumeAccount;
using Model.IModel;
using LinqToSQLModel;

namespace DAL.SqlDAL.HHZX.ConsumeAccount
{
    /// <summary>
    /// 批量原始消费数据
    /// </summary>
    public class SourceConsumeRecordDA : ISourceConsumeRecordDA
    {
        public ReturnValueInfo BatchInsertRecord(List<SourceConsumeRecord_scr_Info> listSource)
        {
            ReturnValueInfo rvInfo = new ReturnValueInfo();
            if (listSource == null)
            {
                rvInfo.isError = true;
                rvInfo.messageText = Common.DefineConstantValue.SystemMessageText.strMessageText_E_ObjectNull;
                return rvInfo;
            }

            try
            {
                using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                {
                    try
                    {
                        List<SourceConsumeRecord_scr> listInsertSource = new List<SourceConsumeRecord_scr>();
                        try
                        {
                            DateTime dtSearchMin = listSource.Min(x => x.scr_dRecordTime);
                            StringBuilder sbSQL = new StringBuilder();
                            sbSQL.AppendLine("select scr_cRecordID,scr_cCardNo,scr_fBalance,scr_fConsume,scr_dRecordTime");
                            sbSQL.AppendLine("     ,scr_iMacNo,src_lIsSync,scr_cAdd,scr_dAddDate from SourceConsumeRecord_scr");
                            sbSQL.AppendLine("where scr_dRecordTime >= '" + dtSearchMin.Date.ToString("yyyy-MM-dd 00:00") + "'");

                            //List<SourceConsumeRecord_scr> listCompAll = db.SourceConsumeRecord_scr.Where(x => x.scr_dRecordTime.Date >= dtSearchMin.Date).ToList();
                            List<SourceConsumeRecord_scr> listCompAll = db.ExecuteQuery<SourceConsumeRecord_scr>(sbSQL.ToString(), new object[] { }).ToList();
                            for (int i = 0; i < listSource.Count; i++)
                            {
                                //检查是否已保存本条记录
                                #region 检查是否已保存本条记录

                                List<SourceConsumeRecord_scr> listComp = listCompAll.Where(x =>
                                    x.scr_dRecordTime == listSource[i].scr_dRecordTime
                                    && x.scr_cCardNo.Trim() == listSource[i].scr_cCardNo.Trim()
                                    && x.scr_fBalance == listSource[i].scr_fBalance
                                    && x.scr_fConsume == listSource[i].scr_fConsume
                                    && x.scr_iMacNo == listSource[i].scr_iMacNo
                                    ).ToList();
                                if (listComp == null || listComp.Count < 1)
                                {
                                    SourceConsumeRecord_scr record = Common.General.CopyObjectValue<SourceConsumeRecord_scr_Info, SourceConsumeRecord_scr>(listSource[i]);
                                    record.src_lIsSync = true;
                                    listInsertSource.Add(record);
                                }
                                else
                                {
                                    rvInfo.messageText += "重复数据：" + listSource[i].scr_cRecordID.ToString();
                                }

                                #endregion
                            }
                        }
                        catch (Exception exChkRecord)
                        {
                            rvInfo.isError = true;
                            rvInfo.messageText = "【检查是否已保存本条记录】，异常：" + exChkRecord.Message;
                            return rvInfo;
                        }

                        if (listInsertSource.Count > 0)
                        {
                            //待添加加工消费记录
                            List<ConsumeRecord_csr> listCSRInsert = new List<ConsumeRecord_csr>();
                            //回馈用消费记录
                            List<ConsumeRecord_csr_Info> listCSRReturn = new List<ConsumeRecord_csr_Info>();

                            try
                            {
                                //各消费时段
                                List<CodeMaster_cmt> listTimes = db.CodeMaster_cmt.Where(x =>
                                    x.cmt_cKey1 == Common.DefineConstantValue.CodeMasterDefine.KEY1_MealTimeSpan.ToString()
                                    ).ToList();

                                foreach (SourceConsumeRecord_scr sourceItem in listInsertSource)
                                {
                                    #region 加工消费数据

                                    if (sourceItem == null)
                                    {
                                        continue;
                                    }
                                    //配对发卡信息
                                    UserCardPair_ucp pairInfo = db.UserCardPair_ucp.Where(x =>
                                        x.ucp_iCardNo == int.Parse(sourceItem.scr_cCardNo)).FirstOrDefault();

                                    //配对消费机信息
                                    ConsumeMachineMaster_cmm macInfo = db.ConsumeMachineMaster_cmm.Where(x =>
                                        x.cmm_iMacNo == sourceItem.scr_iMacNo
                                        ).FirstOrDefault();

                                    if (pairInfo != null && macInfo != null)
                                    {
                                        ConsumeRecord_csr csRecord = new ConsumeRecord_csr();
                                        csRecord.csr_cAdd = sourceItem.scr_cAdd;
                                        csRecord.csr_cCardID = pairInfo.ucp_cCardID;
                                        csRecord.csr_cCardUserID = pairInfo.ucp_cCUSID;
                                        csRecord.csr_cConsumeType = macInfo == null ? Common.DefineConstantValue.ConsumeMachineType.Unknown.ToString() : macInfo.cmm_cUsageType;
                                        csRecord.csr_cMachineID = macInfo == null ? Guid.Empty : macInfo.cmm_cRecordID;
                                        //确定消费餐类型
                                        if (macInfo.cmm_cUsageType == Common.DefineConstantValue.ConsumeMachineType.StuSetmeal.ToString())
                                        {
                                            //学生定餐                                        
                                            csRecord.csr_cMealType = getMealType(listTimes, sourceItem.scr_dRecordTime);
                                        }
                                        else if (macInfo.cmm_cUsageType == Common.DefineConstantValue.ConsumeMachineType.StuPay.ToString())
                                        {
                                            //学生加菜
                                            csRecord.csr_cMealType = Common.DefineConstantValue.MealType.StuFreeMeal.ToString();
                                        }
                                        else if (macInfo.cmm_cUsageType == Common.DefineConstantValue.ConsumeMachineType.TeachPay.ToString())
                                        {
                                            //老师加菜
                                            csRecord.csr_cMealType = Common.DefineConstantValue.MealType.TechFreeMeal.ToString();
                                        }
                                        else if (macInfo.cmm_cUsageType == Common.DefineConstantValue.ConsumeMachineType.HotWaterPay.ToString())
                                        {
                                            //热水房
                                            csRecord.csr_cMealType = Common.DefineConstantValue.MealType.HotWaterRent.ToString();
                                        }
                                        else if (macInfo.cmm_cUsageType == Common.DefineConstantValue.ConsumeMachineType.DrinkPay.ToString())
                                        {
                                            //饮料消费
                                            csRecord.csr_cMealType = Common.DefineConstantValue.MealType.DrinkCost.ToString();
                                        }
                                        else if (macInfo.cmm_cUsageType == Common.DefineConstantValue.ConsumeMachineType.MedicalPay.ToString())
                                        {
                                            //医疗消费
                                            csRecord.csr_cMealType = Common.DefineConstantValue.MealType.MedicalCost.ToString();
                                        }
                                        else
                                        {
                                            //未知类型
                                            csRecord.csr_cMealType = Common.DefineConstantValue.MealType.UnKnown.ToString();
                                        }
                                        csRecord.csr_cRecordID = Guid.NewGuid();
                                        csRecord.csr_cSourceID = sourceItem.scr_cRecordID;
                                        csRecord.csr_dAddDate = DateTime.Now;
                                        csRecord.csr_dConsumeDate = sourceItem.scr_dRecordTime;
                                        csRecord.csr_fCardBalance = sourceItem.scr_fBalance;
                                        csRecord.csr_fConsumeMoney = sourceItem.scr_fConsume;
                                        csRecord.csr_iCardNo = pairInfo.ucp_iCardNo;

                                        ConsumeRecord_csr_Info csrReturn = Common.General.CopyObjectValue<ConsumeRecord_csr, ConsumeRecord_csr_Info>(csRecord);
                                        if (csrReturn != null)
                                        {
                                            listCSRReturn.Add(csrReturn);
                                            listCSRInsert.Add(csRecord);
                                        }
                                    }

                                    #endregion
                                }
                            }
                            catch (Exception exProfileData)
                            {
                                rvInfo.isError = true;
                                rvInfo.messageText = "【加工消费数据】，异常：" + exProfileData.Message;
                                return rvInfo;
                            }

                            if (listInsertSource != null && listCSRInsert != null)
                            {
                                if (listInsertSource.Count > 0 || listCSRInsert.Count > 0)
                                {
                                    db.Connection.Open();
                                    db.Transaction = db.Connection.BeginTransaction();

                                    if (listInsertSource.Count > 0)
                                    {
                                        //保存原始消费记录
                                        db.SourceConsumeRecord_scr.InsertAllOnSubmit(listInsertSource);
                                        db.SubmitChanges();
                                    }

                                    if (listCSRInsert.Count > 0)
                                    {
                                        //保存加工消费记录
                                        db.ConsumeRecord_csr.InsertAllOnSubmit(listCSRInsert);
                                        db.SubmitChanges();
                                    }

                                    db.Transaction.Commit();
                                    db.Connection.Close();
                                }

                                if (listCSRReturn != null)
                                {
                                    rvInfo.ValueObject = listCSRReturn;
                                }
                                else
                                {
                                    rvInfo.messageText = "返回用数据列表为空。";
                                }

                                rvInfo.boolValue = true;
                                rvInfo.isError = false;
                            }
                            else
                            {
                                rvInfo.isError = true;
                                rvInfo.messageText = "插入数据库的数据有异常：数据为空。";
                            }
                        }
                        else
                        {
                            rvInfo.boolValue = true;
                            rvInfo.isError = false;
                            rvInfo.messageText = "无可插入的数据。";
                        }
                    }
                    catch (Exception ex)
                    {
                        rvInfo.boolValue = false;
                        rvInfo.isError = true;
                        db.Transaction.Rollback();
                        throw ex;
                    }
                    finally
                    {
                        db.Connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                rvInfo.boolValue = false;
                rvInfo.isError = true;
                rvInfo.messageText = ex.Message;
            }
            return rvInfo;
        }

        /// <summary>
        /// 获取定餐餐类型值
        /// </summary>
        /// <param name="listTimeList">时段信息</param>
        /// <param name="dtSource">消费时间</param>
        /// <returns></returns>
        string getMealType(List<CodeMaster_cmt> listTimeList, DateTime dtSource)
        {
            try
            {
                string strLunch = listTimeList.Find(x => x.cmt_cKey2 == Common.DefineConstantValue.MealType.Lunch.ToString()).cmt_cRemark;
                string strSupper = listTimeList.Find(x => x.cmt_cKey2 == Common.DefineConstantValue.MealType.Supper.ToString()).cmt_cRemark;

                TimeSpan tsLunch = TimeSpan.Parse(strLunch);
                TimeSpan tsSupper = TimeSpan.Parse(strSupper);
                TimeSpan tsSource = TimeSpan.Parse(dtSource.ToString("HH:mm:ss"));
                if (tsSource < tsLunch)
                {
                    return Common.DefineConstantValue.MealType.Breakfast.ToString();
                }
                else if (tsSource < tsSupper && tsSource >= tsLunch)
                {
                    return Common.DefineConstantValue.MealType.Lunch.ToString();
                }
                else
                {
                    return Common.DefineConstantValue.MealType.Supper.ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region IMainGeneralDA<SourceConsumeRecord_scr_Info> Members

        public ReturnValueInfo InsertRecord(SourceConsumeRecord_scr_Info infoObject)
        {
            throw new NotImplementedException();
        }

        public ReturnValueInfo UpdateRecord(SourceConsumeRecord_scr_Info infoObject)
        {
            throw new NotImplementedException();
        }

        public ReturnValueInfo DeleteRecord(IModelObject KeyObject)
        {
            throw new NotImplementedException();
        }

        public SourceConsumeRecord_scr_Info DisplayRecord(IModelObject KeyObject)
        {
            throw new NotImplementedException();
        }

        public List<SourceConsumeRecord_scr_Info> SearchRecords(IModelObject searchCondition)
        {
            throw new NotImplementedException();
        }

        public List<SourceConsumeRecord_scr_Info> AllRecords()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
