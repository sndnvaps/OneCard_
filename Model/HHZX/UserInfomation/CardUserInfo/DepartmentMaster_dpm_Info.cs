using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.IModel;

namespace Model.HHZX.UserInfomation.CardUserInfo
{
    public class DepartmentMaster_dpm_Info : IModelObject
    {
        public Guid dpm_RecordID
        {
            get;
            set;
        }

        public string dpm_cName
        {
            get;
            set;
        }

        public string dpm_cRemark
        {
            get;
            set;
        }

        public string dpm_cAdd
        {
            get;
            set;
        }

        public DateTime dpm_dAddDate
        {
            get;
            set;
        }

        public string dpm_cLast
        {
            get;
            set;
        }

        public DateTime dpm_dLastDate
        {
            get;
            set;
        }

        public bool dpm_lEnable
        {
            get;
            set;
        }

        #region IModelObject Members

        public int RecordID
        {
            get;
            set;
        }

        #endregion
    }
}
