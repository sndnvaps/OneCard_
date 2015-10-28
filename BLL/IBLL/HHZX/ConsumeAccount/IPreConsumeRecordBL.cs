using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.HHZX.ComsumeAccount;
using Model.General;

namespace BLL.IBLL.HHZX.ConsumeAccount
{
    /// <summary>
    /// 预消费记录
    /// </summary>
    public interface IPreConsumeRecordBL : IBaseBL<PreConsumeRecord_pcs_Info>
    {
        ReturnValueInfo BatchSolveUncertainRecord(List<PreConsumeRecord_pcs_Info> listRecords, bool isSettled);
    }
}
