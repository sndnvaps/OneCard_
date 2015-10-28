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
    public class CardUserMasterDA : ICardUserMasterDA
    {
        #region IMainGeneralDA<CardUserMaster_cus_Info> Members

        public ReturnValueInfo InsertRecord(CardUserMaster_cus_Info infoObject)
        {
            ReturnValueInfo returnInfo = new ReturnValueInfo(false);

            if (infoObject != null)
            {
                try
                {
                    using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                    {
                        CardUserMaster_cus insertData = Common.General.CopyObjectValue<CardUserMaster_cus_Info, CardUserMaster_cus>(infoObject);

                        db.CardUserMaster_cus.InsertOnSubmit(insertData);

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

        public ReturnValueInfo UpdateRecord(CardUserMaster_cus_Info infoObject)
        {
            ReturnValueInfo returnInfo = new ReturnValueInfo(false);

            if (infoObject != null)
            {
                try
                {
                    using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                    {
                        CardUserMaster_cus updateData = db.CardUserMaster_cus.FirstOrDefault(t => t.cus_cRecordID == infoObject.cus_cRecordID);

                        if (updateData != null)
                        {
                            updateData.cus_cChaName = infoObject.cus_cChaName;
                            updateData.cus_cComeYear = infoObject.cus_cComeYear;
                            updateData.cus_cGraduationPeriod = infoObject.cus_cGraduationPeriod;
                            updateData.cus_cStudentID = infoObject.cus_cStudentID;
                            updateData.cus_cClassID = infoObject.cus_cClassID;
                            updateData.cus_cSexNum = infoObject.cus_cSexNum;
                            updateData.cus_cIdentityNum = infoObject.cus_cIdentityNum;
                            updateData.cus_cContractPhone = infoObject.cus_cContractPhone;
                            updateData.cus_cContractName = infoObject.cus_cContractName;
                            updateData.cus_lValid = infoObject.cus_lValid;
                            updateData.cus_lIsGraduate = infoObject.cus_lIsGraduate;
                            updateData.cus_cRemark = infoObject.cus_cRemark;
                            updateData.cus_cLast = infoObject.cus_cLast;
                            updateData.cus_dLastDate = infoObject.cus_dLastDate;
                            updateData.cus_cBankAccount = infoObject.cus_cBankAccount;

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

            CardUserMaster_cus_Info deleteInfo = KeyObject as CardUserMaster_cus_Info;

            if (deleteInfo != null)
            {
                try
                {
                    using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                    {
                        CardUserMaster_cus deleteData = db.CardUserMaster_cus.FirstOrDefault(t => t.cus_cRecordID == deleteInfo.cus_cRecordID);

                        if (deleteData != null)
                        {
                            deleteData.cus_lValid = false;

                            db.SubmitChanges();

                            returnInfo.boolValue = true;

                            returnInfo.ValueObject = deleteInfo;
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
                returnInfo.messageText = Common.DefineConstantValue.SystemMessageText.strMessageText_E_ObjectNull;
            }

            return returnInfo;
        }

        public CardUserMaster_cus_Info DisplayRecord(IModelObject KeyObject)
        {
            CardUserMaster_cus_Info displayInfo = KeyObject as CardUserMaster_cus_Info;

            if (displayInfo != null)
            {
                try
                {
                    using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                    {
                        CardUserMaster_cus displayData = db.CardUserMaster_cus.FirstOrDefault(t => t.cus_cRecordID == displayInfo.cus_cRecordID);

                        if (displayData != null)
                        {
                            displayInfo = Common.General.CopyObjectValue<CardUserMaster_cus, CardUserMaster_cus_Info>(displayData);
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

        public List<CardUserMaster_cus_Info> SearchRecords(IModelObject searchCondition)
        {
            List<CardUserMaster_cus_Info> infoList = new List<CardUserMaster_cus_Info>();

            IEnumerable<CardUserMaster_cus_Info> infos = null;

            CardUserMaster_cus_Info queryInfo = searchCondition as CardUserMaster_cus_Info;

            string strSQL = string.Empty;

            strSQL += "select * ,csm_cClassName as ClassName,dpm_cName as DepartmentName" + Environment.NewLine;

            strSQL += ",(case cus_lIsGraduate when 1 then N'是' when 0 then N'否' end) as IsGraduate" + Environment.NewLine;

            strSQL += ",(case cus_cSexNum when 'MALE' then N'男' when 'FEMALE' then N'女' end) as SexName" + Environment.NewLine;

            strSQL += "from dbo.CardUserMaster_cus left join dbo.ClassMaster_csm on cus_cClassID=csm_cRecordID" + Environment.NewLine;

            strSQL += "left join DepartmentMaster_dpm on cus_cClassID=dpm_RecordID" + Environment.NewLine;

            strSQL += "where 1=1" + Environment.NewLine;

            if (queryInfo.cus_cRecordID != Guid.Empty)
            {
                strSQL += "and cus_cRecordID='" + queryInfo.cus_cRecordID.ToString() + "'" + Environment.NewLine;
            }

            if (!string.IsNullOrEmpty(queryInfo.cus_cChaName))
            {
                strSQL += "and cus_cChaName like N'%" + queryInfo.cus_cChaName + "%'" + Environment.NewLine;
            }

            if (!string.IsNullOrEmpty(queryInfo.cus_cStudentID))
            {
                strSQL += "and cus_cStudentID like '%" + queryInfo.cus_cStudentID + "%'" + Environment.NewLine;
            }

            if (!string.IsNullOrEmpty(queryInfo.cus_cSexNum))
            {
                strSQL += "and cus_cSexNum='" + queryInfo.cus_cSexNum + "'" + Environment.NewLine;
            }

            if (!string.IsNullOrEmpty(queryInfo.cus_cIdentityNum))
            {
                strSQL += "and cus_cIdentityNum='" + queryInfo.cus_cIdentityNum + "'" + Environment.NewLine;
            }

            if (!string.IsNullOrEmpty(queryInfo.cus_cContractPhone))
            {
                strSQL += "and cus_cContractPhone like '%" + queryInfo.cus_cContractPhone + "%'" + Environment.NewLine;
            }

            if (!string.IsNullOrEmpty(queryInfo.cus_cContractName))
            {
                strSQL += "and cus_cContractName like N'%" + queryInfo.cus_cContractName + "%'" + Environment.NewLine;
            }

            strSQL += "and cus_lValid=" + Convert.ToInt32(queryInfo.cus_lValid) + " " + Environment.NewLine;


            strSQL += "and cus_lIsGraduate=" + Convert.ToInt32(queryInfo.cus_lIsGraduate) + " " + Environment.NewLine;


            if (!string.IsNullOrEmpty(queryInfo.cus_cRemark))
            {
                strSQL += "and cus_cRemark like N'%" + queryInfo.cus_cRemark + "%'" + Environment.NewLine;
            }

            if (queryInfo.cus_cClassID != Guid.Empty)
            {
                strSQL += "and cus_cClassID='" + queryInfo.cus_cClassID.ToString() + "'";
            }

            try
            {
                using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                {

                    infos = db.ExecuteQuery<CardUserMaster_cus_Info>(strSQL, new object[] { });

                    if (infos != null)
                    {
                        infoList = infos.ToList<CardUserMaster_cus_Info>();
                    }

                }
            }
            catch (Exception Ex)
            {

                throw Ex;
            }

            return infoList;
        }

        public List<CardUserMaster_cus_Info> SearchRecordsWithCardInfo(IModelObject searchCondition)
        {
            List<CardUserMaster_cus_Info> infoList = new List<CardUserMaster_cus_Info>();

            IEnumerable<CardUserMaster_cus_Info> infos = null;

            CardUserMaster_cus_Info queryInfo = searchCondition as CardUserMaster_cus_Info;

            string strSQL = string.Empty;

            strSQL += @"select * ,( case cus_cIdentityNum 
  when 'STUDENT' then csm_cClassName
  when 'STAFF' then dpm_cName
  end
  ) as ClassName" + Environment.NewLine;
            strSQL += ",ucp_iCardNo as PairCardNo,ucp_dPairTime as PairCardTime,ucp_cCardID as	PairCardID	" + Environment.NewLine;
            strSQL += ",(case cus_lIsGraduate when 1 then N'是' when 0 then N'否' end) as IsGraduate" + Environment.NewLine;
            strSQL += ",(case cus_cSexNum when 'MALE' then N'男' when 'FEMALE' then N'女' end) as SexName" + Environment.NewLine;
            strSQL += ",cua_cRecordID as AccountID" + Environment.NewLine;
            strSQL += "from dbo.CardUserMaster_cus" + Environment.NewLine;
            strSQL += " left join UserCardPair_ucp on ucp_cCUSID = cus_cRecordID and ucp_cUseStatus <> 'Returned' and ucp_lIsActive = 1" + Environment.NewLine;
            strSQL += " left join dbo.ClassMaster_csm on cus_cClassID=csm_cRecordID" + Environment.NewLine;
            strSQL += " left join DepartmentMaster_dpm on cus_cClassID=dpm_RecordID" + Environment.NewLine;
            strSQL += " left join CardUserAccount_cua on cua_cCUSID=cus_cRecordID" + Environment.NewLine;
            strSQL += "where 1=1" + Environment.NewLine;

            if (queryInfo.cus_cRecordID != Guid.Empty)
            {
                strSQL += "and cus_cRecordID='" + queryInfo.cus_cRecordID.ToString() + "'" + Environment.NewLine;
            }

            if (!string.IsNullOrEmpty(queryInfo.cus_cChaName))
            {
                strSQL += "and cus_cChaName like N'%" + queryInfo.cus_cChaName + "%'" + Environment.NewLine;
            }

            if (!string.IsNullOrEmpty(queryInfo.cus_cStudentID))
            {
                strSQL += "and cus_cStudentID like '%" + queryInfo.cus_cStudentID + "%'" + Environment.NewLine;
            }

            if (!string.IsNullOrEmpty(queryInfo.cus_cSexNum))
            {
                strSQL += "and cus_cSexNum='" + queryInfo.cus_cSexNum + "'" + Environment.NewLine;
            }

            if (!string.IsNullOrEmpty(queryInfo.cus_cIdentityNum))
            {
                strSQL += "and cus_cIdentityNum='" + queryInfo.cus_cIdentityNum + "'" + Environment.NewLine;
            }

            if (!string.IsNullOrEmpty(queryInfo.cus_cContractPhone))
            {
                strSQL += "and cus_cContractPhone like '%" + queryInfo.cus_cContractPhone + "%'" + Environment.NewLine;
            }

            if (!string.IsNullOrEmpty(queryInfo.cus_cContractName))
            {
                strSQL += "and cus_cContractName like N'%" + queryInfo.cus_cContractName + "%'" + Environment.NewLine;
            }

            strSQL += "and cus_lValid=" + Convert.ToInt32(queryInfo.cus_lValid) + " " + Environment.NewLine;


            strSQL += "and cus_lIsGraduate=" + Convert.ToInt32(queryInfo.cus_lIsGraduate) + " " + Environment.NewLine;


            if (!string.IsNullOrEmpty(queryInfo.cus_cRemark))
            {
                strSQL += "and cus_cRemark like N'%" + queryInfo.cus_cRemark + "%'" + Environment.NewLine;
            }

            if (queryInfo.cus_cClassID != Guid.Empty)
            {
                strSQL += "and cus_cClassID='" + queryInfo.cus_cClassID.ToString() + "'" + Environment.NewLine;
            }

            if (queryInfo.PairCardNo != null)
            {
                strSQL += "and ucp_iCardNo =" + queryInfo.PairCardNo.ToString() + Environment.NewLine;
            }

            try
            {
                using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                {

                    infos = db.ExecuteQuery<CardUserMaster_cus_Info>(strSQL, new object[] { });

                    if (infos != null)
                    {
                        infoList = infos.ToList<CardUserMaster_cus_Info>();
                    }

                }
            }
            catch (Exception Ex)
            {

                throw Ex;
            }

            return infoList;
        }

        public List<CardUserMaster_cus_Info> AllRecords()
        {
            throw new NotImplementedException();
        }

        public ReturnValueInfo UpdateStudentsInfo(List<CardUserMaster_cus_Info> students, Guid classID)
        {
            ReturnValueInfo returnInfo = new ReturnValueInfo(false);

            if (students != null && students.Count > 0)
            {

                try
                {
                    using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                    {
                        db.Connection.Open();

                        db.Transaction = db.Connection.BeginTransaction();

                        try
                        {
                            foreach (CardUserMaster_cus_Info item in students)
                            {
                                CardUserMaster_cus tab = db.CardUserMaster_cus.FirstOrDefault(t => t.cus_cRecordID == item.cus_cRecordID);

                                if (tab != null)
                                {
                                    tab.cus_cClassID = classID;

                                    db.SubmitChanges();
                                }
                            }

                            db.Transaction.Commit();

                            returnInfo.boolValue = true;

                        }
                        catch (Exception Ex)
                        {

                            db.Transaction.Rollback();

                            returnInfo.messageText = Ex.Message;
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

        public List<CardUserMaster_cus_Info> GetClassInfo(Guid classID)
        {
            List<CardUserMaster_cus_Info> classInfo = null;

            try
            {
                using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                {
                    IEnumerable<CardUserMaster_cus> allStudents = from t in db.CardUserMaster_cus
                                                                  where t.cus_cClassID == classID && t.cus_lValid == true
                                                                  orderby t.cus_cStudentID ascending
                                                                  select t;

                    if (allStudents != null && allStudents.Count() > 0)
                    {
                        classInfo = new List<CardUserMaster_cus_Info>();

                        foreach (CardUserMaster_cus item in allStudents)
                        {
                            CardUserMaster_cus_Info studentInfo = Common.General.CopyObjectValue<CardUserMaster_cus, CardUserMaster_cus_Info>(item);

                            classInfo.Add(studentInfo);
                        }
                    }


                }
            }
            catch (Exception Ex)
            {

                throw Ex;
            }


            return classInfo;
        }

        public List<CardUserMaster_cus_Info> CheckForInportData(List<CardUserMaster_cus_Info> inportData)
        {


            if (inportData != null && inportData.Count > 0)
            {
                try
                {
                    using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                    {
                        foreach (CardUserMaster_cus_Info student in inportData)
                        {
                            CardUserMaster_cus checkStudentID = db.CardUserMaster_cus.FirstOrDefault(t => t.cus_cStudentID == student.cus_cStudentID);

                            if (checkStudentID != null)
                            {
                                student.CheckString += "学号重复;";
                            }

                            CodeMaster_cmt checkSex = db.CodeMaster_cmt.FirstOrDefault(t => t.cmt_cKey1 == Common.DefineConstantValue.CodeMasterDefine.KEY1_SIOT_CardUserSex && t.cmt_cValue == student.SexName);

                            if (checkSex != null)
                            {
                                student.cus_cSexNum = checkSex.cmt_cKey2;
                            }
                            else
                            {
                                student.CheckString += "性别输入有误;";
                            }

                            ClassMaster_csm checkClass = db.ClassMaster_csm.FirstOrDefault(t => t.csm_cClassName == student.ClassName);

                            if (checkClass != null)
                            {
                                student.cus_cClassID = checkClass.csm_cRecordID;
                            }
                            else
                            {
                                student.CheckString += "班级输入有误;";
                            }
                        }
                    }
                }
                catch (Exception Ex)
                {

                    throw Ex;
                }
            }

            return inportData;
        }

        public ReturnValueInfo InportData(List<CardUserMaster_cus_Info> inportData)
        {
            ReturnValueInfo returnInfo = new ReturnValueInfo(false);

            if (inportData != null && inportData.Count > 0)
            {
                try
                {
                    using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                    {
                        db.Connection.Open();

                        db.Transaction = db.Connection.BeginTransaction();

                        foreach (CardUserMaster_cus_Info student in inportData)
                        {
                            CardUserMaster_cus saveData = Common.General.CopyObjectValue<CardUserMaster_cus_Info, CardUserMaster_cus>(student);

                            db.CardUserMaster_cus.InsertOnSubmit(saveData);
                        }

                        try
                        {
                            db.SubmitChanges();

                            db.Transaction.Commit();

                            db.Connection.Close();

                            returnInfo.boolValue = true;

                        }
                        catch (Exception Ex)
                        {
                            db.Transaction.Rollback();

                            db.Connection.Close();

                            returnInfo.messageText = Ex.Message;
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

        public ReturnValueInfo InportChangeClassData(List<ChangeClassRecord_ccr_Info> inportData)
        {
            ReturnValueInfo returnInfo = new ReturnValueInfo(false);

            if (inportData != null && inportData.Count > 0)
            {
                try
                {
                    using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                    {
                        db.Connection.Open();

                        db.Transaction = db.Connection.BeginTransaction();

                        IEnumerable<ClassMaster_csm> classInfo = from t in db.ClassMaster_csm
                                                                 select t;

                        if (classInfo != null && classInfo.Count() > 0)
                        {
                            foreach (ChangeClassRecord_ccr_Info item in inportData)
                            {
                                ClassMaster_csm userClass = classInfo.FirstOrDefault(t => t.csm_cClassName == item.ccr_cClassName);

                                if (userClass != null)
                                {
                                    item.ccr_cClassID = userClass.csm_cRecordID;
                                }

                                CardUserMaster_cus student = db.CardUserMaster_cus.FirstOrDefault(t => t.cus_cRecordID == item.ccr_cCardUserMasterID);

                                if (student != null)
                                {
                                    #region 插入旧班记录
                                    IEnumerable<ChangeClassRecord_ccr> checkOldRecord = from t in db.ChangeClassRecord_ccr
                                                                                        where t.ccr_cCardUserMasterID == student.cus_cRecordID && t.ccr_cClassID == student.cus_cClassID
                                                                                        select t;

                                    if (checkOldRecord != null && checkOldRecord.Count() > 0)
                                    {

                                    }
                                    else
                                    {
                                        ChangeClassRecord_ccr inserChangeClassRecord = new ChangeClassRecord_ccr();

                                        inserChangeClassRecord.ccr_cCardUserMasterID = student.cus_cRecordID;

                                        inserChangeClassRecord.ccr_cClassID = student.cus_cClassID.Value;

                                        inserChangeClassRecord.ccr_cStudentID = student.cus_cStudentID;

                                        inserChangeClassRecord.ccr_dAddDate = DateTime.Now;

                                        ClassMaster_csm tempClass = db.ClassMaster_csm.FirstOrDefault(t => t.csm_cRecordID == inserChangeClassRecord.ccr_cClassID);

                                        if (tempClass != null)
                                        {
                                            inserChangeClassRecord.ccr_cMasterID = tempClass.csm_cMasterID.Value;

                                            db.ChangeClassRecord_ccr.InsertOnSubmit(inserChangeClassRecord);

                                            db.SubmitChanges();

                                        }

                                    }
                                    #endregion

                                    #region 插入转班记录
                                    ChangeClassRecord_ccr newClassRecord = new ChangeClassRecord_ccr();

                                    newClassRecord.ccr_cCardUserMasterID = student.cus_cRecordID;

                                    newClassRecord.ccr_cClassID = item.ccr_cClassID;

                                    ClassMaster_csm tempMaster = db.ClassMaster_csm.FirstOrDefault(t => t.csm_cRecordID == item.ccr_cClassID);

                                    if (tempMaster != null)
                                    {
                                        newClassRecord.ccr_cMasterID = tempMaster.csm_cMasterID.Value;
                                    }

                                    newClassRecord.ccr_cStudentID = item.ccr_cStudentID;

                                    newClassRecord.ccr_dAddDate = DateTime.Now;

                                    db.ChangeClassRecord_ccr.InsertOnSubmit(newClassRecord);

                                    db.SubmitChanges();

                                    #endregion

                                    student.cus_cClassID = item.ccr_cClassID;

                                    student.cus_cStudentID = item.ccr_cStudentID;

                                    db.SubmitChanges();
                                }
                            }

                            try
                            {

                                db.Transaction.Commit();
                                db.Connection.Close();

                                returnInfo.boolValue = true;
                            }
                            catch (Exception Ex)
                            {
                                db.Transaction.Rollback();
                                db.Connection.Close();

                                returnInfo.messageText = Ex.Message;
                            }
                        }
                    }
                }
                catch (Exception Ex)
                {
                    returnInfo.isError = true;
                    returnInfo.messageText = Ex.Message;
                }
            }

            return returnInfo;
        }

        public List<CardUserMaster_cus_Info> GetClassStudents(ClassMaster_csm_Info classInfo)
        {
            List<CardUserMaster_cus_Info> returnList = new List<CardUserMaster_cus_Info>();

            if (classInfo != null)
            {
                try
                {
                    using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                    {
                        IEnumerable<CardUserMaster_cus> students = from t in db.CardUserMaster_cus
                                                                   where (classInfo.csm_cRecordID == Guid.Empty || t.cus_cClassID == classInfo.csm_cRecordID) && t.cus_lValid == true
                                                                   select t;

                        if (students != null && students.Count() > 0)
                        {
                            foreach (CardUserMaster_cus item in students)
                            {
                                CardUserMaster_cus_Info info = new CardUserMaster_cus_Info();

                                info = Common.General.CopyObjectValue<CardUserMaster_cus, CardUserMaster_cus_Info>(item);

                                returnList.Add(info);
                            }
                        }
                    }
                }
                catch (Exception Ex)
                {

                    throw Ex;
                }
            }

            return returnList;
        }

        public ReturnValueInfo BatchUpdateUserInfo(List<CardUserMaster_cus_Info> listUsers)
        {
            ReturnValueInfo rvInfo = new ReturnValueInfo();
            try
            {
                if (listUsers == null || (listUsers != null && listUsers.Count < 1))
                {
                    rvInfo.messageText = Common.DefineConstantValue.SystemMessageText.strMessageText_E_ObjectNull;
                    rvInfo.isError = true;
                    return rvInfo;
                }

                List<CardUserMaster_cus> listUpdateUsers = new List<CardUserMaster_cus>();
                using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                {
                    db.Connection.Open();
                    db.Transaction = db.Connection.BeginTransaction();
                    try
                    {
                        foreach (CardUserMaster_cus_Info userInfo in listUsers)
                        {
                            CardUserMaster_cus user = db.CardUserMaster_cus.Where(x => x.cus_cRecordID == userInfo.cus_cRecordID).FirstOrDefault();
                            if (user != null)
                            {
                                user.cus_cChaName = userInfo.cus_cChaName;
                                user.cus_cClassID = userInfo.cus_cClassID;
                                user.cus_cComeYear = userInfo.cus_cComeYear;
                                user.cus_cContractName = userInfo.cus_cContractName;
                                user.cus_cContractPhone = userInfo.cus_cContractPhone;
                                user.cus_cGraduationPeriod = userInfo.cus_cGraduationPeriod;
                                user.cus_cIdentityNum = userInfo.cus_cIdentityNum;
                                user.cus_cLast = userInfo.cus_cLast;
                                user.cus_cRemark = userInfo.cus_cRemark;
                                user.cus_cSexNum = userInfo.cus_cSexNum;
                                user.cus_cStudentID = userInfo.cus_cStudentID;
                                user.cus_dLastDate = userInfo.cus_dLastDate;
                                user.cus_lIsGraduate = userInfo.cus_lIsGraduate;
                                user.cus_lValid = userInfo.cus_lValid;
                                user.cus_cBankAccount = userInfo.cus_cBankAccount;

                                listUpdateUsers.Add(user);
                            }
                        }

                        db.SubmitChanges();
                        db.Transaction.Commit();
                        db.Connection.Close();
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
            catch (Exception ex)
            {
                rvInfo.isError = true;
                rvInfo.messageText = ex.Message;
            }
            return rvInfo;
        }

        public string GetLastAutoUserCode(string strUserType)
        {
            string strCode = string.Empty;
            string strCondiction = string.Empty;
            try
            {
                if (strUserType == Common.DefineConstantValue.CodeMasterDefine.KEY2_SIOT_CardUserIdentity_Student)
                {
                    strCondiction = Common.DefineConstantValue.UserAutoCode_Student;
                }
                else if (strUserType == Common.DefineConstantValue.CodeMasterDefine.KEY2_SIOT_CardUserIdentity_Staff)
                {
                    strCondiction = Common.DefineConstantValue.USerAutoCode_Teacher;
                }
                else
                {
                    return strCode;
                }

                StringBuilder sbSQL = new StringBuilder();
                sbSQL.AppendLine("SELECT TOP 1 * FROM CardUserMaster_cus");
                sbSQL.AppendLine("WHERE cus_cStudentID LIKE'" + strCondiction + "%'");
                sbSQL.AppendLine("order by cus_cStudentID desc");
                using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                {
                    List<CardUserMaster_cus_Info> listRes = db.ExecuteQuery<CardUserMaster_cus_Info>(sbSQL.ToString(), new object[] { }).ToList();
                    if (listRes != null && listRes.Count > 0)
                    {
                        strCode = listRes[0].cus_cStudentID;
                        if (strCode.Length > 3)
                        {
                            string strPartPre = strCode.Substring(0, 3);
                            string strPartAfter = strCode.Substring(3, strCode.Length - 3);
                            int iCodeNum = int.Parse(strPartAfter);
                            strCode = strPartPre + (iCodeNum + 1).ToString().PadLeft(8, '0');
                        }
                    }
                    else
                    {
                        strCode = strCondiction + "1".PadLeft(8, '0');
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return strCode;
        }

        public List<CardUserMaster_cus_Info> GetGradeStudents(Guid gradeID)
        {
            List<CardUserMaster_cus_Info> returnList = new List<CardUserMaster_cus_Info>();
            try
            {
                StringBuilder sbSQL = new StringBuilder();
                sbSQL.AppendLine("select * from dbo.CardUserMaster_cus ");
                sbSQL.AppendLine("join dbo.ClassMaster_csm on cus_cClassID = csm_cRecordID ");
                sbSQL.AppendLine("where csm_cGDMID='" + gradeID.ToString() + "' ");
                sbSQL.AppendLine("order by csm_cRecordID ");

                using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                {
                    IEnumerable<CardUserMaster_cus_Info> query = db.ExecuteQuery<CardUserMaster_cus_Info>(sbSQL.ToString(), new object[] { });
                    if (query != null)
                    {
                        returnList = query.ToList<CardUserMaster_cus_Info>();
                    }
                }
            }
            catch
            {

            }
            return returnList;
        }

        #endregion
    }
}
