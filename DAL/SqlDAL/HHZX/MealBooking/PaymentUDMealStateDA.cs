using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.IDAL.HHZX.MealBooking;
using Model.General;
using Model.HHZX.MealBooking;
using Model.IModel;
using LinqToSQLModel;

namespace DAL.SqlDAL.HHZX.MealBooking
{
    public class PaymentUDMealStateDA : IPaymentUDMealStateDA
    {

        #region IMainGeneralDA<PaymentUDMealState_pms_Info> Members

        public ReturnValueInfo InsertRecord(PaymentUDMealState_pms_Info infoObject)
        {
            ReturnValueInfo returnInfo = new ReturnValueInfo(false);

            if (infoObject != null)
            {
                try
                {
                    using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                    {
                        PaymentUDMealState_pms insertData = Common.General.CopyObjectValue<PaymentUDMealState_pms_Info, PaymentUDMealState_pms>(infoObject);

                        db.PaymentUDMealState_pms.InsertOnSubmit(insertData);

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

        public ReturnValueInfo UpdateRecord(PaymentUDMealState_pms_Info infoObject)
        {
            ReturnValueInfo returnInfo = new ReturnValueInfo(false);

            if (infoObject != null)
            {
                try
                {
                    using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                    {
                        PaymentUDMealState_pms updata = db.PaymentUDMealState_pms.FirstOrDefault(t => t.pms_cRecordID == infoObject.pms_cRecordID);

                        if (updata != null)
                        {
                            updata.pms_dStartDate = infoObject.pms_dStartDate;

                            updata.pms_dEndDate = infoObject.pms_dEndDate;

                            updata.pms_cBreakfast = infoObject.pms_cBreakfast;

                            updata.pms_cLunch = infoObject.pms_cLunch;

                            updata.pms_cDinner = infoObject.pms_cDinner;

                            updata.pms_cSnack = infoObject.pms_cSnack;

                            updata.pms_cLast = infoObject.pms_cLast;

                            updata.pms_dLastDate = infoObject.pms_dLastDate;

                            db.SubmitChanges();

                            returnInfo.boolValue = true;
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

        public ReturnValueInfo DeleteRecord(IModelObject KeyObject)
        {
            ReturnValueInfo returnInfo = new ReturnValueInfo(false);

            PaymentUDMealState_pms_Info deleteInfo = KeyObject as PaymentUDMealState_pms_Info;

            if (deleteInfo != null)
            {
                try
                {
                    using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                    {
                        PaymentUDMealState_pms deleteData = db.PaymentUDMealState_pms.FirstOrDefault(t => t.pms_cRecordID == deleteInfo.pms_cRecordID);

                        if (deleteData != null)
                        {
                            db.PaymentUDMealState_pms.DeleteOnSubmit(deleteData);

                            db.SubmitChanges();

                            returnInfo.boolValue = true;
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

        public PaymentUDMealState_pms_Info DisplayRecord(IModelObject KeyObject)
        {
            PaymentUDMealState_pms_Info displayInfo = KeyObject as PaymentUDMealState_pms_Info;

            if (displayInfo != null)
            {
                try
                {
                    using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                    {
                        PaymentUDMealState_pms displayData = db.PaymentUDMealState_pms.FirstOrDefault(t => t.pms_cRecordID == displayInfo.pms_cRecordID);

                        if (displayData != null)
                        {
                            displayInfo = Common.General.CopyObjectValue<PaymentUDMealState_pms, PaymentUDMealState_pms_Info>(displayData);
                        }
                    }
                }
                catch (Exception Ex)
                {

                    throw Ex;
                }
            }

            return displayInfo;
        }

        public List<PaymentUDMealState_pms_Info> SearchRecords(IModelObject searchCondition)
        {
            List<PaymentUDMealState_pms_Info> returnList = new List<PaymentUDMealState_pms_Info>();

            PaymentUDMealState_pms_Info query = searchCondition as PaymentUDMealState_pms_Info;

            try
            {
                using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                {
                    IEnumerable<PaymentUDMealState_pms> searchRecord = from t in db.PaymentUDMealState_pms
                                                                       select t;

                    if (searchRecord != null && searchRecord.Count() > 0)
                    {
                        if (query.pms_cCardUserID != null)
                        {
                            searchRecord = searchRecord.Where(t => t.pms_cCardUserID == query.pms_cCardUserID);
                        }

                        if (query.pms_cClassID != null)
                        {
                            searchRecord = searchRecord.Where(t => t.pms_cClassID == query.pms_cClassID);
                        }

                        if (query.pms_cGradeID != null)
                        {
                            searchRecord = searchRecord.Where(t => t.pms_cGradeID == query.pms_cGradeID);
                        }

                        if (query.TimeFrom != null && query.TimeTo != null)
                        {
                            searchRecord = searchRecord.Where(t => t.pms_dStartDate <= query.TimeTo && t.pms_dEndDate >= query.TimeFrom);
                        }

                        if (searchRecord != null && searchRecord.Count() > 0)
                        {
                            foreach (PaymentUDMealState_pms item in searchRecord)
                            {
                                PaymentUDMealState_pms_Info info = Common.General.CopyObjectValue<PaymentUDMealState_pms, PaymentUDMealState_pms_Info>(item);

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

        public List<PaymentUDMealState_pms_Info> AllRecords()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
