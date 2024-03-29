﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL.IBLL.HHZX.MealBooking;
using DAL.IDAL.HHZX.MealBooking;
using DAL.Factory.HHZX;
using Model.General;
using Model.HHZX.MealBooking;
using Common;

namespace BLL.DAL.HHZX.MealBooking
{
    public class BlacklistChangeRecordBL : IBlacklistChangeRecordBL
    {
        private IBlacklistChangeRecordDA _IBlacklistChangeRecordDA;

        public BlacklistChangeRecordBL()
        {
            this._IBlacklistChangeRecordDA = MasterDAFactory.GetDAL<IBlacklistChangeRecordDA>(MasterDAFactory.BlacklistChangeRecord);
        }

        #region IBaseBL<BlacklistChangeRecord_blc_Info> Members

        public Model.General.ReturnValueInfo Save(Model.IModel.IModelObject itemEntity, Common.DefineConstantValue.EditStateEnum EditMode)
        {
            ReturnValueInfo rvInfo = new ReturnValueInfo();
            try
            {
                BlacklistChangeRecord_blc_Info recordInfo = itemEntity as BlacklistChangeRecord_blc_Info;
                if (recordInfo == null)
                {
                    rvInfo.isError = true;
                    rvInfo.messageText = Common.DefineConstantValue.SystemMessageText.strMessageText_E_ObjectNull;
                    return rvInfo;
                }
                switch (EditMode)
                {
                    case Common.DefineConstantValue.EditStateEnum.OE_Insert:
                        return this._IBlacklistChangeRecordDA.InsertRecord(recordInfo);
                        break;
                    case Common.DefineConstantValue.EditStateEnum.OE_Update:
                        return this._IBlacklistChangeRecordDA.UpdateRecord(recordInfo);
                        break;
                    case Common.DefineConstantValue.EditStateEnum.OE_Delete:
                        return this._IBlacklistChangeRecordDA.DeleteRecord(recordInfo);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                rvInfo.messageText = ex.Message;
                rvInfo.isError = true;
            }
            return rvInfo;
        }

        public Model.HHZX.MealBooking.BlacklistChangeRecord_blc_Info DisplayRecord(Model.IModel.IModelObject KeyObject)
        {
            try
            {
                return this._IBlacklistChangeRecordDA.DisplayRecord(KeyObject);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Model.HHZX.MealBooking.BlacklistChangeRecord_blc_Info> SearchRecords(Model.IModel.IModelObject searchCondition)
        {
            try
            {
                return this._IBlacklistChangeRecordDA.SearchRecords(searchCondition);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Model.HHZX.MealBooking.BlacklistChangeRecord_blc_Info> AllRecords()
        {
            try
            {
                return this._IBlacklistChangeRecordDA.AllRecords();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion

        /// <summary>
        /// 批量更新黑名单记录状态
        /// </summary>
        /// <param name="listRecords"></param>
        /// <returns></returns>
        public ReturnValueInfo UpdateBatchRecord(List<BlacklistChangeRecord_blc_Info> listRecords)
        {
            ReturnValueInfo rvInfo = new ReturnValueInfo();
            try
            {
                rvInfo = this._IBlacklistChangeRecordDA.UpdateBatchRecord(listRecords);
            }
            catch (Exception ex)
            {
                rvInfo.isError = true;
                rvInfo.messageText = ex.Message;
            }
            return rvInfo;
        }

        /// <summary>
        /// 插入需要上传消费机的卡号
        /// </summary>
        /// <param name="iCardNo">卡号</param>
        /// <param name="enmOpt">上传操作</param>
        /// <param name="enmReason">上传原因</param>
        public ReturnValueInfo InsertUploadCardNo(int iCardNo, Common.DefineConstantValue.EnumCardUploadListOpt enmOpt, Common.DefineConstantValue.EnumCardUploadListReason enmReason, string strUserID)
        {
            BlacklistChangeRecord_blc_Info blistInsert = new BlacklistChangeRecord_blc_Info();
            blistInsert.blc_cRecordID = Guid.NewGuid();
            blistInsert.blc_cOperation = enmOpt.ToString();
            blistInsert.blc_cOptReason = enmReason.ToString();
            blistInsert.blc_iCardNo = iCardNo;
            blistInsert.blc_cAdd = strUserID;
            blistInsert.blc_dAddDate = DateTime.Now;
            ReturnValueInfo rvInfo = Save(blistInsert, DefineConstantValue.EditStateEnum.OE_Insert);
            return rvInfo;
        }
    }
}
