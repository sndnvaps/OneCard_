using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.IDAL.Report;
using Model.HHZX.Report;
using Model.IModel;
using LinqToSQLModel;

namespace DAL.SqlDAL.HHZX.Report
{
    /// <summary>
    /// 报表--存款汇总表
    /// </summary>
    public class DepositSummaryDA : IDepositSummaryDA
    {
        public Model.General.ReturnValueInfo InsertRecord(Model.HHZX.Report.DepositSummary_dps_Info infoObject)
        {
            throw new NotImplementedException();
        }

        public Model.General.ReturnValueInfo UpdateRecord(Model.HHZX.Report.DepositSummary_dps_Info infoObject)
        {
            throw new NotImplementedException();
        }

        public Model.General.ReturnValueInfo DeleteRecord(Model.IModel.IModelObject KeyObject)
        {
            throw new NotImplementedException();
        }

        public Model.HHZX.Report.DepositSummary_dps_Info DisplayRecord(Model.IModel.IModelObject KeyObject)
        {
            throw new NotImplementedException();
        }

        public List<DepositSummary_dps_Info> SearchRecords(IModelObject searchCondition)
        {
            List<DepositSummary_dps_Info> listSummary = new List<DepositSummary_dps_Info>();
            try
            {
                DepositSummary_dps_Info searchInfo = searchCondition as DepositSummary_dps_Info;
                if (searchInfo == null)
                {
                    return null;
                }

                StringBuilder sqlMain = new StringBuilder();
                StringBuilder sqlPulicClassID = new StringBuilder();
                StringBuilder sqlPublicTime = new StringBuilder();

                #region 旧逻辑

                //                sqlPulic.AppendLine("select cuad_fFlowMoney, cuad_cFlowType, SUBSTRING(CONVERT(VARCHAR(10),cuad_dOptTime,120),0,8) as dps_cMonthName");
                //                sqlPulic.AppendLine("from CardUserAccountDetail_cuad");
                //                sqlPulic.AppendLine("left join CardUserAccount_cua on cua_cRecordID = cuad_cCUAID");
                //                sqlPulic.AppendLine("left join CardUserMaster_cus on cus_cRecordID = cua_cCUSID");
                //                sqlPulic.AppendLine("WHERE 1=1 ");
                //                if (searchInfo.dps_dMonthFrom != DateTime.MinValue)
                //                {
                //                    sqlPulic.AppendLine("and cuad_dOptTime >='" + searchInfo.dps_dMonthFrom.ToString("yyyy-MM-01 00:00:00") + "'");
                //                }
                //                if (searchInfo.dps_dMonthTo != DateTime.MinValue)
                //                {
                //                    sqlPulic.AppendLine("and cuad_dOptTime <'" + DateTime.Parse(searchInfo.dps_dMonthTo.ToString("yyyy-MM-01")).AddMonths(1).ToString("yyyy-MM-dd 00:00:00") + "'");
                //                }
                //                if (searchInfo.dps_cClassID != Guid.Empty)
                //                {
                //                    sqlPulic.AppendLine("and cus_cClassID = '" + searchInfo.dps_cClassID.ToString() + "'");
                //                }
                //                else
                //                {
                //                    if (searchInfo.dps_cDptID != Guid.Empty)
                //                    {
                //                        sqlPulic.AppendLine("and cus_cClassID = '" + searchInfo.dps_cDptID.ToString() + "'");
                //                    }
                //                }

                //                sqlMain.AppendLine("select TBRecharge.dps_cMonthName , dps_fTotalRecharge,dps_iRechargeAmount,dps_fTotalRefund,dps_iRefundAmount, (dps_fTotalRecharge - dps_fTotalRefund) as dps_fTotalDeposit  from(");
                //                sqlMain.AppendLine("select SUM(cuad_fFlowMoney) as dps_fTotalRecharge,COUNT(cuad_fFlowMoney) as dps_iRechargeAmount,dps_cMonthName from(");
                //                sqlMain.AppendLine(sqlPulic.ToString());
                //                sqlMain.AppendLine(@"and (cuad_cFlowType = 'Recharge_PersonalRealTime' --个人实时充值
                //		or cuad_cFlowType = 'Recharge_PersonalTransfer' --个人转账充值
                //		or cuad_cFlowType = 'Recharge_BatchTransfer' --批量转账充值
                //		)");
                //                sqlMain.AppendLine(") as BaseTable group by dps_cMonthName");
                //                sqlMain.AppendLine(") as TBRecharge left join  (");
                //                sqlMain.AppendLine("select SUM(cuad_fFlowMoney)as dps_fTotalRefund,COUNT(cuad_fFlowMoney) as dps_iRefundAmount,dps_cMonthName from(");
                //                sqlMain.AppendLine(sqlPulic.ToString());
                //                sqlMain.AppendLine(@"and (cuad_cFlowType = 'Refund_PersonalCash' --个人现金退款
                //		or cuad_cFlowType = 'Refund_CardPersonalRealTime' --个人卡退款
                //		or cuad_cFlowType = 'Refund_PersonalTransfer'--个人转账退款
                //		or cuad_cFlowType = 'Refund_BatchTransfer' --批量转账退款
                //		)");
                //                sqlMain.AppendLine(") as BaseTable group by dps_cMonthName )as TBRefund on TBRecharge.dps_cMonthName = TBRefund.dps_cMonthName order by TBRecharge.dps_cMonthName");

                #endregion

                #region 新逻辑，因应要求，需要以操作员操作时间为准

                if (searchInfo.dps_cClassID != Guid.Empty)
                {
                    sqlPulicClassID.AppendLine("and cus_cClassID = '" + searchInfo.dps_cClassID.ToString() + "'");
                }
                else
                {
                    if (searchInfo.dps_cDptID != Guid.Empty)
                    {
                        sqlPulicClassID.AppendLine("and cus_cClassID = '" + searchInfo.dps_cDptID.ToString() + "'");
                    }
                }

                string strFormat = @"select SUM(cuad_fFlowMoney) as {0},COUNT(cuad_fFlowMoney) as {1},dps_cMonthName
from(
select 
isnull(cuad_fFlowMoney,0.00)as cuad_fFlowMoney, 
cuad_cFlowType, 
SUBSTRING(CONVERT(VARCHAR(10),cuad_dOptTime,120),0,8) as dps_cMonthName
from dbo.CardUserAccountDetail_cuad 
join dbo.CardUserAccount_cua on cuad_cCUAID = cua_cRecordID
left join CardUserMaster_cus on cus_cRecordID = cua_cCUSID
where 
cuad_cFlowType in {2}
and cuad_dOptTime >= @StartTime and cuad_dOptTime < @EndTime {6}
union all
select 
isnull(prr_fRechargeMoney,0.00)as cuad_fFlowMoney, 
prr_cRechargeType, 
SUBSTRING(CONVERT(VARCHAR(10),prr_dAddDate,120),0,8) as dps_cMonthName
from dbo.PreRechargeRecord_prr
left join CardUserMaster_cus on cus_cRecordID = prr_cUserID
where
prr_cRechargeType in {3}
and prr_dAddDate >= @StartTime and prr_dAddDate < @EndTime
and prr_dRechargeTime <> '2012-01-01 00:00:00' {6}
) as {4} group by dps_cMonthName
) as {5}";
                /*格式内容：
                 * 0-存/退款统计金额栏位名，
                 * 1-存/退款笔数统计栏位名，
                 * 2-即时交易类型，
                 * 3-转账交易类型，
                 * 4-统计详细子表名，
                 * 5-统计汇总子表名，
                 * 6-班别/部门ID筛选条件*/
                string strRecharge = string.Format(strFormat, "dps_fTotalRecharge", "dps_iRechargeAmount", "('Recharge_PersonalRealTime')", "('Recharge_PersonalTransfer','Recharge_BatchTransfer')", "TB_Recharge", "TB_Recharge_Total", sqlPulicClassID.ToString());
                string strRefund = string.Format(strFormat, "dps_fTotalRefund", "dps_iRefundAmount", "('Refund_PersonalCash','Refund_CardPersonalRealTime')", "('Refund_PersonalTransfer','Refund_BatchTransfer')", "TB_Refund", "TB_Refund_Total", sqlPulicClassID.ToString());

                string strTimeFormat = @"declare @StartTime datetime,@EndTime datetime
set @StartTime='{0}'
set @EndTime='{1}'";
                string strTimeStart = string.Empty;
                string strTimeEnd = string.Empty;
                if (searchInfo.dps_dMonthFrom != DateTime.MinValue)
                {
                    strTimeStart = searchInfo.dps_dMonthFrom.ToString("yyyy-MM-01 00:00:00");
                }
                else
                {
                    strTimeStart = DateTime.Parse(searchInfo.dps_dMonthFrom.ToString("yyyy-MM-01")).AddYears(-1).ToString("yyyy-MM-dd 00:00:00");
                }
                if (searchInfo.dps_dMonthTo != DateTime.MinValue)
                {
                    strTimeEnd = DateTime.Parse(searchInfo.dps_dMonthTo.ToString("yyyy-MM-01")).AddMonths(1).ToString("yyyy-MM-dd 00:00:00");
                }
                else
                {
                    strTimeEnd = DateTime.Parse(searchInfo.dps_dMonthTo.ToString("yyyy-MM-01")).AddYears(1).ToString("yyyy-MM-dd 00:00:00");
                }
                sqlPublicTime.Append(string.Format(strTimeFormat, strTimeStart, strTimeEnd));

                sqlMain.AppendLine(sqlPublicTime.ToString());
                sqlMain.AppendLine("select TB_Recharge_Total.dps_cMonthName,dps_fTotalRecharge,dps_iRechargeAmount,dps_fTotalRefund,dps_iRefundAmount from (");
                sqlMain.AppendLine(strRecharge);
                sqlMain.AppendLine("left join(");
                sqlMain.AppendLine(strRefund);
                sqlMain.AppendLine("on TB_Refund_Total.dps_cMonthName = TB_Recharge_Total.dps_cMonthName order by TB_Refund_Total.dps_cMonthName");

                #endregion

                using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                {
                    string strClassName = string.Empty;
                    if (searchInfo.dps_cClassID != Guid.Empty)
                    {
                        ClassMaster_csm classInfo = db.ClassMaster_csm.Where(x => x.csm_cRecordID == searchInfo.dps_cClassID).FirstOrDefault();
                        if (classInfo != null)
                        {
                            strClassName = classInfo.csm_cClassName;
                        }
                    }
                    else
                    {
                        if (searchInfo.dps_cDptID != Guid.Empty)
                        {
                            DepartmentMaster_dpm dptInfo = db.DepartmentMaster_dpm.Where(x => x.dpm_RecordID == searchInfo.dps_cDptID).FirstOrDefault();
                            if (dptInfo != null)
                            {
                                strClassName = dptInfo.dpm_cName;
                            }
                        }
                        else
                        {
                            strClassName = "全校";
                        }
                    }
                    IEnumerable<DepositSummary_dps_Info> query = db.ExecuteQuery<DepositSummary_dps_Info>(sqlMain.ToString(), new object[] { });
                    if (query != null)
                    {
                        foreach (DepositSummary_dps_Info item in query)
                        {
                            item.dps_cObjName = strClassName;
                            if (item.dps_fTotalDeposit == null)
                                item.dps_fTotalDeposit = decimal.Zero;
                            if (item.dps_fTotalRecharge == null)
                                item.dps_fTotalRecharge = decimal.Zero;
                            if (item.dps_fTotalRefund == null)
                                item.dps_fTotalRefund = decimal.Zero;
                            if (item.dps_iRechargeAmount == null)
                                item.dps_iRechargeAmount = 0;
                            if (item.dps_iRefundAmount == null)
                                item.dps_iRefundAmount = 0;
                            listSummary.Add(item);
                        }
                        listSummary = listSummary.OrderBy(x => x.dps_cMonthName).ToList();
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return listSummary;
        }

        public List<Model.HHZX.Report.DepositSummary_dps_Info> AllRecords()
        {
            throw new NotImplementedException();
        }
    }
}
