using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PaymentEquipment.Entity;
using Model.General;

namespace PaymentEquipment.IDevice
{
    public abstract class AbstractReader
    {
        protected AbstractReader()
        { }

        /// <summary>
        /// 连接设备
        /// </summary>
        /// <returns></returns>
        public abstract ReturnValueInfo Conn();

        /// <summary>
        /// 关闭设备
        /// </summary>
        /// <returns></returns>
        public abstract ReturnValueInfo DisConn();

        /// <summary>
        /// 获取卡原始ID
        /// </summary>
        /// <returns></returns>
        public abstract string ReadCardOriginalID();

        /// <summary>
        /// 读取卡信息
        /// </summary>
        /// <param name="iCardSection">卡资料所在扇区号</param>
        /// <param name="strSectionPwd">卡扇区密码</param>
        /// <returns></returns>
        public abstract ConsumeCardInfo ReadCardInfo(short iCardSection, string strSectionPwd);

        /// <summary>
        /// 写入卡信息
        /// </summary>
        /// <param name="iCardSection">卡资料所在扇区号</param>
        /// <param name="strSectionPwd">卡扇区密码</param>
        /// <param name="cardInfo">卡信息</param>
        /// <returns></returns>
        public abstract ReturnValueInfo WriteCardInfo(short iCardSection, string strSectionPwd, ConsumeCardInfo cardInfo);

        /// <summary>
        /// 充值
        /// </summary>
        /// <param name="iCardSection">卡资料所在扇区号</param>
        /// <param name="strSectionPwd">卡扇区密码</param>
        /// <param name="dMoney">充值金额</param>
        /// <returns></returns>
        public abstract ReturnValueInfo Recharge(short iCardSection, string strSectionPwd, decimal dMoney);

        /// <summary>
        /// 修改卡密
        /// </summary>
        /// <param name="iSectionNum">扇区号</param>
        /// <param name="strOldPwd">旧密码</param>
        /// <param name="strNewPwd">新密码</param>
        /// <returns></returns>
        public abstract ReturnValueInfo ModifySectionPwd(int iSectionNum, string strOldPwd, string strNewPwd);
    }
}

