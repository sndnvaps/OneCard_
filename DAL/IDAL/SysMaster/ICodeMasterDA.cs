using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.Base;
using Model.SysMaster;

namespace DAL.IDAL.SysMaster
{
    public interface ICodeMasterDA : IDataBaseCommandDA<CodeMaster_cmt_Info>, IMainDA<CodeMaster_cmt_Info>, IExtraDA
    {
        List<CodeMaster_cmt_Info> FindRecord(CodeMaster_cmt_Info info);

        /// <summary>
        /// 获取当前的就餐时段信息（不在时段中时则返回null值）
        /// </summary>
        /// <returns></returns>
        CodeMaster_cmt_Info GetCurrentMealSpanInfo();
    }
}
