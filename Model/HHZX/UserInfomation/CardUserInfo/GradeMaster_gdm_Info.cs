using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.HHZX.UserInfomation.CardUserInfo
{
    public class GradeMaster_gdm_Info : Model.IModel.IModelObject
    {

        public GradeMaster_gdm_Info()
        {
            this.RecordID = 0;

            this.gdm_cRecordID = Guid.Empty;

            this.gdm_cGradeName = string.Empty;

            this.gdm_cPraepostorID = Guid.Empty;

            this.gdm_cRemark = string.Empty;

            this.gdm_cAdd = string.Empty;

            this.gdm_cLast = string.Empty;

            this.lSave = false;

            this.gdm_cPraepostorName = string.Empty;

            this.gdm_cPraepostorPhone = string.Empty;
        }

        public int RecordID
        {
            get;
            set;
        }

        /// <summary>
        /// 记录ID
        /// </summary>
        public Guid gdm_cRecordID { get; set; }

        /// <summary>
        /// 年纪名称
        /// </summary>
        public string gdm_cGradeName { get; set; }

        /// <summary>
        /// 级长ID
        /// </summary>
        public Guid gdm_cPraepostorID { get; set; }

        /// <summary>
        /// 级长
        /// </summary>
        public string gdm_cPraepostorName { get; set; }

        /// <summary>
        /// 年级缩写
        /// </summary>
        public string gdm_cAbbreviation { get; set; }

        /// <summary>
        /// 级长电话
        /// </summary>
        public string gdm_cPraepostorPhone { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string gdm_cRemark { get; set; }

        /// <summary>
        /// 添加人
        /// </summary>
        public string gdm_cAdd { get; set; }

        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime? gdm_dAddDate { get; set; }

        /// <summary>
        /// 最后修改人
        /// </summary>
        public string gdm_cLast { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        public DateTime? gdm_cLastDate { get; set; }

        /// <summary>
        /// 是否要保存
        /// </summary>
        public bool lSave { get; set; }
    }
}
