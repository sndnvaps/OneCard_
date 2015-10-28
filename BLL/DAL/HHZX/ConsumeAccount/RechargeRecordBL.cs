using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL.IBLL.HHZX.ConsumeAccount;
using DAL.IDAL.HHZX.ConsumeAccount;
using DAL.Factory.HHZX;
using Model.IModel;
using Model.General;
using Common;
using Model.HHZX.ComsumeAccount;
using DAL.IDAL.HHZX.UserCard;
using Model.HHZX.UserCard;
using Model.HHZX.Report;

namespace BLL.DAL.HHZX.ConsumeAccount
{
    /// <summary>
    /// 充值记录（卡充值、卡退款、现金退款、批量充值、批量退款）
    /// </summary>
    public class RechargeRecordBL : IRechargeRecordBL
    {
        private IRechargeRecordDA _IRechargeRecordDA;
        private ICardUserAccountDA _ICardUserAccountDA;
        private ICardUserAccountDetailDA _ICardUserAccountDetailDA;
        private IUserCardPairDA _IUserCardPairDA;
        private ISystemAccountDetailDA _ISystemAccountDetailDA;

        public RechargeRecordBL()
        {
            this._IRechargeRecordDA = MasterDAFactory.GetDAL<IRechargeRecordDA>(MasterDAFactory.RechargeRecord);
            this._ICardUserAccountDA = MasterDAFactory.GetDAL<ICardUserAccountDA>(MasterDAFactory.CardUserAccount);
            this._ICardUserAccountDetailDA = MasterDAFactory.GetDAL<ICardUserAccountDetailDA>(MasterDAFactory.CardUserAccountDetail);
            this._IUserCardPairDA = MasterDAFactory.GetDAL<IUserCardPairDA>(MasterDAFactory.UserCardPair);
            this._ISystemAccountDetailDA = MasterDAFactory.GetDAL<ISystemAccountDetailDA>(MasterDAFactory.SystemAccountDetail);
        }

        #region IMainGeneralBL Members

        public List<RechargeRecord_rcr_Info> AllRecords()
        {
            try
            {
                List<RechargeRecord_rcr_Info> listObj = new List<RechargeRecord_rcr_Info>();
                List<RechargeRecord_rcr_Info> listRecord = this._IRechargeRecordDA.AllRecords();
                foreach (RechargeRecord_rcr_Info item in listRecord)
                {
                    bool res = AddAccountDetailInfo(item);
                    res = AddUserCardPairInfo(item);
                    listObj.Add(item);
                }
                return listObj;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion

        #region IMainBL Members

        public RechargeRecord_rcr_Info DisplayRecord(IModelObject itemEntity)
        {
            try
            {
                RechargeRecord_rcr_Info rechargeInfo = this._IRechargeRecordDA.DisplayRecord(itemEntity);
                if (rechargeInfo != null)
                {
                    AddAccountDetailInfo(rechargeInfo);
                    AddUserCardPairInfo(rechargeInfo);
                }
                return rechargeInfo;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<RechargeRecord_rcr_Info> SearchRecords(IModelObject itemEntity)
        {
            List<RechargeRecord_rcr_Info> listObj = null;
            try
            {
                List<RechargeRecord_rcr_Info> listRechargeInfo = this._IRechargeRecordDA.SearchRecords(itemEntity);
                if (listRechargeInfo != null)
                {
                    listObj = new List<RechargeRecord_rcr_Info>();
                    foreach (RechargeRecord_rcr_Info item in listRechargeInfo)
                    {
                        AddAccountDetailInfo(item);
                        AddUserCardPairInfo(item);
                        listObj.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return listObj;
        }

        public List<RechargeRecord_rcr_Info> SearchRecords(IModelObject itemEntity, DateTime dtBegin, DateTime dtEnd)
        {
            List<RechargeRecord_rcr_Info> listRechrage = null;
            try
            {
                listRechrage = this._IRechargeRecordDA.SearchRecords(itemEntity, dtBegin, dtEnd);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return listRechrage;
        }

        public ReturnValueInfo Save(IModelObject itemEntity, DefineConstantValue.EditStateEnum EditMode)
        {
            ReturnValueInfo rvInfo = new ReturnValueInfo();
            try
            {
                RechargeRecord_rcr_Info sourceInfo = itemEntity as RechargeRecord_rcr_Info;
                if (sourceInfo == null)
                {
                    rvInfo.messageText = DefineConstantValue.SystemMessageText.strMessageText_E_ObjectNull;
                    rvInfo.isError = true;
                    return rvInfo;
                }

                //检查充值用户的账户ID，如还未创建账户，则自动创建，如创建失败，则不给予充值
                Guid? accountID = GetAccountID(sourceInfo);
                if (accountID == null)
                {
                    rvInfo.messageText = "用户账户信息缺失，自动添加账户失败。";
                    rvInfo.isError = true;
                    return rvInfo;
                }

                //判断是否为需要录入用户账户中的记录
                bool isUserDetail = IsUserAccountRecord(sourceInfo);
                // 判断是否为需要录入到系统账户中的记录
                bool isSysDetail = IsSysAccountRecord(sourceInfo);

                switch (EditMode)
                {
                    case DefineConstantValue.EditStateEnum.OE_Insert:
                        {
                            /*插入充值记录时，判断是否需要同步一条卡用户账户资金流记录及系统账户资金流记录，
                             * 如需要，则在新增充值记录后同步插入一条资金流记录及系统账户资金流记录，
                             * 如插入失败，则需要在运行资金同步服务时重新新增*/
                            #region Insert Record

                            sourceInfo.rcr_dRechargeTime = DateTime.Now;
                            sourceInfo.rcr_dLastDate = sourceInfo.rcr_dRechargeTime;

                            rvInfo = this._IRechargeRecordDA.InsertRecord(sourceInfo);

                            if (rvInfo.boolValue && !rvInfo.isError)
                            {
                                if (isUserDetail)
                                {
                                    //同步插入一条用户资金流动记录
                                    #region 同步用户资金流动记录

                                    CardUserAccountDetail_cuad_Info accountDetail = new CardUserAccountDetail_cuad_Info();
                                    accountDetail.cuad_cConsumeID = sourceInfo.rcr_cRecordID;
                                    accountDetail.cuad_cCUAID = accountID.Value;
                                    accountDetail.cuad_fFlowMoney = sourceInfo.rcr_fRechargeMoney;
                                    accountDetail.cuad_cFlowType = sourceInfo.rcr_cRechargeType;
                                    accountDetail.cuad_cOpt = sourceInfo.rcr_cAdd;
                                    accountDetail.cuad_cRecordID = Guid.NewGuid();
                                    accountDetail.cuad_dOptTime = sourceInfo.rcr_dRechargeTime;
                                    ReturnValueInfo res = this._ICardUserAccountDetailDA.InsertRecord(accountDetail);
                                    rvInfo.messageText += res.messageText;

                                    #endregion
                                }
                                if (isSysDetail)
                                {
                                    //同步插入一条系统资金现金流
                                    #region 同步系统资金流动记录

                                    SystemAccountDetail_sad_Info sysAccountInfo = new SystemAccountDetail_sad_Info();
                                    sysAccountInfo.sad_cConsumeID = sourceInfo.rcr_cRecordID;
                                    sysAccountInfo.sad_cDesc = string.Empty;
                                    sysAccountInfo.sad_cFLowMoney = sourceInfo.rcr_fRechargeMoney;
                                    sysAccountInfo.sad_cFlowType = sourceInfo.rcr_cRechargeType;
                                    sysAccountInfo.sad_cOpt = sourceInfo.rcr_cAdd;
                                    sysAccountInfo.sad_cRecordID = Guid.NewGuid();
                                    sysAccountInfo.sad_dOptTime = sourceInfo.rcr_dRechargeTime;
                                    ReturnValueInfo res = this._ISystemAccountDetailDA.InsertRecord(sysAccountInfo);
                                    rvInfo.messageText += res.messageText;

                                    #endregion
                                }
                            }
                            break;

                            #endregion
                        }
                    case DefineConstantValue.EditStateEnum.OE_Update:
                        {
                            /*更新充值记录时，需检查是否有相应的资金流记录，
                             * 如有，则需同步更新
                             */
                            #region Update Record

                            sourceInfo.rcr_dLastDate = DateTime.Now;

                            rvInfo = this._IRechargeRecordDA.UpdateRecord(sourceInfo);

                            if (rvInfo.boolValue && !rvInfo.isError)
                            {
                                if (isUserDetail)
                                {
                                    //同步更新对应用户资金流记录
                                    #region 同步用户资金流记录

                                    CardUserAccountDetail_cuad_Info accountDetail = this._ICardUserAccountDetailDA.SearchRecords(new CardUserAccountDetail_cuad_Info() { cuad_cConsumeID = sourceInfo.rcr_cRecordID }).FirstOrDefault();
                                    if (accountDetail == null)
                                    {
                                        //如无对应资金流记录，则添加
                                        accountDetail = new CardUserAccountDetail_cuad_Info();
                                        accountDetail.cuad_cConsumeID = sourceInfo.rcr_cRecordID;
                                        accountDetail.cuad_cCUAID = accountID.Value;
                                        accountDetail.cuad_fFlowMoney = sourceInfo.rcr_fRechargeMoney;
                                        accountDetail.cuad_cFlowType = sourceInfo.rcr_cRechargeType;
                                        accountDetail.cuad_cOpt = sourceInfo.rcr_cAdd;
                                        accountDetail.cuad_cRecordID = Guid.NewGuid();
                                        accountDetail.cuad_dOptTime = sourceInfo.rcr_dRechargeTime;
                                        ReturnValueInfo res = this._ICardUserAccountDetailDA.InsertRecord(accountDetail);
                                        rvInfo.messageText += res.messageText;
                                    }
                                    else
                                    {
                                        //如存在对应资金流记录，则更新金额、流类型、操作人、最后操作时间
                                        accountDetail.cuad_cFlowType = sourceInfo.rcr_cRechargeType;
                                        accountDetail.cuad_cOpt = sourceInfo.rcr_cLast;
                                        accountDetail.cuad_dOptTime = sourceInfo.rcr_dLastDate;
                                        accountDetail.cuad_fFlowMoney = sourceInfo.rcr_fRechargeMoney;
                                        ReturnValueInfo res = this._ICardUserAccountDetailDA.UpdateRecord(accountDetail);
                                        rvInfo.messageText += res.messageText;
                                    }

                                    #endregion
                                }
                                if (isSysDetail)
                                {
                                    //同步更新对应系统资金流记录
                                    #region 同步系统资金流记录

                                    SystemAccountDetail_sad_Info sysAccountInfo = this._ISystemAccountDetailDA.SearchRecords(new SystemAccountDetail_sad_Info() { sad_cConsumeID = sourceInfo.rcr_cRecordID }).FirstOrDefault();
                                    if (sysAccountInfo == null)
                                    {
                                        sysAccountInfo.sad_cConsumeID = sourceInfo.rcr_cRecordID;
                                        sysAccountInfo.sad_cDesc = string.Empty;
                                        sysAccountInfo.sad_cFLowMoney = sourceInfo.rcr_fRechargeMoney;
                                        sysAccountInfo.sad_cFlowType = sourceInfo.rcr_cRechargeType;
                                        sysAccountInfo.sad_cOpt = sourceInfo.rcr_cAdd;
                                        sysAccountInfo.sad_cRecordID = Guid.NewGuid();
                                        sysAccountInfo.sad_dOptTime = sourceInfo.rcr_dRechargeTime;
                                        ReturnValueInfo res = this._ISystemAccountDetailDA.InsertRecord(sysAccountInfo);
                                        rvInfo.messageText += res.messageText;
                                    }
                                    else
                                    {
                                        sysAccountInfo.sad_cDesc = string.Empty;
                                        sysAccountInfo.sad_cFLowMoney = sourceInfo.rcr_fRechargeMoney;
                                        sysAccountInfo.sad_cFlowType = sourceInfo.rcr_cRechargeType;
                                        sysAccountInfo.sad_cOpt = sourceInfo.rcr_cAdd;
                                        sysAccountInfo.sad_cRecordID = Guid.NewGuid();
                                        sysAccountInfo.sad_dOptTime = sourceInfo.rcr_dRechargeTime;
                                        ReturnValueInfo res = this._ISystemAccountDetailDA.UpdateRecord(sysAccountInfo);
                                        rvInfo.messageText += res.messageText;
                                    }

                                    #endregion
                                }
                            }
                            break;

                            #endregion
                        }
                    case DefineConstantValue.EditStateEnum.OE_Delete:
                        {
                            /*需要删除充值记录时，不能做真正的删除记录操作，
                             * 只能添加一条交易金额为原金额*1的充值记录作为充数只用，充值类型也相应为对冲类型
                             * 同时也需要检查是否有资金流记录，进行同步操作
                             */
                            #region Delete Record

                            RechargeRecord_rcr_Info OldRechargeInfo = this._IRechargeRecordDA.DisplayRecord(sourceInfo);
                            if (OldRechargeInfo != null)
                            {
                                //插入一条金额对冲记录代替删除原充值记录
                                RechargeRecord_rcr_Info NewRechargeInfo = new RechargeRecord_rcr_Info();
                                NewRechargeInfo.rcr_fRechargeMoney = OldRechargeInfo.rcr_fRechargeMoney * -1;
                                NewRechargeInfo.rcr_dRechargeTime = DateTime.Now;
                                NewRechargeInfo.rcr_cUserID = OldRechargeInfo.rcr_cUserID;
                                NewRechargeInfo.rcr_cStatus = DefineConstantValue.ConsumeMoneyFlowStatus.Finished.ToString();
                                NewRechargeInfo.rcr_cRecordID = Guid.NewGuid();
                                NewRechargeInfo.rcr_cRechargeType = DefineConstantValue.ConsumeMoneyFlowType.HedgeFund.ToString();
                                NewRechargeInfo.rcr_cLast = sourceInfo.rcr_cLast;
                                NewRechargeInfo.rcr_dLastDate = NewRechargeInfo.rcr_dRechargeTime;

                                rvInfo = this._IRechargeRecordDA.InsertRecord(NewRechargeInfo);

                                if (rvInfo.boolValue && !rvInfo.isError)
                                {
                                    if (isUserDetail)
                                    {
                                        //同步插入用户账户资金流
                                        #region 同步用户资金流记录

                                        CardUserAccountDetail_cuad_Info accountDetail = new CardUserAccountDetail_cuad_Info();
                                        accountDetail.cuad_cConsumeID = sourceInfo.rcr_cRecordID;
                                        accountDetail.cuad_cCUAID = accountID.Value;
                                        accountDetail.cuad_fFlowMoney = sourceInfo.rcr_fRechargeMoney;
                                        accountDetail.cuad_cFlowType = sourceInfo.rcr_cRechargeType;
                                        accountDetail.cuad_cOpt = sourceInfo.rcr_cAdd;
                                        accountDetail.cuad_cRecordID = Guid.NewGuid();
                                        accountDetail.cuad_dOptTime = sourceInfo.rcr_dRechargeTime;
                                        ReturnValueInfo res = this._ICardUserAccountDetailDA.InsertRecord(accountDetail);

                                        #endregion
                                    }
                                    if (isSysDetail)
                                    {
                                        //同步插入系统资金现金流
                                        #region 同步系统资金流动记录

                                        SystemAccountDetail_sad_Info sysAccountInfo = new SystemAccountDetail_sad_Info();
                                        sysAccountInfo.sad_cConsumeID = sourceInfo.rcr_cRecordID;
                                        sysAccountInfo.sad_cDesc = string.Empty;
                                        sysAccountInfo.sad_cFLowMoney = sourceInfo.rcr_fRechargeMoney;
                                        sysAccountInfo.sad_cFlowType = sourceInfo.rcr_cRechargeType;
                                        sysAccountInfo.sad_cOpt = sourceInfo.rcr_cAdd;
                                        sysAccountInfo.sad_cRecordID = Guid.NewGuid();
                                        sysAccountInfo.sad_dOptTime = sourceInfo.rcr_dRechargeTime;
                                        ReturnValueInfo res = this._ISystemAccountDetailDA.InsertRecord(sysAccountInfo);
                                        rvInfo.messageText += res.messageText;

                                        #endregion
                                    }
                                }

                            }
                            else
                            {
                                rvInfo.messageText = "找不到原充值记录。";
                                rvInfo.isError = true;
                            }

                            break;

                            #endregion
                        }
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                rvInfo.isError = true;
                rvInfo.messageText = ex.Message;
            }
            return rvInfo;
        }

        #endregion

        /// <summary>
        /// 添加消费记录对应用户卡发卡情况
        /// </summary>
        /// <returns></returns>
        bool AddUserCardPairInfo(RechargeRecord_rcr_Info rechargeInfo)
        {
            bool res = false;
            try
            {
                if (rechargeInfo != null)
                {
                    rechargeInfo.AccountDetail = this._ICardUserAccountDetailDA.DisplayRecord(new CardUserAccountDetail_cuad_Info() { cuad_cConsumeID = rechargeInfo.rcr_cRecordID });
                    res = true;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return res;
        }

        /// <summary>
        /// 添加消费记录对应账户资金流动记录
        /// </summary>
        /// <returns></returns>
        bool AddAccountDetailInfo(RechargeRecord_rcr_Info rechargeInfo)
        {
            bool res = false;
            try
            {
                if (rechargeInfo != null)
                {
                    rechargeInfo.PairInfo = this._IUserCardPairDA.DisplayRecord(new UserCardPair_ucp_Info() { ucp_cCardID = rechargeInfo.rcr_cCardID });
                    res = true;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return res;
        }

        /// <summary>
        /// 获取账户ID
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        Guid? GetAccountID(RechargeRecord_rcr_Info rechargeRecord)
        {
            if (rechargeRecord == null)
            {
                return null;
            }
            Guid UserID = rechargeRecord.rcr_cUserID;
            CardUserAccount_cua_Info accountInfo = this._ICardUserAccountDA.SearchRecords(new CardUserAccount_cua_Info() { cua_cCUSID = UserID }).FirstOrDefault();
            if (accountInfo == null)
            {
                accountInfo = new CardUserAccount_cua_Info();
                accountInfo.cua_cAdd = rechargeRecord.rcr_cLast;
                accountInfo.cua_cCUSID = UserID;
                accountInfo.cua_cRecordID = Guid.NewGuid();
                accountInfo.cua_dAddDate = DateTime.Now;
                accountInfo.cua_dLastSyncTime = DateTime.Now;
                accountInfo.cua_fCurrentBalance = 0;
                accountInfo.cua_fOriginalBalance = 0;
                ReturnValueInfo rvInfo = this._ICardUserAccountDA.InsertRecord(accountInfo);
                if (!rvInfo.boolValue || rvInfo.isError)
                {
                    return null;
                }
            }
            return accountInfo.cua_cRecordID;
        }

        /// <summary>
        /// 是否为需要记录到用户账户的数据
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        bool IsUserAccountRecord(RechargeRecord_rcr_Info record)
        {
            if (record != null)
            {
                if (record.rcr_cRechargeType == DefineConstantValue.ConsumeMoneyFlowType.Recharge_AdvanceMoney.ToString() || record.rcr_cRechargeType == DefineConstantValue.ConsumeMoneyFlowType.Recharge_BatchTransfer.ToString() || record.rcr_cRechargeType == DefineConstantValue.ConsumeMoneyFlowType.Recharge_PersonalTransfer.ToString() || record.rcr_cRechargeType == DefineConstantValue.ConsumeMoneyFlowType.Refund_BatchTransfer.ToString() || record.rcr_cRechargeType == DefineConstantValue.ConsumeMoneyFlowType.Refund_PersonalTransfer.ToString())
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 是否为需要记录到系统账户的数据
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        bool IsSysAccountRecord(RechargeRecord_rcr_Info record)
        {
            if (record != null)
            {
                if (record.rcr_cRechargeType == DefineConstantValue.ConsumeMoneyFlowType.Recharge_AdvanceMoney.ToString())
                {
                    return false;
                }
            }
            return true;
        }

        #region IRechargeRecordBL Members

        public List<AmountOfChange_aoc_Info> AccountDetailList(AmountOfChange_aoc_Info query)
        {
            try
            {
                return this._IRechargeRecordDA.AccountDetailList(query);
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }

        #endregion

        #region IRechargeRecordBL Members


        public ReturnValueInfo InsertRechargeRecord(IModelObject itemEntity)
        {
            ReturnValueInfo rvInfo = new ReturnValueInfo();
            try
            {
                rvInfo = this._IRechargeRecordDA.InsertRechargeRecord(itemEntity);
            }
            catch (Exception ex)
            {
                rvInfo.isError = true;
                rvInfo.messageText = ex.Message;
            }
            return rvInfo;
        }

        public ReturnValueInfo UpdateRechargeRecord(List<RechargeRecord_rcr_Info> listRecord, decimal fPreCostRecharge)
        {
            ReturnValueInfo rvInfo = new ReturnValueInfo();
            try
            {
                rvInfo = this._IRechargeRecordDA.UpdateRechargeRecord(listRecord, fPreCostRecharge);
            }
            catch (Exception ex)
            {
                rvInfo.isError = true;
                rvInfo.messageText = ex.Message;
            }
            return rvInfo;
        }

        public ReturnValueInfo UpdateRechargeRecord(List<PreRechargeRecord_prr_Info> listRecord, List<RechargeRecord_rcr_Info> listRechargeRecords, decimal fPreCostRecharge)
        {
            ReturnValueInfo rvInfo = new ReturnValueInfo();
            try
            {
                rvInfo = this._IRechargeRecordDA.UpdateRechargeRecord(listRecord, listRechargeRecords, fPreCostRecharge);
            }
            catch (Exception ex)
            {
                rvInfo.isError = true;
                rvInfo.messageText = ex.Message;
            }
            return rvInfo;
        }

        public ReturnValueInfo DeleteRechargeRecord(IModelObject itemEntity)
        {
            ReturnValueInfo rvInfo = new ReturnValueInfo();
            try
            {
                rvInfo = this._IRechargeRecordDA.DeleteRechargeRecord(itemEntity);
            }
            catch (Exception ex)
            {
                rvInfo.isError = true;
                rvInfo.messageText = ex.Message;
            }
            return rvInfo;
        }

        public ReturnValueInfo CashRefund(RechargeRecord_rcr_Info refundRecord, decimal fPreCostRecharge)
        {
            ReturnValueInfo rvInfo = new ReturnValueInfo();
            try
            {
                fPreCostRecharge = Math.Abs(fPreCostRecharge);
                rvInfo = this._IRechargeRecordDA.CashRefund(refundRecord, fPreCostRecharge);
            }
            catch (Exception ex)
            {
                rvInfo.isError = true;
                rvInfo.messageText = ex.Message;
            }
            return rvInfo;
        }

        #endregion
    }
}
