using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.IDAL.HHZX.ConsumerDevice;
using Model.General;
using LinqToSQLModel;
using Model.HHZX.ConsumerDevice;

namespace DAL.SqlDAL.HHZX.ConsumerDevice
{
    public class ConsumeMachineDA : IConsumeMachineDA
    {
        #region IMainGeneralDA<ConsumeMachineMaster_cmm_Info> 成员

        public Model.General.ReturnValueInfo InsertRecord(Model.HHZX.ConsumerDevice.ConsumeMachineMaster_cmm_Info infoObject)
        {
            ReturnValueInfo rvInfo = new ReturnValueInfo();
            try
            {
                if (infoObject != null)
                {
                    using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                    {
                        ConsumeMachineMaster_cmm record = Common.General.CopyObjectValue<ConsumeMachineMaster_cmm_Info, ConsumeMachineMaster_cmm>(infoObject);
                        if (record != null)
                        {
                            db.ConsumeMachineMaster_cmm.InsertOnSubmit(record);
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

        public Model.General.ReturnValueInfo UpdateRecord(Model.HHZX.ConsumerDevice.ConsumeMachineMaster_cmm_Info infoObject)
        {
            ReturnValueInfo rvInfo = new ReturnValueInfo();
            try
            {
                if (infoObject != null)
                {
                    using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                    {
                        ConsumeMachineMaster_cmm record = db.ConsumeMachineMaster_cmm.Where(x => x.cmm_cRecordID == infoObject.cmm_cRecordID).FirstOrDefault();

                        if (record != null)
                        {
                            record.cmm_cDesc = infoObject.cmm_cDesc;
                            record.cmm_cIPAddr = infoObject.cmm_cIPAddr;
                            record.cmm_cLast = infoObject.cmm_cLast;
                            record.cmm_cMacName = infoObject.cmm_cMacName;
                            record.cmm_cUsageType = infoObject.cmm_cUsageType;
                            record.cmm_dLastAccessTime = infoObject.cmm_dLastAccessTime;
                            record.cmm_dLastDate = infoObject.cmm_dLastDate;
                            record.cmm_iMacNo = infoObject.cmm_iMacNo;
                            record.cmm_iPort = infoObject.cmm_iPort;
                            record.cmm_lIsActive = infoObject.cmm_lIsActive;
                            record.cmm_cStatus = infoObject.cmm_cStatus;
                            record.cmm_lLastAccessRes = infoObject.cmm_lLastAccessRes;

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

        public Model.General.ReturnValueInfo DeleteRecord(Model.IModel.IModelObject KeyObject)
        {
            throw new NotImplementedException();
        }

        public Model.HHZX.ConsumerDevice.ConsumeMachineMaster_cmm_Info DisplayRecord(Model.IModel.IModelObject KeyObject)
        {
            ConsumeMachineMaster_cmm_Info resInfo = null;
            try
            {
                ConsumeMachineMaster_cmm_Info infoObject = KeyObject as ConsumeMachineMaster_cmm_Info;
                if (infoObject != null)
                {
                    using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                    {
                        ConsumeMachineMaster_cmm record = db.ConsumeMachineMaster_cmm.Where(x => x.cmm_cRecordID == infoObject.cmm_cRecordID).FirstOrDefault();

                        if (record != null)
                        {
                            resInfo = Common.General.CopyObjectValue<ConsumeMachineMaster_cmm, ConsumeMachineMaster_cmm_Info>(record);
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

        public List<Model.HHZX.ConsumerDevice.ConsumeMachineMaster_cmm_Info> SearchRecords(Model.IModel.IModelObject searchCondition)
        {
            List<ConsumeMachineMaster_cmm_Info> listRecordInfo = null;
            try
            {
                StringBuilder sbSQL = new StringBuilder();
                sbSQL.AppendLine("SELECT TOP");
                sbSQL.AppendLine(Common.DefineConstantValue.ListRecordMaxCount.ToString());
                sbSQL.AppendLine("* FROM ConsumeMachineMaster_cmm with(nolock) WHERE 1 = 1");

                ConsumeMachineMaster_cmm_Info searchInfo = searchCondition as ConsumeMachineMaster_cmm_Info;
                if (searchInfo != null)
                {
                    if (searchInfo.cmm_cRecordID != Guid.Empty)
                        sbSQL.AppendLine("AND cmm_cRecordID ='" + searchInfo.cmm_cRecordID.ToString() + "'");
                    if (searchInfo.cmm_iMacNo > 0)
                        sbSQL.AppendLine("AND cmm_iMacNo ='" + searchInfo.cmm_iMacNo.ToString() + "'");
                    if (!String.IsNullOrEmpty(searchInfo.cmm_cIPAddr))
                        sbSQL.AppendLine("AND cmm_cIPAddr like '%" + searchInfo.cmm_cIPAddr.ToString() + "%'");
                    if (searchInfo.cmm_iPort > 0)
                        sbSQL.AppendLine("AND cmm_iPort like '%" + searchInfo.cmm_iPort.ToString() + "%'");
                    if (!String.IsNullOrEmpty(searchInfo.cmm_cMacName))
                        sbSQL.AppendLine("AND cmm_cMacName like '%" + searchInfo.cmm_cMacName.ToString() + "%'");
                    if (!String.IsNullOrEmpty(searchInfo.cmm_cUsageType))
                        sbSQL.AppendLine("AND cmm_cUsageType = '" + searchInfo.cmm_cUsageType.ToString() + "'");
                    if (!String.IsNullOrEmpty(searchInfo.cmm_cStatus))
                        sbSQL.AppendLine("AND cmm_cStatus = '" + searchInfo.cmm_cStatus.ToString() + "'");
                }

                sbSQL.AppendLine("order by cmm_iMacNo");

                using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                {
                    IEnumerable<ConsumeMachineMaster_cmm_Info> query = db.ExecuteQuery<ConsumeMachineMaster_cmm_Info>(sbSQL.ToString(), new object[] { });
                    if (query != null)
                    {
                        listRecordInfo = query.ToList<ConsumeMachineMaster_cmm_Info>();
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return listRecordInfo;
        }

        public List<Model.HHZX.ConsumerDevice.ConsumeMachineMaster_cmm_Info> AllRecords()
        {
            List<ConsumeMachineMaster_cmm_Info> listRecordInfo = null;
            try
            {
                StringBuilder sbSQL = new StringBuilder();
                sbSQL.AppendLine("SELECT TOP");
                sbSQL.AppendLine(Common.DefineConstantValue.ListRecordMaxCount.ToString());
                sbSQL.AppendLine("* FROM ConsumeMachineMaster_cmm WHERE 1 = 1");

                using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                {
                    IEnumerable<ConsumeMachineMaster_cmm_Info> query = db.ExecuteQuery<ConsumeMachineMaster_cmm_Info>(sbSQL.ToString(), new object[] { });
                    if (query != null)
                    {
                        listRecordInfo = query.ToList<ConsumeMachineMaster_cmm_Info>();
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return listRecordInfo;
        }

        #endregion
    }
}
