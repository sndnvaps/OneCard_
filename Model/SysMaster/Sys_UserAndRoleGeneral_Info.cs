using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.SysMaster
{
    public class Sys_UserAndRoleGeneral_Info
    {

        public Sys_UserAndRoleGeneral_Info()
        {
            this.recordID = 0;

            this.stringID = string.Empty;

            this.remark = string.Empty;

            this.searchKey = string.Empty;

            this.accountTypeName = string.Empty;
        }

        public enum accountType
        {
            userID = 0,
            roleID = 1
        }

        public int recordID { get; set; }

        public string stringID { get; set; }

        public string remark { get; set; }

        public accountType accountCType { get; set; }

        public string accountTypeName { get; set; }

        public string searchKey { get; set; }
    }
}
