using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.IDAL.HHZX.UserInformation.UserCard;
using Model.HHZX.UserCard;
using LinqToSQLModel;
using Model.General;
using Model.IModel;

namespace DAL.SqlDAL.HHZX.UserCard
{
    public class ConsumeCardMasterDA : IConsumeCardMasterDA
    {
        #region IMainGeneralDA<ConsumeCardMaster_ccm_Info> 成员

        public ReturnValueInfo InsertRecord(ConsumeCardMaster_ccm_Info infoObject)
        {
            ReturnValueInfo rvInfo = new ReturnValueInfo();
            try
            {
                if (infoObject != null)
                {
                    using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                    {
                        ConsumeCardMaster_ccm record = Common.General.CopyObjectValue<ConsumeCardMaster_ccm_Info, ConsumeCardMaster_ccm>(infoObject);
                        if (record != null)
                        {
                            db.ConsumeCardMaster_ccm.InsertOnSubmit(record);
                            db.SubmitChanges();
                            rvInfo.boolValue = true;
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

        public Model.General.ReturnValueInfo UpdateRecord(ConsumeCardMaster_ccm_Info infoObject)
        {
            ReturnValueInfo rvInfo = new ReturnValueInfo();
            try
            {
                if (infoObject != null)
                {
                    using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                    {
                        ConsumeCardMaster_ccm record = db.ConsumeCardMaster_ccm.Where(x => x.ccm_cCardID == infoObject.ccm_cCardID).FirstOrDefault();

                        if (record != null)
                        {
                            //record.ccm_cAdd = infoObject.ccm_cAdd;
                            if (!String.IsNullOrEmpty(infoObject.ccm_cCardState))
                            {
                                record.ccm_cCardState = infoObject.ccm_cCardState;
                            }
                            record.ccm_cLast = infoObject.ccm_cLast;
                            //record.ccm_dAddDate = infoObject.ccm_dAddDate;
                            record.ccm_dLastDate = infoObject.ccm_dLastDate;
                            record.ccm_lIsActive = infoObject.ccm_lIsActive;

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

        public Model.General.ReturnValueInfo DeleteRecord(IModelObject KeyObject)
        {
            ReturnValueInfo rvInfo = new ReturnValueInfo();
            try
            {
                ConsumeCardMaster_ccm_Info infoObject = KeyObject as ConsumeCardMaster_ccm_Info;
                if (infoObject != null)
                {
                    using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                    {
                        ConsumeCardMaster_ccm record = db.ConsumeCardMaster_ccm.Where(x => x.ccm_cCardID == infoObject.ccm_cCardID).FirstOrDefault();

                        if (record != null)
                        {
                            record.ccm_lIsActive = false;
                            //db.ConsumeCardMaster_ccm.DeleteOnSubmit(record);
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

        public ConsumeCardMaster_ccm_Info DisplayRecord(Model.IModel.IModelObject KeyObject)
        {
            ConsumeCardMaster_ccm_Info ccmInfo = null;

            try
            {
                ConsumeCardMaster_ccm_Info infoObject = KeyObject as ConsumeCardMaster_ccm_Info;
                if (infoObject != null)
                {
                    using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                    {
                        ConsumeCardMaster_ccm pair = db.ConsumeCardMaster_ccm.Where(x => x.ccm_cCardID == infoObject.ccm_cCardID && x.ccm_lIsActive == true).FirstOrDefault();

                        if (pair != null)
                        {
                            ccmInfo = Common.General.CopyObjectValue<ConsumeCardMaster_ccm, ConsumeCardMaster_ccm_Info>(pair);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ccmInfo;
        }

        public List<ConsumeCardMaster_ccm_Info> SearchRecords(Model.IModel.IModelObject searchCondition)
        {
            List<ConsumeCardMaster_ccm_Info> listReturn = null;

            try
            {
                ConsumeCardMaster_ccm_Info info = searchCondition as ConsumeCardMaster_ccm_Info;

                string strSql = "select * from dbo.ConsumeCardMaster_ccm where 1 = 1";

                if (info != null)
                {
                    if (!String.IsNullOrEmpty(info.ccm_cCardID) && info.ccm_cCardID != string.Empty.PadLeft(36, 'F'))
                    {
                        strSql += " and ccm_cCardID = '" + info.ccm_cCardID + "'";
                    }
                    if (!String.IsNullOrEmpty(info.ccm_cCardState))
                    {
                        strSql += " and ccm_cCardState = '" + info.ccm_cCardState + "'";
                    }
                    strSql += " and ccm_lIsActive = '" + info.ccm_lIsActive + "' ";

                }

                IEnumerable<ConsumeCardMaster_ccm_Info> infos = null;

                using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                {
                    infos = db.ExecuteQuery<ConsumeCardMaster_ccm_Info>(strSql, new object[] { });
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

        public List<ConsumeCardMaster_ccm_Info> AllRecords()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
