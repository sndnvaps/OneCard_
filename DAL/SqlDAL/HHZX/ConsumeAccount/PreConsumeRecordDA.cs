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
    /// 预消费记录
    /// </summary>
    public class PreConsumeRecordDA : IPreConsumeRecordDA
    {
        public ReturnValueInfo InsertRecord(PreConsumeRecord_pcs_Info infoObject)
        {
            ReturnValueInfo rvInfo = new ReturnValueInfo();
            try
            {
                if (infoObject != null)
                {
                    using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                    {
                        PreConsumeRecord_pcs record = Common.General.CopyObjectValue<PreConsumeRecord_pcs_Info, PreConsumeRecord_pcs>(infoObject);
                        if (record != null)
                        {
                            db.PreConsumeRecord_pcs.InsertOnSubmit(record);
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

        public ReturnValueInfo UpdateRecord(PreConsumeRecord_pcs_Info infoObject)
        {
            ReturnValueInfo rvInfo = new ReturnValueInfo();
            try
            {
                if (infoObject != null)
                {
                    using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                    {
                        PreConsumeRecord_pcs record = db.PreConsumeRecord_pcs.Where(x => x.pcs_cRecordID == infoObject.pcs_cRecordID).FirstOrDefault();

                        if (record != null)
                        {
                            record.pcs_cConsumeType = infoObject.pcs_cConsumeType;
                            record.pcs_cAdd = infoObject.pcs_cAdd;
                            record.pcs_cAccountID = infoObject.pcs_cAccountID;
                            record.pcs_dAddDate = infoObject.pcs_dAddDate;
                            record.pcs_dConsumeDate = infoObject.pcs_dConsumeDate;
                            record.pcs_fCost = infoObject.pcs_fCost;

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

        public ReturnValueInfo DeleteRecord(IModelObject KeyObject)
        {
            ReturnValueInfo rvInfo = new ReturnValueInfo();
            try
            {
                PreConsumeRecord_pcs_Info infoObject = KeyObject as PreConsumeRecord_pcs_Info;
                if (infoObject != null)
                {
                    using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                    {
                        PreConsumeRecord_pcs record = db.PreConsumeRecord_pcs.Where(x => x.pcs_cRecordID == infoObject.pcs_cRecordID).FirstOrDefault();

                        if (record != null)
                        {
                            db.PreConsumeRecord_pcs.DeleteOnSubmit(record);

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

        public PreConsumeRecord_pcs_Info DisplayRecord(IModelObject KeyObject)
        {
            PreConsumeRecord_pcs_Info resInfo = null;
            try
            {
                PreConsumeRecord_pcs_Info infoObject = KeyObject as PreConsumeRecord_pcs_Info;
                if (infoObject != null)
                {
                    using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                    {
                        PreConsumeRecord_pcs record = db.PreConsumeRecord_pcs.Where(x => x.pcs_cRecordID == infoObject.pcs_cRecordID).FirstOrDefault();

                        if (record != null)
                        {
                            resInfo = Common.General.CopyObjectValue<PreConsumeRecord_pcs, PreConsumeRecord_pcs_Info>(record);
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

        public List<PreConsumeRecord_pcs_Info> SearchRecords(IModelObject searchCondition)
        {
            List<PreConsumeRecord_pcs_Info> listRecordInfo = null;
            try
            {
                StringBuilder sbSQL = new StringBuilder();
                sbSQL.AppendLine("SELECT  pcs_cRecordID,pcs_cUserID,pcs_cAccountID,pcs_cSourceID,pcs_fCost,pcs_cConsumeType");
                sbSQL.AppendLine(",pcs_dConsumeDate,pcs_lIsSettled,pcs_dSettleTime,pcs_cAdd,pcs_dAddDate, mbh_cMealType as MealType");
                sbSQL.AppendLine("from PreConsumeRecord_pcs  with(nolock)");
                sbSQL.AppendLine("LEFT JOIN MealBookingHistory_mbh  with(nolock) on mbh_cRecordID = pcs_cSourceID ");

                PreConsumeRecord_pcs_Info searchInfo = searchCondition as PreConsumeRecord_pcs_Info;
                if (searchInfo != null)
                {
                    sbSQL.AppendLine("where 1= 1");
                    if (searchInfo.pcs_cUserID != Guid.Empty)
                        sbSQL.AppendLine("AND pcs_cUserID ='" + searchInfo.pcs_cUserID + "'");
                    if (!string.IsNullOrEmpty(searchInfo.pcs_cConsumeType))
                        sbSQL.AppendLine("AND pcs_cConsumeType ='" + searchInfo.pcs_cConsumeType + "'");
                    if (searchInfo.pcs_cAccountID != Guid.Empty)
                        sbSQL.AppendLine("AND pcs_cAccountID ='" + searchInfo.pcs_cAccountID.ToString() + "'");
                    if (searchInfo.pcs_dConsumeDate != DateTime.MinValue)
                        sbSQL.AppendLine("AND pcs_dConsumeDate ='" + searchInfo.pcs_dConsumeDate.ToString("yyyy-MM-dd HH:mm:ss") + "'");
                    if (searchInfo.pcs_fCost != 0)
                        sbSQL.AppendLine("AND pcs_fCost =" + searchInfo.pcs_fCost);
                }

                using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                {
                    db.CommandTimeout = 10 * 60000;
                    IEnumerable<PreConsumeRecord_pcs_Info> query = db.ExecuteQuery<PreConsumeRecord_pcs_Info>(sbSQL.ToString(), new object[] { });
                    if (query != null)
                    {
                        listRecordInfo = query.ToList<PreConsumeRecord_pcs_Info>();
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return listRecordInfo;
        }

        public List<PreConsumeRecord_pcs_Info> AllRecords()
        {
            List<PreConsumeRecord_pcs_Info> listRecord = null;
            try
            {
                StringBuilder sbSQL = new StringBuilder();
                sbSQL.AppendLine("SELECT ");
                sbSQL.AppendLine("* FROM PreConsumeRecord_pcs WHERE 1 = 1");

                using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                {
                    IEnumerable<PreConsumeRecord_pcs_Info> query = db.ExecuteQuery<PreConsumeRecord_pcs_Info>(sbSQL.ToString(), new object[] { });
                    if (query != null)
                    {
                        listRecord = query.ToList<PreConsumeRecord_pcs_Info>();
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return listRecord;
        }

        public ReturnValueInfo BatchSolveUncertainRecord(List<PreConsumeRecord_pcs_Info> listRecords, bool isSettled)
        {
            ReturnValueInfo rvInfo = new ReturnValueInfo();
            if (listRecords == null || (listRecords != null && listRecords.Count < 1))
            {
                rvInfo.messageText = Common.DefineConstantValue.SystemMessageText.strMessageText_E_ObjectNull;
                return rvInfo;
            }

            try
            {
                using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                {
                    db.Connection.Open();
                    db.Transaction = db.Connection.BeginTransaction();
                    try
                    {
                        List<SystemAccountDetail_sad> listSysAccountDetails = new List<SystemAccountDetail_sad>();
                        List<CardUserAccountDetail_cuad> listUserAccountDetails = new List<CardUserAccountDetail_cuad>();
                        foreach (PreConsumeRecord_pcs_Info preCostItem in listRecords)
                        {
                            PreConsumeRecord_pcs preCost = db.PreConsumeRecord_pcs.Where(x => x.pcs_cRecordID == preCostItem.pcs_cRecordID).FirstOrDefault();
                            if (preCost == null)
                            {
                                throw new Exception("部分记录已被删除  " + preCostItem.pcs_cRecordID.ToString());
                            }

                            preCost.pcs_lIsSettled = isSettled;
                            preCost.pcs_cConsumeType = preCostItem.pcs_cConsumeType;
                            preCost.pcs_cSourceID = preCostItem.pcs_cSourceID;
                            preCost.pcs_dConsumeDate = DateTime.Now;
                            if (isSettled)
                            {
                                preCost.pcs_dSettleTime = DateTime.Now;

                                CardUserAccountDetail_cuad userDetail = new CardUserAccountDetail_cuad();
                                userDetail.cuad_cOpt = preCostItem.pcs_cAdd;
                                userDetail.cuad_cConsumeID = preCostItem.pcs_cRecordID;
                                userDetail.cuad_cCUAID = preCostItem.pcs_cAccountID;
                                userDetail.cuad_cFlowType = preCostItem.pcs_cConsumeType;
                                userDetail.cuad_cRecordID = Guid.NewGuid();
                                userDetail.cuad_dOptTime = DateTime.Now;
                                userDetail.cuad_fFlowMoney = Math.Abs(preCostItem.pcs_fCost);
                                listUserAccountDetails.Add(userDetail);

                                SystemAccountDetail_sad sysDetail = new SystemAccountDetail_sad();
                                sysDetail.sad_cConsumeID = preCostItem.pcs_cRecordID;
                                sysDetail.sad_cDesc = Common.DefineConstantValue.GetMoneyFlowDesc(preCostItem.pcs_cConsumeType);
                                sysDetail.sad_cFLowMoney = Math.Abs(preCostItem.pcs_fCost);
                                sysDetail.sad_cFlowType = preCostItem.pcs_cConsumeType;
                                sysDetail.sad_cOpt = preCostItem.pcs_cAdd;
                                sysDetail.sad_cRecordID = Guid.NewGuid();
                                sysDetail.sad_dOptTime = DateTime.Now;
                                listSysAccountDetails.Add(sysDetail);
                            }
                        }

                        if (listUserAccountDetails.Count > 0)
                        {
                            db.CardUserAccountDetail_cuad.InsertAllOnSubmit(listUserAccountDetails);
                            db.SystemAccountDetail_sad.InsertAllOnSubmit(listSysAccountDetails);
                        }
                        db.SubmitChanges();
                        db.Transaction.Commit();
                        db.Connection.Close();
                        rvInfo.boolValue = true;
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
    }
}
