using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Factory.HHZX
{
    public class MasterBLLFactory
    {
        /// <summary>
        /// 部门主档
        /// </summary>
        public static readonly string DepartmentMaster = "BLL.DAL.HHZX.UserInfomation.CardUserInfo.DepartmentMasterBL,BLL";

        /// <summary>
        /// 年级主档
        /// </summary>
        public static readonly string GradeMaster = "BLL.DAL.HHZX.UserInfomation.CardUserInfo.GradeMasterBL,BLL";

        /// <summary>
        /// 系统用户主档
        /// </summary>
        public static readonly string UserMaster = "BLL.DAL.HHZX.UserInfomation.SysUserInfo.UserMasterBL,BLL";

        /// <summary>
        /// 班级主档
        /// </summary>
        public static readonly string ClassMaster = "BLL.DAL.HHZX.UserInfomation.CardUserInfo.ClassMasterBL,BLL";

        /// <summary>
        /// 卡用户主档
        /// </summary>
        public static readonly string CardUserMaster = "BLL.DAL.HHZX.UserInfomation.CardUserInfo.CardUserMasterBL,BLL";

        /// <summary>
        /// 卡主档
        /// </summary>
        public static readonly string ConsumeCardMaster = "BLL.DAL.HHZX.UserCard.ConsumeCardMasterBL,BLL";

        /// <summary>
        /// 发卡信息
        /// </summary>
        public static readonly string UserCardPair = "BLL.DAL.HHZX.UserCard.UserCardPairBL,BLL";

        /// <summary>
        /// 充值信息（卡充值、卡退款、现金退款、批量充值、批量退款）
        /// </summary>
        public static readonly string RechargeRecord = "BLL.DAL.HHZX.ConsumeAccount.RechargeRecordBL,BLL";

        /// <summary>
        /// 预充值信息
        /// </summary>
        public static readonly string PreRechargeRecord = "BLL.DAL.HHZX.ConsumeAccount.PreRechargeRecordBL,BLL";

        /// <summary>
        /// 卡用户账户余额信息
        /// </summary>
        public static readonly string CardUserAccount = "BLL.DAL.HHZX.ConsumeAccount.CardUserAccountBL,BLL";

        /// <summary>
        /// 卡账户资金流动明细
        /// </summary>
        public static readonly string CardUserAccountDetail = "BLL.DAL.HHZX.ConsumeAccount.CardUserAccountDetailBL,BLL";

        /// <summary>
        /// 系统账户资金流动明细
        /// </summary>
        public static readonly string SystemAccountDetail = "BLL.DAL.HHZX.ConsumeAccount.SystemAccountDetailBL,BLL";

        /// <summary>
        /// 消费机主档
        /// </summary>
        public static readonly string ConsumeMachine = "BLL.DAL.HHZX.ConsumerDevice.ConsumeMachineBL,BLL";

        /// <summary>
        /// 消費记录
        /// </summary>
        public static readonly string ConsumeRecord = "BLL.DAL.HHZX.ConsumeAccount.ConsumeRecordBL,BLL";

        /// <summary>
        /// 预消费记录
        /// </summary>
        public static readonly string PreConsumeRecord = "BLL.DAL.HHZX.ConsumeAccount.PreConsumeRecordBL,BLL";

        /// <summary>
        /// 原始消费记录
        /// </summary>
        public static readonly string SourceConsumeRecord = "BLL.DAL.HHZX.ConsumeAccount.SourceConsumeRecordBL,BLL";

        /// <summary>
        /// 默认定餐
        /// </summary>
        public static readonly string PaymentUDGeneralSetting = "BLL.DAL.HHZX.MealBooking.PaymentUDGeneralSettingBL,BLL";

        /// <summary>
        /// 自定义定餐
        /// </summary>
        public static readonly string PaymentUDMealState = "BLL.DAL.HHZX.MealBooking.PaymentUDMealStateBL,BLL";

        /// <summary>
        /// 学生定餐情况过往记录
        /// </summary>
        public static readonly string MealBookingHistory = "BLL.DAL.HHZX.MealBooking.MealBookingHistoryBL,BLL";

        /// <summary>
        /// 黑名单操作记录
        /// </summary>
        public static readonly string BlacklistChangeRecord = "BLL.DAL.HHZX.MealBooking.BlacklistChangeRecordBL,BLL";

        /// <summary>
        /// 费用支出登记 
        /// </summary>
        public static readonly string PayRecord = "BLL.DAL.HHZX.Report.PayRecordBL,BLL";

        /// <summary>
        /// 定餐記錄，報表
        /// </summary>
        public static readonly string mealBookingReport = "BLL.DAL.HHZX.Report.MealBookingBL,BLL";

        /// <summary>
        ///  结转明细，报表
        /// </summary>
        public static readonly string AccoumtBalance = "BLL.DAL.HHZX.Report.AccoumtBalanceBL,BLL";

        /// <summary>
        /// 消费明细，报表
        /// </summary>
        public static readonly string PaymentBalance = "BLL.DAL.HHZX.Report.PaymentBalanceBL,BLL";

        /// <summary>
        /// 未就餐补充扣费明细,報表
        /// </summary>
        public static readonly string DeductionBalance = "BLL.DAL.HHZX.Report.DeductionBalanceBL,BLL";

        /// <summary>
        /// 帐户余额，报表
        /// </summary>
        public static readonly string MoneyBalance = "BLL.DAL.HHZX.Report.MoneyBalanceBL,BLL";

        /// <summary>
        /// 报表--存款汇总表
        /// </summary>
        public static readonly string DepositSummary = "BLL.DAL.HHZX.Report.DepositSummaryBL,BLL";

        /// <summary>
        /// 报表--饭卡汇总表
        /// </summary>
        public static readonly string CardFeeSummary = "BLL.DAL.HHZX.Report.CardFeeSummaryBL,BLL";

        /// <summary>
        /// 学生消费汇总表
        /// </summary>
        public static readonly string StudentCostSummary = "BLL.DAL.HHZX.Report.StudentCostSummaryBL,BLL";

        public static IBLL GetBLL<IBLL>(string accessorFullName)
        {
            try
            {
                Type accessorType = Type.GetType(accessorFullName, false);
                return (IBLL)Activator.CreateInstance(accessorType);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
