using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.HHZX.ComsumeAccount;
using Model.General;

namespace DAL.IDAL.HHZX.ConsumeAccount
{
    /// <summary>
    /// 预消费记录
    /// </summary>
    public interface IPreConsumeRecordDA : IMainGeneralDA<PreConsumeRecord_pcs_Info>
    {
        /// <summary>
        /// 批量处理不确定扣费记录
        /// </summary>
        /// <param name="listRecords">被处理记录</param>
        /// <param name="isSettled">是否结算</param>
        /// <returns></returns>
        ReturnValueInfo BatchSolveUncertainRecord(List<PreConsumeRecord_pcs_Info> listRecords, bool isSettled);
    }
}
