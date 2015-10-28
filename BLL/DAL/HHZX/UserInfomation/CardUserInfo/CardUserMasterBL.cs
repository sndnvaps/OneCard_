using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL.IBLL.HHZX.UserInfomation.CardUserInfo;
using Model.IModel;
using Model.General;
using DAL.IDAL.HHZX.UserInformation.CardUserInfo;
using DAL.Factory.HHZX;
using Model.HHZX.UserInfomation.CardUserInfo;
using DAL.IDAL.HHZX.UserCard;
using Model.HHZX.UserCard;
using DAL.IDAL.HHZX.UserInformation.UserCard;
using DAL.IDAL.HHZX.ConsumeAccount;
using Model.HHZX.ComsumeAccount;

namespace BLL.DAL.HHZX.UserInfomation.CardUserInfo
{
    public class CardUserMasterBL : ICardUserMasterBL
    {
        ICardUserMasterDA _cardUserMasterDA;
        IUserCardPairDA _IUserCardPairDA;
        IConsumeCardMasterDA _IConsumeCardMasterDA;
        IClassMasterDA _IClassMasterDA;
        IGradeMasterDA _IGradeMasterDA;
        ICardUserAccountDA _ICardUserAccountDA;
        IDepartmentMasterDA _IDepartmentMasterDA;

        public CardUserMasterBL()
        {
            this._cardUserMasterDA = MasterDAFactory.GetDAL<ICardUserMasterDA>(MasterDAFactory.CardUserMaster);
            this._IUserCardPairDA = MasterDAFactory.GetDAL<IUserCardPairDA>(MasterDAFactory.UserCardPair);
            this._IConsumeCardMasterDA = MasterDAFactory.GetDAL<IConsumeCardMasterDA>(MasterDAFactory.ConsumeCardMaster);
            this._IClassMasterDA = MasterDAFactory.GetDAL<IClassMasterDA>(MasterDAFactory.ClassMaster);
            this._IGradeMasterDA = MasterDAFactory.GetDAL<IGradeMasterDA>(MasterDAFactory.GradeMaster);
            this._ICardUserAccountDA = MasterDAFactory.GetDAL<ICardUserAccountDA>(MasterDAFactory.CardUserAccount);
            this._IDepartmentMasterDA = MasterDAFactory.GetDAL<IDepartmentMasterDA>(MasterDAFactory.DepartmentMaster);
        }

        public ReturnValueInfo BatchUpdateUserInfo(List<CardUserMaster_cus_Info> listUsers)
        {
            try
            {
                return this._cardUserMasterDA.BatchUpdateUserInfo(listUsers);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<CardUserMaster_cus_Info> AllRecords()
        {
            throw new NotImplementedException();
        }

        public CardUserMaster_cus_Info DisplayRecord(IModelObject itemEntity)
        {
            try
            {
                CardUserMaster_cus_Info userInfo = this._cardUserMasterDA.DisplayRecord(itemEntity);

                AddCardInfoToUser(userInfo);
                AddUserAccountInfo(userInfo);
                if (userInfo.cus_cIdentityNum == Common.DefineConstantValue.CodeMasterDefine.KEY2_SIOT_CardUserIdentity_Student)
                {
                    AddClassInfoToUser(userInfo);
                }
                else if (userInfo.cus_cIdentityNum == Common.DefineConstantValue.CodeMasterDefine.KEY2_SIOT_CardUserIdentity_Staff)
                {
                    AddDeptInfoToUser(userInfo);
                }

                return userInfo;
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }

        public List<CardUserMaster_cus_Info> SearchRecords(IModelObject itemEntity)
        {
            List<CardUserMaster_cus_Info> searchList = null;
            try
            {
                searchList = this._cardUserMasterDA.SearchRecords(itemEntity);

                if (searchList != null && searchList.Count > 0)
                {
                    foreach (CardUserMaster_cus_Info item in searchList)
                    {
                        AddCardInfoToUser(item);
                        AddUserAccountInfo(item);
                        if (item.cus_cIdentityNum == Common.DefineConstantValue.CodeMasterDefine.KEY2_SIOT_CardUserIdentity_Student)
                        {
                            AddClassInfoToUser(item);
                        }
                        else if (item.cus_cIdentityNum == Common.DefineConstantValue.CodeMasterDefine.KEY2_SIOT_CardUserIdentity_Staff)
                        {
                            AddDeptInfoToUser(item);
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

        public List<CardUserMaster_cus_Info> SearchRecord_ForMaster(CardUserMaster_cus_Info searchInfo)
        {
            List<CardUserMaster_cus_Info> searchList = null;
            try
            {
                searchList = this._cardUserMasterDA.SearchRecords(searchInfo);
            }
            catch (Exception Ex)
            {

                throw Ex;
            }

            return searchList;
        }

        public List<CardUserMaster_cus_Info> SearchRecordsWithCardInfo(IModelObject searchCondition)
        {
            try
            {
                return this._cardUserMasterDA.SearchRecordsWithCardInfo(searchCondition);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public ReturnValueInfo Save(IModelObject itemEntity, Common.DefineConstantValue.EditStateEnum EditMode)
        {
            ReturnValueInfo returnInfo = new ReturnValueInfo(false);

            CardUserMaster_cus_Info objInfo = itemEntity as CardUserMaster_cus_Info;

            try
            {
                switch (EditMode)
                {
                    case Common.DefineConstantValue.EditStateEnum.OE_Insert:

                        objInfo.cus_cRecordID = Guid.NewGuid();

                        objInfo.cus_dAddDate = DateTime.Now;

                        objInfo.cus_dLastDate = DateTime.Now;

                        returnInfo = this._cardUserMasterDA.InsertRecord(objInfo);

                        break;

                    case Common.DefineConstantValue.EditStateEnum.OE_Update:

                        objInfo.cus_dLastDate = DateTime.Now;

                        returnInfo = this._cardUserMasterDA.UpdateRecord(objInfo);

                        break;

                    case Common.DefineConstantValue.EditStateEnum.OE_Delete:

                        returnInfo = this._cardUserMasterDA.DeleteRecord(objInfo);

                        break;

                    default:

                        break;
                }
            }
            catch (Exception Ex)
            {

                returnInfo.messageText = Ex.Message;
            }

            return returnInfo;
        }

        public ReturnValueInfo UpdateStudentsInfo(List<CardUserMaster_cus_Info> students, Guid classID)
        {
            try
            {
                return this._cardUserMasterDA.UpdateStudentsInfo(students, classID);
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }

        /// <summary>
        /// 添加用户持有的卡信息
        /// </summary>
        /// <param name="userInfo"></param>
        void AddCardInfoToUser(CardUserMaster_cus_Info userInfo)
        {
            if (userInfo != null)
            {
                List<UserCardPair_ucp_Info> listPair = this._IUserCardPairDA.SearchRecords(new UserCardPair_ucp_Info() { ucp_cCUSID = userInfo.cus_cRecordID }).Where(x => x.ucp_lIsActive && x.ucp_cUseStatus != Common.DefineConstantValue.ConsumeCardStatus.Returned.ToString()).ToList();

                if (listPair != null && listPair.Count > 0)
                {
                    UserCardPair_ucp_Info pairInfo = listPair[0];

                    if (pairInfo != null)
                    {
                        userInfo.PairInfo = pairInfo;
                        userInfo.PairInfo.CardInfo = this._IConsumeCardMasterDA.DisplayRecord(new ConsumeCardMaster_ccm_Info() { ccm_cCardID = pairInfo.ucp_cCardID });
                    }
                }
            }
        }

        /// <summary>
        /// 添加用户的所在班级信息
        /// </summary>
        /// <param name="userInfo"></param>
        void AddClassInfoToUser(CardUserMaster_cus_Info userInfo)
        {
            if (userInfo != null)
            {
                ClassMaster_csm_Info classInfo = this._IClassMasterDA.DisplayRecord(new ClassMaster_csm_Info() { csm_cRecordID = userInfo.cus_cClassID });

                if (classInfo != null)
                {
                    userInfo.ClassInfo = classInfo;
                    userInfo.ClassName = classInfo.csm_cClassName;
                    GradeMaster_gdm_Info gradeInfo = this._IGradeMasterDA.DisplayRecord(new GradeMaster_gdm_Info() { gdm_cRecordID = classInfo.csm_cGDMID });
                    if (gradeInfo != null)
                    {
                        userInfo.ClassInfo.GradeInfo = gradeInfo;
                    }
                }

                if (userInfo.cus_lIsGraduate)
                {
                    userInfo.IsGraduate = "是";
                }
                else
                {
                    userInfo.IsGraduate = "否";
                }
            }
        }

        /// <summary>
        /// 添加用户的所在部门信息
        /// </summary>
        /// <param name="userInfo"></param>
        void AddDeptInfoToUser(CardUserMaster_cus_Info userInfo)
        {
            if (userInfo != null)
            {
                DepartmentMaster_dpm_Info deptInfo = this._IDepartmentMasterDA.DisplayRecord(new DepartmentMaster_dpm_Info() { dpm_RecordID = userInfo.cus_cClassID });

                if (deptInfo != null)
                {
                    userInfo.DeptInfo = deptInfo;
                    userInfo.ClassName = deptInfo.dpm_cName;
                }
            }
        }

        /// <summary>
        /// 添加用户的账户信息
        /// </summary>
        /// <param name="userInfo"></param>
        void AddUserAccountInfo(CardUserMaster_cus_Info userInfo)
        {
            if (userInfo != null)
            {
                CardUserAccount_cua_Info accountInfo = this._ICardUserAccountDA.SearchRecords(new CardUserAccount_cua_Info() { cua_cCUSID = userInfo.cus_cRecordID }).FirstOrDefault();

                if (accountInfo != null)
                {
                    userInfo.AccountInfo = accountInfo;
                }
            }
        }

        public List<CardUserMaster_cus_Info> GetClassInfo(Guid classID)
        {
            try
            {
                return this._cardUserMasterDA.GetClassInfo(classID);
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }

        public List<CardUserMaster_cus_Info> CheckForInportData(List<CardUserMaster_cus_Info> inportData)
        {
            try
            {
                return this._cardUserMasterDA.CheckForInportData(inportData);
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }

        /// <summary>
        /// 批量添加学生信息
        /// </summary>
        /// <param name="inportData"></param>
        /// <returns></returns>
        public ReturnValueInfo InportData(List<CardUserMaster_cus_Info> inportData)
        {
            try
            {
                foreach (CardUserMaster_cus_Info item in inportData)
                {
                    item.cus_cRecordID = Guid.NewGuid();

                    item.cus_dAddDate = DateTime.Now;

                    item.cus_dLastDate = DateTime.Now;
                }

                return this._cardUserMasterDA.InportData(inportData);
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }

        public ReturnValueInfo InportChangeClassData(List<ChangeClassRecord_ccr_Info> inportData)
        {
            try
            {
                return this._cardUserMasterDA.InportChangeClassData(inportData);
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }

        public List<CardUserMaster_cus_Info> GetClassStudents(ClassMaster_csm_Info classInfo)
        {
            try
            {
                return this._cardUserMasterDA.GetClassStudents(classInfo);
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }

        public string GetLastAutoUserCode(string strUserType)
        {
            try
            {
                return this._cardUserMasterDA.GetLastAutoUserCode(strUserType);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// 获取年级学生
        /// </summary>
        /// <param name="gradeID"></param>
        /// <returns></returns>
        public List<CardUserMaster_cus_Info> GetGradeStudents(Guid gradeID)
        {
            try
            {
                return this._cardUserMasterDA.GetGradeStudents(gradeID);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
