using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.IDAL.Report;
using Model.HHZX.ComsumeAccount;
using Model.HHZX.UserInfomation.CardUserInfo;
using LinqToSQLModel;

namespace DAL.SqlDAL.HHZX.Report
{
    public class MoneyBalanceDA : IMoneyBalanceDA
    {
        #region IMainGeneralDA<CardUserAccount_cua_Info> 成员

        public Model.General.ReturnValueInfo InsertRecord(Model.HHZX.ComsumeAccount.CardUserAccount_cua_Info infoObject)
        {
            throw new NotImplementedException();
        }

        public Model.General.ReturnValueInfo UpdateRecord(Model.HHZX.ComsumeAccount.CardUserAccount_cua_Info infoObject)
        {
            throw new NotImplementedException();
        }

        public Model.General.ReturnValueInfo DeleteRecord(Model.IModel.IModelObject KeyObject)
        {
            throw new NotImplementedException();
        }

        public Model.HHZX.ComsumeAccount.CardUserAccount_cua_Info DisplayRecord(Model.IModel.IModelObject KeyObject)
        {
            throw new NotImplementedException();
        }

        public List<Model.HHZX.ComsumeAccount.CardUserAccount_cua_Info> SearchRecords(Model.IModel.IModelObject searchCondition)
        {
            List<CardUserAccount_cua_Info> cuaList = new List<CardUserAccount_cua_Info>();

            try
            {
                CardUserMaster_cus_Info searchInfo = searchCondition as CardUserMaster_cus_Info;

                StringBuilder sbSQL = new StringBuilder();
                sbSQL.AppendLine(@"select cus_cStudentID,cus_cChaName as cua_cUserName
,ISNULL(csm_cClassName,dpm_cName) as cua_cClassName
,ISNULL(cua_fCurrentBalance,0.00) as cua_fCurrentBalance
,cua_dLastSyncTime
,ISNULL(csr_fCardBalance,0.00) as cua_dCardBlance
from CardUserMaster_cus with(nolock)
left join CardUserAccount_cua with(nolock) on cus_cRecordID = cua_cCUSID
left join ClassMaster_csm with(nolock) on csm_cRecordID = cus_cClassID
left join DepartmentMaster_dpm with(nolock) on dpm_RecordID = cus_cClassID
left join
(
select * from ConsumeRecord_csr with(nolock) inner join
(select MAX(csr_dConsumeDate) as ConsumeDate,csr_cCardUserID as UserID from ConsumeRecord_csr with(nolock)
where csr_lIsSettled = 1
group by csr_cCardUserID) as MaxTB
on csr_cCardUserID = UserID and csr_dConsumeDate = ConsumeDate
) as CosumeTB on cus_cRecordID = UserID");
                sbSQL.AppendLine("where 1=1 and cua_fCurrentBalance is not null");

                if (searchInfo != null)
                {
                    if (searchInfo.cus_cClassID != Guid.Empty)
                    {
                        sbSQL.AppendLine("AND cus_cClassID ='" + searchInfo.cus_cClassID.ToString() + "'");
                    }
                    if (!String.IsNullOrEmpty(searchInfo.cus_cStudentID))
                    {
                        sbSQL.AppendLine("AND cus_cStudentID like '%" + searchInfo.cus_cStudentID + "%'");
                    }
                    if (!String.IsNullOrEmpty(searchInfo.cus_cChaName))
                    {
                        sbSQL.AppendLine("AND cus_cChaName like N'%" + searchInfo.cus_cChaName + "%'");
                    }
                }

                using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                {
                    db.CommandTimeout = 10 * 60000;
                    IEnumerable<CardUserAccount_cua_Info> query = db.ExecuteQuery<CardUserAccount_cua_Info>(sbSQL.ToString(), new object[] { });
                    if (query != null)
                    {
                        cuaList = query.ToList<CardUserAccount_cua_Info>();
                    }
                }

            }
            catch
            {

            }
            return cuaList;
        }

        public List<Model.HHZX.ComsumeAccount.CardUserAccount_cua_Info> AllRecords()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
