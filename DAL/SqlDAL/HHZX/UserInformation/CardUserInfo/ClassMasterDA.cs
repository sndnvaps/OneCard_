using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.IDAL.HHZX.UserInformation.CardUserInfo;
using Model.General;
using Model.HHZX.UserInfomation.CardUserInfo;
using Model.IModel;
using LinqToSQLModel;

namespace DAL.SqlDAL.HHZX.UserInformation.CardUserInfo
{
    public class ClassMasterDA : IClassMasterDA
    {
        #region IMainGeneralDA<ClassMaster_csm_Info> Members

        public ReturnValueInfo InsertRecord(ClassMaster_csm_Info infoObject)
        {
            ReturnValueInfo returnInfo = new ReturnValueInfo(false);

            if (infoObject != null)
            {
                try
                {
                    using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                    {
                        GetClassName(infoObject);

                        ClassMaster_csm insertData = Common.General.CopyObjectValue<ClassMaster_csm_Info, ClassMaster_csm>(infoObject);

                        db.ClassMaster_csm.InsertOnSubmit(insertData);

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

        public ReturnValueInfo UpdateRecord(ClassMaster_csm_Info infoObject)
        {
            ReturnValueInfo returnInfo = new ReturnValueInfo(false);

            if (infoObject != null)
            {
                try
                {
                    using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                    {
                        GetClassName(infoObject);

                        ClassMaster_csm updateData = db.ClassMaster_csm.FirstOrDefault(t => t.csm_cRecordID == infoObject.csm_cRecordID);

                        if (updateData != null)
                        {
                            updateData.csm_cClassName = infoObject.csm_cClassName;

                            updateData.csm_cClassNum = infoObject.csm_cClassNum;

                            updateData.csm_cGDMID = infoObject.csm_cGDMID;

                            updateData.csm_cMasterID = infoObject.csm_cMasterID;

                            updateData.csm_cRemark = infoObject.csm_cRemark;

                            updateData.csm_cLast = infoObject.csm_cLast;

                            updateData.csm_dLastDate = infoObject.csm_dLastDate;

                            db.SubmitChanges();

                            returnInfo.boolValue = true;

                            returnInfo.ValueObject = infoObject;
                        }
                        else
                        {
                            returnInfo.messageText = Common.DefineConstantValue.SystemMessageText.strMessageText_E_UpdateDataNull;
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

            ClassMaster_csm_Info deleteInfo = KeyObject as ClassMaster_csm_Info;

            if (deleteInfo != null)
            {
                using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                {

                    ClassMaster_csm deleteData = db.ClassMaster_csm.FirstOrDefault(t => t.csm_cRecordID == deleteInfo.csm_cRecordID);

                    if (deleteData != null)
                    {
                        IEnumerable<CardUserMaster_cus> students = from t in db.CardUserMaster_cus
                                                                   where t.cus_cClassID == deleteData.csm_cRecordID
                                                                   select t;

                        if (students != null && students.Count() > 0)
                        {
                            returnInfo.boolValue = false;

                            returnInfo.messageText = "该班下还有学生记录！";
                        }
                        else
                        {
                            IEnumerable<ChangeClassRecord_ccr> query = from t in db.ChangeClassRecord_ccr
                                                                       where t.ccr_cClassID == deleteData.csm_cRecordID
                                                                       select t;
                            if (query != null)
                            {
                                List<ChangeClassRecord_ccr> ccrList = query.ToList();

                                for (int index = 0; index < ccrList.Count; index++)
                                {
                                    db.ChangeClassRecord_ccr.DeleteOnSubmit(ccrList[index]);
                                }
                            }

                            returnInfo.boolValue = true;

                            db.ClassMaster_csm.DeleteOnSubmit(deleteData);

                            db.SubmitChanges();
                        }

                        returnInfo.ValueObject = deleteInfo;
                    }
                    else
                    {
                        returnInfo.messageText = Common.DefineConstantValue.SystemMessageText.strMessageText_E_DeleteDataNull;
                    }

                }
            }
            else
            {
                returnInfo.messageText = Common.DefineConstantValue.SystemMessageText.strMessageText_E_ObjectNull;
            }

            return returnInfo;
        }

        public ClassMaster_csm_Info DisplayRecord(IModelObject KeyObject)
        {
            ClassMaster_csm_Info displayInfo = KeyObject as ClassMaster_csm_Info;

            if (displayInfo != null)
            {
                try
                {
                    using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                    {
                        ClassMaster_csm displayData = db.ClassMaster_csm.FirstOrDefault(t => t.csm_cRecordID == displayInfo.csm_cRecordID);

                        if (displayData != null)
                        {
                            displayInfo = Common.General.CopyObjectValue<ClassMaster_csm, ClassMaster_csm_Info>(displayData);
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
            else
            {
                return null;
            }

            return displayInfo;
        }

        public List<ClassMaster_csm_Info> SearchRecords(IModelObject searchCondition)
        {
            List<ClassMaster_csm_Info> listReturn = null;

            try
            {
                ClassMaster_csm_Info info = searchCondition as ClassMaster_csm_Info;

                string strSql = "select * from dbo.ClassMaster_csm where 1 = 1 " + Environment.NewLine;

                if (info != null)
                {
                    if (info.csm_cGDMID != Guid.Empty)
                    {
                        strSql += " and csm_cGDMID = '" + info.csm_cGDMID.ToString() + "'" + Environment.NewLine;
                    }
                    if (info.csm_cMasterID != Guid.Empty)
                    {
                        strSql += " and csm_cMasterID = '" + info.csm_cMasterID.ToString() + "'" + Environment.NewLine;
                    }
                    if (!string.IsNullOrEmpty(info.csm_cClassName))
                    {
                        strSql += "and csm_cClassName like N'%" + info.csm_cClassName + "%'" + Environment.NewLine;
                    }
                    if (!string.IsNullOrEmpty(info.csm_cClassNum))
                    {
                        strSql += "and csm_cClassNum like '%" + info.csm_cClassNum + "%'" + Environment.NewLine;
                    }
                }

                IEnumerable<ClassMaster_csm_Info> infos = null;

                using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                {
                    infos = db.ExecuteQuery<ClassMaster_csm_Info>(strSql, new object[] { });
                    if (infos != null)
                    {
                        listReturn = infos.ToList();
                    }
                }
            }
            catch
            {
                throw;
            }

            return listReturn;
        }

        public List<ClassMaster_csm_Info> AllRecords()
        {
            List<ClassMaster_csm_Info> allRecords = null;

            try
            {
                using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                {
                    IEnumerable<ClassMaster_csm> allData = from t in db.ClassMaster_csm
                                                           orderby t.csm_dAddDate ascending
                                                           select t;

                    if (allData != null && allData.Count() > 0)
                    {
                        allRecords = new List<ClassMaster_csm_Info>();

                        foreach (ClassMaster_csm item in allData)
                        {
                            ClassMaster_csm_Info addInfo = Common.General.CopyObjectValue<ClassMaster_csm, ClassMaster_csm_Info>(item);

                            CardUserMaster_cus masterInfo = db.CardUserMaster_cus.FirstOrDefault(t => t.cus_cRecordID == addInfo.csm_cMasterID);

                            if (masterInfo != null)
                            {
                                addInfo.csm_cMasterName = masterInfo.cus_cChaName;
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

        /// <summary>
        /// 获得班级名称
        /// </summary>
        /// <param name="info"></param>
        private void GetClassName(ClassMaster_csm_Info info)
        {
            if (info != null)
            {
                try
                {
                    using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                    {
                        GradeMaster_gdm tagGrade = db.GradeMaster_gdm.FirstOrDefault(t => t.gdm_cRecordID == info.csm_cGDMID);

                        if (tagGrade != null)
                        {
                            info.csm_cClassName = tagGrade.gdm_cGradeName;
                            CodeMaster_cmt tagClass = db.CodeMaster_cmt.FirstOrDefault(t => t.cmt_cKey1 == Common.DefineConstantValue.CodeMasterDefine.KEY1_SIOT_CardUserClass && t.cmt_cKey2 == info.csm_cClassNum);
                            if (tagClass != null)
                            {
                                string strClassNum = tagClass.cmt_cValue;
                                /*B000001:Modify by Don 20150312*/
                                if (string.IsNullOrEmpty(strClassNum))
                                {
                                    strClassNum = string.Empty;
                                }
                                if (strClassNum.Length > 1)
                                {
                                    strClassNum = "(" + strClassNum.Substring(0, strClassNum.Length - 1) + ")" + strClassNum.Substring(strClassNum.Length - 1, 1);
                                }
                                /*B000001:EndModify Don 20150312*/
                                else
                                {
                                    strClassNum = "(" + strClassNum + ")";
                                }
                                info.csm_cClassName += strClassNum;
                            }
                        }

                    }
                }
                catch (Exception Ex)
                {

                    throw Ex;
                }
            }
        }

        #endregion
    }
}
