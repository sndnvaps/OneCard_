using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.HHZX.ComsumeAccount;
using Model.IModel;
using Model.General;

namespace BLL.IBLL.HHZX.ConsumeAccount
{
    /// <summary>
    /// 卡用户账户余额信息
    /// </summary>
    public interface ICardUserAccountBL : IBaseBL<CardUserAccount_cua_Info>
    {
        /// <summary>
        /// 同步用户账户并获取指定时间内的账户情况
        /// </summary>
        /// <param name="KeyObject"></param>
        /// <param name="dtDeadline">指定时间</param>
        /// <returns></returns>
        CardUserAccount_cua_Info SyncAccount(IModelObject KeyObject, DateTime dtDeadline);

        /// <summary>
        /// 获取批量用户账户余额
        /// </summary>
        /// <param name="listSource">查询条件（填入人员ID）</param>
        /// <param name="dtDeadline">查询截止日期</param>
        /// <returns></returns>
        List<CardUserAccount_cua_Info> GetUserAccountBalance(List<CardUserAccount_cua_Info> listSource, DateTime dtDeadline);

        /// <summary>
        /// 获取系统账户总余额
        /// </summary>
        /// <param name="dtDeadline"></param>
        /// <returns></returns>
        decimal GetAccountTotalBalance(DateTime dtDeadline);

        /// <summary>
        /// 获取催款名单
        /// </summary>
        /// <param name="identityNum"></param>
        /// <param name="departmentID"></param>
        /// <param name="Balance"></param>
        /// <param name="lWithFilter">是否需要排除默认默认全停餐的人员</param>
        /// <returns></returns>
        List<CardUserAccount_cua_Info> GetRemindList(string identityNum, Guid departmentID, decimal Balance, bool lWithFilter, string userName);

        /// <summary>
        /// 账户现金退款
        /// </summary>
        /// <param name="infoObject">退款信息</param>
        /// <returns></returns>
        ReturnValueInfo AccountCashReFund(IModelObject infoObject, string strReason);

        /// <summary>
        /// 同步账户明细
        /// </summary>
        /// <param name="listPreCost">已确定的付款记录</param>
        /// <param name="listConsume">已确定的打卡记录</param>
        /// <returns></returns>
        ReturnValueInfo BatchSyncAccountDetail(List<PreConsumeRecord_pcs_Info> listUpdatePreCost, List<PreConsumeRecord_pcs_Info> listDelPreCost, List<ConsumeRecord_csr_Info> listConsume);

        /// <summary>
        /// 重设学生账户透支额
        /// </summary>
        /// <param name="OverdraftInfo">透支额信息</param>
        /// <returns></returns>
        ReturnValueInfo ResetAccountOverdraft(RechargeRecord_rcr_Info OverdraftInfo);
    }
}
