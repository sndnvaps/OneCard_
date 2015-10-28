using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL.IBLL.HHZX.ConsumeAccount;
using DAL.IDAL.HHZX.ConsumeAccount;
using DAL.Factory.HHZX;
using Model.HHZX.ComsumeAccount;
using Model.General;
using Model.IModel;

namespace BLL.DAL.HHZX.ConsumeAccount
{
    /// <summary>
    /// 原始消费记录
    /// </summary>
    public class SourceConsumeRecordBL : ISourceConsumeRecordBL
    {
        private ISourceConsumeRecordDA _ISourceConsumeRecordDA;

        public SourceConsumeRecordBL()
        {
            this._ISourceConsumeRecordDA = MasterDAFactory.GetDAL<ISourceConsumeRecordDA>(MasterDAFactory.SourceConsumeRecord);
        }

        #region ISourceConsumeRecordBL Members

        public ReturnValueInfo BatchInsertRecord(List<SourceConsumeRecord_scr_Info> listSrouce)
        {
            try
            {
                ReturnValueInfo rvInfo = new ReturnValueInfo();
                if (listSrouce == null)
                {
                    rvInfo.messageText = Common.DefineConstantValue.SystemMessageText.strMessageText_E_ObjectNull;
                    rvInfo.isError = true;
                    return rvInfo;
                }
                rvInfo = this._ISourceConsumeRecordDA.BatchInsertRecord(listSrouce);
                return rvInfo;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion

        #region IBaseBL<SourceConsumeRecord_scr_Info> Members

        public ReturnValueInfo Save(IModelObject itemEntity, Common.DefineConstantValue.EditStateEnum EditMode)
        {
            try
            {
                ReturnValueInfo rvInfo = new ReturnValueInfo();
                SourceConsumeRecord_scr_Info searchInfo = itemEntity as SourceConsumeRecord_scr_Info;
                if (searchInfo == null)
                {
                    rvInfo.messageText = Common.DefineConstantValue.SystemMessageText.strMessageText_E_ObjectNull;
                    rvInfo.isError = true;
                    return rvInfo;
                }

                switch (EditMode)
                {
                    case Common.DefineConstantValue.EditStateEnum.OE_Insert:
                        rvInfo = this._ISourceConsumeRecordDA.InsertRecord(searchInfo);
                        break;
                    case Common.DefineConstantValue.EditStateEnum.OE_Update:
                        rvInfo = this._ISourceConsumeRecordDA.InsertRecord(searchInfo);
                        break;
                    case Common.DefineConstantValue.EditStateEnum.OE_Delete:
                        rvInfo = this._ISourceConsumeRecordDA.DeleteRecord(searchInfo);
                        break;
                    default:
                        break;
                }

                return rvInfo;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public SourceConsumeRecord_scr_Info DisplayRecord(IModelObject KeyObject)
        {
            try
            {
                return this._ISourceConsumeRecordDA.DisplayRecord(KeyObject);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<SourceConsumeRecord_scr_Info> SearchRecords(IModelObject searchCondition)
        {
            try
            {
                return this._ISourceConsumeRecordDA.SearchRecords(searchCondition);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<SourceConsumeRecord_scr_Info> AllRecords()
        {
            try
            {
                return this._ISourceConsumeRecordDA.AllRecords();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion
    }
}
