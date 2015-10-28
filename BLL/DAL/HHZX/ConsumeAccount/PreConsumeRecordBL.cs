using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL.IBLL.HHZX.ConsumeAccount;
using Model.IModel;
using Model.General;
using Model.HHZX.ComsumeAccount;
using DAL.IDAL.HHZX.ConsumeAccount;
using DAL.Factory.HHZX;
using DAL.IDAL.SysMaster;
using sysFac = DAL.Factory.SysMaster;
using Model.SysMaster;

namespace BLL.DAL.HHZX.ConsumeAccount
{
    /// <summary>
    /// 预消费记录
    /// </summary>
    class PreConsumeRecordBL : IPreConsumeRecordBL
    {
        IPreConsumeRecordDA _IPreConsumeRecordDA;

        public PreConsumeRecordBL()
        {
            this._IPreConsumeRecordDA = MasterDAFactory.GetDAL<IPreConsumeRecordDA>(MasterDAFactory.PreConsumeRecord);
        }

        public ReturnValueInfo Save(IModelObject itemEntity, Common.DefineConstantValue.EditStateEnum EditMode)
        {
            ReturnValueInfo rvInfo = new ReturnValueInfo();
            try
            {
                switch (EditMode)
                {
                    case Common.DefineConstantValue.EditStateEnum.OE_Insert:
                        rvInfo = this._IPreConsumeRecordDA.InsertRecord(itemEntity as PreConsumeRecord_pcs_Info);
                        break;
                    case Common.DefineConstantValue.EditStateEnum.OE_Update:
                        rvInfo = this._IPreConsumeRecordDA.UpdateRecord(itemEntity as PreConsumeRecord_pcs_Info);
                        break;
                    case Common.DefineConstantValue.EditStateEnum.OE_Delete:
                        rvInfo = this._IPreConsumeRecordDA.DeleteRecord(itemEntity);
                        break;
                    case Common.DefineConstantValue.EditStateEnum.OE_ReaOnly:
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                rvInfo.messageText += ex.Message;
                rvInfo.isError = true;
            }
            return rvInfo;
        }

        public PreConsumeRecord_pcs_Info DisplayRecord(IModelObject KeyObject)
        {
            try
            {
                PreConsumeRecord_pcs_Info record = this._IPreConsumeRecordDA.DisplayRecord(KeyObject);
                if (record != null)
                {
                    List<CodeMaster_cmt_Info> listFormula = getListFormula();
                    CostValueProfile(record, listFormula);
                    return record;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<PreConsumeRecord_pcs_Info> SearchRecords(IModelObject searchCondition)
        {
            try
            {
                List<PreConsumeRecord_pcs_Info> listRecord = this._IPreConsumeRecordDA.SearchRecords(searchCondition);
                List<CodeMaster_cmt_Info> listFormula = getListFormula();
                listRecord = CostValueProfile(listRecord, listFormula);
                return listRecord;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<PreConsumeRecord_pcs_Info> AllRecords()
        {
            try
            {
                List<PreConsumeRecord_pcs_Info> listRecord = this._IPreConsumeRecordDA.AllRecords();
                List<CodeMaster_cmt_Info> listFormula = getListFormula();
                listRecord = CostValueProfile(listRecord, listFormula);
                return listRecord;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public ReturnValueInfo BatchSolveUncertainRecord(List<PreConsumeRecord_pcs_Info> listRecords, bool isSettled)
        {
            ReturnValueInfo rvInfo = new ReturnValueInfo();
            try
            {
                rvInfo = this._IPreConsumeRecordDA.BatchSolveUncertainRecord(listRecords, isSettled);
            }
            catch (Exception ex)
            {
                rvInfo.isError = true;
                rvInfo.messageText = ex.Message;
            }
            return rvInfo;
        }

        /// <summary>
        /// 将数据库中原始值加工为实际金额
        /// </summary>
        /// <param name="listTarget">原始数据</param>
        /// <param name="listFormula">公式列表</param>
        /// <returns></returns>
        List<PreConsumeRecord_pcs_Info> CostValueProfile(List<PreConsumeRecord_pcs_Info> listTarget, List<CodeMaster_cmt_Info> listFormula)
        {
            List<PreConsumeRecord_pcs_Info> listRecord = new List<PreConsumeRecord_pcs_Info>();
            foreach (PreConsumeRecord_pcs_Info item in listTarget)
            {
                CodeMaster_cmt_Info formula = listFormula.Find(x => x.cmt_cKey2 == item.pcs_cConsumeType);
                if (formula != null)
                {
                    item.pcs_fCost *= formula.cmt_fNumber;
                }
                else
                {
                    item.pcs_fCost *= -1;
                }
                listRecord.Add(item);
            }
            return listRecord;
        }

        /// <summary>
        /// 将数据库中原始值加工为实际金额
        /// </summary>
        /// <param name="target">原始数据</param>
        /// <param name="listFormula">公式列表</param>
        /// <returns></returns>
        void CostValueProfile(PreConsumeRecord_pcs_Info target, List<CodeMaster_cmt_Info> listFormula)
        {
            CodeMaster_cmt_Info formula = listFormula.Find(x => x.cmt_cKey2 == target.pcs_cConsumeType);
            if (formula != null)
            {
                target.pcs_fCost *= formula.cmt_fNumber;
            }
            else
            {
                target.pcs_fCost *= -1;
            }
        }

        /// <summary>
        /// 获得公式列表
        /// </summary>
        /// <returns></returns>
        List<CodeMaster_cmt_Info> getListFormula()
        {
            ICodeMasterDA da = sysFac.MasterDAFactory.GetDAL<ICodeMasterDA>(sysFac.MasterDAFactory.CodeMaster_cmt);
            List<CodeMaster_cmt_Info> listFormula = da.SearchRecords(new CodeMaster_cmt_Info() { cmt_cKey1 = Common.DefineConstantValue.EnumFormulaKey.PRECOSTFORMULA.ToString() });
            return listFormula;
        }
    }
}
