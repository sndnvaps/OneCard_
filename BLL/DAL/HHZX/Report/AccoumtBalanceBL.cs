using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL.IBLL.HHZX.Report;
using Model.HHZX.Report;
using DAL.IDAL.HHZX.ConsumerDevice;
using DAL.Factory.HHZX;
using Model.HHZX.ConsumerDevice;
using Common;
using DAL.IDAL.HHZX.ConsumeAccount;
using Model.HHZX.ComsumeAccount;
using DAL.IDAL.Report;
using BLL.IBLL.HHZX.ConsumeAccount;
using BLL.Factory.HHZX;

namespace BLL.DAL.HHZX.Report
{
    public class AccoumtBalanceBL : IAccoumtBalanceBL
    {
        private IAccoumtBalanceDA _iabDA;

        public AccoumtBalanceBL()
        {
            _iabDA = MasterDAFactory.GetDAL<IAccoumtBalanceDA>(MasterDAFactory.AccoumtBalance);
        }

        #region IBaseBL<AccoumtBalance_atb_info> 成员

        public Model.General.ReturnValueInfo InsertRecord(Model.HHZX.Report.AccoumtBalance_atb_info infoObject)
        {
            throw new NotImplementedException();
        }

        public Model.General.ReturnValueInfo UpdateRecord(Model.HHZX.Report.AccoumtBalance_atb_info infoObject)
        {
            throw new NotImplementedException();
        }

        public Model.General.ReturnValueInfo DeleteRecord(Model.IModel.IModelObject KeyObject)
        {
            throw new NotImplementedException();
        }

        public Model.HHZX.Report.AccoumtBalance_atb_info DisplayRecord(Model.IModel.IModelObject KeyObject)
        {
            throw new NotImplementedException();
        }

        public List<Model.HHZX.Report.AccoumtBalance_atb_info> SearchRecords(Model.IModel.IModelObject searchCondition)
        {
            List<AccoumtBalance_atb_info> returnList = new List<AccoumtBalance_atb_info>();
            try
            {
                AccoumtBalance_atb_info objInfo = searchCondition as AccoumtBalance_atb_info;
                returnList = _iabDA.GetRecord(objInfo);
            }
            catch
            {

            }
            return returnList;
        }

        public List<Model.HHZX.Report.AccoumtBalance_atb_info> AllRecords()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IBaseBL<AccoumtBalance_atb_info> Members

        public Model.General.ReturnValueInfo Save(Model.IModel.IModelObject itemEntity, DefineConstantValue.EditStateEnum EditMode)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
