using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL.IBLL.HHZX.ConsumeAccount;
using DAL.IDAL.HHZX.ConsumeAccount;
using DAL.Factory.HHZX;
using Model.IModel;
using Model.General;
using Common;
using Model.HHZX.ComsumeAccount;

namespace BLL.DAL.HHZX.ConsumeAccount
{
    /// <summary>
    /// 系统账户明细
    /// </summary>
    public class SystemAccountDetailBL : ISystemAccountDetailBL
    {
        private ISystemAccountDetailDA _ISystemAccountDetailDA;

        public SystemAccountDetailBL()
        {
            this._ISystemAccountDetailDA = MasterDAFactory.GetDAL<ISystemAccountDetailDA>(MasterDAFactory.SystemAccountDetail);
        }

        #region IMainGeneralBL Members

        public List<IModelObject> AllRecords()
        {
            List<IModelObject> listObj = null;
            try
            {
                List<SystemAccountDetail_sad_Info> listSysAccount = this._ISystemAccountDetailDA.AllRecords();
                if (listSysAccount != null)
                {
                    listObj = new List<IModelObject>();
                    foreach (SystemAccountDetail_sad_Info item in listSysAccount)
                    {
                        if (item != null)
                        {
                            listObj.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return listObj;
        }

        #endregion

        #region IMainBL Members

        public IModelObject DisplayRecord(IModelObject itemEntity)
        {
            SystemAccountDetail_sad_Info accountInfo = null;
            try
            {
                accountInfo = this._ISystemAccountDetailDA.DisplayRecord(itemEntity) as SystemAccountDetail_sad_Info;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return accountInfo;
        }

        public List<IModelObject> SearchRecords(IModelObject itemEntity)
        {
            List<IModelObject> listObj = null;
            try
            {
                List<SystemAccountDetail_sad_Info> listSysAccount = this._ISystemAccountDetailDA.SearchRecords(itemEntity);
                if (listSysAccount != null)
                {
                    listObj = new List<IModelObject>();
                    foreach (SystemAccountDetail_sad_Info item in listSysAccount)
                    {
                        if (item != null)
                        {
                            listObj.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return listObj;
        }

        public ReturnValueInfo Save(IModelObject itemEntity, DefineConstantValue.EditStateEnum EditMode)
        {
            ReturnValueInfo rvInfo = new ReturnValueInfo();
            SystemAccountDetail_sad_Info searchInfo = itemEntity as SystemAccountDetail_sad_Info;

            if (searchInfo == null)
            {
                rvInfo.isError = true;
                rvInfo.messageText = DefineConstantValue.SystemMessageText.strMessageText_E_ObjectNull;
                return rvInfo;
            }

            searchInfo.sad_dOptTime = DateTime.Now;
            try
            {
                switch (EditMode)
                {
                    case DefineConstantValue.EditStateEnum.OE_Insert:
                        {
                            rvInfo = this._ISystemAccountDetailDA.InsertRecord(searchInfo);
                            break;
                        }
                    case DefineConstantValue.EditStateEnum.OE_Update:
                        {
                            rvInfo = this._ISystemAccountDetailDA.UpdateRecord(searchInfo);
                            break;
                        }
                    case DefineConstantValue.EditStateEnum.OE_Delete:
                        {
                            SystemAccountDetail_sad_Info newRecord = this._ISystemAccountDetailDA.DisplayRecord(searchInfo);
                            if (newRecord != null)
                            {
                                newRecord.sad_cRecordID = Guid.NewGuid();
                                newRecord.sad_cOpt = searchInfo.sad_cOpt;
                                newRecord.sad_cFlowType = DefineConstantValue.ConsumeMoneyFlowType.HedgeFund.ToString();
                                newRecord.sad_dOptTime = searchInfo.sad_dOptTime;
                                newRecord.sad_cConsumeID = searchInfo.sad_cRecordID;
                                rvInfo = this._ISystemAccountDetailDA.InsertRecord(newRecord);
                            }
                            else
                            {
                                rvInfo.messageText = "原记录不存在，请检查数据。";
                                rvInfo.isError = true;
                                return rvInfo;
                            }

                            break;
                        }
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return rvInfo;
        }

        #endregion

        #region ISystemAccountDetailBL Members

        public Model.HHZX.Report.DepartmentBalance_dtb_Info DepartmentBalance(Model.HHZX.Report.DepartmentBalance_dtb_Info query)
        {
            try
            {
                return this._ISystemAccountDetailDA.DepartmentBalance(query);
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }

        #endregion

        public decimal GetHotIncome(DateTime dtQuery)
        {
            return this._ISystemAccountDetailDA.GetHotIncome(dtQuery);
        }

        public decimal GetOrtherIncome(DateTime dtQuery)
        {
            return this._ISystemAccountDetailDA.GetOrtherIncome(dtQuery);
        }

        public ReturnValueInfo SetHotIncome(DateTime dtQuery, decimal fIncome)
        {
            return this._ISystemAccountDetailDA.SetHotIncome(dtQuery, fIncome);
        }

        public ReturnValueInfo SetOrtherIncome(DateTime dtQuery, decimal fIncome)
        {
            return this._ISystemAccountDetailDA.SetOrtherIncome(dtQuery, fIncome);
        }
    }
}
