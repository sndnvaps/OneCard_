using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using BLL.IBLL.HHZX.ConsumeAccount;
using BLL.IBLL.SysMaster;
using BLL.Factory.HHZX;
using Model.SysMaster;
using Model.General;
using System.Configuration;
using Model.HHZX.ComsumeAccount;
using BLL.IBLL.HHZX.ConsumerDevice;
using Model.HHZX.ConsumerDevice;
using System.Threading;
using Common;

namespace WinService.UserAccountFundSync
{
    public partial class UserAccountFundSyncService : ServiceBase
    {
        #region 自定义变量

        /// <summary>
        /// 服务名称
        /// </summary>
        private string _ServiceName;

        /// <summary>
        /// 本地日志记录器
        /// </summary>
        private Common.General _LocalLogger;
        /// <summary>
        /// 数据库日志记录器
        /// </summary>
        private Common.General _DBLogger;

        private IPreConsumeRecordBL _IPreConsumeRecordBL;
        private IConsumeRecordBL _IConsumeRecordBL;
        private ICodeMasterBL _ICodeMasterBL;
        private IConsumeMachineBL _IConsumeMachineBL;
        private ICardUserAccountBL _ICardUserAccountBL;

        /// <summary>
        /// 主时钟
        /// </summary>
        private System.Timers.Timer _tmrMain;
        /// <summary>
        /// 收数时间列表
        /// </summary>
        List<TimeSpan> _ListCollectSpan;

        bool _IsLocalDataRefrashed;
        /// <summary>
        /// yun
        /// </summary>
        bool _IsRunning;

        #endregion

        public UserAccountFundSyncService()
        {
            InitializeComponent();

            try
            {
                this._LocalLogger = new Common.General(Common.General.BindLocalLogInfo());
                this._DBLogger = new Common.General(Common.General.BindDbLogInfo());

                this._ServiceName = ConfigurationSettings.AppSettings["ServiceName"];
                if (string.IsNullOrEmpty(this._ServiceName))
                {
                    this._ServiceName = "ServAccountSync";
                }
                this._ServiceName.PadRight(20, ' ').Substring(0, 20).Trim();

                this._IPreConsumeRecordBL = MasterBLLFactory.GetBLL<IPreConsumeRecordBL>(MasterBLLFactory.PreConsumeRecord);
                this._IConsumeRecordBL = MasterBLLFactory.GetBLL<IConsumeRecordBL>(MasterBLLFactory.ConsumeRecord);
                this._ICodeMasterBL = BLL.Factory.SysMaster.MasterBLLFactory.GetBLL<ICodeMasterBL>(BLL.Factory.SysMaster.MasterBLLFactory.CodeMaster_cmt);
                this._IConsumeMachineBL = MasterBLLFactory.GetBLL<IConsumeMachineBL>(MasterBLLFactory.ConsumeMachine);
                this._ICardUserAccountBL = MasterBLLFactory.GetBLL<ICardUserAccountBL>(MasterBLLFactory.CardUserAccount);

                this._tmrMain = new System.Timers.Timer();
                this._tmrMain.Interval = 60000;
                this._tmrMain.Elapsed += new System.Timers.ElapsedEventHandler(_tmrMain_Elapsed);

                this._LocalLogger.WriteLog("服务初始化完毕。 " + DateTime.Now.ToString(), string.Empty, SystemLog.SystemLog.LogType.Trace);
            }
            catch (Exception ex)
            {
                this._LocalLogger.WriteLog("服务初始化失败。" + ex.Message + " " + DateTime.Now.ToString(), string.Empty, SystemLog.SystemLog.LogType.Error);
            }
        }

        void _tmrMain_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (DateTime.Now > DateTime.Now.Date && DateTime.Now < DateTime.Now.Date.AddHours(1))
            {
                if (!this._IsLocalDataRefrashed)
                {
                    this._ListCollectSpan = getCollectTimeSpan();
                    this._IsLocalDataRefrashed = true;
                }
            }
            else
            {
                if (!this._IsRunning)
                {
                    cosumeRecordAnalysis();
                }
            }
        }

        protected override void OnStart(string[] args)
        {
            Thread.Sleep(5000);
            try
            {
                this._ListCollectSpan = getCollectTimeSpan();
                this._tmrMain.Start();
                this._IsLocalDataRefrashed = true;

                this._LocalLogger.WriteLog("服务启动成功。 " + DateTime.Now.ToString(), string.Empty, SystemLog.SystemLog.LogType.Trace);
            }
            catch (Exception ex)
            {
                this._LocalLogger.WriteLog("服务启动失败。" + ex.Message + " " + DateTime.Now.ToString(), string.Empty, SystemLog.SystemLog.LogType.Error);
            }
        }

        protected override void OnStop()
        {
            try
            {
                this._tmrMain.Stop();
                this._ListCollectSpan = new List<TimeSpan>();
                this._IsLocalDataRefrashed = false;
                this._LocalLogger.WriteLog("服务停止成功。 " + DateTime.Now.ToString(), string.Empty, SystemLog.SystemLog.LogType.Trace);
            }
            catch (Exception ex)
            {
                this._LocalLogger.WriteLog("服务停止失败。" + ex.Message + " " + DateTime.Now.ToString(), string.Empty, SystemLog.SystemLog.LogType.Error);
            }
        }

        /// <summary>
        /// 获取收数时段列表，在收数服务开始收数后一小时内不作操作，以免数据访问冲突
        /// </summary>
        /// <returns></returns>
        List<TimeSpan> getCollectTimeSpan()
        {
            List<TimeSpan> listTime = new List<TimeSpan>();
            List<CodeMaster_cmt_Info> listKeys = this._ICodeMasterBL.SearchRecords(new CodeMaster_cmt_Info()
            {
                cmt_cKey1 = Common.DefineConstantValue.CodeMasterDefine.KEY1_RecordCollectInterval
            });
            if (listKeys != null)
            {
                listKeys = listKeys.Where(x => x.cmt_fNumber > 0).ToList();
                if (listKeys != null && listKeys.Count > 0)
                {
                    foreach (CodeMaster_cmt_Info item in listKeys)
                    {
                        TimeSpan tsBegin = TimeSpan.Parse(item.cmt_cRemark);
                        listTime.Add(tsBegin);
                    }
                }
            }
            return listTime;
        }

        /// <summary>
        /// 消费数据分析
        /// </summary>
        /// <returns></returns>
        bool cosumeRecordAnalysis()
        {
            this._IsRunning = true;
            bool res = true;
            try
            {
                bool canStart = false;
                TimeSpan tsNow = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
                foreach (TimeSpan item in this._ListCollectSpan)
                {
                    TimeSpan tsEnd = new TimeSpan();
                    if (item.Hours == 23)
                    {
                        tsEnd = new TimeSpan(23, 59, 59);
                    }
                    else
                    {
                        tsEnd = new TimeSpan(item.Hours + 1, item.Minutes, 0);
                    }

                    if (tsNow > item && tsNow < tsEnd)
                    {
                        canStart = true;
                        break;
                    }
                }
                if (!canStart)
                {
                    this._IsRunning = false;
                    return false;
                }

                //消费机最后同步时间
                DateTime dtMacSync = DateTime.MinValue;
                //找出消费机主档信息，检查是否全部收数完毕，是则进行平数处理，否则不操作
                #region 找出消费机主档信息，检查是否全部收数完毕，是则进行平数处理，否则不操作

                List<ConsumeMachineMaster_cmm_Info> listMachineInfos = this._IConsumeMachineBL.SearchRecords(new ConsumeMachineMaster_cmm_Info()
                    {
                        cmm_cStatus = Common.DefineConstantValue.ConsumeMachineStatus.Using.ToString(),
                    });
                if (listMachineInfos == null)
                {
                    this._IsRunning = false;
                    return false;
                }
                else
                {
                    if (listMachineInfos != null && listMachineInfos.Count > 0)
                    {
                        if (listMachineInfos != null && listMachineInfos.Count > 0)
                        {
                            dtMacSync = listMachineInfos[0].cmm_dLastAccessTime;
                        }
                    }

                    List<ConsumeMachineMaster_cmm_Info> listUnSyncMachineInfos = listMachineInfos.Where(x =>
                          x.cmm_dLastAccessTime.Hour != dtMacSync.Hour).ToList();
                    if (listUnSyncMachineInfos != null && listUnSyncMachineInfos.Count > 0)
                    {
                        this._IsRunning = false;
                        return false;
                    }

                    List<ConsumeMachineMaster_cmm_Info> listUnConnMachineInfos = listMachineInfos.Where(x =>
                        x.cmm_lIsActive == true
                        && x.cmm_lLastAccessRes == false
                        ).ToList();
                    if (listUnConnMachineInfos == null || (listUnConnMachineInfos != null && listUnConnMachineInfos.Count > 0))
                    {
                        this._IsRunning = false;
                        return false;
                    }
                }

                #endregion

                //就餐时段
                #region 学生真实就餐时段列表
                List<CodeMaster_cmt_Info> listMealTimeSpan = this._ICodeMasterBL.SearchRecords(new CodeMaster_cmt_Info()
                {
                    cmt_cKey1 = Common.DefineConstantValue.CodeMasterDefine.KEY1_MealTimeSpan
                });
                if (listMealTimeSpan == null || (listMealTimeSpan != null && listMealTimeSpan.Count < 1))
                {
                    this._IsRunning = false;
                    return false;
                }
                #endregion

                //定餐时段
                #region 学生定餐设置生成时间列表

                List<CodeMaster_cmt_Info> listBookingMealTimeSpan = this._ICodeMasterBL.SearchRecords(new CodeMaster_cmt_Info()
                {
                    cmt_cKey1 = Common.DefineConstantValue.CodeMasterDefine.KEY1_BWListUploadInterval
                });
                if (listBookingMealTimeSpan == null || (listBookingMealTimeSpan != null && listBookingMealTimeSpan.Count < 1))
                {
                    this._IsRunning = false;
                    return false;
                }

                #endregion

                //未结算的未可确认扣费的消费记录
                #region  获取当前所有未结算的未可确认扣费的消费记录

                List<PreConsumeRecord_pcs_Info> listUnSettlePreCost = this._IPreConsumeRecordBL.SearchRecords(new PreConsumeRecord_pcs_Info()
                {
                    pcs_cConsumeType = Common.DefineConstantValue.ConsumeMoneyFlowType.IndeterminateCost.ToString()
                });
                List<PreConsumeRecord_pcs_Info> listWaitSettlePreCost = this._IPreConsumeRecordBL.SearchRecords(new PreConsumeRecord_pcs_Info()
                {
                    pcs_cConsumeType = Common.DefineConstantValue.ConsumeMoneyFlowType.AdvanceMealCost.ToString()
                });
                listUnSettlePreCost.AddRange(listWaitSettlePreCost);
                if (listUnSettlePreCost != null)
                {
                    //条件分开两次进行筛选，方便数据观察
                    listUnSettlePreCost = listUnSettlePreCost.Where(x =>
                        x.pcs_lIsSettled == false//需要状态为未结算
                        ).ToList();
                    listUnSettlePreCost = listUnSettlePreCost.Where(x =>
                        x.pcs_dConsumeDate <= dtMacSync//使用消费机最后同步时间之前的未结算数据进行同步
                        ).ToList();
                }

                #endregion

                //对冲平数记录
                #region 获取当前所有对冲数据记录

                List<PreConsumeRecord_pcs_Info> listHedge = this._IPreConsumeRecordBL.SearchRecords(new PreConsumeRecord_pcs_Info()
                {
                    pcs_cConsumeType = Common.DefineConstantValue.ConsumeMoneyFlowType.HedgeFund.ToString()
                });
                listHedge = listHedge.Where(x =>
                    x.pcs_lIsSettled == false//需要为未结算状态
                    && x.pcs_dConsumeDate <= dtMacSync//需要为消费机最后同步前的数据
                    ).ToList();

                #endregion

                //未结算的消费记录
                #region 获取当前所有状态为未结算的打卡消费数据

                List<ConsumeRecord_csr_Info> listUnSettleCardCost = this._IConsumeRecordBL.SearchRecords(new ConsumeRecord_csr_Info()
                {
                    IsSettled = false
                });
                if (listUnSettleCardCost != null && listUnSettleCardCost.Count > 0)
                {
                    listUnSettleCardCost = listUnSettleCardCost.Where(x =>
                        x.csr_dConsumeDate <= dtMacSync//需要为消费机最后同步前的数据
                        ).ToList();
                }

                #endregion

                /*<Start-------------------------------------------用于最后数据处理的容器-------------------------------------------------->*/
                //待更新的打卡消费记录
                List<ConsumeRecord_csr_Info> listUpdate_Consume = new List<ConsumeRecord_csr_Info>();
                //待更新的预扣费记录
                List<PreConsumeRecord_pcs_Info> listUpdate_PreCost = new List<PreConsumeRecord_pcs_Info>();
                //无需要处理预扣费的消费记录
                List<ConsumeRecord_csr_Info> listUpdate_UnMealConsume = new List<ConsumeRecord_csr_Info>();
                //待删除的多余预扣费记录
                List<PreConsumeRecord_pcs_Info> listDelete_PreCost = new List<PreConsumeRecord_pcs_Info>();
                /*<End-------------------------------------------用于最后数据处理的容器--------------------------------------------------->*/

                if (listUnSettleCardCost != null && listUnSettleCardCost.Count > 0)//存在未结算处理的消费记录时
                {
                    #region 处理打卡数据（定餐打卡，饮料打卡，加菜打卡，热水打卡）

                    //逐条消费数据进行比对，用作处理未确认扣款记录和对冲记录
                    foreach (ConsumeRecord_csr_Info consumeItem in listUnSettleCardCost)
                    {
                        if (consumeItem.csr_cConsumeType == DefineConstantValue.ConsumeMachineType.StuSetmeal.ToString())
                        {
                            #region 处理定餐消费记录

                            //判断为定餐消费记录，用于消除未确定消费记录
                            List<PreConsumeRecord_pcs_Info> listResPreCost = listUnSettlePreCost.Where(x =>
                                  x.pcs_cUserID == consumeItem.csr_cCardUserID//需为消费用户对应ID
                                  && x.MealType == consumeItem.csr_cMealType//餐类型需要相同
                                      //&& x.pcs_dConsumeDate.Date == consumeItem.csr_dConsumeDate.Date
                                  && x.pcs_dAddDate.Date == consumeItem.csr_dConsumeDate.Date//以添加时间为准，找出
                                  && Math.Abs(x.pcs_fCost) == Math.Abs(consumeItem.csr_fConsumeMoney)//消费金额需一致
                                  ).ToList();
                            if (listResPreCost != null && listResPreCost.Count > 0)//！要注意这里会不会搜索出两条记录出来
                            {
                                if (listResPreCost.Count > 1)
                                {
                                    bool lSign = true;//标识特殊case：同一条打卡消费记录对应两条定餐未结算记录
                                }
                                //消费数据符合该条未确认数据记录的条件，更新该条消费记录的状态为已结，并更新对应的未确定扣费定餐记录置为已结状态
                                consumeItem.csr_lIsSettled = true;
                                consumeItem.csr_dSettleTime = DateTime.Now;
                                listUpdate_Consume.Add(consumeItem);

                                //按升序排序多条待付款预扣费记录
                                List<PreConsumeRecord_pcs_Info> listPreTmp = listResPreCost.OrderBy(x => x.pcs_dAddDate).ToList();
                                for (int i = 0; i < listPreTmp.Count; i++)
                                {
                                    PreConsumeRecord_pcs_Info preCost = listPreTmp[i];
                                    preCost.pcs_cSourceID = consumeItem.csr_cRecordID;//转换预付款记录的源记录ID，原为定餐记录，现为消费记录
                                    preCost.pcs_lIsSettled = true;
                                    preCost.pcs_dSettleTime = DateTime.Now;
                                    preCost.pcs_cConsumeType = Common.DefineConstantValue.ConsumeMoneyFlowType.SetMealCost.ToString();
                                    preCost.pcs_dConsumeDate = consumeItem.csr_dConsumeDate;
                                    PreConsumeRecord_pcs_Info resCompUp = listUpdate_PreCost.Find(x => x.pcs_cRecordID == preCost.pcs_cRecordID);
                                    PreConsumeRecord_pcs_Info resCompDel = listDelete_PreCost.Find(x => x.pcs_cRecordID == preCost.pcs_cRecordID);
                                    if (resCompUp == null && resCompDel == null)
                                    {
                                        if (i == 0)
                                        {
                                            listUpdate_PreCost.Add(preCost);
                                        }
                                        else
                                        {
                                            listDelete_PreCost.Add(preCost);
                                        }
                                    }
                                    else
                                    {
                                        bool lSign = true;//异常数据标识
                                    }
                                }
                            }
                            else
                            {
                                //无符合该消费记录的待付款记录
                                listUpdate_UnMealConsume.Add(consumeItem);
                            }

                            #endregion
                        }
                        else
                        {
                            //判断为非定餐消费记录，用于消减冲数记录
                            consumeItem.csr_lIsSettled = true;
                            consumeItem.csr_dSettleTime = DateTime.Now;
                            listUpdate_Consume.Add(consumeItem);
                        }
                    }

                    #endregion
                }

                //找出有定餐但无打卡数据的未确定预消费记录
                #region 筛选出定餐但无打卡的数据

                int iCount = 0;
                int iCOunt2 = 0;
                foreach (PreConsumeRecord_pcs_Info unMealPreCost in listUnSettlePreCost)
                {
                    PreConsumeRecord_pcs_Info resUnMeal = listUpdate_PreCost.Find(x => x.pcs_cRecordID == unMealPreCost.pcs_cRecordID);
                    PreConsumeRecord_pcs_Info resDelMeal = listDelete_PreCost.Find(x => x.pcs_cRecordID == unMealPreCost.pcs_cRecordID);
                    if (resUnMeal == null && resDelMeal == null)
                    {
                        unMealPreCost.pcs_cConsumeType = Common.DefineConstantValue.ConsumeMoneyFlowType.SetMealCost.ToString();
                        unMealPreCost.pcs_dAddDate = DateTime.Now;
                        unMealPreCost.pcs_cAdd = this._ServiceName;
                        listUpdate_PreCost.Add(unMealPreCost);
                        iCount++;
                    }
                    else
                    {
                        iCOunt2++;
                    }
                }

                #endregion

                //消减平账冲数记录
                #region 消减平账记录

                var groupUserHedge = listHedge.GroupBy(x => x.pcs_cUserID);
                foreach (var userItem in groupUserHedge)
                {
                    //以人为单位组成数据组别
                    Guid userID = userItem.Key;
                    //找出本次收数得到的指定用户的打卡记录
                    List<ConsumeRecord_csr_Info> listUserConsume = listUpdate_Consume.Where(x => x.csr_cCardUserID == userID).ToList();
                    //找出未被处理到类型的打卡记录，并添加到打卡对比记录列表
                    List<ConsumeRecord_csr_Info> listUnMealConsume = listUpdate_UnMealConsume.Where(x => x.csr_cCardUserID == userID).ToList();
                    if (listUnMealConsume != null && listUnMealConsume.Count > 0)
                    {
                        listUserConsume.AddRange(listUnMealConsume);
                    }

                    if (listUserConsume == null || (listUserConsume != null && listUserConsume.Count < 1))
                    {
                        continue;
                    }

                    //以对冲记录产生的时间升序排列，时间早的靠前
                    List<PreConsumeRecord_pcs_Info> listUserHedge = userItem.OrderBy(x => x.pcs_dConsumeDate).ToList();
                    if (listUserHedge != null && listUserHedge.Count > 0)
                    {
                        for (int i = 0; i < listUserHedge.Count; i++)
                        {
                            List<ConsumeRecord_csr_Info> listConsumeComp = new List<ConsumeRecord_csr_Info>();
                            if (i > 0 && i == listUserHedge.Count - 1)
                            {
                                //对冲记录数大于0，且为最后一条记录时，找出是否存在打卡记录在最后一条对冲记录和倒数第二条对冲记录之间
                                listConsumeComp = listUserConsume.Where(x => x.csr_dConsumeDate <= listUserHedge[i].pcs_dConsumeDate && x.csr_dConsumeDate > listUserHedge[i - 1].pcs_dConsumeDate).ToList();
                            }
                            else if (i < listUserHedge.Count - 1)
                            {
                                listConsumeComp = listUserConsume.Where(x => x.csr_dConsumeDate < listUserHedge[i + 1].pcs_dConsumeDate && x.csr_dConsumeDate >= listUserHedge[i].pcs_dConsumeDate).ToList();
                            }
                            else if (i == 0 && listUserHedge.Count == 1)
                            {
                                listConsumeComp = listUserConsume.Where(x => x.csr_dConsumeDate <= listUserHedge[i].pcs_dConsumeDate).ToList();
                            }

                            if (listConsumeComp == null)
                                continue;

                            if (listConsumeComp.Count > 1)
                            {
                                decimal fComp = Math.Abs(listUserHedge[i].pcs_fCost) - Math.Abs(listConsumeComp.Sum(x => x.csr_fConsumeMoney));
                                if (fComp <= 0)
                                {
                                    listUserHedge[i].pcs_lIsSettled = true;
                                    listUserHedge[i].pcs_dSettleTime = DateTime.Now;
                                    listUpdate_PreCost.Add(listUserHedge[i]);
                                }
                                else
                                {
                                    listUserHedge[i].pcs_dConsumeDate = DateTime.Now;
                                    listUserHedge[i].pcs_fCost = fComp;
                                    listUpdate_PreCost.Add(listUserHedge[i]);
                                }

                                foreach (ConsumeRecord_csr_Info item in listConsumeComp)
                                {
                                    ConsumeRecord_csr_Info consumeHedge = listUpdate_Consume.Find(x => x.csr_cRecordID == item.csr_cRecordID);
                                    if (consumeHedge == null)
                                    {
                                        consumeHedge = listUpdate_UnMealConsume.Find(x => x.csr_cRecordID == item.csr_cRecordID);
                                        consumeHedge.csr_lIsSettled = true;
                                        consumeHedge.csr_dSettleTime = DateTime.Now;
                                        listUpdate_Consume.Add(consumeHedge);
                                    }
                                    else
                                    {
                                        consumeHedge.csr_lIsSettled = true;
                                        consumeHedge.csr_dSettleTime = DateTime.Now;
                                    }
                                }
                            }
                            else
                            {
                                if (listUserHedge[i].pcs_dConsumeDate < dtMacSync)
                                {
                                    //若无对应的消费记录，且时间早于收数时间，则删除此对冲记录
                                    listDelete_PreCost.Add(listUserHedge[i]);
                                }
                            }
                        }
                    }
                }

                #endregion

                //如没有被1、定餐冲数；2、平数记录冲数，则进行结算处理
                if (listUpdate_UnMealConsume != null && listUpdate_UnMealConsume.Count > 0)
                {
                    foreach (ConsumeRecord_csr_Info item in listUpdate_UnMealConsume)
                    {
                        if (!item.csr_lIsSettled)
                        {
                            item.csr_lIsSettled = true;
                            item.csr_dSettleTime = DateTime.Now;
                            listUpdate_Consume.Add(item);
                        }
                    }
                }

                if (listUpdate_PreCost.Count > 0 || listUpdate_Consume.Count > 0)
                {
                    ReturnValueInfo rvInfo = this._ICardUserAccountBL.BatchSyncAccountDetail(listUpdate_PreCost, listDelete_PreCost, listUpdate_Consume);
                    if (rvInfo.boolValue && !rvInfo.isError)
                    {
                        this._LocalLogger.WriteLog("同步账户数据成功！" + DateTime.Now.ToString(), string.Empty, SystemLog.SystemLog.LogType.Trace);
                        res = true;
                    }
                    else
                    {
                        if (rvInfo.isError)
                        {
                            this._LocalLogger.WriteLog("同步账户数据失败！" + DateTime.Now.ToString() + rvInfo.messageText, string.Empty, SystemLog.SystemLog.LogType.Error);
                        }
                        else
                        {
                            this._LocalLogger.WriteLog("同步账户数据失败！" + DateTime.Now.ToString() + rvInfo.messageText, string.Empty, SystemLog.SystemLog.LogType.Warning);
                        }
                        res = false;
                    }
                }
                else
                {
                    this._IsRunning = false;
                    return true;
                }
            }
            catch (Exception ex)
            {
                this._LocalLogger.WriteLog(ex.Message, string.Empty, SystemLog.SystemLog.LogType.Error);
                res = false;
            }

            this._IsRunning = false;
            return res;
        }

        /// <summary>
        /// 获取消费记录的餐类型
        /// </summary>
        /// <param name="listTimeSpan"></param>
        /// <param name="dtConsumeTime"></param>
        /// <returns></returns>
        string getConsumeMealType(List<CodeMaster_cmt_Info> listTimeSpan, DateTime dtConsumeTime)
        {
            string strLunch = listTimeSpan.Find(x => x.cmt_cKey2 == Common.DefineConstantValue.MealType.Lunch.ToString()).cmt_cRemark;
            string strSupper = listTimeSpan.Find(x => x.cmt_cKey2 == Common.DefineConstantValue.MealType.Supper.ToString()).cmt_cRemark;

            TimeSpan tsLunch = TimeSpan.Parse(strLunch);
            TimeSpan tsSupper = TimeSpan.Parse(strSupper);
            TimeSpan tsConsume = TimeSpan.Parse(dtConsumeTime.ToString("HH:mm:ss"));

            if (tsConsume < tsLunch)
            {
                return Common.DefineConstantValue.MealType.Breakfast.ToString();
            }
            else if (tsConsume >= tsLunch && tsConsume < tsSupper)
            {
                return Common.DefineConstantValue.MealType.Lunch.ToString();
            }
            else
            {
                return Common.DefineConstantValue.MealType.Supper.ToString();
            }
        }

        /// <summary>
        /// 定餐餐类型
        /// </summary>
        /// <param name="listTimeSpan"></param>
        /// <param name="dtConsumeTime"></param>
        /// <returns></returns>
        string getBookingMealType(List<CodeMaster_cmt_Info> listTimeSpan, DateTime dtConsumeTime)
        {
            string strLunch = listTimeSpan.Find(x => x.cmt_cValue == Common.DefineConstantValue.MealType.Lunch.ToString()).cmt_cRemark;
            string strSupper = listTimeSpan.Find(x => x.cmt_cValue == Common.DefineConstantValue.MealType.Supper.ToString()).cmt_cRemark;

            TimeSpan tsLunch = TimeSpan.Parse(strLunch);
            TimeSpan tsSupper = TimeSpan.Parse(strSupper);
            TimeSpan tsConsume = TimeSpan.Parse(dtConsumeTime.ToString("HH:mm:ss"));

            if (tsConsume < tsLunch)
            {
                return Common.DefineConstantValue.MealType.Breakfast.ToString();
            }
            else if (tsConsume >= tsLunch && tsConsume < tsSupper)
            {
                return Common.DefineConstantValue.MealType.Lunch.ToString();
            }
            else
            {
                return Common.DefineConstantValue.MealType.Supper.ToString();
            }
        }
    }
}
