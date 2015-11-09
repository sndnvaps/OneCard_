using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.IDAL.HHZX.ConsumeAccount;
using Model.General;
using Model.HHZX.ComsumeAccount;
using LinqToSQLModel;
using Model.IModel;
using Model.HHZX.Report;
using DAL.Factory.HHZX;
using DAL.IDAL.Report;
using System.Data.SqlClient;

namespace DAL.SqlDAL.HHZX.ConsumeAccount
{
    public class SystemAccountDetailDA : ISystemAccountDetailDA
    {
        IConsumeRecordDA _IConsumeRecordDA;

        IPayRecordDA _IPayRecordDA;

        public SystemAccountDetailDA()
        {
            this._IConsumeRecordDA = MasterDAFactory.GetDAL<IConsumeRecordDA>(MasterDAFactory.ConsumeRecord);

            this._IPayRecordDA = MasterDAFactory.GetDAL<IPayRecordDA>(MasterDAFactory.PayRecord);
        }

        public ReturnValueInfo InsertRecord(SystemAccountDetail_sad_Info infoObject)
        {
            ReturnValueInfo rvInfo = new ReturnValueInfo();
            try
            {
                if (infoObject != null)
                {
                    using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                    {
                        SystemAccountDetail_sad record = Common.General.CopyObjectValue<SystemAccountDetail_sad_Info, SystemAccountDetail_sad>(infoObject);
                        if (record != null)
                        {
                            db.SystemAccountDetail_sad.InsertOnSubmit(record);
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

        public ReturnValueInfo UpdateRecord(SystemAccountDetail_sad_Info infoObject)
        {
            ReturnValueInfo rvInfo = new ReturnValueInfo();
            try
            {
                if (infoObject != null)
                {
                    using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                    {
                        SystemAccountDetail_sad record = db.SystemAccountDetail_sad.Where(x => x.sad_cRecordID == infoObject.sad_cRecordID).FirstOrDefault();

                        if (record != null)
                        {
                            if (infoObject.sad_cConsumeID != null)
                                record.sad_cConsumeID = infoObject.sad_cConsumeID.Value;
                            record.sad_cFLowMoney = infoObject.sad_cFLowMoney;
                            record.sad_cFlowType = infoObject.sad_cFlowType;
                            record.sad_cOpt = infoObject.sad_cOpt;
                            record.sad_dOptTime = infoObject.sad_dOptTime;

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
                SystemAccountDetail_sad_Info infoObject = KeyObject as SystemAccountDetail_sad_Info;
                if (infoObject != null)
                {
                    using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                    {
                        SystemAccountDetail_sad record = db.SystemAccountDetail_sad.Where(x => x.sad_cRecordID == infoObject.sad_cRecordID).FirstOrDefault();

                        if (record != null)
                        {
                            db.SystemAccountDetail_sad.DeleteOnSubmit(record);

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

        public SystemAccountDetail_sad_Info DisplayRecord(IModelObject KeyObject)
        {
            SystemAccountDetail_sad_Info resInfo = null;
            try
            {
                SystemAccountDetail_sad_Info infoObject = KeyObject as SystemAccountDetail_sad_Info;
                if (infoObject != null)
                {
                    using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                    {
                        SystemAccountDetail_sad record = db.SystemAccountDetail_sad.Where(x => x.sad_cRecordID == infoObject.sad_cRecordID).FirstOrDefault();

                        if (record != null)
                        {
                            resInfo = Common.General.CopyObjectValue<SystemAccountDetail_sad, SystemAccountDetail_sad_Info>(record);
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

        public List<SystemAccountDetail_sad_Info> SearchRecords(IModelObject searchCondition)
        {
            List<SystemAccountDetail_sad_Info> listRecordInfo = null;
            try
            {
                StringBuilder sbSQL = new StringBuilder();
                sbSQL.AppendLine("SELECT TOP");
                sbSQL.AppendLine(Common.DefineConstantValue.ListRecordMaxCount.ToString());
                sbSQL.AppendLine("* FROM SystemAccountDetail_sad WHERE 1 = 1");

                SystemAccountDetail_sad_Info searchInfo = searchCondition as SystemAccountDetail_sad_Info;
                if (searchInfo != null)
                {
                    if (!string.IsNullOrEmpty(searchInfo.sad_cFlowType))
                        sbSQL.AppendLine("AND sad_cFlowType ='" + searchInfo.sad_cFlowType + "'");
                    if (searchInfo.sad_cConsumeID != Guid.Empty)
                        sbSQL.AppendLine("AND sad_cConsumeID ='" + searchInfo.sad_cConsumeID.ToString() + "'");
                    if (!string.IsNullOrEmpty(searchInfo.sad_cOpt))
                        if (searchInfo.sad_dOptTime != DateTime.MinValue)
                            sbSQL.AppendLine("AND sad_dOptTime ='" + searchInfo.sad_dOptTime.ToString("yyyy-MM-dd HH:mm") + "'");
                    if (searchInfo.sad_cFLowMoney != 0)
                        sbSQL.AppendLine("AND sad_cFLowMoney =" + searchInfo.sad_cFLowMoney);
                }

                using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                {
                    IEnumerable<SystemAccountDetail_sad_Info> query = db.ExecuteQuery<SystemAccountDetail_sad_Info>(sbSQL.ToString(), new object[] { });
                    if (query != null)
                    {
                        listRecordInfo = query.ToList<SystemAccountDetail_sad_Info>();
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return listRecordInfo;
        }

        public List<SystemAccountDetail_sad_Info> AllRecords()
        {
            List<SystemAccountDetail_sad_Info> listRecord = null;
            try
            {
                StringBuilder sbSQL = new StringBuilder();
                sbSQL.AppendLine("SELECT ");
                sbSQL.AppendLine("* FROM SystemAccountDetail_sad WHERE 1 = 1");

                using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                {
                    IEnumerable<SystemAccountDetail_sad_Info> query = db.ExecuteQuery<SystemAccountDetail_sad_Info>(sbSQL.ToString(), new object[] { });
                    if (query != null)
                    {
                        listRecord = query.ToList<SystemAccountDetail_sad_Info>();
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return listRecord;
        }

        public List<SystemAccountDetail_sad_Info> SearchDateSpanRecord(DateTime startDate, DateTime endDate)
        {
            List<SystemAccountDetail_sad_Info> result = new List<SystemAccountDetail_sad_Info>();

            try
            {
                using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                {
                    IEnumerable<SystemAccountDetail_sad> searchRecord = from t in db.SystemAccountDetail_sad
                                                                        where t.sad_cFlowType == "ReplaceCardCost"
                                                                        || t.sad_cFlowType == "Recharge_PersonalRealTime"
                                                                        || t.sad_cFlowType == "Recharge_PersonalTransfer"
                                                                        || t.sad_cFlowType == "Recharge_BatchTransfer"
                                                                        || t.sad_cFlowType == "AdvanceMealCost"
                                                                        || t.sad_cFlowType == "StuPay"
                                                                        || t.sad_cFlowType == "WaterRent"
                                                                        || t.sad_cFlowType == "TeachPay"
                                                                        && t.sad_cConsumeID == null
                                                                        && t.sad_dOptTime >= startDate
                                                                        && t.sad_dOptTime <= endDate
                                                                        select t;

                    if (searchRecord != null && searchRecord.Count() > 0)
                    {
                        foreach (SystemAccountDetail_sad item in searchRecord)
                        {
                            SystemAccountDetail_sad_Info info = Common.General.CopyObjectValue<SystemAccountDetail_sad, SystemAccountDetail_sad_Info>(item);

                            result.Add(info);
                        }
                    }
                }
            }
            catch (Exception Ex)
            {

                throw Ex;
            }

            return result;
        }

        /// <summary>
        /// 发卡部收入
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public decimal CardDepartmentIncome(DateTime startDate, DateTime endDate)
        {
            decimal inCome = 0;

            List<PreConsumeRecord_pcs> returnList = new List<PreConsumeRecord_pcs>();

            StringBuilder sbSQL = new StringBuilder();

            sbSQL.AppendLine("select TotalMoney=SUM(pcs_fCost)");
            sbSQL.AppendLine("from dbo.PreConsumeRecord_pcs with(nolock)");
            sbSQL.AppendLine("where 1=1 ");
            sbSQL.AppendLine("and ");
            sbSQL.AppendLine("( (pcs_cConsumeType='" + Common.DefineConstantValue.ConsumeMoneyFlowType.ReplaceCardCost.ToString() + "' )");
            sbSQL.AppendLine("or (pcs_cConsumeType='" + Common.DefineConstantValue.ConsumeMoneyFlowType.NewCardCost.ToString() + "' )");
            sbSQL.AppendLine(") ");
            sbSQL.AppendLine("and pcs_dAddDate>='" + startDate.ToString("yyyy-MM-dd") + " 00:00:00' ");
            sbSQL.AppendLine("and pcs_dAddDate<'" + endDate.AddDays(1).ToString("yyyy-MM-dd") + " 00:00:00' ");
            sbSQL.AppendLine("and pcs_fCost > 0");

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
        /// 订餐部收入
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public decimal BookDepartmentIncome(DateTime startDate, DateTime endDate)
        {
            decimal inCome = 0;

            StringBuilder sbWherePublic = new StringBuilder();
            sbWherePublic.Append(" between '" + startDate.ToString("yyyy-MM-dd 00:00:00") + "' and '" + endDate.ToString("yyyy-MM-dd 23:59:59") + "'");

            StringBuilder sbSQLPreCost = new StringBuilder();

            sbSQLPreCost.AppendLine(@"select cuad_fFlowMoney
from CardUserAccountDetail_cuad with(nolock) 
join vie_AllStudentCardUserInfos on cua_cRecordID=cuad_cCUAID
join PreConsumeRecord_pcs with(nolock) on cuad_cConsumeID = pcs_cRecordID
where cuad_cFlowType = 'SetMealCost'");
            sbSQLPreCost.AppendLine("and pcs_dConsumeDate " + sbWherePublic.ToString());

            StringBuilder sbSQLCardCost = new StringBuilder();
            sbSQLCardCost.AppendLine(@"union all
(select cuad_fFlowMoney
from CardUserAccountDetail_cuad with(nolock) 
join vie_AllStudentCardUserInfos on cua_cRecordID=cuad_cCUAID
join ConsumeRecord_csr with(nolock)  on cuad_cConsumeID = csr_cRecordID
where cuad_cFlowType = 'SetMealCost'");
            sbSQLCardCost.AppendLine("and csr_dConsumeDate" + sbWherePublic.ToString() + ")");

            //            StringBuilder sbSQLUnknowCost = new StringBuilder();
            //            sbSQLUnknowCost.AppendLine(@"union
            //(select [cuad_cRecordID],[cuad_cCUAID],[cuad_fFlowMoney],[cuad_cFlowType],[cuad_cConsumeID],[cuad_cOpt],'UnknowCost' as TypeNum
            //, cuad_dOptTime as CostDate,csr_cRecordID as CostID
            //from CardUserAccountDetail_cuad with(nolock) 
            //join PreConsumeRecord_pcs with(nolock)  on cuad_cConsumeID = pcs_cRecordID
            //join ConsumeRecord_csr with(nolock)  on cuad_cConsumeID = csr_cRecordID
            //where cuad_cFlowType = 'SetMealCost'");
            //            sbSQLUnknowCost.AppendLine("and cuad_dOptTime" + sbWherePublic.ToString() + ")");

            try
            {
                string strSQL = "select TotalMoney=SUM(cuad_fFlowMoney) from( " + sbSQLPreCost.ToString() + sbSQLCardCost.ToString() /*+ sbSQLUnknowCost.ToString()*/+ ")A";

                using (SqlDataReader reader = DbHelperSQL.ExecuteReader(strSQL))
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
        /// 教师饭堂消费
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        private decimal TeacherPayment(DateTime startDate, DateTime endDate)
        {
            decimal inCome = 0;

            List<ConsumeRecord_csr> returnList = new List<ConsumeRecord_csr>();

            StringBuilder sbSQL = new StringBuilder();

            sbSQL.AppendLine("select TotalMoney=SUM(csr_fConsumeMoney) from ConsumeRecord_csr with(nolock)");
            sbSQL.AppendLine("join dbo.CardUserMaster_cus with(nolock) on csr_cCardUserID = cus_cRecordID");
            sbSQL.AppendLine("where cus_cIdentityNum = '" + Common.DefineConstantValue.MasterType.Staff.ToString() + "'");
            sbSQL.AppendLine("and csr_dConsumeDate >='" + startDate.ToString("yyyy-MM-dd") + " 00:00:00'");
            sbSQL.AppendLine("and csr_dConsumeDate < '" + endDate.AddDays(1).ToString("yyyy-MM-dd") + " 00:00:00'");
            sbSQL.AppendLine("and csr_cConsumeType <> '" + Common.DefineConstantValue.ConsumeMachineType.HotWaterPay.ToString() + "'");//筛选出热水机数据
            sbSQL.AppendLine("and csr_cConsumeType <> '" + Common.DefineConstantValue.ConsumeMachineType.DrinkPay.ToString() + "'");//筛选出饮料机数据
            sbSQL.AppendLine("and csr_cConsumeType <> '" + Common.DefineConstantValue.ConsumeMachineType.StuPay.ToString() + "'");//筛选出学生加菜机数据

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
        /// 用户未付款总额
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        decimal TotalUnPayPreCost(DateTime startDate, DateTime endDate)
        {
            decimal fTotalPreCost = decimal.Zero;
            try
            {
                StringBuilder sbSQL = new StringBuilder();
                sbSQL.AppendLine("select TotalMoney=SUM(pcs_fCost) from PreConsumeRecord_pcs with(nolock)");
                sbSQL.AppendLine("where pcs_lIsSettled = 0");
                sbSQL.AppendLine("and (pcs_cConsumeType = '" + Common.DefineConstantValue.ConsumeMoneyFlowType.SetMealCost.ToString() + "' or pcs_cConsumeType = '" + Common.DefineConstantValue.ConsumeMoneyFlowType.NewCardCost.ToString() + "' or pcs_cConsumeType = '" + Common.DefineConstantValue.ConsumeMoneyFlowType.ReplaceCardCost.ToString() + "')");
                sbSQL.AppendLine("and pcs_dAddDate >= '" + startDate.ToString("yyyy-MM-dd") + " 00:00:00'");
                sbSQL.AppendLine("and pcs_dAddDate < '" + endDate.AddDays(1).ToString("yyyy-MM-dd") + " 00:00:00'");

                using (SqlDataReader reader = DbHelperSQL.ExecuteReader(sbSQL.ToString()))
                {
                    if (reader.Read())
                    {
                        if (reader["TotalMoney"] != null && reader["TotalMoney"].ToString() != string.Empty)
                        {
                            fTotalPreCost = decimal.Parse(reader["TotalMoney"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return fTotalPreCost;
        }

        public DepartmentBalance_dtb_Info DepartmentBalance(DepartmentBalance_dtb_Info query)
        {
            if (query != null)
            {
                try
                {
                    //定餐部收入
                    query.dtb_iSetmealIncome = BookDepartmentIncome(query.startDate.Value, query.endDate.Value);

                    //加菜机收入
                    query.dtb_iStudentPlusIncome = this._IConsumeRecordDA.CanteenPlusIncome(query.startDate.Value, query.endDate.Value);

                    //发卡部收入
                    query.dtb_iCardDepartmentIncome = CardDepartmentIncome(query.startDate.Value, query.endDate.Value);

                    //教师用餐收入
                    query.dtb_iTeacherSetmealIncome = TeacherPayment(query.startDate.Value, query.endDate.Value);

                    //热水部收入
                    query.dtb_iHotWaterIncome = GetHotIncome(query.startDate.Value, query.endDate.Value);

                    //其他收入
                    query.dtb_iOtherIncome = GetOrtherIncome(query.startDate.Value, query.endDate.Value);

                    //定餐部支出
                    query.dtb_iSetmealPay = this._IPayRecordDA.PaymentCount(query.startDate.Value, query.endDate.Value);

                    query.dtb_fUnpayPreCost = TotalUnPayPreCost(query.startDate.Value, query.endDate.Value);
                }
                catch (Exception Ex)
                {

                    throw Ex;
                }
            }

            return query;
        }

        public decimal GetHotIncome(DateTime dtQuery)
        {
            decimal fReturn = decimal.Zero;
            try
            {
                StringBuilder sbSQL = new StringBuilder();
                sbSQL.AppendLine("SELECT rid_fHotIncome FROM ReportIncomeDetail_rid");
                sbSQL.AppendLine("WHERE rid_cDateNo = '" + dtQuery.ToString("yyyy-MM-dd") + "'");
                using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                {
                    decimal fSource = db.ExecuteQuery<decimal>(sbSQL.ToString(), new object[] { }).FirstOrDefault();
                    fReturn = fSource;
                }
            }
            catch (Exception ex)
            {
                return decimal.Zero;
            }
            return fReturn;
        }

        public decimal GetHotIncome(DateTime dtBegin, DateTime dtEnd)
        {
            decimal fReturn = decimal.Zero;
            try
            {
                StringBuilder sbSQL = new StringBuilder();
                sbSQL.AppendLine("SELECT SUM(rid_fHotIncome) FROM ReportIncomeDetail_rid with(nolock)");
                sbSQL.AppendLine("WHERE rid_dRecDate between '" + dtBegin.ToString("yyyy-MM-dd 00:00") + "' and '" + dtEnd.ToString("yyyy-MM-dd 23:59") + "'");
                using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                {
                    decimal fSource = db.ExecuteQuery<decimal>(sbSQL.ToString(), new object[] { }).FirstOrDefault();
                    fReturn = fSource;
                }
            }
            catch (Exception ex)
            {
                return decimal.Zero;
            }
            return fReturn;
        }

        public decimal GetOrtherIncome(DateTime dtQuery)
        {
            decimal fReturn = decimal.Zero;
            try
            {
                StringBuilder sbSQL = new StringBuilder();

                sbSQL.AppendLine("SELECT rid_fOrtherIncome FROM ReportIncomeDetail_rid");
                sbSQL.AppendLine("WHERE rid_cDateNo = '" + dtQuery.ToString("yyyy-MM-dd") + "'");
                using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                {
                    decimal fSource = db.ExecuteQuery<decimal>(sbSQL.ToString(), new object[] { }).FirstOrDefault();
                    fReturn = fSource;
                }
            }
            catch (Exception ex)
            {
                return decimal.Zero;
            }
            return fReturn;
        }

        public decimal GetOrtherIncome(DateTime dtBegin, DateTime dtEnd)
        {
            decimal fReturn = decimal.Zero;
            try
            {
                StringBuilder sbSQL = new StringBuilder();
                sbSQL.AppendLine("SELECT SUM(rid_fOrtherIncome) FROM ReportIncomeDetail_rid with(nolock)");
                sbSQL.AppendLine("WHERE rid_dRecDate between '" + dtBegin.ToString("yyyy-MM-dd 00:00") + "' and '" + dtEnd.ToString("yyyy-MM-dd 23:59") + "'");
                using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                {
                    decimal fSource = db.ExecuteQuery<decimal>(sbSQL.ToString(), new object[] { }).FirstOrDefault();
                    fReturn = fSource;
                }
            }
            catch (Exception ex)
            {
                return decimal.Zero;
            }
            return fReturn;
        }

        public ReturnValueInfo SetHotIncome(DateTime dtQuery, decimal fIncome)
        {
            ReturnValueInfo rvInfo = new ReturnValueInfo();
            try
            {
                StringBuilder sbSQL = new StringBuilder();
                sbSQL.AppendLine("if exists(select top 1 1 from dbo.ReportIncomeDetail_rid where rid_cDateNo='" + dtQuery.ToString("yyyy-MM-dd") + "')");
                sbSQL.AppendLine("begin");
                sbSQL.AppendLine("UPDATE ReportIncomeDetail_rid SET rid_fHotIncome=" + Math.Round(fIncome, 2).ToString());
                sbSQL.AppendLine("WHERE rid_cDateNo = '" + dtQuery.ToString("yyyy-MM-dd") + "'");
                sbSQL.AppendLine("end");
                sbSQL.AppendLine("else");
                sbSQL.AppendLine("begin");
                sbSQL.AppendLine("insert into ReportIncomeDetail_rid(rid_cDateNo,rid_fHotIncome,rid_fOrtherIncome,rid_dRecDate)values(");
                sbSQL.AppendLine("'" + dtQuery.ToString("yyyy-MM-dd") + "'," + fIncome.ToString() + ",0,'" + dtQuery.ToString("yyyy-MM-dd HH:mm:ss") + "')");
                sbSQL.AppendLine("end");
                using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                {
                    var res = db.ExecuteQuery(typeof(string), sbSQL.ToString(), new object[] { });
                    rvInfo.boolValue = true;
                }
            }
            catch (Exception ex)
            {
                rvInfo.isError = true;
                rvInfo.messageText = ex.Message;
                return rvInfo;
            }
            return rvInfo;
        }

        public ReturnValueInfo SetOrtherIncome(DateTime dtQuery, decimal fIncome)
        {
            ReturnValueInfo rvInfo = new ReturnValueInfo();
            try
            {
                StringBuilder sbSQL = new StringBuilder();
                sbSQL.AppendLine("if exists(select top 1 1 from dbo.ReportIncomeDetail_rid where rid_cDateNo='" + dtQuery.ToString("yyyy-MM-dd") + "')");
                sbSQL.AppendLine("begin");
                sbSQL.AppendLine("UPDATE ReportIncomeDetail_rid SET rid_fOrtherIncome=" + Math.Round(fIncome, 2).ToString());
                sbSQL.AppendLine("WHERE rid_cDateNo = '" + dtQuery.ToString("yyyy-MM-dd") + "'");
                sbSQL.AppendLine("end");
                sbSQL.AppendLine("else");
                sbSQL.AppendLine("begin");
                sbSQL.AppendLine("insert into ReportIncomeDetail_rid(rid_cDateNo,rid_fHotIncome,rid_fOrtherIncome,rid_dRecDate)values(");
                sbSQL.AppendLine("'" + dtQuery.ToString("yyyy-MM-dd") + "',0," + fIncome.ToString() + ",'" + dtQuery.ToString("yyyy-MM-dd HH:mm:ss") + "')");
                sbSQL.AppendLine("end");
                using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                {
                    var res = db.ExecuteQuery(typeof(string), sbSQL.ToString(), new object[] { });
                    rvInfo.boolValue = true;
                }
            }
            catch (Exception ex)
            {
                rvInfo.isError = true;
                rvInfo.messageText = ex.Message;
                return rvInfo;
            }
            return rvInfo;
        }
    }
}
