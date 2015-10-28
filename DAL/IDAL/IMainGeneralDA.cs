using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.IModel;
using Model.General;

namespace DAL.IDAL
{
    public interface IMainGeneralDA<T>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="infoObject"></param>
        /// <returns></returns>
        ReturnValueInfo InsertRecord(T infoObject);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="infoObject"></param>
        /// <returns></returns>
        ReturnValueInfo UpdateRecord(T infoObject);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="recordID"></param>
        /// <returns></returns>
        ReturnValueInfo DeleteRecord(IModelObject KeyObject);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="recordID"></param>
        /// <returns></returns>
        T DisplayRecord(IModelObject KeyObject);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="MDobject"></param>
        /// <returns></returns>
        List<T> SearchRecords(IModelObject searchCondition);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<T> AllRecords();
    }
}
