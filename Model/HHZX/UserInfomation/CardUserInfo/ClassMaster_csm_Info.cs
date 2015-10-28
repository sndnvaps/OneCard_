using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.HHZX.UserInfomation.CardUserInfo
{
    public class ClassMaster_csm_Info : Model.IModel.IModelObject
    {

        public ClassMaster_csm_Info()
        {
            this.RecordID = 0;

            this.csm_cRecordID = Guid.Empty;

            this.csm_cClassName = string.Empty;

            this.csm_cGDMID = Guid.Empty;

            this.csm_cMasterID = Guid.Empty;

            this.csm_cRemark = string.Empty;

            this.csm_cAdd = string.Empty;

            this.csm_cLast = string.Empty;

            this.lSave = false;
        }

        public int RecordID
        {
            get;
            set;
        }

        /// <summary>
        /// 记录ID
        /// </summary>
        public Guid csm_cRecordID { get; set; }

        /// <summary>
        /// 班级名称
        /// </summary>
        public string csm_cClassName { get; set; }

        /// <summary>
        /// 年级ID
        /// </summary>
        public Guid csm_cGDMID { get; set; }

        /// <summary>
        /// 班级ID
        /// </summary>
        public string csm_cClassNum { get; set; }

        /// <summary>
        /// 班主任ID
        /// </summary>
        public Guid csm_cMasterID { get; set; }

        /// <summary>
        /// 班主任
        /// </summary>
        public string csm_cMasterName { get; set; }

        /// <summary>
        /// 备注 
        /// </summary>
        public string csm_cRemark { get; set; }

        /// <summary>
        /// 新增人
        /// </summary>
        public string csm_cAdd { get; set; }

        /// <summary>
        /// 新增时间
        /// </summary>
        public DateTime? csm_dAddDate { get; set; }

        /// <summary>
        /// 最后修改人
        /// </summary>
        public string csm_cLast { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        public DateTime? csm_dLastDate { get; set; }

        /// <summary>
        /// 是否保存
        /// </summary>
        public bool lSave { get; set; }

        /// <summary>
        /// 年级信息
        /// </summary>
        public GradeMaster_gdm_Info GradeInfo { get; set; }
    }
}
