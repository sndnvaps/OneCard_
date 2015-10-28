using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.HHZX.Report;
using Model.General;

namespace BLL.IBLL.HHZX.ConsumeAccount
{
    /// <summary>
    /// 系统账户明细
    /// </summary>
    public interface ISystemAccountDetailBL : IMainGeneralBL
    {
        /// <summary>
        /// 部门收支统计
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        DepartmentBalance_dtb_Info DepartmentBalance(DepartmentBalance_dtb_Info query);

        /// <summary>
        /// 获得热水部收入
        /// </summary>
        /// <param name="dtQuery"></param>
        /// <returns></returns>
        decimal GetHotIncome(DateTime dtQuery);

        /// <summary>
        /// 获得其他收入
        /// </summary>
        /// <param name="dtQuery"></param>
        /// <returns></returns>
        decimal GetOrtherIncome(DateTime dtQuery);

        /// <summary>
        /// 设置热水部收入
        /// </summary>
        /// <param name="dtQuery"></param>
        /// <returns></returns>
        ReturnValueInfo SetHotIncome(DateTime dtQuery, decimal fIncome);

        /// <summary>
        /// 设置其他收入
        /// </summary>
        /// <param name="dtQuery"></param>
        /// <returns></returns>
        ReturnValueInfo SetOrtherIncome(DateTime dtQuery, decimal fIncome);
    }
}
