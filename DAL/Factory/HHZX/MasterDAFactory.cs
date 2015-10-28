using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Factory.HHZX
{
    public class MasterDAFactory
    {
        /// <summary>
        /// 部门主档
        /// </summary>
        public static readonly string DepartmentMaster = "DAL.SqlDAL.HHZX.UserInformation.CardUserInfo.DepartmentMasterDA,DAL";

        /// <summary>
        /// 年级主档
        /// </summary>
        public static readonly string GradeMaster = "DAL.SqlDAL.HHZX.UserInformation.CardUserInfo.GradeMasterDA,DAL";

        /// <summary>
        /// 系统用户主档
        /// </summary>
        public static readonly string UserMaster = "DAL.SqlDAL.HHZX.UserInformation.SysUserInfo.UserMasterDA,DAL";

        /// <summary>
        /// 班级主档
        /// </summary>
        public static readonly string ClassMaster = "DAL.SqlDAL.HHZX.UserInformation.CardUserInfo.ClassMasterDA,DAL";

        /// <summary>
        /// 卡用户主档
        /// </summary>
        public static readonly string CardUserMaster = "DAL.SqlDAL.HHZX.UserInformation.CardUserInfo.CardUserMasterDA,DAL";

        /// <summary>
        /// 卡主档
        /// </summary>
        public static readonly string ConsumeCardMaster = "DAL.SqlDAL.HHZX.UserCard.ConsumeCardMasterDA,DAL";

        /// <summary>
        /// 发卡信息
        /// </summary>
        public static readonly string UserCardPair = "DAL.SqlDAL.HHZX.UserCard.UserCardPairDA,DAL";

        /// <summary>
        /// 充值记录（卡充值、卡退款、现金退款、批量充值、批量退款）
        /// </summary>
        public static readonly string RechargeRecord = "DAL.SqlDAL.HHZX.ConsumeAccount.RechargeRecordDA,DAL";

        /// <summary>
        ///  预充值记录
        /// </summary>
        public static readonly string PreRechargeRecord = "DAL.SqlDAL.HHZX.ConsumeAccount.PreRechargeRecordDA,DAL";

        /// <summary>
        /// 卡用户账户余额信息
        /// </summary>
        public static readonly string CardUserAccount = "DAL.SqlDAL.HHZX.ConsumeAccount.CardUserAccountDA,DAL";

        /// <summary>
        /// 卡账户资金流动详细信息
        /// </summary>
        public static readonly string CardUserAccountDetail = "DAL.SqlDAL.HHZX.ConsumeAccount.CardUserAccountDetailDA,DAL";

        /// <summary>
        /// 系统账户资金流动详细信息
        /// </summary>
        public static readonly string SystemAccountDetail = "DAL.SqlDAL.HHZX.ConsumeAccount.SystemAccountDetailDA,DAL";

        /// <summary>
        /// 消费机主档
        /// </summary>
        public static readonly string ConsumeMachine = "DAL.SqlDAL.HHZX.ConsumerDevice.ConsumeMachineDA,DAL";

        /// <summary>
        /// 消费记录
        /// </summary>
        public static readonly string ConsumeRecord = "DAL.SqlDAL.HHZX.ConsumeAccount.ConsumeRecordDA,DAL";

        /// <summary>
        /// 预消费记录
        /// </summary>
        public static readonly string PreConsumeRecord = "DAL.SqlDAL.HHZX.ConsumeAccount.PreConsumeRecordDA,DAL";

        /// <summary>
        /// 原始消费记录
        /// </summary>
        public static readonly string SourceConsumeRecord = "DAL.SqlDAL.HHZX.ConsumeAccount.SourceConsumeRecordDA,DAL";

        /// <summary>
        /// 默认定餐
        /// </summary>
        public static readonly string PaymentUDGeneralSetting = "DAL.SqlDAL.HHZX.MealBooking.PaymentUDGeneralSettingDA,DAL";

        /// <summary>
        /// 自定义定餐
        /// </summary>
        public static readonly string PaymentUDMealState = "DAL.SqlDAL.HHZX.MealBooking.PaymentUDMealStateDA,DAL";

        /// <summary>
        /// 定餐过往记录
        /// </summary>
        public static readonly string MealBookingHistory = "DAL.SqlDAL.HHZX.MealBooking.MealBookingHistoryDA,DAL";

        /// <summary>
        /// 黑名单操作记录
        /// </summary>
        public static readonly string BlacklistChangeRecord = "DAL.SqlDAL.HHZX.MealBooking.BlacklistChangeRecordDA,DAL";

        /// <summary>
        /// 支出登记 
        /// </summary>
        public static readonly string PayRecord = "DAL.SqlDAL.HHZX.Report.PayRecordDA,DAL";

        /// <summary>
        /// 定餐記錄,報表
        /// </summary>
        public static readonly string MealBookingReport = "DAL.SqlDAL.HHZX.Report.MealBookingDA,DAL";

        /// <summary>
        /// 結轉明細，報表
        /// </summary>
        public static readonly string AccoumtBalance = "DAL.SqlDAL.HHZX.Report.AccoumtBalanceDA,DAL";

        /// <summary>
        /// 消费明细，报表
        /// </summary>
        public static readonly string PaymentBalance = "DAL.SqlDAL.HHZX.Report.PaymentBalanceDA,DAL";

        /// <summary>
        /// 未就餐补充扣费明细，報表
        /// </summary>
        public static readonly string DeductionBalance = "DAL.SqlDAL.HHZX.Report.DeductionBalanceDA,DAL";

        /// <summary>
        /// 帐户余额，报表
        /// </summary>
        public static readonly string MoneyBalance = "DAL.SqlDAL.HHZX.Report.MoneyBalanceDA,DAL";

        /// <summary>
        /// 报表--存款汇总表
        /// </summary>
        public static readonly string DepositSummary = "DAL.SqlDAL.HHZX.Report.DepositSummaryDA,DAL";

        /// <summary>
        /// 报表--饭卡汇总表
        /// </summary>
        public static readonly string CardFeeSummary = "DAL.SqlDAL.HHZX.Report.CardFeeSummaryDA,DAL";

        /// <summary>
        /// 学生消费汇总表
        /// </summary>
        public static readonly string StudentCostSummary = "DAL.SqlDAL.HHZX.Report.StudentCostSummaryDA,DAL";

        /// <summary>
        /// 根据Accessor接口获得对应的DAL
        /// </summary>
        /// <typeparam name="IAccessor"></typeparam>
        /// <param name="accessorFullName"></param>
        /// <returns></returns>
        public static IDAL GetDAL<IDAL>(string accessorFullName)
        {
            //动态创建实体类型
            try
            {
                Type accessorType = Type.GetType(accessorFullName, false);
                return (IDAL)Activator.CreateInstance(accessorType);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
