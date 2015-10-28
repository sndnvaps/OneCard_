using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL.IBLL.HHZX.ConsumeAccount;
using DAL.IDAL.HHZX.ConsumeAccount;
using DAL.Factory.HHZX;
using Model.IModel;
using Model.HHZX.ComsumeAccount;

namespace BLL.DAL.HHZX.ConsumeAccount
{
    /// <summary>
    /// 账户资金流动明细
    /// </summary>
    public class CardUserAccountDetailBL : ICardUserAccountDetailBL
    {

        private ICardUserAccountDetailDA _icuadDA;

        public CardUserAccountDetailBL()
        {
            this._icuadDA = MasterDAFactory.GetDAL<ICardUserAccountDetailDA>(MasterDAFactory.CardUserAccountDetail);
        }

        #region IMainGeneralBL Members

        public List<CardUserAccountDetail_cuad_Info> AllRecords()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IMainBL Members

        public CardUserAccountDetail_cuad_Info DisplayRecord(Model.IModel.IModelObject itemEntity)
        {
            throw new NotImplementedException();
        }

        public List<CardUserAccountDetail_cuad_Info> SearchRecords(Model.IModel.IModelObject itemEntity)
        {
            try
            {
                List<CardUserAccountDetail_cuad_Info> listObj = new List<CardUserAccountDetail_cuad_Info>();
                List<CardUserAccountDetail_cuad_Info> cuadList = _icuadDA.SearchRecords(itemEntity);
                if (cuadList != null)
                {
                    cuadList = cuadList.OrderBy(p => p.cuad_dOptTime).ToList();
                    foreach (CardUserAccountDetail_cuad_Info info in cuadList)
                    {
                        listObj.Add(info);
                    }
                }

                return listObj;
            }
            catch
            {
                throw;
            }
        }

        public Model.General.ReturnValueInfo Save(Model.IModel.IModelObject itemEntity, Common.DefineConstantValue.EditStateEnum EditMode)
        {
            throw new NotImplementedException();
        }

        #endregion

        public List<CardUserAccountDetail_cuad_Info> SearchRecords(IModelObject itemEntity, DateTime dtBegin, DateTime dtEnd)
        {
            try
            {
                return this._icuadDA.SearchRecords(itemEntity, dtBegin, dtEnd);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
