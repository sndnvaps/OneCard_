using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL.IBLL.HHZX.UserInfomation.SysUserInfo;
using DAL.IDAL.HHZX.UserInformation.SysUserInfo;
using DAL.Factory.HHZX;
using Model.SysMaster;

namespace BLL.DAL.HHZX.UserInfomation.SysUserInfo
{
    public class UserMasterBL : IUserMasterBL
    {
        private IUserMasterDA _iumDA;

        public UserMasterBL()
        {
            _iumDA = MasterDAFactory.GetDAL<IUserMasterDA>(MasterDAFactory.UserMaster);
        }

        #region IUserMasterBL 成员

        public List<Sys_UserMaster_usm_Info> SearchRecords(Sys_UserMaster_usm_Info infoObj)
        {
            return _iumDA.SearchRecords(infoObj);
        }

        public bool SaveRecord(Sys_UserMaster_usm_Info infoObj)
        {
            return _iumDA.SaveRecord(infoObj);
        }

        public bool UpdateRecord(Sys_UserMaster_usm_Info infoObj)
        {
            return _iumDA.UpdateRecord(infoObj);
        }

        public bool DeleteRecord(int id)
        {
            return _iumDA.DeleteRecord(id);
        }

        #endregion
    }
}
