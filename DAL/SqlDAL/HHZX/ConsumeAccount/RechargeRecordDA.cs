using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.IDAL.HHZX.ConsumeAccount;
using Model.HHZX.ComsumeAccount;
using Model.General;
using LinqToSQLModel;
using Model.IModel;
using Model.HHZX.Report;
using Common;
using DAL.Factory.HHZX;
using Model.HHZX.UserCard;
using System.Data.SqlClient;

namespace DAL.SqlDAL.HHZX.ConsumeAccount
{
    /// <summary>
    /// 充值记录（卡充值、卡退款、现金退款、批量充值、批量退款）
    /// </summary>
    public class RechargeRecordDA : IRechargeRecordDA
    {
        public ReturnValueInfo InsertRecord(RechargeRecord_rcr_Info infoObject)
        {
            ReturnValueInfo rvInfo = new ReturnValueInfo();
            try
            {
                if (infoObject != null)
                {
                    using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                    {
                        RechargeRecord_rcr record = Common.General.CopyObjectValue<RechargeRecord_rcr_Info, RechargeRecord_rcr>(infoObject);
                        if (record != null)
                        {
                            db.RechargeRecord_rcr.InsertOnSubmit(record);
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

        public ReturnValueInfo UpdateRecord(RechargeRecord_rcr_Info infoObject)
        {
            ReturnValueInfo rvInfo = new ReturnValueInfo();
            try
            {
                if (infoObject != null)
                {
                    using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                    {
                        RechargeRecord_rcr record = db.RechargeRecord_rcr.Where(x => x.rcr_cRecordID == infoObject.rcr_cRecordID).FirstOrDefault();

                        if (record != null)
                        {
                            record.rcr_cLast = infoObject.rcr_cLast;
                            record.rcr_cCardID = infoObject.rcr_cCardID;
                            record.rcr_cRechargeType = infoObject.rcr_cRechargeType;
                            record.rcr_cStatus = infoObject.rcr_cStatus;
                            record.rcr_cUserID = infoObject.rcr_cUserID;
                            record.rcr_dLastDate = infoObject.rcr_dLastDate;
                            record.rcr_fRechargeMoney = infoObject.rcr_fRechargeMoney;
                            record.rcr_dRechargeTime = infoObject.rcr_dRechargeTime;
                            record.rcr_cDesc = infoObject.rcr_cDesc;

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
                RechargeRecord_rcr_Info infoObject = KeyObject as RechargeRecord_rcr_Info;
                if (infoObject != null)
                {
                    using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                    {
                        RechargeRecord_rcr record = db.RechargeRecord_rcr.Where(x => x.rcr_cRecordID == infoObject.rcr_cRecordID).FirstOrDefault();

                        if (record != null)
                        {
                            db.RechargeRecord_rcr.DeleteOnSubmit(record);

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

        public RechargeRecord_rcr_Info DisplayRecord(IModelObject KeyObject)
        {
            RechargeRecord_rcr_Info resInfo = null;
            try
            {
                RechargeRecord_rcr_Info infoObject = KeyObject as RechargeRecord_rcr_Info;
                if (infoObject != null)
                {
                    using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                    {
                        RechargeRecord_rcr record = db.RechargeRecord_rcr.Where(x => x.rcr_cRecordID == infoObject.rcr_cRecordID).FirstOrDefault();

                        if (record != null)
                        {
                            resInfo = Common.General.CopyObjectValue<RechargeRecord_rcr, RechargeRecord_rcr_Info>(record);
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

        public List<RechargeRecord_rcr_Info> SearchRecords(IModelObject searchCondition)
        {
            List<RechargeRecord_rcr_Info> listRecordInfo = null;
            try
            {
                StringBuilder sbSQL = new StringBuilder();
                sbSQL.AppendLine("SELECT TOP");
                sbSQL.AppendLine(Common.DefineConstantValue.ListRecordMaxCount.ToString());
                sbSQL.AppendLine("rcr_cRecordID,rcr_cCardID,rcr_cUserID,rcr_fRechargeMoney,rcr_fBalance,rcr_dRechargeTime");
                sbSQL.AppendLine(",rcr_cRechargeType,rcr_cStatus,rcr_cDesc,rcr_cAdd,rcr_cLast,rcr_dLastDate");
                sbSQL.AppendLine("FROM RechargeRecord_rcr WHERE 1 = 1");

                RechargeRecord_rcr_Info searchInfo = searchCondition as RechargeRecord_rcr_Info;
                if (searchInfo != null)
                {
                    if (!string.IsNullOrEmpty(searchInfo.rcr_cCardID))
                        sbSQL.AppendLine("AND rcr_cCardID ='" + searchInfo.rcr_cCardID + "'");
                    if (searchInfo.rcr_cUserID != Guid.Empty)
                        sbSQL.AppendLine("AND rcr_cUserID ='" + searchInfo.rcr_cUserID.ToString() + "'");
                    if (!string.IsNullOrEmpty(searchInfo.rcr_cRechargeType))
                        sbSQL.AppendLine("AND rcr_cRechargeType ='" + searchInfo.rcr_cRechargeType + "'");
                    if (!string.IsNullOrEmpty(searchInfo.rcr_cStatus))
                        sbSQL.AppendLine("AND rcr_cStatus ='" + searchInfo.rcr_cStatus + "'");
                    if (searchInfo.rcr_dRechargeTime != DateTime.MinValue)
                        sbSQL.AppendLine("AND rcr_dRechargeTime ='" + searchInfo.rcr_dRechargeTime.ToString("yyyy-MM-dd HH:mm") + "'");
                    if (searchInfo.rcr_fRechargeMoney != 0)
                        sbSQL.AppendLine("AND rcr_fRechargeMoney =" + searchInfo.rcr_fRechargeMoney);
                }

                sbSQL.AppendLine("order by rcr_dRechargeTime desc");

                using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                {
                    IEnumerable<RechargeRecord_rcr_Info> query = db.ExecuteQuery<RechargeRecord_rcr_Info>(sbSQL.ToString(), new object[] { });
                    if (query != null)
                    {
                        listRecordInfo = query.ToList<RechargeRecord_rcr_Info>();
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return listRecordInfo;
        }

        public List<RechargeRecord_rcr_Info> SearchRecords(IModelObject itemEntity, DateTime dtBegin, DateTime dtEnd)
        {
            List<RechargeRecord_rcr_Info> listRecordInfo = null;
            try
            {
                StringBuilder sbSQL = new StringBuilder();
                sbSQL.AppendLine(@"SELECT [rcr_cRecordID],[rcr_cCardID],[rcr_cUserID],[rcr_fBalance]
      ,[rcr_dRechargeTime],[rcr_cStatus],[rcr_cDesc],[rcr_cAdd],[rcr_cLast]
      ,[rcr_dLastDate],[UserName]
      ,[GroupName]
      ,[rcr_cRechargeType]
      ,(case [rcr_cRechargeType]
      when 'Recharge_AdvanceMoney' then [rcr_fRechargeMoney]
      when 'Recharge_PersonalRealTime' then [rcr_fRechargeMoney]
      when 'Recharge_PersonalTransfer' then [rcr_fRechargeMoney]
      when 'Recharge_BatchTransfer' then [rcr_fRechargeMoney]
      when 'Refund_PersonalCash' then [rcr_fRechargeMoney] * -1
      when 'Refund_CardPersonalRealTime' then [rcr_fRechargeMoney] * -1
      when 'Refund_PersonalTransfer' then [rcr_fRechargeMoney] * -1
      when 'Refund_BatchTransfer' then [rcr_fRechargeMoney] * -1
      else ''
      end) as [rcr_fRechargeMoney]
      ,(case [rcr_cRechargeType]
      when 'Recharge_AdvanceMoney' then N'透支金额'
      when 'Recharge_PersonalRealTime' then N'实时卡充值'
      when 'Recharge_PersonalTransfer' then N'个人转账卡充值'
      when 'Recharge_BatchTransfer' then N'批量转账卡充值'
      when 'Refund_PersonalCash' then N'现金退款'
      when 'Refund_CardPersonalRealTime' then N'实时卡退款'
      when 'Refund_PersonalTransfer' then N'个人转账退款'
      when 'Refund_BatchTransfer' then N'个人批量退款'
      else ''
      end) as RechargeType
FROM
(
	SELECT [rcr_cRecordID],[rcr_cCardID],[rcr_cUserID],[rcr_fRechargeMoney],[rcr_fBalance]
      ,[rcr_dRechargeTime],[rcr_cStatus],[rcr_cDesc],[rcr_cAdd],[rcr_cLast],[rcr_cRechargeType]
      ,[rcr_dLastDate],[cus_cChaName] as [UserName],[csm_cClassName] as GroupName
	FROM [SIOTS_HHZXDB].[dbo].[RechargeRecord_rcr]
	  inner join CardUserMaster_cus
	on rcr_cUserID = cus_cRecordID
	and cus_cIdentityNum = 'STUDENT'
	left join ClassMaster_csm
	on csm_cRecordID = cus_cClassID
	UNION
	SELECT [rcr_cRecordID],[rcr_cCardID],[rcr_cUserID],[rcr_fRechargeMoney],[rcr_fBalance]
      ,[rcr_dRechargeTime],[rcr_cStatus],[rcr_cDesc],[rcr_cAdd],[rcr_cLast],[rcr_cRechargeType]
      ,[rcr_dLastDate],[cus_cChaName] as [UserName],[dpm_cName] as GroupName
	FROM [SIOTS_HHZXDB].[dbo].[RechargeRecord_rcr]
	  inner join CardUserMaster_cus
	on rcr_cUserID = cus_cRecordID
	and cus_cIdentityNum = 'STAFF'
	left join DepartmentMaster_dpm
	on dpm_RecordID = cus_cClassID
) AS RechargeDetail WHERE 1=1");

                RechargeRecord_rcr_Info searchInfo = itemEntity as RechargeRecord_rcr_Info;
                if (searchInfo != null)
                {
                    if (!string.IsNullOrEmpty(searchInfo.rcr_cCardID))
                        sbSQL.AppendLine("AND rcr_cCardID ='" + searchInfo.rcr_cCardID + "'");
                    if (searchInfo.rcr_cUserID != Guid.Empty)
                        sbSQL.AppendLine("AND rcr_cUserID ='" + searchInfo.rcr_cUserID.ToString() + "'");
                    if (!string.IsNullOrEmpty(searchInfo.rcr_cRechargeType))
                        sbSQL.AppendLine("AND rcr_cRechargeType ='" + searchInfo.rcr_cRechargeType + "'");
                    if (!string.IsNullOrEmpty(searchInfo.rcr_cStatus))
                        sbSQL.AppendLine("AND rcr_cStatus ='" + searchInfo.rcr_cStatus + "'");
                    if (searchInfo.rcr_fRechargeMoney != 0)
                        sbSQL.AppendLine("AND rcr_fRechargeMoney =" + searchInfo.rcr_fRechargeMoney);
                    sbSQL.AppendLine("AND rcr_dRechargeTime >= '" + dtBegin.ToString("yyyy-MM-dd 00:00:00") + "'");
                    sbSQL.AppendLine("AND rcr_dRechargeTime <= '" + dtEnd.ToString("yyyy-MM-dd 23:59:59") + "'");
                }

                using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                {
                    IEnumerable<RechargeRecord_rcr_Info> query = db.ExecuteQuery<RechargeRecord_rcr_Info>(sbSQL.ToString(), new object[] { });
                    if (query != null)
                    {
                        listRecordInfo = query.ToList<RechargeRecord_rcr_Info>();
                        if (listRecordInfo != null && listRecordInfo.Count > 0)
                        {
                            listRecordInfo = listRecordInfo.OrderByDescending(x => x.rcr_dRechargeTime).ToList();
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return listRecordInfo;
        }

        public List<RechargeRecord_rcr_Info> AllRecords()
        {
            List<RechargeRecord_rcr_Info> listRecord = null;
            try
            {
                StringBuilder sbSQL = new StringBuilder();
                sbSQL.AppendLine("SELECT ");
                sbSQL.AppendLine("* FROM RechargeRecord_rcr WHERE 1 = 1");

                using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                {
                    IEnumerable<RechargeRecord_rcr_Info> query = db.ExecuteQuery<RechargeRecord_rcr_Info>(sbSQL.ToString(), new object[] { });
                    if (query != null)
                    {
                        listRecord = query.ToList<RechargeRecord_rcr_Info>();
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return listRecord;
        }

        #region 报表相关

        /// <summary>
        /// 增减款记录
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public List<AmountOfChange_aoc_Info> AccountDetailList(AmountOfChange_aoc_Info query)
        {
            List<AmountOfChange_aoc_Info> listRecord = new List<AmountOfChange_aoc_Info>();

            StringBuilder sbSQL = new StringBuilder();
            #region
            //sbSQL.AppendLine("select CONVERT(datetime, '" + query.startDate.Value.ToString("yyyy-MM-dd") + "') as startDate,CONVERT(datetime, '" + query.endDate.Value.ToString("yyyy-MM-dd") + "') as endDate,ISNULL( cus_cChaName,'') as aoc_cName, ");
            //sbSQL.AppendLine("case cus_cIdentityNum");
            //sbSQL.AppendLine("when '" + DefineConstantValue.CodeMasterDefine.KEY2_SIOT_CardUserIdentity_Staff + "' then ISNULL( dpm_cName,'')");
            //sbSQL.AppendLine("when '" + DefineConstantValue.CodeMasterDefine.KEY2_SIOT_CardUserIdentity_Student + "' then ISNULL( csm_cClassName,'')");
            //sbSQL.AppendLine("else ''");
            //sbSQL.AppendLine("end");
            //sbSQL.AppendLine("as aoc_cDepartment,");
            //sbSQL.AppendLine("cus_cStudentID,");
            //sbSQL.AppendLine("case rcr_cRechargeType");
            //sbSQL.AppendLine("when '" + DefineConstantValue.ConsumeMoneyFlowType.Recharge_AdvanceMoney.ToString() + "' then ISNULL( rcr_fRechargeMoney ,CONVERT(decimal,0))");
            //sbSQL.AppendLine("when '" + DefineConstantValue.ConsumeMoneyFlowType.Recharge_PersonalRealTime.ToString() + "' then ISNULL( rcr_fRechargeMoney ,CONVERT(decimal,0))");
            //sbSQL.AppendLine("when '" + DefineConstantValue.ConsumeMoneyFlowType.Recharge_PersonalTransfer.ToString() + "' then ISNULL( rcr_fRechargeMoney ,CONVERT(decimal,0))");
            //sbSQL.AppendLine("when '" + DefineConstantValue.ConsumeMoneyFlowType.Recharge_BatchTransfer.ToString() + "' then ISNULL( rcr_fRechargeMoney ,CONVERT(decimal,0))");
            //sbSQL.AppendLine("select CONVERT(datetime, '" + query.startDate.Value.ToString("yyyy-MM-dd") + "') as startDate,CONVERT(datetime, '" + query.endDate.Value.ToString("yyyy-MM-dd") + "') as endDate,ISNULL( cus_cChaName,'') as aoc_cName, ");
            //sbSQL.AppendLine("case cus_cIdentityNum");
            //sbSQL.AppendLine("when '" + DefineConstantValue.CodeMasterDefine.KEY2_SIOT_CardUserIdentity_Staff + "' then ISNULL( dpm_cName,'')");
            //sbSQL.AppendLine("when '" + DefineConstantValue.CodeMasterDefine.KEY2_SIOT_CardUserIdentity_Student + "' then ISNULL( csm_cClassName,'')");
            //sbSQL.AppendLine("else ''");
            //sbSQL.AppendLine("end");
            //sbSQL.AppendLine("as aoc_cDepartment,");
            //sbSQL.AppendLine("cus_cStudentID,");
            //sbSQL.AppendLine("case rcr_cRechargeType");
            //sbSQL.AppendLine("when '" + DefineConstantValue.ConsumeMoneyFlowType.Recharge_AdvanceMoney.ToString() + "' then ISNULL( rcr_fRechargeMoney ,CONVERT(decimal,0))");
            //sbSQL.AppendLine("when '" + DefineConstantValue.ConsumeMoneyFlowType.Recharge_PersonalRealTime.ToString() + "' then ISNULL( rcr_fRechargeMoney ,CONVERT(decimal,0))");
            //sbSQL.AppendLine("when '" + DefineConstantValue.ConsumeMoneyFlowType.Recharge_PersonalTransfer.ToString() + "' then ISNULL( rcr_fRechargeMoney ,CONVERT(decimal,0))");
            //sbSQL.AppendLine("when '" + DefineConstantValue.ConsumeMoneyFlowType.Recharge_BatchTransfer.ToString() + "' then ISNULL( rcr_fRechargeMoney ,CONVERT(decimal,0))");

            //sbSQL.AppendLine("when '" + DefineConstantValue.ConsumeMoneyFlowType.Refund_PersonalCash.ToString() + "' then 0-ISNULL( rcr_fRechargeMoney ,CONVERT(decimal,0))");
            //sbSQL.AppendLine("when '" + DefineConstantValue.ConsumeMoneyFlowType.Refund_CardPersonalRealTime.ToString() + "' then 0-ISNULL( rcr_fRechargeMoney ,CONVERT(decimal,0))");
            //sbSQL.AppendLine("when '" + DefineConstantValue.ConsumeMoneyFlowType.Refund_PersonalTransfer.ToString() + "' then 0-ISNULL( rcr_fRechargeMoney ,CONVERT(decimal,0))");
            //sbSQL.AppendLine("when '" + DefineConstantValue.ConsumeMoneyFlowType.Refund_BatchTransfer.ToString() + "' then 0-ISNULL( rcr_fRechargeMoney ,CONVERT(decimal,0))");
            //sbSQL.AppendLine("else 0");
            //sbSQL.AppendLine("end");
            //sbSQL.AppendLine("as aoc_dMoney,");
            //sbSQL.AppendLine("ISNULL(rcr_fBalance ,CONVERT(decimal,0))as aoc_dAmount,");
            //sbSQL.AppendLine("rcr_dRechargeTime as aoc_opTime");
            //sbSQL.AppendLine("from dbo.RechargeRecord_rcr");
            //sbSQL.AppendLine("left join dbo.CardUserMaster_cus");
            //sbSQL.AppendLine("on rcr_cUserID=cus_cRecordID");
            //sbSQL.AppendLine("left join dbo.ClassMaster_csm");
            //sbSQL.AppendLine("on cus_cClassID=csm_cRecordID");
            //sbSQL.AppendLine("left join dbo.DepartmentMaster_dpm");
            //sbSQL.AppendLine("on cus_cClassID=dpm_RecordID");
            //sbSQL.AppendLine("where 1=1");
            //sbSQL.AppendLine("and");
            //sbSQL.AppendLine("( ");
            ////sbSQL.AppendLine("rcr_cRechargeType='" + DefineConstantValue.ConsumeMoneyFlowType.Recharge_AdvanceMoney.ToString() + "' or ");
            //sbSQL.AppendLine(" rcr_cRechargeType='" + DefineConstantValue.ConsumeMoneyFlowType.Recharge_PersonalRealTime.ToString() + "'");
            //sbSQL.AppendLine("or rcr_cRechargeType='" + DefineConstantValue.ConsumeMoneyFlowType.Recharge_PersonalTransfer.ToString() + "'");
            //sbSQL.AppendLine("or rcr_cRechargeType='" + DefineConstantValue.ConsumeMoneyFlowType.Recharge_BatchTransfer.ToString() + "'");

            //sbSQL.AppendLine("or rcr_cRechargeType='" + DefineConstantValue.ConsumeMoneyFlowType.Refund_PersonalCash.ToString() + "'");
            //sbSQL.AppendLine("or rcr_cRechargeType='" + DefineConstantValue.ConsumeMoneyFlowType.Refund_CardPersonalRealTime.ToString() + "'");
            //sbSQL.AppendLine("or rcr_cRechargeType='" + DefineConstantValue.ConsumeMoneyFlowType.Refund_PersonalTransfer.ToString() + "'");
            //sbSQL.AppendLine("or rcr_cRechargeType='" + DefineConstantValue.ConsumeMoneyFlowType.Refund_BatchTransfer.ToString() + "'");
            //sbSQL.AppendLine(")");
            //sbSQL.AppendLine("and rcr_cStatus='" + DefineConstantValue.ConsumeMoneyFlowStatus.Finished.ToString() + "'");
            //            #endregion
            //            if (!String.IsNullOrEmpty(query.selectMenu))
            //            {
            //=======
            //sbSQL.AppendLine("or rcr_cRechargeType='" + DefineConstantValue.ConsumeMoneyFlowType.Refund_PersonalCash.ToString() + "'");
            //sbSQL.AppendLine("or rcr_cRechargeType='" + DefineConstantValue.ConsumeMoneyFlowType.Refund_CardPersonalRealTime.ToString() + "'");
            //sbSQL.AppendLine("or rcr_cRechargeType='" + DefineConstantValue.ConsumeMoneyFlowType.Refund_PersonalTransfer.ToString() + "'");
            //sbSQL.AppendLine("or rcr_cRechargeType='" + DefineConstantValue.ConsumeMoneyFlowType.Refund_BatchTransfer.ToString() + "'");
            //sbSQL.AppendLine(")");
            //sbSQL.AppendLine("and rcr_cStatus='" + DefineConstantValue.ConsumeMoneyFlowStatus.Finished.ToString() + "'");
            #endregion
            if (!String.IsNullOrEmpty(query.selectMenu))
            {
                //现金充值，退款，实时退款
                sbSQL.AppendLine("select CONVERT(datetime, '" + query.startDate.Value.ToString("yyyy-MM-dd") + "') as startDate,CONVERT(datetime, '" + query.endDate.Value.ToString("yyyy-MM-dd") + "') ");
                sbSQL.AppendLine("as endDate,ISNULL( cus_cChaName,\'') as aoc_cName, ");
                sbSQL.AppendLine("case cus_cIdentityNum");
                sbSQL.AppendLine("when 'STAFF' then ISNULL( dpm_cName,'')");
                sbSQL.AppendLine("when 'STUDENT' then ISNULL( csm_cClassName,'')");
                sbSQL.AppendLine("else ''");
                sbSQL.AppendLine("end");
                sbSQL.AppendLine("as aoc_cDepartment,");
                sbSQL.AppendLine("cus_cStudentID,");
                sbSQL.AppendLine("case cuad_cFlowType");
                sbSQL.AppendLine("when 'Recharge_AdvanceMoney' then ISNULL( cuad_fFlowMoney ,CONVERT(decimal,0))");
                sbSQL.AppendLine("when 'Recharge_PersonalRealTime' then ISNULL( cuad_fFlowMoney ,CONVERT(decimal,0))");
                sbSQL.AppendLine("when 'Recharge_PersonalTransfer' then ISNULL( cuad_fFlowMoney ,CONVERT(decimal,0))");
                sbSQL.AppendLine("when 'Recharge_BatchTransfer' then ISNULL( cuad_fFlowMoney ,CONVERT(decimal,0))");
                sbSQL.AppendLine("when 'Refund_PersonalCash' then 0-ISNULL( cuad_fFlowMoney ,CONVERT(decimal,0))");
                sbSQL.AppendLine("when 'Refund_CardPersonalRealTime' then 0-ISNULL( cuad_fFlowMoney ,CONVERT(decimal,0))");
                sbSQL.AppendLine("when 'Refund_PersonalTransfer' then 0-ISNULL( cuad_fFlowMoney ,CONVERT(decimal,0))");
                sbSQL.AppendLine("when 'Refund_BatchTransfer' then 0-ISNULL( cuad_fFlowMoney ,CONVERT(decimal,0))");
                sbSQL.AppendLine("else 0");
                sbSQL.AppendLine("end");
                sbSQL.AppendLine("as aoc_dMoney,");
                sbSQL.AppendLine("ISNULL(cua_fCurrentBalance ,CONVERT(decimal,0))as aoc_dAmount,");
                sbSQL.AppendLine("cuad_dOptTime as aoc_opTime");
                sbSQL.AppendLine(@",case cuad_cFlowType
when 'Recharge_AdvanceMoney' then N'透支款'
when 'Recharge_PersonalRealTime' then N'个人实时充值'
when 'Recharge_PersonalTransfer' then N'个人转账充值'
when 'Recharge_BatchTransfer' then N'批量转账充值'
when 'Refund_PersonalCash' then N'现金退款'
when 'Refund_CardPersonalRealTime' then N'个人卡退款'
when 'Refund_PersonalTransfer' then N'个人转账退款'
when 'Refund_BatchTransfer' then N'批量转账退款'
else N'异常类型款项'
end
as aoc_cFlowType");
                sbSQL.AppendLine("from dbo.CardUserAccountDetail_cuad with(nolock)");
                sbSQL.AppendLine("join dbo.CardUserAccount_cua with(nolock)");
                sbSQL.AppendLine("on cuad_cCUAID = cua_cRecordID");
                sbSQL.AppendLine("left join dbo.CardUserMaster_cus with(nolock)");
                sbSQL.AppendLine("on cua_cCUSID=cus_cRecordID");
                sbSQL.AppendLine("left join dbo.ClassMaster_csm with(nolock)");
                sbSQL.AppendLine("on cus_cClassID=csm_cRecordID");
                sbSQL.AppendLine("left join dbo.DepartmentMaster_dpm with(nolock)");
                sbSQL.AppendLine("on cus_cClassID=dpm_RecordID");
                sbSQL.AppendLine("where 1=1");

                if (!String.IsNullOrEmpty(query.selectMenu))
                {
                    sbSQL.AppendLine("and cuad_cFlowType in ( ");
                    sbSQL.AppendLine(query.selectMenu);
                    sbSQL.AppendLine(")");
                }

                if (query.startDate != null)
                {
                    sbSQL.AppendLine("and cuad_dOptTime>='" + query.startDate.Value.ToString("yyyy-MM-dd") + " 00:00:00'");
                }
                if (query.endDate != null)
                {
                    sbSQL.AppendLine("and cuad_dOptTime<'" + query.endDate.Value.AddDays(1).ToString("yyyy-MM-dd") + " 00:00:00'");
                }
                if (!String.IsNullOrEmpty(query.cus_cStudentID))
                {
                    sbSQL.AppendLine("and cus_cStudentID ='" + query.cus_cStudentID + "'");
                }
                if (!string.IsNullOrEmpty(query.cus_cIdentityNum))
                {
                    sbSQL.AppendLine("and cus_cIdentityNum = '" + query.cus_cIdentityNum + "'");
                    if (query.cus_cIdentityNum == Common.DefineConstantValue.CodeMasterDefine.KEY2_SIOT_CardUserIdentity_Staff)
                    {
                        if (query.classID != Guid.Empty)
                        {
                            sbSQL.AppendLine("and dpm_RecordID = '" + query.classID + "'");
                        }
                    }
                    else if (query.cus_cIdentityNum == Common.DefineConstantValue.CodeMasterDefine.KEY2_SIOT_CardUserIdentity_Student)
                    {
                        if (query.classID != Guid.Empty)
                        {
                            sbSQL.AppendLine("and csm_cRecordID = '" + query.classID + "'");
                        }
                    }
                }
                if (!String.IsNullOrEmpty(query.aoc_cName))
                {
                    sbSQL.AppendLine("and cus_cChaName like N'%" + query.aoc_cName + "%'");
                }
            }


            //转帐充值，转账退款
            if (query.IsRechargeTransfer || query.IsRefundTransfer)
            {
                if (!String.IsNullOrEmpty(sbSQL.ToString()))
                {
                    sbSQL.AppendLine("union all");
                }

                sbSQL.AppendLine("select ");
                sbSQL.AppendLine("CONVERT(datetime, '" + query.startDate.Value.ToString("yyyy-MM-dd") + "') as startDate,CONVERT(datetime, '" + query.endDate.Value.ToString("yyyy-MM-dd") + "') ");
                sbSQL.AppendLine("as endDate,ISNULL( cus_cChaName,'') as aoc_cName,");
                sbSQL.AppendLine("case cus_cIdentityNum");
                sbSQL.AppendLine("when 'STAFF' then ISNULL( dpm_cName,'')");
                sbSQL.AppendLine("when 'STUDENT' then ISNULL( csm_cClassName,'')");
                sbSQL.AppendLine("else '' end as aoc_cDepartment, cus_cStudentID,");
                sbSQL.AppendLine("ISNULL( prr_fRechargeMoney ,CONVERT(decimal,0)) as aoc_dMoney,");
                sbSQL.AppendLine("ISNULL(cua_fCurrentBalance ,CONVERT(decimal,0))as aoc_dAmount,");
                sbSQL.AppendLine("prr_dAddDate as aoc_opTime");
                sbSQL.AppendLine(@",case prr_cRechargeType
when 'Recharge_PersonalTransfer' then N'个人转账充值'
when 'Recharge_BatchTransfer' then N'批量转账充值'
when 'Refund_PersonalTransfer' then N'个人转账退款'
when 'Refund_BatchTransfer' then N'批量转账退款'
else N'异常类型款项' end as aoc_cFlowType");
                sbSQL.AppendLine("from ");
                sbSQL.AppendLine("dbo.PreRechargeRecord_prr with(nolock) ");
                sbSQL.AppendLine("join dbo.CardUserMaster_cus with(nolock) ");
                sbSQL.AppendLine("on cus_cRecordID = prr_cUserID");
                sbSQL.AppendLine("join dbo.CardUserAccount_cua with(nolock)");
                sbSQL.AppendLine("on cua_cCUSID = cus_cRecordID");
                sbSQL.AppendLine("left join dbo.ClassMaster_csm with(nolock)");
                sbSQL.AppendLine("on cus_cClassID=csm_cRecordID");
                sbSQL.AppendLine("left join dbo.DepartmentMaster_dpm with(nolock)");
                sbSQL.AppendLine("on cus_cClassID=dpm_RecordID where 1=1 ");
                sbSQL.AppendLine("and prr_cRechargeType in(");
                if (query.IsRechargeTransfer)
                {
                    sbSQL.AppendLine("'" + Common.DefineConstantValue.ConsumeMoneyFlowType.Recharge_PersonalTransfer.ToString() + "',");
                    sbSQL.AppendLine("'" + Common.DefineConstantValue.ConsumeMoneyFlowType.Recharge_BatchTransfer.ToString() + "'");
                }
                if (query.IsRefundTransfer)
                {
                    if (query.IsRechargeTransfer)
                    {
                        sbSQL.AppendLine(",");
                    }
                    sbSQL.AppendLine("'" + Common.DefineConstantValue.ConsumeMoneyFlowType.Refund_BatchTransfer.ToString() + "',");
                    sbSQL.AppendLine("'" + Common.DefineConstantValue.ConsumeMoneyFlowType.Refund_PersonalTransfer.ToString() + "'");
                }
                sbSQL.AppendLine(")");

                #region 15/11/2013 Add by Donald 特殊筛选（详见注释）
                //用于筛出旧系统过渡入新系统的批量转账，该批数据的特征为，预转账时间均为'2012-01-01 00:00:00'

                sbSQL.AppendLine(@"and prr_cRecordID not in(
select prr_cRecordID from
(
select * from PreRechargeRecord_prr with(nolock)
left join RechargeRecord_rcr with(nolock) on prr_cRCRID = rcr_cRecordID
left join CardUserAccountDetail_cuad with(nolock) on cuad_cConsumeID = rcr_cRecordID
where prr_cRechargeType = 'Recharge_BatchTransfer'
and prr_dAddDate < '2013-09-03'
) AS ccc)");

                #endregion

                if (query.startDate != null)
                {
                    sbSQL.AppendLine("and prr_dAddDate>='" + query.startDate.Value.ToString("yyyy-MM-dd") + " 00:00:00'");
                }
                if (query.endDate != null)
                {
                    sbSQL.AppendLine("and prr_dAddDate <'" + query.endDate.Value.AddDays(1).ToString("yyyy-MM-dd") + " 00:00:00'");
                }
                if (!String.IsNullOrEmpty(query.cus_cStudentID))
                {
                    sbSQL.AppendLine("and cus_cStudentID ='" + query.cus_cStudentID + "'");
                }
                if (!string.IsNullOrEmpty(query.cus_cIdentityNum))
                {
                    sbSQL.AppendLine("and cus_cIdentityNum = '" + query.cus_cIdentityNum + "'");
                    if (query.cus_cIdentityNum == Common.DefineConstantValue.CodeMasterDefine.KEY2_SIOT_CardUserIdentity_Staff)
                    {
                        if (query.classID != Guid.Empty)
                        {
                            sbSQL.AppendLine("and dpm_RecordID = '" + query.classID + "'");
                        }
                    }
                    else if (query.cus_cIdentityNum == Common.DefineConstantValue.CodeMasterDefine.KEY2_SIOT_CardUserIdentity_Student)
                    {
                        if (query.classID != Guid.Empty)
                        {
                            sbSQL.AppendLine("and csm_cRecordID = '" + query.classID + "'");
                        }
                    }
                }
                if (!String.IsNullOrEmpty(query.aoc_cName))
                {
                    sbSQL.AppendLine("and cus_cChaName like N'%" + query.aoc_cName + "%'");
                }
            }

            try
            {
                if (String.IsNullOrEmpty(sbSQL.ToString()))
                {
                    return listRecord;
                }

                using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                {
                    db.CommandTimeout = 600000;
                    IEnumerable<AmountOfChange_aoc_Info> queryData = db.ExecuteQuery<AmountOfChange_aoc_Info>(sbSQL.ToString(), new object[] { });
                    if (query != null)
                    {
                        listRecord = queryData.ToList<AmountOfChange_aoc_Info>();
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

        #region IRechargeRecordDA Members

        public ReturnValueInfo InsertRechargeRecord(IModelObject itemEntity)
        {
            ReturnValueInfo rvInfo = new ReturnValueInfo();
            try
            {
                RechargeRecord_rcr_Info sourceInfo = itemEntity as RechargeRecord_rcr_Info;
                if (sourceInfo == null)
                {
                    rvInfo.messageText = DefineConstantValue.SystemMessageText.strMessageText_E_ObjectNull;
                    rvInfo.isError = true;
                    return rvInfo;
                }

                //判断是否为需要录入用户账户中的记录
                bool isUserDetail = IsUserAccountRecord(sourceInfo);
                // 判断是否为需要录入到系统账户中的记录
                bool isSysDetail = IsSysAccountRecord(sourceInfo);

                //使用服务器时间更新记录时间
                sourceInfo.rcr_dRechargeTime = DateTime.Now;
                sourceInfo.rcr_dLastDate = sourceInfo.rcr_dRechargeTime;

                RechargeRecord_rcr rechargeRecord = Common.General.CopyObjectValue<RechargeRecord_rcr_Info, RechargeRecord_rcr>(sourceInfo);
                if (rechargeRecord == null)
                {
                    rvInfo.isError = true;
                    rvInfo.messageText = DefineConstantValue.SystemMessageText.strMessageText_E_ObjectNull;
                    return rvInfo;
                }

                using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                {
                    //用于批量统一插数
                    List<PreConsumeRecord_pcs> listToInsertPreCost = new List<PreConsumeRecord_pcs>();
                    List<CardUserAccountDetail_cuad> listToInsertAccountDetail = new List<CardUserAccountDetail_cuad>();
                    List<SystemAccountDetail_sad> listToInsertSysDetail = new List<SystemAccountDetail_sad>();

                    //获取账户信息
                    CardUserAccount_cua account = db.CardUserAccount_cua.Where(x => x.cua_cCUSID == sourceInfo.rcr_cUserID).FirstOrDefault();
                    #region 账户信息丢失时，自动创建账户信息

                    if (account == null)
                    {
                        account = new CardUserAccount_cua();
                        account.cua_cRecordID = Guid.NewGuid();
                        account.cua_cCUSID = sourceInfo.rcr_cUserID;
                        account.cua_cAdd = sourceInfo.rcr_cLast;
                        account.cua_dAddDate = DateTime.Now;
                        account.cua_dLastSyncTime = DateTime.Now;
                        account.cua_lIsActive = true;
                        account.cua_fCurrentBalance = decimal.Zero;
                        account.cua_fOriginalBalance = decimal.Zero;
                        db.CardUserAccount_cua.InsertOnSubmit(account);
                        db.SubmitChanges();
                    }

                    #endregion

                    if (isUserDetail)
                    {
                        //同步插入一条用户资金流动记录
                        #region 同步用户资金流动记录

                        CardUserAccountDetail_cuad accountDetail = new CardUserAccountDetail_cuad();
                        accountDetail.cuad_cRecordID = Guid.NewGuid();
                        accountDetail.cuad_cConsumeID = sourceInfo.rcr_cRecordID;//消费源ID
                        accountDetail.cuad_cCUAID = account.cua_cRecordID;//账户ID
                        accountDetail.cuad_fFlowMoney = sourceInfo.rcr_fRechargeMoney + Math.Abs(sourceInfo.PreCostMoney);//账户当次充值金额=卡实际充值金额+应付欠款
                        accountDetail.cuad_cFlowType = sourceInfo.rcr_cRechargeType;
                        accountDetail.cuad_cOpt = sourceInfo.rcr_cAdd;
                        accountDetail.cuad_dOptTime = sourceInfo.rcr_dRechargeTime;
                        listToInsertAccountDetail.Add(accountDetail);

                        #endregion
                    }

                    if (isSysDetail)
                    {
                        //同步插入一条系统资金现金流
                        #region 同步系统资金流动记录

                        SystemAccountDetail_sad sysAccountInfo = new SystemAccountDetail_sad();
                        sysAccountInfo.sad_cRecordID = Guid.NewGuid();
                        sysAccountInfo.sad_cConsumeID = sourceInfo.rcr_cRecordID;//消费源ID
                        sysAccountInfo.sad_cDesc = sourceInfo.rcr_cDesc;//充值或退款描述
                        sysAccountInfo.sad_cFLowMoney = sourceInfo.rcr_fRechargeMoney + Math.Abs(sourceInfo.PreCostMoney);
                        sysAccountInfo.sad_cFlowType = sourceInfo.rcr_cRechargeType;
                        sysAccountInfo.sad_cOpt = sourceInfo.rcr_cAdd;
                        sysAccountInfo.sad_dOptTime = sourceInfo.rcr_dRechargeTime;
                        listToInsertSysDetail.Add(sysAccountInfo);
                        #endregion
                    }

                    //找出该用户最后一条透支充值记录
                    decimal fAdvance = 0;
                    #region 获取用户的预充值金额（透支款）

                    List<RechargeRecord_rcr> listRechargeRecord = db.RechargeRecord_rcr.Where(x =>
                        x.rcr_cRechargeType == DefineConstantValue.ConsumeMoneyFlowType.Recharge_AdvanceMoney.ToString()
                        && x.rcr_cUserID == sourceInfo.rcr_cUserID
                        ).ToList();
                    if (listRechargeRecord != null && listRechargeRecord.Count > 0)
                    {
                        listRechargeRecord = listRechargeRecord.OrderByDescending(x => x.rcr_dRechargeTime).ToList();
                        fAdvance = listRechargeRecord[0].rcr_fRechargeMoney;
                    }

                    #endregion

                    decimal fCurrentBalance = decimal.Zero;
                    //判断是否需要同步处理欠款结算
                    if (Math.Abs(sourceInfo.PreCostMoney) > 0 || sourceInfo.IsNeedSyncAccount)//需要欠款金额大于零及标识为需要同步
                    {
                        //若预付款还款值大于0，则存入充值账户
                        #region 存入预付款还款

                        List<PreConsumeRecord_pcs> listPreCost = db.PreConsumeRecord_pcs.Where(x =>
                            x.pcs_lIsSettled == false//状态为未结算
                            && x.pcs_cAccountID == account.cua_cRecordID//配对用户账号ID
                            && x.pcs_cUserID == sourceInfo.rcr_cUserID//配对用户ID
                            && x.pcs_cConsumeType != DefineConstantValue.ConsumeMoneyFlowType.IndeterminateCost.ToString()//非未确定扣费款项
                            && x.pcs_cConsumeType != DefineConstantValue.ConsumeMoneyFlowType.AdvanceMealCost.ToString()//非待扣费款项
                            && x.pcs_cConsumeType != DefineConstantValue.ConsumeMoneyFlowType.HedgeFund.ToString()//非对冲款项
                            ).ToList();

                        decimal sumPreCost = listPreCost.Sum(x => x.pcs_fCost);
                        if (Math.Abs(sourceInfo.PreCostMoney) < Math.Abs(sumPreCost))//判断该次充值时缴纳的应付款总额是否足以扣除当前全部欠款
                        {
                            //不足以扣除
                            db.Transaction.Rollback();
                            db.Connection.Close();
                            rvInfo.messageText = "支付额不足以支付待结算的预付款。";
                            return rvInfo;
                        }

                        //用户需要结算的欠款记录
                        List<CardUserAccountDetail_cuad> listPreUserCost = new List<CardUserAccountDetail_cuad>();
                        List<SystemAccountDetail_sad> listPreSysIncome = new List<SystemAccountDetail_sad>();
                        foreach (PreConsumeRecord_pcs preItem in listPreCost)
                        {
                            preItem.pcs_lIsSettled = true;
                            preItem.pcs_dSettleTime = DateTime.Now;

                            //结算的同时插入一条账户支出记录
                            CardUserAccountDetail_cuad userAccount = new CardUserAccountDetail_cuad();
                            userAccount.cuad_cRecordID = Guid.NewGuid();
                            userAccount.cuad_cConsumeID = preItem.pcs_cRecordID;
                            userAccount.cuad_cCUAID = account.cua_cRecordID;
                            userAccount.cuad_cFlowType = preItem.pcs_cConsumeType;
                            userAccount.cuad_cOpt = sourceInfo.rcr_cLast;
                            userAccount.cuad_dOptTime = DateTime.Now;
                            userAccount.cuad_fFlowMoney = preItem.pcs_fCost;
                            listPreUserCost.Add(userAccount);

                            //结算的同时插入一条系统账户收入记录
                            SystemAccountDetail_sad sysAccount = new SystemAccountDetail_sad();
                            sysAccount.sad_cRecordID = Guid.NewGuid();
                            sysAccount.sad_cConsumeID = preItem.pcs_cRecordID;
                            sysAccount.sad_cDesc = DefineConstantValue.GetMoneyFlowDesc(preItem.pcs_cConsumeType);
                            sysAccount.sad_cFLowMoney = preItem.pcs_fCost;
                            sysAccount.sad_cFlowType = preItem.pcs_cConsumeType;
                            sysAccount.sad_cOpt = sourceInfo.rcr_cLast;
                            sysAccount.sad_dOptTime = DateTime.Now;
                            listPreSysIncome.Add(sysAccount);
                        }

                        if (listPreUserCost.Count > 0)
                        {
                            listToInsertAccountDetail.AddRange(listPreUserCost);
                            listToInsertSysDetail.AddRange(listPreSysIncome);
                        }

                        #endregion

                        //更新账户余额
                        decimal fAccountUpdate = account.cua_fCurrentBalance + sourceInfo.rcr_fRechargeMoney;//充值后账户余额=当前账户余额+实际充值金额
                        decimal fCardBalance = sourceInfo.rcr_fBalance - fAdvance;//充值后卡余额 = 卡当前余额 - 透支金额

                        if (fAccountUpdate > fCardBalance)//【系统账户余额】 大于 【卡实际余额】
                        {
                            #region 进行平数处理

                            // 新增一条平数的预扣费记录
                            decimal fUnconfirmCost = fAccountUpdate - fCardBalance;//需要对冲款 = 账户当前余额 - 卡当前余额

                            PreConsumeRecord_pcs unconfirmRecord = new PreConsumeRecord_pcs();
                            unconfirmRecord.pcs_cRecordID = Guid.NewGuid();
                            unconfirmRecord.pcs_cAccountID = account.cua_cRecordID;
                            unconfirmRecord.pcs_cUserID = sourceInfo.rcr_cUserID;
                            unconfirmRecord.pcs_cConsumeType = DefineConstantValue.ConsumeMoneyFlowType.HedgeFund.ToString();
                            unconfirmRecord.pcs_dConsumeDate = DateTime.Now;
                            unconfirmRecord.pcs_fCost = fUnconfirmCost;
                            unconfirmRecord.pcs_lIsSettled = false;//状态设置为未结算，等待账户同步服务同步时结算清数
                            unconfirmRecord.pcs_cAdd = sourceInfo.rcr_cLast;
                            unconfirmRecord.pcs_dAddDate = DateTime.Now;
                            listToInsertPreCost.Add(unconfirmRecord);

                            //用户账户
                            CardUserAccountDetail_cuad userAccount = new CardUserAccountDetail_cuad();
                            userAccount.cuad_cRecordID = Guid.NewGuid();
                            userAccount.cuad_cConsumeID = unconfirmRecord.pcs_cRecordID;
                            userAccount.cuad_cCUAID = account.cua_cRecordID;
                            userAccount.cuad_cFlowType = unconfirmRecord.pcs_cConsumeType;
                            userAccount.cuad_cOpt = sourceInfo.rcr_cLast;
                            userAccount.cuad_dOptTime = DateTime.Now;
                            userAccount.cuad_fFlowMoney = fUnconfirmCost;
                            listToInsertAccountDetail.Add(userAccount);

                            //系统账户
                            SystemAccountDetail_sad sysAccount = new SystemAccountDetail_sad();
                            sysAccount.sad_cRecordID = Guid.NewGuid();
                            sysAccount.sad_cConsumeID = unconfirmRecord.pcs_cRecordID;
                            sysAccount.sad_cDesc = DefineConstantValue.GetMoneyFlowDesc(unconfirmRecord.pcs_cConsumeType);
                            sysAccount.sad_cFLowMoney = fUnconfirmCost;
                            sysAccount.sad_cFlowType = unconfirmRecord.pcs_cConsumeType;
                            sysAccount.sad_cOpt = sourceInfo.rcr_cLast;
                            sysAccount.sad_dOptTime = DateTime.Now;
                            listToInsertSysDetail.Add(sysAccount);

                            #endregion
                        }
                        fCurrentBalance = fCardBalance;
                    }
                    else
                    {
                        fCurrentBalance = sourceInfo.rcr_fBalance - fAdvance;
                    }

                    db.Connection.Open();
                    db.Transaction = db.Connection.BeginTransaction();
                    try
                    {

                        db.RechargeRecord_rcr.InsertOnSubmit(rechargeRecord);//插入卡实际金额充值记录
                        db.PreConsumeRecord_pcs.InsertAllOnSubmit(listToInsertPreCost);
                        db.CardUserAccountDetail_cuad.InsertAllOnSubmit(listToInsertAccountDetail);
                        db.SystemAccountDetail_sad.InsertAllOnSubmit(listToInsertSysDetail);
                        CardUserAccount_cua accountUpdate = db.CardUserAccount_cua.Where(x => x.cua_cRecordID == account.cua_cRecordID).FirstOrDefault();
                        accountUpdate.cua_fCurrentBalance = fCurrentBalance;
                        accountUpdate.cua_dLastSyncTime = DateTime.Now;

                        db.SubmitChanges();
                        db.Transaction.Commit();
                        rvInfo.boolValue = true;
                        rvInfo.ValueObject = DateTime.Now;
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

        public ReturnValueInfo UpdateRechargeRecord(List<RechargeRecord_rcr_Info> listRechargeRecords, decimal fPreCostRecharge)
        {
            ReturnValueInfo rvInfo = new ReturnValueInfo();
            if (listRechargeRecords == null)
            {
                rvInfo.isError = true;
                rvInfo.messageText = Common.DefineConstantValue.SystemMessageText.strMessageText_E_ObjectNull;
                return rvInfo;
            }
            if (listRechargeRecords != null && listRechargeRecords.Count < 1)
            {
                rvInfo.isError = true;
                rvInfo.messageText = "需要更新的充值记录不能为空。";
                return rvInfo;
            }
            try
            {
                using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                {
                    //用于批量统一插数
                    List<PreConsumeRecord_pcs> listToInsertPreCost = new List<PreConsumeRecord_pcs>();
                    List<CardUserAccountDetail_cuad> listToInsertAccountDetail = new List<CardUserAccountDetail_cuad>();
                    List<SystemAccountDetail_sad> listToInsertSysDetail = new List<SystemAccountDetail_sad>();

                    //获取账户信息
                    CardUserAccount_cua account = db.CardUserAccount_cua.Where(x => x.cua_cCUSID == listRechargeRecords[0].rcr_cUserID).FirstOrDefault();
                    #region 账户信息丢失时，自动创建账户信息

                    if (account == null)
                    {
                        account = new CardUserAccount_cua();
                        account.cua_cRecordID = Guid.NewGuid();
                        account.cua_cCUSID = listRechargeRecords[0].rcr_cUserID;
                        account.cua_cAdd = listRechargeRecords[0].rcr_cLast;
                        account.cua_dAddDate = DateTime.Now;
                        account.cua_dLastSyncTime = DateTime.Now;
                        account.cua_lIsActive = true;
                        account.cua_fCurrentBalance = decimal.Zero;
                        account.cua_fOriginalBalance = decimal.Zero;
                        db.CardUserAccount_cua.InsertOnSubmit(account);
                        db.SubmitChanges();
                    }

                    #endregion

                    //充值总额
                    decimal fSumRecharge = decimal.Zero;

                    //待添加的的用户账户数据
                    List<CardUserAccountDetail_cuad> listUserAccountInfos = new List<CardUserAccountDetail_cuad>();
                    //待添加的系统账户数据
                    List<SystemAccountDetail_sad> listSysAccountInfos = new List<SystemAccountDetail_sad>();
                    //更新已经使用的转账充值记录
                    #region 更新已被充值的转账记录状态为已完成

                    foreach (RechargeRecord_rcr_Info rechargeItem in listRechargeRecords)
                    {
                        RechargeRecord_rcr record = db.RechargeRecord_rcr.Where(x => x.rcr_cRecordID == rechargeItem.rcr_cRecordID).FirstOrDefault();
                        if (record != null)
                        {
                            fSumRecharge += rechargeItem.rcr_fRechargeMoney;

                            record.rcr_cLast = rechargeItem.rcr_cLast;
                            record.rcr_cRechargeType = rechargeItem.rcr_cRechargeType;
                            record.rcr_cStatus = rechargeItem.rcr_cStatus;
                            record.rcr_cUserID = rechargeItem.rcr_cUserID;
                            record.rcr_dLastDate = rechargeItem.rcr_dLastDate;
                            record.rcr_dRechargeTime = rechargeItem.rcr_dRechargeTime;
                            record.rcr_fBalance = rechargeItem.rcr_fBalance;
                            record.rcr_fRechargeMoney = rechargeItem.rcr_fRechargeMoney;

                            //用户账户
                            CardUserAccountDetail_cuad userAccount = new CardUserAccountDetail_cuad();
                            userAccount.cuad_cConsumeID = record.rcr_cRecordID;
                            userAccount.cuad_cCUAID = account.cua_cRecordID;
                            userAccount.cuad_cFlowType = record.rcr_cRechargeType;
                            userAccount.cuad_cOpt = record.rcr_cLast;
                            userAccount.cuad_cRecordID = Guid.NewGuid();
                            userAccount.cuad_dOptTime = DateTime.Now;
                            userAccount.cuad_fFlowMoney = record.rcr_fRechargeMoney;
                            listUserAccountInfos.Add(userAccount);

                            //系统账户
                            SystemAccountDetail_sad sysAccount = new SystemAccountDetail_sad();
                            sysAccount.sad_cConsumeID = record.rcr_cRecordID;
                            sysAccount.sad_cDesc = Common.DefineConstantValue.GetMoneyFlowDesc(record.rcr_cRechargeType);
                            sysAccount.sad_cFLowMoney = record.rcr_fRechargeMoney;
                            sysAccount.sad_cFlowType = record.rcr_cRechargeType;
                            sysAccount.sad_cOpt = record.rcr_cLast;
                            sysAccount.sad_cRecordID = Guid.NewGuid();
                            sysAccount.sad_dOptTime = DateTime.Now;
                            listSysAccountInfos.Add(sysAccount);
                        }
                    }

                    #endregion
                    if (listUserAccountInfos.Count > 0)
                    {
                        //插入由充值记录产生的账户记录
                        listToInsertAccountDetail.AddRange(listUserAccountInfos);
                        listToInsertSysDetail.AddRange(listSysAccountInfos);
                    }

                    //查找用户是否含有预充值记录
                    decimal fAdvance = decimal.Zero;
                    #region 获取用户透支金额

                    List<RechargeRecord_rcr> listAdvance = db.RechargeRecord_rcr.Where(x =>
                        x.rcr_cUserID == listRechargeRecords[0].rcr_cUserID
                        && x.rcr_cRechargeType == Common.DefineConstantValue.ConsumeMoneyFlowType.Recharge_AdvanceMoney.ToString()
                        ).ToList();
                    if (listAdvance != null && listAdvance.Count > 0)
                    {
                        fAdvance = listAdvance.OrderByDescending(x => x.rcr_dRechargeTime).FirstOrDefault().rcr_fRechargeMoney;
                    }

                    #endregion

                    decimal fCurrentBalance = decimal.Zero;
                    //获取本次充值的最后卡余额
                    decimal fCardBalance = listRechargeRecords.Max(x => x.rcr_fBalance);

                    if (Math.Abs(fPreCostRecharge) >= 0 && listRechargeRecords.Count > 0)//若存在需要支付预付款的金额，则进行平数处理
                    {
                        //记录欠款总额
                        decimal fSumPreCost = decimal.Zero;
                        //若预付款还款值大于0，则更新被支付的未结算预付款记录
                        #region 结算预付款项

                        List<PreConsumeRecord_pcs> listPreCost = db.PreConsumeRecord_pcs.Where(x =>
                            x.pcs_lIsSettled == false //需为未支付金额
                            && x.pcs_cAccountID == account.cua_cRecordID //需要账户对口
                            && x.pcs_cUserID == listRechargeRecords[0].rcr_cUserID  //需要对口人员ID
                            ).ToList();

                        //筛选预付款的消费类型
                        listPreCost = filterRecord_CanComputePreCost(listPreCost);

                        fSumPreCost = listPreCost.Sum(x => x.pcs_fCost);
                        if (Math.Abs(fPreCostRecharge) < Math.Abs(fSumPreCost))
                        {
                            db.Transaction.Rollback();
                            db.Connection.Close();
                            rvInfo.messageText = "支付额不足以支付待结算的预付款。";
                            return rvInfo;
                        }

                        List<CardUserAccountDetail_cuad> listPreUserCost = new List<CardUserAccountDetail_cuad>();
                        List<SystemAccountDetail_sad> listPreSysIncome = new List<SystemAccountDetail_sad>();
                        foreach (PreConsumeRecord_pcs preItem in listPreCost)
                        {
                            preItem.pcs_lIsSettled = true;
                            preItem.pcs_dSettleTime = DateTime.Now;

                            //结算的同时插入一条用户账户支出记录
                            CardUserAccountDetail_cuad userAccount = new CardUserAccountDetail_cuad();
                            userAccount.cuad_cRecordID = Guid.NewGuid();
                            userAccount.cuad_cConsumeID = preItem.pcs_cRecordID;
                            userAccount.cuad_cCUAID = account.cua_cRecordID;
                            userAccount.cuad_cFlowType = preItem.pcs_cConsumeType;
                            userAccount.cuad_cOpt = listRechargeRecords[0].rcr_cLast;
                            userAccount.cuad_dOptTime = DateTime.Now;
                            userAccount.cuad_fFlowMoney = preItem.pcs_fCost;
                            listPreUserCost.Add(userAccount);

                            //结算的同时插入一条系统账户收入记录
                            SystemAccountDetail_sad sysAccount = new SystemAccountDetail_sad();
                            sysAccount.sad_cRecordID = Guid.NewGuid();
                            sysAccount.sad_cConsumeID = preItem.pcs_cRecordID;
                            sysAccount.sad_cDesc = Common.DefineConstantValue.GetMoneyFlowDesc(preItem.pcs_cConsumeType);
                            sysAccount.sad_cFLowMoney = preItem.pcs_fCost;
                            sysAccount.sad_cFlowType = preItem.pcs_cConsumeType;
                            sysAccount.sad_cOpt = listRechargeRecords[0].rcr_cLast;
                            sysAccount.sad_dOptTime = DateTime.Now;
                            listPreSysIncome.Add(sysAccount);
                        }

                        if (listPreUserCost.Count > 0)
                        {
                            listToInsertAccountDetail.AddRange(listPreUserCost);
                            listToInsertSysDetail.AddRange(listPreSysIncome);
                        }

                        #endregion

                        //扣减透支额后的卡余额
                        fCardBalance -= fAdvance;
                        //账户余额
                        decimal fAccountUpdate = account.cua_fCurrentBalance + fSumRecharge - fSumPreCost;
                        if (fAccountUpdate > fCardBalance)
                        {
                            #region 平数处理

                            //【系统账户余额】 大于 【卡实际余额】
                            // 新增一条平数的预扣费记录
                            decimal fUnconfirmCost = fAccountUpdate - fCardBalance;
                            PreConsumeRecord_pcs unconfirmRecord = new PreConsumeRecord_pcs();
                            unconfirmRecord.pcs_cAccountID = account.cua_cRecordID;
                            unconfirmRecord.pcs_cAdd = listRechargeRecords[0].rcr_cLast;
                            unconfirmRecord.pcs_cConsumeType = Common.DefineConstantValue.ConsumeMoneyFlowType.HedgeFund.ToString();
                            unconfirmRecord.pcs_cRecordID = Guid.NewGuid();
                            unconfirmRecord.pcs_cUserID = listRechargeRecords[0].rcr_cUserID;
                            unconfirmRecord.pcs_dAddDate = DateTime.Now;
                            unconfirmRecord.pcs_dConsumeDate = DateTime.Now;
                            unconfirmRecord.pcs_fCost = fUnconfirmCost;
                            unconfirmRecord.pcs_lIsSettled = false;
                            listToInsertPreCost.Add(unconfirmRecord);

                            //用户账户
                            CardUserAccountDetail_cuad userAccount = new CardUserAccountDetail_cuad();
                            userAccount.cuad_cConsumeID = unconfirmRecord.pcs_cRecordID;
                            userAccount.cuad_cCUAID = account.cua_cRecordID;
                            userAccount.cuad_cFlowType = unconfirmRecord.pcs_cConsumeType;
                            userAccount.cuad_cOpt = listRechargeRecords[0].rcr_cLast;
                            userAccount.cuad_cRecordID = Guid.NewGuid();
                            userAccount.cuad_dOptTime = DateTime.Now;
                            userAccount.cuad_fFlowMoney = fUnconfirmCost;
                            listToInsertAccountDetail.Add(userAccount);

                            //系统账户
                            SystemAccountDetail_sad sysAccount = new SystemAccountDetail_sad();
                            sysAccount.sad_cConsumeID = unconfirmRecord.pcs_cRecordID;
                            sysAccount.sad_cDesc = Common.DefineConstantValue.GetMoneyFlowDesc(unconfirmRecord.pcs_cConsumeType);
                            sysAccount.sad_cFLowMoney = fUnconfirmCost;
                            sysAccount.sad_cFlowType = unconfirmRecord.pcs_cConsumeType;
                            sysAccount.sad_cOpt = listRechargeRecords[0].rcr_cLast;
                            sysAccount.sad_cRecordID = Guid.NewGuid();
                            sysAccount.sad_dOptTime = DateTime.Now;
                            listToInsertSysDetail.Add(sysAccount);

                            #endregion
                        }
                        fCurrentBalance = fCardBalance;
                    }
                    else
                    {
                        fCurrentBalance = fCardBalance - fAdvance;
                    }

                    db.Connection.Open();
                    db.Transaction = db.Connection.BeginTransaction();

                    try
                    {
                        account.cua_fCurrentBalance = fCurrentBalance;
                        account.cua_dLastSyncTime = DateTime.Now;
                        db.SubmitChanges();

                        db.Transaction.Commit();

                        rvInfo.boolValue = true;
                        return rvInfo;
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

        public ReturnValueInfo UpdateRechargeRecord(List<PreRechargeRecord_prr_Info> listRecord, List<RechargeRecord_rcr_Info> listRecharges, decimal fPreCostRecharge)
        {
            ReturnValueInfo rvInfo = new ReturnValueInfo();
            #region 检查条件合法性

            if (listRecord == null)
            {
                rvInfo.isError = true;
                rvInfo.messageText = Common.DefineConstantValue.SystemMessageText.strMessageText_E_ObjectNull + Environment.NewLine + "预充值记录。";
                return rvInfo;
            }
            if (listRecharges == null)
            {
                rvInfo.isError = true;
                rvInfo.messageText = Common.DefineConstantValue.SystemMessageText.strMessageText_E_ObjectNull + Environment.NewLine + "实际充值记录。";
                return rvInfo;
            }
            if (listRecharges != null && listRecharges.Count < 1)
            {
                rvInfo.isError = true;
                rvInfo.messageText = "需要录入的充值记录不能为空。";
                return rvInfo;
            }
            if (listRecord != null && listRecord.Count < 1)
            {
                rvInfo.isError = true;
                rvInfo.messageText = "需要更新的充值记录不能为空。";
                return rvInfo;
            }

            #endregion

            try
            {
                using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                {
                    //用于批量统一插数
                    List<PreConsumeRecord_pcs> listToInsertPreCost = new List<PreConsumeRecord_pcs>();
                    List<CardUserAccountDetail_cuad> listToInsertAccountDetail = new List<CardUserAccountDetail_cuad>();
                    List<SystemAccountDetail_sad> listToInsertSysDetail = new List<SystemAccountDetail_sad>();
                    List<RechargeRecord_rcr> listToInsertRecharge = new List<RechargeRecord_rcr>();

                    //获取账户信息
                    CardUserAccount_cua account = db.CardUserAccount_cua.Where(x => x.cua_cCUSID == listRecharges[0].rcr_cUserID).FirstOrDefault();
                    #region 账户信息丢失时，自动创建账户信息

                    if (account == null)
                    {
                        account = new CardUserAccount_cua();
                        account.cua_cRecordID = Guid.NewGuid();
                        account.cua_cCUSID = listRecharges[0].rcr_cUserID;
                        account.cua_cAdd = listRecharges[0].rcr_cLast;
                        account.cua_dAddDate = DateTime.Now;
                        account.cua_dLastSyncTime = DateTime.Now;
                        account.cua_lIsActive = true;
                        account.cua_fCurrentBalance = decimal.Zero;
                        account.cua_fOriginalBalance = decimal.Zero;
                        db.CardUserAccount_cua.InsertOnSubmit(account);
                        db.SubmitChanges();
                    }

                    #endregion

                    //充值总额
                    decimal fSumRecharge = decimal.Zero;

                    //待添加的实际充值记录
                    List<RechargeRecord_rcr> listRechargeInserts = new List<RechargeRecord_rcr>();
                    //待添加的的用户账户数据
                    List<CardUserAccountDetail_cuad> listUserAccountInfos = new List<CardUserAccountDetail_cuad>();
                    //待添加的系统账户数据
                    List<SystemAccountDetail_sad> listSysAccountInfos = new List<SystemAccountDetail_sad>();
                    //更新已经使用的转账充值记录
                    #region 更新已被使用的预充值记录状态为已完成，并插入实际充值记录并记录账户收入记录

                    foreach (PreRechargeRecord_prr_Info preRechargeItem in listRecord)
                    {
                        if (preRechargeItem == null)
                        {
                            continue;
                        }

                        PreRechargeRecord_prr preRecord = db.PreRechargeRecord_prr.Where(x => x.prr_cRecordID == preRechargeItem.prr_cRecordID).FirstOrDefault();
                        if (preRecord != null)
                        {
                            //添加实际消费记录
                            RechargeRecord_rcr_Info rechargeInfo = listRecharges.Find(x => x.rcr_cRecordID == preRechargeItem.prr_cRCRID);
                            if (rechargeInfo != null)
                            {
                                RechargeRecord_rcr recharge = Common.General.CopyObjectValue<RechargeRecord_rcr_Info, RechargeRecord_rcr>(rechargeInfo);
                                if (recharge != null)
                                {
                                    rechargeInfo.rcr_dRechargeTime = DateTime.Now;
                                    rechargeInfo.rcr_dLastDate = DateTime.Now;
                                    listRechargeInserts.Add(recharge);
                                }
                            }

                            preRecord.prr_cRCRID = rechargeInfo.rcr_cRecordID;
                            preRecord.prr_cStatus = Common.DefineConstantValue.ConsumeMoneyFlowStatus.Finished.ToString();
                            preRecord.prr_cLast = preRechargeItem.prr_cLast;
                            preRecord.prr_dLastDate = preRechargeItem.prr_dLastDate;

                            //累积充值记录
                            fSumRecharge += preRechargeItem.prr_fRechargeMoney;

                            //用户账户
                            CardUserAccountDetail_cuad userAccountDetail = new CardUserAccountDetail_cuad();
                            userAccountDetail.cuad_cRecordID = Guid.NewGuid();
                            userAccountDetail.cuad_cConsumeID = rechargeInfo.rcr_cRecordID;
                            userAccountDetail.cuad_cCUAID = account.cua_cRecordID;
                            userAccountDetail.cuad_cFlowType = rechargeInfo.rcr_cRechargeType;
                            userAccountDetail.cuad_cOpt = rechargeInfo.rcr_cLast;
                            userAccountDetail.cuad_dOptTime = DateTime.Now;
                            userAccountDetail.cuad_fFlowMoney = preRechargeItem.prr_fRechargeMoney;//金额与预充值额全额一致
                            listUserAccountInfos.Add(userAccountDetail);

                            //系统账户
                            SystemAccountDetail_sad sysAccount = new SystemAccountDetail_sad();
                            sysAccount.sad_cRecordID = Guid.NewGuid();
                            sysAccount.sad_cConsumeID = rechargeInfo.rcr_cRecordID;
                            sysAccount.sad_cDesc = Common.DefineConstantValue.GetMoneyFlowDesc(rechargeInfo.rcr_cRechargeType);
                            sysAccount.sad_cFLowMoney = preRechargeItem.prr_fRechargeMoney;//金额与预充值额全额一致
                            sysAccount.sad_cFlowType = rechargeInfo.rcr_cRechargeType;
                            sysAccount.sad_cOpt = rechargeInfo.rcr_cLast;
                            sysAccount.sad_dOptTime = DateTime.Now;
                            listSysAccountInfos.Add(sysAccount);
                        }
                    }

                    #endregion
                    if (listUserAccountInfos.Count > 0)
                    {
                        //插入由充值记录产生的账户记录
                        listToInsertRecharge.AddRange(listRechargeInserts);
                        listToInsertAccountDetail.AddRange(listUserAccountInfos);
                        listToInsertSysDetail.AddRange(listSysAccountInfos);
                    }

                    //查找用户是否含有透支预存款记录
                    decimal fAdvance = decimal.Zero;
                    #region 获取用户的透支金额

                    List<RechargeRecord_rcr> listAdvance = db.RechargeRecord_rcr.Where(x =>
                        x.rcr_cUserID == listRechargeInserts[0].rcr_cUserID
                        && x.rcr_cRechargeType == Common.DefineConstantValue.ConsumeMoneyFlowType.Recharge_AdvanceMoney.ToString()
                        ).ToList();
                    if (listAdvance != null && listAdvance.Count > 0)
                    {
                        fAdvance = listAdvance.OrderByDescending(x => x.rcr_dRechargeTime).FirstOrDefault().rcr_fRechargeMoney;
                    }

                    #endregion

                    decimal fCurrentBalance = decimal.Zero;
                    fPreCostRecharge = Math.Abs(fPreCostRecharge);
                    decimal fSumPreCost = decimal.Zero;//记录欠款总额
                    //获取本次充值的最后余额
                    //decimal fCardBalance = listRechargeInserts.Max(x => x.rcr_fBalance);
                    decimal fCardBalance = listRechargeInserts.OrderByDescending(x => x.rcr_dRechargeTime).FirstOrDefault().rcr_fBalance;
                    if (fPreCostRecharge >= 0 && listRechargeInserts.Count > 0)//若存在需要支付预付款的金额，则进行平数处理
                    {
                        //若预付款还款值大于0，则更新被支付的未结算预付款记录
                        #region 结算预付款项

                        List<PreConsumeRecord_pcs> listPreCost = db.PreConsumeRecord_pcs.Where(x =>
                            x.pcs_lIsSettled == false //需为未支付金额
                            && x.pcs_cAccountID == account.cua_cRecordID//需要账户对口
                            && x.pcs_cUserID == listRechargeInserts[0].rcr_cUserID  //需要对口人员ID
                            ).ToList();

                        //筛选预付款的消费类型
                        listPreCost = filterRecord_CanComputePreCost(listPreCost);

                        fSumPreCost = listPreCost.Sum(x => x.pcs_fCost);
                        if (Math.Abs(fPreCostRecharge) < Math.Abs(fSumPreCost))
                        {
                            rvInfo.messageText = "支付额不足以支付待结算的预付款。";
                            return rvInfo;
                        }

                        List<CardUserAccountDetail_cuad> listPreUserCost = new List<CardUserAccountDetail_cuad>();
                        List<SystemAccountDetail_sad> listPreSysIncome = new List<SystemAccountDetail_sad>();
                        foreach (PreConsumeRecord_pcs preItem in listPreCost)
                        {
                            preItem.pcs_lIsSettled = true;
                            preItem.pcs_dSettleTime = DateTime.Now;

                            //结算的同时插入一条用户账户支出记录
                            CardUserAccountDetail_cuad userAccountDetail = new CardUserAccountDetail_cuad();
                            userAccountDetail.cuad_cConsumeID = preItem.pcs_cRecordID;
                            userAccountDetail.cuad_cCUAID = account.cua_cRecordID;
                            userAccountDetail.cuad_cFlowType = preItem.pcs_cConsumeType;
                            userAccountDetail.cuad_cOpt = listRechargeInserts[0].rcr_cLast;
                            userAccountDetail.cuad_cRecordID = Guid.NewGuid();
                            userAccountDetail.cuad_dOptTime = DateTime.Now;
                            userAccountDetail.cuad_fFlowMoney = preItem.pcs_fCost;
                            listPreUserCost.Add(userAccountDetail);

                            //结算的同时插入一条系统账户收入记录
                            SystemAccountDetail_sad sysAccount = new SystemAccountDetail_sad();
                            sysAccount.sad_cConsumeID = preItem.pcs_cRecordID;
                            sysAccount.sad_cDesc = Common.DefineConstantValue.GetMoneyFlowDesc(preItem.pcs_cConsumeType);
                            sysAccount.sad_cFLowMoney = preItem.pcs_fCost;
                            sysAccount.sad_cFlowType = preItem.pcs_cConsumeType;
                            sysAccount.sad_cOpt = listRechargeInserts[0].rcr_cLast;
                            sysAccount.sad_cRecordID = Guid.NewGuid();
                            sysAccount.sad_dOptTime = DateTime.Now;
                            listPreSysIncome.Add(sysAccount);
                        }

                        if (listPreUserCost.Count > 0)
                        {
                            listToInsertAccountDetail.AddRange(listPreUserCost);
                            listToInsertSysDetail.AddRange(listPreSysIncome);
                        }

                        #endregion

                        //扣减预支款
                        fCardBalance -= fAdvance;
                        //账户余额
                        decimal fAccountUpdate = account.cua_fCurrentBalance + fSumRecharge - fSumPreCost;
                        if (fAccountUpdate > fCardBalance)
                        {
                            #region 平数处理

                            //【系统账户余额】 大于 【卡实际余额】
                            // 新增一条平数的预扣费记录
                            decimal fUnconfirmCost = fAccountUpdate - fCardBalance;

                            PreConsumeRecord_pcs unconfirmRecord = new PreConsumeRecord_pcs();
                            unconfirmRecord.pcs_cRecordID = Guid.NewGuid();
                            unconfirmRecord.pcs_cAccountID = account.cua_cRecordID;
                            unconfirmRecord.pcs_cAdd = listRechargeInserts[0].rcr_cLast;
                            unconfirmRecord.pcs_cConsumeType = DefineConstantValue.ConsumeMoneyFlowType.HedgeFund.ToString();
                            unconfirmRecord.pcs_cUserID = listRechargeInserts[0].rcr_cUserID;
                            unconfirmRecord.pcs_dAddDate = DateTime.Now;
                            unconfirmRecord.pcs_dConsumeDate = DateTime.Now;
                            unconfirmRecord.pcs_fCost = fUnconfirmCost;
                            unconfirmRecord.pcs_lIsSettled = false;
                            listToInsertPreCost.Add(unconfirmRecord);

                            //用户账户
                            CardUserAccountDetail_cuad userAccountDetail = new CardUserAccountDetail_cuad();
                            userAccountDetail.cuad_cRecordID = Guid.NewGuid();
                            userAccountDetail.cuad_cConsumeID = unconfirmRecord.pcs_cRecordID;
                            userAccountDetail.cuad_cCUAID = account.cua_cRecordID;
                            userAccountDetail.cuad_cFlowType = unconfirmRecord.pcs_cConsumeType;
                            userAccountDetail.cuad_cOpt = listRechargeInserts[0].rcr_cLast;
                            userAccountDetail.cuad_dOptTime = DateTime.Now;
                            userAccountDetail.cuad_fFlowMoney = fUnconfirmCost;
                            listToInsertAccountDetail.Add(userAccountDetail);

                            //系统账户
                            SystemAccountDetail_sad sysAccount = new SystemAccountDetail_sad();
                            sysAccount.sad_cRecordID = Guid.NewGuid();
                            sysAccount.sad_cConsumeID = unconfirmRecord.pcs_cRecordID;
                            sysAccount.sad_cDesc = DefineConstantValue.GetMoneyFlowDesc(unconfirmRecord.pcs_cConsumeType);
                            sysAccount.sad_cFLowMoney = fUnconfirmCost;
                            sysAccount.sad_cFlowType = unconfirmRecord.pcs_cConsumeType;
                            sysAccount.sad_cOpt = listRechargeInserts[0].rcr_cLast;
                            sysAccount.sad_dOptTime = DateTime.Now;
                            listToInsertSysDetail.Add(sysAccount);

                            #endregion
                        }
                        fCurrentBalance = fCardBalance;
                    }
                    else
                    {
                        fCurrentBalance = fCardBalance - fAdvance;
                    }
                    try
                    {
                        db.Connection.Open();
                        db.Transaction = db.Connection.BeginTransaction();

                        if (listToInsertRecharge != null && listToInsertRecharge.Count > 0)
                            db.RechargeRecord_rcr.InsertAllOnSubmit(listToInsertRecharge);
                        if (listToInsertPreCost != null && listToInsertPreCost.Count > 0)
                            db.PreConsumeRecord_pcs.InsertAllOnSubmit(listToInsertPreCost);
                        if (listToInsertAccountDetail != null && listToInsertAccountDetail.Count > 0)
                            db.CardUserAccountDetail_cuad.InsertAllOnSubmit(listToInsertAccountDetail);
                        if (listToInsertSysDetail != null && listToInsertSysDetail.Count > 0)
                            db.SystemAccountDetail_sad.InsertAllOnSubmit(listToInsertSysDetail);

                        account.cua_dLastSyncTime = DateTime.Now;
                        account.cua_fCurrentBalance = fCurrentBalance;

                        db.SubmitChanges();
                        db.Transaction.Commit();
                        rvInfo.boolValue = true;
                        rvInfo.ValueObject = DateTime.Now;
                        return rvInfo;
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

        public ReturnValueInfo DeleteRechargeRecord(IModelObject itemEntity)
        {
            throw new NotImplementedException();
        }

        public ReturnValueInfo CashRefund(RechargeRecord_rcr_Info refundRecord, decimal fPreCostRecharge)
        {
            ReturnValueInfo rvInfo = new ReturnValueInfo();
            try
            {
                #region  数据检验

                if (refundRecord == null)
                {
                    rvInfo.messageText = Common.DefineConstantValue.SystemMessageText.strMessageText_E_ObjectNull;
                    rvInfo.isError = true;
                    return rvInfo;
                }
                RechargeRecord_rcr refundInfo = Common.General.CopyObjectValue<RechargeRecord_rcr_Info, RechargeRecord_rcr>(refundRecord);
                if (refundInfo == null)
                {
                    rvInfo.messageText = Common.DefineConstantValue.SystemMessageText.strMessageText_E_ObjectNull;
                    rvInfo.isError = true;
                    return rvInfo;
                }

                #endregion

                using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                {
                    //用于批量统一插数
                    List<PreConsumeRecord_pcs> listToInsertPreCost = new List<PreConsumeRecord_pcs>();
                    List<CardUserAccountDetail_cuad> listToInsertAccountDetail = new List<CardUserAccountDetail_cuad>();
                    List<SystemAccountDetail_sad> listToInsertSysDetail = new List<SystemAccountDetail_sad>();
                    List<RechargeRecord_rcr> listToInsertRecharge = new List<RechargeRecord_rcr>();

                    //获取账户信息
                    CardUserAccount_cua account = db.CardUserAccount_cua.Where(x => x.cua_cCUSID == refundRecord.rcr_cUserID).FirstOrDefault();
                    #region 账户信息丢失时，自动创建账户信息

                    if (account == null)
                    {
                        account = new CardUserAccount_cua();
                        account.cua_cRecordID = Guid.NewGuid();
                        account.cua_cCUSID = refundRecord.rcr_cUserID;
                        account.cua_cAdd = refundRecord.rcr_cLast;
                        account.cua_dAddDate = DateTime.Now;
                        account.cua_dLastSyncTime = DateTime.Now;
                        account.cua_lIsActive = true;
                        account.cua_fCurrentBalance = decimal.Zero;
                        account.cua_fOriginalBalance = decimal.Zero;
                        db.CardUserAccount_cua.InsertOnSubmit(account);
                        db.SubmitChanges();
                    }

                    #endregion

                    if (account != null)
                    {
                        if (Math.Abs(fPreCostRecharge) > 0)
                        {
                            #region 检查未付款记录，并更新状态

                            List<PreConsumeRecord_pcs> listPreCosts = db.PreConsumeRecord_pcs.Where(x =>
                               x.pcs_cAccountID == account.cua_cRecordID
                               && x.pcs_cUserID == refundInfo.rcr_cUserID
                               && x.pcs_lIsSettled == false
                            ).ToList();

                            //筛选预付款的消费类型
                            listPreCosts = filterRecord_CanComputePreCost(listPreCosts);

                            if (listPreCosts != null && listPreCosts.Count > 0)
                            {
                                decimal fSumPreCost = listPreCosts.Sum(x => x.pcs_fCost);
                                fSumPreCost = Math.Abs(fSumPreCost);

                                if (fSumPreCost != Math.Abs(fPreCostRecharge))
                                {
                                    rvInfo.messageText = "未结算款项记录异常。";
                                    db.Transaction.Rollback();
                                    rvInfo.isError = true;
                                    return rvInfo;
                                }
                                else
                                {
                                    List<CardUserAccountDetail_cuad> listAccountPreCost = new List<CardUserAccountDetail_cuad>();
                                    List<SystemAccountDetail_sad> listSysAccountPreCost = new List<SystemAccountDetail_sad>();
                                    foreach (PreConsumeRecord_pcs preCostItem in listPreCosts)
                                    {
                                        preCostItem.pcs_lIsSettled = true;
                                        preCostItem.pcs_dSettleTime = DateTime.Now;

                                        #region 插入欠费缴费记录

                                        //插入用户账户记录
                                        CardUserAccountDetail_cuad accountDetailPreCost = new CardUserAccountDetail_cuad();
                                        accountDetailPreCost.cuad_cRecordID = Guid.NewGuid();
                                        accountDetailPreCost.cuad_cConsumeID = refundInfo.rcr_cRecordID;
                                        accountDetailPreCost.cuad_cCUAID = account.cua_cRecordID;
                                        accountDetailPreCost.cuad_cFlowType = preCostItem.pcs_cConsumeType;
                                        accountDetailPreCost.cuad_cOpt = refundInfo.rcr_cLast;
                                        accountDetailPreCost.cuad_dOptTime = DateTime.Now;
                                        accountDetailPreCost.cuad_fFlowMoney = preCostItem.pcs_fCost;
                                        listAccountPreCost.Add(accountDetailPreCost);

                                        //插入系统账户记录
                                        SystemAccountDetail_sad sysAccountDetailPreCost = new SystemAccountDetail_sad();
                                        sysAccountDetailPreCost.sad_cRecordID = Guid.NewGuid();
                                        sysAccountDetailPreCost.sad_cConsumeID = refundInfo.rcr_cRecordID;
                                        sysAccountDetailPreCost.sad_cDesc = DefineConstantValue.GetMoneyFlowDesc(preCostItem.pcs_cConsumeType);
                                        sysAccountDetailPreCost.sad_cFLowMoney = preCostItem.pcs_fCost;
                                        sysAccountDetailPreCost.sad_cFlowType = preCostItem.pcs_cConsumeType;
                                        sysAccountDetailPreCost.sad_cOpt = refundInfo.rcr_cLast;
                                        sysAccountDetailPreCost.sad_dOptTime = DateTime.Now;
                                        listSysAccountPreCost.Add(sysAccountDetailPreCost);

                                        #endregion
                                    }

                                    if (listAccountPreCost.Count > 0)
                                    {
                                        listToInsertAccountDetail.AddRange(listAccountPreCost);
                                        listToInsertSysDetail.AddRange(listSysAccountPreCost);
                                    }
                                }
                            }
                            else
                            {
                                if (listPreCosts == null)
                                {
                                    rvInfo.messageText = "未结算款项记录异常。";
                                    rvInfo.isError = true;
                                    return rvInfo;
                                }
                            }

                            #endregion
                        }

                        #region 插入退款记录

                        //插入用户账户退款记录
                        CardUserAccountDetail_cuad accountDetail = new CardUserAccountDetail_cuad();
                        accountDetail.cuad_cRecordID = Guid.NewGuid();
                        accountDetail.cuad_cConsumeID = refundInfo.rcr_cRecordID;
                        accountDetail.cuad_cCUAID = account.cua_cRecordID;
                        accountDetail.cuad_cFlowType = refundInfo.rcr_cRechargeType;
                        accountDetail.cuad_cOpt = refundInfo.rcr_cLast;
                        accountDetail.cuad_dOptTime = DateTime.Now;
                        accountDetail.cuad_fFlowMoney = refundInfo.rcr_fRechargeMoney;
                        listToInsertAccountDetail.Add(accountDetail);

                        //插入系统账户退款记录
                        SystemAccountDetail_sad sysAccountDetail = new SystemAccountDetail_sad();
                        sysAccountDetail.sad_cRecordID = Guid.NewGuid();
                        sysAccountDetail.sad_cConsumeID = refundInfo.rcr_cRecordID;
                        sysAccountDetail.sad_cDesc = refundInfo.rcr_cDesc;
                        sysAccountDetail.sad_cFLowMoney = refundInfo.rcr_fRechargeMoney;
                        sysAccountDetail.sad_cFlowType = refundInfo.rcr_cRechargeType;
                        sysAccountDetail.sad_cOpt = refundInfo.rcr_cLast;
                        sysAccountDetail.sad_dOptTime = DateTime.Now;
                        listToInsertSysDetail.Add(sysAccountDetail);

                        #endregion

                        decimal fAdvanceCost = decimal.Zero;
                        #region 获取透支金额

                        List<RechargeRecord_rcr> listAdvanceCost = db.RechargeRecord_rcr.Where(x =>
                             x.rcr_cUserID == refundInfo.rcr_cUserID
                            && x.rcr_cRechargeType == Common.DefineConstantValue.ConsumeMoneyFlowType.Recharge_AdvanceMoney.ToString()).ToList();
                        if (listAdvanceCost != null && listAdvanceCost.Count > 0)
                        {
                            RechargeRecord_rcr advanceCost = listAdvanceCost.OrderByDescending(x => x.rcr_dRechargeTime).FirstOrDefault();
                            if (advanceCost != null)
                            {
                                fAdvanceCost = advanceCost.rcr_fRechargeMoney;
                            }
                        }

                        #endregion

                        decimal fAccountCurrentBalance = account.cua_fCurrentBalance - fPreCostRecharge - refundInfo.rcr_fRechargeMoney;//退款后的最新账户余额
                        decimal fCardCurrentBalance = refundInfo.rcr_fBalance - fAdvanceCost;//退款后的卡余额
                        if (fAccountCurrentBalance > fCardCurrentBalance)
                        {
                            //账户余额比卡余额大，则需要插入补充金额
                            #region 插入补充消费记录

                            decimal fInsert = fAccountCurrentBalance - fCardCurrentBalance;

                            //【系统账户余额】 大于 【卡实际余额】
                            // 新增一条平数的预扣费记录
                            PreConsumeRecord_pcs unconfirmRecord = new PreConsumeRecord_pcs();
                            unconfirmRecord.pcs_cAccountID = account.cua_cRecordID;
                            unconfirmRecord.pcs_cRecordID = Guid.NewGuid();
                            unconfirmRecord.pcs_cConsumeType = DefineConstantValue.ConsumeMoneyFlowType.HedgeFund.ToString();
                            unconfirmRecord.pcs_cUserID = refundInfo.rcr_cUserID;
                            unconfirmRecord.pcs_cAdd = refundInfo.rcr_cLast;
                            unconfirmRecord.pcs_dAddDate = DateTime.Now;
                            unconfirmRecord.pcs_dConsumeDate = DateTime.Now;
                            unconfirmRecord.pcs_fCost = fInsert;
                            unconfirmRecord.pcs_lIsSettled = false;
                            listToInsertPreCost.Add(unconfirmRecord);

                            //用户账户
                            CardUserAccountDetail_cuad userAccount = new CardUserAccountDetail_cuad();
                            userAccount.cuad_cConsumeID = unconfirmRecord.pcs_cRecordID;
                            userAccount.cuad_cCUAID = account.cua_cRecordID;
                            userAccount.cuad_cFlowType = unconfirmRecord.pcs_cConsumeType;
                            userAccount.cuad_cOpt = refundInfo.rcr_cLast;
                            userAccount.cuad_cRecordID = Guid.NewGuid();
                            userAccount.cuad_dOptTime = DateTime.Now;
                            userAccount.cuad_fFlowMoney = fInsert;
                            listToInsertAccountDetail.Add(userAccount);

                            //系统账户
                            SystemAccountDetail_sad sysAccount = new SystemAccountDetail_sad();
                            sysAccount.sad_cRecordID = Guid.NewGuid();
                            sysAccount.sad_cConsumeID = unconfirmRecord.pcs_cRecordID;
                            sysAccount.sad_cDesc = DefineConstantValue.GetMoneyFlowDesc(unconfirmRecord.pcs_cConsumeType);
                            sysAccount.sad_cFLowMoney = fInsert;
                            sysAccount.sad_cFlowType = unconfirmRecord.pcs_cConsumeType;
                            sysAccount.sad_cOpt = refundInfo.rcr_cLast;
                            sysAccount.sad_dOptTime = DateTime.Now;
                            listToInsertSysDetail.Add(sysAccount);

                            #endregion
                        }

                        try
                        {
                            db.Connection.Open();
                            db.Transaction = db.Connection.BeginTransaction();

                            refundInfo.rcr_dRechargeTime = DateTime.Now;
                            refundInfo.rcr_dLastDate = DateTime.Now;
                            db.RechargeRecord_rcr.InsertOnSubmit(refundInfo);

                            account.cua_fCurrentBalance = fCardCurrentBalance;
                            account.cua_dLastSyncTime = DateTime.Now;

                            if (listToInsertPreCost != null && listToInsertPreCost.Count > 0)
                                db.PreConsumeRecord_pcs.InsertAllOnSubmit(listToInsertPreCost);
                            if (listToInsertAccountDetail != null && listToInsertAccountDetail.Count > 0)
                                db.CardUserAccountDetail_cuad.InsertAllOnSubmit(listToInsertAccountDetail);
                            if (listToInsertSysDetail != null && listToInsertSysDetail.Count > 0)
                                db.SystemAccountDetail_sad.InsertAllOnSubmit(listToInsertSysDetail);
                            if (listToInsertRecharge != null && listToInsertRecharge.Count > 0)
                                db.RechargeRecord_rcr.InsertAllOnSubmit(listToInsertRecharge);

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
                rvInfo.isError = true;
                rvInfo.messageText = ex.Message;
            }
            return rvInfo;
        }

        #endregion

        /// <summary>
        /// 是否为需要记录到用户账户的数据
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        bool IsUserAccountRecord(RechargeRecord_rcr_Info record)
        {
            if (record != null)
            {
                //排除转账充值及透支额充值，不需要或暂不需要写入账户明细表
                if (record.rcr_cRechargeType == DefineConstantValue.ConsumeMoneyFlowType.Recharge_AdvanceMoney.ToString()
                    || record.rcr_cRechargeType == DefineConstantValue.ConsumeMoneyFlowType.Recharge_BatchTransfer.ToString()
                    || record.rcr_cRechargeType == DefineConstantValue.ConsumeMoneyFlowType.Recharge_PersonalTransfer.ToString()
                    || record.rcr_cRechargeType == DefineConstantValue.ConsumeMoneyFlowType.Refund_BatchTransfer.ToString()
                    || record.rcr_cRechargeType == DefineConstantValue.ConsumeMoneyFlowType.Refund_PersonalTransfer.ToString())
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 是否为需要记录到系统账户的数据
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        bool IsSysAccountRecord(RechargeRecord_rcr_Info record)
        {
            if (record != null)
            {
                if (record.rcr_cRechargeType == DefineConstantValue.ConsumeMoneyFlowType.Recharge_AdvanceMoney.ToString())
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 记录筛选--可用于计算欠款的预付款记录
        /// </summary>
        /// <param name="listFilter"></param>
        List<PreConsumeRecord_pcs> filterRecord_CanComputePreCost(List<PreConsumeRecord_pcs> listFilterPreCost)
        {
            //需要不为未确定结算款、待扣费款及对冲款
            List<PreConsumeRecord_pcs> listFilterPreCostRv = listFilterPreCost.Where(x =>
                x.pcs_cConsumeType != Common.DefineConstantValue.ConsumeMoneyFlowType.IndeterminateCost.ToString()
                && x.pcs_cConsumeType != Common.DefineConstantValue.ConsumeMoneyFlowType.AdvanceMealCost.ToString()
                && x.pcs_cConsumeType != Common.DefineConstantValue.ConsumeMoneyFlowType.HedgeFund.ToString()
                ).ToList();
            return listFilterPreCostRv;
        }
    }
}
