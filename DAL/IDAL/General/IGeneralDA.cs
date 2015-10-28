using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;
using Model.General;

namespace DAL.IDAL.General
{
    public interface IGeneralDA
    {
        List<ComboboxDataInfo> GetMasterDataInformations(DefineConstantValue.MasterType masterType);
        List<ComboboxDataInfo> GetMasterDataInformations(DefineConstantValue.MasterType masterType, object keyInfo);  
    }
}
