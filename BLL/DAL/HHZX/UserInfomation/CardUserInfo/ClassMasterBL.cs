using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL.IBLL.HHZX.UserInfomation.CardUserInfo;
using Model.IModel;
using Model.General;
using DAL.IDAL.HHZX.UserInformation.CardUserInfo;
using DAL.Factory.HHZX;
using Model.HHZX.UserInfomation.CardUserInfo;

namespace BLL.DAL.HHZX.UserInfomation.CardUserInfo
{
    public class ClassMasterBL : IClassMasterBL
    {
        IClassMasterDA _classMasterDA;

        public ClassMasterBL()
        {
            this._classMasterDA = MasterDAFactory.GetDAL<IClassMasterDA>(MasterDAFactory.ClassMaster);
        }

        #region IMainGeneralBL Members

        public List<ClassMaster_csm_Info> AllRecords()
        {
            List<ClassMaster_csm_Info> returnList = new List<ClassMaster_csm_Info>();

            try
            {
                List<ClassMaster_csm_Info> allDatas = this._classMasterDA.AllRecords();
                if (allDatas != null)
                {
                    allDatas = allDatas.OrderBy(x => x.csm_cClassName).ToList();
                }
                return allDatas;
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }

        public ClassMaster_csm_Info DisplayRecord(IModelObject itemEntity)
        {
            try
            {
                return this._classMasterDA.DisplayRecord(itemEntity);
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }

        public List<ClassMaster_csm_Info> SearchRecords(IModelObject itemEntity)
        {
            List<ClassMaster_csm_Info> returnList = new List<ClassMaster_csm_Info>();

            try
            {
                List<ClassMaster_csm_Info> allDatas = this._classMasterDA.SearchRecords(itemEntity);
                if (allDatas != null)
                {
                    allDatas = allDatas.OrderBy(x => x.csm_cClassName).ToList();
                }
                return allDatas;
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }

        public ReturnValueInfo Save(IModelObject itemEntity, Common.DefineConstantValue.EditStateEnum EditMode)
        {
            ReturnValueInfo returnInfo = new ReturnValueInfo(false);

            ClassMaster_csm_Info objInfo = itemEntity as ClassMaster_csm_Info;

            switch (EditMode)
            {
                case Common.DefineConstantValue.EditStateEnum.OE_Insert:

                    objInfo.csm_dAddDate = DateTime.Now;

                    objInfo.csm_dLastDate = DateTime.Now;

                    returnInfo = this._classMasterDA.InsertRecord(objInfo);

                    break;

                case Common.DefineConstantValue.EditStateEnum.OE_Update:

                    objInfo.csm_dLastDate = DateTime.Now;

                    returnInfo = this._classMasterDA.UpdateRecord(objInfo);

                    break;

                case Common.DefineConstantValue.EditStateEnum.OE_Delete:

                    returnInfo = this._classMasterDA.DeleteRecord(objInfo);

                    break;

                default:
                    break;
            }

            return returnInfo;
        }

        #endregion
    }
}
