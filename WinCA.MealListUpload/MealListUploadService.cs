using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL.IBLL.HHZX.ConsumerDevice;
using BLL.IBLL.HHZX.MealBooking;
using BLL.IBLL.HHZX.UserInfomation.CardUserInfo;
using BLL.IBLL.HHZX.UserCard;
using BLL.IBLL.HHZX.ConsumeAccount;
using sysBL = BLL.IBLL.SysMaster;
using sysFac = BLL.Factory.SysMaster;
using BLL.Factory.HHZX;
using BLL.DAL.HHZX.ConsumeAccount;
using Model.SysMaster;
using Model.HHZX.ConsumerDevice;
using Model.HHZX.MealBooking;
using Model.General;
using Model.HHZX.UserCard;
using Model.HHZX.UserInfomation.CardUserInfo;
using System.Net;
using PaymentEquipment.IDevice;
using PaymentEquipment.DeviceFactory;

namespace WinCA.MealListUpload
{
    public class MealListUploadService
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
        private List<CardUserMaster_cus_Info> _ListUserInfos;

        private sysBL.ICodeMasterBL _ICodeMasterBL;
        private IConsumeMachineBL _IConsumeMachineBL;
        private IMealBookingHistoryBL _IMealBookingHistoryBL;
        private IPaymentUDGeneralSettingBL _IPaymentUDGeneralSettingBL;
        private IPaymentUDMealStateBL _IPaymentUDMealStateBL;
        private ICardUserMasterBL _ICardUserMasterBL;
        private IUserCardPairBL _IUserCardPairBL;
        private ICardUserAccountBL _ICardUserAccountBL;
        private IRechargeRecordBL _IRechargeRecordBL;
        private IPreConsumeRecordBL _IPreConsumeRecordBL;
        private IBlacklistChangeRecordBL _IBlacklistChangeRecordBL;
        private IPreRechargeRecordBL _IPreRechargeRecordBL;

        #endregion

        public MealListUploadService()
        {
            this._ServiceName = "MLUServ";

            InitBLL();
        }

        /// <summary>
        /// 数据逻辑类初始化
        /// </summary>
        private void InitBLL()
        {
            this._ICodeMasterBL = sysFac.MasterBLLFactory.GetBLL<sysBL.ICodeMasterBL>(sysFac.MasterBLLFactory.CodeMaster_cmt);
            this._IConsumeMachineBL = MasterBLLFactory.GetBLL<IConsumeMachineBL>(MasterBLLFactory.ConsumeMachine);
            this._IMealBookingHistoryBL = MasterBLLFactory.GetBLL<IMealBookingHistoryBL>(MasterBLLFactory.MealBookingHistory);
            this._IPaymentUDGeneralSettingBL = MasterBLLFactory.GetBLL<IPaymentUDGeneralSettingBL>(MasterBLLFactory.PaymentUDGeneralSetting);
            this._IPaymentUDMealStateBL = MasterBLLFactory.GetBLL<IPaymentUDMealStateBL>(MasterBLLFactory.PaymentUDMealState);
            this._ICardUserMasterBL = MasterBLLFactory.GetBLL<ICardUserMasterBL>(MasterBLLFactory.CardUserMaster);
            this._IUserCardPairBL = MasterBLLFactory.GetBLL<IUserCardPairBL>(MasterBLLFactory.UserCardPair);
            this._ICardUserAccountBL = MasterBLLFactory.GetBLL<ICardUserAccountBL>(MasterBLLFactory.CardUserAccount);
            this._IRechargeRecordBL = MasterBLLFactory.GetBLL<RechargeRecordBL>(MasterBLLFactory.RechargeRecord);
            this._IPreConsumeRecordBL = MasterBLLFactory.GetBLL<IPreConsumeRecordBL>(MasterBLLFactory.PreConsumeRecord);
            this._IBlacklistChangeRecordBL = BLL.Factory.HHZX.MasterBLLFactory.GetBLL<IBlacklistChangeRecordBL>(BLL.Factory.HHZX.MasterBLLFactory.BlacklistChangeRecord);
            this._IPreRechargeRecordBL = MasterBLLFactory.GetBLL<IPreRechargeRecordBL>(MasterBLLFactory.PreRechargeRecord);
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
                DateTime dtBegin = DateTime.Now.Date;
                DateTime dtEnd = DateTime.Now.Date.AddHours(2);
                if (dtBegin <= DateTime.Now && DateTime.Now <= dtEnd)
                {
                    SendContinuedBalckList();
                }
                else
                {
                    MealListUpload();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(getCWStyle(ex.Message, SystemLog.SystemLog.LogType.Error));
                return false;
            }

            return true;
        }

        private void MealListUpload()
        {
            try
            {
                CodeMaster_cmt_Info mealInfo = this._ICodeMasterBL.GetCurrentMealSpanInfo();
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

                    Console.WriteLine(getCWStyle("进入用餐名单上传时段。" + Environment.NewLine + "餐类型：" + strMealType + ";餐金额：" + fMealCost.ToString() + "；上传开始时间：" + strMealBeginSpan + "；上传结束时间：" + strMealEndSpan, SystemLog.SystemLog.LogType.Trace));

                    //获取在用的消费机信息
                    List<ConsumeMachineMaster_cmm_Info> listUsingMacInfos = GetInUsingMacInfoList();

                    if (listUsingMacInfos != null)
                    {
                        //获取学生信息
                        List<CardUserMaster_cus_Info> listStudent = this._ICardUserMasterBL.SearchRecords(new CardUserMaster_cus_Info()
                        {
                            cus_cIdentityNum = Common.DefineConstantValue.CodeMasterDefine.KEY2_SIOT_CardUserIdentity_Student
                        });
                        listStudent = listStudent.Where(x => x.cus_lValid && x.PairInfo != null && !x.cus_lIsGraduate).ToList();//需为有效用户及已发卡用户
                        this._ListUserInfos = listStudent;

                        #region 特殊设置，星期六日开放非定餐机打卡

                        if (DateTime.Now.DayOfWeek == DayOfWeek.Sunday || DateTime.Now.DayOfWeek == DayOfWeek.Saturday)
                        {
                            listUsingMacInfos = listUsingMacInfos.Where(x =>
                                x.cmm_cUsageType != Common.DefineConstantValue.ConsumeMachineType.MedicalPay.ToString()
                                && x.cmm_cUsageType != Common.DefineConstantValue.ConsumeMachineType.DrinkPay.ToString()
                                && x.cmm_cUsageType != Common.DefineConstantValue.ConsumeMachineType.StuPay.ToString()
                                && x.cmm_cUsageType != Common.DefineConstantValue.ConsumeMachineType.HotWaterPay.ToString()).ToList();
                        }

                        #endregion

                        Console.WriteLine(getCWStyle("相关消费机数量：" + listUsingMacInfos.Count + "条。", SystemLog.SystemLog.LogType.Trace));

                        List<MealBookingHistory_mbh_Info> listMealPlanInfos = this._IMealBookingHistoryBL.GetAllCardUsersMealPlan(dtMealBeginSpan.Date, strMealType, fMealCost, this._ServiceName);

                        if (listMealPlanInfos != null && listMealPlanInfos.Count > 0)
                        {
                            Console.WriteLine(getCWStyle("定餐计划总数量：" + listMealPlanInfos.Count + "条。", SystemLog.SystemLog.LogType.Trace));

                            ReturnValueInfo rvInfo = this._IMealBookingHistoryBL.InsertBatchRecords(listMealPlanInfos);
                            if (rvInfo.boolValue && !rvInfo.isError)
                            {
                                Console.WriteLine(getCWStyle("成功保存定餐历史记录。", SystemLog.SystemLog.LogType.Trace));
                            }
                            else
                            {
                                Console.WriteLine(getCWStyle("保存定餐历史记录失败。", SystemLog.SystemLog.LogType.Error));
                            }

                            List<MealBookingHistory_mbh_Info> listUnSetMealPlans = listMealPlanInfos.Where(x => !x.mbh_lIsSet).ToList();
                            Console.WriteLine(getCWStyle("停餐名单数量：" + listUnSetMealPlans.Count + "条。", SystemLog.SystemLog.LogType.Trace));

                            List<MealBookingHistory_mbh_Info> listSetMealPlans = listMealPlanInfos.Where(x => x.mbh_lIsSet).ToList();
                            Console.WriteLine(getCWStyle("开餐名单数量：" + listSetMealPlans.Count + "条。", SystemLog.SystemLog.LogType.Trace));

                            //常态黑名单列表
                            //List<UserCardPair_ucp_Info> listBlacklist = this._IUserCardPairBL.GetUnusualCardList();
                            //if (listBlacklist != null)
                            //{
                            //    Console.WriteLine(getCWStyle("固定黑名单数量：" + listBlacklist.Count + "条。", SystemLog.SystemLog.LogType.Trace));
                            //}
                            //else
                            //{
                            //    Console.WriteLine(getCWStyle("获取到固定黑名单记录失败。", SystemLog.SystemLog.LogType.Error));
                            //}

                            foreach (ConsumeMachineMaster_cmm_Info macItem in listUsingMacInfos)
                            {
                                if (macItem == null)
                                {
                                    continue;
                                }
                                try
                                {
                                    if (macItem.cmm_cUsageType == Common.DefineConstantValue.ConsumeMachineType.HotWaterPay.ToString())
                                    {
                                        continue;
                                    }
                                    MealInfoProfile proFile = new MealInfoProfile();
                                    proFile.UnSetMealInfoList = listUnSetMealPlans;
                                    proFile.SetMealInfoList = listSetMealPlans;
                                    proFile.MacInfo = macItem;
                                    //proFile.BlacklistInfos = listBlacklist;

                                    SingleMacUploading(proFile);
                                }
                                catch (Exception exx)
                                {
                                    Console.WriteLine(getCWStyle(macItem.cmm_iMacNo.ToString() + "号机，发送名单异常：" + exx.Message, SystemLog.SystemLog.LogType.Error));
                                }
                            }

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
        /// 获取所有在用的消费机列表
        /// </summary>
        /// <returns></returns>
        private List<ConsumeMachineMaster_cmm_Info> GetInUsingMacInfoList()
        {
            List<ConsumeMachineMaster_cmm_Info> listUsingMacInfos = this._IConsumeMachineBL.SearchRecords(new ConsumeMachineMaster_cmm_Info()
            {
                cmm_cStatus = Common.DefineConstantValue.ConsumeMachineStatus.Using.ToString()
            });
            listUsingMacInfos = listUsingMacInfos.Where(x => x.cmm_lIsActive == true).ToList();
            return listUsingMacInfos;
        }

        /// <summary>
        /// 单台消费机黑名单上传
        /// </summary>
        /// <param name="MacInfo">对象消费机信息</param>
        void SingleMacUploading(object MealInfo)
        {
            MealInfoProfile profileInfo = MealInfo as MealInfoProfile;
            if (profileInfo != null && profileInfo.MacInfo != null && profileInfo.UnSetMealInfoList != null)
            {
                List<CardUserMaster_cus_Info> listUserInfo = new List<CardUserMaster_cus_Info>();
                listUserInfo.AddRange(this._ListUserInfos);

                ConsumeMachineMaster_cmm_Info MacInfo = profileInfo.MacInfo;

                string strMacDetail = "机号：" + MacInfo.cmm_iMacNo + "-" + MacInfo.cmm_cIPAddr + ":" + MacInfo.cmm_iPort.ToString() + "-" + MacInfo.cmm_cDesc;
                try
                {
                    int iMacNo = MacInfo.cmm_iMacNo;
                    int iPort = MacInfo.cmm_iPort;
                    IPAddress ipAddr = IPAddress.Parse(MacInfo.cmm_cIPAddr);
                    bool resPing = Common.General.Ping(ipAddr.ToString());
                    if (resPing)
                    {
                        AbstractPayDevice device = PaymentDeviceFactory.CreateDevice(PaymentDeviceFactory.EastRiverDevice);
                        ReturnValueInfo rvInfo = device.Conn(ipAddr, iPort, iMacNo);
                        if (rvInfo.boolValue && !rvInfo.isError)
                        {
                            //rvInfo = device.RemoveAllBlacklist();
                            //if (rvInfo.isError || !rvInfo.boolValue)
                            //{
                            //    Console.WriteLine(getCWStyle(MacInfo.cmm_iMacNo.ToString() + "移除所有黑名单失败。" + DateTime.Now.ToString() + Environment.NewLine + strMacDetail, SystemLog.SystemLog.LogType.Error));
                            //}
                            //else
                            //{
                            //    Console.WriteLine(getCWStyle(MacInfo.cmm_iMacNo.ToString() + "移除所有黑名单成功。" + DateTime.Now.ToString() + Environment.NewLine + strMacDetail, null));
                            //}

                            #region 添加名单--停餐

                            string strFailUnSetRes = "消费机#" + iMacNo.ToString() + "，挂失不定餐卡失败结果：" + DateTime.Now.ToString() + Environment.NewLine;//挂失失败结果记录内容
                            bool resUnSet = true;

                            foreach (MealBookingHistory_mbh_Info mealInfo in profileInfo.UnSetMealInfoList)
                            {
                                CardUserMaster_cus_Info userInfo = listUserInfo.Find(x => x.cus_cRecordID == mealInfo.mbh_cTargetID);
                                if (userInfo != null && userInfo.PairInfo != null)
                                {
                                    rvInfo = device.AddBlacklist(userInfo.PairInfo.ucp_iCardNo.ToString());
                                    if (rvInfo.boolValue && !rvInfo.isError)
                                    {
                                        continue;
                                    }
                                    else
                                    {
                                        resUnSet = resUnSet && false;
                                        strFailUnSetRes += userInfo.PairInfo.ucp_iCardNo.ToString() + "，失败。" + Environment.NewLine;
                                        continue;
                                    }
                                }
                                else
                                {
                                    strFailUnSetRes += "无法找到该用户的卡信息：" + mealInfo.mbh_cTargetID.ToString() + "。" + Environment.NewLine;
                                    continue;
                                }
                            }

                            if (!resUnSet)
                            {
                                Console.WriteLine(getCWStyle(strFailUnSetRes, SystemLog.SystemLog.LogType.Error));
                            }

                            #endregion

                            #region 移除名单--开餐

                            string strFailSetRes = "消费机#" + iMacNo.ToString() + "，解挂定餐卡失败结果：" + DateTime.Now.ToString() + Environment.NewLine;//挂失失败结果记录内容
                            bool resSet = true;

                            foreach (MealBookingHistory_mbh_Info mealInfo in profileInfo.SetMealInfoList)
                            {
                                CardUserMaster_cus_Info userInfo = listUserInfo.Find(x => x.cus_cRecordID == mealInfo.mbh_cTargetID);
                                if (userInfo != null && userInfo.PairInfo != null)
                                {
                                    rvInfo = device.RemoveBlacklist(userInfo.PairInfo.ucp_iCardNo.ToString());
                                    if (rvInfo.boolValue && !rvInfo.isError)
                                    {
                                        continue;
                                    }
                                    else
                                    {
                                        resSet = resSet && false;
                                        strFailSetRes += userInfo.PairInfo.ucp_iCardNo.ToString() + "，失败。" + Environment.NewLine;
                                        continue;
                                    }
                                }
                                else
                                {
                                    strFailSetRes += "无法找到该用户的卡信息：" + mealInfo.mbh_cTargetID.ToString() + "。" + Environment.NewLine;
                                    continue;
                                }
                            }

                            if (!resSet)
                            {
                                Console.WriteLine(getCWStyle(strFailSetRes, SystemLog.SystemLog.LogType.Error));
                            }

                            #endregion

                            //if (profileInfo.BlacklistInfos != null)
                            //{
                            //    strFailRes = "消费机#" + iMacNo.ToString() + "，挂失固定黑名单卡失败结果：" + DateTime.Now.ToString() + Environment.NewLine;//挂失失败结果记录内容
                            //    res = true;

                            //    foreach (UserCardPair_ucp_Info blacklistItem in profileInfo.BlacklistInfos)
                            //    {
                            //        if (blacklistItem != null)
                            //        {
                            //            rvInfo = device.AddBlacklist(blacklistItem.ucp_iCardNo.ToString());
                            //            if (rvInfo.boolValue && !rvInfo.isError)
                            //            {
                            //                continue;
                            //            }
                            //            else
                            //            {
                            //                res = res && false;
                            //                strFailRes += blacklistItem.ucp_iCardNo.ToString() + "，失败。" + Environment.NewLine;
                            //                continue;
                            //            }
                            //        }
                            //    }

                            //    if (!res)
                            //    {
                            //        Console.WriteLine(getCWStyle(strFailRes, SystemLog.SystemLog.LogType.Error));
                            //    }
                            //}
                        }
                        else
                        {
                            Console.WriteLine(getCWStyle(MacInfo.cmm_iMacNo.ToString() + "--" + "设备无法连接。" + DateTime.Now.ToString(), SystemLog.SystemLog.LogType.Warning));
                        }
                    }
                    else
                    {
                        Console.WriteLine(getCWStyle(MacInfo.cmm_iMacNo.ToString() + "--" + "设备无法访问。" + DateTime.Now.ToString(), SystemLog.SystemLog.LogType.Warning));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(getCWStyle(ex.Message + Environment.NewLine + strMacDetail, SystemLog.SystemLog.LogType.Error));
                }
            }
        }

        /// <summary>
        /// 发送持久化黑名单到消费机处
        /// </summary>
        /// <param name="listTargetMachine"></param>
        private void SendContinuedBalckList()
        {
            List<ConsumeMachineMaster_cmm_Info> listTargetMachine = GetInUsingMacInfoList();

            if (listTargetMachine == null)
            {
                Console.WriteLine(getCWStyle("没有可用的机台信息，发送持久化黑名单操作失败。", SystemLog.SystemLog.LogType.Warning));
                return;
            }

            if (listTargetMachine.Count < 1)
            {
                Console.WriteLine(getCWStyle("没有可用的机台信息，发送持久化黑名单操作失败。", SystemLog.SystemLog.LogType.Warning));
                return;
            }

            Console.WriteLine(getCWStyle("准备发送持久化黑名单到消费机，数量：" + listTargetMachine.Count.ToString() + "台。", SystemLog.SystemLog.LogType.Trace));

            List<int> listBlackListCardNo = this._IUserCardPairBL.GetContinuedBalckListCardNoList();
            if (listBlackListCardNo == null)
            {
                Console.WriteLine(getCWStyle("没有可用的持久化黑名单列表，发送持久化黑名单操作失败。", SystemLog.SystemLog.LogType.Warning));
                return;
            }
            if (listBlackListCardNo.Count < 1)
            {
                Console.WriteLine(getCWStyle("没有可用的持久化黑名单列表，发送持久化黑名单操作失败。", SystemLog.SystemLog.LogType.Warning));
                return;
            }

            //凌晨进行大量数据发送操作
            foreach (ConsumeMachineMaster_cmm_Info macInfo in listTargetMachine)
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
                        Console.WriteLine(getCWStyle("消费机连接成功，机号：" + iMacNo.ToString(), SystemLog.SystemLog.LogType.Trace));

                        rvInfo = device.RemoveAllBlacklist();
                        if (rvInfo.boolValue && !rvInfo.isError)
                        {
                            Console.WriteLine(getCWStyle("消费机移除所有黑名单成功，机号：" + iMacNo.ToString(), SystemLog.SystemLog.LogType.Trace));

                            string strFailList = string.Empty;
                            foreach (int iCardNo in listBlackListCardNo)
                            {
                                rvInfo = device.AddBlacklist(iCardNo.ToString());
                                if (rvInfo.isError || !rvInfo.boolValue)
                                {
                                    strFailList += iCardNo.ToString() + ";";
                                }
                            }
                            if (!string.IsNullOrEmpty(strFailList))
                            {
                                Console.WriteLine(getCWStyle("发送失败名单：" + strFailList, SystemLog.SystemLog.LogType.Warning));
                            }

                            Console.WriteLine(getCWStyle("消费机添加持久化名单完成，机号：" + iMacNo.ToString(), SystemLog.SystemLog.LogType.Trace));
                        }
                        else
                        {
                            Console.WriteLine(getCWStyle("消费机移除所有黑名单失败，机号：" + iMacNo.ToString(), SystemLog.SystemLog.LogType.Error));
                        }
                    }
                    else
                    {
                        Console.WriteLine(getCWStyle("消费机连接失败，机号：" + iMacNo.ToString(), SystemLog.SystemLog.LogType.Error));
                    }
                }
                else
                {
                    Console.WriteLine(getCWStyle("消费机没有联网，机号：" + iMacNo.ToString(), SystemLog.SystemLog.LogType.Error));
                }
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

        /// <summary>
        /// 定餐信息外壳
        /// </summary>
        class MealInfoProfile
        {
            public ConsumeMachineMaster_cmm_Info MacInfo { get; set; }
            /// <summary>
            /// 未定餐名单信息
            /// </summary>
            public List<MealBookingHistory_mbh_Info> UnSetMealInfoList { get; set; }
            /// <summary>
            /// 定餐名单信息
            /// </summary>
            public List<MealBookingHistory_mbh_Info> SetMealInfoList { get; set; }
            //public List<UserCardPair_ucp_Info> BlacklistInfos { get; set; }
        }
    }
}
