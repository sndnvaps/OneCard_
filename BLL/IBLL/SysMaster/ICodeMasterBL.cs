using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.SysMaster;

namespace BLL.IBLL.SysMaster
{
    public interface ICodeMasterBL : IDataBaseCommandBL<CodeMaster_cmt_Info>, IBaseBL<CodeMaster_cmt_Info>, IExtraBL
    {
        List<CodeMaster_cmt_Info> FindRecord(CodeMaster_cmt_Info info);

        /// <summary>
        /// 获取当前的就餐时段信息（不在时段中时则返回null值）
        /// </summary>
        /// <returns></returns>
        CodeMaster_cmt_Info GetCurrentMealSpanInfo();
    }
}
