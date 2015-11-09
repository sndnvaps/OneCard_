using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.IDAL.Report;
using Model.HHZX.Report;
using LinqToSQLModel;

namespace DAL.SqlDAL.HHZX.Report
{
    public class CardFeeSummaryDA : ICardFeeSummaryDA
    {
        public List<CardFeeSummary_cfs_Info> SearchRecords(CardFeeSummary_cfs_Info searchInfo)
        {
            List<CardFeeSummary_cfs_Info> listRes = new List<CardFeeSummary_cfs_Info>();
            try
            {
                StringBuilder sbIncome = new StringBuilder();
                StringBuilder sbCost = new StringBuilder();
                if (searchInfo != null)
                {
                    if (searchInfo.cfs_dMonthFrom != DateTime.MinValue)
                    {
                        sbIncome.AppendLine("		and pcs_dAddDate >='" + searchInfo.cfs_dMonthFrom.ToString("yyyy-MM-01 00:00:00") + "'");
                        sbCost.AppendLine("		and prd_dCertificateDate >='" + searchInfo.cfs_dMonthFrom.ToString("yyyy-MM-01 00:00:00") + "'");
                    }
                    if (searchInfo.cfs_dMonthTo != DateTime.MinValue)
                    {
                        sbIncome.AppendLine("and pcs_dAddDate <'" + DateTime.Parse(searchInfo.cfs_dMonthTo.ToString("yyyy-MM-01")).AddMonths(1).ToString("yyyy-MM-dd 00:00:00") + "'");
                        sbCost.AppendLine("and prd_dCertificateDate <'" + DateTime.Parse(searchInfo.cfs_dMonthTo.ToString("yyyy-MM-01")).AddMonths(1).ToString("yyyy-MM-dd 00:00:00") + "'");
                    }
                }
                StringBuilder sbSQL = new StringBuilder();
                sbSQL.AppendLine(@"
select
ISNULL(AA.PayMonth,BB.PayMonth) as cfs_cMonthName,
ISNULL(CardIncome,0.00) as cfs_fCardIncome,ISNULL(CardIncomeCount,0) as cfs_iCardIncomeCount,
ISNULL(CardCost,0.00) as cfs_fCardPay,ISNULL(CardCount,0) as cfs_iCardPayCount
from(
	select SUM(pcs_fCost) as CardIncome, COUNT(PayMonth)as CardIncomeCount,PayMonth from 
	(
		select pcs_fCost,SUBSTRING(CONVERT(VARCHAR(10),pcs_dAddDate,120),0,8) as PayMonth 
		from PreConsumeRecord_pcs with(nolock)
		left join vie_AllStudentCardUserInfos with(nolock) on pcs_cUserID=cus_cRecordID ");
                sbSQL.AppendLine("		where (pcs_cConsumeType = '" + Common.DefineConstantValue.ConsumeMoneyFlowType.NewCardCost.ToString() + "' or pcs_cConsumeType = '" + Common.DefineConstantValue.ConsumeMoneyFlowType.ReplaceCardCost.ToString() + "') and pcs_fCost >0");
                if (!string.IsNullOrEmpty(sbIncome.ToString()))
                {
                    sbSQL.AppendLine(sbIncome.ToString());
                }
                sbSQL.AppendLine(@"
	) as A group by PayMonth) as AA
left join(
	select SUM(prd_fPayMoney) as CardCost,SUM(prd_iPayCount) as CardCount,PayMonth from(
		select prd_fPayMoney,prd_iPayCount,SUBSTRING(CONVERT(VARCHAR(10),prd_dCertificateDate,120),0,8) AS PayMonth 
		from dbo.PayRecord_prd with(nolock)");
                sbSQL.AppendLine("		where prd_cPayType = 'Card'");
                if (!string.IsNullOrEmpty(sbCost.ToString()))
                {
                    sbSQL.AppendLine(sbCost.ToString());
                }
                sbSQL.AppendLine(") as B group by PayMonth)as BB on AA.PayMonth = BB.PayMonth order by AA.PayMonth");

                using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                {
                    IEnumerable<CardFeeSummary_cfs_Info> query = db.ExecuteQuery<CardFeeSummary_cfs_Info>(sbSQL.ToString(), new object[] { });
                    if (query != null)
                    {
                        listRes = query.ToList();
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return listRes;
        }
    }
}
