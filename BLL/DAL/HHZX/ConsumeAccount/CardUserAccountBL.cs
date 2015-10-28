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

namespace BLL.DAL.HHZX.ConsumeAccount
{
    /// <summary>
    /// 卡用户账户余额信息
    /// </summary>
    public class CardUserAccountBL : ICardUserAccountBL
    {
        private ICardUserAccountDA _ICardUserAccountDA;

        public CardUserAccountBL()
        {
            this._ICardUserAccountDA = MasterDAFactory.GetDAL<ICardUserAccountDA>(MasterDAFactory.CardUserAccount);
        }

        public List<CardUserAccount_cua_Info> AllRecords()
        {
            throw new NotImplementedException();
        }

        public CardUserAccount_cua_Info DisplayRecord(IModelObject itemEntity)
        {
            try
            {
                return this._ICardUserAccountDA.DisplayRecord(itemEntity);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<CardUserAccount_cua_Info> SearchRecords(IModelObject itemEntity)
        {
            try
            {
                return this._ICardUserAccountDA.SearchRecords(itemEntity);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public ReturnValueInfo Save(IModelObject itemEntity, DefineConstantValue.EditStateEnum EditMode)
        {
            throw new NotImplementedException();
        }

        public CardUserAccount_cua_Info SyncAccount(IModelObject KeyObject, DateTime dtDeadline)
        {
            try
            {
                return this._ICardUserAccountDA.SyncAccount(KeyObject, dtDeadline);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<CardUserAccount_cua_Info> GetUserAccountBalance(List<CardUserAccount_cua_Info> listSource, DateTime dtDeadline)
        {
            if (listSource == null || (listSource != null && listSource.Count < 0))
            {
                return null;
            }

            List<CardUserAccount_cua_Info> listUserAccounts = new List<CardUserAccount_cua_Info>();
            if (dtDeadline.Date == DateTime.Now.Date)
            {
                foreach (CardUserAccount_cua_Info accountItem in listSource)
                {
                    CardUserAccount_cua_Info accountInfo = this._ICardUserAccountDA.SearchRecords(new CardUserAccount_cua_Info()
                    {
                        cua_cCUSID = accountItem.cua_cCUSID
                    }).FirstOrDefault();
                    if (accountInfo != null)
                    {
                        listUserAccounts.Add(accountInfo);
                    }
                }
            }

            return listUserAccounts;
        }

        public decimal GetAccountTotalBalance(DateTime dtDeadline)
        {
            try
            {
                return this._ICardUserAccountDA.GetAccountTotalBalance(dtDeadline);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<CardUserAccount_cua_Info> GetRemindList(string identityNum, Guid departmentID, decimal Balance, bool lWithFilter,string userName)
        {
            try
            {
                return this._ICardUserAccountDA.GetRemindList(identityNum, departmentID, Balance, lWithFilter, userName);
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }

        public ReturnValueInfo AccountCashReFund(IModelObject infoObject, string strReason)
        {
            ReturnValueInfo rvInfo = new ReturnValueInfo();
            try
            {
                rvInfo = this._ICardUserAccountDA.AccountCashReFund(infoObject, strReason);
            }
            catch (Exception ex)
            {
                rvInfo.isError = true;
                rvInfo.messageText = ex.Message;
            }
            return rvInfo;
        }

        public ReturnValueInfo BatchSyncAccountDetail(List<PreConsumeRecord_pcs_Info> listUpdatePreCost, List<PreConsumeRecord_pcs_Info> listDelPreCost, List<ConsumeRecord_csr_Info> listConsume)
        {
            try
            {
                return this._ICardUserAccountDA.BatchSyncAccountDetail(listUpdatePreCost, listDelPreCost, listConsume);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public ReturnValueInfo ResetAccountOverdraft(RechargeRecord_rcr_Info OverdraftInfo)
        {
            try
            {
                return this._ICardUserAccountDA.ResetAccountOverdraft(OverdraftInfo);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
