using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL.IBLL.HHZX.Report;
using Model.IModel;
using Common;
using Model.HHZX.Report;
using DAL.IDAL.Report;
using DAL.Factory.HHZX;

namespace BLL.DAL.HHZX.Report
{
    public class DepositSummaryBL : IDepositSummaryBL
    {
        private IDepositSummaryDA _IDepositSummaryDA;

        public DepositSummaryBL()
        {
            this._IDepositSummaryDA = MasterDAFactory.GetDAL<IDepositSummaryDA>(MasterDAFactory.DepositSummary);
        }

        public Model.General.ReturnValueInfo Save(IModelObject itemEntity, DefineConstantValue.EditStateEnum EditMode)
        {
            throw new NotImplementedException();
        }

        public DepositSummary_dps_Info DisplayRecord(IModelObject KeyObject)
        {
            throw new NotImplementedException();
        }

        public List<DepositSummary_dps_Info> SearchRecords(IModelObject searchCondition)
        {
            try
            {
                return this._IDepositSummaryDA.SearchRecords(searchCondition);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<DepositSummary_dps_Info> AllRecords()
        {
            throw new NotImplementedException();
        }
    }
}
