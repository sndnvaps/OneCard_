using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL.IBLL.HHZX.Report;
using DAL.IDAL.Report;
using DAL.Factory.HHZX;

namespace BLL.DAL.HHZX.Report
{
    public class PaymentBalanceBL : IPaymentBalanceBL
    {
        private IPaymentBalanceDA _ipbDA;

        public PaymentBalanceBL()
        {
            _ipbDA = MasterDAFactory.GetDAL<IPaymentBalanceDA>(MasterDAFactory.PaymentBalance);
        }

        #region IBaseBL<PaymentBalance_Info> 成员

        public Model.General.ReturnValueInfo Save(Model.IModel.IModelObject itemEntity, Common.DefineConstantValue.EditStateEnum EditMode)
        {
            throw new NotImplementedException();
        }

        public Model.HHZX.Report.PaymentBalance_Info DisplayRecord(Model.IModel.IModelObject KeyObject)
        {
            throw new NotImplementedException();
        }

        public List<Model.HHZX.Report.PaymentBalance_Info> SearchRecords(Model.IModel.IModelObject searchCondition)
        {
            return _ipbDA.SearchRecords(searchCondition);
        }

        public List<Model.HHZX.Report.PaymentBalance_Info> SearchRecords(Model.IModel.IModelObject searchCondition, bool lIsWithMac, bool lIsWithPreCost)
        {
            return _ipbDA.SearchRecords(searchCondition, lIsWithMac, lIsWithPreCost);
        }

        public List<Model.HHZX.Report.PaymentBalance_Info> AllRecords()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
