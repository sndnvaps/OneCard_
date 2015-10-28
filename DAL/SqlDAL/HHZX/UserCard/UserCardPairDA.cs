using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.IDAL.HHZX.UserCard;
using Model.General;
using LinqToSQLModel;
using Model.HHZX.UserCard;
using Model.IModel;
using Model.HHZX.Report;
using Model.HHZX.ComsumeAccount;
using System.Data.SqlClient;

namespace DAL.SqlDAL.HHZX.UserCard
{
    public class UserCardPairDA : IUserCardPairDA
    {
        public List<UserCardPair_ucp_Info> GetUnusualCardList()
        {
            List<UserCardPair_ucp_Info> listPairs = null;
            try
            {
                StringBuilder sbSQL = new StringBuilder();
                //sbSQL.AppendLine("select top");
                //sbSQL.AppendLine(Common.DefineConstantValue.ListRecordMaxCount.ToString());
                //sbSQL.AppendLine("* from UserCardPair_ucp with(nolock)");
                //sbSQL.AppendLine("where ucp_cCardID not in(");
                //sbSQL.AppendLine("select ucp_cCardID from UserCardPair_ucp with(nolock)");
                //sbSQL.AppendLine("where ucp_cUseStatus='Normal')");
                //sbSQL.AppendLine("and (ucp_dLastDate>=DATEADD(MONTH,-6,GETDATE())");
                //sbSQL.AppendLine("or ucp_cUseStatus='LoseReporting')");

                sbSQL.AppendLine("select * from UserCardPair_ucp with(nolock)");
                sbSQL.AppendLine("where ucp_cUseStatus<>'Normal' and ucp_dPairTime>=DATEADD(MONTH,-12,GETDATE())");

                using (SqlDataReader reader = DbHelperSQL.ExecuteReader(sbSQL.ToString()))
                {
                    listPairs = new List<UserCardPair_ucp_Info>();

                    while (reader.Read())
                    {
                        UserCardPair_ucp_Info pairInfo = new UserCardPair_ucp_Info();

                        if (reader["ucp_cRecordID"] != null && reader["ucp_cRecordID"].ToString() != string.Empty)
                        {
                            pairInfo.ucp_cRecordID = new Guid(reader["ucp_cRecordID"].ToString());
                        }
                        if (reader["ucp_iCardNo"] != null && reader["ucp_iCardNo"].ToString() != string.Empty)
                        {
                            pairInfo.ucp_iCardNo = int.Parse(reader["ucp_iCardNo"].ToString());
                        }
                        if (reader["ucp_cCardID"] != null && reader["ucp_cCardID"].ToString() != string.Empty)
                        {
                            pairInfo.ucp_cCardID = reader["ucp_cCardID"].ToString();
                        }
                        if (reader["ucp_cCUSID"] != null && reader["ucp_cCUSID"].ToString() != string.Empty)
                        {
                            pairInfo.ucp_cCUSID = new Guid(reader["ucp_cCUSID"].ToString());
                        }
                        if (reader["ucp_dPairTime"] != null && reader["ucp_dPairTime"].ToString() != string.Empty)
                        {
                            pairInfo.ucp_dPairTime = DateTime.Parse(reader["ucp_dPairTime"].ToString());
                        }
                        if (reader["ucp_dReturnTime"] != null && reader["ucp_dReturnTime"].ToString() != string.Empty)
                        {
                            pairInfo.ucp_dReturnTime = DateTime.Parse(reader["ucp_dReturnTime"].ToString());
                        }
                        if (reader["ucp_cUseStatus"] != null && reader["ucp_cUseStatus"].ToString() != string.Empty)
                        {
                            pairInfo.ucp_cUseStatus = reader["ucp_cUseStatus"].ToString();
                        }
                        if (reader["ucp_lIsActive"] != null && reader["ucp_lIsActive"].ToString() != string.Empty)
                        {
                            pairInfo.ucp_lIsActive = bool.Parse(reader["ucp_lIsActive"].ToString());
                        }
                        if (reader["ucp_cAdd"] != null && reader["ucp_cAdd"].ToString() != string.Empty)
                        {
                            pairInfo.ucp_cAdd = reader["ucp_cAdd"].ToString();
                        }
                        if (reader["ucp_dAddDate"] != null && reader["ucp_dAddDate"].ToString() != string.Empty)
                        {
                            pairInfo.ucp_dAddDate = DateTime.Parse(reader["ucp_dAddDate"].ToString());
                        }
                        if (reader["ucp_cLast"] != null && reader["ucp_cLast"].ToString() != string.Empty)
                        {
                            pairInfo.ucp_cLast = reader["ucp_cLast"].ToString();
                        }
                        if (reader["ucp_dLastDate"] != null && reader["ucp_dLastDate"].ToString() != string.Empty)
                        {
                            pairInfo.ucp_dLastDate = DateTime.Parse(reader["ucp_dLastDate"].ToString());
                        }

                        listPairs.Add(pairInfo);
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return listPairs;
        }

        public ReturnValueInfo InsertRecord(UserCardPair_ucp_Info infoObject)
        {
            ReturnValueInfo rvInfo = new ReturnValueInfo();
            try
            {
                if (infoObject != null)
                {
                    using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                    {
                        UserCardPair_ucp pair = Common.General.CopyObjectValue<UserCardPair_ucp_Info, UserCardPair_ucp>(infoObject);
                        if (pair != null)
                        {
                            db.UserCardPair_ucp.InsertOnSubmit(pair);
                            db.SubmitChanges();
                            rvInfo.boolValue = true;

                            infoObject = Common.General.CopyObjectValue<UserCardPair_ucp, UserCardPair_ucp_Info>(pair);

                            rvInfo.ValueObject = infoObject;
                        }
                        else
                        {
                            rvInfo.messageText = "TransEntity is null";
                        }
                    }
                }
                else
                {
                    rvInfo.messageText = Common.DefineConstantValue.SystemMessageText.strMessageText_E_ObjectNull;
                }
            }
            catch (Exception ex)
            {
                rvInfo.isError = true;
                rvInfo.messageText = ex.Message;
            }
            return rvInfo;
        }

        public ReturnValueInfo UpdateRecord(UserCardPair_ucp_Info infoObject)
        {
            ReturnValueInfo rvInfo = new ReturnValueInfo();
            try
            {
                if (infoObject != null)
                {
                    using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                    {
                        UserCardPair_ucp pair = db.UserCardPair_ucp.Where(x => x.ucp_cRecordID == infoObject.ucp_cRecordID).FirstOrDefault();

                        if (pair != null)
                        {
                            pair.ucp_cCardID = infoObject.ucp_cCardID;
                            pair.ucp_cCUSID = infoObject.ucp_cCUSID;
                            pair.ucp_cLast = infoObject.ucp_cLast;
                            pair.ucp_cUseStatus = infoObject.ucp_cUseStatus;
                            pair.ucp_dLastDate = infoObject.ucp_dLastDate;
                            pair.ucp_dPairTime = infoObject.ucp_dPairTime;
                            pair.ucp_dReturnTime = infoObject.ucp_dReturnTime;
                            pair.ucp_lIsActive = infoObject.ucp_lIsActive;
                            //pair.ucp_iCardNo = infoObject.ucp_iCardNo;

                            db.SubmitChanges();
                            rvInfo.boolValue = true;
                        }
                        else
                        {
                            rvInfo.messageText = "GetEntity is null";
                        }
                    }
                }
                else
                {
                    rvInfo.messageText = Common.DefineConstantValue.SystemMessageText.strMessageText_E_ObjectNull;
                }
            }
            catch (Exception ex)
            {
                rvInfo.isError = true;
                rvInfo.messageText = ex.Message;
            }
            return rvInfo;
        }

        public ReturnValueInfo DeleteRecord(IModelObject KeyObject)
        {
            ReturnValueInfo rvInfo = new ReturnValueInfo();
            try
            {
                UserCardPair_ucp_Info infoObject = KeyObject as UserCardPair_ucp_Info;
                if (infoObject != null)
                {
                    using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                    {
                        UserCardPair_ucp pair = db.UserCardPair_ucp.Where(x => x.ucp_cRecordID == infoObject.ucp_cRecordID).FirstOrDefault();

                        if (pair != null)
                        {
                            pair.ucp_lIsActive = false;

                            db.SubmitChanges();
                            rvInfo.boolValue = true;
                            rvInfo.ValueObject = infoObject;
                        }
                        else
                        {
                            rvInfo.messageText = "GetEntity is null";
                        }
                    }
                }
                else
                {
                    rvInfo.messageText = Common.DefineConstantValue.SystemMessageText.strMessageText_E_ObjectNull;
                }
            }
            catch (Exception ex)
            {
                rvInfo.isError = true;
                rvInfo.messageText = ex.Message;
            }
            return rvInfo;
        }

        public UserCardPair_ucp_Info DisplayRecord(IModelObject KeyObject)
        {
            UserCardPair_ucp_Info resInfo = null;
            try
            {
                UserCardPair_ucp_Info infoObject = KeyObject as UserCardPair_ucp_Info;
                if (infoObject != null)
                {
                    using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                    {
                        UserCardPair_ucp pair = db.UserCardPair_ucp.Where(x => x.ucp_cRecordID == infoObject.ucp_cRecordID).FirstOrDefault();

                        if (pair != null)
                        {
                            resInfo = Common.General.CopyObjectValue<UserCardPair_ucp, UserCardPair_ucp_Info>(pair);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return resInfo;
        }

        public List<UserCardPair_ucp_Info> SearchRecords(IModelObject searchCondition)
        {
            List<UserCardPair_ucp_Info> listPairInfo = null;
            try
            {
                StringBuilder sbSQL = new StringBuilder();
                sbSQL.AppendLine("SELECT TOP");
                sbSQL.AppendLine(Common.DefineConstantValue.ListRecordMaxCount.ToString());
                sbSQL.AppendLine("* FROM UserCardPair_ucp WHERE 1 = 1");
                sbSQL.AppendLine("AND ucp_lIsActive = 1");

                UserCardPair_ucp_Info searchInfo = searchCondition as UserCardPair_ucp_Info;
                if (searchInfo != null)
                {
                    if (!string.IsNullOrEmpty(searchInfo.ucp_cCardID))
                        sbSQL.AppendLine("AND ucp_cCardID ='" + searchInfo.ucp_cCardID + "'");
                    if (searchInfo.ucp_cCUSID != Guid.Empty)
                        sbSQL.AppendLine("AND ucp_cCUSID ='" + searchInfo.ucp_cCUSID.ToString() + "'");
                    if (!string.IsNullOrEmpty(searchInfo.ucp_cUseStatus))
                        sbSQL.AppendLine("AND ucp_cUseStatus ='" + searchInfo.ucp_cUseStatus + "'");
                    if (searchInfo.ucp_dPairTime != DateTime.MinValue)
                        sbSQL.AppendLine("AND ucp_dPairTime ='" + searchInfo.ucp_dPairTime.ToString("yyyy-MM-dd HH:mm") + "'");
                    if (searchInfo.ucp_dReturnTime != null)
                        sbSQL.AppendLine("AND ucp_dReturnTime ='" + searchInfo.ucp_dReturnTime.Value.ToString("yyyy-MM-dd HH:mm") + "'");
                    if (searchInfo.ucp_iCardNo > 0)
                        sbSQL.AppendLine("AND ucp_iCardNo =" + searchInfo.ucp_iCardNo.ToString());
                }

                using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                {
                    IEnumerable<UserCardPair_ucp_Info> query = db.ExecuteQuery<UserCardPair_ucp_Info>(sbSQL.ToString(), new object[] { });
                    if (query != null)
                    {
                        listPairInfo = query.ToList<UserCardPair_ucp_Info>();
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return listPairInfo;
        }

        public List<UserCardPair_ucp_Info> AllRecords()
        {
            List<UserCardPair_ucp_Info> listPairInfo = null;
            try
            {
                StringBuilder sbSQL = new StringBuilder();
                sbSQL.AppendLine("SELECT ");
                sbSQL.AppendLine("* FROM UserCardPair_ucp WHERE 1 = 1");
                sbSQL.AppendLine("AND ucp_lIsActive = 1");

                using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                {
                    IEnumerable<UserCardPair_ucp_Info> query = db.ExecuteQuery<UserCardPair_ucp_Info>(sbSQL.ToString(), new object[] { });
                    if (query != null)
                    {
                        listPairInfo = query.ToList<UserCardPair_ucp_Info>();
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return listPairInfo;
        }

        public ReturnValueInfo InsertNewCard(UserCardPair_ucp_Info infoObject, decimal dCost)
        {
            ReturnValueInfo rvInfo = new ReturnValueInfo();
            try
            {
                if (infoObject == null)
                {
                    rvInfo.isError = true;
                    rvInfo.messageText = Common.DefineConstantValue.SystemMessageText.strMessageText_E_ObjectNull;
                    return rvInfo;
                }
                using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                {
                    try
                    {
                        db.Connection.Open();
                        db.Transaction = db.Connection.BeginTransaction();

                        ConsumeCardMaster_ccm cardInfo = db.ConsumeCardMaster_ccm.Where(x => x.ccm_cCardID == infoObject.ucp_cCardID).FirstOrDefault();
                        if (cardInfo == null)
                        {
                            //如未有卡主档信息，则添加
                            cardInfo = new ConsumeCardMaster_ccm();
                            cardInfo.ccm_cCardID = infoObject.ucp_cCardID;
                            cardInfo.ccm_cCardState = Common.DefineConstantValue.CardUseState.InUse.ToString();
                            cardInfo.ccm_cAdd = infoObject.ucp_cLast;
                            cardInfo.ccm_dAddDate = DateTime.Now;
                            cardInfo.ccm_cLast = infoObject.ucp_cLast;
                            cardInfo.ccm_dLastDate = DateTime.Now;
                            cardInfo.ccm_lIsActive = true;
                            db.ConsumeCardMaster_ccm.InsertOnSubmit(cardInfo);
                        }
                        else
                        {
                            //如已有卡主档信息，则更新卡的使用状态
                            cardInfo.ccm_cCardState = Common.DefineConstantValue.CardUseState.InUse.ToString();
                            cardInfo.ccm_cLast = infoObject.ucp_cLast;
                            cardInfo.ccm_dLastDate = DateTime.Now;
                        }

                        //检查是否已发卡
                        UserCardPair_ucp pair = db.UserCardPair_ucp.Where(x => x.ucp_cCUSID == infoObject.ucp_cCUSID && x.ucp_cUseStatus == Common.DefineConstantValue.ConsumeCardStatus.Normal.ToString()).FirstOrDefault();
                        if (pair != null)
                        {
                            rvInfo.isError = true;
                            rvInfo.messageText = "本用户已发卡，现用卡号为：" + pair.ucp_iCardNo.ToString();
                            return rvInfo;
                        }

                        pair = Common.General.CopyObjectValue<UserCardPair_ucp_Info, UserCardPair_ucp>(infoObject);
                        if (pair != null)
                        {
                            pair.ucp_dAddDate = DateTime.Now;
                            pair.ucp_dLastDate = DateTime.Now;
                            db.UserCardPair_ucp.InsertOnSubmit(pair);
                            db.SubmitChanges();

                            //查看是否已经创建账户
                            CardUserAccount_cua account = db.CardUserAccount_cua.Where(x => x.cua_cCUSID == pair.ucp_cCUSID).FirstOrDefault();
                            if (account == null)
                            {
                                //如未创建账户，则自动创建
                                account = new CardUserAccount_cua();
                                account.cua_cRecordID = Guid.NewGuid();
                                account.cua_cCUSID = pair.ucp_cCUSID;
                                account.cua_fCurrentBalance = 0;
                                account.cua_fOriginalBalance = 0;
                                account.cua_dLastSyncTime = DateTime.Now;
                                account.cua_lIsActive = true;
                                account.cua_cAdd = pair.ucp_cAdd;
                                account.cua_dAddDate = DateTime.Now;
                                db.CardUserAccount_cua.InsertOnSubmit(account);
                                db.SubmitChanges();
                            }
                            decimal fFormula = -1;
                            CodeMaster_cmt codeFormula = db.CodeMaster_cmt.Where(x => x.cmt_cKey1 == Common.DefineConstantValue.EnumFormulaKey.PRECOSTFORMULA.ToString() && x.cmt_cKey2 == Common.DefineConstantValue.ConsumeMoneyFlowType.NewCardCost.ToString()).FirstOrDefault();
                            if (codeFormula != null)
                            {
                                fFormula = codeFormula.cmt_fNumber;
                            }
                            //account.cua_fCurrentBalance += dCost * fFormula;
                            //account.cua_dLastSyncTime = DateTime.Now;
                            //db.SubmitChanges();

                            //插入【预消费记录】

                            PreConsumeRecord_pcs preConsume = new PreConsumeRecord_pcs();
                            preConsume.pcs_cAccountID = account.cua_cRecordID;
                            preConsume.pcs_cRecordID = Guid.NewGuid();
                            preConsume.pcs_cUserID = infoObject.ucp_cCUSID;
                            preConsume.pcs_cConsumeType = Common.DefineConstantValue.ConsumeMoneyFlowType.NewCardCost.ToString();
                            preConsume.pcs_dConsumeDate = DateTime.Now;
                            preConsume.pcs_fCost = dCost;
                            preConsume.pcs_cAdd = pair.ucp_cAdd;
                            preConsume.pcs_dAddDate = DateTime.Now;
                            if (dCost == 0)
                            {
                                preConsume.pcs_lIsSettled = true;
                                preConsume.pcs_dSettleTime = DateTime.Now;
                            }
                            else
                            {
                                preConsume.pcs_lIsSettled = false;
                            }
                            preConsume.pcs_cSourceID = pair.ucp_cRecordID;
                            db.PreConsumeRecord_pcs.InsertOnSubmit(preConsume);
                            db.SubmitChanges();

                            db.Transaction.Commit();
                            rvInfo.boolValue = true;

                        }
                        else
                        {
                            rvInfo.isError = true;
                            rvInfo.messageText = Common.DefineConstantValue.SystemMessageText.strMessageText_E_ObjectNull;
                            return rvInfo;
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
            catch (Exception ex)
            {
                rvInfo.isError = true;
                rvInfo.messageText = ex.Message;
            }
            return rvInfo;
        }

        public ReturnValueInfo InsertExchargeCard(UserCardPair_ucp_Info infoObject, decimal dCost)
        {
            ReturnValueInfo rvInfo = new ReturnValueInfo();
            try
            {
                if (infoObject != null)
                {
                    using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                    {
                        db.Connection.Open();
                        db.Transaction = db.Connection.BeginTransaction();
                        try
                        {
                            UserCardPair_ucp pair = Common.General.CopyObjectValue<UserCardPair_ucp_Info, UserCardPair_ucp>(infoObject);
                            if (pair != null)
                            {
                                db.UserCardPair_ucp.InsertOnSubmit(pair);
                                db.SubmitChanges();

                                // 用户账户不存在时，自动创建对应账户信息
                                CardUserAccount_cua accountInfo = db.CardUserAccount_cua.Where(x => x.cua_cCUSID == pair.ucp_cCUSID).FirstOrDefault();
                                if (accountInfo == null)
                                {
                                    accountInfo = new CardUserAccount_cua();
                                    accountInfo.cua_cCUSID = pair.ucp_cCUSID;
                                    accountInfo.cua_cRecordID = Guid.NewGuid();
                                    accountInfo.cua_cAdd = pair.ucp_cLast;
                                    accountInfo.cua_dAddDate = DateTime.Now;
                                    accountInfo.cua_dLastSyncTime = DateTime.Now;
                                    accountInfo.cua_fCurrentBalance = 0;
                                    accountInfo.cua_fOriginalBalance = 0;
                                    accountInfo.cua_lIsActive = true;

                                    db.CardUserAccount_cua.InsertOnSubmit(accountInfo);
                                    db.SubmitChanges();
                                }

                                //插入【预消费记录】
                                PreConsumeRecord_pcs preConsume = new PreConsumeRecord_pcs();
                                preConsume.pcs_cAccountID = accountInfo.cua_cRecordID;
                                preConsume.pcs_cRecordID = Guid.NewGuid();
                                preConsume.pcs_cUserID = infoObject.ucp_cCUSID;
                                preConsume.pcs_cConsumeType = Common.DefineConstantValue.ConsumeMoneyFlowType.ReplaceCardCost.ToString();
                                preConsume.pcs_dConsumeDate = DateTime.Now;
                                preConsume.pcs_fCost = dCost;
                                if (dCost == 0)
                                {
                                    preConsume.pcs_lIsSettled = true;
                                    preConsume.pcs_dSettleTime = DateTime.Now;
                                }
                                else
                                {
                                    preConsume.pcs_lIsSettled = false;
                                }
                                preConsume.pcs_cAdd = pair.ucp_cAdd;
                                preConsume.pcs_cSourceID = pair.ucp_cRecordID;
                                preConsume.pcs_dAddDate = DateTime.Now;
                                preConsume.pcs_cSourceID = pair.ucp_cRecordID;
                                db.PreConsumeRecord_pcs.InsertOnSubmit(preConsume);
                                db.SubmitChanges();

                                db.Transaction.Commit();

                                rvInfo.boolValue = true;
                                rvInfo.ValueObject = Common.General.CopyObjectValue<UserCardPair_ucp, UserCardPair_ucp_Info>(pair);
                            }
                            else
                            {
                                rvInfo.messageText = "TransEntity is null";
                                db.Transaction.Rollback();
                            }
                        }
                        catch (Exception exx)
                        {
                            db.Transaction.Rollback();
                            throw exx;
                        }
                    }
                }
                else
                {
                    rvInfo.messageText = Common.DefineConstantValue.SystemMessageText.strMessageText_E_ObjectNull;
                }
            }
            catch (Exception ex)
            {
                rvInfo.isError = true;
                rvInfo.messageText = ex.Message;
            }
            return rvInfo;
        }

        public ReturnValueInfo ReturnCard(UserCardPair_ucp_Info infoObject)
        {
            ReturnValueInfo rvInfo = new ReturnValueInfo();
            try
            {
                if (infoObject == null)
                {
                    rvInfo.isError = true;
                    rvInfo.messageText = Common.DefineConstantValue.SystemMessageText.strMessageText_E_ObjectNull;
                    return rvInfo;
                }
                using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                {
                    db.Connection.Open();
                    db.Transaction = db.Connection.BeginTransaction();
                    try
                    {
                        UserCardPair_ucp pairInfo = db.UserCardPair_ucp.Where(x => x.ucp_cRecordID == infoObject.ucp_cRecordID).FirstOrDefault();
                        if (pairInfo != null)
                        {
                            pairInfo.ucp_cUseStatus = Common.DefineConstantValue.ConsumeCardStatus.Returned.ToString();
                            pairInfo.ucp_dReturnTime = infoObject.ucp_dReturnTime;
                            pairInfo.ucp_cLast = infoObject.ucp_cLast;
                            pairInfo.ucp_dLastDate = infoObject.ucp_dLastDate;
                            db.SubmitChanges();

                            ConsumeCardMaster_ccm cardInfo = db.ConsumeCardMaster_ccm.Where(x => x.ccm_cCardID == infoObject.ucp_cCardID).FirstOrDefault();
                            if (cardInfo != null)
                            {
                                cardInfo.ccm_cCardState = Common.DefineConstantValue.CardUseState.NotUsed.ToString();
                                cardInfo.ccm_cLast = infoObject.ucp_cLast;
                                cardInfo.ccm_dLastDate = infoObject.ucp_dLastDate;
                                db.SubmitChanges();
                            }
                            else
                            {
                                cardInfo = new ConsumeCardMaster_ccm();
                                cardInfo.ccm_cAdd = infoObject.ucp_cLast;
                                cardInfo.ccm_cLast = infoObject.ucp_cLast;
                                cardInfo.ccm_dAddDate = infoObject.ucp_dLastDate;
                                cardInfo.ccm_dLastDate = infoObject.ucp_dLastDate;
                                cardInfo.ccm_cCardState = Common.DefineConstantValue.CardUseState.NotUsed.ToString();
                                cardInfo.ccm_lIsActive = true;
                                cardInfo.ccm_cCardID = infoObject.ucp_cCardID;
                                db.ConsumeCardMaster_ccm.InsertOnSubmit(cardInfo);
                                db.SubmitChanges();
                            }

                            db.Transaction.Commit();
                            db.Connection.Close();
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
            catch (Exception ex)
            {
                rvInfo.isError = true;
                rvInfo.messageText = ex.Message;
            }
            return rvInfo;
        }

        /// <summary>
        /// 取得换卡信息列表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public List<ChangeCardDetail_ccd_Info> GetChangeCardDetail(ChangeCardDetail_ccd_Info query)
        {
            List<ChangeCardDetail_ccd_Info> searchData = null;

            if (query != null)
            {
                StringBuilder sbSQL = new StringBuilder();

                sbSQL.AppendLine(" select ISNULL( ucp1.ucp_iCardNo,'') as 'ccd_cOldID',");
                sbSQL.AppendLine(" ISNULL( ucp2.ucp_iCardNo,'') as 'ccd_cNewID',");
                sbSQL.AppendLine(" ISNULL(cus_cChaName,'') as 'ccd_cName',");
                sbSQL.AppendLine(" ISNULL(pcs_fCost,CONVERT(decimal(18,2), 0)) as 'ccd_dMoney',");
                sbSQL.AppendLine(" case");
                sbSQL.AppendLine(" when cus_cIdentityNum='" + Common.DefineConstantValue.CodeMasterDefine.KEY2_SIOT_CardUserIdentity_Staff + "' then dpm_cName  ");
                sbSQL.AppendLine(" when cus_cIdentityNum='" + Common.DefineConstantValue.CodeMasterDefine.KEY2_SIOT_CardUserIdentity_Student + "' then csm_cClassName");
                sbSQL.AppendLine(" else '' end as 'ccd_cUnionName',");
                sbSQL.AppendLine("  ucp1.ucp_dReturnTime as 'ccd_dOpTime',CONVERT (datetime, '" + query.startDate.Value.ToString("yyyy-MM-dd") + "') as startDate,CONVERT (datetime,'" + query.endDate.Value.ToString("yyyy-MM-dd") + "') as endDate");
                sbSQL.AppendLine(" from dbo.UserCardPair_ucp as ucp1");
                sbSQL.AppendLine("  join dbo.UserCardPair_ucp as ucp2");
                sbSQL.AppendLine(" on ucp1.ucp_cCUSID=ucp2.ucp_cCUSID and ucp1.ucp_cRecordID <> ucp2.ucp_cRecordID and ucp2.ucp_dReturnTime IS NULL and ucp2.ucp_cUseStatus='" + Common.DefineConstantValue.ConsumeCardStatus.Normal.ToString() + "'");
                sbSQL.AppendLine("  join dbo.CardUserMaster_cus");
                sbSQL.AppendLine(" on ucp2.ucp_cCUSID=cus_cRecordID");
                sbSQL.AppendLine("  join dbo.PreConsumeRecord_pcs");
                sbSQL.AppendLine(" on ucp2.ucp_cRecordID=pcs_cSourceID");
                sbSQL.AppendLine(" left join dbo.ClassMaster_csm");
                sbSQL.AppendLine(" on cus_cClassID=csm_cRecordID");
                sbSQL.AppendLine(" left join dbo.DepartmentMaster_dpm");
                sbSQL.AppendLine(" on cus_cClassID=dpm_RecordID");
                sbSQL.AppendLine(" where 1=1");
                sbSQL.AppendLine(" and ucp1.ucp_dReturnTime IS NOT NULL");
                if (query.startDate != null)
                {
                    sbSQL.AppendLine(" and ucp1.ucp_dReturnTime>='" + query.startDate.Value.ToString("yyyy-MM-dd") + " 00:00'");
                }
                if (query.endDate != null)
                {
                    sbSQL.AppendLine(" and ucp1.ucp_dReturnTime<'" + query.endDate.Value.AddDays(1).ToString("yyyy-MM-dd") + " 00:00'");
                }
                if (query.classID != null && query.classID != Guid.Empty)
                {
                    sbSQL.AppendLine(" and cus_cClassID ='" + query.classID.ToString() + "'");
                }
                if (query.ccd_cNewID > 0)
                {
                    sbSQL.AppendLine(" and ucp2.ucp_iCardNo =" + query.ccd_cNewID.ToString());
                }

                sbSQL.AppendLine(" order by ucp1.ucp_dReturnTime asc");

                try
                {
                    using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                    {
                        IEnumerable<ChangeCardDetail_ccd_Info> queryData = db.ExecuteQuery<ChangeCardDetail_ccd_Info>(sbSQL.ToString(), new object[] { });
                        if (query != null)
                        {
                            searchData = queryData.ToList<ChangeCardDetail_ccd_Info>();
                        }
                    }
                }
                catch (Exception Ex)
                {

                    throw Ex;
                }
            }

            return searchData;
        }

        /// <summary>
        /// 取得开户信息列表
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="classID"></param>
        /// <returns></returns>
        public List<CardUserAccount_cua_Info> GetAccoumtEstablishInfo(DateTime startDate, DateTime endDate, Guid classID, string studentID)
        {
            List<CardUserAccount_cua_Info> accountInfo = new List<CardUserAccount_cua_Info>();

            string sqlStr = string.Empty;

            //sqlStr += "select ISNULL( cus_cChaName,'') as cua_cUserName," + Environment.NewLine;

            //sqlStr += "ISNULL( csm_cClassName,'') as cua_cClassName," + Environment.NewLine;

            //sqlStr += "ISNULL(cuad_fFlowMoney,0) as cua_dCostMoney," + Environment.NewLine;

            //sqlStr += "cuad_dOptTime as cua_dLastSyncTime,ISNULL(ucp_iCardNo,0) as cua_cCardNo" + Environment.NewLine;

            //sqlStr += ",cus_cStudentID" + Environment.NewLine;

            //sqlStr += "from dbo.CardUserAccountDetail_cuad" + Environment.NewLine;

            //sqlStr += "left join dbo.CardUserAccount_cua" + Environment.NewLine;

            //sqlStr += "on cuad_cCUAID=cua_cRecordID" + Environment.NewLine;

            //sqlStr += "left join dbo.CardUserMaster_cus" + Environment.NewLine;

            //sqlStr += "on cua_cCUSID=cus_cRecordID" + Environment.NewLine;

            //sqlStr += "left join dbo.ClassMaster_csm" + Environment.NewLine;

            //sqlStr += "on cus_cClassID=csm_cRecordID" + Environment.NewLine;

            //sqlStr += "left join dbo.UserCardPair_ucp" + Environment.NewLine;

            //sqlStr += "on cuad_cConsumeID=ucp_cRecordID" + Environment.NewLine;

            //sqlStr += "where 1=1" + Environment.NewLine;

            //sqlStr += "and cuad_cFlowType='" + Common.DefineConstantValue.ConsumeMoneyFlowType.NewCardCost + "'" + Environment.NewLine;

            //sqlStr += "and cuad_dOptTime>='" + startDate.ToString("yyyy-MM-dd") + " 00:00:00'" + Environment.NewLine;

            //sqlStr += "and cuad_dOptTime<'" + endDate.AddDays(1).ToString("yyyy-MM-dd") + " 00:00:00'" + Environment.NewLine;

            //if (classID != Guid.Empty)
            //{
            //    sqlStr += "and cus_cClassID='" + classID.ToString() + "'" + Environment.NewLine;
            //}


            sqlStr += "select ISNULL( cus_cChaName,'') as cua_cUserName," + Environment.NewLine;

            //sqlStr += "ISNULL( csm_cClassName,'') as cua_cClassName," + Environment.NewLine;
            sqlStr += "case cus_cIdentityNum" + Environment.NewLine;
            sqlStr += "when 'STAFF' then ISNULL( dpm_cName,'')" + Environment.NewLine;
            sqlStr += "when 'STUDENT' then ISNULL( csm_cClassName,'')" + Environment.NewLine;
            sqlStr += "else '' end as cua_cClassName," + Environment.NewLine;

            sqlStr += "ISNULL(pcs_fCost,0) as cua_dCostMoney," + Environment.NewLine;
            sqlStr += "pcs_dConsumeDate as cua_dLastSyncTime,ISNULL(ucp_iCardNo,0) as cua_cCardNo" + Environment.NewLine;
            sqlStr += ",cus_cStudentID" + Environment.NewLine;
            sqlStr += "from " + Environment.NewLine;
            sqlStr += "dbo.PreConsumeRecord_pcs" + Environment.NewLine;
            sqlStr += "left join dbo.CardUserMaster_cus" + Environment.NewLine;
            sqlStr += "on pcs_cUserID=cus_cRecordID" + Environment.NewLine;
            sqlStr += "left join dbo.ClassMaster_csm" + Environment.NewLine;
            sqlStr += "on cus_cClassID=csm_cRecordID" + Environment.NewLine;

            sqlStr += "left join dbo.DepartmentMaster_dpm" + Environment.NewLine;
            sqlStr += "on dpm_RecordID = cus_cClassID" + Environment.NewLine;

            sqlStr += "left join dbo.UserCardPair_ucp" + Environment.NewLine;
            sqlStr += "on pcs_cSourceID=ucp_cRecordID" + Environment.NewLine;
            sqlStr += "where 1=1" + Environment.NewLine;

            sqlStr += "and pcs_cConsumeType='" + Common.DefineConstantValue.ConsumeMoneyFlowType.NewCardCost + "'";
            sqlStr += "and pcs_dConsumeDate >= '" + startDate.ToString("yyyy-MM-dd") + " 00:00:00'";
            sqlStr += "and pcs_dConsumeDate <= '" + endDate.AddDays(1).ToString("yyyy-MM-dd") + " 00:00:00'";

            if (classID != Guid.Empty)
            {
                sqlStr += "and cus_cClassID='" + classID.ToString() + "'" + Environment.NewLine;
            }

            if (!String.IsNullOrEmpty(studentID))
            {
                sqlStr += "and cus_cStudentID like '%" + studentID + "%'" + Environment.NewLine;
            }

            try
            {
                using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                {
                    IEnumerable<CardUserAccount_cua_Info> queryData = db.ExecuteQuery<CardUserAccount_cua_Info>(sqlStr.ToString(), new object[] { });
                    if (queryData != null)
                    {
                        accountInfo = queryData.ToList<CardUserAccount_cua_Info>();
                    }
                }
            }
            catch (Exception Ex)
            {

                throw Ex;
            }


            return accountInfo;
        }

        /// <summary>
        /// 获取长期黑名单的卡号列表
        /// </summary>
        public List<int> GetContinuedBalckListCardNoList()
        {
            List<int> listCardNo = null;

            StringBuilder sbSQL = new StringBuilder();
            sbSQL.AppendLine("select top 10000 ucp_iCardNo from UserCardPair_ucp Main with(nolock)");
            sbSQL.AppendLine("left join (select distinct ucp_cCardID from UserCardPair_ucp with(nolock)");
            sbSQL.AppendLine("where ucp_cUseStatus='Normal')A");
            sbSQL.AppendLine("on A.ucp_cCardID=Main.ucp_cCardID");
            sbSQL.AppendLine("where ucp_cUseStatus<>'Normal' and A.ucp_cCardID is null");
            sbSQL.AppendLine("order by ucp_dPairTime desc");

            try
            {
                using (SqlDataReader reader = DbHelperSQL.ExecuteReader(sbSQL.ToString()))
                {
                    listCardNo = new List<int>();
                    while (reader.Read())
                    {
                        if (reader["ucp_iCardNo"] != null && reader["ucp_iCardNo"].ToString() != string.Empty)
                        {
                            int iCardNo = int.Parse(reader["ucp_iCardNo"].ToString());
                            if (!listCardNo.Contains(iCardNo))
                            {
                                listCardNo.Add(iCardNo);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return listCardNo;
        }

    }
}
