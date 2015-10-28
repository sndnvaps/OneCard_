using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.IDAL.HHZX.UserInformation.CardUserInfo;
using Model.HHZX.UserInfomation.CardUserInfo;
using Model.IModel;
using DAL.IDAL;
using Model.General;
using LinqToSQLModel;

namespace DAL.SqlDAL.HHZX.UserInformation.CardUserInfo
{
    public class GradeMasterDA : IGradeMasterDA
    {
        #region IGradeMasterDA<GradeMaster_gdm_Info> Members

        public ReturnValueInfo InsertRecord(GradeMaster_gdm_Info infoObject)
        {
            ReturnValueInfo returnInfo = new ReturnValueInfo(false);

            if (infoObject != null)
            {
                try
                {
                    using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                    {
                        GradeMaster_gdm insertData = Common.General.CopyObjectValue<GradeMaster_gdm_Info, GradeMaster_gdm>(infoObject);

                        db.GradeMaster_gdm.InsertOnSubmit(insertData);

                        db.SubmitChanges();

                        returnInfo.boolValue = true;

                        returnInfo.ValueObject = infoObject;
                    }
                }
                catch (Exception Ex)
                {

                    returnInfo.messageText = Ex.Message;
                }
            }
            else
            {
                returnInfo.messageText = Common.DefineConstantValue.SystemMessageText.strMessageText_E_ObjectNull;
            }

            return returnInfo;
        }

        public ReturnValueInfo UpdateRecord(GradeMaster_gdm_Info infoObject)
        {
            ReturnValueInfo returnInfo = new ReturnValueInfo(false);

            if (infoObject != null)
            {
                try
                {
                    using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                    {
                        db.Connection.Open();
                        db.Transaction = db.Connection.BeginTransaction();
                        try
                        {
                            GradeMaster_gdm updateData = db.GradeMaster_gdm.FirstOrDefault(t => t.gdm_cRecordID == infoObject.gdm_cRecordID);

                            if (updateData != null)
                            {
                                updateData.gdm_cGradeName = infoObject.gdm_cGradeName;
                                updateData.gdm_cPraepostorID = infoObject.gdm_cPraepostorID;
                                updateData.gdm_cRemark = infoObject.gdm_cRemark;
                                updateData.gdm_cAbbreviation = infoObject.gdm_cAbbreviation;
                                updateData.gdm_cLast = infoObject.gdm_cLast;
                                updateData.gdm_cLastDate = infoObject.gdm_cLastDate.Value;
                                updateData.gdm_cLastDate = DateTime.Now;
                                db.SubmitChanges();

                                List<CodeMaster_cmt> listCodeKey = db.CodeMaster_cmt.Where(x => x.cmt_cKey1 == Common.DefineConstantValue.CodeMasterDefine.KEY1_SIOT_CardUserClass).ToList();
                                List<ClassMaster_csm> listClassInfos = db.ClassMaster_csm.Where(x => x.csm_cGDMID == updateData.gdm_cRecordID).ToList();
                                foreach (ClassMaster_csm classItem in listClassInfos)
                                {
                                    classItem.csm_cClassName = updateData.gdm_cGradeName;
                                    CodeMaster_cmt tagClass = listCodeKey.Find(x => x.cmt_cKey2 == classItem.csm_cClassNum);
                                    if (tagClass != null)
                                    {
                                        string strClassNum = tagClass.cmt_cValue;
                                        if (!string.IsNullOrEmpty(tagClass.cmt_cValue) && tagClass.cmt_cValue.Length > 1)
                                        {
                                            strClassNum = "(" + strClassNum.Substring(0, 2) + ")" + strClassNum.Substring(2, 1);
                                        }
                                        else
                                        {
                                            strClassNum = "(" + strClassNum + ")";
                                        }
                                        classItem.csm_cClassName += strClassNum;
                                    }
                                }
                                if (listClassInfos != null && listClassInfos.Count > 0)
                                {
                                    db.SubmitChanges();
                                }

                                db.Transaction.Commit();
                                db.Connection.Close();
                                returnInfo.boolValue = true;
                            }
                            else
                            {
                                returnInfo.messageText = Common.DefineConstantValue.SystemMessageText.strMessageText_E_UpdateDataNull;
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
                catch (Exception Ex)
                {
                    returnInfo.messageText = Ex.Message;
                }
            }
            else
            {
                returnInfo.messageText = Common.DefineConstantValue.SystemMessageText.strMessageText_E_ObjectNull;
            }

            return returnInfo;
        }

        public ReturnValueInfo DeleteRecord(IModelObject KeyObject)
        {
            ReturnValueInfo returnInfo = new ReturnValueInfo(false);

            GradeMaster_gdm_Info deleteInfo = KeyObject as GradeMaster_gdm_Info;

            if (deleteInfo != null)
            {
                try
                {
                    using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                    {
                        GradeMaster_gdm deleteData = db.GradeMaster_gdm.FirstOrDefault(t => t.gdm_cRecordID == deleteInfo.gdm_cRecordID);

                        if (deleteData != null)
                        {
                            IEnumerable<ClassMaster_csm> classe = from t in db.ClassMaster_csm
                                                                  where t.csm_cGDMID == deleteInfo.gdm_cRecordID
                                                                  select t;

                            if (classe != null && classe.Count() > 0)
                            {
                                returnInfo.messageText = Common.DefineConstantValue.SystemMessageText.strMessageText_E_DeleteObjectHaveContectData;
                            }
                            else
                            {
                                db.GradeMaster_gdm.DeleteOnSubmit(deleteData);

                                db.SubmitChanges();

                                returnInfo.boolValue = true;
                            }
                        }
                        else
                        {
                            returnInfo.messageText = Common.DefineConstantValue.SystemMessageText.strMessageText_E_DeleteDataNull;
                        }
                    }
                }
                catch (Exception Ex)
                {

                    returnInfo.messageText = Ex.Message;
                }
            }
            else
            {
                returnInfo.messageText = Common.DefineConstantValue.SystemMessageText.strMessageText_E_DeleteDataNull;
            }

            return returnInfo;
        }

        public GradeMaster_gdm_Info DisplayRecord(IModelObject KeyObject)
        {
            GradeMaster_gdm_Info displayInfo = null;

            if (KeyObject != null)
            {
                displayInfo = KeyObject as GradeMaster_gdm_Info;

                try
                {
                    using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                    {
                        GradeMaster_gdm displayData = db.GradeMaster_gdm.FirstOrDefault(t => t.gdm_cRecordID == displayInfo.gdm_cRecordID);

                        if (displayData != null)
                        {
                            displayInfo = Common.General.CopyObjectValue<GradeMaster_gdm, GradeMaster_gdm_Info>(displayData);
                        }
                        else
                        {
                            return null;
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

        public List<GradeMaster_gdm_Info> SearchRecords(IModelObject searchCondition)
        {
            List<GradeMaster_gdm_Info> allRecords = null;

            try
            {
                using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                {
                    IEnumerable<GradeMaster_gdm> allDatas = from t in db.GradeMaster_gdm
                                                            orderby t.gdm_dAddDate ascending
                                                            select t;

                    GradeMaster_gdm_Info searchInfo = searchCondition as GradeMaster_gdm_Info;
                    if (searchInfo == null)
                    {
                        return null;
                    }
                    else
                    {
                        if (searchInfo.gdm_cPraepostorID != null || searchInfo.gdm_cPraepostorID != Guid.Empty)
                        {
                            allDatas = allDatas.Where(x => x.gdm_cPraepostorID == searchInfo.gdm_cPraepostorID);
                        }
                        if (!string.IsNullOrEmpty(searchInfo.gdm_cGradeName))
                        {
                            allDatas = allDatas.Where(x => x.gdm_cGradeName == searchInfo.gdm_cGradeName);
                        }
                    }

                    if (allDatas != null && allDatas.Count() > 0)
                    {
                        allRecords = new List<GradeMaster_gdm_Info>();

                        foreach (GradeMaster_gdm item in allDatas)
                        {
                            GradeMaster_gdm_Info addInfo = Common.General.CopyObjectValue<GradeMaster_gdm, GradeMaster_gdm_Info>(item);

                            CardUserMaster_cus staff = db.CardUserMaster_cus.FirstOrDefault(t => t.cus_cRecordID == item.gdm_cPraepostorID);

                            if (staff != null)
                            {
                                addInfo.gdm_cPraepostorName = staff.cus_cChaName;

                                addInfo.gdm_cPraepostorPhone = staff.cus_cContractPhone;
                            }

                            allRecords.Add(addInfo);
                        }
                    }
                }
            }
            catch (Exception Ex)
            {

                throw Ex;
            }

            return allRecords;
        }

        public List<GradeMaster_gdm_Info> AllRecords()
        {
            List<GradeMaster_gdm_Info> allRecords = null;

            try
            {
                using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                {
                    IEnumerable<GradeMaster_gdm> allDatas = from t in db.GradeMaster_gdm
                                                            orderby t.gdm_dAddDate ascending
                                                            select t;

                    if (allDatas != null && allDatas.Count() > 0)
                    {
                        allRecords = new List<GradeMaster_gdm_Info>();

                        foreach (GradeMaster_gdm item in allDatas)
                        {
                            GradeMaster_gdm_Info addInfo = Common.General.CopyObjectValue<GradeMaster_gdm, GradeMaster_gdm_Info>(item);

                            CardUserMaster_cus staff = db.CardUserMaster_cus.FirstOrDefault(t => t.cus_cRecordID == item.gdm_cPraepostorID);

                            if (staff != null)
                            {
                                addInfo.gdm_cPraepostorName = staff.cus_cChaName;

                                addInfo.gdm_cPraepostorPhone = staff.cus_cContractPhone;
                            }

                            allRecords.Add(addInfo);
                        }
                    }
                }
            }
            catch (Exception Ex)
            {

                throw Ex;
            }

            return allRecords;
        }

        #endregion
    }
}
