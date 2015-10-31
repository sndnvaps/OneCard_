using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.IDAL.HHZX.MealBooking;
using Model.HHZX.MealBooking;
using Model.General;
using LinqToSQLModel;
using Model.IModel;

namespace DAL.SqlDAL.HHZX.MealBooking
{
    public class BlacklistChangeRecordDA : IBlacklistChangeRecordDA
    {
        public ReturnValueInfo InsertRecord(BlacklistChangeRecord_blc_Info infoObject)
        {
            ReturnValueInfo rvInfo = new ReturnValueInfo();
            try
            {
                if (infoObject != null)
                {
                    using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                    {
                        BlacklistChangeRecord_blc record = Common.General.CopyObjectValue<BlacklistChangeRecord_blc_Info, BlacklistChangeRecord_blc>(infoObject);
                        record.blc_dAddDate = DateTime.Now;

                        if (record != null)
                        {
                            db.BlacklistChangeRecord_blc.InsertOnSubmit(record);
                            db.SubmitChanges();
                            rvInfo.boolValue = true;
                            infoObject.blc_dAddDate = record.blc_dAddDate;
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

        public ReturnValueInfo UpdateRecord(BlacklistChangeRecord_blc_Info infoObject)
        {
            ReturnValueInfo rvInfo = new ReturnValueInfo();
            try
            {
                if (infoObject != null)
                {
                    using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                    {
                        BlacklistChangeRecord_blc record = db.BlacklistChangeRecord_blc.Where(x => x.blc_cRecordID == infoObject.blc_cRecordID).FirstOrDefault();

                        if (record != null)
                        {
                            record.blc_cAdd = infoObject.blc_cAdd;
                            record.blc_cOperation = infoObject.blc_cOperation;
                            record.blc_cOptReason = infoObject.blc_cOptReason;
                            record.blc_dAddDate = infoObject.blc_dAddDate;
                            record.blc_dFinishDate = infoObject.blc_dFinishDate;
                            record.blc_iCardNo = infoObject.blc_iCardNo;
                            record.blc_lIsFinished = infoObject.blc_lIsFinished;

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
                BlacklistChangeRecord_blc_Info infoObject = KeyObject as BlacklistChangeRecord_blc_Info;
                if (infoObject != null)
                {
                    using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                    {
                        BlacklistChangeRecord_blc record = db.BlacklistChangeRecord_blc.Where(x => x.blc_cRecordID == infoObject.blc_cRecordID).FirstOrDefault();

                        if (record != null)
                        {
                            db.BlacklistChangeRecord_blc.DeleteOnSubmit(record);

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

        public BlacklistChangeRecord_blc_Info DisplayRecord(IModelObject KeyObject)
        {
            BlacklistChangeRecord_blc_Info resInfo = null;
            try
            {
                BlacklistChangeRecord_blc_Info infoObject = KeyObject as BlacklistChangeRecord_blc_Info;
                if (infoObject != null)
                {
                    using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                    {
                        BlacklistChangeRecord_blc record = db.BlacklistChangeRecord_blc.Where(x => x.blc_cRecordID == infoObject.blc_cRecordID).FirstOrDefault();

                        if (record != null)
                        {
                            resInfo = Common.General.CopyObjectValue<BlacklistChangeRecord_blc, BlacklistChangeRecord_blc_Info>(record);
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

        public List<BlacklistChangeRecord_blc_Info> SearchRecords(IModelObject searchCondition)
        {
            List<BlacklistChangeRecord_blc_Info> listRecordInfo = null;
            try
            {
                StringBuilder sbSQL = new StringBuilder();
                sbSQL.AppendLine("SELECT  blc_cRecordID,blc_iCardNo,blc_cOperation,blc_cOptReason,blc_lIsFinished,blc_cAdd,blc_dAddDate,blc_dFinishDate");
                sbSQL.AppendLine(" FROM BlacklistChangeRecord_blc WHERE 1 = 1");

                BlacklistChangeRecord_blc_Info searchInfo = searchCondition as BlacklistChangeRecord_blc_Info;
                if (searchInfo != null)
                {
                    if (!string.IsNullOrEmpty(searchInfo.blc_cOperation))
                        sbSQL.AppendLine("AND blc_cOperation ='" + searchInfo.blc_cOperation + "'");
                    if (!string.IsNullOrEmpty(searchInfo.blc_cOptReason))
                        sbSQL.AppendLine("AND blc_cOptReason ='" + searchInfo.blc_cOptReason + "'");
                    if (searchInfo.blc_iCardNo != 0)
                        sbSQL.AppendLine("AND blc_iCardNo =" + searchInfo.blc_iCardNo.ToString() + "");
                    sbSQL.AppendLine("AND blc_lIsFinished = 0");
                }

                using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                {
                    IEnumerable<BlacklistChangeRecord_blc_Info> query = db.ExecuteQuery<BlacklistChangeRecord_blc_Info>(sbSQL.ToString(), new object[] { });
                    if (query != null)
                    {
                        listRecordInfo = query.ToList<BlacklistChangeRecord_blc_Info>();
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return listRecordInfo;
        }

        public List<BlacklistChangeRecord_blc_Info> AllRecords()
        {
            List<BlacklistChangeRecord_blc_Info> listRecord = null;
            try
            {
                StringBuilder sbSQL = new StringBuilder();
                sbSQL.AppendLine(" SELECT blc_cRecordID,blc_iCardNo,blc_cOperation,blc_cOptReason,blc_lIsFinished,blc_cAdd ");
                sbSQL.AppendLine(" ,blc_dAddDate,blc_dFinishDate,cus_cIdentityNum as IdentityNum ");
                sbSQL.AppendLine(" FROM BlacklistChangeRecord_blc WITH(NOLOCK) ");
                sbSQL.AppendLine(" JOIN UserCardPair_ucp WITH(NOLOCK) ON ucp_iCardNo=blc_iCardNo ");
                sbSQL.AppendLine(" JOIN CardUserMaster_cus WITH(NOLOCK) ON cus_cRecordID=ucp_cCUSID ");
                sbSQL.AppendLine(" WHERE blc_lIsFinished=0 ");

                using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                {
                    IEnumerable<BlacklistChangeRecord_blc_Info> query = db.ExecuteQuery<BlacklistChangeRecord_blc_Info>(sbSQL.ToString(), new object[] { });
                    if (query != null)
                    {
                        listRecord = query.ToList<BlacklistChangeRecord_blc_Info>();
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return listRecord;
        }

        public ReturnValueInfo UpdateBatchRecord(List<BlacklistChangeRecord_blc_Info> listRecords)
        {
            ReturnValueInfo rvInfo = new ReturnValueInfo();
            try
            {
                if (listRecords == null || (listRecords != null && listRecords.Count < 1))
                {
                    rvInfo.messageText = Common.DefineConstantValue.SystemMessageText.strMessageText_E_ObjectNull;
                    rvInfo.isError = true;
                    return rvInfo;
                }

                using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                {
                    var groupCardNo = listRecords.GroupBy(x => x.blc_iCardNo);
                    if (groupCardNo != null)
                    {
                        StringBuilder sbSQL = new StringBuilder();
                        string strSQLTemp = "UPDATE BlacklistChangeRecord_blc SET blc_lIsFinished = 1, blc_dFinishDate =GETDATE() WHERE 1=1 AND  blc_lIsFinished = 0";
                        foreach (var itemCardNo in groupCardNo)
                        {
                            int iCardNo = itemCardNo.Key;
                            BlacklistChangeRecord_blc_Info blInfo = itemCardNo.OrderByDescending(x => x.blc_dAddDate).FirstOrDefault();
                            if (blInfo != null)
                            {
                                StringBuilder sbSubSQL = new StringBuilder();
                                sbSubSQL.AppendLine(strSQLTemp);
                                sbSubSQL.AppendLine("AND blc_iCardNo = " + iCardNo);
                                sbSubSQL.AppendLine("AND blc_dAddDate <= '" + blInfo.blc_dAddDate.ToString() + "';");
                                sbSQL.AppendLine(sbSubSQL.ToString());
                            }
                        }
                        if (!string.IsNullOrEmpty(sbSQL.ToString()))
                        {
                            int iRes = db.ExecuteCommand(sbSQL.ToString(), new object[] { });
                        }
                    }
                }
                rvInfo.boolValue = true;
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
