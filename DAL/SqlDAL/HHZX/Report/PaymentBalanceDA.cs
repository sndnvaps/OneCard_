using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.IDAL.Report;
using Model.HHZX.Report;
using LinqToSQLModel;

namespace DAL.SqlDAL.HHZX.Report
{
    public class PaymentBalanceDA : IPaymentBalanceDA
    {
        #region IMainGeneralDA<PaymentBalance_Info> 成员

        public Model.General.ReturnValueInfo InsertRecord(Model.HHZX.Report.PaymentBalance_Info infoObject)
        {
            throw new NotImplementedException();
        }

        public Model.General.ReturnValueInfo UpdateRecord(Model.HHZX.Report.PaymentBalance_Info infoObject)
        {
            throw new NotImplementedException();
        }

        public Model.General.ReturnValueInfo DeleteRecord(Model.IModel.IModelObject KeyObject)
        {
            throw new NotImplementedException();
        }

        public Model.HHZX.Report.PaymentBalance_Info DisplayRecord(Model.IModel.IModelObject KeyObject)
        {
            throw new NotImplementedException();
        }

        public List<Model.HHZX.Report.PaymentBalance_Info> SearchRecords(Model.IModel.IModelObject searchCondition)
        {
            try
            {
                return SearchRecords(searchCondition, true, true);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Model.HHZX.Report.PaymentBalance_Info> SearchRecords(Model.IModel.IModelObject searchCondition, bool lIsWithMac, bool lIsWithPreCost)
        {
            List<PaymentBalance_Info> returnList = new List<PaymentBalance_Info>();
            try
            {
                PaymentBalance_Info info = searchCondition as PaymentBalance_Info;

                StringBuilder sbSQL = new StringBuilder();
                StringBuilder sbSQLMac = new StringBuilder();
                StringBuilder sbSQLPreCost = new StringBuilder();
                StringBuilder sbSQLMacWhere = new StringBuilder();
                StringBuilder sbSQLPreCostWhere = new StringBuilder();
                StringBuilder sbSQLTotalWhere = new StringBuilder();

                sbSQLMac.AppendLine("SELECT");
                sbSQLMac.AppendLine("cus_cStudentID,cus_cChaName,csr_fConsumeMoney,");
                sbSQLMac.AppendLine("csr_dConsumeDate,");
                sbSQLMac.AppendLine("(Convert(varchar,cmm_iMacNo)+'--'+MacTypeName) as MacNo,");
                sbSQLMac.AppendLine("csr_fCardBalance, ");
                sbSQLMac.AppendLine("case cus_cIdentityNum when 'STAFF' then ISNULL( dpm_cName,'')");
                sbSQLMac.AppendLine("when 'STUDENT' then ISNULL( csm_cClassName,'') else '' end as csm_cClassName");
                sbSQLMac.AppendLine(" FROM ConsumeRecord_csr ");
                sbSQLMac.AppendLine("join dbo.CardUserMaster_cus on cus_cRecordID = csr_cCardUserID ");
                sbSQLMac.AppendLine("left join dbo.ClassMaster_csm on csm_cRecordID = cus_cClassID ");
                sbSQLMac.AppendLine("left join dbo.DepartmentMaster_dpm on dpm_RecordID = cus_cClassID ");
                sbSQLMac.AppendLine(@"left join 
(select *,
 (case cmm_cUsageType 
 when 'StuSetmeal' then N'定餐机' 
 when 'StuPay' then N'加菜机'
 when 'TeachPay' then N'教师机' 
 when 'HotWaterPay' then N'热水机' 
 when 'DrinkPay' then N'饮料机' 
 else ''end) as MacTypeName
 from dbo.ConsumeMachineMaster_cmm) as ProFileCMM on cmm_cRecordID = csr_cMachineID ");
                sbSQLMac.AppendLine("where 1=1 ");

                if (info.ClassID != Guid.Empty)
                {
                    if (info.cus_cIdentityNum == Common.DefineConstantValue.CodeMasterDefine.KEY2_SIOT_CardUserIdentity_Staff)
                    {
                        sbSQLTotalWhere.AppendLine("and dpm_RecordID = '" + info.ClassID.ToString() + "' ");
                    }
                    else if (info.cus_cIdentityNum == Common.DefineConstantValue.CodeMasterDefine.KEY2_SIOT_CardUserIdentity_Student)
                    {
                        sbSQLTotalWhere.AppendLine("and csm_cRecordID = '" + info.ClassID.ToString() + "' ");
                    }
                }
                if (!String.IsNullOrEmpty(info.cus_cStudentID))
                {
                    sbSQLTotalWhere.AppendLine("and cus_cStudentID = '" + info.cus_cStudentID + "'");
                }
                if (!String.IsNullOrEmpty(info.cus_cChaName))
                {
                    sbSQLTotalWhere.AppendLine("and cus_cChaName like N'%" + info.cus_cChaName + "%'");
                }
                if (!string.IsNullOrEmpty(info.cus_cIdentityNum))
                {
                    sbSQLTotalWhere.AppendLine("and cus_cIdentityNum = '" + info.cus_cIdentityNum + "'");
                }

                if (info.TimeFrom != null && info.TimeTo != null)
                {
                    sbSQLMacWhere.AppendLine("and csr_dConsumeDate between '" + ((DateTime)(info.TimeFrom)).ToString("yyyy/MM/dd HH:mm:ss") + "' and '" + ((DateTime)(info.TimeTo)).ToString("yyyy/MM/dd HH:mm:ss") + "'");
                    sbSQLPreCostWhere.AppendLine("and pcs_dConsumeDate between '" + ((DateTime)(info.TimeFrom)).ToString("yyyy/MM/dd HH:mm:ss") + "' and '" + ((DateTime)(info.TimeTo)).ToString("yyyy/MM/dd HH:mm:ss") + "'");
                    //sbSQLPreCostWhere.AppendLine("and pcs_dSettleTime between '" + ((DateTime)(info.TimeFrom)).ToString("yyyy/MM/dd HH:mm:ss") + "' and '" + ((DateTime)(info.TimeTo)).ToString("yyyy/MM/dd HH:mm:ss") + "'");
                }
                if (!string.IsNullOrEmpty(info.MacNo) && info.MacNo != "0")
                {
                    int iMacNo = int.Parse(info.MacNo);
                    sbSQLMacWhere.AppendLine("and cmm_iMacNo = '" + iMacNo + "'");
                }

                sbSQLPreCost.AppendLine("SELECT");
                sbSQLPreCost.AppendLine("cus_cStudentID,cus_cChaName,pcs_fCost as csr_fConsumeMoney, ");
                sbSQLPreCost.AppendLine("pcs_dConsumeDate as csr_dConsumeDate,");
                sbSQLPreCost.AppendLine("case cuad_cFlowType  when 'NewCardCost' then N'新卡工本费补扣'  when 'ReplaceCardCost' then N'换卡工本费补扣'  when 'SetMealCost' then N'定餐费补扣' else N'系统补扣'  end as MacNo,");
                sbSQLPreCost.AppendLine("CONVERT(decimal,0) as csr_fCardBalance,");
                sbSQLPreCost.AppendLine("case cus_cIdentityNum when 'STAFF' then ISNULL( dpm_cName,'')");
                sbSQLPreCost.AppendLine("when 'STUDENT' then ISNULL( csm_cClassName,'') else '' end as csm_cClassName");
                sbSQLPreCost.AppendLine("from dbo.CardUserAccount_cua");
                sbSQLPreCost.AppendLine("join dbo.CardUserAccountDetail_cuad on cuad_cCUAID = cua_cRecordID");
                sbSQLPreCost.AppendLine("join dbo.PreConsumeRecord_pcs on pcs_cRecordID = cuad_cConsumeID");
                sbSQLPreCost.AppendLine("join dbo.CardUserMaster_cus on cus_cRecordID = cua_cCUSID");
                sbSQLPreCost.AppendLine("left join dbo.ClassMaster_csm on csm_cRecordID = cus_cClassID ");
                sbSQLPreCost.AppendLine("left join dbo.DepartmentMaster_dpm on dpm_RecordID = cus_cClassID ");
                sbSQLPreCost.AppendLine("where 1=1 and cuad_cFlowType <> 'HedgeFund'");

                using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                {
                    db.CommandTimeout = 10 * 60000;
                    if (lIsWithMac && lIsWithPreCost)//包含全部数据
                    {
                        sbSQL.AppendLine(sbSQLMac.ToString() + sbSQLMacWhere.ToString() + sbSQLTotalWhere.ToString());
                        sbSQL.AppendLine("union all");
                        sbSQL.AppendLine(sbSQLPreCost.ToString() + sbSQLPreCostWhere.ToString() + sbSQLTotalWhere.ToString());
                    }
                    else if (lIsWithMac && !lIsWithPreCost)//只有打卡数据
                    {
                        sbSQL.AppendLine(sbSQLMac.ToString() + sbSQLMacWhere.ToString() + sbSQLTotalWhere.ToString());
                    }
                    else if (!lIsWithMac && lIsWithPreCost)//只有补扣数据
                    {
                        sbSQL.AppendLine(sbSQLPreCost.ToString() + sbSQLPreCostWhere.ToString() + sbSQLTotalWhere.ToString());
                    }

                    IEnumerable<PaymentBalance_Info> query = db.ExecuteQuery<PaymentBalance_Info>(sbSQL.ToString(), new object[] { });
                    if (query != null)
                    {
                        returnList = query.ToList<PaymentBalance_Info>();
                    }
                }
            }
            catch
            {

            }
            return returnList;
        }

        public List<Model.HHZX.Report.PaymentBalance_Info> AllRecords()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
