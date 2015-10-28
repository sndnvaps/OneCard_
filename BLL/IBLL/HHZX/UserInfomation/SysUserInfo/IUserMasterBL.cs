using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.SysMaster;

namespace BLL.IBLL.HHZX.UserInfomation.SysUserInfo
{
    public interface IUserMasterBL
    {
        /// <summary>
        /// 查找用戶數據
        /// </summary>
        /// <param name="infoObj"></param>
        /// <returns></returns>
        List<Sys_UserMaster_usm_Info> SearchRecords(Sys_UserMaster_usm_Info infoObj);

        /// <summary>
        /// 保存用戶數據
        /// </summary>
        /// <param name="infoObj"></param>
        /// <returns></returns>
        bool SaveRecord(Sys_UserMaster_usm_Info infoObj);

        /// <summary>
        /// 更新用戶數據
        /// </summary>
        /// <param name="infoObj"></param>
        /// <returns></returns>
        bool UpdateRecord(Sys_UserMaster_usm_Info infoObj);

        /// <summary>
        /// 刪除用戶數據
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool DeleteRecord(int id);
    }
}
