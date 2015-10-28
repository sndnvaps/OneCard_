using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.HHZX.ComsumeAccount;
using Model.General;

namespace BLL.IBLL.HHZX.ConsumeAccount
{
    /// <summary>
    /// 原始消费记录
    /// </summary>
    public interface ISourceConsumeRecordBL : IBaseBL<SourceConsumeRecord_scr_Info>
    {
        /// <summary>
        /// 批量插入消费原始数据
        /// </summary>
        /// <param name="listSrouce"></param>
        /// <returns></returns>
        ReturnValueInfo BatchInsertRecord(List<SourceConsumeRecord_scr_Info> listSrouce);
    }
}
