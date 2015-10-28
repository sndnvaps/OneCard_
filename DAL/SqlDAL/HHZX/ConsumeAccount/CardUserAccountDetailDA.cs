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
    /// 账户资金流动详细信息
    /// </summary>
    public class CardUserAccountDetailDA : ICardUserAccountDetailDA
    {
        #region IMainGeneralDA<CardUserAccountDetail_cuad_Info> Members

        public ReturnValueInfo InsertRecord(CardUserAccountDetail_cuad_Info infoObject)
        {
            ReturnValueInfo rvInfo = new ReturnValueInfo();
            try
            {
                if (infoObject != null)
                {
                    using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                    {
                        CardUserAccountDetail_cuad record = Common.General.CopyObjectValue<CardUserAccountDetail_cuad_Info, CardUserAccountDetail_cuad>(infoObject);
                        if (record != null)
                        {
                            db.CardUserAccountDetail_cuad.InsertOnSubmit(record);
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

        public ReturnValueInfo UpdateRecord(CardUserAccountDetail_cuad_Info infoObject)
        {
            ReturnValueInfo rvInfo = new ReturnValueInfo();
            try
            {
                if (infoObject != null)
                {
                    using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                    {
                        CardUserAccountDetail_cuad record = db.CardUserAccountDetail_cuad.Where(x => x.cuad_cRecordID == infoObject.cuad_cRecordID).FirstOrDefault();

                        if (record != null)
                        {
                            record.cuad_cCUAID = infoObject.cuad_cCUAID;
                            record.cuad_fFlowMoney = infoObject.cuad_fFlowMoney;
                            record.cuad_cFlowType = infoObject.cuad_cFlowType;
                            if (infoObject.cuad_cConsumeID != null)
                            {
                                record.cuad_cConsumeID = infoObject.cuad_cConsumeID.Value;
                            }
                            record.cuad_cOpt = infoObject.cuad_cOpt;
                            record.cuad_dOptTime = infoObject.cuad_dOptTime;

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
                CardUserAccountDetail_cuad_Info infoObject = KeyObject as CardUserAccountDetail_cuad_Info;
                if (infoObject != null)
                {
                    using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                    {
                        CardUserAccountDetail_cuad record = db.CardUserAccountDetail_cuad.Where(x => x.cuad_cRecordID == infoObject.cuad_cRecordID).FirstOrDefault();

                        if (record != null)
                        {
                            db.CardUserAccountDetail_cuad.DeleteOnSubmit(record);

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

        public CardUserAccountDetail_cuad_Info DisplayRecord(IModelObject KeyObject)
        {
            CardUserAccountDetail_cuad_Info resInfo = null;
            try
            {
                CardUserAccountDetail_cuad_Info infoObject = KeyObject as CardUserAccountDetail_cuad_Info;
                if (infoObject != null)
                {
                    using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                    {
                        CardUserAccountDetail_cuad record = db.CardUserAccountDetail_cuad.Where(x => x.cuad_cRecordID == infoObject.cuad_cRecordID).FirstOrDefault();

                        if (record != null)
                        {
                            resInfo = Common.General.CopyObjectValue<CardUserAccountDetail_cuad, CardUserAccountDetail_cuad_Info>(record);
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

        public List<CardUserAccountDetail_cuad_Info> SearchRecords(IModelObject searchCondition)
        {
            List<CardUserAccountDetail_cuad_Info> listRecordInfo = null;
            try
            {
                StringBuilder sbSQL = new StringBuilder();
                sbSQL.AppendLine("SELECT TOP");
                sbSQL.AppendLine(Common.DefineConstantValue.ListRecordMaxCount.ToString());
                sbSQL.AppendLine(@"[cuad_cRecordID]
      ,[cuad_cCUAID]
      ,[cuad_fFlowMoney]
      ,[cuad_cFlowType]
      ,[cuad_cConsumeID]
      ,[cuad_cOpt]
      ,[cuad_dOptTime]
      ,csr_dConsumeDate
      ,csr_cMachineID
      ,csr_cCardID
      ,cmm_iMacNo as MacNo");
                sbSQL.AppendLine("FROM CardUserAccountDetail_cuad ");
                sbSQL.AppendLine("LEFT JOIN ConsumeRecord_csr ON  cuad_cConsumeID = csr_cRecordID");
                sbSQL.AppendLine("LEFT JOIN ConsumeMachineMaster_cmm ON csr_cMachineID = cmm_cRecordID");
                sbSQL.AppendLine("WHERE 1 = 1");

                CardUserAccountDetail_cuad_Info searchInfo = searchCondition as CardUserAccountDetail_cuad_Info;
                if (searchInfo != null)
                {
                    if (searchInfo.cuad_cCUAID != Guid.Empty)
                        sbSQL.AppendLine("AND cuad_cCUAID ='" + searchInfo.cuad_cCUAID + "'");
                    if (searchInfo.cuad_fFlowMoney != 0)
                        sbSQL.AppendLine("AND cuad_cFlowMoney =" + searchInfo.cuad_fFlowMoney.ToString());
                    if (!string.IsNullOrEmpty(searchInfo.cuad_cFlowType))
                        sbSQL.AppendLine("AND cuad_cFlowType ='" + searchInfo.cuad_cFlowType + "'");
                    if (searchInfo.cuad_dOptTime != DateTime.MinValue)
                        sbSQL.AppendLine("AND cuad_dOptTime ='" + searchInfo.cuad_dOptTime.ToString("yyyy-MM-dd HH:mm") + "'");
                    if (searchInfo.cuad_cConsumeID != null)
                        sbSQL.AppendLine("AND cuad_cConsumeID ='" + searchInfo.cuad_cConsumeID + "'");

                    if (searchInfo.OptTime_From != null && searchInfo.OptTime_To != null)
                    {
                        sbSQL.AppendLine("AND cuad_dOptTime between '" + ((DateTime)(searchInfo.OptTime_From)).ToString("yyyy-MM-dd HH:mm") + "' and  '" + ((DateTime)(searchInfo.OptTime_To)).ToString("yyyy-MM-dd HH:mm") + "'");
                    }

                }

                using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                {
                    IEnumerable<CardUserAccountDetail_cuad_Info> query = db.ExecuteQuery<CardUserAccountDetail_cuad_Info>(sbSQL.ToString(), new object[] { });
                    if (query != null)
                    {
                        listRecordInfo = query.ToList<CardUserAccountDetail_cuad_Info>();
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return listRecordInfo;
        }

        public List<CardUserAccountDetail_cuad_Info> AllRecords()
        {
            List<CardUserAccountDetail_cuad_Info> listRecord = null;
            try
            {
                StringBuilder sbSQL = new StringBuilder();
                sbSQL.AppendLine("SELECT ");
                sbSQL.AppendLine("* FROM CardUserAccountDetail_cuad WHERE 1 = 1");

                using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                {
                    IEnumerable<CardUserAccountDetail_cuad_Info> query = db.ExecuteQuery<CardUserAccountDetail_cuad_Info>(sbSQL.ToString(), new object[] { });
                    if (query != null)
                    {
                        listRecord = query.ToList<CardUserAccountDetail_cuad_Info>();
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

        public List<CardUserAccountDetail_cuad_Info> SearchRecords(IModelObject itemEntity, DateTime dtBegin, DateTime dtEnd)
        {
            List<CardUserAccountDetail_cuad_Info> listRecordInfo = null;
            try
            {
                StringBuilder sbSQL = new StringBuilder();
                sbSQL.AppendLine(@"select *
,(case [cuad_cFlowType]
      when 'Recharge_AdvanceMoney' then [cuad_fFlowMoney]
      when 'Recharge_PersonalRealTime' then [cuad_fFlowMoney]
      when 'Recharge_PersonalTransfer' then [cuad_fFlowMoney]
      when 'Recharge_BatchTransfer' then [cuad_fFlowMoney]
      when 'Refund_PersonalCash' then [cuad_fFlowMoney] * -1
      when 'Refund_CardPersonalRealTime' then [cuad_fFlowMoney] * -1
      when 'Refund_PersonalTransfer' then [cuad_fFlowMoney] * -1
      when 'Refund_BatchTransfer' then [cuad_fFlowMoney] * -1
      else ''  end) as FlowMoney
      ,(case [cuad_cFlowType]
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
 from
(
select [cuad_cRecordID],[cuad_cFlowType],[cuad_dOptTime],[cuad_fFlowMoney],cua_cCUSID,
    [cus_cChaName] as [UserName],isnull([csm_cClassName],dpm_cName) as GroupName
from(
select [cuad_cRecordID],[cuad_cCUAID],[cuad_cFlowType],[cuad_dOptTime],[cuad_fFlowMoney]
from CardUserAccountDetail_cuad
where  1= 1");

                CardUserAccountDetail_cuad_Info searchInfo = itemEntity as CardUserAccountDetail_cuad_Info;
                if (searchInfo != null)
                {
                    if (searchInfo.cuad_cCUAID != Guid.Empty)
                        sbSQL.AppendLine("AND cuad_cCUAID ='" + searchInfo.cuad_cCUAID + "'");
                    if (searchInfo.cuad_fFlowMoney != 0)
                        sbSQL.AppendLine("AND cuad_cFlowMoney =" + searchInfo.cuad_fFlowMoney.ToString());
                    if (!string.IsNullOrEmpty(searchInfo.cuad_cFlowType))
                        sbSQL.AppendLine("AND cuad_cFlowType ='" + searchInfo.cuad_cFlowType + "'");
                    if (searchInfo.cuad_cConsumeID != null)
                        sbSQL.AppendLine("AND cuad_cConsumeID ='" + searchInfo.cuad_cConsumeID + "'");
                    sbSQL.AppendLine("AND cuad_dOptTime >= '" + dtBegin.ToString("yyyy-MM-dd 00:00:00") + "'");
                    sbSQL.AppendLine("AND cuad_dOptTime <= '" + dtEnd.ToString("yyyy-MM-dd 23:59:59") + "'");
                }

                sbSQL.AppendLine(@"and cuad_cFlowType in('Recharge_PersonalRealTime'
,'Recharge_PersonalTransfer'
,'Recharge_BatchTransfer'
,'Refund_PersonalCash'
,'Refund_CardPersonalRealTime'
,'Refund_PersonalTransfer'
,'Refund_BatchTransfer'))CUAD inner join CardUserAccount_cua on cua_cRecordID = cuad_cCUAID 
inner join CardUserMaster_cus on cua_cCUSID = cus_cRecordID
left join ClassMaster_csm on csm_cRecordID = cus_cClassID
left join DepartmentMaster_dpm on dpm_RecordID = cus_cClassID
 )as A ORDER BY cuad_dOptTime DESC");

                using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                {
                    IEnumerable<CardUserAccountDetail_cuad_Info> query = db.ExecuteQuery<CardUserAccountDetail_cuad_Info>(sbSQL.ToString(), new object[] { });
                    if (query != null)
                    {
                        listRecordInfo = query.ToList<CardUserAccountDetail_cuad_Info>();
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return listRecordInfo;
        }
    }
}
