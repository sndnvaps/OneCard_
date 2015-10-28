using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL.IBLL.HHZX;
using DAL.IDAL.HHZX;
using DAL.Factory.HHZX;
using DAL.IDAL.HHZX.UserInformation.CardUserInfo;
using BLL.IBLL.HHZX.UserInfomation.CardUserInfo;
using Model.HHZX.UserInfomation.CardUserInfo;
using Model.General;
using Model.IModel;

namespace BLL.DAL.HHZX.UserInfomation.CardUserInfo
{
    public class DepartmentMasterBL : IDepartmentMasterBL
    {
        IDepartmentMasterDA _iDMDL;

        public DepartmentMasterBL()
        {
            _iDMDL = MasterDAFactory.GetDAL<IDepartmentMasterDA>(MasterDAFactory.DepartmentMaster);
        }

        #region IBaseBL<DepartmentMaster_dpm_Info> Members

        public ReturnValueInfo Save(IModelObject itemEntity, Common.DefineConstantValue.EditStateEnum EditMode)
        {
            ReturnValueInfo rvInfo = new ReturnValueInfo();
            try
            {
                switch (EditMode)
                {
                    case Common.DefineConstantValue.EditStateEnum.OE_Insert:
                        rvInfo = this._iDMDL.InsertRecord(itemEntity as DepartmentMaster_dpm_Info);
                        break;
                    case Common.DefineConstantValue.EditStateEnum.OE_Update:
                        rvInfo = this._iDMDL.UpdateRecord(itemEntity as DepartmentMaster_dpm_Info);
                        break;
                    case Common.DefineConstantValue.EditStateEnum.OE_Delete:
                        rvInfo = this._iDMDL.DeleteRecord(itemEntity);
                        break;
                    case Common.DefineConstantValue.EditStateEnum.OE_ReaOnly:
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

        public DepartmentMaster_dpm_Info DisplayRecord(Model.IModel.IModelObject KeyObject)
        {
            try
            {
                return this._iDMDL.DisplayRecord(KeyObject);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<DepartmentMaster_dpm_Info> SearchRecords(Model.IModel.IModelObject searchCondition)
        {
            try
            {
                return this._iDMDL.SearchRecords(searchCondition);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<DepartmentMaster_dpm_Info> AllRecords()
        {
            try
            {
                return this._iDMDL.AllRecords();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion
    }
}
