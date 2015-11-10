using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sysBL = BLL.IBLL.SysMaster;
using sysFac = BLL.Factory.SysMaster;
using Model.HHZX.UserInfomation.CardUserInfo;
using BLL.IBLL.HHZX.ConsumerDevice;
using BLL.IBLL.HHZX.MealBooking;
using BLL.IBLL.HHZX.UserInfomation.CardUserInfo;
using BLL.IBLL.HHZX.UserCard;
using BLL.IBLL.HHZX.ConsumeAccount;
using BLL.Factory.HHZX;
using BLL.DAL.HHZX.ConsumeAccount;
using Model.HHZX.ConsumerDevice;
using System.Net;
using PaymentEquipment.IDevice;
using PaymentEquipment.DeviceFactory;
using Model.General;
using Model.SysMaster;
using Model.HHZX.MealBooking;

namespace WinCA.MealListUpload
{
    class MealWhiteListUploadService
    {
        #region 自定义变量
        /// <summary>
        /// 服务名称
        /// </summary>
        private string _ServiceName;

        Common.General _LocalLogger;
        /// <summary>
        /// 本地日志记录类
        /// </summary>
        public Common.General LocalLogger
        {
            get { return _LocalLogger; }
            set { _LocalLogger = value; }
        }

        private int _ErrRetryTimes;
        /// <summary>
        /// 操作失败后重复操作次数
        /// </summary>
        public int ErrRetryTimes
        {
            get { return _ErrRetryTimes; }
            set { _ErrRetryTimes = value; }
        }

        private int _ErrRetryInterval;
        /// <summary>
        /// 每次操作失败后等待时间间隔（单位：毫秒）
        /// </summary>
        public int ErrRetryInterval
        {
            get { return _ErrRetryInterval; }
            set { _ErrRetryInterval = value; }
        }

        /// <summary>
        /// 缓存的用户信息
        /// </summary>
        private List<CardUserMaster_cus_Info> m_ListUserInfos;
        private List<ConsumeMachineMaster_cmm_Info> m_ListMacInfos;

        private sysBL.ICodeMasterBL m_ICodeMasterBL;
        private IConsumeMachineBL m_IConsumeMachineBL;
        private IMealBookingHistoryBL m_IMealBookingHistoryBL;
        private IPaymentUDGeneralSettingBL m_IPaymentUDGeneralSettingBL;
        private IPaymentUDMealStateBL m_IPaymentUDMealStateBL;
        private ICardUserMasterBL m_ICardUserMasterBL;
        private IUserCardPairBL m_IUserCardPairBL;
        private ICardUserAccountBL m_ICardUserAccountBL;
        private IRechargeRecordBL m_IRechargeRecordBL;
        private IPreConsumeRecordBL m_IPreConsumeRecordBL;
        private IBlacklistChangeRecordBL m_IBlacklistChangeRecordBL;
        private IPreRechargeRecordBL m_IPreRechargeRecordBL;

        #endregion

        public MealWhiteListUploadService()
        {
            this._ServiceName = "MWLUServ";

            InitBLL();
        }

        /// <summary>
        /// 数据逻辑类初始化
        /// </summary>
        private void InitBLL()
        {
            this.m_ICodeMasterBL = sysFac.MasterBLLFactory.GetBLL<sysBL.ICodeMasterBL>(sysFac.MasterBLLFactory.CodeMaster_cmt);
            this.m_IConsumeMachineBL = MasterBLLFactory.GetBLL<IConsumeMachineBL>(MasterBLLFactory.ConsumeMachine);
            this.m_IMealBookingHistoryBL = MasterBLLFactory.GetBLL<IMealBookingHistoryBL>(MasterBLLFactory.MealBookingHistory);
            this.m_IPaymentUDGeneralSettingBL = MasterBLLFactory.GetBLL<IPaymentUDGeneralSettingBL>(MasterBLLFactory.PaymentUDGeneralSetting);
            this.m_IPaymentUDMealStateBL = MasterBLLFactory.GetBLL<IPaymentUDMealStateBL>(MasterBLLFactory.PaymentUDMealState);
            this.m_ICardUserMasterBL = MasterBLLFactory.GetBLL<ICardUserMasterBL>(MasterBLLFactory.CardUserMaster);
            this.m_IUserCardPairBL = MasterBLLFactory.GetBLL<IUserCardPairBL>(MasterBLLFactory.UserCardPair);
            this.m_ICardUserAccountBL = MasterBLLFactory.GetBLL<ICardUserAccountBL>(MasterBLLFactory.CardUserAccount);
            this.m_IRechargeRecordBL = MasterBLLFactory.GetBLL<RechargeRecordBL>(MasterBLLFactory.RechargeRecord);
            this.m_IPreConsumeRecordBL = MasterBLLFactory.GetBLL<IPreConsumeRecordBL>(MasterBLLFactory.PreConsumeRecord);
            this.m_IBlacklistChangeRecordBL = BLL.Factory.HHZX.MasterBLLFactory.GetBLL<IBlacklistChangeRecordBL>(BLL.Factory.HHZX.MasterBLLFactory.BlacklistChangeRecord);
            this.m_IPreRechargeRecordBL = MasterBLLFactory.GetBLL<IPreRechargeRecordBL>(MasterBLLFactory.PreRechargeRecord);
        }

        /// <summary>
        /// 上传名单
        /// </summary>
        /// <returns></returns>
        public bool Upload()
        {
            if (_LocalLogger == null)
            {
                _LocalLogger = new Common.General(Common.General.BindLocalLogInfo());
            }
            try
            {
                GetAllCardUserInfos();

                GetInUsingMacInfoList();

                TeacherWhiteListUpload();

                StudentWhiteListUpload();
            }
            catch (Exception ex)
            {
                Console.WriteLine(getCWStyle(ex.Message, SystemLog.SystemLog.LogType.Error));
                return false;
            }

            return true;
        }

        /// <summary>
        /// 获取全部卡用户信息
        /// </summary>
        private void GetAllCardUserInfos()
        {
            List<CardUserMaster_cus_Info> listCardUserInfos = this.m_ICardUserMasterBL.SearchRecords(new CardUserMaster_cus_Info());
            if (listCardUserInfos != null)
            {
                listCardUserInfos = listCardUserInfos.Where(x => x.PairInfo != null && x.cus_lValid).ToList();
            }
            this.m_ListUserInfos = listCardUserInfos;
        }

        /// <summary>
        /// 教职工消费白名单上传
        /// </summary>
        void TeacherWhiteListUpload()
        {
            try
            {
                if (this.m_ListUserInfos == null)
                {
                    Console.WriteLine(getCWStyle("没有可用的全部卡用户信息列表。", SystemLog.SystemLog.LogType.Warning));
                    return;
                }

                List<CardUserMaster_cus_Info> listTeachers = this.m_ListUserInfos.Where(x => x.cus_cIdentityNum == Common.DefineConstantValue.CodeMasterDefine.KEY2_SIOT_CardUserIdentity_Staff).ToList();
                if (listTeachers == null)
                {
                    Console.WriteLine(getCWStyle("没有获取到可用的教职工信息列表。", SystemLog.SystemLog.LogType.Warning));
                    return;
                }
                Console.WriteLine(getCWStyle("获取到持卡教职工名单：" + listTeachers.Count + "个。", SystemLog.SystemLog.LogType.Trace));

                List<ConsumeMachineMaster_cmm_Info> listTechMacs = this.m_ListMacInfos;
                //if (listTechMacs != null)
                //{
                //    listTechMacs = listTechMacs.Where(x => x.cmm_cUsageType == Common.DefineConstantValue.ConsumeMachineType.TeachPay.ToString()).ToList();
                //}

                if (listTechMacs != null && listTeachers != null)
                {
                    Console.WriteLine(getCWStyle("获取教职工可用消费机：" + listTechMacs.Count + "台。", SystemLog.SystemLog.LogType.Trace));

                    foreach (ConsumeMachineMaster_cmm_Info macItem in listTechMacs)
                    {
                        UploadWhiteListToMachine(macItem, listTeachers, true);
                    }
                }
                else
                {
                    Console.WriteLine(getCWStyle("没有可用的教职工消费机信息。", SystemLog.SystemLog.LogType.Warning));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(getCWStyle("上传教职工可就餐名单失败，异常信息：" + ex.Message, SystemLog.SystemLog.LogType.Error));
            }
        }

        /// <summary>
        /// 学生消费白名单上传
        /// </summary>
        void StudentWhiteListUpload()
        {
            try
            {
                CodeMaster_cmt_Info mealInfo = this.m_ICodeMasterBL.GetCurrentMealSpanInfo();
                if (mealInfo == null)
                {
                    Console.WriteLine(getCWStyle("没有可用的就餐时间信息", SystemLog.SystemLog.LogType.Warning));
                }
                else
                {
                    string strMealType = mealInfo.cmt_cKey1.Trim();
                    decimal fMealCost = mealInfo.cmt_fNumber;
                    string strMealBeginSpan = mealInfo.cmt_cRemark.Trim();
                    string strMealEndSpan = mealInfo.cmt_cRemark2.Trim();
                    DateTime dtMealBeginSpan = DateTime.Parse(strMealBeginSpan);
                    DateTime dtMealEndSpan = DateTime.Parse(strMealEndSpan);

                    Console.WriteLine(getCWStyle("进入学生用餐名单上传时段。" + Environment.NewLine + "餐类型：" + strMealType + ";餐金额：" + fMealCost.ToString() + "；上传开始时间：" + strMealBeginSpan + "；上传结束时间：" + strMealEndSpan, SystemLog.SystemLog.LogType.Trace));

                    //获取在用的消费机信息
                    List<ConsumeMachineMaster_cmm_Info> listUsingMacInfos = this.m_ListMacInfos;
                    if (listUsingMacInfos != null)
                    {
                        listUsingMacInfos = listUsingMacInfos.Where(x => x.cmm_cUsageType != Common.DefineConstantValue.ConsumeMachineType.TeachPay.ToString()).ToList();
                    }
                    Console.WriteLine(getCWStyle("相关学生消费机数量：" + listUsingMacInfos.Count + "条。", SystemLog.SystemLog.LogType.Trace));

                    if (listUsingMacInfos != null)
                    {
                        if (this.m_ListUserInfos == null)
                        {
                            Console.WriteLine(getCWStyle("没有可用的全部卡用户信息列表。", SystemLog.SystemLog.LogType.Warning));
                            return;
                        }

                        //获取学生信息
                        List<CardUserMaster_cus_Info> listStudent = this.m_ListUserInfos.Where(x => x.cus_cIdentityNum == Common.DefineConstantValue.CodeMasterDefine.KEY2_SIOT_CardUserIdentity_Student && !x.cus_lIsGraduate).ToList();
                        if (listStudent == null)
                        {
                            Console.WriteLine(getCWStyle("没有获取到可用的学生信息列表。", SystemLog.SystemLog.LogType.Warning));
                            return;
                        }
                        Console.WriteLine(getCWStyle("获取到持卡学生名单：" + listStudent.Count + "个。", SystemLog.SystemLog.LogType.Trace));

                        List<MealBookingHistory_mbh_Info> listMealPlanInfos = this.m_IMealBookingHistoryBL.GetAllCardUsersMealPlan(dtMealBeginSpan.Date, strMealType, fMealCost, this._ServiceName);

                        if (listMealPlanInfos != null && listMealPlanInfos.Count > 0)
                        {
                            #region 正常定餐名单上传

                            Console.WriteLine(getCWStyle("定餐计划总数量：" + listMealPlanInfos.Count + "条。", SystemLog.SystemLog.LogType.Trace));

                            ReturnValueInfo rvInfo = this.m_IMealBookingHistoryBL.InsertBatchRecords(listMealPlanInfos);
                            if (rvInfo.boolValue && !rvInfo.isError)
                            {
                                Console.WriteLine(getCWStyle("成功保存定餐历史记录。", SystemLog.SystemLog.LogType.Trace));
                            }
                            else
                            {
                                Console.WriteLine(getCWStyle("保存定餐历史记录失败。", SystemLog.SystemLog.LogType.Error));
                            }

                            List<CardUserMaster_cus_Info> listIsSetUsers;
                            List<CardUserMaster_cus_Info> listUnSetUsers;
                            GetMealUserList(listMealPlanInfos, out listIsSetUsers, out listUnSetUsers);

                            Console.WriteLine(getCWStyle("停餐名单数量：" + listUnSetUsers.Count + "条。", SystemLog.SystemLog.LogType.Trace));

                            int iSet = listMealPlanInfos.Count(x => x.mbh_lIsSet);
                            Console.WriteLine(getCWStyle("开餐名单数量：" + listIsSetUsers.Count + "条。", SystemLog.SystemLog.LogType.Trace));

                            foreach (ConsumeMachineMaster_cmm_Info macItem in listUsingMacInfos)
                            {
                                if (macItem == null)
                                {
                                    continue;
                                }
                                try
                                {
                                    UploadWhiteListToMachine(macItem, listIsSetUsers, false);

                                    RemoveWhiteListToMachine(macItem, listUnSetUsers);
                                }
                                catch (Exception exx)
                                {
                                    Console.WriteLine(getCWStyle(macItem.cmm_iMacNo.ToString() + "号机，发送名单异常：" + exx.Message, SystemLog.SystemLog.LogType.Error));
                                }
                            }

                            #endregion

                            #region 星期六日开放加菜机、饮料机打卡

                            if (DateTime.Now.DayOfWeek == DayOfWeek.Sunday || DateTime.Now.DayOfWeek == DayOfWeek.Saturday)
                            {
                                List<ConsumeMachineMaster_cmm_Info> listWeekendMacInfos = listUsingMacInfos.Where(x =>
                                    x.cmm_cUsageType == Common.DefineConstantValue.ConsumeMachineType.MedicalPay.ToString()
                                    || x.cmm_cUsageType == Common.DefineConstantValue.ConsumeMachineType.DrinkPay.ToString()
                                    || x.cmm_cUsageType == Common.DefineConstantValue.ConsumeMachineType.StuPay.ToString()
                                    || x.cmm_cUsageType == Common.DefineConstantValue.ConsumeMachineType.HotWaterPay.ToString()).ToList();

                                foreach (ConsumeMachineMaster_cmm_Info macItem in listWeekendMacInfos)
                                {
                                    if (macItem == null)
                                    {
                                        continue;
                                    }
                                    try
                                    {
                                        UploadWhiteListToMachine(macItem, listUnSetUsers, false);
                                    }
                                    catch (Exception exx)
                                    {
                                        Console.WriteLine(getCWStyle(macItem.cmm_iMacNo.ToString() + "号机，发送周末名单异常：" + exx.Message, SystemLog.SystemLog.LogType.Error));
                                    }
                                }
                            }

                            #endregion
                        }
                        else
                        {
                            Console.WriteLine(getCWStyle("获取定餐计划信息失败。", SystemLog.SystemLog.LogType.Warning));
                        }

                        Console.WriteLine(getCWStyle("停餐名单上传服务结束。", SystemLog.SystemLog.LogType.Trace));
                    }
                    else
                    {
                        Console.WriteLine(getCWStyle("获取消费机信息列表失败。", SystemLog.SystemLog.LogType.Error));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(getCWStyle(ex.Message, SystemLog.SystemLog.LogType.Error));
            }
        }

        /// <summary>
        /// 获取就餐用户列表
        /// </summary>
        /// <param name="listTotalMeal">用餐情况列表</param>
        /// <param name="listIsSetUsers">返回，开餐用户</param>
        /// <param name="listUnSetUsers">返回，停餐用户</param>
        void GetMealUserList(List<MealBookingHistory_mbh_Info> listTotalMeal, out List<CardUserMaster_cus_Info> listIsSetUsers, out List<CardUserMaster_cus_Info> listUnSetUsers)
        {
            listIsSetUsers = new List<CardUserMaster_cus_Info>();
            listUnSetUsers = new List<CardUserMaster_cus_Info>();

            if (listTotalMeal != null && this.m_ListUserInfos != null)
            {
                foreach (MealBookingHistory_mbh_Info itemMeal in listTotalMeal)
                {
                    CardUserMaster_cus_Info cardUser = this.m_ListUserInfos.Find(x => x.cus_cRecordID == itemMeal.mbh_cTargetID);
                    if (cardUser != null)
                    {
                        if (itemMeal.mbh_lIsSet)
                        {
                            listIsSetUsers.Add(cardUser);
                        }
                        else
                        {
                            listUnSetUsers.Add(cardUser);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 获取所有在用的消费机列表
        /// </summary>
        /// <returns></returns>
        private List<ConsumeMachineMaster_cmm_Info> GetInUsingMacInfoList()
        {
            List<ConsumeMachineMaster_cmm_Info> listUsingMacInfos = this.m_IConsumeMachineBL.SearchRecords(new ConsumeMachineMaster_cmm_Info()
            {
                cmm_cStatus = Common.DefineConstantValue.ConsumeMachineStatus.Using.ToString()
            });
            listUsingMacInfos = listUsingMacInfos.Where(x => x.cmm_lIsActive == true).ToList();

            this.m_ListMacInfos = listUsingMacInfos;
            return listUsingMacInfos;
        }

        /// <summary>
        /// 上传白名单到消费机
        /// </summary>
        /// <param name="macInfo">消费机信息</param>
        /// <param name="listUsers">白名单用户信息</param>
        ///  <param name="IsClearedOldList">是否清空旧名单</param>
        void UploadWhiteListToMachine(ConsumeMachineMaster_cmm_Info macInfo, List<CardUserMaster_cus_Info> listUsers, bool IsClearedOldList)
        {
            try
            {
                if (macInfo != null && listUsers != null && listUsers.Count > 0)
                {
                    int iMacNo = macInfo.cmm_iMacNo;
                    int iPort = macInfo.cmm_iPort;
                    IPAddress ipAddr = IPAddress.Parse(macInfo.cmm_cIPAddr);
                    bool resPing = Common.General.Ping(ipAddr.ToString());
                    if (resPing)
                    {
                        AbstractPayDevice device = PaymentDeviceFactory.CreateDevice(PaymentDeviceFactory.EastRiverDevice);
                        ReturnValueInfo rvInfo = device.Conn(ipAddr, iPort, iMacNo);
                        if (rvInfo.boolValue && !rvInfo.isError)
                        {
                            if (IsClearedOldList)
                            {
                                device.RemoveAllWhitelist();
                                Console.WriteLine(getCWStyle("消费机连接成功，已清除所有历史白名单：" + iMacNo + "号", SystemLog.SystemLog.LogType.Trace));
                            }

                            foreach (CardUserMaster_cus_Info techItem in listUsers)
                            {
                                try
                                {
                                    ReturnValueInfo rvAdd = device.AddWhitelist(techItem.PairInfo.ucp_iCardNo.ToString());
                                }
                                catch (Exception exAdd)
                                {
                                    Console.WriteLine(getCWStyle("添加白名单卡失败，卡号：" + techItem.PairInfo.ucp_iCardNo + "。异常信息：" + exAdd.Message, SystemLog.SystemLog.LogType.Error));
                                }

                            }
                        }
                        else
                        {
                            Console.WriteLine(getCWStyle("消费机可以通信，但无法连接：" + iMacNo + "号", SystemLog.SystemLog.LogType.Error));
                        }
                    }
                    else
                    {
                        Console.WriteLine(getCWStyle("消费机无法通信：" + iMacNo + "号", SystemLog.SystemLog.LogType.Error));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(getCWStyle(ex.Message, SystemLog.SystemLog.LogType.Error));
            }
        }

        /// <summary>
        /// 从消费机移除白名单
        /// </summary>
        /// <param name="macInfo">消费机信息</param>
        /// <param name="listUsers">白名单用户信息</param>
        void RemoveWhiteListToMachine(ConsumeMachineMaster_cmm_Info macInfo, List<CardUserMaster_cus_Info> listUsers)
        {
            try
            {
                if (macInfo != null && listUsers != null && listUsers.Count > 0)
                {
                    int iMacNo = macInfo.cmm_iMacNo;
                    int iPort = macInfo.cmm_iPort;
                    IPAddress ipAddr = IPAddress.Parse(macInfo.cmm_cIPAddr);
                    bool resPing = Common.General.Ping(ipAddr.ToString());
                    if (resPing)
                    {
                        AbstractPayDevice device = PaymentDeviceFactory.CreateDevice(PaymentDeviceFactory.EastRiverDevice);
                        ReturnValueInfo rvInfo = device.Conn(ipAddr, iPort, iMacNo);
                        if (rvInfo.boolValue && !rvInfo.isError)
                        {
                            foreach (CardUserMaster_cus_Info techItem in listUsers)
                            {
                                ReturnValueInfo rvRemove = device.RemoveWhitelist(techItem.PairInfo.ucp_iCardNo.ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private string getCWStyle(string strContent, SystemLog.SystemLog.LogType? logType)
        {
            strContent = "* " + strContent + " " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            if (logType != null)
            {
                this._LocalLogger.WriteLog(strContent, string.Empty, logType.Value);
            }
            return strContent;
        }
    }
}
