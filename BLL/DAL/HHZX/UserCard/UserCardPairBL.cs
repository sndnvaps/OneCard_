using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL.IBLL.HHZX.UserCard;
using DAL.IDAL.HHZX.UserCard;
using DAL.IDAL.HHZX.UserInformation.CardUserInfo;
using DAL.Factory.HHZX;
using DAL.IDAL.HHZX.UserInformation.UserCard;
using Model.HHZX.UserCard;
using Model.HHZX.UserInfomation.CardUserInfo;
using Model.IModel;
using Model.General;
using Common;
using Model.HHZX.Report;
using Model.HHZX.ComsumeAccount;
using DAL.IDAL.HHZX.ConsumeAccount;
using BLL.IBLL.HHZX.MealBooking;
using BLL.Factory.HHZX;

namespace BLL.DAL.HHZX.UserCard
{
    public class UserCardPairBL : IUserCardPairBL
    {
        private IUserCardPairDA _IUserCardPairDA;
        private ICardUserMasterDA _ICardUserMasterDA;
        private IConsumeCardMasterDA _IConsumeCardMasterDA;
        private IGradeMasterDA _IGradeMasterDA;
        private IClassMasterDA _IClassMasterDA;
        private IDepartmentMasterDA _IDepartmentMasterDA;
        private ICardUserAccountDA _ICardUserAccountDA;
        private IBlacklistChangeRecordBL _IBlacklistChangeRecordBL;

        public UserCardPairBL()
        {
            this._IUserCardPairDA = MasterDAFactory.GetDAL<IUserCardPairDA>(MasterDAFactory.UserCardPair);
            this._ICardUserMasterDA = MasterDAFactory.GetDAL<ICardUserMasterDA>(MasterDAFactory.CardUserMaster);
            this._IConsumeCardMasterDA = MasterDAFactory.GetDAL<IConsumeCardMasterDA>(MasterDAFactory.ConsumeCardMaster);
            this._IGradeMasterDA = MasterDAFactory.GetDAL<IGradeMasterDA>(MasterDAFactory.GradeMaster);
            this._IClassMasterDA = MasterDAFactory.GetDAL<IClassMasterDA>(MasterDAFactory.ClassMaster);
            this._ICardUserAccountDA = MasterDAFactory.GetDAL<ICardUserAccountDA>(MasterDAFactory.CardUserAccount);
            this._IDepartmentMasterDA = MasterDAFactory.GetDAL<IDepartmentMasterDA>(MasterDAFactory.DepartmentMaster);
            this._IBlacklistChangeRecordBL = MasterBLLFactory.GetBLL<IBlacklistChangeRecordBL>(MasterBLLFactory.BlacklistChangeRecord);
        }

        public List<UserCardPair_ucp_Info> GetUnusualCardList()
        {
            try
            {
                return this._IUserCardPairDA.GetUnusualCardList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<UserCardPair_ucp_Info> AllRecords()
        {
            try
            {
                List<UserCardPair_ucp_Info> listPairs = this._IUserCardPairDA.AllRecords();
                foreach (UserCardPair_ucp_Info item in listPairs)
                {
                    if (item != null)
                    {
                        AddCardMasterInfo(item);
                        AddUserMasterInfo(item);
                        AddUserAccountInfo(item);
                    }
                }
                return listPairs;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public UserCardPair_ucp_Info DisplayRecord(IModelObject itemEntity)
        {
            try
            {
                UserCardPair_ucp_Info pairInfo = null;

                UserCardPair_ucp_Info searchInfo = itemEntity as UserCardPair_ucp_Info;

                if (searchInfo == null)
                {
                    searchInfo = GetPairEntityCondiction(itemEntity);

                    if (searchInfo != null)
                    {
                        pairInfo = this._IUserCardPairDA.SearchRecords(searchInfo).FirstOrDefault();
                    }
                }
                else
                {
                    pairInfo = this._IUserCardPairDA.DisplayRecord(searchInfo);
                }

                //补充卡资料及用户资料
                if (pairInfo != null)
                {
                    AddCardMasterInfo(pairInfo);
                    AddUserMasterInfo(pairInfo);
                    AddUserAccountInfo(pairInfo);
                }

                return pairInfo;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<UserCardPair_ucp_Info> SearchRecords(IModelObject itemEntity)
        {
            try
            {
                UserCardPair_ucp_Info searchInfo = GetPairEntityCondiction(itemEntity);
                List<UserCardPair_ucp_Info> listPairInfo = this._IUserCardPairDA.SearchRecords(searchInfo);
                foreach (UserCardPair_ucp_Info item in listPairInfo)
                {
                    if (item != null)
                    {
                        AddCardMasterInfo(item);
                        AddUserMasterInfo(item);
                        AddUserAccountInfo(item);
                    }
                }
                return listPairInfo;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public ReturnValueInfo Save(IModelObject itemEntity, DefineConstantValue.EditStateEnum EditMode)
        {
            ReturnValueInfo rvInfo = new ReturnValueInfo();
            try
            {
                DefineConstantValue.CardUseState cardState = DefineConstantValue.CardUseState.NotUsed;

                UserCardPair_ucp_Info pairInfo = itemEntity as UserCardPair_ucp_Info;

                if (pairInfo == null)
                {
                    rvInfo.isError = true;
                    rvInfo.messageText = Common.DefineConstantValue.SystemMessageText.strMessageText_E_ObjectNull;
                    return rvInfo;
                }

                switch (EditMode)
                {
                    case DefineConstantValue.EditStateEnum.OE_Insert:
                        {
                            //如果无被发卡，则插入发卡记录
                            rvInfo = CheckPairDetail(pairInfo);
                            if (!rvInfo.boolValue || rvInfo.isError)
                            {
                                return rvInfo;
                            }

                            pairInfo.ucp_dPairTime = DateTime.Now;
                            pairInfo.ucp_dAddDate = pairInfo.ucp_dPairTime;
                            pairInfo.ucp_dLastDate = pairInfo.ucp_dPairTime;

                            rvInfo = this._IUserCardPairDA.InsertRecord(pairInfo);
                            cardState = DefineConstantValue.CardUseState.InUse;
                            break;
                        }
                    case DefineConstantValue.EditStateEnum.OE_Update:

                        pairInfo.ucp_dLastDate = DateTime.Now;

                        rvInfo = this._IUserCardPairDA.UpdateRecord(pairInfo);
                        cardState = DefineConstantValue.CardUseState.InUse;
                        break;
                    case DefineConstantValue.EditStateEnum.OE_Delete:

                        pairInfo.ucp_dLastDate = DateTime.Now;

                        rvInfo = this._IUserCardPairDA.DeleteRecord(pairInfo);
                        cardState = DefineConstantValue.CardUseState.NotUsed;
                        break;
                    default:
                        break;
                }

                rvInfo.ValueObject = this._IUserCardPairDA.DisplayRecord(pairInfo);

                if (rvInfo.boolValue && !rvInfo.isError)
                {
                    //检查本卡是否已经录入卡主档
                    ConsumeCardMaster_ccm_Info searchCardInfo = new ConsumeCardMaster_ccm_Info();
                    searchCardInfo.ccm_cCardID = pairInfo.ucp_cCardID;
                    ConsumeCardMaster_ccm_Info cardInfo = this._IConsumeCardMasterDA.DisplayRecord(searchCardInfo);

                    if (cardInfo == null)//查无此卡
                    {
                        cardInfo = new ConsumeCardMaster_ccm_Info();
                        cardInfo.ccm_cCardID = pairInfo.ucp_cCardID;
                        cardInfo.ccm_cCardState = cardState.ToString();
                        cardInfo.ccm_cAdd = pairInfo.ucp_cLast;
                        cardInfo.ccm_dAddDate = DateTime.Now;
                        cardInfo.ccm_dLastDate = cardInfo.ccm_dAddDate;
                        //将新卡录入卡主档
                        rvInfo = this._IConsumeCardMasterDA.InsertRecord(cardInfo);
                    }
                    else
                    {
                        if (EditMode != DefineConstantValue.EditStateEnum.OE_Delete)
                        {
                            if (cardInfo.ccm_cCardState != DefineConstantValue.CardUseState.InUse.ToString())
                            {
                                cardInfo.ccm_cCardState = DefineConstantValue.CardUseState.InUse.ToString();
                                rvInfo = this._IConsumeCardMasterDA.UpdateRecord(cardInfo);
                            }
                        }
                        else
                        {
                            if (cardInfo.ccm_cCardState != DefineConstantValue.CardUseState.NotUsed.ToString())
                            {
                                cardInfo.ccm_cCardState = DefineConstantValue.CardUseState.NotUsed.ToString();
                                rvInfo = this._IConsumeCardMasterDA.UpdateRecord(cardInfo);
                            }
                        }
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

        public ReturnValueInfo InsertNewCard(UserCardPair_ucp_Info infoObject, decimal dCost)
        {
            try
            {
                ReturnValueInfo rvInfo = this._IUserCardPairDA.InsertNewCard(infoObject, dCost);
                if (rvInfo.boolValue && !rvInfo.isError)
                {
                    UserCardPair_ucp_Info pairInfo = DisplayRecord(new UserCardPair_ucp_Info()
                    {
                        ucp_cRecordID = infoObject.ucp_cRecordID
                    });
                    this._IBlacklistChangeRecordBL.InsertUploadCardNo(pairInfo.ucp_iCardNo, DefineConstantValue.EnumCardUploadListOpt.AddWhiteList, DefineConstantValue.EnumCardUploadListReason.NewCard, infoObject.ucp_cLast);
                }
                return rvInfo;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public ReturnValueInfo InsertExchargeCard(UserCardPair_ucp_Info infoObject, decimal dCost)
        {
            try
            {
                return this._IUserCardPairDA.InsertExchargeCard(infoObject, dCost);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public ReturnValueInfo ReturnCard(UserCardPair_ucp_Info infoObject)
        {
            try
            {
                ReturnValueInfo rvInfo = this._IUserCardPairDA.ReturnCard(infoObject);
                if (rvInfo.boolValue && !rvInfo.isError)
                {
                    this._IBlacklistChangeRecordBL.InsertUploadCardNo(infoObject.ucp_iCardNo, DefineConstantValue.EnumCardUploadListOpt.RemoveWhiteList, DefineConstantValue.EnumCardUploadListReason.CardReturned, infoObject.ucp_cLast);
                }
                return rvInfo;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// 添加已发卡的卡信息
        /// </summary>
        /// <param name="pairInfo"></param>
        /// <returns></returns>
        bool AddCardMasterInfo(UserCardPair_ucp_Info pairInfo)
        {
            bool res = false;
            try
            {
                ConsumeCardMaster_ccm_Info searchInfo = new ConsumeCardMaster_ccm_Info();
                searchInfo.ccm_cCardID = pairInfo.ucp_cCardID;
                pairInfo.CardInfo = this._IConsumeCardMasterDA.DisplayRecord(searchInfo);
                if (pairInfo.CardOwner != null)
                    res = true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return res;
        }

        /// <summary>
        /// 添加已发卡的卡用户信息
        /// </summary>
        /// <param name="pairInfo"></param>
        /// <returns></returns>
        bool AddUserMasterInfo(UserCardPair_ucp_Info pairInfo)
        {
            bool res = false;
            try
            {
                if (pairInfo != null)
                {
                    CardUserMaster_cus_Info searchInfo = new CardUserMaster_cus_Info();
                    searchInfo.cus_cRecordID = pairInfo.ucp_cCUSID;
                    pairInfo.CardOwner = this._ICardUserMasterDA.DisplayRecord(searchInfo);
                    if (pairInfo.CardOwner != null)
                    {
                        AddClassInfoToUser(pairInfo.CardOwner);
                        res = true;
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return res;
        }

        /// <summary>
        /// 添加用户的所在班级信息
        /// </summary>
        /// <param name="userInfo"></param>
        void AddClassInfoToUser(CardUserMaster_cus_Info userInfo)
        {
            if (userInfo != null)
            {
                if (userInfo.cus_cIdentityNum == Common.DefineConstantValue.CodeMasterDefine.KEY2_SIOT_CardUserIdentity_Student)
                {
                    ClassMaster_csm_Info classInfo = this._IClassMasterDA.DisplayRecord(new ClassMaster_csm_Info() { csm_cRecordID = userInfo.cus_cClassID });
                    if (classInfo != null)
                    {
                        userInfo.ClassInfo = classInfo;

                        userInfo.ClassInfo = classInfo;
                        GradeMaster_gdm_Info gradeInfo = this._IGradeMasterDA.DisplayRecord(new GradeMaster_gdm_Info() { gdm_cRecordID = classInfo.csm_cGDMID });
                        if (gradeInfo != null)
                        {
                            userInfo.ClassInfo.GradeInfo = gradeInfo;
                        }
                    }
                }
                else if (userInfo.cus_cIdentityNum == Common.DefineConstantValue.CodeMasterDefine.KEY2_SIOT_CardUserIdentity_Staff)
                {
                    DepartmentMaster_dpm_Info deptInfo = this._IDepartmentMasterDA.DisplayRecord(new DepartmentMaster_dpm_Info() { dpm_RecordID = userInfo.cus_cClassID });
                    if (deptInfo != null)
                    {
                        userInfo.DeptInfo = deptInfo;
                    }
                }
            }
        }

        /// <summary>
        /// 添加用户的账户信息
        /// </summary>
        /// <param name="userInfo"></param>
        void AddUserAccountInfo(UserCardPair_ucp_Info pairInfo)
        {
            if (pairInfo != null && pairInfo.CardOwner != null)
            {
                CardUserAccount_cua_Info accountInfo = this._ICardUserAccountDA.SearchRecords(new CardUserAccount_cua_Info() { cua_cCUSID = pairInfo.ucp_cCUSID }).FirstOrDefault();

                if (accountInfo != null)
                {
                    pairInfo.CardOwner.AccountInfo = accountInfo;
                }
            }
        }

        /// <summary>
        /// 接受不同类型的条件参数
        /// </summary>
        /// <param name="itemEntity">参数可以为实体CardUserMaster_cus_Info、ConsumeCardMaster_ccm_Info</param>
        /// <returns></returns>
        UserCardPair_ucp_Info GetPairEntityCondiction(IModelObject itemEntity)
        {
            UserCardPair_ucp_Info searchInfo = itemEntity as UserCardPair_ucp_Info;
            if (searchInfo != null)
            {
                return searchInfo;
            }

            CardUserMaster_cus_Info userInfo = itemEntity as CardUserMaster_cus_Info;
            if (userInfo == null)
            {
                ConsumeCardMaster_ccm_Info cardInfo = itemEntity as ConsumeCardMaster_ccm_Info;
                if (cardInfo == null)
                {
                    return null;
                }
                else
                {
                    searchInfo = new UserCardPair_ucp_Info();
                    searchInfo.ucp_cCardID = cardInfo.ccm_cCardID;
                }
            }
            else
            {
                searchInfo = new UserCardPair_ucp_Info();
                searchInfo.ucp_cCUSID = userInfo.cus_cRecordID;
                //searchInfo.ucp_cUseStatus = DefineConstantValue.ConsumeCardStatus.Normal.ToString();
            }

            return searchInfo;
        }

        /// <summary>
        /// 检查是否已被发卡
        /// </summary>
        /// <param name="pairInfo"></param>
        /// <returns></returns>
        ReturnValueInfo CheckPairDetail(UserCardPair_ucp_Info pairInfo)
        {
            ReturnValueInfo rvInfo = new ReturnValueInfo();

            //以卡主档记录查询
            UserCardPair_ucp_Info searchInfo = new UserCardPair_ucp_Info();
            searchInfo.ucp_cCardID = pairInfo.ucp_cCardID;

            List<UserCardPair_ucp_Info> listPair = this._IUserCardPairDA.SearchRecords(searchInfo);
            listPair = listPair.Where(x => x.ucp_cUseStatus == DefineConstantValue.ConsumeCardStatus.Normal.ToString() || x.ucp_cUseStatus == DefineConstantValue.ConsumeCardStatus.LoseReporting.ToString() && x.ucp_lIsActive).ToList();

            if (listPair != null && listPair.Count > 0)
            {
                UserCardPair_ucp_Info pair = listPair[0];
                AddUserMasterInfo(pair);
                if (pair != null)
                {
                    rvInfo.isError = true;
                    if (pair.CardOwner != null)
                    {
                        rvInfo.messageText = "此卡已被发卡，持有人为：" + pair.CardOwner.cus_cChaName;
                    }
                    return rvInfo;
                }
            }
            else
            {
                //以用户主档记录查询
                searchInfo = new UserCardPair_ucp_Info();
                searchInfo.ucp_cCUSID = pairInfo.ucp_cCUSID;

                listPair = this._IUserCardPairDA.SearchRecords(searchInfo);
                listPair = listPair.Where(x => x.ucp_cUseStatus == DefineConstantValue.ConsumeCardStatus.Normal.ToString() || x.ucp_cUseStatus == DefineConstantValue.ConsumeCardStatus.LoseReporting.ToString() && x.ucp_lIsActive).ToList();

                if (listPair != null && listPair.Count > 0)
                {
                    UserCardPair_ucp_Info pair = listPair[0];

                    if (pair != null)
                    {
                        rvInfo.isError = true;
                        rvInfo.messageText = "此用户已被发卡，持有卡号：" + pair.ucp_iCardNo.ToString();
                        return rvInfo;
                    }
                }
            }

            rvInfo.boolValue = true;
            return rvInfo;
        }

        #region IUserCardPairBL Members

        /// <summary>
        /// 取得换卡信息列表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public List<ChangeCardDetail_ccd_Info> GetChangeCardDetail(ChangeCardDetail_ccd_Info query)
        {
            try
            {
                return this._IUserCardPairDA.GetChangeCardDetail(query);
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }

        #endregion

        #region IUserCardPairBL Members

        /// <summary>
        /// 取得开户信息列表
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="classID"></param>
        /// <returns></returns>
        public List<CardUserAccount_cua_Info> GetAccoumtEstablishInfo(DateTime startDate, DateTime endDate, Guid classID, string studentID)
        {
            try
            {
                return this._IUserCardPairDA.GetAccoumtEstablishInfo(startDate, endDate, classID, studentID);
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }

        #endregion

        /// <summary>
        /// 获取长期黑名单的卡号列表
        /// </summary>
        public List<int> GetContinuedBalckListCardNoList()
        {
            try
            {
                return this._IUserCardPairDA.GetContinuedBalckListCardNoList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
