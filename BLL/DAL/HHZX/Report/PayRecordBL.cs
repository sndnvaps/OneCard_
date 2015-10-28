using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL.IBLL.HHZX.Report;
using Model.IModel;
using Model.General;
using DAL.IDAL.Report;
using DAL.Factory.HHZX;
using Model.HHZX.Report;

namespace BLL.DAL.HHZX.Report
{
    public class PayRecordBL : IPayRecordBL
    {
        IPayRecordDA _payRecordDA;

        public PayRecordBL()
        {
            this._payRecordDA = MasterDAFactory.GetDAL<IPayRecordDA>(MasterDAFactory.PayRecord);
        }

        #region IMainBL Members

        public IModelObject DisplayRecord(IModelObject itemEntity)
        {
            try
            {
                return this._payRecordDA.DisplayRecord(itemEntity);
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }

        public List<IModelObject> SearchRecords(IModelObject itemEntity)
        {
            List<IModelObject> returnList = new List<IModelObject>();

            try
            {
                List<PayRecord_prd_Info> searchInfo = this._payRecordDA.SearchRecords(itemEntity);

                if (searchInfo != null && searchInfo.Count > 0)
                {
                    foreach (PayRecord_prd_Info item in searchInfo)
                    {
                        returnList.Add(item);
                    }
                }
            }
            catch (Exception Ex)
            {

                throw Ex;
            }

            return returnList;
        }

        public ReturnValueInfo Save(IModelObject itemEntity, Common.DefineConstantValue.EditStateEnum EditMode)
        {
            ReturnValueInfo returnInfo = new ReturnValueInfo(false);

            PayRecord_prd_Info objInfo = itemEntity as PayRecord_prd_Info;

            objInfo.prd_dAddDate = DateTime.Now;

            objInfo.prd_dLastDate = DateTime.Now;

            try
            {
                switch (EditMode)
                {
                    case Common.DefineConstantValue.EditStateEnum.OE_Insert:

                        objInfo.prd_cRecordID = Guid.NewGuid();

                        returnInfo = this._payRecordDA.InsertRecord(objInfo);

                        break;
                    case Common.DefineConstantValue.EditStateEnum.OE_Update:

                        returnInfo = this._payRecordDA.UpdateRecord(objInfo);

                        break;
                    case Common.DefineConstantValue.EditStateEnum.OE_Delete:

                        returnInfo = this._payRecordDA.DeleteRecord(objInfo);

                        break;
                    case Common.DefineConstantValue.EditStateEnum.OE_ReaOnly:
                        break;
                    default:
                        break;
                }
            }
            catch (Exception Ex)
            {

                throw Ex;
            }

            return returnInfo;
        }

        #endregion
    }
}
