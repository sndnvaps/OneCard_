using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PaymentEquipment.IDevice;
using PaymentEquipment.DLL;
using Model.General;
using System.Net;
using PaymentEquipment.Enum;
using PaymentEquipment.Entity;
using Model.HHZX.ComsumeAccount;
using BLL.IBLL.HHZX.ConsumeAccount;
using BLL.Factory.HHZX;
using BLL.IBLL.HHZX.ConsumerDevice;
using Model.HHZX.ConsumerDevice;

namespace PaymentEquipment.DeviceImplement
{
    public class EastRiverDevice : AbstractPayDevice
    {
        private EastRiverDevice_base _Device;

        public EastRiverDevice()
        {
            this._Device = new EastRiverDevice_base();
        }

        public override ReturnValueInfo Conn(IPAddress IPAddr, int iPort, int iMacID)
        {
            ReturnValueInfo rvInfo = new ReturnValueInfo();
            try
            {
                rvInfo.boolValue = this._Device.ER_ConnNet(IPAddr.ToString().ToCharArray(), iPort, iMacID);
                base.MacNo = iMacID;
                base.IP = IPAddr;
            }
            catch (Exception ex)
            {
                rvInfo.isError = true;
                rvInfo.messageText = ex.Message;
            }
            return rvInfo;
        }

        public override ReturnValueInfo DisConn()
        {
            ReturnValueInfo rvInfo = new ReturnValueInfo();
            try
            {
                rvInfo.boolValue = this._Device.ER_DisconnMac();
            }
            catch (Exception ex)
            {
                rvInfo.isError = true;
                rvInfo.messageText = ex.Message;
            }
            return rvInfo;
        }

        public override ReturnValueInfo SetManagementCard(string strManageCardNo)
        {
            throw new NotImplementedException();
        }

        public override string GetManagementCard()
        {
            throw new NotImplementedException();
        }

        public override ReturnValueInfo SetDeviceNo(int iDeviceNewNo)
        {
            ReturnValueInfo rvInfo = new ReturnValueInfo();
            try
            {
                rvInfo.boolValue = this._Device.ER_SetMacID(iDeviceNewNo);
            }
            catch (Exception ex)
            {
                rvInfo.isError = true;
                rvInfo.messageText = ex.Message;
            }
            return rvInfo;
        }

        public override ReturnValueInfo SyncDeviceTime()
        {
            ReturnValueInfo rvInfo = new ReturnValueInfo();
            try
            {
                rvInfo.boolValue = this._Device.ER_SetMacTime(DateTime.Now);
            }
            catch (Exception ex)
            {
                rvInfo.isError = true;
                rvInfo.messageText = ex.Message;
            }
            return rvInfo;
        }

        public override DateTime? GetDeviceTime()
        {
            return this._Device.ER_GetMacTime();
        }

        public override ReturnValueInfo SetDeviceMode(EnumDeviceMode Mode)
        {
            ReturnValueInfo rvInfo = new ReturnValueInfo();
            try
            {
                rvInfo.boolValue = this._Device.ER_SetWorkModelState(Mode, EnumDeviceState.Common);
            }
            catch (Exception ex)
            {
                rvInfo.isError = true;
                rvInfo.messageText = ex.Message;
            }
            return rvInfo;
        }

        public override EnumDeviceMode ReadDeviceMode()
        {
            try
            {
                EnumDeviceMode mode;
                EnumDeviceState state;

                bool res = this._Device.ER_GetWorkModelState(out mode, out state);
                return mode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override ReturnValueInfo AddBlacklist(string strCardNo)
        {
            ReturnValueInfo rvInfo = new ReturnValueInfo();
            try
            {
                rvInfo.boolValue = this._Device.ER_SetSigleNameList(strCardNo, EastRiverDevice_base.ER_ListType.Blacklist);
            }
            catch (Exception ex)
            {
                rvInfo.isError = true;
                rvInfo.messageText = ex.Message;
            }
            return rvInfo;
        }

        public override ReturnValueInfo AddWhitelist(string strCardNo)
        {
            ReturnValueInfo rvInfo = new ReturnValueInfo();
            try
            {
                rvInfo.boolValue = this._Device.ER_SetSigleNameList(strCardNo, EastRiverDevice_base.ER_ListType.AttendanceWhiteList);
            }
            catch (Exception ex)
            {
                rvInfo.isError = true;
                rvInfo.messageText = ex.Message;
            }
            return rvInfo;
        }

        public override ReturnValueInfo RemoveBlacklist(string strCardNo)
        {
            ReturnValueInfo rvInfo = new ReturnValueInfo();
            try
            {
                rvInfo.boolValue = this._Device.ER_DelSigleList(EastRiverDevice_base.ER_ListType.Blacklist, strCardNo);
            }
            catch (Exception ex)
            {
                rvInfo.isError = true;
                rvInfo.messageText = ex.Message;
            }
            return rvInfo;
        }

        public override ReturnValueInfo RemoveWhitelist(string strCardNo)
        {
            ReturnValueInfo rvInfo = new ReturnValueInfo();
            try
            {
                rvInfo.boolValue = this._Device.ER_DelSigleList(EastRiverDevice_base.ER_ListType.AttendanceWhiteList, strCardNo);
            }
            catch (Exception ex)
            {
                rvInfo.isError = true;
                rvInfo.messageText = ex.Message;
            }
            return rvInfo;
        }

        public override ReturnValueInfo RemoveAllBlacklist()
        {
            ReturnValueInfo rvInfo = new ReturnValueInfo();
            try
            {
                //rvInfo.boolValue = this._Device.ER_ClearAllList();
                rvInfo.boolValue = this._Device.ER_DelBatchList(EastRiverDevice_base.ER_ListType.Blacklist);
            }
            catch (Exception ex)
            {
                rvInfo.isError = true;
                rvInfo.messageText = ex.Message;
            }
            return rvInfo;
        }

        public override ReturnValueInfo RemoveAllWhitelist()
        {
            ReturnValueInfo rvInfo = new ReturnValueInfo();
            try
            {
                //rvInfo.boolValue = this._Device.ER_ClearAllList();
                rvInfo.boolValue = this._Device.ER_DelBatchList(EastRiverDevice_base.ER_ListType.AttendanceWhiteList);
            }
            catch (Exception ex)
            {
                rvInfo.isError = true;
                rvInfo.messageText = ex.Message;
            }
            return rvInfo;
        }

        public override Model.General.ReturnValueInfo SetDevicePwd(string strOldPwd, string strNewPwd)
        {
            ReturnValueInfo rvInfo = new ReturnValueInfo();

            try
            {
                rvInfo.boolValue = _Device.ER_SetMacPwd(strOldPwd, strNewPwd);
            }
            catch (Exception ex)
            {
                rvInfo.isError = true;
                rvInfo.messageText = ex.Message;
            }

            return rvInfo;
        }

        public override List<PosRecord> GetAllConsumptionRecords()
        {
            try
            {
                return this._Device.ER_GetAllRecord();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public override List<ConsumeRecord_csr_Info> GetAllProfileRecords()
        {
            List<ConsumeRecord_csr_Info> listReturn = null;
            try
            {
                IConsumeMachineBL MacBLL = MasterBLLFactory.GetBLL<IConsumeMachineBL>(MasterBLLFactory.ConsumeMachine);
                ConsumeMachineMaster_cmm_Info machineInfo = MacBLL.SearchRecords(new ConsumeMachineMaster_cmm_Info() { cmm_iMacNo = base.MacNo, cmm_cIPAddr = base.IP.ToString() }).FirstOrDefault();
                if (machineInfo == null)
                {
                    return listReturn;
                }

                bool isPingSucc = Common.General.Ping(base.IP.ToString());
                List<PosRecord> listRecord = this._Device.ER_GetAllRecord();
                if (listRecord != null && isPingSucc)
                {
                    if (listRecord.Count > 0)
                    {
                        //转换数据，保存到数据库
                        #region 转换原始数据

                        List<SourceConsumeRecord_scr_Info> listDBRecord = new List<SourceConsumeRecord_scr_Info>();
                        foreach (PosRecord payItem in listRecord)
                        {
                            try
                            {
                                SourceConsumeRecord_scr_Info sRecord = new SourceConsumeRecord_scr_Info();
                                sRecord.scr_cAdd = "sys";
                                sRecord.scr_cCardNo = payItem.CardNo;
                                sRecord.scr_cRecordID = Guid.NewGuid();
                                sRecord.scr_dAddDate = DateTime.Now;
                                sRecord.scr_dRecordTime = payItem.RecordTime;
                                sRecord.scr_fBalance = payItem.Balance;
                                sRecord.scr_fConsume = payItem.Consume;
                                sRecord.scr_iMacNo = base.MacNo;
                                listDBRecord.Add(sRecord);
                            }
                            catch (Exception exItem)
                            {
                                throw exItem;
                            }
                        }

                        #endregion

                        ISourceConsumeRecordBL BLL = MasterBLLFactory.GetBLL<ISourceConsumeRecordBL>(MasterBLLFactory.SourceConsumeRecord);
                        ReturnValueInfo rvInfo = BLL.BatchInsertRecord(listDBRecord);

                        if (rvInfo.boolValue && !rvInfo.isError)
                        {
                            machineInfo.cmm_lLastAccessRes = true;

                            this.RemoveAllConsumptionRecords();
                            listReturn = rvInfo.ValueObject as List<ConsumeRecord_csr_Info>;
                        }
                        else
                        {
                            machineInfo.cmm_lLastAccessRes = false;
                        }
                    }
                    else
                    {
                        machineInfo.cmm_lLastAccessRes = true;
                        listReturn = new List<ConsumeRecord_csr_Info>();
                    }
                }
                else
                {
                    machineInfo.cmm_lLastAccessRes = false;
                }

                machineInfo.cmm_dLastAccessTime = DateTime.Now;
                machineInfo.cmm_cLast = "sys";
                machineInfo.cmm_dLastDate = DateTime.Now;
                MacBLL.Save(machineInfo, Common.DefineConstantValue.EditStateEnum.OE_Update);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return listReturn;
        }

        public override ReturnValueInfo RemoveAllConsumptionRecords()
        {
            ReturnValueInfo rvInfo = new ReturnValueInfo();
            try
            {
                rvInfo.boolValue = this._Device.ER_DeleteAllRecord();
            }
            catch (Exception ex)
            {
                rvInfo.isError = true;
                rvInfo.messageText = ex.Message;
            }
            return rvInfo;
        }

        public override ReturnValueInfo SetReadCardInterval(int iInterval)
        {
            ReturnValueInfo rvInfo = new ReturnValueInfo();
            try
            {
                rvInfo.boolValue = this._Device.ER_SetMacReadInterval(iInterval);
            }
            catch (Exception ex)
            {
                rvInfo.isError = true;
                rvInfo.messageText = ex.Message;
            }
            return rvInfo;
        }

        public override int GetReadCardInterval()
        {
            return this._Device.ER_GetMacReadInterval();
        }

        public override decimal GetDayConsumeLimit()
        {
            try
            {
                return this._Device.ER_GetDayConsumeLimit();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public override ReturnValueInfo SetDayConsumeLimit(decimal dLimit)
        {
            ReturnValueInfo rvInfo = new ReturnValueInfo();
            try
            {
                rvInfo.boolValue = this._Device.ER_SetDayConsumeLimit(dLimit);
            }
            catch (Exception ex)
            {
                rvInfo.isError = true;
                rvInfo.messageText = ex.Message;
            }
            return rvInfo;
        }

        public override decimal GetPerConsumeLimit()
        {
            try
            {
                return this._Device.ER_GetPerConsumeLimit();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public override ReturnValueInfo SetPerConsumeLimit(decimal dLimit)
        {
            ReturnValueInfo rvInfo = new ReturnValueInfo();
            try
            {
                rvInfo.boolValue = this._Device.ER_SetPerConsumeLimit(dLimit);
            }
            catch (Exception ex)
            {
                rvInfo.isError = true;
                rvInfo.messageText = ex.Message;
            }
            return rvInfo;
        }

        public override IPAddress GetMachineIP()
        {
            IPAddress ipAddr = IPAddress.Parse("192.168.20.200");
            this._Device.ER_GetMachineNetworkInfo();
            return ipAddr;
        }

        public override int GetClientCode()
        {
            return this._Device.ER_GetClientCode();
        }

        public override bool SetClientCode()
        {
            return this._Device.ER_SetSectionNum(1);
        }

        public override ReturnValueInfo SetMacTimeSpan(List<ConsumeTimeSpan> listSpan)
        {
            ReturnValueInfo rvInfo = new ReturnValueInfo();
            try
            {
                if (listSpan == null)
                {
                    rvInfo.isError = true;
                    return rvInfo;
                }
                List<PaymentEquipment.DLL.EastRiverDevice_base.TimepriceSpan> listBaseSpan = new List<EastRiverDevice_base.TimepriceSpan>();
                foreach (ConsumeTimeSpan item in listSpan)
                {
                    PaymentEquipment.DLL.EastRiverDevice_base.TimepriceSpan span = new EastRiverDevice_base.TimepriceSpan();
                    span.begintime = Convert.ToChar(item.BeginTime.Hours).ToString() + Convert.ToChar(item.BeginTime.Minutes).ToString();
                    span.endtime = Convert.ToChar(item.EndTime.Hours).ToString() + Convert.ToChar(item.EndTime.Minutes).ToString();
                    span.price = (int)(item.SetMoney * 100);
                    span.clockmodule = (int)item.DeviceMode;
                    span.times = 0;
                    listBaseSpan.Add(span);

                    this._Device.ER_SetSpanTimeofPrice(item.BeginTime.ToString(), item.EndTime.ToString(), item.LimitedTimes, (int)(item.SetMoney * 100));
                }
                //rvInfo.boolValue = this._Device.ER_SetConsumeSpan(listBaseSpan);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return rvInfo;
        }

        public override List<ConsumeTimeSpan> GetMacTimeSpan()
        {
            List<ConsumeTimeSpan> listSpan = new List<ConsumeTimeSpan>();
            try
            {
                PaymentEquipment.DLL.EastRiverDevice_base.TimepriceSpan[] times = this._Device.ER_GetConsumeSpan();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return listSpan;
        }

        public override ReturnValueInfo SetConsumetimeParam(int setcurmodel, int setcurallow)
        {
            ReturnValueInfo rvInfo = new ReturnValueInfo();
            try
            {
                rvInfo.boolValue = this._Device.ER_SetConsumetimeParam(setcurmodel, setcurallow);
            }
            catch (Exception ex)
            {
                rvInfo.isError = true;
                rvInfo.messageText = ex.Message;
            }
            return rvInfo;
        }
    }
}
