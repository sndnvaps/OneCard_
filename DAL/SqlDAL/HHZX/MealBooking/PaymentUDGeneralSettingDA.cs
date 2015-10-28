using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.IDAL.HHZX.MealBooking;
using Model.HHZX.MealBooking;
using Model.IModel;
using Model.General;
using LinqToSQLModel;

namespace DAL.SqlDAL.HHZX.MealBooking
{
    public class PaymentUDGeneralSettingDA : IPaymentUDGeneralSettingDA
    {

        #region IMainGeneralDA<PaymentUDGeneralSetting_pus_Info> Members

        public ReturnValueInfo InsertRecord(PaymentUDGeneralSetting_pus_Info infoObject)
        {
            ReturnValueInfo returnInfo = new ReturnValueInfo(false);

            if (infoObject != null)
            {
                try
                {
                    using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                    {
                        string sqlStr = string.Empty;

                        sqlStr += "delete from " + Environment.NewLine;

                        sqlStr += "dbo.PaymentUDGeneralSetting_pus" + Environment.NewLine;

                        sqlStr += "where 1=1" + Environment.NewLine;

                        if (infoObject.pus_cGradeID != null)
                        {
                            sqlStr += "and pus_cGradeID='" + infoObject.pus_cGradeID.Value.ToString() + "'" + Environment.NewLine;
                        }

                        if (infoObject.pus_cCardUserID != null)
                        {
                            sqlStr += "and pus_cCardUserID='" + infoObject.pus_cCardUserID.Value.ToString() + "'" + Environment.NewLine;
                        }

                        if (infoObject.pus_cClassID != null)
                        {
                            sqlStr += "and pus_cClassID='" + infoObject.pus_cClassID.Value.ToString() + "'" + Environment.NewLine;
                        }

                        if (infoObject.pus_iWeek != null)
                        {
                            sqlStr += "and pus_iWeek=" + infoObject.pus_iWeek.Value.ToString() + "" + Environment.NewLine;
                        }

                        db.ExecuteCommand(sqlStr, new object[] { });


                        PaymentUDGeneralSetting_pus insertData = Common.General.CopyObjectValue<PaymentUDGeneralSetting_pus_Info, PaymentUDGeneralSetting_pus>(infoObject);

                        db.PaymentUDGeneralSetting_pus.InsertOnSubmit(insertData);

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

        public ReturnValueInfo UpdateRecord(PaymentUDGeneralSetting_pus_Info infoObject)
        {
            ReturnValueInfo returnInfo = new ReturnValueInfo(false);

            if (infoObject != null)
            {
                try
                {
                    using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                    {
                        PaymentUDGeneralSetting_pus updateData = db.PaymentUDGeneralSetting_pus.FirstOrDefault(t => t.pus_cRecordID == infoObject.pus_cRecordID);

                        if (updateData != null)
                        {
                            updateData.pus_cGradeID = infoObject.pus_cGradeID;

                            updateData.pus_cCardUserID = infoObject.pus_cCardUserID;

                            updateData.pus_cClassID = infoObject.pus_cClassID;

                            updateData.pus_iWeek = infoObject.pus_iWeek.Value;

                            updateData.pus_cBreakfast = infoObject.pus_cBreakfast;

                            updateData.pus_cLunch = infoObject.pus_cLunch;

                            updateData.pus_cDinner = infoObject.pus_cDinner;

                            updateData.pus_cSnack = infoObject.pus_cSnack;

                            updateData.pus_cLast = infoObject.pus_cLast;

                            updateData.pus_dLastDate = infoObject.pus_dLastDate;

                            db.SubmitChanges();

                            returnInfo.boolValue = true;
                        }
                    }
                }
                catch (Exception Ex)
                {

                    returnInfo.messageText = Ex.Message; ;
                }
            }

            return returnInfo;
        }

        public ReturnValueInfo DeleteRecord(IModelObject KeyObject)
        {
            ReturnValueInfo returnInfo = new ReturnValueInfo(false);

            PaymentUDGeneralSetting_pus_Info deleteInfo = KeyObject as PaymentUDGeneralSetting_pus_Info;

            if (deleteInfo != null)
            {
                try
                {
                    using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                    {
                        PaymentUDGeneralSetting_pus deleteData;

                        IEnumerable<PaymentUDGeneralSetting_pus> delDatas;

                        if (deleteInfo.pus_cRecordID != Guid.Empty)
                        {
                            deleteData = db.PaymentUDGeneralSetting_pus.FirstOrDefault(t => t.pus_cRecordID == deleteInfo.pus_cRecordID);

                            db.PaymentUDGeneralSetting_pus.DeleteOnSubmit(deleteData);

                            returnInfo.boolValue = true;
                        }
                        else
                        {
                            if (deleteInfo.pus_cGradeID != null)
                            {
                                delDatas = from t in db.PaymentUDGeneralSetting_pus
                                           where t.pus_cGradeID == deleteInfo.pus_cGradeID
                                           select t;

                                if (delDatas != null && delDatas.Count() > 0)
                                {
                                    db.PaymentUDGeneralSetting_pus.DeleteAllOnSubmit(delDatas);

                                }

                                returnInfo.boolValue = true;
                            }
                            else
                            {
                                if (deleteInfo.pus_cClassID != null)
                                {
                                    delDatas = from t in db.PaymentUDGeneralSetting_pus
                                               where t.pus_cClassID == deleteInfo.pus_cClassID
                                               select t;

                                    if (delDatas != null && delDatas.Count() > 0)
                                    {
                                        db.PaymentUDGeneralSetting_pus.DeleteAllOnSubmit(delDatas);

                                    }

                                    returnInfo.boolValue = true;
                                }
                                else
                                {
                                    if (deleteInfo.pus_cCardUserID != null)
                                    {
                                        delDatas = from t in db.PaymentUDGeneralSetting_pus
                                                   where t.pus_cCardUserID == deleteInfo.pus_cCardUserID
                                                   select t;

                                        if (delDatas != null && delDatas.Count() > 0)
                                        {
                                            db.PaymentUDGeneralSetting_pus.DeleteAllOnSubmit(delDatas);

                                        }

                                        returnInfo.boolValue = true;
                                    }
                                    else
                                    {
                                        returnInfo.messageText = "找不到要删除的记录！";

                                        returnInfo.boolValue = true;
                                    }
                                }

                            }

                        }

                        db.SubmitChanges();
                    }
                }
                catch (Exception Ex)
                {

                    throw Ex;
                }
            }

            return returnInfo;
        }

        public PaymentUDGeneralSetting_pus_Info DisplayRecord(IModelObject KeyObject)
        {
            PaymentUDGeneralSetting_pus_Info display = null;

            display = KeyObject as PaymentUDGeneralSetting_pus_Info;

            if (display != null)
            {
                try
                {
                    using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                    {
                        PaymentUDGeneralSetting_pus displayData = db.PaymentUDGeneralSetting_pus.FirstOrDefault(t => t.pus_cRecordID == display.pus_cRecordID);

                        if (displayData != null)
                        {
                            display = Common.General.CopyObjectValue<PaymentUDGeneralSetting_pus, PaymentUDGeneralSetting_pus_Info>(displayData);
                        }
                    }
                }
                catch (Exception Ex)
                {

                    throw Ex;
                }
            }

            return display;
        }

        public List<PaymentUDGeneralSetting_pus_Info> SearchRecords(IModelObject searchCondition)
        {
            List<PaymentUDGeneralSetting_pus_Info> searchList = new List<PaymentUDGeneralSetting_pus_Info>();

            IEnumerable<PaymentUDGeneralSetting_pus> searchData = null;

            try
            {
                using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                {
                    PaymentUDGeneralSetting_pus_Info query = searchCondition as PaymentUDGeneralSetting_pus_Info;

                    if (query != null)
                    {
                        searchData = from t in db.PaymentUDGeneralSetting_pus
                                     select t;

                        if (query.pus_cCardUserID != null)
                        {
                            searchData = searchData.Where(t => t.pus_cCardUserID == query.pus_cCardUserID);
                        }

                        if (query.pus_cClassID != null)
                        {
                            searchData = searchData.Where(t => t.pus_cClassID == query.pus_cClassID);
                        }

                        if (query.pus_cGradeID != null)
                        {
                            searchData = searchData.Where(t => t.pus_cGradeID == query.pus_cGradeID);
                        }

                        if (query.pus_iWeek != null && query.pus_iWeek != -1)
                        {
                            searchData = searchData.Where(t => t.pus_iWeek == query.pus_iWeek);
                        }

                        if (searchData != null && searchData.Count() > 0)
                        {
                            foreach (PaymentUDGeneralSetting_pus item in searchData)
                            {
                                PaymentUDGeneralSetting_pus_Info info = Common.General.CopyObjectValue<PaymentUDGeneralSetting_pus, PaymentUDGeneralSetting_pus_Info>(item);

                                searchList.Add(info);
                            }
                        }
                    }
                }
            }
            catch (Exception Ex)
            {

                throw Ex;
            }

            return searchList;
        }

        public List<PaymentUDGeneralSetting_pus_Info> AllRecords()
        {
            throw new NotImplementedException();
        }

        #endregion

        public ReturnValueInfo Save(List<PaymentUDGeneralSetting_pus_Info> objList)
        {
            ReturnValueInfo rvInfo = new ReturnValueInfo();
            try
            {
                if (objList != null && objList.Count > 0)
                {
                    using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                    {
                        db.Connection.Open();
                        db.Transaction = db.Connection.BeginTransaction();

                        try
                        {
                            List<PaymentUDGeneralSetting_pus> listPreInsert = new List<PaymentUDGeneralSetting_pus>();

                            foreach (PaymentUDGeneralSetting_pus_Info item in objList)
                            {
                                #region 删除历史记录

                                List<PaymentUDGeneralSetting_pus> listTargetDel = null;
                                if (item.pus_cCardUserID != null)
                                {
                                    listTargetDel = db.PaymentUDGeneralSetting_pus.Where(x => x.pus_cCardUserID == item.pus_cCardUserID.Value && x.pus_iWeek == item.pus_iWeek).ToList();
                                }
                                else if (item.pus_cClassID != null)
                                {
                                    listTargetDel = db.PaymentUDGeneralSetting_pus.Where(x => x.pus_cClassID == item.pus_cClassID.Value && x.pus_iWeek == item.pus_iWeek).ToList();
                                }
                                else if (item.pus_cGradeID != null)
                                {
                                    listTargetDel = db.PaymentUDGeneralSetting_pus.Where(x => x.pus_cGradeID == item.pus_cGradeID.Value && x.pus_iWeek == item.pus_iWeek).ToList();
                                }

                                if (listTargetDel != null && listTargetDel.Count > 0)
                                {
                                    db.PaymentUDGeneralSetting_pus.DeleteAllOnSubmit(listTargetDel);
                                    db.SubmitChanges();
                                }

                                #endregion

                                PaymentUDGeneralSetting_pus setting = Common.General.CopyObjectValue<PaymentUDGeneralSetting_pus_Info, PaymentUDGeneralSetting_pus>(item);
                                if (item != null)
                                {
                                    listPreInsert.Add(setting);
                                }
                            }
                            if (listPreInsert != null && listPreInsert.Count > 0)
                            {
                                db.PaymentUDGeneralSetting_pus.InsertAllOnSubmit(listPreInsert);
                                db.SubmitChanges();
                                db.Transaction.Commit();

                                rvInfo.boolValue = true;
                            }
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
                rvInfo.messageText = ex.Message;
                rvInfo.isError = true;
            }
            return rvInfo;
        }

        public ReturnValueInfo BatchDeleteRecords(PaymentUDGeneralSetting_pus_Info searchInfo)
        {
            ReturnValueInfo rvInfo = new ReturnValueInfo();

            try
            {
                using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                {
                    List<PaymentUDGeneralSetting_pus> searchData = db.PaymentUDGeneralSetting_pus.Where(x => 1 == 1).ToList();
                    PaymentUDGeneralSetting_pus_Info query = searchInfo as PaymentUDGeneralSetting_pus_Info;

                    if (query != null)
                    {
                        if (query.pus_cCardUserID != null)
                        {
                            searchData = searchData.Where(t => t.pus_cCardUserID == query.pus_cCardUserID).ToList();
                        }
                        if (query.pus_cClassID != null)
                        {
                            searchData = searchData.Where(t => t.pus_cClassID == query.pus_cClassID).ToList();
                        }
                        if (query.pus_cGradeID != null)
                        {
                            searchData = searchData.Where(t => t.pus_cGradeID == query.pus_cGradeID).ToList();
                        }
                        if (query.pus_iWeek != null && query.pus_iWeek != -1)
                        {
                            searchData = searchData.Where(t => t.pus_iWeek == query.pus_iWeek).ToList();
                        }
                    }
                    else
                    {
                        rvInfo.messageText = Common.DefineConstantValue.SystemMessageText.strMessageText_E_ObjectNull;
                        return rvInfo;
                    }

                    db.PaymentUDGeneralSetting_pus.DeleteAllOnSubmit(searchData);
                    db.SubmitChanges();
                    rvInfo.boolValue = true;
                }
            }
            catch (Exception ex)
            {
                rvInfo.isError = true;
                rvInfo.messageText = ex.Message;
            }
            return rvInfo;
        }

        #region IExtraDA Members

        public bool IsExistRecord(object KeyObject)
        {
            bool isExist = true;

            PaymentUDGeneralSetting_pus_Info info = KeyObject as PaymentUDGeneralSetting_pus_Info;

            if (info != null)
            {
                try
                {
                    using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                    {
                        PaymentUDGeneralSetting_pus query = db.PaymentUDGeneralSetting_pus.FirstOrDefault(t => t.pus_cCardUserID == info.pus_cCardUserID && t.pus_cClassID == info.pus_cClassID && t.pus_cGradeID == info.pus_cGradeID && t.pus_iWeek == info.pus_iWeek);

                        if (query == null)
                        {
                            isExist = false;
                        }
                        else
                        {
                            isExist = true;
                        }
                    }
                }
                catch (Exception Ex)
                {

                    throw Ex;
                }
            }

            return isExist;
        }

        public ReturnValueInfo LockRecord(object KeyObject)
        {
            throw new NotImplementedException();
        }

        public ReturnValueInfo UnLockRecord(object KeyObject)
        {
            throw new NotImplementedException();
        }

        public bool IsMyLockedRecord(object KeyObject)
        {
            throw new NotImplementedException();
        }

        public IModelObject GetTableFieldLenght()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
