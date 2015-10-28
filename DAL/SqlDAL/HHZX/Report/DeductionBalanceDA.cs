using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.IDAL.Report;
using LinqToSQLModel;
using Model.HHZX.Report;

namespace DAL.SqlDAL.HHZX.Report
{
    public class DeductionBalanceDA : IDeductionBalanceDA
    {

        #region IMainGeneralDA<DeductionBalance_Info> 成员

        public Model.General.ReturnValueInfo InsertRecord(DeductionBalance_Info infoObject)
        {
            throw new NotImplementedException();
        }

        public Model.General.ReturnValueInfo UpdateRecord(DeductionBalance_Info infoObject)
        {
            throw new NotImplementedException();
        }

        public Model.General.ReturnValueInfo DeleteRecord(Model.IModel.IModelObject KeyObject)
        {
            throw new NotImplementedException();
        }

        public DeductionBalance_Info DisplayRecord(Model.IModel.IModelObject KeyObject)
        {
            throw new NotImplementedException();
        }

        public List<DeductionBalance_Info> SearchRecords(Model.IModel.IModelObject searchCondition)
        {
            List<DeductionBalance_Info> returnList = new List<DeductionBalance_Info>();

            try
            {
                DeductionBalance_Info searchInfo = searchCondition as DeductionBalance_Info;

                StringBuilder sbSQL = new StringBuilder();
                sbSQL.AppendLine("select *,cua_fCurrentBalance as Balance ");
                sbSQL.AppendLine("from dbo.PreConsumeRecord_pcs");
                sbSQL.AppendLine("join dbo.CardUserAccount_cua on cua_cRecordID = pcs_cAccountID");
                sbSQL.AppendLine("join dbo.CardUserMaster_cus on cus_cRecordID = cua_cCUSID");
                sbSQL.AppendLine("join dbo.ClassMaster_csm on csm_cRecordID = cus_cClassID");
                sbSQL.AppendLine("join dbo.UserCardPair_ucp on ucp_cCUSID = cus_cRecordID and ucp_dReturnTime is null");
                sbSQL.AppendLine(" where pcs_cConsumeType = 'SetMealCost' and pcs_lIsSettled = 1");

                if (searchInfo != null)
                {
                    if (searchInfo.ClassID != Guid.Empty)
                    {
                        sbSQL.AppendLine("AND csm_cRecordID ='" + searchInfo.ClassID.ToString() + "'");
                    }
                    if (searchInfo.CardNo > 0)
                    {
                        sbSQL.AppendLine("AND ucp_iCardNo ='" + searchInfo.CardNo.ToString() + "'");
                    }
                    if (!String.IsNullOrEmpty(searchInfo.ChaName))
                    {
                        sbSQL.AppendLine("AND cus_cChaName like N'%" + searchInfo.ChaName.ToString() + "%'");
                    }
                    if (!String.IsNullOrEmpty(searchInfo.StudentID))
                    {
                        sbSQL.AppendLine("AND cus_cStudentID ='" + searchInfo.StudentID.ToString() + "'");
                    }

                    sbSQL.AppendLine("AND pcs_dConsumeDate between '" + searchInfo.FromTime.ToString("yyyy/MM/dd") + "' and '" + searchInfo.ToTime.ToString("yyyy/MM/dd") + "'");
                    sbSQL.AppendLine("order by pcs_dConsumeDate desc");

                }

                using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                {
                    IEnumerable<DeductionBalance_Info> query = db.ExecuteQuery<DeductionBalance_Info>(sbSQL.ToString(), new object[] { });
                    if (query != null)
                    {
                        returnList = query.ToList<DeductionBalance_Info>();
                    }
                }

            }
            catch
            {

            }
            return returnList;
        }

        public List<DeductionBalance_Info> AllRecords()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
