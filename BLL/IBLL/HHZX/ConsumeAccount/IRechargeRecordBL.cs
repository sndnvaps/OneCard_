using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.HHZX.ComsumeAccount;
using Model.HHZX.Report;
using Model.General;
using Model.IModel;
using Model.HHZX.UserCard;

namespace BLL.IBLL.HHZX.ConsumeAccount
{
    /// <summary>
    /// 充值记录（卡充值、卡退款、现金退款、批量充值、批量退款）
    /// </summary>
    public interface IRechargeRecordBL : IBaseBL<RechargeRecord_rcr_Info>
    {
        /// <summary>
        /// 增减款明细
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        List<AmountOfChange_aoc_Info> AccountDetailList(AmountOfChange_aoc_Info query);

        /// <summary>
        /// 插入充值记录（带充值连带逻辑）
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        ReturnValueInfo InsertRechargeRecord(IModelObject itemEntity);

        /// <summary>
        /// 更新充值记录
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        ReturnValueInfo UpdateRechargeRecord(List<RechargeRecord_rcr_Info> listRecord, decimal fPreCostRecharge);

        /// <summary>
        /// 更新充值记录
        /// </summary>
        /// <param name="listRecord">预充值记录</param>
        /// <param name="PairInfo">发卡信息</param>
        /// <param name="fPreCostRecharge">需支付金额</param>
        /// <returns></returns>
        ReturnValueInfo UpdateRechargeRecord(List<PreRechargeRecord_prr_Info> listRecord, List<RechargeRecord_rcr_Info> listRechargeRecords, decimal fPreCostRecharge);

        /// <summary>
        /// 删除充值记录（带充值连带逻辑）
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        ReturnValueInfo DeleteRechargeRecord(IModelObject itemEntity);

        /// <summary>
        /// 现金退款
        /// </summary>
        /// <param name="refundRecord">退款记录</param>
        /// <param name="fPreCostRecharge">需支付金额</param>
        /// <returns></returns>
        ReturnValueInfo CashRefund(RechargeRecord_rcr_Info refundRecord, decimal fPreCostRecharge);

        /// <summary>
        /// 搜寻结果
        /// </summary>
        /// <param name="itemEntity">条件</param>
        /// <param name="dtBegin">开始时间</param>
        /// <param name="dtEnd">结束时间</param>
        /// <returns></returns>
        List<RechargeRecord_rcr_Info> SearchRecords(IModelObject itemEntity, DateTime dtBegin, DateTime dtEnd);
    }
}
