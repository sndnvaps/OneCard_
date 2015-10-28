using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL.IBLL.HHZX.ConsumeAccount;
using DAL.IDAL.HHZX.ConsumeAccount;
using DAL.Factory.HHZX;
using Model.HHZX.ComsumeAccount;
using DAL.IDAL.HHZX.ConsumerDevice;
using Model.HHZX.ConsumerDevice;
using Model.HHZX.UserCard;
using Model.HHZX.UserInfomation.CardUserInfo;
using DAL.IDAL.HHZX.UserInformation.CardUserInfo;
using DAL.IDAL.HHZX.UserCard;
using Model.General;

namespace BLL.DAL.HHZX.ConsumeAccount
{
    public class ConsumeRecordBL : IConsumeRecordBL
    {
        private IConsumeRecordDA _icmDA;

        public ConsumeRecordBL()
        {
            this._icmDA = MasterDAFactory.GetDAL<IConsumeRecordDA>(MasterDAFactory.ConsumeRecord);
        }

        #region IBaseBL<ConsumeRecord_csr_Info> 成员

        public Model.General.ReturnValueInfo InsertRecord(ConsumeRecord_csr_Info infoObject)
        {
            throw new NotImplementedException();
        }

        public Model.General.ReturnValueInfo UpdateRecord(ConsumeRecord_csr_Info infoObject)
        {
            throw new NotImplementedException();
        }

        public Model.General.ReturnValueInfo DeleteRecord(Model.IModel.IModelObject KeyObject)
        {
            throw new NotImplementedException();
        }

        public ConsumeRecord_csr_Info DisplayRecord(Model.IModel.IModelObject KeyObject)
        {
            try
            {
                return this._icmDA.DisplayRecord(KeyObject);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<ConsumeRecord_csr_Info> SearchRecords(Model.IModel.IModelObject searchCondition)
        {
            List<ConsumeRecord_csr_Info> returnList = new List<ConsumeRecord_csr_Info>();
            try
            {
                ConsumeRecord_csr_Info csrInfo = searchCondition as ConsumeRecord_csr_Info;

                returnList = _icmDA.SearchRecords(csrInfo);
            }
            catch
            {

            }
            return returnList;
        }

        public List<ConsumeRecord_csr_Info> AllRecords()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IBaseBL<ConsumeRecord_csr_Info> Members

        public Model.General.ReturnValueInfo Save(Model.IModel.IModelObject itemEntity, Common.DefineConstantValue.EditStateEnum EditMode)
        {
            throw new NotImplementedException();
        }

        #endregion

        public ReturnValueInfo BatchSyncSourceRecord(List<SourceConsumeRecord_scr_Info> listSourceRecord, string strMealType)
        {
            try
            {
                return this._icmDA.BatchSyncSourceRecord(listSourceRecord, strMealType);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #region IConsumeRecordBL Members

        /// <summary>
        /// 取得个人最后消费记录
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public ConsumeRecord_csr_Info GetLastRecord(ConsumeRecord_csr_Info query)
        {
            try
            {
                return this._icmDA.GetLastRecord(query);
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }

        #endregion
    }
}
