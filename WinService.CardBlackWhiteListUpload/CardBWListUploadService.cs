﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using Model.SysMaster;
using Model.IModel;
using System.Threading;
using BLL.IBLL.HHZX.ConsumerDevice;
using System.Timers;
using BLL.Factory.HHZX;
using sysBL = BLL.IBLL.SysMaster;
using sysFac = BLL.Factory.SysMaster;
using BLL.IBLL.HHZX.MealBooking;
using Model.HHZX.ConsumerDevice;
using Model.HHZX.MealBooking;
using BLL.IBLL.HHZX.UserInfomation.CardUserInfo;
using Model.HHZX.UserInfomation.CardUserInfo;
using Model.General;
using System.Net;
using PaymentEquipment.IDevice;
using PaymentEquipment.DeviceFactory;
using BLL.IBLL.HHZX.UserCard;
using Model.HHZX.UserCard;
using System.Configuration;
using BLL.IBLL.HHZX.ConsumeAccount;
using Model.HHZX.ComsumeAccount;
using BLL.DAL.HHZX.ConsumeAccount;

namespace WinService.CardBlackWhiteListUpload
{
    /*
     * 1、使用当前定餐设置，汇总成当前餐类型的历史设置记录
     * 2、使用汇总出来的定餐设置进行不定餐对象临时挂失处理，挂失机型必须为在用的定餐消费机
     * */
    /// <summary>
    /// 卡片黑白名单上传服务
    /// </summary>
    public partial class CardBWListUploadService : ServiceBase
    {
        #region 自定义变量

        /// <summary>
        /// 服务名称
        /// </summary>
        private string _ServiceName;
        /// <summary>
        /// 缓存的用户信息
        /// </summary>
        private List<CardUserMaster_cus_Info> _ListUserInfos;
        /// <summary>
        /// 同步收数时段主时钟
        /// </summary>
        private System.Timers.Timer _tmrSycnTime;
        /// <summary>
        /// 是否正在收集数据中
        /// </summary>
        private bool _IsCollectting;
        /// <summary>
        /// 本地日志记录器
        /// </summary>
        private Common.General _LocalLogger;
        /// <summary>
        /// 数据库日志记录器
        /// </summary>
        private Common.General _DBLogger;
        /// <summary>
        /// 当前开始收集时刻
        /// </summary>
        private TimeSpan _CurrentStartSpan;
        /// <summary>
        /// 当前结束收集时刻
        /// </summary>
        private TimeSpan _CurrentEndSpan;
        /// <summary>
        /// 当前餐类型
        /// </summary>
        private string _CurrentMealType;
        /// <summary>
        /// 当前餐费用
        /// </summary>
        private decimal _CurrentMealCost;

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

        /// <summary>
        /// 操作失败后重复操作次数
        /// </summary>
        private int _iErrRetryTimes;
        /// <summary>
        /// 每次操作失败后等待时间间隔（单位：毫秒）
        /// </summary>
        private int _iErrRetryInterval;

        #endregion

        public CardBWListUploadService()
        {
            InitializeComponent();

            try
            {
                InitLogger();

                InitTimers();

                InitBLL();

                this._LocalLogger.WriteLog("服务初始化完毕。" + DateTime.Now.ToString(), string.Empty, SystemLog.SystemLog.LogType.Trace);
            }
            catch (Exception ex)
            {
                this._LocalLogger.WriteLog("服务初始化失败。" + DateTime.Now.ToString(), ex.Message, SystemLog.SystemLog.LogType.Error);
                throw ex;
            }
        }

        /// <summary>
        /// 日志记录器初始化
        /// </summary>
        private void InitLogger()
        {
            this._LocalLogger = new Common.General(Common.General.BindLocalLogInfo());
            this._DBLogger = new Common.General(Common.General.BindDbLogInfo());
        }

        /// <summary>
        /// 参数初始化
        /// </summary>
        private void InitParams()
        {
            this._ServiceName = ConfigurationSettings.AppSettings["ServiceName"];
            if (string.IsNullOrEmpty(this._ServiceName))
            {
                this._ServiceName = "ServBlacklistUpload";
            }
            this._ServiceName.PadRight(20, ' ').Substring(0, 20).Trim();

            this._iErrRetryTimes = int.Parse(ConfigurationSettings.AppSettings["ErrRetryTimes"]);
            this._iErrRetryInterval = int.Parse(ConfigurationSettings.AppSettings["ErrWaitInterval"]);

            this._CurrentMealType = string.Empty;
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
        /// 计数器初始化
        /// </summary>
        private void InitTimers()
        {
            this._tmrSycnTime = new System.Timers.Timer();
            this._tmrSycnTime.Interval = 120000;
            this._tmrSycnTime.Elapsed += new ElapsedEventHandler(_tmrSycnTime_Elapsed);
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                InitParams();
            }
            catch (Exception ex)
            {
                this._LocalLogger.WriteLog("初始化参数失败。" + DateTime.Now.ToString(), ex.Message, SystemLog.SystemLog.LogType.Error);
                this._DBLogger.WriteLog("初始化参数失败。" + DateTime.Now.ToString(), ex.Message, SystemLog.SystemLog.LogType.Error);
            }
            finally
            {
                if (this._tmrSycnTime != null)
                {
                    Thread.Sleep(5000);
                    this._tmrSycnTime.Start();
                    this._LocalLogger.WriteLog("初始化参数成功，服务启动。" + DateTime.Now.ToString(), string.Empty, SystemLog.SystemLog.LogType.Trace);
                }
            }
        }

        protected override void OnStop()
        {
            try
            {
                this._tmrSycnTime.Stop();
                this._LocalLogger.WriteLog("服务停止。" + DateTime.Now.ToString(), string.Empty, SystemLog.SystemLog.LogType.Trace);
            }
            catch (Exception ex)
            {
                this._LocalLogger.WriteLog("服务停止失败。" + DateTime.Now.ToString(), ex.Message, SystemLog.SystemLog.LogType.Error);
                this._DBLogger.WriteLog("服务停止失败。" + DateTime.Now.ToString(), ex.Message, SystemLog.SystemLog.LogType.Error);
            }
        }

        void _tmrSycnTime_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                if (!_IsCollectting)
                {
                    UploadCardNoOpt();
                }
            }
            catch (Exception ex)
            {
                this._LocalLogger.WriteLog(ex.Message, string.Empty, SystemLog.SystemLog.LogType.Error);
                this._DBLogger.WriteLog(ex.Message, string.Empty, SystemLog.SystemLog.LogType.Error);
                this._IsCollectting = false;
            }
        }

        /// <summary>
        /// 上传普通黑名单
        /// </summary>
        void UploadCardNoOpt()
        {
            this._IsCollectting = true;

            try
            {
                #region 获取需要操作的设备
                List<ConsumeMachineMaster_cmm_Info> listMachine = this._IConsumeMachineBL.SearchRecords(new ConsumeMachineMaster_cmm_Info()
                {
                    cmm_cStatus = Common.DefineConstantValue.ConsumeMachineStatus.Using.ToString()
                });
                if (listMachine != null)
                {
                    listMachine = listMachine.Where(x => x.cmm_lIsActive == true).ToList();
                    if (listMachine.Count < 1)
                    {
                        this._LocalLogger.WriteLog("没有可用的消费机资料，请检查主档信息。" + DateTime.Now.ToString(), string.Empty, SystemLog.SystemLog.LogType.Error);
                        this._IsCollectting = false;
                        return;
                    }
                }
                else
                {
                    this._LocalLogger.WriteLog("搜寻消费机资料时出现异常。" + DateTime.Now.ToString(), string.Empty, SystemLog.SystemLog.LogType.Error);
                    this._IsCollectting = false;
                    return;
                }
                #endregion

                #region 获取普通黑白名单操作记录
                List<BlacklistChangeRecord_blc_Info> listBlackWhitelist = this._IBlacklistChangeRecordBL.AllRecords();
                if (listBlackWhitelist == null)
                {
                    this._LocalLogger.WriteLog("搜寻黑白名单操作记录时出现异。" + DateTime.Now.ToString(), string.Empty, SystemLog.SystemLog.LogType.Error);
                    this._IsCollectting = false;
                    return;
                }

                if (listBlackWhitelist != null && listBlackWhitelist.Count < 1)
                {
                    this._IsCollectting = false;
                    return;
                }
                #endregion

                #region 操作黑白名单
                List<BlacklistChangeRecord_blc_Info> listAddBlacklist = new List<BlacklistChangeRecord_blc_Info>();//新增的黑名单
                List<BlacklistChangeRecord_blc_Info> listRemoveBalcklist = new List<BlacklistChangeRecord_blc_Info>();//移出的黑名单
                List<BlacklistChangeRecord_blc_Info> listAddWhitelist = new List<BlacklistChangeRecord_blc_Info>();//新增的白名单
                List<BlacklistChangeRecord_blc_Info> listRemoveWhitelist = new List<BlacklistChangeRecord_blc_Info>();//移出的白名单

                //按卡号进行黑名单操作分组，每组只取最新操作
                var groupForCard = listBlackWhitelist.GroupBy(x => x.blc_iCardNo);
                foreach (var cardGroupItem in groupForCard)
                {
                    int iCardNo = cardGroupItem.Key;
                    //按时间排序  取最新操作
                    BlacklistChangeRecord_blc_Info blOptInfo = cardGroupItem.OrderByDescending(x => x.blc_dAddDate).FirstOrDefault();
                    if (blOptInfo != null)
                    {
                        if (blOptInfo.blc_cOperation == Common.DefineConstantValue.EnumCardUploadListOpt.AddBlackList.ToString())
                        {
                            //收集挂失黑名单
                            listAddBlacklist.Add(blOptInfo);
                        }
                        else if (blOptInfo.blc_cOperation == Common.DefineConstantValue.EnumCardUploadListOpt.RemoveBlackList.ToString())
                        {
                            //收集解挂黑名单
                            listRemoveBalcklist.Add(blOptInfo);
                        }
                        else if (blOptInfo.blc_cOperation == Common.DefineConstantValue.EnumCardUploadListOpt.AddWhiteList.ToString())
                        {
                            //收集新增白名单
                            listAddWhitelist.Add(blOptInfo);
                        }
                        else if (blOptInfo.blc_cOperation == Common.DefineConstantValue.EnumCardUploadListOpt.RemoveWhiteList.ToString())
                        {
                            //收集移除白名单
                            listRemoveWhitelist.Add(blOptInfo);
                        }
                    }
                }

                AbstractPayDevice currentDevice = PaymentDeviceFactory.CreateDevice(PaymentDeviceFactory.EastRiverDevice);
                if (currentDevice == null)
                {
                    this._LocalLogger.WriteLog("初始化消费机抽象类失败。" + DateTime.Now.ToString(), string.Empty, SystemLog.SystemLog.LogType.Error);
                    this._IsCollectting = false;
                    return;
                }
                foreach (ConsumeMachineMaster_cmm_Info itemMac in listMachine)
                {
                    try
                    {
                        IPAddress ip = IPAddress.Parse(itemMac.cmm_cIPAddr);
                        if (!Common.General.Ping(ip.ToString()))
                        {
                            continue;
                        }

                        bool isTechMac = itemMac.cmm_cUsageType == Common.DefineConstantValue.ConsumeMachineType.TeachPay.ToString() ? true : false;//是否教师机

                        ReturnValueInfo returnInfo = currentDevice.Conn(ip, itemMac.cmm_iPort, itemMac.cmm_iMacNo);
                        if (returnInfo.boolValue && !returnInfo.isError)
                        {
                            foreach (BlacklistChangeRecord_blc_Info addItem in listAddBlacklist)
                            {
                                bool isTechUser = addItem.IdentityNum == Common.DefineConstantValue.CodeMasterDefine.KEY2_SIOT_CardUserIdentity_Staff ? true : false;
                                if (isTechMac == isTechUser)
                                {
                                    //添加黑名单
                                    currentDevice.AddBlacklist(addItem.blc_iCardNo.ToString());
                                }
                            }
                            foreach (BlacklistChangeRecord_blc_Info removeItem in listRemoveBalcklist)
                            {
                                bool isTechUser = removeItem.IdentityNum == Common.DefineConstantValue.CodeMasterDefine.KEY2_SIOT_CardUserIdentity_Staff ? true : false;
                                if (isTechMac == isTechUser)
                                {
                                    //移除黑名单
                                    currentDevice.RemoveBlacklist(removeItem.blc_iCardNo.ToString());
                                }
                            }
                            foreach (BlacklistChangeRecord_blc_Info addNewItem in listAddWhitelist)
                            {
                                bool isTechUser = addNewItem.IdentityNum == Common.DefineConstantValue.CodeMasterDefine.KEY2_SIOT_CardUserIdentity_Staff ? true : false;
                                if (isTechMac == isTechUser)
                                {
                                    //添加白名单
                                    currentDevice.AddWhitelist(addNewItem.blc_iCardNo.ToString());
                                }
                            }
                            foreach (BlacklistChangeRecord_blc_Info removeNewItem in listRemoveWhitelist)
                            {
                                bool isTechUser = removeNewItem.IdentityNum == Common.DefineConstantValue.CodeMasterDefine.KEY2_SIOT_CardUserIdentity_Staff ? true : false;
                                if (isTechMac == isTechUser)
                                {
                                    //移除白名单
                                    currentDevice.RemoveWhitelist(removeNewItem.blc_iCardNo.ToString());
                                }
                            }
                        }
                        currentDevice.DisConn();
                    }
                    catch (Exception ex)
                    {
                        this._LocalLogger.WriteLog("挂失 or 解挂卡名单操作异常。" + ex.Message + DateTime.Now.ToString(), string.Empty, SystemLog.SystemLog.LogType.Error);
                        this._IsCollectting = false;
                        return;
                    }
                }
                #endregion

                #region  更新已被使用的黑白名单记录

                List<BlacklistChangeRecord_blc_Info> listTotalList = new List<BlacklistChangeRecord_blc_Info>();
                listTotalList.AddRange(listAddBlacklist);
                listTotalList.AddRange(listRemoveBalcklist);
                listTotalList.AddRange(listAddWhitelist);
                listTotalList.AddRange(listRemoveWhitelist);

                if (listTotalList != null && listTotalList.Count > 0)
                {
                    ReturnValueInfo rvInfo = this._IBlacklistChangeRecordBL.UpdateBatchRecord(listTotalList);
                    if (rvInfo.boolValue && !rvInfo.isError)
                    {
                        //this._LocalLogger.WriteLog("保存黑名单操作记录成功。" + DateTime.Now.ToString(), string.Empty, SystemLog.SystemLog.LogType.Trace);
                    }
                    else
                    {
                        this._LocalLogger.WriteLog("保存黑名单操作记录异常。" + rvInfo.messageText + DateTime.Now.ToString(), string.Empty, SystemLog.SystemLog.LogType.Error);
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                this._LocalLogger.WriteLog("上传普通黑名单失败，错误信息：" + ex.Message, string.Empty, SystemLog.SystemLog.LogType.Error);
            }
            this._IsCollectting = false;
        }

        /// <summary>
        /// 获取当餐停餐信息
        /// </summary>
        /// <param name="strMealType">定餐类型</param>
        /// <returns></returns>
        List<MealBookingHistory_mbh_Info> GetMealBookingRecord(string strMealType)
        {
            List<MealBookingHistory_mbh_Info> listMeal = new List<MealBookingHistory_mbh_Info>();
            try
            {
                //获取学生信息
                List<CardUserMaster_cus_Info> listStudent = this._ICardUserMasterBL.SearchRecords(new CardUserMaster_cus_Info()
                {
                    cus_cIdentityNum = Common.DefineConstantValue.CodeMasterDefine.KEY2_SIOT_CardUserIdentity_Student
                });
                listStudent = listStudent.Where(x => x.cus_lValid && x.PairInfo != null).ToList();//需为有效用户及已发卡用户
                this._ListUserInfos = listStudent;

                //获取默认定餐设置
                List<PaymentUDGeneralSetting_pus_Info> listGeneralSettings = this._IPaymentUDGeneralSettingBL.SearchRecords(new PaymentUDGeneralSetting_pus_Info()
                {
                    pus_iWeek = (int)DateTime.Now.DayOfWeek//符合当天星期日子
                });

                //获取自定义定餐设置
                List<PaymentUDMealState_pms_Info> listCustomSettings = this._IPaymentUDMealStateBL.SearchRecords(new PaymentUDMealState_pms_Info()
                {
                    TimeFrom = DateTime.Now.Date,
                    TimeTo = DateTime.Now.Date
                });

                foreach (CardUserMaster_cus_Info stuItem in listStudent)
                {
                    //以一个学生为单位储存定餐数据
                    MealBookingHistory_mbh_Info history = new MealBookingHistory_mbh_Info();
                    history.mbh_cTargetID = stuItem.cus_cRecordID;
                    history.mbh_cMealType = this._CurrentMealType;
                    history.mbh_cRecordID = Guid.NewGuid();
                    history.mbh_dMealDate = DateTime.Now.Date;
                    history.mbh_cAdd = this._ServiceName;
                    history.mbh_dAddDate = DateTime.Now;
                    history.mbh_fMealCost = this._CurrentMealCost;

                    #region 个人-->>班级-->>年级

                    //学生自定义
                    List<PaymentUDMealState_pms_Info> listUD = listCustomSettings.Where(x => x.pms_cCardUserID == stuItem.cus_cRecordID).ToList();
                    PaymentUDMealState_pms_Info stuCustom = null;
                    if (listUD != null)
                    {
                        if (listUD.Count > 1)
                        {
                            //stuCustom = listUD.OrderByDescending(x => x.pms_dEndDate).FirstOrDefault();
                            stuCustom = listUD.OrderByDescending(x => x.pms_dLastDate).FirstOrDefault();
                        }
                        else if (listUD.Count == 1)
                            stuCustom = listUD.FirstOrDefault();
                        else
                            stuCustom = null;
                    }
                    else
                    {
                        stuCustom = null;
                    }
                    if (stuCustom == null)//学生自定义无值
                    {
                        //学生默认
                        PaymentUDGeneralSetting_pus_Info stuDefault = listGeneralSettings.Find(x => x.pus_cCardUserID == stuItem.cus_cRecordID);
                        if (stuDefault == null)//学生默认无值
                        {
                            #region 班级-->>年级

                            //班级自定义
                            listUD = listCustomSettings.Where(x => x.pms_cClassID == stuItem.cus_cClassID).ToList();
                            stuCustom = null;
                            if (listUD != null)
                            {
                                if (listUD.Count > 1)
                                {
                                    //stuCustom = listUD.OrderByDescending(x => x.pms_dEndDate).FirstOrDefault();
                                    stuCustom = listUD.OrderByDescending(x => x.pms_dLastDate).FirstOrDefault();
                                }
                                else if (listUD.Count == 1)
                                    stuCustom = listUD.FirstOrDefault();
                                else
                                    stuCustom = null;
                            }
                            else
                            {
                                stuCustom = null;
                            }
                            if (stuCustom == null)//班级自定义无值
                            {
                                //班级默认
                                stuDefault = listGeneralSettings.Find(x => x.pus_cClassID == stuItem.cus_cClassID);
                                if (stuDefault == null)//班级默认无值
                                {
                                    if (stuItem.ClassInfo != null && stuItem.ClassInfo.GradeInfo != null)
                                    {
                                        #region 年级

                                        //年级自定义
                                        listUD = listCustomSettings.Where(x => x.pms_cGradeID == stuItem.ClassInfo.GradeInfo.gdm_cRecordID).ToList();
                                        stuCustom = null;
                                        if (listUD != null)
                                        {
                                            if (listUD.Count > 1)
                                            {
                                                //stuCustom = listUD.OrderByDescending(x => x.pms_dEndDate).FirstOrDefault();
                                                stuCustom = listUD.OrderByDescending(x => x.pms_dLastDate).FirstOrDefault();
                                            }
                                            else if (listUD.Count == 1)
                                                stuCustom = listUD.FirstOrDefault();
                                            else
                                                stuCustom = null;
                                        }
                                        else
                                        {
                                            stuCustom = null;
                                        }
                                        if (stuCustom == null)//年级自定义无值
                                        {
                                            //年级默认
                                            stuDefault = listGeneralSettings.Find(x => x.pus_cGradeID == stuItem.ClassInfo.GradeInfo.gdm_cRecordID);
                                            if (stuDefault != null)//年级默认有值
                                            {
                                                history.mbh_cTargetType = Common.DefineConstantValue.StuMealBookingType.GradeDefault.ToString();
                                                history.mbh_lIsSet = GetGeneralSettings(this._CurrentMealType, stuDefault);
                                                listMeal.Add(history);
                                                continue;
                                            }
                                            else//年级默认无值
                                            {
                                                //缺失年级默认设置时，默认不定餐
                                                history.mbh_cTargetType = Common.DefineConstantValue.StuMealBookingType.Unknown.ToString();
                                                history.mbh_lIsSet = false;
                                                listMeal.Add(history);
                                                continue;
                                            }
                                        }
                                        else//年级自定义有值
                                        {
                                            history.mbh_cTargetType = Common.DefineConstantValue.StuMealBookingType.GradeCustom.ToString();
                                            history.mbh_lIsSet = GetCustomMealSettings(this._CurrentMealType, stuCustom);
                                            listMeal.Add(history);
                                            continue;
                                        }

                                        #endregion
                                    }
                                    else
                                    {
                                        //缺失年级信息时，默认不定餐
                                        history.mbh_cTargetType = Common.DefineConstantValue.StuMealBookingType.Unknown.ToString();
                                        history.mbh_lIsSet = false;
                                        listMeal.Add(history);
                                        continue;
                                    }
                                }
                                else//班级默认有值
                                {
                                    history.mbh_cTargetType = Common.DefineConstantValue.StuMealBookingType.ClassDefault.ToString();
                                    history.mbh_lIsSet = GetGeneralSettings(this._CurrentMealType, stuDefault);
                                    if (history.mbh_lIsSet)
                                    {
                                        CheckClassGradeIsSet(stuItem, history, listGeneralSettings, listCustomSettings);
                                    }
                                    listMeal.Add(history);
                                    continue;
                                }
                            }
                            else//班级自定义有值
                            {
                                history.mbh_cTargetType = Common.DefineConstantValue.StuMealBookingType.ClassCustom.ToString();
                                history.mbh_lIsSet = GetCustomMealSettings(this._CurrentMealType, stuCustom);
                                if (history.mbh_lIsSet)
                                {
                                    CheckClassGradeIsSet(stuItem, history, listGeneralSettings, listCustomSettings);
                                }
                                listMeal.Add(history);
                                continue;
                            }

                            #endregion
                        }
                        else//学生默认有值
                        {
                            history.mbh_cTargetType = Common.DefineConstantValue.StuMealBookingType.StudentDefault.ToString();
                            history.mbh_lIsSet = GetGeneralSettings(this._CurrentMealType, stuDefault);
                            if (history.mbh_lIsSet)
                            {
                                CheckClassGradeIsSet(stuItem, history, listGeneralSettings, listCustomSettings);
                            }
                            listMeal.Add(history);
                            continue;
                        }
                    }
                    else//学生自定义有记录
                    {
                        history.mbh_cTargetType = Common.DefineConstantValue.StuMealBookingType.StudentCustom.ToString();
                        history.mbh_lIsSet = GetCustomMealSettings(this._CurrentMealType, stuCustom);
                        if (history.mbh_lIsSet)
                        {
                            CheckClassGradeIsSet(stuItem, history, listGeneralSettings, listCustomSettings);
                        }
                        listMeal.Add(history);
                        continue;
                    }

                    #endregion
                }

                return listMeal;
            }
            catch (Exception ex)
            {
                this._LocalLogger.WriteLog(ex.Message, string.Empty, SystemLog.SystemLog.LogType.Error);
                this._DBLogger.WriteLog(ex.Message, string.Empty, SystemLog.SystemLog.LogType.Error);
            }
            return listMeal;
        }

        /// <summary>
        /// 扩展检查
        /// </summary>
        /// <param name="userInfo"></param>
        /// <param name="targetInfo"></param>
        /// <param name="listGeneralSettings"></param>
        /// <param name="listCustomSettings"></param>
        void CheckClassGradeIsSet(CardUserMaster_cus_Info userInfo, MealBookingHistory_mbh_Info targetInfo, List<PaymentUDGeneralSetting_pus_Info> listGeneralSettings, List<PaymentUDMealState_pms_Info> listCustomSettings)
        {
            MealBookingHistory_mbh_Info rvHistoryInfo = new MealBookingHistory_mbh_Info();
            if (targetInfo.mbh_lIsSet)
            {
                if (userInfo.ClassInfo != null)
                {
                    //先检查年级是否停餐，默认+自定义
                    //年级自定义
                    PaymentUDMealState_pms_Info stuCustom = listCustomSettings.Find(x => x.pms_cGradeID == userInfo.ClassInfo.GradeInfo.gdm_cRecordID);
                    if (stuCustom != null)
                    {
                        //有年级自定义
                        bool setInfo = GetCustomMealSettings(this._CurrentMealType, stuCustom);
                        if (!setInfo)
                        {
                            targetInfo.mbh_lIsSet = setInfo;
                            targetInfo.mbh_cTargetType = Common.DefineConstantValue.StuMealBookingType.GradeCustom.ToString();
                            return;
                        }
                    }
                    else
                    {
                        PaymentUDGeneralSetting_pus_Info stuDefault = listGeneralSettings.Find(x => x.pus_cGradeID == userInfo.ClassInfo.GradeInfo.gdm_cRecordID);
                        if (stuDefault != null)
                        {
                            //无年级自定义，有年级默认
                            bool setInfo = GetGeneralSettings(this._CurrentMealType, stuDefault);
                            if (!setInfo)
                            {
                                targetInfo.mbh_lIsSet = setInfo;
                                targetInfo.mbh_cTargetType = Common.DefineConstantValue.StuMealBookingType.GradeDefault.ToString();
                                return;
                            }
                        }
                    }

                    stuCustom = listCustomSettings.Find(x => x.pms_cClassID == userInfo.ClassInfo.csm_cRecordID);
                    if (stuCustom != null)
                    {
                        //无年级自定义、默认，有班级自定义
                        bool setInfo = GetCustomMealSettings(this._CurrentMealType, stuCustom);
                        if (!setInfo)
                        {
                            targetInfo.mbh_lIsSet = setInfo;
                            targetInfo.mbh_cTargetType = Common.DefineConstantValue.StuMealBookingType.ClassCustom.ToString();
                            return;
                        }
                    }
                    else
                    {
                        PaymentUDGeneralSetting_pus_Info stuDefault = listGeneralSettings.Find(x => x.pus_cClassID == userInfo.ClassInfo.csm_cRecordID);
                        if (stuDefault != null)
                        {
                            //无年级自定义、默认，无班级自定义，有班级默认
                            bool setInfo = GetGeneralSettings(this._CurrentMealType, stuDefault);
                            if (!setInfo)
                            {
                                targetInfo.mbh_lIsSet = setInfo;
                                targetInfo.mbh_cTargetType = Common.DefineConstantValue.StuMealBookingType.ClassDefault.ToString();
                                return;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 获取自定义定餐指定餐类型的定餐情况
        /// </summary>
        /// <param name="strMealType"></param>
        /// <param name="customMeal"></param>
        /// <returns></returns>
        bool GetCustomMealSettings(string strMealType, PaymentUDMealState_pms_Info customMeal)
        {
            if (customMeal == null)
            {
                return false;
            }
            Common.DefineConstantValue.MealType mealType = GetMealType(strMealType);
            bool? res = false;
            switch (mealType)
            {
                case Common.DefineConstantValue.MealType.UnKnown:
                    break;
                case Common.DefineConstantValue.MealType.Breakfast:
                    res = customMeal.pms_cBreakfast;
                    if (res != null)
                        res = customMeal.pms_cBreakfast.Value;
                    else
                        res = true;
                    break;
                case Common.DefineConstantValue.MealType.Lunch:
                    res = customMeal.pms_cLunch;
                    if (res != null)
                        res = customMeal.pms_cLunch.Value;
                    else
                        res = true;
                    break;
                case Common.DefineConstantValue.MealType.Supper:
                    res = customMeal.pms_cDinner;
                    if (res != null)
                        res = customMeal.pms_cDinner.Value;
                    else
                        res = true;
                    break;
                default:
                    break;
            }
            return res.Value;
        }

        /// <summary>
        /// 获取默认定餐指定餐类型的定餐情况
        /// </summary>
        /// <param name="strMealType"></param>
        /// <param name="generalMeal"></param>
        /// <returns></returns>
        bool GetGeneralSettings(string strMealType, PaymentUDGeneralSetting_pus_Info generalMeal)
        {
            if (generalMeal == null)
            {
                return false;
            }

            Common.DefineConstantValue.MealType mealType = GetMealType(strMealType);
            bool? res = false;
            switch (mealType)
            {
                case Common.DefineConstantValue.MealType.UnKnown:
                    break;
                case Common.DefineConstantValue.MealType.Breakfast:
                    res = generalMeal.pus_cBreakfast;
                    if (res != null)
                        res = generalMeal.pus_cBreakfast.Value;
                    else
                        res = true;
                    break;
                case Common.DefineConstantValue.MealType.Lunch:
                    res = generalMeal.pus_cLunch;
                    if (res != null)
                        res = generalMeal.pus_cLunch.Value;
                    else
                        res = true;
                    break;
                case Common.DefineConstantValue.MealType.Supper:
                    res = generalMeal.pus_cDinner;
                    if (res != null)
                        res = generalMeal.pus_cDinner.Value;
                    else
                        res = true;
                    break;
                default:
                    break;
            }
            return res.Value;
        }

        /// <summary>
        /// 获取当前用餐类型
        /// </summary>
        /// <param name="strMealType"></param>
        /// <returns></returns>
        Common.DefineConstantValue.MealType GetMealType(string strMealType)
        {
            if (strMealType == Common.DefineConstantValue.MealType.Breakfast.ToString())
            {
                return Common.DefineConstantValue.MealType.Breakfast;
            }
            else if (strMealType == Common.DefineConstantValue.MealType.Lunch.ToString())
            {
                return Common.DefineConstantValue.MealType.Lunch;
            }
            else if (strMealType == Common.DefineConstantValue.MealType.Supper.ToString())
            {
                return Common.DefineConstantValue.MealType.Supper;
            }
            else
            {
                return Common.DefineConstantValue.MealType.UnKnown;
            }
        }

        /// <summary>
        /// 单台消费机黑名单上传
        /// </summary>
        /// <param name="MacInfo">对象消费机信息</param>
        void SingleMacUploading(object MealInfo)
        {
            MealInfoProfile profileInfo = MealInfo as MealInfoProfile;
            if (profileInfo != null && profileInfo.MacInfo != null && profileInfo.HistoryInfo != null)
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
                            rvInfo = device.RemoveAllBlacklist();
                            if (!rvInfo.isError && rvInfo.boolValue)
                            {
                                //this._LocalLogger.WriteLog(MacInfo.cmm_iMacNo.ToString() + "移除所有黑名单成功。" + DateTime.Now.ToString(), strMacDetail, SystemLog.SystemLog.LogType.Trace);
                            }
                            else
                            {
                                this._LocalLogger.WriteLog(MacInfo.cmm_iMacNo.ToString() + "移除所有黑名单失败。" + DateTime.Now.ToString(), strMacDetail, SystemLog.SystemLog.LogType.Error);
                            }

                            //string strSuccRes = "消费机#" + iMacNo.ToString() + "，挂失不定餐卡成功结果：" + DateTime.Now.ToString() + Environment.NewLine;//挂失成功结果记录内容
                            string strFailRes = "消费机#" + iMacNo.ToString() + "，挂失不定餐卡失败结果：" + DateTime.Now.ToString() + Environment.NewLine;//挂失失败结果记录内容
                            bool res = true;

                            foreach (MealBookingHistory_mbh_Info mealInfo in profileInfo.HistoryInfo)
                            {
                                CardUserMaster_cus_Info userInfo = listUserInfo.Find(x => x.cus_cRecordID == mealInfo.mbh_cTargetID);
                                if (userInfo != null && userInfo.PairInfo != null)
                                {
                                    rvInfo = device.AddBlacklist(userInfo.PairInfo.ucp_iCardNo.ToString());
                                    if (rvInfo.boolValue && !rvInfo.isError)
                                    {
                                        //strSuccRes += userInfo.PairInfo.ucp_iCardNo.ToString() + "，成功。" + Environment.NewLine;
                                        continue;
                                    }
                                    else
                                    {
                                        res = res && false;
                                        strFailRes += userInfo.PairInfo.ucp_iCardNo.ToString() + "，失败。" + Environment.NewLine;
                                        continue;
                                    }
                                }
                                else
                                {
                                    strFailRes += "无法找到该用户的卡信息：" + mealInfo.mbh_cTargetID.ToString() + "。" + Environment.NewLine;
                                    continue;
                                }
                            }
                            //this._LocalLogger.WriteLog(strSuccRes, string.Empty, SystemLog.SystemLog.LogType.Trace);
                            if (!res)
                            {
                                this._LocalLogger.WriteLog(strFailRes, string.Empty, SystemLog.SystemLog.LogType.Error);
                            }

                            if (profileInfo.BlacklistInfos != null)
                            {
                                //strSuccRes = "消费机#" + iMacNo.ToString() + "，挂失固定黑名单卡成功结果：" + DateTime.Now.ToString() + Environment.NewLine;//挂失成功结果记录内容
                                strFailRes = "消费机#" + iMacNo.ToString() + "，挂失固定黑名单卡失败结果：" + DateTime.Now.ToString() + Environment.NewLine;//挂失失败结果记录内容
                                res = true;

                                foreach (UserCardPair_ucp_Info blacklistItem in profileInfo.BlacklistInfos)
                                {
                                    if (blacklistItem != null)
                                    {
                                        rvInfo = device.AddBlacklist(blacklistItem.ucp_iCardNo.ToString());
                                        if (rvInfo.boolValue && !rvInfo.isError)
                                        {
                                            //strSuccRes += blacklistItem.ucp_iCardNo.ToString() + "，成功。" + Environment.NewLine;
                                            continue;
                                        }
                                        else
                                        {
                                            res = res && false;
                                            strFailRes += blacklistItem.ucp_iCardNo.ToString() + "，失败。" + Environment.NewLine;
                                            continue;
                                        }
                                    }
                                }

                                //this._LocalLogger.WriteLog(strSuccRes, string.Empty, SystemLog.SystemLog.LogType.Trace);
                                if (!res)
                                {
                                    this._LocalLogger.WriteLog(strFailRes, string.Empty, SystemLog.SystemLog.LogType.Error);
                                }
                            }
                        }
                        else
                        {
                            this._LocalLogger.WriteLog(MacInfo.cmm_iMacNo.ToString() + "--" + "设备无法连接。" + DateTime.Now.ToString(), strMacDetail, SystemLog.SystemLog.LogType.Warning);
                        }
                    }
                    else
                    {
                        this._LocalLogger.WriteLog(MacInfo.cmm_iMacNo.ToString() + "--" + "设备无法访问。" + DateTime.Now.ToString(), strMacDetail, SystemLog.SystemLog.LogType.Warning);
                    }
                }
                catch (Exception ex)
                {
                    this._LocalLogger.WriteLog(ex.Message, strMacDetail, SystemLog.SystemLog.LogType.Error);
                }
            }
        }

        /// <summary>
        /// 定餐信息外壳
        /// </summary>
        class MealInfoProfile
        {
            public ConsumeMachineMaster_cmm_Info MacInfo { get; set; }
            public List<MealBookingHistory_mbh_Info> HistoryInfo { get; set; }
            public List<UserCardPair_ucp_Info> BlacklistInfos { get; set; }
        }
    }
}
