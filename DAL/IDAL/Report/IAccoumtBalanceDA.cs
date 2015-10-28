using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.HHZX.Report;

namespace DAL.IDAL.Report
{
    public interface IAccoumtBalanceDA
    {
        /// <summary>
        /// 獲取金額
        /// </summary>
        /// <param name="infoObject"></param>
        /// <returns></returns>
        List<AccoumtBalance_atb_info> GetRecord(AccoumtBalance_atb_info infoObject);

    }
}
