using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.HHZX.ComsumeAccount;
using Model.General;

namespace DAL.IDAL.HHZX.ConsumeAccount
{
    /// <summary>
    /// 消费原始记录
    /// </summary>
    public interface ISourceConsumeRecordDA : IMainGeneralDA<SourceConsumeRecord_scr_Info>
    {
        /// <summary>
        /// 批量插入消费原始数据
        /// </summary>
        /// <param name="listSrouce"></param>
        /// <returns></returns>
        ReturnValueInfo BatchInsertRecord(List<SourceConsumeRecord_scr_Info> listSrouce);
    }
}
