using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL.IBLL.HHZX.Report;
using Model.HHZX.Report;
using DAL.IDAL.Report;
using DAL.Factory.HHZX;

namespace BLL.DAL.HHZX.Report
{
    public class CardFeeSummaryBL : ICardFeeSummaryBL
    {
        ICardFeeSummaryDA _ICardFeeSummaryDA;

        public CardFeeSummaryBL()
        {
            this._ICardFeeSummaryDA = MasterDAFactory.GetDAL<ICardFeeSummaryDA>(MasterDAFactory.CardFeeSummary);
        }

        public List<CardFeeSummary_cfs_Info> SearchRecords(CardFeeSummary_cfs_Info searchInfo)
        {
            try
            {
                return this._ICardFeeSummaryDA.SearchRecords(searchInfo);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
