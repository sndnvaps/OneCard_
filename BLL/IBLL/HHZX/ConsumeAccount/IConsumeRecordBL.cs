using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.HHZX.ComsumeAccount;
using Model.General;

namespace BLL.IBLL.HHZX.ConsumeAccount
{
    public interface IConsumeRecordBL : IBaseBL<ConsumeRecord_csr_Info>
    {
        /// <summary>
        /// 同步源消费数据
        /// </summary>
        /// <param name="listSourceRecord">源消费数据</param>
        /// <param name="strMealType">餐类型</param>
        /// <returns></returns>
        ReturnValueInfo BatchSyncSourceRecord(List<SourceConsumeRecord_scr_Info> listSourceRecord, string strMealType);

        /// <summary>
        /// 取得最后的消费记录
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        ConsumeRecord_csr_Info GetLastRecord(ConsumeRecord_csr_Info query);
    }
}
