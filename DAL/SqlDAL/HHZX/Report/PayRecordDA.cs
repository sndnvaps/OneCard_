using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.IDAL.Report;
using Model.General;
using Model.HHZX.Report;
using LinqToSQLModel;
using System.Data.SqlClient;

namespace DAL.SqlDAL.HHZX.Report
{
    public class PayRecordDA : IPayRecordDA
    {

        #region IMainGeneralDA<PayRecord_prd_Info> Members

        public ReturnValueInfo InsertRecord(PayRecord_prd_Info infoObject)
        {
            ReturnValueInfo returnInfo = new ReturnValueInfo(false);

            if (infoObject != null)
            {
                try
                {
                    using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                    {
                        PayRecord_prd insertData = Common.General.CopyObjectValue<PayRecord_prd_Info, PayRecord_prd>(infoObject);

                        db.PayRecord_prd.InsertOnSubmit(insertData);

                        db.SubmitChanges();

                        returnInfo.boolValue = true;
                    }
                }
                catch (Exception Ex)
                {

                    returnInfo.messageText = Ex.Message;
                }
            }

            return returnInfo;
        }

        public ReturnValueInfo UpdateRecord(PayRecord_prd_Info infoObject)
        {
            ReturnValueInfo returnInfo = new ReturnValueInfo(false);

            if (infoObject != null)
            {
                try
                {
                    using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                    {
                        PayRecord_prd updataData = db.PayRecord_prd.FirstOrDefault(t => t.prd_cRecordID == infoObject.prd_cRecordID);

                        if (updataData != null)
                        {
                            updataData.prd_cPayType = infoObject.prd_cPayType;

                            updataData.prd_fPayMoney = infoObject.prd_fPayMoney;

                            updataData.prd_cDepartmentID = infoObject.prd_cDepartmentID;

                            updataData.prd_cCertificateID = infoObject.prd_cCertificateID;

                            updataData.prd_dCertificateDate = infoObject.prd_dCertificateDate;

                            updataData.prd_cLast = infoObject.prd_cLast;

                            updataData.prd_dLastDate = infoObject.prd_dLastDate;

                            updataData.prd_iPayCount = infoObject.prd_iPayCount;

                            db.SubmitChanges();

                            returnInfo.boolValue = true;
                        }
                        else
                        {
                            returnInfo.messageText = "找不到要修改的记录！";
                        }
                    }
                }
                catch (Exception Ex)
                {

                    returnInfo.messageText = Ex.Message;
                }
            }

            return returnInfo;
        }

        public ReturnValueInfo DeleteRecord(Model.IModel.IModelObject KeyObject)
        {
            ReturnValueInfo returnInfo = new ReturnValueInfo(false);

            PayRecord_prd_Info deleteInfo = KeyObject as PayRecord_prd_Info;

            if (deleteInfo != null)
            {
                try
                {
                    using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                    {
                        PayRecord_prd deleteData = db.PayRecord_prd.FirstOrDefault(t => t.prd_cRecordID == deleteInfo.prd_cRecordID);

                        if (deleteData != null)
                        {
                            db.PayRecord_prd.DeleteOnSubmit(deleteData);

                            db.SubmitChanges();

                            returnInfo.boolValue = true;
                        }
                        else
                        {
                            returnInfo.messageText = "找不到要删除的记录！";
                        }
                    }
                }
                catch (Exception Ex)
                {

                    returnInfo.messageText = Ex.Message;
                }
            }

            return returnInfo;
        }

        public PayRecord_prd_Info DisplayRecord(Model.IModel.IModelObject KeyObject)
        {
            PayRecord_prd_Info showInfo = KeyObject as PayRecord_prd_Info;

            if (showInfo != null)
            {
                try
                {
                    using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                    {
                        PayRecord_prd displayData = db.PayRecord_prd.FirstOrDefault(t => t.prd_cRecordID == showInfo.prd_cRecordID);

                        if (displayData != null)
                        {
                            showInfo = Common.General.CopyObjectValue<PayRecord_prd, PayRecord_prd_Info>(displayData);
                        }
                        else
                        {
                            showInfo = null;
                        }
                    }
                }
                catch (Exception Ex)
                {

                    throw Ex;
                }
            }

            return showInfo;
        }

        public List<PayRecord_prd_Info> SearchRecords(Model.IModel.IModelObject searchCondition)
        {
            List<PayRecord_prd_Info> returnList = new List<PayRecord_prd_Info>();

            PayRecord_prd_Info query = searchCondition as PayRecord_prd_Info;

            try
            {
                using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                {
                    IEnumerable<PayRecord_prd> searchData = from t in db.PayRecord_prd
                                                            orderby t.prd_dAddDate descending
                                                            select t;
                    if (searchData != null && searchData.Count() > 0)
                    {

                        if (query.prd_cDepartmentID != null && query.prd_cRecordID != Guid.Empty)
                        {
                            searchData = searchData.Where(t => t.prd_cDepartmentID == query.prd_cDepartmentID);
                        }

                        if (query.prd_cPayType != null && query.prd_cPayType != "")
                        {
                            searchData = searchData.Where(t => t.prd_cPayType == query.prd_cPayType);
                        }

                        if (query.prd_dStartDate != null && query.prd_dEndDate != null)
                        {
                            searchData = searchData.Where(t => t.prd_dCertificateDate >= query.prd_dStartDate && t.prd_dCertificateDate <= query.prd_dEndDate.Value.AddDays(1));
                        }

                        IEnumerable<CodeMaster_cmt> cName = from t in db.CodeMaster_cmt
                                                            where t.cmt_cKey1 == Common.DefineConstantValue.CodeMasterDefine.KEY1_SIOT_CostType
                                                            select t;

                        IEnumerable<DepartmentMaster_dpm> departMents = from t in db.DepartmentMaster_dpm
                                                                        select t;

                        if (searchData.Count() > 0)
                        {
                            foreach (PayRecord_prd item in searchData)
                            {
                                PayRecord_prd_Info info = Common.General.CopyObjectValue<PayRecord_prd, PayRecord_prd_Info>(item);

                                CodeMaster_cmt cnName = cName.FirstOrDefault(t => t.cmt_cKey2 == item.prd_cPayType);

                                if (cnName != null)
                                {
                                    info.prd_cPayTypeName = cnName.cmt_cValue;
                                }

                                DepartmentMaster_dpm departmentInfo = departMents.FirstOrDefault(t => t.dpm_RecordID == item.prd_cDepartmentID);

                                if (departmentInfo != null)
                                {
                                    info.prd_cDepartmentName = departmentInfo.dpm_cName;
                                }

                                info.prd_cCertificateDate = info.prd_dCertificateDate.ToString(Common.DefineConstantValue.gc_DateFormat);

                                info.prd_dStartDate = query.prd_dStartDate;

                                info.prd_dEndDate = query.prd_dEndDate;

                                returnList.Add(info);
                            }
                        }
                    }


                }
            }
            catch (Exception Ex)
            {

                throw Ex;
            }

            return returnList;
        }

        public List<PayRecord_prd_Info> AllRecords()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 支出统计
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public decimal PaymentCount(DateTime startDate, DateTime endDate)
        {
            decimal paymentTotal = 0;

            StringBuilder sbSQL = new StringBuilder();

            sbSQL.AppendLine("select TotalMoney=SUM(prd_fPayMoney)");

            sbSQL.AppendLine("from dbo.PayRecord_prd with(nolock)");

            sbSQL.AppendLine("where 1=1");

            sbSQL.AppendLine("and prd_dCertificateDate>='" + startDate.ToString("yyyy-MM-dd") + " 00:00:00'");

            sbSQL.AppendLine("and prd_dCertificateDate<='" + endDate.AddDays(1).ToString("yyyy-MM-dd") + " 00:00:00'");


            List<PayRecord_prd_Info> returnList = new List<PayRecord_prd_Info>();

            try
            {
                using (SqlDataReader reader = DbHelperSQL.ExecuteReader(sbSQL.ToString()))
                {
                    if (reader.Read())
                    {
                        if (reader["TotalMoney"] != null && reader["TotalMoney"].ToString() != string.Empty)
                        {
                            paymentTotal = decimal.Parse(reader["TotalMoney"].ToString());
                        }
                    }
                }
            }
            catch (Exception Ex)
            {

                throw Ex;
            }

            return paymentTotal;
        }

        #endregion
    }
}
