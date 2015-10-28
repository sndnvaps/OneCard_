using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using PaymentEquipment.Entity;
using System.Xml;
using PaymentEquipment.Enum;

namespace PaymentEquipment.DLL
{
    public class EastRiverWriter_906
    {
        private const string C_strDLLPath = @"\DLL\906\ERTrans.dll";
        private const string C_strSectionControl = "FF078069";

        [DllImport(C_strDLLPath, EntryPoint = "OpenReaderXML")]
        private static extern byte OpenReaderXML(string strConnXML);
        /// <summary>
        /// 打开读写器
        /// </summary>
        /// <returns></returns>
        public bool ER_OpenReader()
        {
            try
            {
                string strConnXML = string.Empty;
                strConnXML = @"<EastRiver><ERReader>" +
                                 "<CommStyle>3</CommStyle>" +//0 是串口，3是USB接口
                                 "<ClockModel>906</ClockModel>" +
                                 "<ComPort></ComPort>" +
                                 "<BaudRate></BaudRate>";

                if (OpenReaderXML(strConnXML) == 1)
                    return true;
                else
                    return false;
            }
            catch (Exception ex) { throw ex; }
        }


        [DllImport(C_strDLLPath, EntryPoint = "CloseReader")]
        private static extern bool CloseReader();
        /// <summary>
        /// 关闭读写器
        /// </summary>
        /// <returns></returns>
        public bool ER_CloseReader()
        {
            try
            {
                return CloseReader();
            }
            catch (Exception ex) { throw ex; }
        }

        [DllImport(C_strDLLPath, EntryPoint = "ReadER690CardXML")]
        public static extern bool ReadER690CardXML(short aSector, string PwdA, StringBuilder ReadCardXml);
        /// <summary>
        /// 读取卡片信息
        /// </summary>
        /// <param name="iSectionNo">资料扇区号</param>
        /// <param name="strCardBlockPwd">卡片扇区密码</param>
        /// <returns></returns>
        public ConsumeCardInfo ER_ReadCardInfo(short iSectionNo, string strCardBlockPwd)
        {
            ConsumeCardInfo cardInfo = null;
            try
            {
                StringBuilder sbReadXML = new StringBuilder(5120);
                bool res = ReadER690CardXML(iSectionNo, strCardBlockPwd, sbReadXML);

                if (res)
                {
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.LoadXml(sbReadXML.ToString());

                    cardInfo = new ConsumeCardInfo();
                    cardInfo.CardNo = xmlDoc.DocumentElement.GetElementsByTagName("CardNo")[0].InnerText;
                    cardInfo.CardBalance = Convert.ToDecimal(xmlDoc.DocumentElement.GetElementsByTagName("CardBalance")[0].InnerText) / 10;
                    cardInfo.Name = xmlDoc.DocumentElement.GetElementsByTagName("CardName")[0].InnerText;
                    cardInfo.ConsumeTimes = Convert.ToInt32(xmlDoc.DocumentElement.GetElementsByTagName("ChargeTimes")[0].InnerText);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return cardInfo;

        }

        [DllImport(C_strDLLPath, EntryPoint = "WriteER690CardXML")]
        private static extern bool WriteER690CardXML(string ReadCardXml);
        /// <summary>
        /// 写卡信息
        /// </summary>
        /// <param name="iSectionNo">资料扇区号</param>
        /// <param name="strCardBlockPwd">扇区密码</param>
        /// <param name="cardInfo">写入的卡资料</param>
        /// <returns></returns>
        public bool ER_WriteCardInfo(short iSectionNo, string strCardBlockPwd, ConsumeCardInfo cardInfo)
        {
            bool res = false;
            try
            {
                if (cardInfo != null)
                {
                    string strXML = string.Empty;
                    strXML = @"<EastRiver><V1CardInfo>" +
                                     "<AsectorNo>" + iSectionNo.ToString() + "</AsectorNo>" +
                                     "<PwdA>" + strCardBlockPwd + "</PwdA>" +
                                     "<CardNo>" + cardInfo.CardNo + "</CardNo>" +
                                     "<CardName>" + cardInfo.Name + "</CardName>" +
                                     "<CardBalance>" + ((int)(cardInfo.CardBalance * 10)).ToString() + "</CardBalance>" +
                                     "<ChargeTimes>" + cardInfo.ConsumeTimes.ToString() + "</ChargeTimes>";
                    res = WriteER690CardXML(strXML);
                    return res;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return res;
        }

        /// <summary>
        /// 写卡密
        /// </summary>
        /// <param name="aSectorNo">扇区号</param>
        /// <param name="pwdType">卡密类型，0-A，1-B，密钥</param>
        /// <param name="AccessPwd">旧密码</param>
        /// <param name="PwdA">新A密</param>
        /// <param name="PwdB">新B密</param>
        /// <param name="ControlCode">密钥控制字段</param>
        /// <returns></returns>
        [DllImport(C_strDLLPath, EntryPoint = "WriteSectorPwdEx")]
        private static extern int WriteSectorPwdEx(int aSectorNo, int pwdType, string AccessPwd, string PwdA, string PwdB, string ControlCode);
        /// <summary>
        /// 修改卡片扇区密码
        /// </summary>
        /// <param name="iSectionNum">扇区号</param>
        /// <param name="strOldPwd">旧卡密</param>
        /// <param name="strNewPwd">新卡密</param>
        /// <returns></returns>
        public bool ER_WriteCardSectionPwd(int iSectionNum, string strOldPwd, string strNewPwd)
        {
            bool res = false;
            try
            {
                int iRes = WriteSectorPwdEx(iSectionNum, 0, strOldPwd.ToUpper(), strNewPwd.ToUpper(), string.Empty.PadLeft(12, 'F'), C_strSectionControl);
                if (iRes == 0)
                {
                    res = true;
                }
                else
                {
                    res = false;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return res;
        }

        /// <summary>
        /// 卡充值
        /// </summary>
        /// <param name="iSectionNo">资料扇区号</param>
        /// <param name="strCardBlockPwd">扇区密码</param>
        /// <param name="dMoney">充值金额</param>
        /// <returns></returns>
        public bool ER_Recharge(short iSectionNo, string strCardBlockPwd, decimal dMoney)
        {
            bool res = false;
            try
            {
                ConsumeCardInfo cardOldInfo = ER_ReadCardInfo(iSectionNo, strCardBlockPwd);
                cardOldInfo.CardBalance = cardOldInfo.CardBalance + dMoney;
                cardOldInfo.ConsumeTimes++;
                res = ER_WriteCardInfo(iSectionNo, strCardBlockPwd, cardOldInfo);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return res;
        }

        /// <summary>
        /// 读写扇区的单个数据块资料
        /// </summary>
        /// <param name="aSectorNo">扇区号</param>
        /// <param name="aBlockNo">数据块号</param>
        /// <param name="pwdType">密钥类型</param>
        /// <param name="Pwd">扇区密码</param>
        /// <param name="BlockData">卡块数据</param>
        /// <returns></returns>
        [DllImport(C_strDLLPath, EntryPoint = "ReadBlockEx")]
        private static extern byte ReadBlockEx(int aSectorNo, int aBlockNo, int pwdType, string Pwd, StringBuilder BlockData);
        /// <summary>
        /// 读取数据块资料
        /// </summary>
        /// <param name="iSectionNum">扇区号</param>
        /// <param name="iBlockNum">数据块号</param>
        /// <param name="pwdType">密钥类型</param>
        /// <param name="strPwd">扇区密码</param>
        /// <returns></returns>
        public string ER_ReadBlockData(int iSectionNum, int iBlockNum, EnumPwdType pwdType, string strPwd)
        {
            string strBlockData = string.Empty;
            try
            {
                StringBuilder sbBlockData = new StringBuilder(5120);
                byte res = ReadBlockEx(iSectionNum, iBlockNum, (int)pwdType, strPwd, sbBlockData);
                if (res != 1)
                {
                    strBlockData = null;
                }
                else
                {
                    strBlockData = sbBlockData.ToString();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return strBlockData;
        }

        /// <summary>
        /// 寻卡
        /// </summary>
        /// <param name="iCardType">传出卡类型</param>
        /// <param name="cardSN">卡序列号缓冲指针</param>
        /// <param name="iBuffSize"></param>
        /// <returns></returns>
        [DllImport(C_strDLLPath, EntryPoint = "SeekCard")]
        private static extern bool SeekCard(ref byte iCardType, IntPtr cardSN, ref int iBuffSize);
        /// <summary>
        /// 寻卡（未完成，参数有问题）
        /// </summary>
        /// <returns></returns>
        public bool ER_SeekCard()
        {
            byte bType = 0;
            bool res = false;
            try
            {
                int iBuff = 20;
                res = SeekCard(ref bType, IntPtr.Zero, ref iBuff);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return res;
        }
    }
}
