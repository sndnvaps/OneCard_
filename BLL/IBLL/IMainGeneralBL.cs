using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.IModel;

namespace BLL.IBLL
{
   public interface IMainGeneralBL:IMainBL
    {


        /// <summary>
        /// 
        /// </summary>
        /// <param name="MDobject"></param>
        /// <returns></returns>
        List<IModelObject> AllRecords();
    }
}
