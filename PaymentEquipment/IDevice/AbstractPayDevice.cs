using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PaymentEquipment.Entity;
using PaymentEquipment.Enum;
using Model.General;
using System.Net;
using Model.HHZX.ComsumeAccount;

namespace PaymentEquipment.IDevice
{
    /// <summary>
    /// 消费机抽象类
    /// </summary>
    public abstract class AbstractPayDevice
    {
        #region 属性

        /// <summary>
        /// 串口
        /// </summary>
        public virtual int ComPort { set; get; }

        /// <summary>
        /// 波特率
        /// </summary>
        public virtual int BaudRate { set; get; }

        /// <summary>
        /// IP地址
        /// </summary>
        public virtual IPAddress IP { set; get; }

        /// <summary>
        /// 机号
        /// </summary>
        public virtual int MacNo { set; get; }

        #endregion

        protected AbstractPayDevice() { }

        /// <summary>
        /// 连接消费机
        /// </summary>
        /// <param name="arrIPAddr">IP地址</param>
        /// <param name="iPort">工作端口</param>
        ///  <param name="iMacID">机号</param>
        /// <returns></returns>
        public abstract ReturnValueInfo Conn(IPAddress IPAddr, int iPort, int iMacID);

        /// <summary>
        /// 断开连接
        /// </summary>
        /// <returns></returns>
        public abstract ReturnValueInfo DisConn();

        /// <summary>
        /// 设置管理卡号
        /// </summary>
        /// <param name="strManageCardNo">管理卡卡号</param>
        /// <returns></returns>
        public abstract ReturnValueInfo SetManagementCard(string strManageCardNo);

        /// <summary>
        /// 获得管理卡号
        /// </summary>
        /// <returns></returns>
        public abstract string GetManagementCard();

        /// <summary>
        /// 设置机号
        /// </summary>
        /// <param name="iDeviceNewNo">新机号</param>
        /// <returns></returns>
        public abstract ReturnValueInfo SetDeviceNo(int iDeviceNewNo);

        /// <summary>
        /// 同步机器时间
        /// </summary>
        /// <returns></returns>
        public abstract ReturnValueInfo SyncDeviceTime();

        /// <summary>
        /// 获得机器时间
        /// </summary>
        /// <returns></returns>
        public abstract DateTime? GetDeviceTime();

        /// <summary>
        /// 设置消费机工作模式
        /// </summary>
        /// <param name="Mode">工作模式</param>
        /// <returns></returns>
        public abstract ReturnValueInfo SetDeviceMode(EnumDeviceMode Mode);

        /// <summary>
        /// 读取消费机工作模式
        /// </summary>
        /// <returns></returns>
        public abstract EnumDeviceMode ReadDeviceMode();

        /// <summary>
        /// 添加黑名单
        /// </summary>
        /// <param name="strCardNo">卡号</param>
        /// <returns></returns>
        public abstract ReturnValueInfo AddBlacklist(string strCardNo);

        /// <summary>
        /// 添加白名单
        /// </summary>
        /// <param name="strCardNo">卡号</param>
        /// <returns></returns>
        public abstract ReturnValueInfo AddWhitelist(string strCardNo);

        /// <summary>
        /// 移除黑名单
        /// </summary>
        /// <param name="strCardNo">卡号</param>
        /// <returns></returns>
        public abstract ReturnValueInfo RemoveBlacklist(string strCardNo);

        /// <summary>
        /// 移除白名单
        /// </summary>
        /// <param name="strCardNo">卡号</param>
        /// <returns></returns>
        public abstract ReturnValueInfo RemoveWhitelist(string strCardNo);

        /// <summary>
        /// 移除所有黑名单
        /// </summary>
        /// <returns></returns>
        public abstract ReturnValueInfo RemoveAllBlacklist();

        /// <summary>
        /// 移除所有白名单
        /// </summary>
        /// <returns></returns>
        public abstract ReturnValueInfo RemoveAllWhitelist();

        /// <summary>
        /// 设置机器设备密码
        /// </summary>
        /// <param name="strOldPwd">旧密码</param>
        /// <param name="strNewPwd">新密码</param>
        /// <returns></returns>
        public abstract ReturnValueInfo SetDevicePwd(string strOldPwd, string strNewPwd);

        /// <summary>
        /// 获取设备所有消费记录
        /// </summary>
        /// <returns></returns>
        public abstract List<PosRecord> GetAllConsumptionRecords();

        /// <summary>
        /// 获取设备已经加工过的数据
        /// </summary>
        /// <returns></returns>
        public abstract List<ConsumeRecord_csr_Info> GetAllProfileRecords();

        /// <summary>
        /// 清除设备所有消费数据
        /// </summary>
        /// <param name="p_intDeviceNo"></param>
        /// <returns></returns>
        public abstract ReturnValueInfo RemoveAllConsumptionRecords();

        /// <summary>
        /// 设置同卡重复刷卡时间间隔
        /// </summary>
        /// <param name="iInterval">时间间隔，单位：分钟，范围：1~99分钟</param>
        /// <returns></returns>
        public abstract ReturnValueInfo SetReadCardInterval(int iInterval);

        /// <summary>
        /// 获取同卡重复刷卡时间间隔
        /// </summary>
        /// <returns></returns>
        public abstract int GetReadCardInterval();

        /// <summary>
        /// 获取每日消费限额值
        /// </summary>
        /// <returns></returns>
        public abstract decimal GetDayConsumeLimit();

        /// <summary>
        /// 设置每日消费限额值
        /// </summary>
        /// <returns></returns>
        public abstract ReturnValueInfo SetDayConsumeLimit(decimal dLimit);

        /// <summary>
        /// 获取每次消费限额值
        /// </summary>
        /// <returns></returns>
        public abstract decimal GetPerConsumeLimit();

        /// <summary>
        /// 设置每次消费限额值
        /// </summary>
        /// <returns></returns>
        public abstract ReturnValueInfo SetPerConsumeLimit(decimal dLimit);

        /// <summary>
        /// 设置消费时段
        /// </summary>
        /// <param name="listSpan"></param>
        /// <returns></returns>
        public abstract ReturnValueInfo SetMacTimeSpan(List<ConsumeTimeSpan> listSpan);

        /// <summary>
        /// 消费时段
        /// </summary>
        /// <param name="setcurmodel"></param>
        /// <param name="setcurallow"></param>
        /// <returns></returns>
        public abstract ReturnValueInfo SetConsumetimeParam(int setcurmodel, int setcurallow);

        /// <summary>
        /// 获取消费时段
        /// </summary>
        /// <returns></returns>
        public abstract List<ConsumeTimeSpan> GetMacTimeSpan();

        /// <summary>
        /// 获取设备IP地址
        /// </summary>
        /// <returns></returns>
        public abstract IPAddress GetMachineIP();

        /// <summary>
        /// 获取线区号
        /// </summary>
        /// <returns></returns>
        public abstract int GetClientCode();

        public abstract bool SetClientCode();
    }
}
