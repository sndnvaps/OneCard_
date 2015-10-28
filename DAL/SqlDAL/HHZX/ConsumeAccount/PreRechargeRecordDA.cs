using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.IDAL.HHZX.ConsumeAccount;
using Model.General;
using LinqToSQLModel;
using Model.HHZX.ComsumeAccount;
using Model.IModel;

namespace DAL.SqlDAL.HHZX.ConsumeAccount
{
    /// <summary>
    /// 预充值记录
    /// </summary>
    class PreRechargeRecordDA : IPreRechargeRecordDA
    {
        #region IMainGeneralDA<PreRechargeRecord_prr_Info> Members

        public ReturnValueInfo InsertRecord(PreRechargeRecord_prr_Info infoObject)
        {
            ReturnValueInfo rvInfo = new ReturnValueInfo();
            try
            {
                if (infoObject != null)
                {
                    using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                    {
                        PreRechargeRecord_prr record = Common.General.CopyObjectValue<PreRechargeRecord_prr_Info, PreRechargeRecord_prr>(infoObject);
                        record.prr_dAddDate = DateTime.Now;
                        record.prr_dLastDate = DateTime.Now;

                        if (record != null)
                        {
                            db.PreRechargeRecord_prr.InsertOnSubmit(record);
                            db.SubmitChanges();
                            rvInfo.boolValue = true;
                            infoObject.prr_dAddDate = record.prr_dAddDate;
                            infoObject.prr_dLastDate = record.prr_dLastDate;
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

        public ReturnValueInfo UpdateRecord(PreRechargeRecord_prr_Info infoObject)
        {
            ReturnValueInfo rvInfo = new ReturnValueInfo();
            try
            {
                if (infoObject != null)
                {
                    using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                    {
                        PreRechargeRecord_prr record = db.PreRechargeRecord_prr.Where(x => x.prr_cRecordID == infoObject.prr_cRecordID).FirstOrDefault();

                        if (record != null)
                        {
                            record.prr_cAdd = infoObject.prr_cAdd;
                            record.prr_cLast = infoObject.prr_cLast;
                            record.prr_cRCRID = infoObject.prr_cRCRID;
                            record.prr_cRechargeType = infoObject.prr_cRechargeType;
                            record.prr_cStatus = infoObject.prr_cStatus;
                            record.prr_cUserID = infoObject.prr_cUserID;
                            record.prr_dAddDate = infoObject.prr_dAddDate;
                            record.prr_dLastDate = DateTime.Now;
                            record.prr_dRechargeTime = infoObject.prr_dRechargeTime;
                            record.prr_fRechargeMoney = infoObject.prr_fRechargeMoney;
                            record.prr_cDesc = infoObject.prr_cDesc;

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
                PreRechargeRecord_prr_Info infoObject = KeyObject as PreRechargeRecord_prr_Info;
                if (infoObject != null)
                {
                    using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                    {
                        PreRechargeRecord_prr record = db.PreRechargeRecord_prr.Where(x => x.prr_cRecordID == infoObject.prr_cRecordID).FirstOrDefault();

                        if (record != null)
                        {
                            db.PreRechargeRecord_prr.DeleteOnSubmit(record);

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

        public PreRechargeRecord_prr_Info DisplayRecord(IModelObject KeyObject)
        {
            PreRechargeRecord_prr_Info resInfo = null;
            try
            {
                PreRechargeRecord_prr_Info infoObject = KeyObject as PreRechargeRecord_prr_Info;
                if (infoObject != null)
                {
                    using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                    {
                        PreRechargeRecord_prr record = db.PreRechargeRecord_prr.Where(x => x.prr_cRecordID == infoObject.prr_cRecordID).FirstOrDefault();

                        if (record != null)
                        {
                            resInfo = Common.General.CopyObjectValue<PreRechargeRecord_prr, PreRechargeRecord_prr_Info>(record);
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

        public List<PreRechargeRecord_prr_Info> SearchRecords(IModelObject searchCondition)
        {
            List<PreRechargeRecord_prr_Info> listRecordInfo = null;
            try
            {
                StringBuilder sbSQL = new StringBuilder();
                sbSQL.AppendLine("SELECT TOP");
                sbSQL.AppendLine(Common.DefineConstantValue.ListRecordMaxCount.ToString());
                sbSQL.AppendLine("* FROM PreRechargeRecord_prr WHERE 1 = 1");

                PreRechargeRecord_prr_Info searchInfo = searchCondition as PreRechargeRecord_prr_Info;
                if (searchInfo != null)
                {
                    if (searchInfo.prr_cRCRID != null && searchInfo.prr_cRCRID != Guid.Empty)
                        sbSQL.AppendLine("AND prr_cRCRID ='" + searchInfo.prr_cRCRID.ToString() + "'");
                    if (!string.IsNullOrEmpty(searchInfo.prr_cRechargeType))
                        sbSQL.AppendLine("AND prr_cRechargeType ='" + searchInfo.prr_cRechargeType + "'");
                    if (searchInfo.prr_cUserID != Guid.Empty)
                        sbSQL.AppendLine("AND prr_cUserID ='" + searchInfo.prr_cUserID.ToString() + "'");
                    if (!string.IsNullOrEmpty(searchInfo.prr_cStatus))
                        sbSQL.AppendLine("AND prr_cStatus ='" + searchInfo.prr_cStatus + "'");
                    if (searchInfo.prr_dRechargeTime != DateTime.MinValue)
                        sbSQL.AppendLine("AND prr_dRechargeTime ='" + searchInfo.prr_dRechargeTime.ToString("yyyy-MM-dd HH:mm") + "'");
                    if (searchInfo.prr_fRechargeMoney != 0)
                        sbSQL.AppendLine("AND prr_fRechargeMoney =" + searchInfo.prr_fRechargeMoney);
                }

                using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                {
                    IEnumerable<PreRechargeRecord_prr_Info> query = db.ExecuteQuery<PreRechargeRecord_prr_Info>(sbSQL.ToString(), new object[] { });
                    if (query != null)
                    {
                        listRecordInfo = query.ToList<PreRechargeRecord_prr_Info>();
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return listRecordInfo;
        }

        public List<PreRechargeRecord_prr_Info> AllRecords()
        {
            List<PreRechargeRecord_prr_Info> listRecord = null;
            try
            {
                StringBuilder sbSQL = new StringBuilder();
                sbSQL.AppendLine("SELECT ");
                sbSQL.AppendLine("* FROM PreRechargeRecord_prr WHERE 1 = 1");

                using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                {
                    IEnumerable<PreRechargeRecord_prr_Info> query = db.ExecuteQuery<PreRechargeRecord_prr_Info>(sbSQL.ToString(), new object[] { });
                    if (query != null)
                    {
                        listRecord = query.ToList<PreRechargeRecord_prr_Info>();
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return listRecord;
        }

        #endregion
    }
}
