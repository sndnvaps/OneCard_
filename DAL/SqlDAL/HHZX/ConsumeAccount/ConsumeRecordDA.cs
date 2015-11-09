using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.IDAL.HHZX.ConsumeAccount;
using LinqToSQLModel;
using Model.HHZX.ComsumeAccount;
using Model.General;
using System.Data.SqlClient;

namespace DAL.SqlDAL.HHZX.ConsumeAccount
{
    public class ConsumeRecordDA : IConsumeRecordDA
    {
        #region IMainGeneralDA<ConsumeRecord_csr_Info> 成员

        public Model.General.ReturnValueInfo InsertRecord(Model.HHZX.ComsumeAccount.ConsumeRecord_csr_Info infoObject)
        {
            throw new NotImplementedException();
        }

        public Model.General.ReturnValueInfo UpdateRecord(Model.HHZX.ComsumeAccount.ConsumeRecord_csr_Info infoObject)
        {
            throw new NotImplementedException();
        }

        public Model.General.ReturnValueInfo DeleteRecord(Model.IModel.IModelObject KeyObject)
        {
            throw new NotImplementedException();
        }

        public Model.HHZX.ComsumeAccount.ConsumeRecord_csr_Info DisplayRecord(Model.IModel.IModelObject KeyObject)
        {
            ConsumeRecord_csr_Info resInfo = null;
            try
            {
                ConsumeRecord_csr_Info infoObject = KeyObject as ConsumeRecord_csr_Info;
                if (infoObject != null)
                {
                    using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                    {
                        ConsumeRecord_csr record = db.ConsumeRecord_csr.Where(x => x.csr_cRecordID == infoObject.csr_cRecordID).FirstOrDefault();

                        if (record != null)
                        {
                            resInfo = Common.General.CopyObjectValue<ConsumeRecord_csr, ConsumeRecord_csr_Info>(record);
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

        public List<Model.HHZX.ComsumeAccount.ConsumeRecord_csr_Info> SearchRecords(Model.IModel.IModelObject searchCondition)
        {
            List<ConsumeRecord_csr_Info> listRecordInfo = null;
            try
            {
                StringBuilder sbSQL = new StringBuilder();
                sbSQL.AppendLine("SELECT  * FROM ConsumeRecord_csr WHERE 1 = 1");

                ConsumeRecord_csr_Info searchInfo = searchCondition as ConsumeRecord_csr_Info;
                if (searchInfo != null)
                {
                    if (!String.IsNullOrEmpty(searchInfo.csr_cCardID))
                        sbSQL.AppendLine("AND csr_cCardID ='" + searchInfo.csr_cCardID.ToString() + "'");
                    if (searchInfo.csr_cMachineID != Guid.Empty)
                        sbSQL.AppendLine("AND csr_cMachineID ='" + searchInfo.csr_cMachineID.ToString() + "'");
                    if (searchInfo.csr_cCardUserID != Guid.Empty)
                        sbSQL.AppendLine("AND csr_cCardUserID ='" + searchInfo.csr_cCardUserID.ToString() + "'");

                    if (searchInfo.AddDate_From != null && searchInfo.AddDate_To != null)
                    {
                        sbSQL.AppendLine("AND csr_dAddDate between '" + ((DateTime)(searchInfo.AddDate_From)).ToString("yyyy/MM/dd")
                                    + "' and '" + ((DateTime)(searchInfo.AddDate_To)).ToString("yyyy/MM/dd") + "'");
                    }

                    if (searchInfo.ConsumeMoney_From != null && searchInfo.ConsumeMoney_To != null)
                    {
                        sbSQL.AppendLine("AND csr_fConsumeMoney between '" + searchInfo.ConsumeMoney_From.ToString()
                                    + "' and '" + searchInfo.ConsumeMoney_To.ToString() + "'");
                    }
                    if (searchInfo.IsSettled != null)
                    {
                        string strRes = "AND csr_lIsSettled = ";
                        strRes += searchInfo.IsSettled == true ? "1" : "0";
                        sbSQL.AppendLine(strRes);
                    }
                }

                using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                {
                    IEnumerable<ConsumeRecord_csr_Info> query = db.ExecuteQuery<ConsumeRecord_csr_Info>(sbSQL.ToString(), new object[] { });
                    if (query != null)
                    {
                        listRecordInfo = query.ToList<ConsumeRecord_csr_Info>();
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return listRecordInfo;
        }

        public List<Model.HHZX.ComsumeAccount.ConsumeRecord_csr_Info> AllRecords()
        {
            List<ConsumeRecord_csr_Info> listRecordInfo = null;
            try
            {
                StringBuilder sbSQL = new StringBuilder();
                sbSQL.AppendLine("SELECT TOP");
                sbSQL.AppendLine(Common.DefineConstantValue.ListRecordMaxCount.ToString());
                sbSQL.AppendLine("* FROM ConsumeRecord_csr ");

                using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                {
                    IEnumerable<ConsumeRecord_csr_Info> query = db.ExecuteQuery<ConsumeRecord_csr_Info>(sbSQL.ToString(), new object[] { });
                    if (query != null)
                    {
                        listRecordInfo = query.ToList<ConsumeRecord_csr_Info>();
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

        #region IConsumeRecordDA 成员

        public ReturnValueInfo BatchSyncSourceRecord(List<SourceConsumeRecord_scr_Info> listSourceRecord, string strMealType)
        {
            ReturnValueInfo rvInfo = new ReturnValueInfo();
            if (listSourceRecord == null)
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
                        db.Connection.Open();
                        db.Transaction = db.Connection.BeginTransaction();

                        List<ConsumeRecord_csr_Info> listReturn = new List<ConsumeRecord_csr_Info>();

                        foreach (SourceConsumeRecord_scr_Info sourceItem in listSourceRecord)
                        {
                            SourceConsumeRecord_scr sourceRecord = db.SourceConsumeRecord_scr.Where(x => x.scr_cRecordID == sourceItem.scr_cRecordID).FirstOrDefault();
                            if (sourceRecord != null && !sourceRecord.src_lIsSync)
                            {
                                UserCardPair_ucp pairInfo = db.UserCardPair_ucp.Where(x => x.ucp_iCardNo == int.Parse(sourceItem.scr_cCardNo)).FirstOrDefault();
                                ConsumeMachineMaster_cmm macInfo = db.ConsumeMachineMaster_cmm.Where(x => x.cmm_iMacNo == sourceRecord.scr_iMacNo).FirstOrDefault();
                                if (pairInfo != null)
                                {
                                    ConsumeRecord_csr csRecord = new ConsumeRecord_csr();
                                    csRecord.csr_cAdd = "sys";
                                    csRecord.csr_cCardID = pairInfo.ucp_cCardID;
                                    csRecord.csr_cCardUserID = pairInfo.ucp_cCUSID;
                                    csRecord.csr_cConsumeType = macInfo == null ? "UNKNOWN" : macInfo.cmm_cUsageType;
                                    csRecord.csr_cMachineID = macInfo == null ? Guid.Empty : macInfo.cmm_cRecordID;
                                    csRecord.csr_cMealType = strMealType;
                                    csRecord.csr_cRecordID = Guid.NewGuid();
                                    csRecord.csr_cSourceID = sourceRecord.scr_cRecordID;
                                    csRecord.csr_dAddDate = DateTime.Now;
                                    csRecord.csr_dConsumeDate = sourceRecord.scr_dRecordTime;
                                    csRecord.csr_fCardBalance = sourceRecord.scr_fBalance;
                                    csRecord.csr_fConsumeMoney = sourceRecord.scr_fConsume;
                                    csRecord.csr_iCardNo = pairInfo.ucp_iCardNo;
                                    csRecord.csr_lIsSettled = false;
                                    csRecord.csr_dSettleTime = null;

                                    db.ConsumeRecord_csr.InsertOnSubmit(csRecord);
                                    sourceRecord.src_lIsSync = true;
                                    db.SubmitChanges();

                                    listReturn.Add(Common.General.CopyObjectValue<ConsumeRecord_csr, ConsumeRecord_csr_Info>(csRecord));
                                }
                            }
                        }

                        db.Transaction.Commit();
                        rvInfo.boolValue = true;
                        rvInfo.ValueObject = listReturn;
                    }
                    catch (Exception ex)
                    {
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
                rvInfo.isError = true;
                rvInfo.messageText = ex.Message;
            }
            return rvInfo;
        }

        public List<ConsumeRecord_csr_Info> GetClassConsumeRecord(Guid classID, DateTime dt)
        {
            List<ConsumeRecord_csr_Info> listRecordInfo = null;
            try
            {
                StringBuilder sbSQL = new StringBuilder();
                sbSQL.AppendLine("select * from dbo.ConsumeRecord_csr csr ");
                sbSQL.AppendLine("join dbo.UserCardPair_ucp ucp on csr.csr_cCardID = ucp.ucp_cCardID");
                sbSQL.AppendLine("join dbo.CardUserMaster_cus cus on ucp.ucp_cCUSID = cus.cus_cRecordID");
                sbSQL.AppendLine("where 1=1");

                if (classID != Guid.Empty)
                {
                    sbSQL.AppendLine("AND cus.cus_cClassID ='" + classID.ToString() + "'");
                }

                sbSQL.AppendLine("and csr_dConsumeDate between '" + dt.ToString("yyyy/MM/dd") + "' and '" + dt.AddDays(1).ToString("yyyy/MM/dd") + "'");

                using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                {
                    IEnumerable<ConsumeRecord_csr_Info> query = db.ExecuteQuery<ConsumeRecord_csr_Info>(sbSQL.ToString(), new object[] { });
                    if (query != null)
                    {
                        listRecordInfo = query.ToList<ConsumeRecord_csr_Info>();
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return listRecordInfo;
        }

        /// <summary>
        /// 饭堂消费收入 
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public decimal CanteenIncome(DateTime startDate, DateTime endDate)
        {
            decimal inCome = 0;

            StringBuilder sbSQL = new StringBuilder();

            sbSQL.AppendLine("select *");

            sbSQL.AppendLine("from dbo.ConsumeRecord_csr");

            sbSQL.AppendLine("where 1=1 ");

            sbSQL.AppendLine("and csr_cConsumeType='" + Common.DefineConstantValue.ConsumeMachineType.StuSetmeal.ToString() + "'");

            sbSQL.AppendLine("and csr_dAddDate>='" + startDate.ToString("yyyy-MM-dd") + " 00:00:00'");

            sbSQL.AppendLine("and csr_dAddDate<'" + endDate.AddDays(1).ToString("yyyy-MM-dd") + " 00:00:00'");


            List<ConsumeRecord_csr_Info> returnList = new List<ConsumeRecord_csr_Info>();

            try
            {
                using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                {
                    IEnumerable<ConsumeRecord_csr_Info> query = db.ExecuteQuery<ConsumeRecord_csr_Info>(sbSQL.ToString(), new object[] { });

                    if (query != null)
                    {
                        returnList = query.ToList<ConsumeRecord_csr_Info>();

                        foreach (ConsumeRecord_csr_Info item in returnList)
                        {
                            inCome += item.csr_fConsumeMoney;
                        }
                    }
                }
            }
            catch (Exception Ex)
            {

                throw Ex;
            }

            return inCome;
        }

        /// <summary>
        /// 加菜收入
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public decimal CanteenPlusIncome(DateTime startDate, DateTime endDate)
        {
            decimal inCome = 0;

            StringBuilder sbSQL = new StringBuilder();

            sbSQL.AppendLine("select TotalMoney=SUM(csr_fConsumeMoney)");
            sbSQL.AppendLine("from dbo.ConsumeRecord_csr with(nolock)");
            sbSQL.AppendLine("join vie_AllStudentCardUserInfos with(nolock) on csr_cCardUserID = cus_cRecordID");
            sbSQL.AppendLine("where 1=1");
            sbSQL.AppendLine("and (csr_cConsumeType='" + Common.DefineConstantValue.ConsumeMachineType.StuPay.ToString() + "'");
            sbSQL.AppendLine("or csr_cConsumeType='" + Common.DefineConstantValue.ConsumeMachineType.DrinkPay.ToString() + "')");
            sbSQL.AppendLine("and csr_dConsumeDate>='" + startDate.ToString("yyyy-MM-dd") + " 00:00:00'");
            sbSQL.AppendLine("and csr_dConsumeDate<'" + endDate.AddDays(1).ToString("yyyy-MM-dd") + " 00:00:00'");

            try
            {
                using (SqlDataReader reader = DbHelperSQL.ExecuteReader(sbSQL.ToString()))
                {
                    if (reader.Read())
                    {
                        if (reader["TotalMoney"] != null && reader["TotalMoney"].ToString() != string.Empty)
                        {
                            inCome = decimal.Parse(reader["TotalMoney"].ToString());
                        }
                    }
                }
            }
            catch (Exception Ex)
            {

                throw Ex;
            }

            return inCome;
        }

        /// <summary>
        /// 热水房收入
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public decimal HotWaterIncome(DateTime startDate, DateTime endDate)
        {
            decimal inCome = 0;

            StringBuilder sbSQL = new StringBuilder();

            sbSQL.AppendLine("select *");

            sbSQL.AppendLine("from dbo.ConsumeRecord_csr");

            sbSQL.AppendLine("where 1=1");

            sbSQL.AppendLine("and csr_cConsumeType='" + Common.DefineConstantValue.ConsumeMachineType.HotWaterPay.ToString() + "'");

            sbSQL.AppendLine("and csr_dAddDate>='" + startDate.ToString("yyyy-MM-dd") + " 00:00:00'");

            sbSQL.AppendLine("and csr_dAddDate<'" + endDate.AddDays(1).ToString("yyyy-MM-dd") + " 00:00:00'");

            List<ConsumeRecord_csr_Info> returnList = new List<ConsumeRecord_csr_Info>();

            try
            {
                using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                {
                    IEnumerable<ConsumeRecord_csr_Info> query = db.ExecuteQuery<ConsumeRecord_csr_Info>(sbSQL.ToString(), new object[] { });

                    if (query != null)
                    {
                        returnList = query.ToList<ConsumeRecord_csr_Info>();

                        foreach (ConsumeRecord_csr_Info item in returnList)
                        {
                            inCome += item.csr_fConsumeMoney;
                        }
                    }
                }
            }
            catch (Exception Ex)
            {

                throw Ex;
            }


            return inCome;
        }

        /// <summary>
        /// 教师消费收入
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public decimal TeacherPayment(DateTime startDate, DateTime endDate)
        {
            decimal inCome = 0;

            StringBuilder sbSQL = new StringBuilder();

            sbSQL.AppendLine("select *");

            sbSQL.AppendLine("from dbo.ConsumeRecord_csr");

            sbSQL.AppendLine("where 1=1");

            sbSQL.AppendLine("and csr_cConsumeType='" + Common.DefineConstantValue.ConsumeMachineType.TeachPay.ToString() + "'");

            sbSQL.AppendLine("and csr_dAddDate>='" + startDate.ToString("yyyy-MM-dd") + " 00:00:00'");

            sbSQL.AppendLine("and csr_dAddDate<'" + endDate.AddDays(1).ToString("yyyy-MM-dd") + " 00:00:00'");


            List<ConsumeRecord_csr_Info> returnList = new List<ConsumeRecord_csr_Info>();

            try
            {
                using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                {
                    IEnumerable<ConsumeRecord_csr_Info> query = db.ExecuteQuery<ConsumeRecord_csr_Info>(sbSQL.ToString(), new object[] { });

                    if (query != null)
                    {
                        returnList = query.ToList<ConsumeRecord_csr_Info>();

                        foreach (ConsumeRecord_csr_Info item in returnList)
                        {
                            inCome += item.csr_fConsumeMoney;
                        }
                    }
                }
            }
            catch (Exception Ex)
            {

                throw Ex;
            }

            return inCome;
        }

        public decimal DrinkIncome(DateTime dtStart, DateTime dtEnd)
        {
            decimal inCome = 0;

            StringBuilder sbSQL = new StringBuilder();

            sbSQL.AppendLine("select *");

            sbSQL.AppendLine("from dbo.ConsumeRecord_csr");

            sbSQL.AppendLine("where 1=1");

            sbSQL.AppendLine("and csr_cConsumeType='" + Common.DefineConstantValue.ConsumeMachineType.DrinkPay.ToString() + "'");

            sbSQL.AppendLine("and csr_dAddDate>='" + dtStart.ToString("yyyy-MM-dd") + " 00:00:00'");

            sbSQL.AppendLine("and csr_dAddDate<'" + dtEnd.AddDays(1).ToString("yyyy-MM-dd") + " 00:00:00'");

            List<ConsumeRecord_csr_Info> returnList = new List<ConsumeRecord_csr_Info>();

            try
            {
                using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                {
                    IEnumerable<ConsumeRecord_csr_Info> query = db.ExecuteQuery<ConsumeRecord_csr_Info>(sbSQL.ToString(), new object[] { });

                    if (query != null)
                    {
                        returnList = query.ToList<ConsumeRecord_csr_Info>();

                        foreach (ConsumeRecord_csr_Info item in returnList)
                        {
                            inCome += item.csr_fConsumeMoney;
                        }
                    }
                }
            }
            catch (Exception Ex)
            {

                throw Ex;
            }

            return inCome;
        }

        /// <summary>
        /// 取得个人最后消费记录
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public ConsumeRecord_csr_Info GetLastRecord(ConsumeRecord_csr_Info query)
        {
            if (query != null)
            {
                try
                {
                    using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                    {
                        IEnumerable<ConsumeRecord_csr> searchRecord = (from t in db.ConsumeRecord_csr
                                                                       where t.csr_cCardUserID == query.csr_cCardUserID && t.csr_dConsumeDate <= query.csr_dConsumeDate
                                                                       orderby t.csr_dConsumeDate descending
                                                                       select t);

                        if (searchRecord != null && searchRecord.Count() > 0)
                        {
                            ConsumeRecord_csr info = searchRecord.First();

                            query = Common.General.CopyObjectValue<ConsumeRecord_csr, ConsumeRecord_csr_Info>(info);
                        }
                        else
                        {
                            query = null;
                        }
                    }
                }
                catch (Exception Ex)
                {

                    throw Ex;
                }
            }

            return query;
        }

        #endregion
    }
}
