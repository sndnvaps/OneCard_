using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.General;
using Model.HHZX.ConsumerDevice;
using System.Net;
using PaymentEquipment.IDevice;
using PaymentEquipment.Entity;
using Model.HHZX.ComsumeAccount;
using sysBL = BLL.IBLL.SysMaster;
using sysFac = BLL.Factory.SysMaster;
using BLL.IBLL.HHZX.ConsumerDevice;
using BLL.IBLL.HHZX.ConsumeAccount;
using BLL.Factory.HHZX;
using PaymentEquipment.DeviceFactory;
using System.Threading;

namespace WinCA.ConsumptionRecordCollect
{
    /// <summary>
    /// 消费机消费数据收集逻辑类
    /// </summary>
    public class CollectionService
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

        private sysBL.ICodeMasterBL _ICodeMasterBL;
        private IConsumeMachineBL _IConsumeMachineBL;
        private ISourceConsumeRecordBL _ISourceConsumeRecordBL;
        private IConsumeRecordBL _IConsumeRecordBL;
        #endregion

        public CollectionService()
        {
            try
            {
                this._ServiceName = "CRCServ";
                this._ICodeMasterBL = sysFac.MasterBLLFactory.GetBLL<sysBL.ICodeMasterBL>(sysFac.MasterBLLFactory.CodeMaster_cmt);
                this._IConsumeMachineBL = MasterBLLFactory.GetBLL<IConsumeMachineBL>(MasterBLLFactory.ConsumeMachine);
                this._ISourceConsumeRecordBL = MasterBLLFactory.GetBLL<ISourceConsumeRecordBL>(MasterBLLFactory.SourceConsumeRecord);
                this._IConsumeRecordBL = MasterBLLFactory.GetBLL<IConsumeRecordBL>(MasterBLLFactory.ConsumeRecord);
            }
            catch (Exception ex)
            {
                Console.WriteLine(getCWStyle(ex.Message, SystemLog.SystemLog.LogType.Error));
                throw;
            }

        }

        /// <summary>
        /// 收集操作
        /// </summary>
        /// <returns></returns>
        public bool Collect()
        {
            if (_LocalLogger == null)
            {
                _LocalLogger = new Common.General(Common.General.BindLocalLogInfo());
            }
            try
            {
                CollectRecord();
            }
            catch (Exception ex)
            {
                Console.WriteLine(getCWStyle(ex.Message, SystemLog.SystemLog.LogType.Error));
                return false;
            }

            return true;
        }

        /// <summary>
        /// 收集消费数据
        /// </summary>
        void CollectRecord()
        {
            try
            {
                Console.WriteLine(getCWStyle("开始进行数据收集。", null));

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
                    listMacObj = listMacObj.OrderBy(x => x.cmm_iMacNo).ToList();
                    string strMacCount = "成功获取消费机记录数量：" + listMacObj.Count + "台。" + "-" + DateTime.Now.ToString() + Environment.NewLine;
                    strMacCount += "定餐机：" + listMacSetMeal.Count.ToString() + "台。" + Environment.NewLine;
                    strMacCount += "加菜机：" + listMacFreeMoney.Count.ToString() + "台。" + Environment.NewLine;
                    strMacCount += "老师机：" + listMacTech.Count.ToString() + "台。";
                    Console.WriteLine(getCWStyle(strMacCount, SystemLog.SystemLog.LogType.Trace));

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
                                while (iRetryTimes < this._ErrRetryTimes && rvInfo.isError)
                                {
                                    Console.WriteLine(getCWStyle("机号：" + macItem.cmm_iMacNo.ToString() + "，失败重试第 " + (iRetryTimes + 1).ToString() + " 次。", SystemLog.SystemLog.LogType.Warning));
                                    Thread.Sleep(this._ErrRetryInterval);
                                    rvInfo = SetMealRecordCollection(macItem);
                                    if (!rvInfo.isError)
                                    {
                                        Console.WriteLine(getCWStyle("机号：" + macItem.cmm_iMacNo.ToString() + "，重试后成功收数。", SystemLog.SystemLog.LogType.Trace));
                                    }
                                    iRetryTimes++;
                                }

                                if (rvInfo.isError)
                                {
                                    Console.WriteLine(getCWStyle("机号：" + macItem.cmm_iMacNo.ToString() + "，失败重试  " + this._ErrRetryTimes.ToString() + "次后依然失败。", SystemLog.SystemLog.LogType.Error));
                                }
                                else
                                {
                                    Console.WriteLine(getCWStyle("机号：" + macItem.cmm_iMacNo.ToString() + "重新收数完成。", SystemLog.SystemLog.LogType.Trace));
                                }
                            }
                            else
                            {
                                Console.WriteLine(getCWStyle("机号：" + macItem.cmm_iMacNo.ToString() + "收数完成。", SystemLog.SystemLog.LogType.Trace));
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
            catch (Exception ex)
            {
                this._LocalLogger.WriteLog(ex.Message, string.Empty, SystemLog.SystemLog.LogType.Error);
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
                            Console.WriteLine(getCWStyle("设备可以ping通。", null));

                            AbstractPayDevice device = PaymentDeviceFactory.CreateDevice(PaymentDeviceFactory.EastRiverDevice);
                            ReturnValueInfo rvInfoConn = device.Conn(ipAddr, iPort, iMacNo);
                            if (rvInfoConn.boolValue && !rvInfoConn.isError)
                            {
                                #region 设备连接成功
                                Console.WriteLine(getCWStyle("设备连接成功。", null));

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
                                            Console.WriteLine(getCWStyle("得到设备原始数据：" + listSourceRecord.Count.ToString() + "条。", null));

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
                                                    Console.WriteLine(getCWStyle(exItem.Message, SystemLog.SystemLog.LogType.Error));
                                                    throw exItem;
                                                }
                                            }

                                            #endregion

                                            //插入消费数据（插入原始消费数据表，消费数据表
                                            ReturnValueInfo rvInfoInsert = this._ISourceConsumeRecordBL.BatchInsertRecord(listDBRecord);
                                            if (!rvInfoInsert.isError)
                                            {
                                                List<ConsumeRecord_csr_Info> listReturn = rvInfoInsert.ValueObject as List<ConsumeRecord_csr_Info>;
                                                if (listReturn != null)
                                                {
                                                    Console.WriteLine(getCWStyle("返回成功保存记录数量：" + listReturn.Count.ToString() + "条。", SystemLog.SystemLog.LogType.Trace));
                                                }
                                                else
                                                {
                                                    Console.WriteLine(getCWStyle("返回成功保存记录发生异常。" + rvInfoConn.messageText, SystemLog.SystemLog.LogType.Error));
                                                    rvInfoMain.isError = true;
                                                }

                                                MacInfo.cmm_lLastAccessRes = true;
                                                MacInfo.cmm_dLastAccessTime = DateTime.Now;

                                                //删除所有消费数据
                                                #region 消费机清数
                                                ReturnValueInfo rvInfoClear = device.RemoveAllConsumptionRecords();
                                                if (!rvInfoClear.boolValue || rvInfoClear.isError)
                                                {
                                                    Console.WriteLine(getCWStyle("删除设备数据失败。", SystemLog.SystemLog.LogType.Error));
                                                    rvInfoMain.isError = true;
                                                }
                                                #endregion
                                            }
                                            else
                                            {
                                                Console.WriteLine(getCWStyle("保存消费数据失败。", SystemLog.SystemLog.LogType.Error));
                                                rvInfoMain.isError = true;
                                            }
                                        }
                                        catch (Exception exList)
                                        {
                                            //有错误数据产生，停止收集数据
                                            Console.WriteLine(getCWStyle(exList.Message, SystemLog.SystemLog.LogType.Error));
                                            rvInfoMain.isError = true;
                                        }

                                        #endregion
                                    }
                                    else if (listSourceRecord.Count == 0)
                                    {
                                        rvInfoMain.isError = false;
                                        rvInfoMain.boolValue = true;
                                        Console.WriteLine(getCWStyle("消费机：" + MacInfo.cmm_iMacNo + "号，没有收集到消费数据。", SystemLog.SystemLog.LogType.Warning));
                                        MacInfo.cmm_lLastAccessRes = true;
                                        MacInfo.cmm_dLastAccessTime = DateTime.Now;
                                    }

                                    //Modify by Donald @ 12-24，获取数据操作完毕后清除黑名单
                                    rvInfoConn = device.RemoveAllBlacklist();
                                    if (rvInfoConn.boolValue && !rvInfoConn.isError)
                                    {
                                        Console.WriteLine(getCWStyle("删除设备黑名单成功。", null));
                                    }
                                    else
                                    {
                                        Console.WriteLine(getCWStyle("删除设备黑名单失败。", SystemLog.SystemLog.LogType.Error));
                                        rvInfoMain.isError = true;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine(getCWStyle("获取设备数据失败。", SystemLog.SystemLog.LogType.Error));
                                    rvInfoMain.isError = true;
                                }

                                #endregion
                            }
                            else
                            {
                                Console.WriteLine(getCWStyle("设备无法连接。", SystemLog.SystemLog.LogType.Error));
                                rvInfoMain.isError = true;
                            }

                            ReturnValueInfo rvInfoDisConn = device.DisConn();
                            if (!rvInfoDisConn.boolValue || rvInfoDisConn.isError)
                            {
                                Console.WriteLine(getCWStyle("设备断开失败。", SystemLog.SystemLog.LogType.Warning));
                            }

                            #endregion
                        }
                        else
                        {
                            Console.WriteLine(getCWStyle("设备无法访问(PING)。", SystemLog.SystemLog.LogType.Warning));
                            rvInfoMain.isError = true;
                        }

                        //更新对应消费机的状态
                        ReturnValueInfo rvInfoState = this._IConsumeMachineBL.Save(MacInfo, Common.DefineConstantValue.EditStateEnum.OE_Update);
                        if (rvInfoState.isError)
                        {
                            Console.WriteLine(getCWStyle("设备状态更新失败。", SystemLog.SystemLog.LogType.Error));
                            rvInfoMain.isError = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(getCWStyle(ex.Message, SystemLog.SystemLog.LogType.Error));
                        rvInfoMain.isError = true;
                    }
                }
                else
                {
                    Console.WriteLine(getCWStyle("消费机转换实体失败。", SystemLog.SystemLog.LogType.Error));
                    rvInfoMain.isError = true;
                }
            }
            catch (Exception exMain)
            {
                Console.WriteLine(getCWStyle(exMain.Message, SystemLog.SystemLog.LogType.Error));
                rvInfoMain.messageText = exMain.Message;
                rvInfoMain.isError = true;
            }
            return rvInfoMain;
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
