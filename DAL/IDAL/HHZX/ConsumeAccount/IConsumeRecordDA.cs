using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.HHZX.ComsumeAccount;
using Model.General;

namespace DAL.IDAL.HHZX.ConsumeAccount
{
    public interface IConsumeRecordDA : IMainGeneralDA<ConsumeRecord_csr_Info>
    {
        /// <summary>
        /// 同步源消费数据
        /// </summary>
        /// <param name="listSourceRecord">源消费数据</param>
        /// <param name="mealType">餐类型</param>
        /// <returns></returns>
        ReturnValueInfo BatchSyncSourceRecord(List<SourceConsumeRecord_scr_Info> listSourceRecord, string strMealType);

        /// <summary>
        /// 获取班級消費記錄
        /// </summary>
        /// <param name="classID"></param>
        /// <returns></returns>
        List<ConsumeRecord_csr_Info> GetClassConsumeRecord(Guid classID, DateTime dt);

        /// <summary>
        /// 饭堂消费收入
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        decimal CanteenIncome(DateTime startDate, DateTime endDate);

        /// <summary>
        /// 加菜机收入
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        decimal CanteenPlusIncome(DateTime startDate, DateTime endDate);

        /// <summary>
        /// 热水收入
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        decimal HotWaterIncome(DateTime startDate, DateTime endDate);

        /// <summary>
        /// 教师消费收入 
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        decimal TeacherPayment(DateTime startDate, DateTime endDate);

        /// <summary>
        /// 饮料收入
        /// </summary>
        /// <param name="dtStart"></param>
        /// <param name="dtEnd"></param>
        /// <returns></returns>
        decimal DrinkIncome(DateTime dtStart, DateTime dtEnd);

        /// <summary>
        /// 取得最后的消费记录
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        ConsumeRecord_csr_Info GetLastRecord(ConsumeRecord_csr_Info query);

    }
}
