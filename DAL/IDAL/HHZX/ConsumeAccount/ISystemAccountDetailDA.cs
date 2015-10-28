using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.HHZX.ComsumeAccount;
using Model.HHZX.Report;
using Model.General;

namespace DAL.IDAL.HHZX.ConsumeAccount
{
    /// <summary>
    /// 系统资金明细
    /// </summary>
    public interface ISystemAccountDetailDA : IMainGeneralDA<SystemAccountDetail_sad_Info>
    {
        List<SystemAccountDetail_sad_Info> SearchDateSpanRecord(DateTime startDate, DateTime endDate);

        /// <summary>
        /// 发卡部收入
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        decimal CardDepartmentIncome(DateTime startDate, DateTime endDate);

        /// <summary>
        /// 订餐部收入
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        decimal BookDepartmentIncome(DateTime startDate, DateTime endDate);

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
