using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.IDAL.HHZX.ConsumeAccount;
using Model.General;
using Model.HHZX.ComsumeAccount;
using LinqToSQLModel;
using Model.IModel;
using DAL.IDAL.HHZX.UserInformation.CardUserInfo;
using DAL.Factory.HHZX;
using Model.HHZX.UserInfomation.CardUserInfo;
using System.Data;
using System.Data.SqlClient;

namespace DAL.SqlDAL.HHZX.ConsumeAccount
{
    /// <summary>
    /// 卡用户账户余额信息
    /// </summary>
    public class CardUserAccountDA : ICardUserAccountDA
    {
        public ReturnValueInfo InsertRecord(CardUserAccount_cua_Info infoObject)
        {
            ReturnValueInfo rvInfo = new ReturnValueInfo();
            try
            {
                if (infoObject != null)
                {
                    using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                    {
                        CardUserAccount_cua record = Common.General.CopyObjectValue<CardUserAccount_cua_Info, CardUserAccount_cua>(infoObject);
                        if (record != null)
                        {
                            db.CardUserAccount_cua.InsertOnSubmit(record);
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

        public ReturnValueInfo UpdateRecord(CardUserAccount_cua_Info infoObject)
        {
            ReturnValueInfo rvInfo = new ReturnValueInfo();
            try
            {
                if (infoObject != null)
                {
                    using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                    {
                        CardUserAccount_cua record = db.CardUserAccount_cua.Where(x => x.cua_cRecordID == infoObject.cua_cRecordID).FirstOrDefault();

                        if (record != null)
                        {
                            record.cua_cCUSID = infoObject.cua_cCUSID;
                            record.cua_dLastSyncTime = infoObject.cua_dLastSyncTime;
                            record.cua_fCurrentBalance = infoObject.cua_fCurrentBalance;
                            record.cua_fOriginalBalance = infoObject.cua_fOriginalBalance;
                            record.cua_lIsActive = infoObject.cua_lIsActive;
                            record.cua_cAdd = infoObject.cua_cAdd;
                            record.cua_dAddDate = infoObject.cua_dAddDate;

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
                CardUserAccount_cua_Info infoObject = KeyObject as CardUserAccount_cua_Info;
                if (infoObject != null)
                {
                    using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                    {
                        CardUserAccount_cua record = db.CardUserAccount_cua.Where(x => x.cua_cRecordID == infoObject.cua_cRecordID).FirstOrDefault();

                        if (record != null)
                        {
                            db.CardUserAccount_cua.DeleteOnSubmit(record);

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

        public CardUserAccount_cua_Info DisplayRecord(IModelObject KeyObject)
        {
            CardUserAccount_cua_Info resInfo = null;
            try
            {
                CardUserAccount_cua_Info infoObject = KeyObject as CardUserAccount_cua_Info;
                if (infoObject != null)
                {
                    using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                    {
                        CardUserAccount_cua record = db.CardUserAccount_cua.Where(x => x.cua_cRecordID == infoObject.cua_cRecordID).FirstOrDefault();
                        if (record != null)
                        {
                            resInfo = Common.General.CopyObjectValue<CardUserAccount_cua, CardUserAccount_cua_Info>(record);
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

        public CardUserAccount_cua_Info SyncAccount(IModelObject KeyObject, DateTime dtDeadline)
        {
            CardUserAccount_cua_Info resInfo = null;
            try
            {
                CardUserAccount_cua_Info infoObject = KeyObject as CardUserAccount_cua_Info;
                if (infoObject != null)
                {
                    using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                    {
                        db.CommandTimeout = 10 * 60000;
                        CardUserAccount_cua record = db.CardUserAccount_cua.Where(x => x.cua_cRecordID == infoObject.cua_cRecordID).FirstOrDefault();
                        if (record != null)
                        {
                            StringBuilder sbSQL = new StringBuilder();
                            sbSQL.AppendLine(@"SELECT cua_cRecordID,cua_cCUSID,cua_fOriginalBalance,");
                            sbSQL.AppendLine(@"ISNULL(TotalCost.cua_fCurrentBalance,0.00) as cua_fCurrentBalance,");
                            sbSQL.AppendLine(@"ISNULL(TotalCost.cua_dLastSyncTime,GETDATE()) as cua_dLastSyncTime,");
                            sbSQL.AppendLine(@"cua_lIsActive, cua_cAdd, cua_dAddDate FROM dbo.CardUserAccount_cua");
                            sbSQL.AppendLine(@"INNER JOIN (SELECT * FROM(");
                            sbSQL.AppendLine(@"SELECT SUM(FormulaRes) as cua_fCurrentBalance,MAX(cuad_dOptTime) AS cua_dLastSyncTime");
                            sbSQL.AppendLine(@"FROM (SELECT *,(cuad_fFlowMoney * cmt_fNumber) AS FormulaRes FROM CardUserAccountDetail_cuad ");
                            sbSQL.AppendLine(@"INNER JOIN CardUserAccount_cua ON  cua_cRecordID = cuad_cCUAID");
                            sbSQL.AppendLine(@"AND cua_cCUSID = '" + record.cua_cCUSID + "'");
                            sbSQL.AppendLine(@"AND cuad_dOptTime <='" + dtDeadline + "'");
                            sbSQL.AppendLine(@"LEFT JOIN CodeMaster_cmt ON cmt_cKey1 = 'ACCOUNTFORMULA_USER' AND cmt_cKey2 = cuad_cFlowType) AS A) AS AA) AS TotalCost");
                            sbSQL.AppendLine(@"on  cua_cCUSID ='" + record.cua_cCUSID + "'");

                            IEnumerable<CardUserAccount_cua_Info> query = db.ExecuteQuery<CardUserAccount_cua_Info>(sbSQL.ToString(), new object[] { });
                            if (query != null)
                            {
                                List<CardUserAccount_cua_Info> listRes = query.ToList();
                                if (listRes.Count > 0)
                                {
                                    CardUserAccount_cua_Info accRev = listRes[0];
                                    record.cua_fCurrentBalance = accRev.cua_fCurrentBalance;
                                    record.cua_dLastSyncTime = dtDeadline;
                                    if (dtDeadline.Date == DateTime.Now.AddDays(-1))
                                    {
                                        db.SubmitChanges();
                                    }
                                }
                            }

                            resInfo = Common.General.CopyObjectValue<CardUserAccount_cua, CardUserAccount_cua_Info>(record);
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

        public List<CardUserAccount_cua_Info> SearchRecords(IModelObject searchCondition)
        {
            List<CardUserAccount_cua_Info> listRecordInfo = null;
            try
            {
                StringBuilder sbSQL = new StringBuilder();
                sbSQL.AppendLine("SELECT TOP");
                sbSQL.AppendLine(Common.DefineConstantValue.ListRecordMaxCount.ToString());
                sbSQL.AppendLine("* FROM CardUserAccount_cua  WHERE 1 = 1");

                CardUserAccount_cua_Info searchInfo = searchCondition as CardUserAccount_cua_Info;
                if (searchInfo != null)
                {
                    if (searchInfo.cua_cCUSID != Guid.Empty)
                        sbSQL.AppendLine("AND cua_cCUSID ='" + searchInfo.cua_cCUSID.ToString() + "'");
                    if (searchInfo.cua_dLastSyncTime != DateTime.MinValue)
                        sbSQL.AppendLine("AND cua_dLastSyncTime ='" + searchInfo.cua_dLastSyncTime.ToString("yyyy-MM-dd HH:mm") + "'");
                    if (!string.IsNullOrEmpty(searchInfo.cua_cAdd))
                        sbSQL.AppendLine("AND cua_cAdd ='" + searchInfo.cua_cAdd + "'");
                    if (searchInfo.cua_dAddDate != DateTime.MinValue)
                        sbSQL.AppendLine("AND cua_dAddDate ='" + searchInfo.cua_dAddDate.ToString("yyyy-MM-dd HH:mm") + "'");
                    if (searchInfo.cua_fCurrentBalance != 0)
                        sbSQL.AppendLine("AND cua_fCurrentBalance =" + searchInfo.cua_fCurrentBalance);
                    if (searchInfo.cua_fOriginalBalance != 0)
                        sbSQL.AppendLine("AND cua_fOriginalBalance =" + searchInfo.cua_fOriginalBalance);
                }

                using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                {
                    IEnumerable<CardUserAccount_cua_Info> query = db.ExecuteQuery<CardUserAccount_cua_Info>(sbSQL.ToString(), new object[] { });
                    if (query != null)
                    {
                        listRecordInfo = query.ToList<CardUserAccount_cua_Info>();
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return listRecordInfo;
        }

        public List<CardUserAccount_cua_Info> AllRecords()
        {
            List<CardUserAccount_cua_Info> listRecord = null;
            try
            {
                StringBuilder sbSQL = new StringBuilder();
                sbSQL.AppendLine("SELECT ");
                sbSQL.AppendLine("* FROM CardUserAccount_cua WHERE 1 = 1");

                using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                {
                    IEnumerable<CardUserAccount_cua_Info> query = db.ExecuteQuery<CardUserAccount_cua_Info>(sbSQL.ToString(), new object[] { });
                    if (query != null)
                    {
                        listRecord = query.ToList<CardUserAccount_cua_Info>();
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return listRecord;
        }

        public List<CardUserAccount_cua_Info> GetRemindList(string identityNum, Guid departmentID, decimal Balance, bool lWithFilter, string userName)
        {
            List<CardUserAccount_cua_Info> reminList = new List<CardUserAccount_cua_Info>();

            string sqlStr = string.Empty;

            sqlStr += "select * from (" + Environment.NewLine;

            sqlStr += "select  cua_cCUSID,ISNULL( cus_cChaName,'') as cua_cUserName,cus_cStudentID," + Environment.NewLine;

            sqlStr += "case cus_cIdentityNum " + Environment.NewLine;

            sqlStr += "when '" + Common.DefineConstantValue.CodeMasterDefine.KEY2_SIOT_CardUserIdentity_Staff + "' then ISNULL( dpm_cName,'')" + Environment.NewLine;

            sqlStr += "when '" + Common.DefineConstantValue.CodeMasterDefine.KEY2_SIOT_CardUserIdentity_Student + "' then ISNULL( csm_cClassName,'')" + Environment.NewLine;

            sqlStr += "else ''" + Environment.NewLine;

            sqlStr += "end as cua_cClassName," + Environment.NewLine;

            sqlStr += "ISNULL( cua_fCurrentBalance,0.00)-ISNULL( lco.pcscost,0.00)+ISNULL(prrRecharge,0.00) as TotalBalance," + Environment.NewLine;

            sqlStr += "ISNULL(cua_fCurrentBalance,0.00) as cua_fCurrentBalance,";
            sqlStr += "ISNULL(lco.pcscost,0.00) as Pcscost,";
            sqlStr += "ISNULL(prrRecharge,0.00) as PreRechargeMoney,";

            sqlStr += "cua_dLastSyncTime" + Environment.NewLine;

            sqlStr += ",cus_cBankAccount as BankAccount,cus_cContractName as ParentName,cus_cContractPhone as ParentPhone" + Environment.NewLine;

            sqlStr += "from dbo.CardUserAccount_cua with(nolock)" + Environment.NewLine;

            sqlStr += "left join dbo.CardUserMaster_cus with(nolock)" + Environment.NewLine;

            sqlStr += "on cus_cRecordID=cua_cCUSID" + Environment.NewLine;

            sqlStr += "left join dbo.ClassMaster_csm with(nolock)" + Environment.NewLine;

            sqlStr += "on cus_cClassID=csm_cRecordID" + Environment.NewLine;

            sqlStr += "left join dbo.DepartmentMaster_dpm with(nolock)" + Environment.NewLine;

            sqlStr += "on cus_cClassID=dpm_RecordID" + Environment.NewLine;

            sqlStr += "left join " + Environment.NewLine;
            sqlStr += "(select pcs_cUserID,Sum(pcs_fCost) as pcscost from PreConsumeRecord_pcs with(nolock) where " + Environment.NewLine;
            sqlStr += "(pcs_cConsumeType = 'NewCardCost' or pcs_cConsumeType = 'SetMealCost' or pcs_cConsumeType = 'ReplaceCardCost')" + Environment.NewLine;
            sqlStr += "and pcs_lIsSettled = 0 group by pcs_cUserID ) lco " + Environment.NewLine;
            sqlStr += "on lco.pcs_cUserID = cua_cCUSID" + Environment.NewLine;

            sqlStr += "left join" + Environment.NewLine;
            sqlStr += "(select prr_cUserID,SUM(prr_fRechargeMoney)as prrRecharge from PreRechargeRecord_prr with(nolock)" + Environment.NewLine;
            sqlStr += "where prr_cRCRID is null and prr_cStatus= '" + Common.DefineConstantValue.ConsumeMoneyFlowStatus.WaitForAcceptTransfer.ToString() + "'" + Environment.NewLine;
            sqlStr += "group by prr_cUserID)  PreRec on PreRec.prr_cUserID = cua_cCUSID" + Environment.NewLine;//预充值款

            sqlStr += "where 1=1 and cus_lValid=1 and cus_lIsGraduate=0" + Environment.NewLine;

            //sqlStr += "and (cua_fCurrentBalance - ISNULL( lco.pcscost,0.00))<" + Balance.ToString() + Environment.NewLine;

            if (identityNum != "")
            {
                sqlStr += "and cus_cIdentityNum='" + identityNum + "'" + Environment.NewLine;
            }

            if (departmentID != Guid.Empty)
            {
                sqlStr += "and cus_cClassID='" + departmentID.ToString() + "'" + Environment.NewLine;
            }

            if (!string.IsNullOrEmpty(userName))
            {
                sqlStr += "and cus_cChaName like N'%" + userName + "%'" + Environment.NewLine;
            }

            if (lWithFilter)
            {
                sqlStr += @"and cus_cRecordID not  in
(
select pus_cCardUserID from (
select pus_cCardUserID,COUNT(pus_cCardUserID) as UserCount from PaymentUDGeneralSetting_pus with(nolock)
where pus_cBreakfast = 0 and pus_cLunch = 0 and pus_cDinner = 0
group by pus_cCardUserID
)as UserItem where UserCount = 7 and pus_cCardUserID is not null
union
select cus_cRecordID from CardUserMaster_cus with(nolock)  where cus_cClassID in(
select pus_cClassID from
(
select pus_cClassID,COUNT(pus_cClassID)as ClassCount  from PaymentUDGeneralSetting_pus with(nolock)
where pus_cBreakfast = 0 and pus_cLunch = 0 and pus_cDinner = 0
group by pus_cClassID
) as ClassItem where ClassCount = 7 and pus_cClassID is not null
union
(
select csm_cRecordID from ClassMaster_csm with(nolock) where csm_cGDMID in
(
select pus_cGradeID from (
select pus_cGradeID,COUNT(pus_cGradeID) as GradeCount from PaymentUDGeneralSetting_pus with(nolock)
where pus_cBreakfast = 0 and pus_cLunch = 0 and pus_cDinner = 0
group by pus_cGradeID
) as GradeItem where GradeCount = 7 and pus_cGradeID is not null))))
and cus_lValid=1 and cus_lIsGraduate=0" + Environment.NewLine;
            }

            sqlStr += ") as AAA where TotalBalance < " + Balance.ToString() + Environment.NewLine;

            try
            {
                using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                {
                    db.CommandTimeout = 10 * 60000;
                    IEnumerable<CardUserAccount_cua_Info> query = db.ExecuteQuery<CardUserAccount_cua_Info>(sqlStr.ToString(), new object[] { });
                    if (query != null)
                    {
                        reminList = query.ToList<CardUserAccount_cua_Info>();

                        #region 执行查询用户预计定餐消费额

                        DataTable dtAll = new DataTable("TableAll");
                        SqlConnection sqlconn = new SqlConnection(db.Connection.ConnectionString);

                        DateTime dtStart = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-01 00:00")).AddMonths(1);
                        int iDays = DateTime.DaysInMonth(dtStart.Year, dtStart.Month);

                        #region  循环获取用户每天的开餐情况

                        for (int i = 0; i < iDays; i++)
                        {
                            DateTime dtUse = dtStart.AddDays(i);

                            SqlCommand cmd = new SqlCommand("usp_GetUDMealSetting", sqlconn);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandTimeout = 300;

                            SqlParameter[] parameters = { 
                    new SqlParameter("@StartDate", SqlDbType.DateTime), 
                    new SqlParameter("@GradeID", SqlDbType.UniqueIdentifier),
                    new SqlParameter("@ClassID", SqlDbType.UniqueIdentifier),
                    new SqlParameter("@UserID", SqlDbType.UniqueIdentifier),
                    new SqlParameter("@UserName", SqlDbType.NVarChar,50),
                    new SqlParameter("@UserNum", SqlDbType.VarChar,30)};

                            parameters[0].Value = dtUse;//查询日期
                            parameters[1].Value = Guid.Empty;//年级ID
                            parameters[2].Value = Guid.Empty;//班级ID
                            parameters[3].Value = Guid.Empty;//人员ID
                            if (!string.IsNullOrEmpty(userName))//人员姓名
                            {
                                parameters[4].Value = userName;
                            }
                            else
                            {
                                parameters[4].Value = string.Empty;
                            }
                            parameters[5].Value = string.Empty;//人员编号

                            cmd.Parameters.Add(parameters[0]);
                            cmd.Parameters.Add(parameters[1]);
                            cmd.Parameters.Add(parameters[2]);
                            cmd.Parameters.Add(parameters[3]);
                            cmd.Parameters.Add(parameters[4]);
                            cmd.Parameters.Add(parameters[5]);
                            sqlconn.Open();

                            SqlDataAdapter dp = new SqlDataAdapter(cmd);

                            dp.Fill(dtAll);
                            int iCount = dtAll.Rows.Count;

                            sqlconn.Close();
                        }

                        #endregion

                        List<UserMealDetail_Tmp> listMealDetail = new List<UserMealDetail_Tmp>();
                        if (dtAll != null && dtAll.Rows.Count > 0)
                        {
                            for (int i = 0; i < dtAll.Rows.Count; i++)
                            {
                                UserMealDetail_Tmp detail_Info = new UserMealDetail_Tmp();
                                detail_Info.UserID = new Guid(dtAll.Rows[i]["UserID"].ToString());
                                detail_Info.Breakfast = Convert.ToInt32(dtAll.Rows[i]["UD_Breakfast"]);
                                detail_Info.Lunch = Convert.ToInt32(dtAll.Rows[i]["UD_Lunch"]);
                                detail_Info.Dinner = Convert.ToInt32(dtAll.Rows[i]["UD_Dinner"]);
                                listMealDetail.Add(detail_Info);
                            }
                        }

                        #endregion

                        var groupMealDetail = listMealDetail.GroupBy(x => x.UserID);
                        foreach (var mealItem in groupMealDetail)
                        {
                            Guid userID = mealItem.Key;
                            CardUserAccount_cua_Info sumInfo = reminList.Find(x => x.cua_cCUSID == userID);
                            if (sumInfo != null)
                            {
                                int iBreakfast = mealItem.Sum(x => x.Breakfast);
                                int iLunch = mealItem.Sum(x => x.Lunch);
                                int iDinner = mealItem.Sum(x => x.Dinner);
                                sumInfo.NextMonthPreRecharge = iBreakfast * 2.00M + iLunch * 4.00M + iDinner * 4.00M;
                            }
                        }


                    }
                }
            }
            catch (Exception Ex)
            {

                throw Ex;
            }


            return reminList;
        }

        /// <summary>
        /// 用户临时每天就餐情况
        /// </summary>
        class UserMealDetail_Tmp
        {
            public Guid UserID { get; set; }
            public int Breakfast { get; set; }
            public int Lunch { get; set; }
            public int Dinner { get; set; }
        }

        public ReturnValueInfo AccountCashReFund(IModelObject infoObject, string strReason)
        {
            ReturnValueInfo rvInfo = new ReturnValueInfo();
            CardUserAccountDetail_cuad_Info userDetailInfo = infoObject as CardUserAccountDetail_cuad_Info;
            if (userDetailInfo == null)
            {
                rvInfo.messageText = "对象类型不符合，参数需要为SystemAccountDetail_sad_Info类";
                rvInfo.isError = true;
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
                        PreConsumeRecord_pcs preCost = new PreConsumeRecord_pcs();
                        preCost.pcs_cAccountID = userDetailInfo.cuad_cCUAID;
                        preCost.pcs_cAdd = userDetailInfo.cuad_cOpt;
                        preCost.pcs_dAddDate = DateTime.Now;
                        preCost.pcs_cConsumeType = userDetailInfo.cuad_cFlowType;
                        preCost.pcs_cRecordID = Guid.NewGuid();
                        CardUserAccount_cua userAccount = db.CardUserAccount_cua.Where(x => x.cua_cRecordID == userDetailInfo.cuad_cCUAID).FirstOrDefault();
                        preCost.pcs_cUserID = userAccount.cua_cCUSID;
                        preCost.pcs_dConsumeDate = DateTime.Now;
                        preCost.pcs_dSettleTime = DateTime.Now;
                        preCost.pcs_fCost = userDetailInfo.cuad_fFlowMoney;
                        preCost.pcs_lIsSettled = true;
                        db.PreConsumeRecord_pcs.InsertOnSubmit(preCost);
                        userAccount.cua_fCurrentBalance -= userDetailInfo.cuad_fFlowMoney;
                        db.SubmitChanges();

                        CardUserAccountDetail_cuad userDetail = Common.General.CopyObjectValue<CardUserAccountDetail_cuad_Info, CardUserAccountDetail_cuad>(userDetailInfo);
                        userDetail.cuad_cConsumeID = preCost.pcs_cRecordID;
                        db.CardUserAccountDetail_cuad.InsertOnSubmit(userDetail);
                        db.SubmitChanges();

                        SystemAccountDetail_sad sysDetail = new SystemAccountDetail_sad();
                        sysDetail.sad_cConsumeID = preCost.pcs_cRecordID;
                        sysDetail.sad_cDesc = strReason;
                        sysDetail.sad_cFLowMoney = userDetailInfo.cuad_fFlowMoney;
                        sysDetail.sad_cFlowType = userDetailInfo.cuad_cFlowType;
                        sysDetail.sad_cOpt = userDetailInfo.cuad_cOpt;
                        sysDetail.sad_cRecordID = Guid.NewGuid();
                        sysDetail.sad_dOptTime = DateTime.Now;
                        db.SystemAccountDetail_sad.InsertOnSubmit(sysDetail);
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

        public ReturnValueInfo BatchSyncAccountDetail(List<PreConsumeRecord_pcs_Info> listUpdatePreCost, List<PreConsumeRecord_pcs_Info> listDelPreCost, List<ConsumeRecord_csr_Info> listConsume)
        {
            ReturnValueInfo rvInfo = new ReturnValueInfo();
            try
            {
                using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                {
                    //db.Connection.Open();
                    //db.Transaction = db.Connection.BeginTransaction();

                    List<CardUserAccountDetail_cuad> listUserAccount = new List<CardUserAccountDetail_cuad>();
                    List<SystemAccountDetail_sad> listSysAccount = new List<SystemAccountDetail_sad>();
                    List<PreConsumeRecord_pcs> listDelPreCost_DB = new List<PreConsumeRecord_pcs>();

                    #region 准备需要删除的重复扣费列表

                    if (listDelPreCost != null && listDelPreCost.Count > 0)
                    {
                        foreach (var item in listDelPreCost)
                        {
                            if (item == null)
                                continue;
                            PreConsumeRecord_pcs preCostDel = db.PreConsumeRecord_pcs.Where(x => x.pcs_cRecordID == item.pcs_cRecordID).FirstOrDefault();
                            if (preCostDel != null)
                            {
                                listDelPreCost_DB.Add(preCostDel);
                            }
                        }
                    }

                    #endregion

                    #region 归档处理实际卡消费记录

                    foreach (ConsumeRecord_csr_Info consumeItem in listConsume)
                    {
                        CardUserAccount_cua account = db.CardUserAccount_cua.Where(x => x.cua_cCUSID == consumeItem.csr_cCardUserID).FirstOrDefault();
                        ConsumeRecord_csr consumeInfo = db.ConsumeRecord_csr.Where(x => x.csr_cRecordID == consumeItem.csr_cRecordID).FirstOrDefault();
                        consumeInfo.csr_lIsSettled = consumeItem.csr_lIsSettled;
                        consumeInfo.csr_dSettleTime = consumeItem.csr_dSettleTime;

                        string strFlowType = string.Empty;//公用消费类型

                        CardUserAccountDetail_cuad userAccountDetail = new CardUserAccountDetail_cuad();
                        userAccountDetail.cuad_cRecordID = Guid.NewGuid();
                        userAccountDetail.cuad_cConsumeID = consumeInfo.csr_cRecordID;
                        userAccountDetail.cuad_cCUAID = account.cua_cRecordID;
                        userAccountDetail.cuad_fFlowMoney = consumeItem.csr_fConsumeMoney;
                        if (consumeItem.csr_cConsumeType == Common.DefineConstantValue.ConsumeMachineType.StuSetmeal.ToString())
                        {
                            strFlowType = Common.DefineConstantValue.ConsumeMoneyFlowType.SetMealCost.ToString();
                        }
                        else
                        {
                            strFlowType = Common.DefineConstantValue.ConsumeMoneyFlowType.FreeMealCost.ToString();
                        }
                        userAccountDetail.cuad_cFlowType = strFlowType;
                        userAccountDetail.cuad_cOpt = "sys";
                        userAccountDetail.cuad_dOptTime = DateTime.Now;
                        listUserAccount.Add(userAccountDetail);

                        SystemAccountDetail_sad sysAccountDetail = new SystemAccountDetail_sad();
                        sysAccountDetail.sad_cRecordID = Guid.NewGuid();
                        sysAccountDetail.sad_cConsumeID = consumeInfo.csr_cRecordID;
                        sysAccountDetail.sad_cDesc = Common.DefineConstantValue.GetMoneyFlowDesc(strFlowType);
                        sysAccountDetail.sad_cFLowMoney = consumeItem.csr_fConsumeMoney;
                        sysAccountDetail.sad_cFlowType = strFlowType;
                        sysAccountDetail.sad_cOpt = "sys";
                        sysAccountDetail.sad_dOptTime = DateTime.Now;
                        listSysAccount.Add(sysAccountDetail);
                    }

                    #endregion

                    #region 处理预扣费记录，更新已结算部分数据与未结算部分数据，未结算部分等待下次充值时补扣

                    foreach (PreConsumeRecord_pcs_Info preCostItem in listUpdatePreCost)
                    {
                        PreConsumeRecord_pcs preCostInfo = db.PreConsumeRecord_pcs.Where(x => x.pcs_cRecordID == preCostItem.pcs_cRecordID).FirstOrDefault();
                        if (preCostInfo != null)
                        {
                            preCostInfo.pcs_cSourceID = preCostItem.pcs_cSourceID;
                            preCostInfo.pcs_cConsumeType = preCostItem.pcs_cConsumeType;
                            preCostInfo.pcs_lIsSettled = preCostItem.pcs_lIsSettled;
                            preCostInfo.pcs_dSettleTime = preCostItem.pcs_dSettleTime;
                            preCostInfo.pcs_fCost = Math.Abs(preCostItem.pcs_fCost);
                            preCostInfo.pcs_cAdd = preCostItem.pcs_cAdd;
                            preCostInfo.pcs_dAddDate = preCostItem.pcs_dAddDate;
                        }
                        else
                        {
                            throw new Exception("预付款记录丢失。" + preCostItem.pcs_cRecordID.ToString());
                        }
                    }

                    #endregion

                    #region 更新用户账户的余额以及同步时间
                    /*1、取出用户最新的卡消费记录
                     * 2、取出用户最新的转账或充值记录
                     * 3、对比两者时间，取较新时间的记录去到用户的余额
                     */

                    var groupConsumeRecord = db.ConsumeRecord_csr.GroupBy(x => x.csr_cCardUserID);
                    foreach (var itemUserConsumeGroup in groupConsumeRecord)
                    {
                        Guid userID = itemUserConsumeGroup.Key;
                        List<ConsumeRecord_csr> listUserRecord = itemUserConsumeGroup.OrderByDescending(x => x.csr_dConsumeDate).ToList();
                        if (listUserRecord != null && listUserRecord.Count > 0)
                        {
                            ConsumeRecord_csr record = listUserRecord.FirstOrDefault();//最新的消费记录
                            if (record != null)
                            {
                                decimal fCardCostCurrentBalance = record.csr_fCardBalance;
                                decimal fAdvanceRecharge = decimal.Zero;//透支额度
                                RechargeRecord_rcr advanceRecharge = db.RechargeRecord_rcr.Where(x =>
                                    x.rcr_cUserID == record.csr_cCardUserID
                                    && x.rcr_cRechargeType == Common.DefineConstantValue.ConsumeMoneyFlowType.Recharge_AdvanceMoney.ToString()
                                    ).OrderByDescending(x => x.rcr_dRechargeTime).FirstOrDefault();
                                if (advanceRecharge != null)
                                {
                                    fAdvanceRecharge = advanceRecharge.rcr_fRechargeMoney;
                                }

                                //找出最后消费记录后，有充值情况出现的，需使用此充值后结果
                                List<RechargeRecord_rcr> listCardRecharge = db.RechargeRecord_rcr.Where(x =>
                                    x.rcr_cUserID == record.csr_cCardUserID
                                    && x.rcr_dRechargeTime >= record.csr_dConsumeDate
                                    ).OrderByDescending(x => x.rcr_dRechargeTime).ToList();//以充值时间倒序，取出最新的充值列表
                                listCardRecharge = listCardRecharge.Where(x =>
                                    x.rcr_cRechargeType != Common.DefineConstantValue.ConsumeMoneyFlowType.AdvanceMealCost.ToString()
                                    && x.rcr_cRechargeType != Common.DefineConstantValue.ConsumeMoneyFlowType.FreeMealCost.ToString()
                                    && x.rcr_cRechargeType != Common.DefineConstantValue.ConsumeMoneyFlowType.HedgeFund.ToString()
                                    && x.rcr_cRechargeType != Common.DefineConstantValue.ConsumeMoneyFlowType.IndeterminateCost.ToString()
                                    && x.rcr_cRechargeType != Common.DefineConstantValue.ConsumeMoneyFlowType.NewCardCost.ToString()
                                    && x.rcr_cRechargeType != Common.DefineConstantValue.ConsumeMoneyFlowType.Recharge_AdvanceMoney.ToString()
                                    && x.rcr_cRechargeType != Common.DefineConstantValue.ConsumeMoneyFlowType.ReplaceCardCost.ToString()
                                    && x.rcr_cRechargeType != Common.DefineConstantValue.ConsumeMoneyFlowType.SetMealCost.ToString()).ToList();

                                RechargeRecord_rcr cardRecharge = listCardRecharge.FirstOrDefault();
                                if (cardRecharge != null)
                                {
                                    if (record.csr_dConsumeDate < cardRecharge.rcr_dRechargeTime)
                                    {
                                        //如果充值记录存在，且充值时间比消费时间新，则以充值后余额为最后余额值
                                        fCardCostCurrentBalance = cardRecharge.rcr_fBalance;
                                    }
                                }

                                CardUserAccount_cua userAccount = db.CardUserAccount_cua.Where(x => x.cua_cCUSID == record.csr_cCardUserID).FirstOrDefault();
                                if (userAccount != null)
                                {
                                    decimal fCurrentBalance = fCardCostCurrentBalance - fAdvanceRecharge;
                                    userAccount.cua_fCurrentBalance = fCurrentBalance;
                                    userAccount.cua_dLastSyncTime = DateTime.Now;
                                }
                            }
                        }
                        else
                        {
                            continue;
                        }
                    }

                    #endregion

                    db.Connection.Open();
                    db.Transaction = db.Connection.BeginTransaction();
                    try
                    {
                        if (listConsume.Count > 0)
                        {
                            if (listUserAccount.Count > 0)
                            {
                                db.CardUserAccountDetail_cuad.InsertAllOnSubmit(listUserAccount);
                                db.SystemAccountDetail_sad.InsertAllOnSubmit(listSysAccount);
                            }
                        }

                        if (listDelPreCost_DB.Count > 0)
                        {
                            db.PreConsumeRecord_pcs.DeleteAllOnSubmit(listDelPreCost_DB);
                        }

                        db.SubmitChanges();

                        #region 临时清除午餐误扣费

                        string strChkLunch = @"update PreConsumeRecord_pcs set pcs_lIsSettled=1,pcs_dSettleTime=GETDATE()
where pcs_cRecordID in
(
select pcs_cRecordID from PreConsumeRecord_pcs
where pcs_lIsSettled = 0
and pcs_cConsumeType = '" + Common.DefineConstantValue.ConsumeMoneyFlowType.SetMealCost.ToString() + "'" + Environment.NewLine;
                        strChkLunch += "and pcs_dConsumeDate between '" + DateTime.Now.ToString("yyyy-MM-dd 09:00") + "' and '" + DateTime.Now.ToString("yyyy-MM-dd 13:00") + "'" + Environment.NewLine;
                        strChkLunch += @"and pcs_fCost > 2
and pcs_cUserID in
(
select csr_cCardUserID from ConsumeRecord_csr
where csr_dConsumeDate between '" + DateTime.Now.ToString("yyyy-MM-dd 09:00") + "' and '" + DateTime.Now.ToString("yyyy-MM-dd 13:59") + "'" + Environment.NewLine;
                        strChkLunch += "and csr_cConsumeType = '" + Common.DefineConstantValue.ConsumeMachineType.StuSetmeal.ToString() + "' and csr_cMealType = '" + Common.DefineConstantValue.MealType.Lunch.ToString() + "'))" + Environment.NewLine;
                        db.ExecuteCommand(strChkLunch, new object[] { });

                        #endregion

                        #region 临时清除晚餐误扣费

                        string strChkDinner = @"update PreConsumeRecord_pcs set pcs_lIsSettled=1,pcs_dSettleTime=GETDATE()
where pcs_cRecordID in
(
select pcs_cRecordID from PreConsumeRecord_pcs
where pcs_lIsSettled = 0
and pcs_cConsumeType = '" + Common.DefineConstantValue.ConsumeMoneyFlowType.SetMealCost.ToString() + "'" + Environment.NewLine;
                        strChkDinner += "and pcs_dConsumeDate between '" + DateTime.Now.ToString("yyyy-MM-dd 13:30") + "' and '" + DateTime.Now.ToString("yyyy-MM-dd 23:59") + "'" + Environment.NewLine;
                        strChkDinner += @"and pcs_fCost > 2
and pcs_cUserID in
(
select csr_cCardUserID from ConsumeRecord_csr
where csr_dConsumeDate between '" + DateTime.Now.ToString("yyyy-MM-dd 15:00") + "' and '" + DateTime.Now.ToString("yyyy-MM-dd 23:59") + "'" + Environment.NewLine;
                        strChkDinner += "and csr_cConsumeType = '" + Common.DefineConstantValue.ConsumeMachineType.StuSetmeal.ToString() + "' and csr_cMealType = '" + Common.DefineConstantValue.MealType.Supper.ToString() + "'))" + Environment.NewLine;
                        db.ExecuteCommand(strChkDinner, new object[] { });

                        #endregion

                        if (listConsume.Count < 1 && listUpdatePreCost.Count < 1)
                        {
                            rvInfo.boolValue = false;
                            rvInfo.messageText = "没有可用的数据。";
                        }
                        else
                        {
                            rvInfo.boolValue = true;
                        }

                    }
                    catch (Exception exx)
                    {
                        db.Transaction.Rollback();
                        db.Connection.Close();
                        throw exx;
                    }
                    db.Transaction.Commit();
                    db.Connection.Close();
                }
            }
            catch (Exception ex)
            {
                rvInfo.isError = true;
                rvInfo.messageText = ex.Message;
            }
            return rvInfo;
        }

        public decimal GetAccountTotalBalance(DateTime dtDeadline)
        {
            decimal fTotalAccount = decimal.Zero;
            try
            {
                StringBuilder sbSQL = new StringBuilder();
                sbSQL.AppendLine("SELECT SUM(cua_fCurrentBalance) FROM CardUserAccount_cua WHERE 1= 1");
                sbSQL.AppendLine("AND cua_dLastSyncTime <= '" + dtDeadline.ToString("yyyy-MM-dd ") + "23:59:59" + "'");
                using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                {
                    var query = db.ExecuteQuery(typeof(decimal), sbSQL.ToString(), new object[] { });
                    foreach (decimal item in query)
                    {
                        fTotalAccount = item;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return fTotalAccount;
        }

        public ReturnValueInfo ResetAccountOverdraft(RechargeRecord_rcr_Info OverdraftInfo)
        {
            ReturnValueInfo rvInfo = new ReturnValueInfo();
            if (OverdraftInfo == null)
            {
                rvInfo.isError = true;
                rvInfo.messageText = Common.DefineConstantValue.SystemMessageText.strMessageText_E_ObjectNull;
                return rvInfo;
            }
            try
            {
                //获取已发卡用户列表
                ICardUserMasterDA userDA = MasterDAFactory.GetDAL<ICardUserMasterDA>(MasterDAFactory.CardUserMaster);
                CardUserMaster_cus_Info userSearch = new CardUserMaster_cus_Info();
                userSearch.cus_cIdentityNum = Common.DefineConstantValue.CodeMasterDefine.KEY2_SIOT_CardUserIdentity_Student;
                List<CardUserMaster_cus_Info> listUsers = userDA.SearchRecordsWithCardInfo(userSearch);
                if (listUsers != null)
                {
                    listUsers = listUsers.Where(x => x.cus_lValid && x.PairCardNo != null).ToList();
                }

                //获取透支额列表
                IRechargeRecordDA rechargeDA = MasterDAFactory.GetDAL<IRechargeRecordDA>(MasterDAFactory.RechargeRecord);
                RechargeRecord_rcr_Info rechargeSearch = new RechargeRecord_rcr_Info();
                rechargeSearch.rcr_cRechargeType = Common.DefineConstantValue.ConsumeMoneyFlowType.Recharge_AdvanceMoney.ToString();
                List<RechargeRecord_rcr_Info> listRecharge = rechargeDA.SearchRecords(rechargeSearch);
                List<RechargeRecord_rcr> listRechargeRec = new List<RechargeRecord_rcr>();

                List<PreConsumeRecord_pcs> listInsertPreCost = new List<PreConsumeRecord_pcs>();
                if (listRecharge != null && listRecharge.Count > 0)
                {
                    IEnumerable<IGrouping<Guid, RechargeRecord_rcr_Info>> groupRecharge = listRecharge.GroupBy(x => x.rcr_cUserID);
                    foreach (var itemRecharge in groupRecharge)
                    {
                        Guid userID = itemRecharge.Key;
                        CardUserMaster_cus_Info userInfo = listUsers.Find(x => x.cus_cRecordID == userID);
                        if (userInfo == null)
                        {
                            continue;
                        }

                        RechargeRecord_rcr_Info userRecharge = itemRecharge.OrderByDescending(x => x.rcr_dRechargeTime).FirstOrDefault();
                        if (userRecharge != null)
                        {
                            Guid sourceID = Guid.NewGuid();
                            if (OverdraftInfo.rcr_fRechargeMoney > userRecharge.rcr_fRechargeMoney)
                            {
                                //新的透支额大于当前透支额
                            }
                            else if (OverdraftInfo.rcr_fRechargeMoney < userRecharge.rcr_fRechargeMoney)
                            {
                                //新的透支额小于当前透支额 eg: 0, 50
                                PreConsumeRecord_pcs preCost = new PreConsumeRecord_pcs();
                                preCost.pcs_cRecordID = Guid.NewGuid();
                                preCost.pcs_cSourceID = sourceID;
                                preCost.pcs_cAccountID = userInfo.AccountID.Value;
                                preCost.pcs_cAdd = OverdraftInfo.rcr_cAdd;
                                preCost.pcs_cConsumeType = Common.DefineConstantValue.ConsumeMoneyFlowType.Recharge_AdvanceMoney.ToString();
                                preCost.pcs_cUserID = userID;
                                preCost.pcs_dAddDate = DateTime.Now;
                                preCost.pcs_dConsumeDate = DateTime.Now;
                                preCost.pcs_fCost = Math.Abs(OverdraftInfo.rcr_fRechargeMoney - userRecharge.rcr_fRechargeMoney);

                                listInsertPreCost.Add(preCost);
                            }
                            else
                            {
                                continue;
                            }

                            RechargeRecord_rcr insertRechrage = Common.General.CopyObjectValue<RechargeRecord_rcr_Info, RechargeRecord_rcr>(userRecharge);
                            insertRechrage.rcr_cRecordID = sourceID;
                            insertRechrage.rcr_fRechargeMoney = OverdraftInfo.rcr_fRechargeMoney;
                            insertRechrage.rcr_fBalance = 0;
                            insertRechrage.rcr_dRechargeTime = DateTime.Now;
                            insertRechrage.rcr_cAdd = OverdraftInfo.rcr_cAdd;
                            insertRechrage.rcr_cLast = OverdraftInfo.rcr_cLast;
                            insertRechrage.rcr_cDesc = OverdraftInfo.rcr_cDesc;
                            insertRechrage.rcr_cStatus = Common.DefineConstantValue.ConsumeMoneyFlowStatus.Finished.ToString();

                            listRechargeRec.Add(insertRechrage);
                        }
                    }
                }

                if (listInsertPreCost.Count == listRechargeRec.Count && listRechargeRec.Count > 0)
                {
                    using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                    {
                        db.Connection.Open();
                        db.Transaction = db.Connection.BeginTransaction();
                        try
                        {
                            db.RechargeRecord_rcr.InsertAllOnSubmit(listRechargeRec);
                            db.PreConsumeRecord_pcs.InsertAllOnSubmit(listInsertPreCost);
                            db.SubmitChanges();
                            db.Transaction.Commit();
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
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return rvInfo;
        }
    }
}
