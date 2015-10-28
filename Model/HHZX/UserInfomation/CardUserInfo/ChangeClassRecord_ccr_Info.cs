using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.HHZX.UserInfomation.CardUserInfo
{
    public class ChangeClassRecord_ccr_Info
    {
        public ChangeClassRecord_ccr_Info()
        {
            this.ccr_iID = 0;

            this.ccr_cCardUserMasterID = Guid.Empty;

            this.ccr_cClassID = Guid.Empty;

            this.ccr_cMasterID = Guid.Empty;

            this.ccr_cStudentID = string.Empty;

            this.ccr_cCName = string.Empty;

            this.ccr_cClassName = string.Empty;

            this.ccr_cOldClassName = string.Empty;

            this.VaildString = string.Empty;

        }

        /// <summary>
        /// 自增ID
        /// </summary>
        public int ccr_iID { get; set; }

        /// <summary>
        /// 学生ID
        /// </summary>
        public Guid ccr_cCardUserMasterID { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string ccr_cCName { get; set; }

        /// <summary>
        /// 班级ID
        /// </summary>
        public Guid ccr_cClassID { get; set; }

        /// <summary>
        /// 班级描述
        /// </summary>
        public string ccr_cClassName { get; set; }

        /// <summary>
        /// 旧班级描述
        /// </summary>
        public string ccr_cOldClassName { get; set; }

        /// <summary>
        /// 班主任ID
        /// </summary>
        public Guid ccr_cMasterID { get; set; }

        /// <summary>
        /// 旧学号
        /// </summary>
        public string ccr_cOldStudentID { get; set; }

        /// <summary>
        /// 学生学号
        /// </summary>
        public string ccr_cStudentID { get; set; }

        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime ccr_dAddDate { get; set; }

        /// <summary>
        /// 验证数据是否合法，布尔类型
        /// </summary>
        public bool ValidBool { get; set; }
        /// <summary>
        /// 验证数据是否合法 
        /// </summary>
        public string VaildString { get; set; }
    }
}
