using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.HHZX.ComsumeAccount;
using Model.IModel;
using Model.General;

namespace DAL.IDAL.HHZX.ConsumeAccount
{
    /// <summary>
    /// 卡用户账户余额信息
    /// </summary>
    public interface ICardUserAccountDA : IMainGeneralDA<CardUserAccount_cua_Info>
    {
        /// <summary>
        /// 同步用户账户并获取指定时间内的账户情况
        /// </summary>
        /// <param name="KeyObject"></param>
        /// <param name="dtDeadline">指定时间</param>
        /// <returns></returns>
        CardUserAccount_cua_Info SyncAccount(IModelObject KeyObject, DateTime dtDeadline);

        /// <summary>
        /// 获取催款名单
        /// </summary>
        /// <param name="identityNum"></param>
        /// <param name="departmentID"></param>
        /// <param name="Balance"></param>
        /// <param name="lWithFilter">是否需要排除默认默认全停餐的人员</param>
        /// <returns></returns>
        List<CardUserAccount_cua_Info> GetRemindList(string identityNum, Guid departmentID, decimal Balance, bool lWithFilter,string userName);

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
        /// <param name="listConsume">需要删除的的付款记录</param>
        /// <param name="listConsume">已确定的打卡记录</param>
        /// <returns></returns>
        ReturnValueInfo BatchSyncAccountDetail(List<PreConsumeRecord_pcs_Info> listUpdatePreCost, List<PreConsumeRecord_pcs_Info> listDelPreCost, List<ConsumeRecord_csr_Info> listConsume);

        /// <summary>
        /// 获取系统现存账户的总余额(同步时间为截止时间前)
        /// </summary>
        /// <param name="dtDeadline">截止时间</param>
        /// <returns></returns>
        decimal GetAccountTotalBalance(DateTime dtDeadline);

        /// <summary>
        /// 重设学生账户透支额
        /// </summary>
        /// <param name="OverdraftInfo">透支额信息</param>
        /// <returns></returns>
        ReturnValueInfo ResetAccountOverdraft(RechargeRecord_rcr_Info OverdraftInfo);
    }
}
