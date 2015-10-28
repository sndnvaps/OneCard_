using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.HHZX.Report;

namespace DAL.IDAL.Report
{
    public interface IPayRecordDA : IMainGeneralDA<PayRecord_prd_Info>
    {
        /// <summary>
        /// 支出统计
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        decimal PaymentCount(DateTime startDate, DateTime endDate);
    }
}
