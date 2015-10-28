using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.IModel;

namespace Model.HHZX.ConsumerDevice
{
    /// <summary>
    /// 消费机主档信息
    /// </summary>
    public class ConsumeMachineMaster_cmm_Info : IModelObject
    {
        #region IModelObject Members

        public int RecordID
        {
            get;
            set;
        }

        #endregion

        public Guid cmm_cRecordID { get; set; }
        /// <summary>
        /// 消费机号
        /// </summary>
        public int cmm_iMacNo { get; set; }
        /// <summary>
        /// 消费机名称
        /// </summary>
        public string cmm_cMacName { get; set; }
        /// <summary>
        /// 消费机IP地址
        /// </summary>
        public string cmm_cIPAddr { get; set; }
        /// <summary>
        /// 消费机通讯端口号
        /// </summary>
        public int cmm_iPort { get; set; }
        /// <summary>
        /// 用途类型
        /// </summary>
        public string cmm_cUsageType { get; set; }
        /// <summary>
        /// 消费机状态
        /// </summary>
        public string cmm_cStatus { get; set; }
        /// <summary>
        /// 最后被访问时间
        /// </summary>
        public DateTime cmm_dLastAccessTime { get; set; }
        /// <summary>
        /// 最后访问时是否收数成功
        /// </summary>
        public bool cmm_lLastAccessRes { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string cmm_cDesc { get; set; }
        /// <summary>
        /// 是否有效
        /// </summary>
        public bool cmm_lIsActive { get; set; }

        public string cmm_cAdd { get; set; }
        public DateTime cmm_dAddDate { get; set; }
        public string cmm_cLast { get; set; }
        public DateTime cmm_dLastDate { get; set; }
    }
}
