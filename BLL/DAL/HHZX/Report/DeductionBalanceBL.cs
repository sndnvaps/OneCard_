using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL.IBLL.HHZX.Report;
using DAL.IDAL.Report;
using DAL.Factory.HHZX;

namespace BLL.DAL.HHZX.Report
{
    public class DeductionBalanceBL : IDeductionBalanceBL
    {
        private IDeductionBalanceDA _idbDA;

        public DeductionBalanceBL()
        {
            _idbDA = MasterDAFactory.GetDAL<IDeductionBalanceDA>(MasterDAFactory.DeductionBalance);
        }

        #region IBaseBL<DeductionBalance_Info> 成员

        public Model.General.ReturnValueInfo Save(Model.IModel.IModelObject itemEntity, Common.DefineConstantValue.EditStateEnum EditMode)
        {
            throw new NotImplementedException();
        }

        public Model.HHZX.Report.DeductionBalance_Info DisplayRecord(Model.IModel.IModelObject KeyObject)
        {
            throw new NotImplementedException();
        }

        public List<Model.HHZX.Report.DeductionBalance_Info> SearchRecords(Model.IModel.IModelObject searchCondition)
        {
            return _idbDA.SearchRecords(searchCondition);
        }

        public List<Model.HHZX.Report.DeductionBalance_Info> AllRecords()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
