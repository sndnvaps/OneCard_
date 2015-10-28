using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.IDAL.Report;
using Model.HHZX.Report;
using LinqToSQLModel;
using System.Data.SqlClient;
using System.Data;

namespace DAL.SqlDAL.HHZX.Report
{
    public class StudentCostSummaryDA : IStudentCostSummaryDA
    {
        public List<StudentCostSummary_scs_Info> SearchRecords(StudentCostSummary_scs_Info searchInfo)
        {
            if (searchInfo == null)
            {
                return null;
            }
            List<StudentCostSummary_scs_Info> listRes = new List<StudentCostSummary_scs_Info>();
            try
            {
                #region SQL-- 统计用户的消费金额

                string strPublicDate = string.Empty;
                string strDateFrom = string.Empty;
                string strDateTo = string.Empty;
                if (searchInfo.scs_dStartDate != DateTime.MinValue && searchInfo.scs_dEndDate != DateTime.MinValue)
                {
                    strDateFrom = searchInfo.scs_dStartDate.ToString("yyyy-MM-dd 00:00:00");
                    strDateTo = searchInfo.scs_dEndDate.ToString("yyyy-MM-dd 23:59:59");
                }
                else
                {
                    if (searchInfo.scs_dStartDate != DateTime.MinValue)
                    {
                        strDateFrom = searchInfo.scs_dStartDate.ToString("yyyy-MM-dd 00:00:00");
                        strDateTo = searchInfo.scs_dEndDate.ToString("2099-01-01 23:59:59");
                    }
                    else if (searchInfo.scs_dEndDate != DateTime.MinValue)
                    {
                        strDateFrom = searchInfo.scs_dStartDate.ToString("1900-01-01 00:00:00");
                        strDateTo = searchInfo.scs_dEndDate.ToString("yyyy-MM-dd 23:59:59");
                    }
                    else
                    {
                        strDateFrom = searchInfo.scs_dStartDate.ToString("1900-01-01 00:00:00");
                        strDateTo = searchInfo.scs_dEndDate.ToString("2099-01-01 23:59:59");
                    }
                }

                StringBuilder sbSQL = new StringBuilder();
                sbSQL.AppendLine(@"set nocount on;
if object_id('tempdb..#CostDetail')<>'' drop table #CostDetail
if object_id('tempdb..#UnMealMemberList')<>'' drop table #UnMealMemberList
declare @dateFrom datetime
declare @dateTo datetime
set @dateFrom = '" + strDateFrom + @"'
set @dateTo = '" + strDateTo + @"'

select targetID,targetLevel into #UnMealMemberList from
(select targetID=AAA.targetID,targetLevel=AAA.targetLevel from(
select * from(
select targetID,targetLevel,(SUM(cBreakfast)+SUM(cLunch)+SUM(cDinner))GenNum from (
select targetID=ISNULL(pus_cGradeID,ISNULL(pus_cClassID,pus_cCardUserID))
,convert(int,pus_cBreakfast)cBreakfast,convert(int,pus_cLunch)cLunch,convert(int,pus_cDinner)cDinner
,targetLevel=(case when pus_cGradeID is not null then 'Grade' else(case when pus_cClassID is not null then 'Class' else 'User' end) end)
from PaymentUDGeneralSetting_pus)A
group by targetID,targetLevel)AA where GenNum=0)AAA
left join(
select * from(
select targetID,targetLevel,(SUM(cBreakfast)+SUM(cLunch)+SUM(cDinner))GenNum from(
select targetID=ISNULL(pms_cGradeID,ISNULL(pms_cClassID,pms_cCardUserID))
,convert(int,pms_cBreakfast)cBreakfast,convert(int,pms_cLunch)cLunch,convert(int,pms_cDinner)cDinner
,targetLevel=(case when pms_cGradeID is not null then 'Grade' else(case when pms_cClassID is not null then 'Class' else 'User' end) end)
from dbo.PaymentUDMealState_pms
where pms_dStartDate>=@dateFrom and pms_dEndDate<=@dateTo)B
group by targetID,targetLevel)BB where GenNum>0)BBB
on AAA.targetID=BBB.targetID and AAA.targetLevel=BBB.targetLevel
where BBB.targetID is null)UnMealMemberList

select UserID,CostMoney
into #CostDetail from (
 --无打卡补扣的定餐费用
select pcs_cUserID as UserID,cuad_fFlowMoney as CostMoney from CardUserAccountDetail_cuad
left join PreConsumeRecord_pcs on cuad_cConsumeID = pcs_cRecordID
where cuad_cFlowType = '" + Common.DefineConstantValue.ConsumeMoneyFlowType.SetMealCost.ToString() + @"' 
and pcs_dConsumeDate  between @dateFrom and @dateTo
union all
--打卡的定餐费用
select csr_cCardUserID as UserID,cuad_fFlowMoney as CostMoney from CardUserAccountDetail_cuad
left join ConsumeRecord_csr on cuad_cConsumeID = csr_cRecordID
where cuad_cFlowType = '" + Common.DefineConstantValue.ConsumeMoneyFlowType.SetMealCost.ToString() + @"' 
and csr_dConsumeDate  between @dateFrom and @dateTo
union all
--未结算的定餐费用
select pcs_cUserID as UserID,pcs_fCost as CostMoney from PreConsumeRecord_pcs 
where pcs_lIsSettled = 0 and pcs_cConsumeType = '" + Common.DefineConstantValue.ConsumeMoneyFlowType.SetMealCost.ToString() + @"' 
and pcs_dConsumeDate  between @dateFrom and @dateTo
)as CostDetail
select cus_cRecordID as UserID,
cus_cChaName as scs_cUserName,
cus_cStudentID as scs_cUserNum,
csm_cClassName as scs_cClassName,
cus_cContractName as scs_cParentName,
cus_cContractPhone as scs_cParentPhone,
ISNULL(cus_cBankAccount,'') as scs_cAccountNum,
ISNULL(SumMealCost,0.00) + ISNULL(SumFreeCost,0.00)  as scs_fTotalCost,
ISNULL(SumMealCost,0.00) as scs_fHistoryMealCost,
ISNULL(SumFreeCost,0.00) as scs_fHistoryFreeCost,
(ISNULL(cua_fCurrentBalance,0) - ISNULL(UnPayCost,0) + ISNULL(UnGetMoney,0)) as scs_fAccountBalance
,ISNULL(SumMealCost,0)SumFreeCost,ISNULL(SumFreeCost,0)SumMealCost
from (select cus_cRecordID as UserID,isnull(SumMealCost,0)SumMealCost from CardUserMaster_cus 
	left join (select UserID,SUM(CostMoney)as SumMealCost from #CostDetail group by UserID) AA on AA.UserID=cus_cRecordID
	left join UserCardPair_ucp on ucp_cCUSID=cus_cRecordID and ucp_dReturnTime is null
	where cus_lValid=1 and cus_lIsGraduate=0 and cus_cIdentityNum='STUDENT')as A
left join
(select UserID,SUM(CostMoney)as SumFreeCost from(--統計上月餐外消費總額_2_HistoryFreeCost
--餐外消费（加菜、饮料、热水）
select csr_cCardUserID as UserID,csr_fConsumeMoney as CostMoney from ConsumeRecord_csr
left join CardUserMaster_cus on csr_cCardUserID = cus_cRecordID
where csr_dConsumeDate  between @dateFrom and @dateTo
and csr_cConsumeType <> '" + Common.DefineConstantValue.ConsumeMachineType.StuSetmeal.ToString() + @"' 
and cus_cIdentityNum = '" + Common.DefineConstantValue.CodeMasterDefine.KEY2_SIOT_CardUserIdentity_Student + @"' 
union all
--换卡、新发卡补扣费
select pcs_cUserID as UserID,pcs_fCost as CostMoney from PreConsumeRecord_pcs
left join CardUserMaster_cus on cus_cRecordID = pcs_cUserID
where (pcs_cConsumeType = '" + Common.DefineConstantValue.ConsumeMoneyFlowType.ReplaceCardCost.ToString() + @"'
or pcs_cConsumeType = '" + Common.DefineConstantValue.ConsumeMoneyFlowType.NewCardCost.ToString() + @"')
and pcs_fCost > 0
and pcs_dConsumeDate  between @dateFrom and @dateTo
and cus_cIdentityNum = '" + Common.DefineConstantValue.CodeMasterDefine.KEY2_SIOT_CardUserIdentity_Student + @"' 
) as _2_HistoryFreeCost group by UserID) as B
on A.UserID = B.UserID
left join CardUserMaster_cus on cus_cRecordID=A.UserID
left join ClassMaster_csm on csm_cRecordID=cus_cClassID
left join #UnMealMemberList MealA on MealA.targetID=csm_cGDMID and MealA.targetLevel='Grade'
left join #UnMealMemberList MealB on MealB.targetID=csm_cRecordID and MealB.targetLevel='Class'
left join #UnMealMemberList MealC on MealC.targetID=cus_cRecordID and MealC.targetLevel='User'
left join 
(
select cua_cCUSID,cua_fCurrentBalance,ISNULL(UnPayCost,0.00) as UnPayCost,ISNULL(UnGetMoney,0.00) as UnGetMoney from CardUserAccount_cua
left join (
select SUM(pcs_fCost) as UnPayCost,pcs_cUserID from PreConsumeRecord_pcs 
where pcs_lIsSettled = 0 
and (pcs_cConsumeType = '" + Common.DefineConstantValue.ConsumeMoneyFlowType.SetMealCost.ToString() + @"'
or pcs_cConsumeType = '" + Common.DefineConstantValue.ConsumeMoneyFlowType.NewCardCost.ToString() + @"'
or pcs_cConsumeType = '" + Common.DefineConstantValue.ConsumeMoneyFlowType.ReplaceCardCost.ToString() + @"')
group by pcs_cUserID
) as SubTB_UnpayRecord on pcs_cUserID = cua_cCUSID
left join (
select SUM(prr_fRechargeMoney) as UnGetMoney,prr_cUserID from PreRechargeRecord_prr
where prr_cStatus <> '" + Common.DefineConstantValue.ConsumeMoneyFlowStatus.Finished.ToString() + @"'
group by prr_cUserID
) as SubTB_UnGetRecharge on prr_cUserID = cua_cCUSID
) as SubTB_AccountInfo on cua_cCUSID = cus_cRecordID
where 1=1
and (MealA.targetID is null and MealB.targetID is null and MealC.targetID is null)");

                if (!string.IsNullOrEmpty(searchInfo.scs_cUserName))
                {
                    sbSQL.AppendLine("and cus_cChaName like N'%" + searchInfo.scs_cUserName + "%'");
                }
                if (!string.IsNullOrEmpty(searchInfo.scs_cUserNum))
                {
                    sbSQL.AppendLine("and cus_cStudentID like '%" + searchInfo.scs_cUserNum + "%'");
                }
                if (searchInfo.ClassID != null && searchInfo.ClassID.Value != Guid.Empty)
                {
                    sbSQL.AppendLine("and cus_cClassID = '" + searchInfo.ClassID + "'");
                }
                if (searchInfo.GradeID != null && searchInfo.GradeID.Value != Guid.Empty)
                {
                    sbSQL.AppendLine("and csm_cGDMID = '" + searchInfo.GradeID + "'");
                }
                sbSQL.AppendLine("if object_id('tempdb..#CostDetail')<>'' drop table #CostDetail");

                #endregion

                using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                {
                    db.CommandTimeout = 10 * 60000;
                    IEnumerable<StudentCostSummary_scs_Info> query = db.ExecuteQuery<StudentCostSummary_scs_Info>(sbSQL.ToString(), new object[] { });
                    listRes = query.OrderBy(x => x.scs_cClassName).ToList();

                    #region 执行查询用户预计定餐消费额

                    DataTable dtAll = new DataTable("TableAll");
                    SqlConnection sqlconn = new SqlConnection(db.Connection.ConnectionString);

                    DateTime dtStart = DateTime.Parse(searchInfo.scs_dStartDate.ToString("yyyy-MM-01 00:00")).AddMonths(1);
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

                        parameters[0].Value = dtUse;
                        if (searchInfo.GradeID == null || (searchInfo.GradeID != null && searchInfo.GradeID.Value == Guid.Empty))
                        {
                            parameters[1].Value = Guid.Empty;
                        }
                        else
                        {
                            parameters[1].Value = searchInfo.GradeID;
                        }
                        if (searchInfo.ClassID == null || (searchInfo.ClassID != null && searchInfo.ClassID.Value == Guid.Empty))
                        {
                            parameters[2].Value = Guid.Empty;
                        }
                        else
                        {
                            parameters[2].Value = searchInfo.ClassID;
                        }
                        if (searchInfo.UserID == null || (searchInfo.UserID != null && searchInfo.UserID.Value == Guid.Empty))
                        {
                            parameters[3].Value = Guid.Empty;
                        }
                        else
                        {
                            parameters[3].Value = searchInfo.UserID;
                        }
                        if (!string.IsNullOrEmpty(searchInfo.scs_cUserName))
                        {
                            parameters[4].Value = searchInfo.scs_cUserName;
                        }
                        else
                        {
                            parameters[4].Value = string.Empty;
                        }
                        if (!string.IsNullOrEmpty(searchInfo.scs_cUserNum))
                        {
                            parameters[5].Value = searchInfo.scs_cUserNum;
                        }
                        else
                        {
                            parameters[5].Value = string.Empty;
                        }

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
                    var groupMealDetail = listMealDetail.GroupBy(x => x.UserID);
                    foreach (var mealItem in groupMealDetail)
                    {
                        Guid userID = mealItem.Key;
                        StudentCostSummary_scs_Info sumInfo = listRes.Find(x => x.UserID == userID);
                        if (sumInfo != null)
                        {
                            int iBreakfast = mealItem.Sum(x => x.Breakfast);
                            int iLunch = mealItem.Sum(x => x.Lunch);
                            int iDinner = mealItem.Sum(x => x.Dinner);
                            sumInfo.scs_fPreMealCost = iBreakfast * 2.00M + iLunch * 4.00M + iDinner * 4.00M;
                        }
                    }

                    #endregion
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return listRes;
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
    }
}
