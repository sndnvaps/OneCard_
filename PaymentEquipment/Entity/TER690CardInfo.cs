using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PaymentEquipment.Entity
{
    /// <summary>
    /// 依时利卡片信息
    /// </summary>
    public struct TER690CardInfo
    {
        public Int32 CardNo;//卡号
        public char[] CardName;//姓名
        public Int32 CardBalance;//卡余额(单位分)
        public Int32 ChargeTimes;//充值次数
        public Int32 OverPwd;//超额密码
        public Int32 DayMoney;//日累计
        public byte Period;//消费时段
        public Int32 PeriodCount;//时段次数
        public Int32 MonthDay;//消费月日
        public Int32 OrderGroup;//订餐分组（0-15组）
        public byte OrderMonth;//订餐月
        public byte OrderDay;//订餐日
        public byte OrderListType;//订餐表类型
        public byte CycleMealFlag;//重复消费标志
        public byte[] OrderList;//订餐表
        public byte ReservedFlag;//保留，补贴批次
        public byte Privillege; //权限
        public Int32 EnterpriseID;//企业ID，按BCD格式存储

    }
}
