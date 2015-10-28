using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using PaymentEquipment.Enum;
using Model.General;
using PaymentEquipment.Entity;

namespace PaymentEquipment.DLL
{
    public class EastRiverDevice_base
    {
        /// <summary>
        /// 设备句柄
        /// </summary>
        private IntPtr _DevicePort;

        private const string C_strDLLPath = @"\DLL\EastRiver.dll";

        private const decimal C_dMoneyRate = 25600;

        private const short C_iTimesRate = 256;

        /// <summary>
        /// 取得函数库DLL 版本号
        /// </summary>
        /// <returns></returns>
        [DllImport(C_strDLLPath, EntryPoint = "GetDLLVersion")]
        public static extern double ER_GetDLLVersion();

        #region 设备连接相关

        /// <summary>
        /// 连接设备，TCP/IP方式
        /// </summary>
        /// <param name="arrIP">IP地址，Ascii码</param>
        /// <param name="iPort">网络端口号</param>
        /// <param name="iMacID">机号</param>
        /// <returns></returns>
        public bool ER_ConnNet(char[] arrIP, int iPort, int iMacID)
        {
            bool res = false;
            try
            {
                this._DevicePort = OpenClientSocket(arrIP, iPort);
                res = ConnMac(this._DevicePort, iMacID);
            }
            catch (Exception)
            {
                return false;
            }
            return res;
        }

        /// <summary>
        /// 连接设备，串口方式
        /// </summary>
        /// <param name="iPort">串口号</param>
        /// <param name="iBaudRate">波特率</param>
        /// <param name="iMacID">机号</param>
        /// <returns></returns>
        public bool ER_ConnComm(int iPort, int iBaudRate, int iMacID)
        {
            bool res = false;
            try
            {
                this._DevicePort = OpenCommPort(iPort, iBaudRate);
                res = ConnMac(this._DevicePort, iMacID);
            }
            catch (Exception)
            {
                return false;
            }
            return res;
        }

        /// <summary>
        /// 断开设备连接
        /// </summary>
        /// <returns></returns>
        public bool ER_DisconnMac()
        {
            bool resDicConn = DisconnMac(this._DevicePort);
            bool resClosePort = ClosePortHandle(this._DevicePort);
            bool res = resDicConn && resClosePort;
            return res;
        }

        /// <summary>
        /// 打开串口通讯端口
        /// </summary>
        /// <param name="iPort">端口号，允许值1-256</param>
        /// <param name="iBaudRate">端口波特率，其中88X,89X,860默认是9600，69X默认19200</param>
        /// <returns></returns>
        [DllImport(C_strDLLPath, EntryPoint = "OpenCommPort")]
        private static extern IntPtr OpenCommPort(int iPort, int iBaudRate);

        /// <summary>
        /// 打开TCP/IP通讯端口
        /// </summary>
        /// <param name="arrIP">IP地址</param>
        /// <param name="iIPPort">通讯端口（默认为4100）</param>
        /// <returns></returns>
        [DllImport(C_strDLLPath, EntryPoint = "OpenClientSocket")]
        private static extern IntPtr OpenClientSocket(char[] arrIP, int iIPPort);

        /// <summary>
        /// 联机
        /// </summary>
        /// <param name="hPort">句柄</param>
        /// <param name="iMacID">机号，允许值：1-65535</param>
        /// <returns></returns>
        [DllImport(C_strDLLPath, EntryPoint = "CallClock")]
        private static extern bool ConnMac(IntPtr hPort, int iMacID);

        /// <summary>
        /// 脱机
        /// </summary>
        /// <param name="hPort">句柄</param>
        /// <returns></returns>
        [DllImport(C_strDLLPath, EntryPoint = "UnCallClock")]
        private static extern bool DisconnMac(IntPtr hPort);

        /// <summary>
        /// 关闭端口
        /// </summary>
        /// <param name="hPort">句柄</param>
        /// <returns></returns>
        [DllImport(C_strDLLPath, EntryPoint = "ClosePortHandle")]
        private static extern bool ClosePortHandle(IntPtr hPort);

        #endregion

        #region 设备管理函数

        [DllImport(C_strDLLPath, EntryPoint = "GetClockVersion")]
        private static extern bool GetClockVersion(IntPtr hPort, StringBuilder sbVersion);
        /// <summary>
        ///  获取设备版本号
        /// </summary>
        /// <returns></returns>
        public string ER_GetMacVersion()
        {
            StringBuilder sbVersion = new StringBuilder();
            bool res = GetClockVersion(this._DevicePort, sbVersion);
            return sbVersion.ToString();
        }

        /// <summary>
        /// 取得设备型号
        /// </summary>
        /// <param name="hPort">句柄</param>
        /// <param name="iModel">返回设备型号</param>
        /// <param name="fVersion">返回设备版本号</param>
        /// <param name="iType">返回设备类型</param>
        /// <returns></returns>
        [DllImport(C_strDLLPath, EntryPoint = "GetClockModel")]
        private static extern bool GetMacModel(IntPtr hPort, ref int iModel, ref double fVersion, ref int iType);
        /// <summary>
        /// 获得设备型号信息
        /// </summary>
        /// <param name="iModel">设备型号</param>
        /// <param name="fVersion">设备版本号</param>
        /// <param name="iType">设备类型</param>
        /// <returns></returns>
        public bool ER_GetMachineInfo(ref int iModel, ref double fVersion, ref int iType)
        {
            return GetMacModel(this._DevicePort, ref iModel, ref fVersion, ref iType);
        }

        /// <summary>
        /// 删除机台所有记录
        /// </summary>
        /// <param name="hPort">句柄</param>
        /// <returns></returns>
        [DllImport(C_strDLLPath, EntryPoint = "ClearAllReadCard")]
        private static extern bool ClearAllReadCard(IntPtr hPort);
        /// <summary>
        /// 删除机台所有记录
        /// </summary>
        /// <returns></returns>
        public bool ER_DeleteAllRecord()
        {
            return ClearAllReadCard(this._DevicePort);
        }

        /// <summary>
        /// 读取设备时间
        /// </summary>
        /// <param name="hPort">句柄</param>
        /// <param name="arrMacTime">返回设备当前时间,格式:yyyyMMddhhnnss(yyyy 年MM 月dd 日hh 时nn分ss 秒)</param>
        /// <returns></returns>
        [DllImport(C_strDLLPath, EntryPoint = "ReadClockTimeString")]
        private static extern bool ReadMacStrTime(IntPtr hPort, byte[] arrMacTime);
        /// <summary>
        /// 获得设备时间
        /// </summary>
        /// <returns></returns>
        public DateTime? ER_GetMacTime()
        {
            DateTime dtMac;
            try
            {
                string strMacTime = "20";
                byte[] arrTime = new byte[12];
                bool resGetMacTime = EastRiverDevice_base.ReadMacStrTime(this._DevicePort, arrTime);
                foreach (byte item in arrTime)
                {
                    strMacTime += Convert.ToChar(item).ToString();
                }
                if (strMacTime.Length != 14)
                {
                    return null;
                }

                strMacTime = strMacTime.Substring(0, 4) + "-" + strMacTime.Substring(4, 2) + "-" + strMacTime.Substring(6, 2) + " " + strMacTime.Substring(8, 2) + ":" + strMacTime.Substring(10, 2) + ":" + strMacTime.Substring(12, 2);
                dtMac = DateTime.Parse(strMacTime);
            }
            catch (Exception)
            {
                return null;
            }

            return dtMac;
        }

        /// <summary>
        /// 修改设备时间
        /// </summary>
        /// <param name="hPort">句柄</param>
        /// <param name="arrMacTime">待设置的新设备时间，格式为:yyyyMMddhhnnss(yyyy 年MM 月dd 日hh 时nn 分ss秒), 如果是第二代或以上的产品,如：ER-880、ER-690 及ER-980 等, 需要在最后附加一个星期值, 星期天为0, 星期一为1, 星期六为6，例：200501201030454 表示2005 年1 月20 日10 时30 分45 秒星期四</param>
        /// <returns></returns>
        [DllImport(C_strDLLPath, EntryPoint = "SetClockTimeString")]
        public static extern bool SetClockStrTime(IntPtr hPort, byte[] arrMacTime);
        /// <summary>
        /// 设定设备时间
        /// </summary>
        /// <param name="dtSetTime">待设置的新设备时间，格式为:yyyyMMddhhnnss(yyyy 年MM 月dd 日hh 时nn 分ss秒), 如果是第二代或以上的产品,如：ER-880、ER-690 及ER-980 等, 需要在最后附加一个星期值, 星期天为0, 星期一为1, 星期六为6，例：200501201030454 表示2005 年1 月20 日10 时30 分45 秒星期四</param>
        /// <returns></returns>
        public bool ER_SetMacTime(DateTime dtSetTime)
        {
            string strTime = dtSetTime.ToString("yyyyMMddHHmmss");
            strTime += ((int)dtSetTime.DayOfWeek).ToString();
            if (strTime.Length != 15)
            {
                return false;
            }
            List<byte> listTime = new List<byte>();
            for (int i = 0; i < strTime.Length; i++)
            {
                char cItem = Convert.ToChar(strTime.Substring(i, 1));
                byte bItem = Convert.ToByte(cItem);
                listTime.Add(bItem);
            }

            bool resSetTime = SetClockStrTime(this._DevicePort, listTime.ToArray());
            return resSetTime;
        }

        [DllImport(C_strDLLPath, EntryPoint = "SetClockID")]
        private static extern bool SetClockID(IntPtr hPort, int iNewMacID);
        /// <summary>
        /// 设定机号
        /// </summary>
        /// <param name="iNewID">新机号</param>
        /// <returns></returns>
        public bool ER_SetMacID(int iNewMacID)
        {
            return SetClockID(this._DevicePort, iNewMacID);
        }

        [DllImport(C_strDLLPath, EntryPoint = "ReadRepeatClockerTime")]
        private static extern bool ReadRepeatClockerTime(IntPtr hPort, ref int iTimeInterval);
        /// <summary>
        /// 读取机台重复刷卡的时间间隔
        /// </summary>
        /// <returns></returns>
        public int ER_GetMacReadInterval()
        {
            int iInterval = -1;
            bool res = ReadRepeatClockerTime(this._DevicePort, ref iInterval);
            return iInterval;
        }

        [DllImport(C_strDLLPath, EntryPoint = "SetRepeatClockerTime")]
        private static extern bool SetRepeatClockerTime(IntPtr hPort, int iTimeInterval);
        /// <summary>
        /// 设置机台重复刷卡的时间间隔
        /// </summary>
        /// <param name="iInterval">时间间隔，单位：分钟，大于0小于99</param>
        /// <returns></returns>
        public bool ER_SetMacReadInterval(int iInterval)
        {
            if (iInterval < 0)
            {
                iInterval = 0;
            }
            else if (iInterval > 99)
            {
                iInterval = 99;
            }
            return SetRepeatClockerTime(this._DevicePort, iInterval);
        }

        [DllImport(C_strDLLPath, EntryPoint = "ReadManagerCard")]
        private static extern bool ReadManagerCard(IntPtr hPort, StringBuilder strMCardNo);
        /// <summary>
        /// 读取机台的管理卡卡号
        /// </summary>
        /// <returns></returns>
        public string ER_GetManageCardNo(EnumCardFormat CardVersion)
        {
            StringBuilder sbCardNo = new StringBuilder();
            string strCardNo = string.Empty;
            bool res = ReadManagerCard(this._DevicePort, sbCardNo);
            if (res)
            {
                if (CardVersion == EnumCardFormat.CARDVER_690CARD)
                {
                    string strCardNoFull = sbCardNo.ToString();
                    strCardNo = strCardNoFull.Substring(strCardNoFull.Length - 7, 7);
                }
            }
            return strCardNo;
        }

        [DllImport(C_strDLLPath, EntryPoint = "SetManagerCard")]
        private static extern bool SetManagerCard(IntPtr hPort, StringBuilder strMCardNo);
        /// <summary>
        /// 设置机台的管理卡卡号
        /// </summary>
        /// <param name="strManageCardNo"></param>
        /// <returns></returns>
        public bool ER_SetManageCardNo(string strManageCardNo, EnumCardFormat CardVersion)
        {
            if (string.IsNullOrEmpty(strManageCardNo))
            {
                return false;
            }

            if (CardVersion == EnumCardFormat.CARDVER_690CARD)
            {
                if (strManageCardNo.Length > 7)
                {
                    return false;
                }
                strManageCardNo = "EF".PadRight(9, '0') + strManageCardNo.PadLeft(7, '0');
            }

            StringBuilder sbCardNo = new StringBuilder(strManageCardNo);
            return SetManagerCard(this._DevicePort, sbCardNo);
        }

        #region 698、699专用

        //[DllImport(C_strDLLPath, EntryPoint = "ReadSpanTimeofPrice")]
        //private static extern int ReadSpanTimeofPrice(IntPtr hPort, TimepriceSpan[] arrSpan, int iCount);

        [DllImport(@"\DLL\ERDriver_LeoThlink.dll", EntryPoint = "ER_ReadSpanTimeofPrice")]
        private static extern int ER_ReadSpanTimeofPrice(IntPtr hPort, ref char[] s);


        public TimepriceSpan[] ER_GetConsumeSpan()
        {
            List<TimepriceSpan> listSpan = new List<TimepriceSpan>();
            for (int i = 0; i < 3; i++)
            {
                listSpan.Add(new TimepriceSpan());
            }
            TimepriceSpan[] arrSpan = listSpan.ToArray();
            char[] ch = new char[255];
            ER_ReadSpanTimeofPrice(this._DevicePort, ref ch);

            string s = new string(ch);

            return arrSpan;
        }

        ///// <summary>
        ///// 设置时段消费信息
        ///// </summary>
        ///// <param name="hPort">句柄</param>
        ///// <param name="arrSpan">时段参数</param>
        ///// <param name="iCount">时段数量</param>
        ///// <returns></returns>
        //[DllImport(C_strDLLPath, EntryPoint = "SetSpanTimeofPrice")]
        //private static extern int SetSpanTimeofPrice(IntPtr hPort, TimepriceSpan[] arrSpan, int iCount);

        //public bool ER_SetConsumeSpan(List<TimepriceSpan> listTimeSpan)
        //{
        //    int iRes = SetSpanTimeofPrice(this._DevicePort, listTimeSpan.ToArray(), listTimeSpan.Count);
        //    if (iRes == 0)
        //    {
        //        return true;
        //    }
        //    return false; ;
        //}


        /// <summary>
        /// 设置时段消费信息
        /// </summary>
        /// <param name="hPort"></param>
        /// <param name="beginTime"></param>
        /// <param name="endTime"></param>
        /// <param name="times"></param>
        /// <param name="cost"></param>
        /// <returns></returns>
        [DllImport(@"\DLL\ERDriver_LeoThlink.dll", EntryPoint = "ER_SetSpanTimeofPrice")]
        private static extern int ER_SetSpanTimeofPrice(IntPtr hPort, string beginTime,string endTime,int times,int cost);

        public bool ER_SetSpanTimeofPrice(string beginTime, string endTime, int times, int cost)
        {
            int iRes = ER_SetSpanTimeofPrice(this._DevicePort,beginTime, endTime, times - 1, cost);
            if (iRes == 0)
            {
                return true;
            }
            return false; ;
        }

        /// <summary>
        /// 消費時段
        /// </summary>
        /// <param name="hPort"></param>
        /// <param name="setcurmodel"></param>
        /// <param name="setcurallow"></param>
        /// <returns></returns>
        [DllImport(C_strDLLPath, EntryPoint = "SetConsumetimeParam")]
        private static extern int SetConsumetimeParam(IntPtr hPort,int setcurmodel,int setcurallow);

        public bool ER_SetConsumetimeParam(int setcurmodel, int setcurallow)
        {
            int iRes = SetConsumetimeParam(this._DevicePort, setcurmodel, setcurallow);
            if(iRes == 0)
            {
                return true;
            }
            return false;
        }

        [DllImport(C_strDLLPath, EntryPoint = "ReadLanIP")]
        private static extern int ReadLanIP(IntPtr hPort, string IPAddr, string SubAddr, string SubMask, ref int iTCPPort, ref int iUDPPort, ref int iAutoIP, string MacAddr);
        public bool ER_GetMachineNetworkInfo()
        {
            try
            {
                string strIPAddr = string.Empty;
                string strSubAddr = string.Empty;
                string strSubMask = string.Empty;
                int iPortTCP = 0;
                int iPortUDP = 0;
                int iAutoIP = 0;
                string strMacAddr = string.Empty;
                int iRes = ReadLanIP(this._DevicePort, strIPAddr, strSubAddr, strSubMask, ref iPortTCP, ref iPortUDP, ref iAutoIP, strMacAddr);
                if (iRes == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 读取消费机工作模式和状态（698）
        /// </summary>
        /// <param name="hPort">句柄</param>
        /// <param name="iMode">工作模式</param>
        /// <param name="iWorkState">工作状态</param>
        /// <returns></returns>
        [DllImport(C_strDLLPath, EntryPoint = "GetWorkModelSta")]
        private static extern int GetWorkModelSta(IntPtr hPort, ref int iMode, ref int iWorkState);
        /// <summary>
        /// 获取消费机工作模式和状态（698）
        /// </summary>
        /// <param name="mode">工作模式</param>
        /// <param name="state">工作状态</param>
        /// <returns></returns>
        public bool ER_GetWorkModelState(out EnumDeviceMode mode, out EnumDeviceState state)
        {
            bool res = false;
            try
            {
                int iMode = -1;
                int iState = -1;
                int iRes = GetWorkModelSta(this._DevicePort, ref iMode, ref iState);

                if (iRes == 0)
                {
                    res = true;
                }
                else
                {
                    mode = EnumDeviceMode.Unknown;
                    state = EnumDeviceState.Unknown;

                    return res;
                }

                switch (iMode)
                {
                    case (int)EnumDeviceMode.CustomMoney:
                        mode = EnumDeviceMode.CustomMoney;
                        break;
                    case (int)EnumDeviceMode.FixedMoney:
                        mode = EnumDeviceMode.FixedMoney;
                        break;
                    default:
                        mode = EnumDeviceMode.Unknown;
                        break;
                }

                switch (iState)
                {
                    case (int)EnumDeviceState.Common:
                        state = EnumDeviceState.Common;
                        break;
                    case (int)EnumDeviceState.Online:
                        state = EnumDeviceState.Online;
                        break;
                    default:
                        state = EnumDeviceState.Unknown;
                        break;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return res;
        }

        /// <summary>
        /// 设置消费机工作模式和状态（698）
        /// </summary>
        /// <param name="hPort"></param>
        /// <param name="iMode"></param>
        /// <param name="iWorkState"></param>
        /// <returns></returns>
        [DllImport(C_strDLLPath, EntryPoint = "SetWorkModelSta")]
        private static extern int SetWorkModelSta(IntPtr hPort, int iMode, int iWorkState);
        /// <summary>
        /// 设置消费机工作模式和状态（698）
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public bool ER_SetWorkModelState(EnumDeviceMode mode, EnumDeviceState state)
        {
            try
            {
                int iRes = SetWorkModelSta(this._DevicePort, (int)mode, (int)state);
                if (iRes == 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// 读取日消费限额（698）
        /// </summary>
        /// <param name="hPort">句柄</param>
        /// <param name="iLimit">限额值</param>
        /// <returns></returns>
        [DllImport(C_strDLLPath, EntryPoint = "ReadDayConsumelimit")]
        private static extern int ReadDayConsumelimit(IntPtr hPort, ref int iLimit);
        /// <summary>
        /// 获得日消费限额（698）
        /// </summary>
        /// <returns></returns>
        public decimal ER_GetDayConsumeLimit()
        {
            try
            {
                decimal dLimit = -1;
                int iLimit = -1;
                int iRes = ReadDayConsumelimit(this._DevicePort, ref iLimit);
                if (iRes == 0)
                    dLimit = decimal.Divide((decimal)iLimit, 100);
                return dLimit;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// 设置日消费限额（698）
        /// </summary>
        /// <param name="hPort">句柄</param>
        /// <param name="iLimit">限额值</param>
        /// <returns></returns>
        [DllImport(C_strDLLPath, EntryPoint = "SetDayConsumelimit")]
        private static extern int SetDayConsumelimit(IntPtr hPort, int iLimit);
        /// <summary>
        /// 设置日消费限额（698）
        /// </summary>
        /// <param name="dLimit">限额值</param>
        /// <returns></returns>
        public bool ER_SetDayConsumeLimit(decimal dLimit)
        {
            try
            {
                int iLimit = (int)(dLimit * 100);
                int iRes = SetDayConsumelimit(this._DevicePort, iLimit);
                if (iRes == 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// 读取每次消费限额（698）
        /// </summary>
        /// <param name="hPort">句柄</param>
        /// <param name="iLimit">限额值</param>
        /// <returns></returns>
        [DllImport(C_strDLLPath, EntryPoint = "ReadperConsumelimit")]
        private static extern int ReadperConsumelimit(IntPtr hPort, ref int iLimit);
        /// <summary>
        /// 获得每次消费限额（698）
        /// </summary>
        /// <returns></returns>
        public decimal ER_GetPerConsumeLimit()
        {
            try
            {
                decimal dLimit = -1;
                int iLimit = -1;
                int iRes = ReadperConsumelimit(this._DevicePort, ref iLimit);
                if (iRes == 0)
                    dLimit = decimal.Divide((decimal)iLimit, 100);
                return dLimit;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// 设置每次消费限额（698）
        /// </summary>
        /// <param name="hPort">句柄</param>
        /// <param name="iLimit">限额值</param>
        /// <returns></returns>
        [DllImport(C_strDLLPath, EntryPoint = "SetperConsumelimit")]
        private static extern int SetperConsumelimit(IntPtr hPort, int iLimit);
        /// <summary>
        /// 设置每次消费限额（698）
        /// </summary>
        /// <param name="dLimit">限额值</param>
        /// <returns></returns>
        public bool ER_SetPerConsumeLimit(decimal dLimit)
        {
            try
            {
                int iLimit = (int)(dLimit * 100);
                int iRes = SetperConsumelimit(this._DevicePort, iLimit);
                if (iRes == 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion

        #endregion

        #region 消费设备记录处理函数

        #region 获取消费机数据

        /// <summary>
        /// 暂存获取的消费记录
        /// </summary>
        private List<T690ReadData> _ListConsRecords;

        [DllImport(C_strDLLPath, EntryPoint = "ReadAllRecord", ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
        private static extern int ReadAllRecord(IntPtr hPort, IntPtr hData, TDataProcessDelegate procDelegate, TimeLapseDelegae timeDelegate);
        public List<PosRecord> ER_GetAllRecord()
        {
            this._ListConsRecords = new List<T690ReadData>();

            procDelegate = ReceiveData;
            timeDelegate = TimeLapse;

            int res = ReadAllRecord(this._DevicePort, this._DevicePort, procDelegate, timeDelegate);

            List<PosRecord> listRecod = new List<PosRecord>();
            foreach (T690ReadData itemT690 in this._ListConsRecords)
            {
                PosRecord posRecord = GetPosRecord(itemT690);
                if (posRecord != null)
                {
                    listRecod.Add(posRecord);
                }
            }

            return listRecod;
        }

        /// <summary>
        /// 获得自定义格式的消费记录
        /// </summary>
        /// <param name="t690Data">源数据</param>
        /// <returns></returns>
        private PosRecord GetPosRecord(T690ReadData t690Data)
        {
            PosRecord posRecord = new PosRecord();
            try
            {
                posRecord.CardNo = t690Data.CardNo;
                posRecord.RecordIndex = t690Data.Record_Total / C_iTimesRate;
                posRecord.Consume = (decimal)t690Data.flag / C_dMoneyRate;
                posRecord.Balance = (decimal)t690Data.transcount / C_dMoneyRate - posRecord.Consume;

                string strYear = t690Data.TimeString.Substring(0, 4);
                string strMonth = t690Data.TimeString.Substring(4, 2);
                //返回的原始数据中，月份的十位数无法反映0以外的数字
                if (strMonth == "00" || strMonth == "01" || strMonth == "02")
                {
                    strMonth = DateTime.Now.Month.ToString().PadLeft('0');
                }
                string strDay = t690Data.TimeString.Substring(6, 2);
                string strHour = t690Data.TimeString.Substring(8, 2);
                string strMinute = t690Data.TimeString.Substring(10, 2);
                string strSeconds = t690Data.TimeString.Substring(12, 2);
                posRecord.RecordTime = DateTime.Parse(strYear + "-" + strMonth + "-" + strDay + " " + strHour + ":" + strMinute + ":" + strSeconds);
            }
            catch (Exception)
            {
                //需添异常数据的记录
                return null;
            }
            return posRecord;
        }

        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.StdCall)]
        private delegate void TimeLapseDelegae(IntPtr lpData, int iCallBackTime);
        private static TimeLapseDelegae timeDelegate;
        private void TimeLapse(IntPtr lpData, int iCallBackTime) { }
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.StdCall)]
        private delegate bool TDataProcessDelegate(IntPtr lpData, [System.Runtime.InteropServices.MarshalAs(UnmanagedType.LPArray, SizeConst = 1)]T690ReadData[] readData);
        private static TDataProcessDelegate procDelegate;
        private bool ReceiveData(IntPtr lpData, T690ReadData[] readData)
        {
            this._ListConsRecords.Add(readData[0]);

            //必须返回true，收数才可以自动循环
            return true;
        }

        #endregion

        #region 黑白名单上传

        [DllImport(C_strDLLPath, EntryPoint = "DownLoadOneNameList")]
        private static extern int DownLoadOneNameList(IntPtr hPort, PNameList nameList);
        /// <summary>
        /// 下传单个名单
        /// </summary>
        /// <param name="strCardNo">卡号</param>
        /// <param name="listType">名单类型</param>
        /// <returns></returns>
        public bool ER_SetSigleNameList(string strCardNo, ER_ListType listType)
        {
            PNameList nameList = new PNameList();
            nameList.cardno = strCardNo;
            nameList.listtype = (int)listType;
            int iRes = DownLoadOneNameList(this._DevicePort, nameList);
            if (iRes == 0)
            {
                return true;
            }
            return false;
        }

        [DllImport(C_strDLLPath, EntryPoint = "DeleteNameList")]
        private static extern bool DeleteNameList(IntPtr hPort, int ilistType, int iDelAll, string strCardNo);
        /// <summary>
        /// 删除单个名单
        /// </summary>
        /// <param name="listType">名单类型</param>
        /// <param name="strCardNo">卡号</param>
        /// <returns></returns>
        public bool ER_DelSigleList(ER_ListType listType, string strCardNo)
        {
            return DeleteNameList(this._DevicePort, (int)listType, 0, strCardNo);
        }
        /// <summary>
        /// 批量删除名单
        /// </summary>
        /// <param name="listType">名单类型</param>
        /// <returns></returns>
        public bool ER_DelBatchList(ER_ListType listType)
        {
            return DeleteNameList(this._DevicePort, (int)listType, 1, string.Empty);
        }

        [DllImport(C_strDLLPath, EntryPoint = "ClearAllNamelist")]
        private static extern bool ClearAllNamelist(IntPtr hPort);
        /// <summary>
        /// 清空所有名单
        /// </summary>
        /// <returns></returns>
        public bool ER_ClearAllList()
        {
            return ClearAllNamelist(this._DevicePort);
        }

        #endregion

        #endregion

        #region 发卡器相关

        //[DllImport(C_strDLLPath, EntryPoint = "SetClientCode")]
        //private static extern bool SetClientCode(IntPtr hPort, int iClientCode);

        [DllImport(@"\DLL\ERDriver_LeoThlink.dll", EntryPoint = "ER_SetParam")]
        private static extern int ER_SetParam(IntPtr hPort, ref int lBaseInfoBlockNo, ref int lConsumeBlockNo, ref int lPunchCardblockNo);


        /// <summary>
        /// 设置用户卡资料存储扇区号
        /// </summary>
        /// <param name="iSecNo"></param>
        /// <returns></returns>
        public bool ER_SetSectionNum(int iSecNo)
        {
            //if (iSecNo > 15 || iSecNo < 0)
            //{
            //    return false;
            //}
            //iSecNo = iSecNo * 4 + 2;
            //return SetClientCode(this._DevicePort, iSecNo);

            int lBaseInfoBlockNo = 1;
            int lConsumeBlockNo = 1;
            int lPunchCardblockNo = 0;

            ER_SetParam(this._DevicePort, ref lBaseInfoBlockNo, ref lConsumeBlockNo, ref lPunchCardblockNo);


            return true;
        }

        /// <summary>
        /// 读取扇区号
        /// </summary>
        /// <param name="hPort"></param>
        /// <returns></returns>
        [DllImport(@"\DLL\ERDriver_LeoThlink.dll", EntryPoint = "ER_ReadParam")]
        private static extern int ER_ReadParam(IntPtr hPort, ref int lBaseInfoBlockNo, ref int lConsumeBlockNo, ref int lPunchCardblockNo);

        //[DllImport(C_strDLLPath, EntryPoint = "ReadClientCode")]
        //private static extern bool ReadClientCode(IntPtr hPort, ref int iClientCode);
        /// <summary>
        /// 读取用户卡资料存储扇区号
        /// </summary>
        /// <param name="iSecNo"></param>
        /// <returns></returns>
        public int ER_GetClientCode()
        {
            //int iSecNo = -1;
            //bool res = ReadClientCode(this._DevicePort, ref iSecNo);
            //iSecNo = (iSecNo - 2) / 4;
            //return iSecNo;

            int lBaseInfoBlockNo = 0;
            int lConsumeBlockNo = 0;
            int lPunchCardblockNo = 0;

            ER_ReadParam(this._DevicePort, ref lBaseInfoBlockNo, ref lConsumeBlockNo, ref lPunchCardblockNo);

            return lConsumeBlockNo;
        }

        //[DllImport(@"\DLL\ERDriver_LeoThlink.dll", EntryPoint = "ER_ReadClientCode")]
        //private static extern int ER_ReadClientCode(IntPtr hPort);



        [DllImport(C_strDLLPath, EntryPoint = "SetSecurityCode")]
        private static extern bool SetSecurityCode(IntPtr hPort, char[] strOldPwd, char[] strNewPwd);
        /// <summary>
        /// 设置设备密码
        /// </summary>
        /// <param name="strOldPwd">旧密码</param>
        /// <param name="strNewPwd">新密码</param>
        /// <returns></returns>
        public bool ER_SetMacPwd(string strOldPwd, string strNewPwd)
        {
            char[] o = strOldPwd.ToCharArray();
            char[] n = strNewPwd.ToCharArray();

            return SetSecurityCode(this._DevicePort, strOldPwd.ToCharArray(), strNewPwd.ToCharArray());

            //int a = setStaticAuthor(this._DevicePort, 0, 6, strNewPwd.ToCharArray());

            // return a == 0 ? true:false;
        }

        [DllImport(C_strDLLPath, EntryPoint = "setStaticAuthor")]
        private static extern int setStaticAuthor(IntPtr hPort, int a, int b, char[] strNewPwd);


        [DllImport(C_strDLLPath, EntryPoint = "ReadICCard")]
        private static extern bool ReadICCard(IntPtr hPort, StringBuilder strCardNo, StringBuilder strCardName, ref int iMoney, ref int iTimes, ref int iVer);
        /// <summary>
        /// 读IC卡信息
        /// </summary>
        /// <param name="strCardNo">卡号</param>
        /// <param name="strName">姓名</param>
        /// <param name="iMoney">卡余额，单位为角</param>
        /// <param name="iTimes">充值次数</param>
        /// <param name="iVer">IC卡格式</param>
        /// <returns></returns>
        public bool ER_ReadCardInfo(ref string strCardNo, ref  string strName, ref int iMoney, ref int iChargeTimes, ref EnumCardFormat CardFormat)
        {
            StringBuilder sbCardNo = new StringBuilder();
            StringBuilder sbName = new StringBuilder();
            int iCardType = 0;
            bool res = ReadICCard(this._DevicePort, sbCardNo, sbName, ref iMoney, ref iChargeTimes, ref iCardType);
            strCardNo = sbCardNo.ToString();
            strName = sbName.ToString();
            CardFormat = GetCardVersion(iCardType);
            return res;
        }

        [DllImport(C_strDLLPath, EntryPoint = "ReadLastCard")]
        private static extern bool ReadLastCard(IntPtr hPort, StringBuilder strCardNo);
        /// <summary>
        /// 读取最新刷卡卡号
        /// </summary>
        /// <returns></returns>
        public string ER_GetLastReadCardNo()
        {
            string strCardNum = string.Empty;
            StringBuilder sbCardNum = new StringBuilder();
            bool resRead = ReadLastCard(this._DevicePort, sbCardNum);
            strCardNum = sbCardNum.ToString();
            return strCardNum;
        }

        [DllImport(C_strDLLPath, EntryPoint = "WriteICCard")]
        private static extern bool WriteICCard(IntPtr hPort, StringBuilder strCardNo, StringBuilder strCardName, int iMoney, int iTimes, int iVer);
        /// <summary>
        /// 写IC卡信息
        /// </summary>
        /// <param name="strCardNo">卡号</param>
        /// <param name="strName">姓名</param>
        /// <param name="iMoney">卡余额，单位为角</param>
        /// <param name="iTimes">充值次数</param>
        /// <param name="CardVersion">IC卡格式</param>
        /// <returns></returns>
        public bool ER_WriteCardInfo(string strCardNo, string strName, int iMoney, int iChargeTimes, EnumCardFormat CardFormat)
        {
            StringBuilder sbCardNo = new StringBuilder(strCardNo);
            StringBuilder sbName = new StringBuilder(strName);
            bool res = WriteICCard(this._DevicePort, sbCardNo, sbName, iMoney, iChargeTimes, (int)CardFormat);
            return res;
        }

        private EnumCardFormat GetCardVersion(int iCardVer)
        {
            EnumCardFormat CardVersion = EnumCardFormat.CARDVER_UNKNOWN;
            switch (iCardVer)
            {
                case (0): { CardVersion = EnumCardFormat.CARDVER_UNKNOWN; break; }
                case (1): { CardVersion = EnumCardFormat.CARDVER_IDCARD; break; }
                case (830): { CardVersion = EnumCardFormat.CARDVER_STDCARD; break; }
                case (880): { CardVersion = EnumCardFormat.CARDVER_NEWCARD; break; }
                case (690): { CardVersion = EnumCardFormat.CARDVER_690CARD; break; }
                default: { CardVersion = EnumCardFormat.CARDVER_UNKNOWN; break; }
            }
            return CardVersion;
        }

        #endregion

        #region 主动上传数据相关

        [DllImport(C_strDLLPath, EntryPoint = "StartUpLoad")]
        private static extern bool StartUpLoad(int iMonitorPort);
        /// <summary>
        /// 开始监听上传数据
        /// </summary>
        /// <returns></returns>
        public bool ER_StartMonitor(int iMonitorPort)
        {
            return StartUpLoad(iMonitorPort);
        }

        [DllImport(C_strDLLPath, EntryPoint = "StopUpLoad")]
        private static extern bool StopUpLoad();
        /// <summary>
        ///停止监听
        /// </summary>
        /// <returns></returns>
        public bool ER_StopMonitor()
        {
            return StopUpLoad();
        }

        /// <summary>
        /// 读取设备主动上传相关信息
        /// </summary>
        /// <param name="hPort">句柄</param>
        /// <param name="arrRemoteIP">远程服务器IP地址</param>
        /// <param name="iRemotePort">监听的端口</param>
        /// <param name="iRemoteType">主动上传类型：0-不主动上传，3-启动主动上传</param>
        /// <param name="iLanType">连接通讯方式，0-UDP，1-TCP</param>
        /// <param name="iWirelessType">无线通讯方式，0-UDP，1-TCP</param>
        /// <param name="arrRemoteParam">保留参数</param>
        /// <param name="iRemoteParamLen">保留参数长度</param>
        /// <returns></returns>
        [DllImport(C_strDLLPath, EntryPoint = "ReadRemoteIPEx")]
        private static extern int ReadRemoteIPEx(IntPtr hPort, ref char[] arrRemoteIP, ref int iRemotePort, ref int iRemoteType, ref int iLanType, ref int iWirelessType, ref char[] arrRemoteParam, ref int iRemoteParamLen);
        [DllImport(C_strDLLPath, EntryPoint = "ReadRemoteIPEx")]
        private static extern int ReadRemoteIPEx(IntPtr hPort, char[] arrRemoteIP, ref int iRemotePort, ref int iRemoteType, ref int iLanType, ref int iWirelessType, char[] arrRemoteParam, ref int iRemoteParamLen);
        /// <summary>
        /// 读取设备主动上传相关信息
        /// </summary>
        /// <param name="arrRemoteIP">远程服务器IP地址</param>
        /// <param name="iRemotePort">监听的端口</param>
        /// <param name="iRemoteType">主动上传类型：0-不主动上传，3-启动主动上传</param>
        /// <param name="iLanType">连接通讯方式，0-UDP，1-TCP</param>
        /// <param name="iWirelessType">无线通讯方式，0-UDP，1-TCP</param>
        /// <param name="arrRemoteParam">保留参数</param>
        /// <param name="iRemoteParamLen">保留参数长度</param>
        /// <returns></returns>
        public int ER_GetRemoteInfo(ref char[] arrRemoteIP, ref int iRemotePort, ref int iRemoteType, ref int iLanType, ref int iWirelessType, ref char[] arrRemoteParam, ref int iRemoteParamLen)
        {
            //char[] arrIp = new char[0];
            //int iPort = 0;
            //int iType = 0;
            //int iLType = 0;
            //int iWType = 0;
            //char[] arrPara = new char[0];
            //int iLen = 0;

            return ReadRemoteIPEx(this._DevicePort, ref arrRemoteIP, ref iRemotePort, ref iRemoteType, ref iLanType, ref iWirelessType, ref arrRemoteParam, ref iRemoteParamLen);
            //return ReadRemoteIPEx(this._DevicePort, arrRemoteIP, ref iRemotePort, ref iRemoteType, ref iLanType, ref iWirelessType, arrRemoteParam, ref iRemoteParamLen);
        }

        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.StdCall)]
        private delegate void OnDeviceLoginDelegae(int iMacID, string strSN, string strIP, int iPort, ref int iHeartbeat);
        private static OnDeviceLoginDelegae onDeviceLogin;

        #endregion

        #region 通讯结构体

        [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public struct TimepriceSpan
        {
            /// <summary>
            /// 工作模式
            /// </summary>
            public int clockmodule;
            /// <summary>
            /// 时段定值消费金额
            /// </summary>
            public int price;
            /// <summary>
            /// 时段限次
            /// </summary>
            public int times;

            [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst = 2)]
            public string begintime;

            [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst = 3)]
            public string endtime;
        }

        /// <summary>
        /// 消费记录结构
        /// </summary>
        [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public struct T690ReadData
        {
            /// <summary>
            /// 此记录校验是否正确, 由用户处理,如果记录校验错误且需继续读返回一条记录则需重置为False
            /// </summary>
            [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
            public bool Verify_Error;

            /// <summary>
            /// 卡号(20 个字节,以0 结束字符串)
            /// </summary>
            [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst = 20)]
            public string CardNo;

            /// <summary>
            /// 时间(20 个字节,以0 结束字符串)
            /// </summary>
            [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst = 20)]
            public string TimeString;

            /// <summary>
            /// 打卡标识
            /// </summary>
            public int flag;

            /// <summary>
            /// 消费金额(690D、690C1.0 单位角，690C2.0 单位分)
            /// </summary>
            public int Consume;

            /// <summary>
            /// 余额(690D、690C1.0 单位角，690C2.0 单位分)
            /// </summary>
            public int Balance;

            /// <summary>
            /// 充值次数
            /// </summary>
            public int Times;

            /// <summary>
            /// 采集数据的总记录数
            /// </summary>
            public int Record_Total;

            /// <summary>
            /// 当前记录是第几条记录
            /// </summary>
            public int Record_Index;

            #region 690C2.0 扩展成员

            /// <summary>
            /// 消费记录版本号
            /// </summary>
            public int Clock_ver;

            /// <summary>
            /// 机号
            /// </summary>
            public int Clock_ID;

            /// <summary>
            /// POS 交易流水号
            /// </summary>
            public int POS_Sequ;

            /// <summary>
            /// 卡交易流水号
            /// </summary>
            public int Card_Sequ;

            /// <summary>
            /// 操作员卡号
            /// </summary>
            [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst = 20)]
            public string Op_CardNo;

            /// <summary>
            /// 补贴版本号，格式yymmddhh
            /// </summary>
            [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst = 20)]
            public string Date_ver;

            /// <summary>
            /// 超额消费密码
            /// </summary>
            [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst = 10)]
            public string OverPwd;

            /// <summary>
            /// 保留
            /// </summary>
            public uint reserved1;

            /// <summary>
            /// 保留
            /// </summary>
            public uint reserved2;

            /// <summary>
            /// 保留
            /// </summary>
            [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst = 20)]
            public string reserved3;

            /// <summary>
            /// 保留
            /// </summary>
            [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst = 100)]
            public string reserved4;

            #endregion

            #region 订餐扩展

            /// <summary>
            /// 订餐月
            /// </summary>
            public int OrderMonth;
            /// <summary>
            /// 订餐日
            /// </summary>
            public int OrderDay;
            /// <summary>
            /// 订餐表
            /// </summary>
            [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst = 100)]
            public string OrderDinings;
            public int Dins;

            #endregion

            #region 消费机新增

            /// <summary>
            /// 交易前金额
            /// </summary>
            public int transcount;
            /// <summary>
            /// 交易状态
            /// </summary>
            public int retransta;

            #endregion
        }

        /// <summary>
        /// 名单类型结构体
        /// </summary>
        [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public struct PNameList
        {
            /// <summary>
            /// 名单类型，1-考勤白名单、0-黑名单、2-门禁白名单、12-补贴名单、17-已删除白名单、16-已删除黑名单、18-已删除门禁名单
            /// </summary>
            public int listtype;

            /// <summary>
            /// 卡号
            /// </summary>
            [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst = 19)]
            public string cardno;

            /// <summary>
            /// 工号
            /// </summary>
            [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst = 15)]
            public string emp_no;

            /// <summary>
            /// 员工姓名
            /// </summary>
            [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst = 15)]
            public string emp_name;

            /// <summary>
            /// 设备ID
            /// </summary>
            public int devid;

            /// <summary>
            /// 名单时间段
            /// </summary>
            public int week;

            /// <summary>
            /// 名单时间段
            /// </summary>
            [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst = 5, ArraySubType = System.Runtime.InteropServices.UnmanagedType.I4)]
            public int[] TimePass;

            /// <summary>
            /// 自定义信息 1
            /// </summary>
            [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst = 31)]
            public string Custominfo1;

            /// <summary>
            /// 自定义信息 2
            /// </summary>
            [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst = 31)]
            public string custominfo2;

            /// <summary>
            /// 自定义信息 3
            /// </summary>
            [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst = 31)]
            public string custominfo3;

            /// <summary>
            /// 自定义信息 4
            /// </summary>
            [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst = 31)]
            public string custominfo4;

            #region 门禁机新增

            /// <summary>
            /// 个人密码
            /// </summary>
            [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst = 3)]
            public string password;

            /// <summary>
            /// 名单权限
            /// </summary>
            public int Right;

            #endregion

            #region 消费机

            /// <summary>
            /// 补贴金额
            /// </summary>
            public int allowance;

            /// <summary>
            /// 补贴次数
            /// </summary>
            public int allowance_time;

            /// <summary>
            /// 补贴类型
            /// </summary>
            public int allowancetype;

            /// <summary>
            /// 黑名单次数
            /// </summary>
            public int backnametimes;

            /// <summary>
            /// 补贴开始时间
            /// </summary>
            [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst = 7)]
            public string allowancestart;

            /// <summary>
            /// 补贴结束时间
            /// </summary>
            [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst = 7)]
            public string allowanceend;

            /// <summary>
            /// 保留字段
            /// </summary>
            [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst = 99)]
            public string keepfields;

            #endregion
        }

        /// <summary>
        /// 名单类型
        /// </summary>
        public enum ER_ListType
        {
            /// <summary>
            /// 黑名单
            /// </summary>
            Blacklist = 0,
            /// <summary>
            /// 考勤白名单
            /// </summary>
            AttendanceWhiteList = 1,
            /// <summary>
            /// 门禁白名单
            /// </summary>
            EntranceGuardWhiteList = 2,
            /// <summary>
            /// 补贴名单
            /// </summary>
            SubsidyList = 12,
            /// <summary>
            /// 已删除黑名单
            /// </summary>
            DeletedBalcklist = 16,
            /// <summary>
            /// 已删除白名单
            /// </summary>
            DeletedWhiteList = 17,
            /// <summary>
            /// 已删除门禁名单
            /// </summary>
            DeletedEntranceGuardWhiteList = 18
        }

        #endregion


        #region 聯機消費


        [DllImport(@"\DLL\TradeOnline.dll", EntryPoint = "LaunchOnline")]
        private static extern bool LaunchOnline(POnlineClock[] onlineClock, int APort, RequestDelegate TRequestCallBack, CallBackDelegate Callback, CallBackDelegate Callback1);

        [DllImport(@"\DLL\TradeOnline.dll", EntryPoint = "StopOnline")]
        private static extern bool StopOnline();


        /// <summary>
        /// 设备信息结构体
        /// </summary>
        public struct POnlineClock
        {
            public int Clock_id;                         // 机号

            [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst = 15)]
            public string IPAddr;                  // 设备网络IP
            public int Port;                         // 设备网络端口
            public bool Connected;
            public int kModel;

            [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst = 20)]
            public string LastHeartTime;
        }

        /// <summary>
        /// 请求信息结构体
        /// </summary>
        public struct PRequestdata
        {
            [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst = 15)]
            public string ClientIP;                  // 设备网络IP
            public int ClockId;                         // 设备网络端口
            [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst = 15)]
            public string CardId;
            [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst = 15)]
            public string RealCardId;
            public int CardType;
            public int SubUseFlag;
            public int WalletFlag;
            public int ContrType;
            public int Consume;
            public int RequestTime;
            public bool Checked;
            public int OnlineId;

        }

        /// <summary>
        /// 响应请求结构体
        /// </summary>
        public struct PRespondData
        {
            public uint IdentifyID;
            public int ErrorCode;
            [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst = 200)]
            public string Error;
            [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst = 20)]
            public string RealCardId;
            public int Balance;
        }

        /// <summary>
        /// 收到交易请求的回调函数
        /// </summary>
        //[DllImport("ERDriver.dll", EntryPoint = " TRequestCallBack")]
        private void TRequestCallBack(PRequestdata request, PRespondData respond, ref bool Accept)
        {
            Accept = true;
        }

        /// <summary>
        /// 收到交易请求的回调函数
        /// </summary>
        /// <param name="request"></param>
        /// <param name="respond"></param>
        /// <param name="Accept"></param>
        private void TDoneCallBack(PRequestdata request, ref bool bSuc, ref bool Accept)
        {
            bSuc = true;
            Accept = true;
        }

        private RequestDelegate Delegate1;
        private CallBackDelegate Delegate2;

        public void t()
        {
            try
            {
                POnlineClock c = new POnlineClock();


                Delegate1 = TRequestCallBack;
                Delegate2 = TDoneCallBack;

                //int a = SetRemoteIPEx(this._DevicePort, "192.168.1.132".ToCharArray(), 5302, 3, 1, 1, null, 0);
                //int b = 1;

                bool con = ER_ConnNet("192.168.20.200".ToCharArray(), 4001, 1);

                POnlineClock[] a = new POnlineClock[1];

                POnlineClock poc = new POnlineClock();
                poc.Clock_id = 1;
                poc.IPAddr = "192.168.20.200";
                poc.Port = 4001;
                poc.Connected = true;
                // poc.Connected = true;

                //        public int Clock_id;                         // 机号
                //public char[] IPAddr;                  // 设备网络IP
                //public int Port;                         // 设备网络端口
                //public bool Connected;
                //public int kModel;
                //public DateTime LastHeartTime;

                a[0] = poc;
                bool istrue = LaunchOnline(a, 8002, Delegate1, Delegate2, null);
                //  bool stop = StopOnline();

                int b = 0;
            }
            catch
            {

            }

        }

        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.StdCall)]
        public delegate void RequestDelegate(PaymentEquipment.DLL.EastRiverDevice_base.PRequestdata request, PaymentEquipment.DLL.EastRiverDevice_base.PRespondData respond, ref bool Accept);
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.StdCall)]
        public delegate void CallBackDelegate(PaymentEquipment.DLL.EastRiverDevice_base.PRequestdata request, ref bool bSuc, ref bool Accept);

        #endregion
    }
}
