using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Timers;
using System.Threading;
using sysBL = BLL.IBLL.SysMaster;
using sysFac = BLL.Factory.SysMaster;
using BLL.IBLL.HHZX.ConsumerDevice;
using BLL.Factory.HHZX;
using Model.IModel;
using Model.SysMaster;
using Model.HHZX.ConsumerDevice;
using PaymentEquipment.DeviceFactory;
using PaymentEquipment.IDevice;
using System.Net;
using Model.General;
using PaymentEquipment.Entity;
using Model.HHZX.ComsumeAccount;
using BLL.IBLL.HHZX.ConsumeAccount;
using System.Configuration;

namespace WinService.ConsumptionRecordCollect
{
    /// <summary>
    /// 消费机消费数据收集服务
    /// </summary>
    public partial class CollectionService : ServiceBase
    {
        #region 自定义变量

        /// <summary>
        /// 服务名称
        /// </summary>
        private string _ServiceName;
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
        /// 就餐时段信息列表
        /// </summary>
        //private List<MealTimeSpanInfo> _ListMealTimeSpan;

        private sysBL.ICodeMasterBL _ICodeMasterBL;
        private IConsumeMachineBL _IConsumeMachineBL;
        private ISourceConsumeRecordBL _ISourceConsumeRecordBL;
        private IConsumeRecordBL _IConsumeRecordBL;

        /// <summary>
        /// 操作失败后重复操作次数
        /// </summary>
        private int _iErrRetryTimes;
        /// <summary>
        /// 每次操作失败后等待时间间隔（单位：毫秒）
        /// </summary>
        private int _iErrRetryInterval;

        #endregion

        public CollectionService()
        {
            InitializeComponent();

            this._ServiceName = ConfigurationSettings.AppSettings["ServiceName"];
            if (string.IsNullOrEmpty(this._ServiceName))
            {
                this._ServiceName = "ServRecordCollect";
            }
            this._ServiceName.PadRight(20, ' ').Substring(0, 20).Trim();

            this._LocalLogger = new Common.General(Common.General.BindLocalLogInfo());
            this._DBLogger = new Common.General(Common.General.BindDbLogInfo());

            this._tmrSycnTime = new System.Timers.Timer();
            this._tmrSycnTime.Interval = 10000;
            this._tmrSycnTime.Elapsed += new ElapsedEventHandler(_tmrSycnTime_Elapsed);

            //this._ListMealTimeSpan = new List<MealTimeSpanInfo>();

            this._LocalLogger.WriteLog("服务初始化完毕。", string.Empty, SystemLog.SystemLog.LogType.Trace);
        }

        void _tmrSycnTime_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                if (!_IsCollectting)
                {
                    bool res = GetCollectionInterval();
                    if (res)
                    {
                        CollectRecord();
                    }
                }

                //清空当前时段和线程池
                if (DateTime.Now >= DateTime.Parse("00:00") && DateTime.Now <= DateTime.Parse("00:30"))
                {
                    if (this._CurrentStartSpan != TimeSpan.Parse("00:00"))
                    {
                        this._CurrentStartSpan = TimeSpan.Parse("00:00");
                        this._CurrentEndSpan = TimeSpan.Parse("00:01");
                    }
                }
            }
            catch (Exception ex)
            {
                this._LocalLogger.WriteLog(ex.Message, string.Empty, SystemLog.SystemLog.LogType.Error);
                this._DBLogger.WriteLog(ex.Message, string.Empty, SystemLog.SystemLog.LogType.Error);
            }
        }

        /// <summary>
        /// 获取收集数据时段信息
        /// </summary>
        /// <returns></returns>
        bool GetCollectionInterval()
        {
            List<CodeMaster_cmt_Info> listSpanObj = this._ICodeMasterBL.SearchRecords(new CodeMaster_cmt_Info()
            {
                cmt_cKey1 = Common.DefineConstantValue.CodeMasterDefine.KEY1_RecordCollectInterval
            });
            listSpanObj = listSpanObj.Where(x => x.cmt_fNumber > 0).ToList();

            if (listSpanObj != null)
            {
                foreach (CodeMaster_cmt_Info codeItem in listSpanObj)
                {
                    if (codeItem != null)
                    {
                        TimeSpan spanStart = TimeSpan.Parse(codeItem.cmt_cRemark);
                        TimeSpan spanEnd = TimeSpan.Parse(DateTime.Parse(codeItem.cmt_cRemark).AddHours(1).ToString("HH:mm"));
                        TimeSpan spanCurrent = TimeSpan.Parse(DateTime.Now.ToString("HH:mm"));
                        if (spanCurrent >= spanStart && spanCurrent <= spanEnd)
                        {
                            if (this._CurrentStartSpan == spanStart && this._CurrentMealType == codeItem.cmt_cValue)
                            {
                                continue;
                            }
                            else
                            {
                                this._CurrentStartSpan = spanStart;
                                this._CurrentEndSpan = spanEnd;
                                this._CurrentMealType = codeItem.cmt_cValue;
                                this._LocalLogger.WriteLog("找到时段：" + this._CurrentStartSpan.ToString() + "-" + this._CurrentEndSpan.ToString() + ", 类型" + this._CurrentMealType + "-" + DateTime.Now.ToString(), string.Empty, SystemLog.SystemLog.LogType.Trace);
                                return true;
                            }
                        }
                    }
                }
            }
            else
            {
                this._LocalLogger.WriteLog("没有找到可用的收集数据时段设置信息" + "-" + DateTime.Now.ToString(), string.Empty, SystemLog.SystemLog.LogType.Warning);
                return false;
            }
            return false;
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                this._ICodeMasterBL = sysFac.MasterBLLFactory.GetBLL<sysBL.ICodeMasterBL>(sysFac.MasterBLLFactory.CodeMaster_cmt);
                this._IConsumeMachineBL = MasterBLLFactory.GetBLL<IConsumeMachineBL>(MasterBLLFactory.ConsumeMachine);
                this._ISourceConsumeRecordBL = MasterBLLFactory.GetBLL<ISourceConsumeRecordBL>(MasterBLLFactory.SourceConsumeRecord);
                this._IConsumeRecordBL = MasterBLLFactory.GetBLL<IConsumeRecordBL>(MasterBLLFactory.ConsumeRecord);

                this._CurrentMealType = string.Empty;

                this._iErrRetryTimes = int.Parse(ConfigurationSettings.AppSettings["ErrRetryTimes"]);
                this._iErrRetryInterval = int.Parse(ConfigurationSettings.AppSettings["ErrWaitInterval"]);

                this._LocalLogger.WriteLog("服务启动准备完毕。", string.Empty, SystemLog.SystemLog.LogType.Trace);
            }
            catch (Exception ex)
            {
                this._LocalLogger.WriteLog(ex.Message, string.Empty, SystemLog.SystemLog.LogType.Error);
                this._DBLogger.WriteLog(ex.Message, string.Empty, SystemLog.SystemLog.LogType.Error);
            }
            finally
            {
                if (this._tmrSycnTime != null)
                {
                    Thread.Sleep(10000);
                    this._tmrSycnTime.Start();
                    this._LocalLogger.WriteLog("服务启动成功。", string.Empty, SystemLog.SystemLog.LogType.Trace);
                }
            }
        }

        protected override void OnStop()
        {
            try
            {
                this._tmrSycnTime.Stop();
                this._LocalLogger.WriteLog("服务停止成功。" + "-" + DateTime.Now, string.Empty, SystemLog.SystemLog.LogType.Trace);
            }
            catch (Exception ex)
            {
                this._LocalLogger.WriteLog(ex.Message, string.Empty, SystemLog.SystemLog.LogType.Error);
                this._DBLogger.WriteLog(ex.Message, string.Empty, SystemLog.SystemLog.LogType.Error);
            }
        }

        /// <summary>
        /// 收集消费数据
        /// </summary>
        void CollectRecord()
        {
            try
            {
                TimeSpan spanCurrent = TimeSpan.Parse(DateTime.Now.ToString("HH:mm"));
                if (spanCurrent >= this._CurrentStartSpan && spanCurrent <= this._CurrentEndSpan)
                {
                    this._LocalLogger.WriteLog("进入收集数据时段：" + this._CurrentStartSpan.ToString() + "-" + this._CurrentEndSpan.ToString(), string.Empty, SystemLog.SystemLog.LogType.Trace);

                    this._IsCollectting = true;

                    //获取在用的所有消费机
                    List<ConsumeMachineMaster_cmm_Info> listMacObj = this._IConsumeMachineBL.SearchRecords(new ConsumeMachineMaster_cmm_Info()
                    {
                        cmm_cStatus = Common.DefineConstantValue.ConsumeMachineStatus.Using.ToString()
                    });
                    listMacObj = listMacObj.Where(x => x.cmm_lIsActive).ToList();

                    //定餐机
                    List<ConsumeMachineMaster_cmm_Info> listMacSetMeal = listMacObj.Where(x => x.cmm_cUsageType == Common.DefineConstantValue.ConsumeMachineType.StuSetmeal.ToString()).ToList();
                    if (listMacSetMeal == null)
                        listMacSetMeal = new List<ConsumeMachineMaster_cmm_Info>();
                    //加菜机
                    List<ConsumeMachineMaster_cmm_Info> listMacFreeMoney = listMacObj.Where(x => x.cmm_cUsageType == Common.DefineConstantValue.ConsumeMachineType.StuPay.ToString()).ToList();
                    if (listMacFreeMoney == null)
                        listMacFreeMoney = new List<ConsumeMachineMaster_cmm_Info>();
                    //老师专用机
                    List<ConsumeMachineMaster_cmm_Info> listMacTech = listMacObj.Where(x => x.cmm_cUsageType == Common.DefineConstantValue.ConsumeMachineType.TeachPay.ToString()).ToList();
                    if (listMacTech == null)
                        listMacTech = new List<ConsumeMachineMaster_cmm_Info>();

                    //处理消费数据
                    if (listMacObj != null)
                    {
                        string strMacCount = "成功获取消费机记录数量：" + listMacObj.Count + "台。" + "-" + DateTime.Now.ToString() + Environment.NewLine;
                        strMacCount += "定餐机：" + listMacSetMeal.Count.ToString() + "台。" + Environment.NewLine;
                        strMacCount += "加菜机：" + listMacFreeMoney.Count.ToString() + "台。" + Environment.NewLine;
                        strMacCount += "老师机：" + listMacTech.Count.ToString() + "台。" + Environment.NewLine;
                        this._LocalLogger.WriteLog(strMacCount, string.Empty, SystemLog.SystemLog.LogType.Trace);

                        foreach (ConsumeMachineMaster_cmm_Info macItem in listMacObj)
                        {
                            try
                            {
                                //以每台消费机为单位收集消费数据
                                ReturnValueInfo rvInfo = SetMealRecordCollection(macItem);
                                //若收数失败，则进行失败重试
                                if (rvInfo.isError)
                                {
                                    int iRetryTimes = 0;
                                    //重试条件：重试次数不超过预设最大次数 且 重试后依然结果为失败 
                                    while (iRetryTimes < this._iErrRetryTimes && rvInfo.isError)
                                    {
                                        this._LocalLogger.WriteLog("机号：" + macItem.cmm_iMacNo.ToString() + "，失败重试第 " + (iRetryTimes + 1).ToString() + " 次。", string.Empty, SystemLog.SystemLog.LogType.Warning);
                                        Thread.Sleep(this._iErrRetryInterval);
                                        rvInfo = SetMealRecordCollection(macItem);
                                        if (!rvInfo.isError)
                                        {
                                            this._LocalLogger.WriteLog("机号：" + macItem.cmm_iMacNo.ToString() + "，重试后成功收数。", string.Empty, SystemLog.SystemLog.LogType.Trace);
                                        }
                                        iRetryTimes++;
                                    }

                                    if (rvInfo.isError)
                                    {
                                        this._LocalLogger.WriteLog("机号：" + macItem.cmm_iMacNo.ToString() + "，失败重试  " + this._iErrRetryTimes.ToString() + "次后依然失败。", string.Empty, SystemLog.SystemLog.LogType.Error);
                                    }
                                    else
                                    {
                                        this._LocalLogger.WriteLog("机号：" + macItem.cmm_iMacNo.ToString() + "重新收数完成。", string.Empty, SystemLog.SystemLog.LogType.Trace);
                                    }
                                }
                                else
                                {
                                    this._LocalLogger.WriteLog("机号：" + macItem.cmm_iMacNo.ToString() + "收数完成。", string.Empty, SystemLog.SystemLog.LogType.Trace);
                                }
                            }
                            catch (Exception exx)
                            {
                                this._LocalLogger.WriteLog(exx.Message, string.Empty, SystemLog.SystemLog.LogType.Error);
                            }
                            Thread.Sleep(1000);
                        }
                    }
                    else
                    {
                        this._LocalLogger.WriteLog("获取消费机信息列表失败。" + "-" + DateTime.Now.ToString(), string.Empty, SystemLog.SystemLog.LogType.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                this._LocalLogger.WriteLog(ex.Message, string.Empty, SystemLog.SystemLog.LogType.Error);
                this._DBLogger.WriteLog(ex.Message, string.Empty, SystemLog.SystemLog.LogType.Error);
            }
            finally
            {
                this._IsCollectting = false;
            }
        }

        /// <summary>
        /// 收集定餐消费数据
        /// </summary>
        /// <param name="MacObjInfo">机器主档信息</param>
        ReturnValueInfo SetMealRecordCollection(Object MacObjInfo)
        {
            ReturnValueInfo rvInfoMain = new ReturnValueInfo();
            try
            {
                ConsumeMachineMaster_cmm_Info MacInfo = MacObjInfo as ConsumeMachineMaster_cmm_Info;
                if (MacInfo != null)
                {
                    string strMacDetail = "机号：" + MacInfo.cmm_iMacNo + "-" + MacInfo.cmm_cIPAddr + ":" + MacInfo.cmm_iPort.ToString() + "-" + MacInfo.cmm_cDesc;
                    try
                    {
                        int iMacNo = MacInfo.cmm_iMacNo;
                        int iPort = MacInfo.cmm_iPort;
                        IPAddress ipAddr = IPAddress.Parse(MacInfo.cmm_cIPAddr);
                        bool resPing = Common.General.Ping(ipAddr.ToString());

                        //更新设备访问信息
                        MacInfo.cmm_lLastAccessRes = false;
                        MacInfo.cmm_dLastAccessTime = DateTime.Now;
                        MacInfo.cmm_cLast = this._ServiceName;
                        MacInfo.cmm_dLastDate = DateTime.Now;

                        if (resPing)
                        {
                            #region 可以ping通，则表示可以进行收数操作

                            AbstractPayDevice device = PaymentDeviceFactory.CreateDevice(PaymentDeviceFactory.EastRiverDevice);
                            ReturnValueInfo rvInfoConn = device.Conn(ipAddr, iPort, iMacNo);
                            if (rvInfoConn.boolValue && !rvInfoConn.isError)
                            {
                                #region 设备连接成功

                                List<PosRecord> listSourceRecord = device.GetAllConsumptionRecords();
                                if (listSourceRecord != null)
                                {
                                    if (listSourceRecord.Count > 0)
                                    {
                                        #region 收到的消费数据数量不为零

                                        try
                                        {
                                            //转换数据，保存到数据库
                                            #region 转换原始数据

                                            List<SourceConsumeRecord_scr_Info> listDBRecord = new List<SourceConsumeRecord_scr_Info>();

                                            foreach (PosRecord payItem in listSourceRecord)
                                            {
                                                try
                                                {
                                                    SourceConsumeRecord_scr_Info sRecord = new SourceConsumeRecord_scr_Info();
                                                    sRecord.scr_cAdd = this._ServiceName;
                                                    sRecord.scr_cCardNo = payItem.CardNo;
                                                    sRecord.scr_cRecordID = Guid.NewGuid();
                                                    sRecord.scr_dAddDate = DateTime.Now;
                                                    sRecord.scr_dRecordTime = payItem.RecordTime;
                                                    sRecord.scr_fBalance = payItem.Balance;
                                                    sRecord.scr_fConsume = payItem.Consume;
                                                    sRecord.scr_iMacNo = MacInfo.cmm_iMacNo;
                                                    listDBRecord.Add(sRecord);
                                                }
                                                catch (Exception exItem)
                                                {
                                                    this._LocalLogger.WriteLog(exItem.Message + "-" + DateTime.Now.ToString(), string.Empty, SystemLog.SystemLog.LogType.Error);
                                                    throw exItem;
                                                }
                                            }

                                            #endregion

                                            //插入消费数据（插入原始消费数据表，消费数据表
                                            ReturnValueInfo rvInfoInsert = this._ISourceConsumeRecordBL.BatchInsertRecord(listDBRecord);
                                            if (!rvInfoInsert.isError)
                                            {
                                                List<ConsumeRecord_csr_Info> listReturn = rvInfoConn.ValueObject as List<ConsumeRecord_csr_Info>;
                                                if (listReturn != null)
                                                {
                                                    this._LocalLogger.WriteLog("返回成功保存记录数量：" + listReturn.Count.ToString() + "条。" + "-" + DateTime.Now.ToString(), strMacDetail, SystemLog.SystemLog.LogType.Trace);
                                                }
                                                else
                                                {
                                                    this._LocalLogger.WriteLog("返回成功保存记录发生异常。" + rvInfoConn.messageText + "-" + DateTime.Now.ToString(), strMacDetail, SystemLog.SystemLog.LogType.Error);
                                                    rvInfoMain.isError = true;
                                                }

                                                MacInfo.cmm_lLastAccessRes = true;
                                                MacInfo.cmm_dLastAccessTime = DateTime.Now;

                                                //删除所有消费数据
                                                #region 消费机清数
                                                ReturnValueInfo rvInfoClear = device.RemoveAllConsumptionRecords();
                                                if (!rvInfoClear.boolValue || rvInfoClear.isError)
                                                {
                                                    this._LocalLogger.WriteLog("删除设备数据失败。" + rvInfoConn.messageText + "-" + DateTime.Now.ToString(), strMacDetail, SystemLog.SystemLog.LogType.Error);
                                                    rvInfoMain.isError = true;
                                                }
                                                #endregion
                                            }
                                            else
                                            {
                                                this._LocalLogger.WriteLog("保存消费数据失败。" + rvInfoConn.messageText + "-" + DateTime.Now.ToString(), strMacDetail, SystemLog.SystemLog.LogType.Error);
                                                rvInfoMain.isError = true;
                                            }
                                        }
                                        catch (Exception exList)
                                        {
                                            //有错误数据产生，停止收集数据
                                            this._LocalLogger.WriteLog(exList.Message, strMacDetail, SystemLog.SystemLog.LogType.Error);
                                            rvInfoMain.isError = true;
                                        }

                                        #endregion
                                    }
                                    else if (listSourceRecord.Count == 0)
                                    {
                                        rvInfoMain.isError = false;
                                        rvInfoMain.boolValue = true;
                                        this._LocalLogger.WriteLog("消费机：" + MacInfo.cmm_iMacNo + "号，没有收集到消费数据。" + DateTime.Now.ToString(), strMacDetail, SystemLog.SystemLog.LogType.Warning);
                                        MacInfo.cmm_lLastAccessRes = true;
                                        MacInfo.cmm_dLastAccessTime = DateTime.Now;
                                    }

                                    //Modify by Donald @ 12-24，获取数据操作完毕后清除黑名单
                                    rvInfoConn = device.RemoveAllBlacklist();
                                    if (rvInfoConn.boolValue && !rvInfoConn.isError)
                                    {
                                        //this._LocalLogger.WriteLog("删除设备黑名单成功。" + "-" + DateTime.Now.ToString(), strMacDetail, SystemLog.SystemLog.LogType.Trace);
                                        rvInfoMain.isError = false;
                                    }
                                    else
                                    {
                                        this._LocalLogger.WriteLog("删除设备黑名单失败。" + rvInfoConn.messageText + "-" + DateTime.Now.ToString(), strMacDetail, SystemLog.SystemLog.LogType.Error);
                                        rvInfoMain.isError = true;
                                    }
                                }
                                else
                                {
                                    this._LocalLogger.WriteLog("获取设备数据失败。" + "-" + DateTime.Now.ToString(), strMacDetail, SystemLog.SystemLog.LogType.Error);
                                    rvInfoMain.isError = true;
                                }

                                #endregion
                            }
                            else
                            {
                                this._LocalLogger.WriteLog("设备无法连接。" + "-" + DateTime.Now.ToString(), strMacDetail, SystemLog.SystemLog.LogType.Error);
                                rvInfoMain.isError = true;
                            }

                            ReturnValueInfo rvInfoDisConn = device.DisConn();
                            if (!rvInfoDisConn.boolValue || rvInfoDisConn.isError)
                            {
                                this._LocalLogger.WriteLog("设备断开失败。" + rvInfoConn.messageText + "-" + DateTime.Now.ToString(), strMacDetail, SystemLog.SystemLog.LogType.Warning);
                            }

                            #endregion
                        }
                        else
                        {
                            this._LocalLogger.WriteLog("设备无法访问(PING)。" + "-" + DateTime.Now.ToString(), strMacDetail, SystemLog.SystemLog.LogType.Warning);
                            rvInfoMain.isError = true;
                        }

                        //更新对应消费机的状态
                        ReturnValueInfo rvInfoState = this._IConsumeMachineBL.Save(MacInfo, Common.DefineConstantValue.EditStateEnum.OE_Update);
                        if (rvInfoState.isError)
                        {
                            this._LocalLogger.WriteLog("设备状态更新失败。" + "-" + DateTime.Now.ToString() + rvInfoState.messageText, strMacDetail, SystemLog.SystemLog.LogType.Error);
                            rvInfoMain.isError = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        this._LocalLogger.WriteLog(ex.Message + "-" + DateTime.Now.ToString(), strMacDetail, SystemLog.SystemLog.LogType.Error);
                        rvInfoMain.isError = true;
                    }
                }
                else
                {
                    this._LocalLogger.WriteLog("消费机转换实体失败。" + "-" + DateTime.Now.ToString(), string.Empty, SystemLog.SystemLog.LogType.Error);
                    rvInfoMain.isError = true;
                }
            }
            catch (Exception exMain)
            {
                this._LocalLogger.WriteLog(exMain.Message + "-" + DateTime.Now.ToString(), string.Empty, SystemLog.SystemLog.LogType.Error);
                rvInfoMain.messageText = exMain.Message;
                rvInfoMain.isError = true;
            }
            return rvInfoMain;
        }
    }
}
