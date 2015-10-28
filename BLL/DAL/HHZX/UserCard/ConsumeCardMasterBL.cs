using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL.IBLL.HHZX.UserInfomation.UserCard;
using DAL.IDAL.HHZX.UserInformation.CardUserInfo;
using DAL.IDAL.HHZX.UserCard;
using DAL.Factory.HHZX;
using Model.HHZX.UserCard;
using DAL.IDAL.HHZX.UserInformation.UserCard;
using Model.HHZX.UserInfomation.CardUserInfo;
using Common;
using BLL.IBLL.HHZX.UserCard;
using BLL.Factory.HHZX;

namespace BLL.DAL.HHZX.UserCard
{
    public class ConsumeCardMasterBL : IConsumeCardMasterBL
    {
        private ICardUserMasterDA _icumDA;
        private IUserCardPairDA _iucpDA;
        private IConsumeCardMasterDA _iccmDA;

        private IUserCardPairBL _iucpBL;

        public ConsumeCardMasterBL()
        {
            _icumDA = MasterDAFactory.GetDAL<ICardUserMasterDA>(MasterDAFactory.CardUserMaster);
            _iucpDA = MasterDAFactory.GetDAL<IUserCardPairDA>(MasterDAFactory.UserCardPair);
            _iccmDA = MasterDAFactory.GetDAL<IConsumeCardMasterDA>(MasterDAFactory.ConsumeCardMaster);

            _iucpBL = MasterBLLFactory.GetBLL<IUserCardPairBL>(MasterBLLFactory.UserCardPair);
        }

        #region IMainGeneralBL 成员

        public List<Model.IModel.IModelObject> AllRecords()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IMainBL 成员

        public Model.IModel.IModelObject DisplayRecord(Model.IModel.IModelObject itemEntity)
        {
            return _iccmDA.DisplayRecord(itemEntity);
        }

        public Model.General.ReturnValueInfo Save(Model.IModel.IModelObject itemEntity, Common.DefineConstantValue.EditStateEnum EditMode)
        {
            ConsumeCardMaster_ccm_Info info = itemEntity as ConsumeCardMaster_ccm_Info;

            switch (EditMode)
            {
                case DefineConstantValue.EditStateEnum.OE_Insert:
                    info.ccm_dAddDate = System.DateTime.Now;
                    info.ccm_dLastDate = System.DateTime.Now;
                    return _iccmDA.InsertRecord(info);
                case DefineConstantValue.EditStateEnum.OE_Update:
                    info.ccm_dLastDate = System.DateTime.Now;
                    return _iccmDA.UpdateRecord(info);
            }

            return _iccmDA.InsertRecord(info);
        }

        #endregion

        #region IConsumeCardMasterBL 成员


        public Model.General.ReturnValueInfo SaveRecord(Model.IModel.IModelObject saveInfo)
        {
            ConsumeCardMaster_ccm_Info info = saveInfo as ConsumeCardMaster_ccm_Info;
            return _iccmDA.InsertRecord(info);
        }

        #endregion

        #region IMainBL 成员


        List<Model.IModel.IModelObject> BLL.IBLL.IMainBL.SearchRecords(Model.IModel.IModelObject itemEntity)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IConsumeCardMasterBL 成员

        List<ConsumeCardMaster_ccm_Info> IConsumeCardMasterBL.SearchRecords(Model.IModel.IModelObject searchCondition)
        {
            List<ConsumeCardMaster_ccm_Info> infoList = _iccmDA.SearchRecords(searchCondition);



            return infoList;
        }

        #endregion

        #region IConsumeCardMasterBL 成员


        public List<ConsumeCardMaster_ccm_Info> SearchDisplayRecords(UserCardPair_ucp_Info searchInfo)
        {
            List<ConsumeCardMaster_ccm_Info> infoList = new List<ConsumeCardMaster_ccm_Info>();

            UserCardPair_ucp_Info ucpInfo;
            CardUserMaster_cus_Info cusInfo;
            ConsumeCardMaster_ccm_Info ccmInfo;

            if (searchInfo.ucp_iCardNo > 0 || !String.IsNullOrEmpty(searchInfo.ucp_cCardID))
            {
                //searchInfo.ucp_cUseStatus = "Normal";

                ccmInfo = new ConsumeCardMaster_ccm_Info();

                ucpInfo = _iucpDA.SearchRecords(searchInfo).OrderBy(p => p.ucp_dAddDate).FirstOrDefault();//查卡用戶關系表

                if (ucpInfo != null && ucpInfo.ucp_cUseStatus != DefineConstantValue.ConsumeCardStatus.Returned.ToString())
                {
                    cusInfo = new CardUserMaster_cus_Info();
                    cusInfo.cus_cRecordID = ucpInfo.ucp_cCUSID;
                    cusInfo = _icumDA.DisplayRecord(cusInfo);//查用戶信息

                    ccmInfo.ccm_cCardID = ucpInfo.ucp_cCardID;
                    ccmInfo.ccm_lIsActive = true;
                    ccmInfo = _iccmDA.SearchRecords(ccmInfo).FirstOrDefault();//查卡信息

                    if(ccmInfo != null)
                    {
                        ccmInfo.CardOwner = cusInfo;
                        ccmInfo.UCPInfo = ucpInfo;
                        infoList.Add(ccmInfo);
                    }
                }
                else if(!String.IsNullOrEmpty(searchInfo.ucp_cCardID))
                {
                    ccmInfo = new ConsumeCardMaster_ccm_Info();
                    ccmInfo.ccm_cCardID = searchInfo.ucp_cCardID;
                    ccmInfo.ccm_lIsActive = true;
                    ccmInfo = _iccmDA.SearchRecords(ccmInfo).FirstOrDefault();

                    if(ccmInfo != null)
                    {
                        infoList.Add(ccmInfo);
                    }
                }

            }
            else if (!String.IsNullOrEmpty(searchInfo.CardOwner.cus_cChaName) || searchInfo.CardOwner.cus_cClassID != Guid.Empty)
            {
                List<CardUserMaster_cus_Info> cusList = _icumDA.SearchRecords(searchInfo.CardOwner);

                if (cusList != null)
                {
                    for (int index = 0; index < cusList.Count; index++)
                    {
                        searchInfo.ucp_cCUSID = cusList[index].cus_cRecordID;

                        ucpInfo = _iucpDA.SearchRecords(searchInfo).OrderBy(p => p.ucp_dAddDate).FirstOrDefault();

                        if (ucpInfo != null && ucpInfo.ucp_cUseStatus == DefineConstantValue.ConsumeCardStatus.Normal.ToString())
                        {
                            ccmInfo = new ConsumeCardMaster_ccm_Info();
                            ccmInfo.ccm_cCardID = ucpInfo.ucp_cCardID;
                            ccmInfo.ccm_cCardState = searchInfo.CardInfo.ccm_cCardState;
                            ccmInfo.ccm_lIsActive = true;

                            ccmInfo = _iccmDA.SearchRecords(ccmInfo).FirstOrDefault();//查卡信息

                            if (ccmInfo != null)
                            {
                                ccmInfo.CardOwner = cusList[index];
                                ccmInfo.UCPInfo = ucpInfo;

                                infoList.Add(ccmInfo);
                            }

                        }
                    }
                }
            }
            else
            {
                List<ConsumeCardMaster_ccm_Info> ccmList = _iccmDA.SearchRecords(new ConsumeCardMaster_ccm_Info() { ccm_lIsActive = true});
                if (ccmList != null)
                {
                    for (int index = 0; index < ccmList.Count; index++)
                    {
                        ucpInfo = new UserCardPair_ucp_Info();
                        ucpInfo.ucp_cCardID = ccmList[index].ccm_cCardID;
                        ucpInfo.ucp_cUseStatus = DefineConstantValue.ConsumeCardStatus.Normal.ToString();

                        ucpInfo = _iucpBL.SearchRecords(ucpInfo).FirstOrDefault();

                        if(ucpInfo != null)
                        {
                            ccmList[index].UCPInfo = ucpInfo;
                            ccmList[index].CardOwner = ucpInfo.CardOwner;
                        }

                        infoList.Add(ccmList[index]);
                    }
                }

            }

            if (infoList != null && infoList.Count > 0 && searchInfo.PairTime_From != null && searchInfo.PairTime_To != null)
            {
                for (int index = 0; index < infoList.Count; index++)
                {
                    if (infoList[index].UCPInfo.ucp_dPairTime < searchInfo.PairTime_From || infoList[index].UCPInfo.ucp_dPairTime > searchInfo.PairTime_To)
                    {
                        infoList.RemoveAt(index);
                        index--;
                    }
                }
            }

            return infoList;
        }

        #endregion

        #region IConsumeCardMasterBL 成员


        public List<ConsumeCardMaster_ccm_Info> SearchHistoryRecords(UserCardPair_ucp_Info searchInfo)
        {
            List<ConsumeCardMaster_ccm_Info> ccmList = new List<ConsumeCardMaster_ccm_Info>();

            try
            {
                searchInfo.ucp_iCardNo = 0;
                searchInfo.ucp_cUseStatus = DefineConstantValue.ConsumeCardStatus.Returned.ToString();
                List<UserCardPair_ucp_Info> ucpList = _iucpDA.SearchRecords(searchInfo);
                if (ucpList != null)
                {
                    for (int index = 0; index < ucpList.Count; index++)
                    {
                        CardUserMaster_cus_Info cusInfo = new CardUserMaster_cus_Info();
                        cusInfo.cus_cRecordID = ucpList[index].ucp_cCUSID;
                        cusInfo = _icumDA.SearchRecords(cusInfo).FirstOrDefault();

                        if (cusInfo != null)
                        {
                            ConsumeCardMaster_ccm_Info ccmInfo = new ConsumeCardMaster_ccm_Info();
                            ccmInfo.CardOwner = cusInfo;
                            ccmInfo.UCPInfo = ucpList[index];

                            ccmList.Add(ccmInfo);
                        }
                    }
                }
            }
            catch
            {

            }

            return ccmList;
        }

        #endregion

        #region IConsumeCardMasterBL 成员


        public Model.General.ReturnValueInfo DeleteRecord(Model.IModel.IModelObject deleteInfo)
        {
            Model.General.ReturnValueInfo returnInfo = new Model.General.ReturnValueInfo();

            try
            {
                if (deleteInfo != null)
                {
                    returnInfo = _iccmDA.DeleteRecord(deleteInfo);
                }
            }
            catch (Exception ex)
            {
                returnInfo.boolValue = false;
                returnInfo.messageText = ex.ToString();
            }

            return returnInfo;
        }

        #endregion

        #region IConsumeCardMasterBL 成员


        public Model.General.ReturnValueInfo UpdateRecord(Model.IModel.IModelObject updateInfo)
        {
            Model.General.ReturnValueInfo returnInfo = new Model.General.ReturnValueInfo();
            try
            {
                if(updateInfo != null)
                {
                    returnInfo = _iccmDA.UpdateRecord(updateInfo as ConsumeCardMaster_ccm_Info);
                }
            }
            catch (Exception ex)
            {
                returnInfo.boolValue = false;
                returnInfo.messageText = ex.ToString();
            }

            return returnInfo;
        }

        #endregion
    }
}
