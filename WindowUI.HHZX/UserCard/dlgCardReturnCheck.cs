using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Model.HHZX.UserInfomation.CardUserInfo;
using WindowUI.HHZX.ClassLibrary.Public;
using BLL.IBLL.HHZX.ConsumeAccount;
using BLL.Factory.HHZX;
using Model.HHZX.ComsumeAccount;
using BLL.IBLL.HHZX.UserCard;
using Model.HHZX.UserCard;
using Model.General;
using Common;
using BLL.IBLL.HHZX.MealBooking;
using Model.HHZX.MealBooking;

namespace WindowUI.HHZX.UserCard
{
    public partial class dlgCardReturnCheck : BaseForm
    {
        #region 自定义变量

        /// <summary>
        /// 传递用户初始信息
        /// </summary>
        List<CardUserMaster_cus_Info> _ListCheckedUsers;
        /// <summary>
        /// 用户账号信息
        /// </summary>
        ICardUserAccountBL _ICardUserAccountBL;
        /// <summary>
        /// 预付款消费明细信息
        /// </summary>
        IPreConsumeRecordBL _IPreConsumeRecordBL;
        /// <summary>
        /// 用户发卡信息
        /// </summary>
        IUserCardPairBL _IUserCardPairBL;
        /// <summary>
        /// 用户显示信息缓存
        /// </summary>
        List<UserCardInfo> _ListDisplayInfos;

        #endregion

        public dlgCardReturnCheck()
        {
            InitializeComponent();
        }

        public dlgCardReturnCheck(CardUserMaster_cus_Info CardUserInfo)
        {
            InitializeComponent();

            this._ListCheckedUsers = new List<CardUserMaster_cus_Info>();
            this._ListCheckedUsers.Add(CardUserInfo);
        }

        public dlgCardReturnCheck(List<CardUserMaster_cus_Info> listCardUserInfos)
        {
            InitializeComponent();

            this._ListCheckedUsers = listCardUserInfos;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.Cursor = Cursors.WaitCursor;
            try
            {
                this._ListDisplayInfos = new List<UserCardInfo>();
                this._ICardUserAccountBL = MasterBLLFactory.GetBLL<ICardUserAccountBL>(MasterBLLFactory.CardUserAccount);
                this._IPreConsumeRecordBL = MasterBLLFactory.GetBLL<IPreConsumeRecordBL>(MasterBLLFactory.PreConsumeRecord);
                this._IUserCardPairBL = MasterBLLFactory.GetBLL<IUserCardPairBL>(MasterBLLFactory.UserCardPair);

                List<UserCardInfo> listCheckInfo = checkReturnCardInfo(this._ListCheckedUsers);
                if (listCheckInfo != null)
                {
                    this._ListDisplayInfos.AddRange(listCheckInfo);
                }
                lvStudentList.SetDataSource(listCheckInfo);

                checkListViewRes();
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex);
            }

            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// 检查信息窗的结果，并作出相应的颜色提示处理
        /// </summary>
        void checkListViewRes()
        {
            if (lvStudentList.Items.Count > 0)
            {
                bool res = true;
                foreach (ListViewItem item in lvStudentList.Items)
                {
                    if (Convert.ToBoolean(item.SubItems[1].Text))
                    {
                        item.BackColor = Color.LightGreen;
                    }
                    else
                    {
                        item.BackColor = Color.Tomato;
                        res = res && false;
                    }
                }
                btnConfirm.Enabled = res;
            }
        }

        /// <summary>
        /// 检查每个用户是否合符资格可以退卡
        /// </summary>
        /// <param name="listCardUserInfos">用户信息</param>
        /// <returns></returns>
        List<UserCardInfo> checkReturnCardInfo(List<CardUserMaster_cus_Info> listCardUserInfos)
        {
            if (listCardUserInfos == null)
            {
                return null;
            }
            List<UserCardInfo> listCheckInfo = new List<UserCardInfo>();
            foreach (CardUserMaster_cus_Info userInfo in listCardUserInfos)
            {
                UserCardInfo checkInfo = new UserCardInfo(userInfo);

                bool res = true;

                //账户信息
                if (checkInfo.UserInfo.AccountInfo == null)
                {
                    checkInfo.UserInfo.AccountInfo = this._ICardUserAccountBL.SearchRecords(new CardUserAccount_cua_Info() { cua_cCUSID = userInfo.cus_cRecordID }).FirstOrDefault();
                }
                if (checkInfo.UserInfo.AccountInfo.cua_fCurrentBalance != decimal.Zero)
                {
                    res = res && false;
                    checkInfo.Ext_CheckResult = "不能退卡：账户余额不为零。";
                }

                //检查未缴款项
                List<PreConsumeRecord_pcs_Info> listPreCost = this._IPreConsumeRecordBL.SearchRecords(new PreConsumeRecord_pcs_Info()
                {
                    pcs_cAccountID = checkInfo.UserInfo.AccountInfo.cua_cRecordID,
                    pcs_cUserID = userInfo.cus_cRecordID
                });

                if (listPreCost != null && listPreCost.Count > 0)
                {
                    listPreCost = listPreCost.Where(x => x.pcs_lIsSettled == false).ToList();
                    if (listPreCost != null && listPreCost.Count > 0)
                    {
                        res = res && false;
                        checkInfo.Ext_CheckResult = "不能退卡：存在未结算的预收款记录。";
                    }
                }

                checkInfo.Ext_IsPassed = res;
                if (res)
                {
                    checkInfo.Ext_CheckResult = "可以退卡。";
                }
                listCheckInfo.Add(checkInfo);
            }
            return listCheckInfo;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (ShowQuestionMessage("是否确认要进行退卡操作？"))
            {
                try
                {
                    foreach (ListViewItem item in lvStudentList.Items)
                    {
                        bool chkRes = Convert.ToBoolean(item.SubItems[1].Text);
                        if (chkRes)
                        {
                            Guid gRecordID = new Guid(item.SubItems[0].Text);

                            UserCardInfo chkUserInfo = this._ListDisplayInfos.Find(x => x.Ext_RecordID == gRecordID);
                            UserCardPair_ucp_Info pairInfo = this._IUserCardPairBL.DisplayRecord(chkUserInfo.UserInfo.PairInfo);
                            pairInfo.ucp_dReturnTime = DateTime.Now;
                            pairInfo.ucp_dLastDate = pairInfo.ucp_dReturnTime.Value;
                            pairInfo.ucp_cLast = base.UserInformation.usm_cUserLoginID;
                            pairInfo.ucp_cUseStatus = Common.DefineConstantValue.ConsumeCardStatus.Returned.ToString();
                            ReturnValueInfo rvInfo = this._IUserCardPairBL.ReturnCard(pairInfo);
                            if (rvInfo.boolValue && !rvInfo.isError)
                            {
                                chkUserInfo.Ext_CheckResult = "退卡成功。";
                                chkUserInfo.Ext_IsPassed = true;
                                ReturnValueInfo rvAddBlist = AddOldCardBList(pairInfo.ucp_iCardNo, DefineConstantValue.EnumCardUploadListOpt.AddBlackList);
                            }
                            else
                            {
                                chkUserInfo.Ext_CheckResult = "退卡失败。" + rvInfo.messageText;
                                chkUserInfo.Ext_IsPassed = false;
                            }
                        }
                    }

                    lvStudentList.Items.Clear();
                    lvStudentList.SetDataSource(this._ListDisplayInfos);
                    checkListViewRes();
                    btnConfirm.Enabled = false;
                    base.ShowInformationMessage("操作结束。");
                }
                catch (Exception ex)
                {
                    ShowErrorMessage(ex);
                }
            }
        }

        ReturnValueInfo AddOldCardBList(int iCardNo, Common.DefineConstantValue.EnumCardUploadListOpt blistOpt)
        {
            IBlacklistChangeRecordBL blistBL = MasterBLLFactory.GetBLL<IBlacklistChangeRecordBL>(MasterBLLFactory.BlacklistChangeRecord);
            BlacklistChangeRecord_blc_Info blistInsert = new BlacklistChangeRecord_blc_Info();
            blistInsert.blc_cAdd = this.UserInformation.usm_cUserLoginID;
            blistInsert.blc_cOperation = blistOpt.ToString();
            blistInsert.blc_cOptReason = Common.DefineConstantValue.EnumCardUploadListReason.BlacklistOpt.ToString();
            blistInsert.blc_cRecordID = Guid.NewGuid();
            blistInsert.blc_dAddDate = DateTime.Now;
            blistInsert.blc_iCardNo = iCardNo;
            ReturnValueInfo rvInfo = blistBL.Save(blistInsert, DefineConstantValue.EditStateEnum.OE_Insert);
            return rvInfo;
        }

        /// <summary>
        /// ListView显示信息
        /// </summary>
        class UserCardInfo
        {
            public UserCardInfo(CardUserMaster_cus_Info user)
            {
                this.userInfo = user;
                Ext_RecordID = user.cus_cRecordID;
                Ext_UserNum = user.cus_cStudentID;
                Ext_UserName = user.cus_cChaName;
                Ext_CardNo = user.PairInfo.ucp_iCardNo.ToString();
                Ext_PairTime = user.PairInfo.ucp_dPairTime;
                Ext_GroupName = user.ClassInfo != null ? user.ClassInfo.csm_cClassName : user.DeptInfo.dpm_cName;
            }
            public Guid Ext_RecordID { get; set; }
            public string Ext_UserNum { get; set; }
            public string Ext_UserName { get; set; }

            /// 持有卡号
            /// </summary>
            public string Ext_CardNo { get; set; }
            /// <summary>
            /// 发卡时间
            /// </summary>
            public DateTime? Ext_PairTime { get; set; }
            /// <summary>
            /// 所属组织名称
            /// </summary>
            public string Ext_GroupName { get; set; }
            /// <summary>
            /// 检查\处理结果信息
            /// </summary>
            public string Ext_CheckResult { get; set; }
            /// <summary>
            /// 是否通过检测
            /// </summary>
            public bool Ext_IsPassed { get; set; }

            private CardUserMaster_cus_Info userInfo;
            public CardUserMaster_cus_Info UserInfo
            {
                get { return userInfo; }
            }
        }
    }
}
