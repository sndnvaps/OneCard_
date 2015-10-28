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
    public class GradeMasterBL : IGradeMasterBL
    {
        IGradeMasterDA _gradeMasterDA;

        public GradeMasterBL()
        {
            this._gradeMasterDA = MasterDAFactory.GetDAL<IGradeMasterDA>(MasterDAFactory.GradeMaster);
        }

        #region IMainGeneralBL Members

        public List<GradeMaster_gdm_Info> AllRecords()
        {
            try
            {
                List<GradeMaster_gdm_Info> allRecords = this._gradeMasterDA.AllRecords();
                if (allRecords != null)
                {
                    allRecords = allRecords.OrderBy(x => x.gdm_cAbbreviation).ToList();
                }
                return allRecords;
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }

        public GradeMaster_gdm_Info DisplayRecord(IModelObject itemEntity)
        {
            try
            {
                return this._gradeMasterDA.DisplayRecord(itemEntity);
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }

        public List<GradeMaster_gdm_Info> SearchRecords(IModelObject itemEntity)
        {
            try
            {
                List<GradeMaster_gdm_Info> searchList = this._gradeMasterDA.SearchRecords(itemEntity);
                if (searchList != null)
                {
                    searchList = searchList.OrderBy(x => x.gdm_cAbbreviation).ToList();
                }
                return searchList;
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }

        public ReturnValueInfo Save(IModelObject itemEntity, Common.DefineConstantValue.EditStateEnum EditMode)
        {
            ReturnValueInfo returnInfo = new ReturnValueInfo(false);

            GradeMaster_gdm_Info objInfo = itemEntity as GradeMaster_gdm_Info;

            try
            {
                switch (EditMode)
                {
                    case Common.DefineConstantValue.EditStateEnum.OE_Insert:

                        objInfo.gdm_dAddDate = DateTime.Now;

                        objInfo.gdm_cLastDate = DateTime.Now;

                        returnInfo = this._gradeMasterDA.InsertRecord(objInfo);

                        break;

                    case Common.DefineConstantValue.EditStateEnum.OE_Update:

                        objInfo.gdm_cLastDate = DateTime.Now;

                        returnInfo = this._gradeMasterDA.UpdateRecord(objInfo);

                        break;

                    case Common.DefineConstantValue.EditStateEnum.OE_Delete:

                        returnInfo = this._gradeMasterDA.DeleteRecord(objInfo);

                        break;

                    default:
                        break;
                }
            }
            catch (Exception Ex)
            {

                throw Ex;
            }

            return returnInfo;
        }

        #endregion
    }
}
