using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PaymentEquipment.IDevice;
using PaymentEquipment.DLL;
using Model.General;
using PaymentEquipment.Entity;

namespace PaymentEquipment.DeviceImplement
{
    public class EastRiverReader : AbstractReader
    {
        private EastRiverWriter_906 _Reader;

        public EastRiverReader()
        {
            this._Reader = new EastRiverWriter_906();
        }

        public override ReturnValueInfo Conn()
        {
            ReturnValueInfo rvInfo = new ReturnValueInfo();
            try
            {
                rvInfo.boolValue = this._Reader.ER_OpenReader();
            }
            catch (Exception ex)
            {
                rvInfo.isError = true;
                rvInfo.messageText = ex.Message;
            }
            return rvInfo;
        }

        public override Model.General.ReturnValueInfo DisConn()
        {
            ReturnValueInfo rvInfo = new ReturnValueInfo();
            try
            {
                rvInfo.boolValue = this._Reader.ER_CloseReader();
            }
            catch (Exception ex)
            {
                rvInfo.isError = true;
                rvInfo.messageText = ex.Message;
            }
            return rvInfo;
        }

        public override ConsumeCardInfo ReadCardInfo(short iCardSection, string strSectionPwd)
        {
            try
            {
                DisConn();
                Conn();
                ConsumeCardInfo cardInfo = this._Reader.ER_ReadCardInfo(iCardSection, strSectionPwd);
                if (cardInfo != null)
                {
                    cardInfo.CardSourceID = this._Reader.ER_ReadBlockData(0, 0, PaymentEquipment.Enum.EnumPwdType.A, string.Empty.PadRight(12, 'F'));
                }
                return cardInfo;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public override ReturnValueInfo WriteCardInfo(short iCardSection, string strSectionPwd, ConsumeCardInfo cardInfo)
        {
            ReturnValueInfo rvInfo = new ReturnValueInfo();
            try
            {
                rvInfo.boolValue = this._Reader.ER_WriteCardInfo(iCardSection, strSectionPwd, cardInfo);
            }
            catch (Exception ex)
            {
                rvInfo.messageText = ex.Message;
                rvInfo.isError = true;
            }
            return rvInfo;
        }

        public override ReturnValueInfo Recharge(short iCardSection, string strSectionPwd, decimal dMoney)
        {
            ReturnValueInfo rvInfo = new ReturnValueInfo();
            try
            {
                rvInfo.boolValue = this._Reader.ER_Recharge(iCardSection, strSectionPwd, dMoney);
            }
            catch (Exception ex)
            {
                rvInfo.messageText = ex.Message;
                rvInfo.isError = true;
            }
            return rvInfo;
        }

        public override string ReadCardOriginalID()
        {
            string strCardID = null;
            try
            {
                DisConn();
                Conn();
                ConsumeCardInfo cardInfo = ReadCardInfo(0, string.Empty.PadLeft(12, 'F'));
                if (cardInfo != null)
                {
                    strCardID = cardInfo.CardSourceID;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return strCardID;
        }

        public override ReturnValueInfo ModifySectionPwd(int iSectionNum, string strOldPwd, string strNewPwd)
        {
            ReturnValueInfo rvInfo = new ReturnValueInfo();
            try
            {
                rvInfo.boolValue = this._Reader.ER_WriteCardSectionPwd(iSectionNum, strOldPwd, strNewPwd);
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
