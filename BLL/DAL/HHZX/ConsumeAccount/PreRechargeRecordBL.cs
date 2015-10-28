using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL.IBLL.HHZX.ConsumeAccount;
using DAL.IDAL.HHZX.ConsumeAccount;
using DAL.Factory.HHZX;
using Model.General;
using Model.IModel;
using Model.HHZX.ComsumeAccount;

namespace BLL.DAL.HHZX.ConsumeAccount
{
    class PreRechargeRecordBL : IPreRechargeRecordBL
    {
        public IPreRechargeRecordDA _IPreRechargeRecordDA;

        public PreRechargeRecordBL()
        {
            this._IPreRechargeRecordDA = MasterDAFactory.GetDAL<IPreRechargeRecordDA>(MasterDAFactory.PreRechargeRecord);
        }

        #region IBaseBL<PreRechargeRecord_prr_Info> Members

        public ReturnValueInfo Save(IModelObject itemEntity, Common.DefineConstantValue.EditStateEnum EditMode)
        {
            ReturnValueInfo rvInfo = new ReturnValueInfo();
            try
            {
                switch (EditMode)
                {
                    case Common.DefineConstantValue.EditStateEnum.OE_Insert:
                        rvInfo = this._IPreRechargeRecordDA.InsertRecord(itemEntity as PreRechargeRecord_prr_Info);
                        break;
                    case Common.DefineConstantValue.EditStateEnum.OE_Update:
                        rvInfo = this._IPreRechargeRecordDA.UpdateRecord(itemEntity as PreRechargeRecord_prr_Info);
                        break;
                    case Common.DefineConstantValue.EditStateEnum.OE_Delete:
                        rvInfo = this._IPreRechargeRecordDA.DeleteRecord(itemEntity);
                        break;
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

        public PreRechargeRecord_prr_Info DisplayRecord(IModelObject KeyObject)
        {
            try
            {
                return this._IPreRechargeRecordDA.DisplayRecord(KeyObject);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<PreRechargeRecord_prr_Info> SearchRecords(IModelObject searchCondition)
        {
            try
            {
                return this._IPreRechargeRecordDA.SearchRecords(searchCondition);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<PreRechargeRecord_prr_Info> AllRecords()
        {
            try
            {
                return this._IPreRechargeRecordDA.AllRecords();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion
    }
}
