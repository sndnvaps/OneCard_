using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.HHZX.UserCard;
using Model.HHZX.ComsumeAccount;

namespace Model.HHZX.UserInfomation.CardUserInfo
{
    public class CardUserMaster_cus_Info : Model.IModel.IModelObject
    {

        public CardUserMaster_cus_Info()
        {
            this.RecordID = 0;

            this.cus_cRecordID = Guid.Empty;

            this.cus_cChaName = string.Empty;

            this.cus_cSexNum = string.Empty;

            this.cus_cIdentityNum = string.Empty;

            this.cus_cContractPhone = string.Empty;

            this.cus_cContractName = string.Empty;

            this.cus_cComeYear = string.Empty;

            this.cus_cGraduationPeriod = string.Empty;

            this.cus_cClassID = Guid.Empty;

            this.cus_lValid = true;

            this.cus_lIsGraduate = false;

            this.cus_cRemark = string.Empty;

            this.cus_cAdd = string.Empty;

            this.cus_cLast = string.Empty;

            this.ClassName = string.Empty;

            this.IsSaved = false;

            this.PairInfo = null;

            this.SexName = string.Empty;

            this.CheckString = string.Empty;

            this.DepartmentName = string.Empty;
        }

        public int RecordID
        {
            get;
            set;
        }

        /// <summary>
        /// 唯一ID
        /// </summary>
        public Guid cus_cRecordID { get; set; }

        /// <summary>
        /// 中文名
        /// </summary>
        public string cus_cChaName { get; set; }

        /// <summary>
        /// 学号
        /// </summary>
        public string cus_cStudentID { get; set; }

        /// <summary>
        /// 性别编码
        /// </summary>
        public string cus_cSexNum { get; set; }

        /// <summary>
        /// 性别描述
        /// </summary>
        public string SexName { get; set; }

        /// <summary>
        /// 部门名称
        /// </summary>
        public string DepartmentName { get; set; }

        /// <summary>
        /// 入学时间
        /// </summary>
        public string cus_cComeYear { get; set; }

        /// <summary>
        /// 届别
        /// </summary>
        public string cus_cGraduationPeriod { get; set; }

        /// <summary>
        /// 身份编码
        /// </summary>
        public string cus_cIdentityNum { get; set; }

        /// <summary>
        /// 班级编号
        /// </summary>
        public Guid cus_cClassID { get; set; }

        /// <summary>
        /// 班级名称
        /// </summary>
        public string ClassName { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        public string cus_cContractPhone { get; set; }

        /// <summary>
        /// 联系人
        /// </summary>
        public string cus_cContractName { get; set; }

        /// <summary>
        /// 是否有效
        /// </summary>
        public bool cus_lValid { get; set; }

        /// <summary>
        /// 是否已毕业
        /// </summary>
        public bool cus_lIsGraduate { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string cus_cRemark { get; set; }

        /// <summary>
        /// 添加人
        /// </summary>
        public string cus_cAdd { get; set; }

        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime cus_dAddDate { get; set; }

        /// <summary>
        /// 最后修改人
        /// </summary>
        public string cus_cLast { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        public DateTime cus_dLastDate { get; set; }

        /// <summary>
        /// 用户银行账号
        /// </summary>
        public string cus_cBankAccount { get; set; }

        /// <summary>
        /// 是否已经保存
        /// </summary>
        public bool IsSaved { get; set; }

        /// <summary>
        /// 验证数据是否合法，布尔类型
        /// </summary>
        public bool CheckBool { get; set; }

        /// <summary>
        /// 验证数据是否合法，反馈信息
        /// </summary>
        public string CheckString { get; set; }

        /// <summary>
        /// 是否已毕业
        /// </summary>
        public string IsGraduate { get; set; }

        /// <summary>
        /// 持有卡的卡标签ID
        /// </summary>
        public string PairCardID { get; set; }
        /// <summary>
        /// 持有卡的卡号
        /// </summary>
        public int? PairCardNo { get; set; }
        /// <summary>
        /// 持有卡的发卡时间
        /// </summary>
        public DateTime? PairCardTime { get; set; }

        /// <summary>
        /// 账户ID
        /// </summary>
        public Guid? AccountID { get; set; }

        /// <summary>
        /// 持有的卡信息
        /// </summary>
        public UserCardPair_ucp_Info PairInfo { get; set; }

        /// <summary>
        /// 用户所在班级信息
        /// </summary>
        public ClassMaster_csm_Info ClassInfo { get; set; }

        /// <summary>
        /// 用户所在部门信息
        /// </summary>
        public DepartmentMaster_dpm_Info DeptInfo { get; set; }

        /// <summary>
        /// 用户账户信息
        /// </summary>
        public CardUserAccount_cua_Info AccountInfo { get; set; }
    }
}
