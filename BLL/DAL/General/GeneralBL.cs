using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL.IBLL.General;
using DAL.IDAL.General;
using DAL.Factory.General;
using Model.General;
using Model.IModel;

namespace BLL.DAL.General
{
    class GeneralBL : IGeneralBL
    {
        IGeneralDA _iGeneralDA;

        public GeneralBL()
        {
            this._iGeneralDA = GeneralDAFactory.GetDAL<IGeneralDA>(GeneralDAFactory.General);
        }


        public List<Model.IModel.IModelObject> GetMasterDataInformations(Common.DefineConstantValue.MasterType masterType)
        {
            List<ComboboxDataInfo> sourceInfos = null;
            List<IModelObject> resultInfos = null;

            sourceInfos = this._iGeneralDA.GetMasterDataInformations(masterType);

            if (sourceInfos != null || sourceInfos.Count > 0)
            {
                resultInfos = new List<IModelObject>();

                foreach (ComboboxDataInfo info in sourceInfos)
                {
                    resultInfos.Add(info);
                }
            }

            return resultInfos;
        }

        public List<IModelObject> GetMasterDataInformations(Common.DefineConstantValue.MasterType masterType, object keyInfo)
        {
            List<ComboboxDataInfo> sourceInfos = null;
            List<IModelObject> resultInfos = null;

            sourceInfos = this._iGeneralDA.GetMasterDataInformations(masterType, keyInfo);

            if (sourceInfos != null || sourceInfos.Count > 0)
            {
                resultInfos = new List<IModelObject>();

                foreach (ComboboxDataInfo info in sourceInfos)
                {
                    resultInfos.Add(info);
                }
            }

            return resultInfos;
        }     
    }
}
