using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.SysMaster;
using Model.General;

namespace BLL.IBLL.SysMaster
{
    public interface IUserPurviewBL : IDataBaseCommandBL<Sys_UserPurview_usp_Info>, IExtraBL, IMainBL
    {

        List<Sys_UserPurview_usp_Info> GetFormPurview(Sys_UserPurview_usp_Info query);

        ReturnValueInfo SavePruview(List<Sys_UserPurview_usp_Info> userAndRoleInfo, int formID);

        List<Sys_UserAndRoleGeneral_Info> SearchUserAndRole(Sys_UserAndRoleGeneral_Info query);

        ReturnValueInfo SavePruview(List<Sys_UserPurview_usp_Info> userAndRoleInfo, string objID, Sys_UserAndRoleGeneral_Info.accountType typeID);

        List<Sys_UserPurview_usp_Info> GetUserOrRolePurview(Sys_UserPurview_usp_Info query);
    }
}
