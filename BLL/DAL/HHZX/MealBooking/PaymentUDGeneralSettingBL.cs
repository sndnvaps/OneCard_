using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL.IBLL.HHZX.MealBooking;
using Model.IModel;
using Model.General;
using DAL.IDAL.HHZX.MealBooking;
using DAL.Factory.HHZX;
using Model.HHZX.MealBooking;

namespace BLL.DAL.HHZX.MealBooking
{
    public class PaymentUDGeneralSettingBL : IPaymentUDGeneralSettingBL
    {
        IPaymentUDGeneralSettingDA _paymentUDGeneralSettingDA;

        public PaymentUDGeneralSettingBL()
        {
            this._paymentUDGeneralSettingDA = MasterDAFactory.GetDAL<IPaymentUDGeneralSettingDA>(MasterDAFactory.PaymentUDGeneralSetting);
        }

        public PaymentUDGeneralSetting_pus_Info DisplayRecord(IModelObject itemEntity)
        {
            try
            {
                return this._paymentUDGeneralSettingDA.DisplayRecord(itemEntity);
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }

        public List<PaymentUDGeneralSetting_pus_Info> SearchRecords(IModelObject itemEntity)
        {
            List<PaymentUDGeneralSetting_pus_Info> searchInfo = null;
            try
            {
                searchInfo = this._paymentUDGeneralSettingDA.SearchRecords(itemEntity);
            }
            catch (Exception Ex)
            {

                throw Ex;
            }


            return searchInfo;
        }

        public ReturnValueInfo Save(IModelObject itemEntity, Common.DefineConstantValue.EditStateEnum EditMode)
        {
            ReturnValueInfo returnInfo = new ReturnValueInfo();

            PaymentUDGeneralSetting_pus_Info objInfo = itemEntity as PaymentUDGeneralSetting_pus_Info;

            if (objInfo != null)
            {

                objInfo.pus_dAddDate = DateTime.Now;

                objInfo.pus_dLastDate = DateTime.Now;

                try
                {
                    switch (EditMode)
                    {
                        case Common.DefineConstantValue.EditStateEnum.OE_Insert:

                            if (!this._paymentUDGeneralSettingDA.IsExistRecord(objInfo))
                            {
                                returnInfo = this._paymentUDGeneralSettingDA.InsertRecord(objInfo);
                            }
                            else
                            {
                                returnInfo = this._paymentUDGeneralSettingDA.UpdateRecord(objInfo);
                            }

                            break;
                        case Common.DefineConstantValue.EditStateEnum.OE_Update:

                            returnInfo = this._paymentUDGeneralSettingDA.UpdateRecord(objInfo);

                            break;
                        case Common.DefineConstantValue.EditStateEnum.OE_Delete:

                            returnInfo = this._paymentUDGeneralSettingDA.DeleteRecord(objInfo);

                            break;
                        case Common.DefineConstantValue.EditStateEnum.OE_ReaOnly:
                            break;
                        default:
                            break;
                    }
                }
                catch (Exception Ex)
                {

                    returnInfo.messageText = Ex.Message;
                }

            }


            return returnInfo;
        }

        public ReturnValueInfo Save(List<PaymentUDGeneralSetting_pus_Info> objList)
        {
            try
            {

                if (objList != null && objList.Count > 0)
                {
                    foreach (PaymentUDGeneralSetting_pus_Info item in objList)
                    {
                        item.pus_cRecordID = Guid.NewGuid();
                        item.pus_dAddDate = DateTime.Now;
                        item.pus_dLastDate = DateTime.Now;
                    }
                }

                return this._paymentUDGeneralSettingDA.Save(objList);
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }

        public List<PaymentUDGeneralSetting_pus_Info> AllRecords()
        {
            try
            {
                return this._paymentUDGeneralSettingDA.AllRecords();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public ReturnValueInfo BatchDeleteRecords(PaymentUDGeneralSetting_pus_Info searchInfo)
        {
            try
            {
                return this._paymentUDGeneralSettingDA.BatchDeleteRecords(searchInfo);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #region IExtraBL Members

        public bool IsExistRecord(object KeyObject)
        {
            throw new NotImplementedException();
        }

        public IModelObject LockRecord(object KeyObject)
        {
            throw new NotImplementedException();
        }

        public IModelObject UnLockRecord(object KeyObject)
        {
            throw new NotImplementedException();
        }

        public IModelObject GetTableFieldLenght()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
