using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.HHZX.MealBooking;
using Model.General;

namespace DAL.IDAL.HHZX.MealBooking
{
    public interface IBlacklistChangeRecordDA : IMainGeneralDA<BlacklistChangeRecord_blc_Info>
    {
        /// <summary>
        /// 批量更新黑名单记录状态
        /// </summary>
        /// <param name="listRecords"></param>
        /// <returns></returns>
        ReturnValueInfo UpdateBatchRecord(List<BlacklistChangeRecord_blc_Info> listRecords);
    }
}
