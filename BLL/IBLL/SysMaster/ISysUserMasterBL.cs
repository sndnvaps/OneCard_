﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.SysMaster;
using Model.General;

namespace BLL.IBLL.SysMaster
{
    public interface ISysUserMasterBL : IDataBaseCommandBL<Sys_UserMaster_usm_Info>, IExtraBL, IMainBL
    {
    }
}
