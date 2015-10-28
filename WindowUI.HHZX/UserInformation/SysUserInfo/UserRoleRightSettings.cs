using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL.IBLL.SysMaster;
using BLL.Factory.SysMaster;
using Model.SysMaster;
using Model.IModel;
using Model.General;
using Common;
using WindowUI.HHZX;
using WindowUI.HHZX.ClassLibrary.Public;
using WindowUI.HHZX.SysMaster;

namespace WindowUI.HBManagerTerminal.SysMaster
{
    public partial class UserRoleRightSettings : BaseForm
    {
        #region 自定義變量

        bool _isEdited;

        bool _isAlert;

        Model.SysMaster.Sys_UserAndRoleGeneral_Info.accountType saveTypeID;

        List<Sys_UserAndRoleGeneral_Info> _seachUserAndRoleList;

        private int _selecedFormID;

        private EnumOptType _CurrentOptType;

        private DefineConstantValue.EditStateEnum _EditStatus;

        #region 用戶帳戶信息相關

        ISysUserMasterBL _ISysUserMasterBL;
        /// <summary>
        /// 當前用戶主檔記錄ID
        /// </summary>
        int _CurrentUserID;
        /// <summary>
        /// 緩存本地的用戶數據
        /// </summary>
        List<Sys_UserMaster_usm_Info> _ListUserMasterInfo;

        #endregion

        #region 角色信息相關

        ISysRoleMasterBL _ISysRoleMasterBL;
        /// <summary>
        /// 緩存本地的角色數據
        /// </summary>
        List<Sys_RoleMaster_rlm_Info> _ListRoleMasterInfo;
        /// <summary>
        /// 當前角色記錄ID
        /// </summary>
        int _CurrentRoleID;

        #endregion

        #region 權限信息相關

        IUserPurviewBL _IUserPurviewBL;

        ISysFormMasterBL _ISysFormMasterBL;

        List<Sys_UserMaster_usm_Info> _purviewUserList;

        List<Sys_RoleMaster_rlm_Info> _purviewRoleList;

        /// <summary>
        /// 窗體列表緩存
        /// </summary>
        List<Sys_FormMaster_fom_Info> _ListFormInfos;

        #endregion

        #endregion

        public UserRoleRightSettings()
        {
            InitializeComponent();

            this._CurrentOptType = EnumOptType.Type_User;
            this._EditStatus = DefineConstantValue.EditStateEnum.OE_ReaOnly;
            this._ISysUserMasterBL = MasterBLLFactory.GetBLL<ISysUserMasterBL>(MasterBLLFactory.SysUserMaster);
            this._ISysRoleMasterBL = MasterBLLFactory.GetBLL<ISysRoleMasterBL>(MasterBLLFactory.SysRoleMaster);
            this._ISysFormMasterBL = MasterBLLFactory.GetBLL<ISysFormMasterBL>(MasterBLLFactory.SysFormMaster);
            this._IUserPurviewBL = MasterBLLFactory.GetBLL<IUserPurviewBL>(MasterBLLFactory.UserPurview);
            this._selecedFormID = 0;

            this._ListRoleMasterInfo = new List<Sys_RoleMaster_rlm_Info>();

            this._ListUserMasterInfo = new List<Sys_UserMaster_usm_Info>();

            this._seachUserAndRoleList = null;

            this._purviewUserList = null;

            this._purviewRoleList = null;

            this._isEdited = false;

            this._isAlert = false;


        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            BindUserInfos();
        }

        #region ************************************用戶帳號信息相關************************************

        /// <summary>
        /// 綁定用戶信息
        /// </summary>
        private void BindUserInfos()
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                Sys_UserMaster_usm_Info searchInfo = new Sys_UserMaster_usm_Info();
                List<IModelObject> listObjUser = this._ISysUserMasterBL.SearchRecords(searchInfo);
                List<Sys_UserMaster_usm_Info> listUsers = new List<Sys_UserMaster_usm_Info>();
                foreach (Sys_UserMaster_usm_Info userItem in listObjUser)
                {
                    if (userItem != null)
                    {
                        listUsers.Add(userItem);
                    }
                }
                this._ListUserMasterInfo = listUsers;
                lvUsers.SetDataSource<Sys_UserMaster_usm_Info>(listUsers);

                ListViewSorter sorter = new ListViewSorter(1, SortOrder.Ascending);
                lvUsers.ListViewItemSorter = sorter;
                lvUsers.Sorting = SortOrder.Ascending;

                lvPurviewUser.SetDataSource(listUsers);

                this._isEdited = false;

                this._ListUserMasterInfo = listUsers;
            }
            catch (Exception ex)
            {
                this.ShowErrorMessage("系統異常，異常信息：" + ex.Message);
                this.Cursor = Cursors.Default;
            }

            this.Cursor = Cursors.Default;
        }

        private void btnUserEnabled_Click(object sender, EventArgs e)
        {
            Sys_UserMaster_usm_Info user = this._ListUserMasterInfo.Where(x => x.usm_iRecordID == this._CurrentUserID).FirstOrDefault();
            if (user != null)
            {
                user.usm_iLock = false;
                user.usm_cLast = this.UserInformation != null ? this.UserInformation.usm_cUserLoginID : "sa";
                user.usm_dLastDate = DateTime.Now;
                ReturnValueInfo res = this._ISysUserMasterBL.Save(user, Common.DefineConstantValue.EditStateEnum.OE_Update);
                if (res.boolValue && !res.isError)
                {
                    this.ShowInformationMessage("帳戶啟用成功。");
                    BindUserInfos();
                }
                else
                {
                    this.ShowWarningMessage("帳戶啟用失敗，異常信息：" + res.messageText);
                }
            }
        }

        private void lvUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvUsers.SelectedItems.Count > 0)
            {
                this._CurrentUserID = Convert.ToInt32(lvUsers.SelectedItems[0].SubItems[0].Text.Trim());//用戶主檔信息記錄ID
                Sys_UserMaster_usm_Info user = this._ListUserMasterInfo.Where(x => x.usm_iRecordID == this._CurrentUserID).FirstOrDefault();
                if (user != null)
                {
                    tbxUserID.Text = user.usm_cUserLoginID;
                    tbxUserName.Text = user.usm_cChaName;
                    //txtPhoneNumber.Text = user.usm_cPhoneNumber;
                    txtEMail.Text = user.usm_cEmail;
                    tbxUserDescribe.Text = user.usm_cRemark;

                    if (user.usm_iLock)
                    {
                        btnUserEnabled.Enabled = true;
                        btnUserDisabled.Enabled = false;
                    }
                    else
                    {
                        btnUserDisabled.Enabled = true;
                        btnUserEnabled.Enabled = false;
                    }

                    btnPwdReset.Enabled = true;
                    sysToolBar.BtnNew_IsEnabled = false;
                    sysToolBar.BtnModify_IsEnabled = true;
                    sysToolBar.BtnDelete_IsEnabled = true;
                    return;
                }

            }

            this._CurrentUserID = 0;
            //btnUserEnabled.Enabled = false;
            btnUserDisabled.Enabled = false;
            btnPwdReset.Enabled = false;

            sysToolBar.BtnNew_IsEnabled = true;
            sysToolBar.BtnModify_IsEnabled = false;
            sysToolBar.BtnDelete_IsEnabled = false;
        }

        private void lvUsers_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lvUsers.SelectedItems.Count > 0)
            {
                this._CurrentUserID = Convert.ToInt32(lvUsers.SelectedItems[0].SubItems[0].Text.Trim());//用戶主檔信息記錄ID
                this._EditStatus = DefineConstantValue.EditStateEnum.OE_Update;
                Sys_UserMaster_usm_Info user = this._ListUserMasterInfo.Where(x => x.usm_iRecordID == this._CurrentUserID).FirstOrDefault();
                if (user != null)
                {
                    tbxUserID.Text = user.usm_cUserLoginID;
                    tbxUserName.Enabled = true;
                    tbxUserName.Text = user.usm_cChaName;
                    tbxPW.Enabled = true;
                    tbxPW.Text = string.Empty;
                    //txtPhoneNumber.Enabled = true;
                    //txtPhoneNumber.Text = user.usm_cPhoneNumber;
                    txtEMail.Enabled = true;
                    txtEMail.Text = user.usm_cEmail;
                    tbxUserDescribe.Enabled = true;
                    tbxUserDescribe.Text = user.usm_cRemark;
                    cbxUserEnabled.Enabled = true;
                    cbxUserEnabled.Checked = user.usm_iLock;
                    btnSaveUser.Enabled = true;
                    btnCancelUser.Enabled = true;

                    sysToolBar.BtnNew_IsEnabled = false;
                    sysToolBar.BtnModify_IsEnabled = false;
                    sysToolBar.BtnDelete_IsEnabled = false;

                    lvUsers.Enabled = false;
                    btnUserEnabled.Enabled = false;
                    btnUserDisabled.Enabled = false;
                    btnPwdReset.Enabled = false;

                    return;
                }
            }

            ResetControlls_UserInfo();
        }

        /// <summary>
        /// 重置用戶信息錄入相關控件狀態
        /// </summary>
        private void ResetControlls_UserInfo()
        {
            this._CurrentUserID = 0;

            sysToolBar.BtnNew_IsEnabled = true;
            sysToolBar.BtnModify_IsEnabled = false;
            sysToolBar.BtnDelete_IsEnabled = false;

            tbxUserID.Enabled = false;
            tbxUserID.Text = string.Empty;
            tbxPW.Text = string.Empty;
            tbxPW.Enabled = false;
            tbxUserName.Enabled = false;
            tbxUserName.Text = string.Empty;
            //txtPhoneNumber.Enabled = false;
            //txtPhoneNumber.Text = string.Empty;
            txtEMail.Enabled = false;
            txtEMail.Text = string.Empty;
            tbxUserDescribe.Enabled = false;
            tbxUserDescribe.Text = string.Empty;
            cbxUserEnabled.Enabled = false;
            cbxUserEnabled.Checked = false;
            btnSaveUser.Enabled = false;
            btnCancelUser.Enabled = false;
        }

        private void btnPwdReset_Click(object sender, EventArgs e)
        {
            string strUserID = lvUsers.SelectedItems[0].SubItems[1].Text;
            if (!this.ShowQuestionMessage("確認重置帳戶：[" + strUserID + "]的登錄密碼？"))
            {
                return;
            }
            Sys_UserMaster_usm_Info user = this._ListUserMasterInfo.Where(x => x.usm_iRecordID == this._CurrentUserID).FirstOrDefault();
            if (user != null)
            {
                user.usm_cPwd = Common.General.MD5("!!!aaa111");
                user.usm_cLast = this.UserInformation != null ? this.UserInformation.usm_cUserLoginID : "sa";
                user.usm_dLastDate = DateTime.Now;
                ReturnValueInfo res = this._ISysUserMasterBL.Save(user, Common.DefineConstantValue.EditStateEnum.OE_Update);
                if (res.boolValue && !res.isError)
                {
                    this.ShowInformationMessage("帳戶密碼重置成功。");
                    BindUserInfos();
                }
                else
                {
                    this.ShowWarningMessage("帳戶密碼重置失敗，異常信息：" + res.messageText);
                }
            }

            this._CurrentUserID = 0;
            btnUserEnabled.Enabled = false;
            btnUserDisabled.Enabled = false;
            btnPwdReset.Enabled = false;
        }

        private void btnUserDisabled_Click(object sender, EventArgs e)
        {
            Sys_UserMaster_usm_Info user = this._ListUserMasterInfo.Where(x => x.usm_iRecordID == this._CurrentUserID).FirstOrDefault();
            if (user != null)
            {
                user.usm_iLock = true;
                user.usm_cLast = this.UserInformation != null ? this.UserInformation.usm_cUserLoginID : "sa";
                user.usm_dLastDate = DateTime.Now;
                ReturnValueInfo res = this._ISysUserMasterBL.Save(user, Common.DefineConstantValue.EditStateEnum.OE_Update);
                if (res.boolValue && !res.isError)
                {
                    this.ShowInformationMessage("帳戶停用成功。");
                    BindUserInfos();
                }
                else
                {
                    this.ShowWarningMessage("帳戶停用失敗，異常信息：" + res.messageText);
                }
            }

            this._CurrentUserID = 0;
            btnUserEnabled.Enabled = false;
            btnUserDisabled.Enabled = false;
            btnPwdReset.Enabled = false;
        }

        private void btnSaveUser_Click(object sender, EventArgs e)
        {
            try
            {
                if (this._EditStatus == DefineConstantValue.EditStateEnum.OE_Update)
                {
                    #region update user

                    Sys_UserMaster_usm_Info searchInfo = new Sys_UserMaster_usm_Info();
                    searchInfo.usm_iRecordID = this._CurrentUserID;
                    List<IModelObject> listObjUser = this._ISysUserMasterBL.SearchRecords(searchInfo);
                    if (listObjUser != null && listObjUser.Count > 0)
                    {
                        Sys_UserMaster_usm_Info user = listObjUser[0] as Sys_UserMaster_usm_Info;
                        if (user != null)
                        {
                            if (tbxPW.Text.Trim() != "")
                            {
                                user.usm_cPwd = tbxPW.Text.Trim();
                            }

                            user.usm_cChaName = tbxUserName.Text.Trim();
                            //user.usm_cPhoneNumber = txtPhoneNumber.Text.Trim();
                            user.usm_cEmail = txtEMail.Text.Trim();
                            user.usm_cRemark = tbxUserDescribe.Text.Trim();
                            user.usm_iLock = cbxUserEnabled.Checked;
                            user.usm_cLast = base.UserInformation != null ? base.UserInformation.usm_cUserLoginID : "sys";
                            user.usm_dLastDate = DateTime.Now;
                            ReturnValueInfo res = this._ISysUserMasterBL.Save(user, Common.DefineConstantValue.EditStateEnum.OE_Update);
                            if (res.boolValue && !res.isError)
                            {
                                this.ShowInformationMessage("修改用戶信息成功。");

                                this._EditStatus = DefineConstantValue.EditStateEnum.OE_ReaOnly;
                            }
                            else
                            {
                                this.ShowErrorMessage("修改用戶信息失敗，異常信息：" + res.messageText);
                            }
                        }
                        else
                        {
                            this.ShowErrorMessage("該用戶信息已被修改，請重新獲取用戶信息。");
                            btnCancelUser_Click(null, null);
                        }
                    }
                    else
                    {
                        this.ShowErrorMessage("該用戶信息已被修改，請重新獲取用戶信息。");
                        btnCancelUser_Click(null, null);
                    }

                    #endregion
                }
                else if (this._EditStatus == DefineConstantValue.EditStateEnum.OE_Insert)
                {
                    Sys_UserMaster_usm_Info user = new Sys_UserMaster_usm_Info();
                    user.usm_cUserLoginID = tbxUserID.Text.Trim();
                    if (string.IsNullOrEmpty(user.usm_cUserLoginID))
                    {
                        this.ShowWarningMessage("帳號ID不能為空。");
                        tbxUserID.Focus();
                        return;
                    }
                    Sys_UserMaster_usm_Info searchInfo = new Sys_UserMaster_usm_Info();
                    searchInfo.usm_cUserLoginID = user.usm_cUserLoginID;
                    List<IModelObject> listObj = this._ISysUserMasterBL.SearchRecords(searchInfo);
                    if (listObj != null && listObj.Count > 0)
                    {
                        this.ShowWarningMessage("已存在相同用戶ID。");
                        tbxUserID.Focus();
                        return;
                    }

                    user.usm_cChaName = tbxUserName.Text.Trim();
                    //user.usm_cPhoneNumber = txtPhoneNumber.Text.Trim();
                    user.usm_cEmail = txtEMail.Text.Trim();
                    user.usm_cRemark = tbxUserDescribe.Text.Trim();
                    user.usm_iLock = cbxUserEnabled.Checked;
                    user.usm_cPwd = tbxPW.Text;
                    user.usm_cAdd = base.UserInformation != null ? base.UserInformation.usm_cUserLoginID : "sys";
                    user.usm_dAddDate = DateTime.Now;
                    user.usm_cLast = base.UserInformation != null ? base.UserInformation.usm_cUserLoginID : "sys";
                    user.usm_dLastDate = DateTime.Now;
                    ReturnValueInfo res = this._ISysUserMasterBL.Save(user, Common.DefineConstantValue.EditStateEnum.OE_Insert);
                    if (res.boolValue && !res.isError)
                    {
                        this.ShowInformationMessage("新增用戶成功。");

                        this._EditStatus = DefineConstantValue.EditStateEnum.OE_ReaOnly;

                    }
                    else
                    {
                        this.ShowErrorMessage("新增用戶失敗，異常信息：" + res.messageText);
                    }

                    this._EditStatus = DefineConstantValue.EditStateEnum.OE_ReaOnly;
                }
            }
            catch (Exception ex)
            {
                this.ShowErrorMessage("操作產生異常：" + ex.Message);
            }
            btnCancelUser_Click(null, null);
        }

        private void btnCancelUser_Click(object sender, EventArgs e)
        {
            if (this._EditStatus != DefineConstantValue.EditStateEnum.OE_ReaOnly)
            {
                if (!this.ShowQuestionMessage("確定取消正在進行的操作嗎？"))
                {
                    return;
                }
            }
            this._EditStatus = DefineConstantValue.EditStateEnum.OE_ReaOnly;

            ResetControlls_UserInfo();

            lvUsers.Enabled = true;
            btnUserEnabled.Enabled = false;
            btnUserDisabled.Enabled = false;
            btnPwdReset.Enabled = false;

            BindUserInfos();
        }

        /// <summary>
        /// 新增用戶操作
        /// </summary>
        void AddNewUserOpt()
        {
            ResetControlls_UserInfo();
            sysToolBar.BtnNew_IsEnabled = false;
            tbxUserID.Enabled = true;
            tbxUserID.Text = string.Empty;
            tbxUserName.Enabled = true;
            tbxPW.Enabled = true;
            tbxUserName.Text = string.Empty;
            //txtPhoneNumber.Enabled = true;
            //txtPhoneNumber.Text = string.Empty;
            txtEMail.Enabled = true;
            txtEMail.Text = string.Empty;
            tbxUserDescribe.Enabled = true;
            tbxUserDescribe.Text = string.Empty;
            cbxUserEnabled.Enabled = true;
            cbxUserEnabled.Checked = false;
            btnSaveUser.Enabled = true;
            btnCancelUser.Enabled = true;

        }

        /// <summary>
        /// 刪除用戶
        /// </summary>
        void DeleteUser()
        {
            if (lvUsers.SelectedItems.Count > 0)
            {
                this._EditStatus = DefineConstantValue.EditStateEnum.OE_Delete;
                string strUserID = lvUsers.SelectedItems[0].SubItems[1].Text;
                if (this.ShowQuestionMessage("確定要刪除帳號【" + strUserID + "】嗎？"))
                {
                    Sys_UserMaster_usm_Info user = new Sys_UserMaster_usm_Info();
                    user.usm_iRecordID = Convert.ToInt32(lvUsers.SelectedItems[0].SubItems[0].Text);
                    ReturnValueInfo rvInfo = this._ISysUserMasterBL.Save(user, DefineConstantValue.EditStateEnum.OE_Delete);
                    if (rvInfo.boolValue && !rvInfo.isError)
                    {
                        this.ShowInformationMessage("刪除成功。");
                        this._EditStatus = DefineConstantValue.EditStateEnum.OE_ReaOnly;
                    }
                    else
                    {
                        this.ShowInformationMessage("刪除失敗。異常信息：" + rvInfo.messageText);
                        this._EditStatus = DefineConstantValue.EditStateEnum.OE_ReaOnly;
                    }
                }
            }
        }

        #endregion

        #region ************************************角色信息相關************************************

        /// <summary>
        /// 綁定角色信息
        /// </summary>
        private void BindRoleInfos()
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                Sys_RoleMaster_rlm_Info searchInfo = new Sys_RoleMaster_rlm_Info();
                List<IModelObject> listObjRole = this._ISysRoleMasterBL.SearchRecords(searchInfo);
                List<Sys_RoleMaster_rlm_Info> listRoleInfos = new List<Sys_RoleMaster_rlm_Info>();
                foreach (Sys_RoleMaster_rlm_Info roleItem in listObjRole)
                {
                    if (roleItem != null)
                    {
                        listRoleInfos.Add(roleItem);
                    }
                }
                this._ListRoleMasterInfo = listRoleInfos;
                lvRole.SetDataSource<Sys_RoleMaster_rlm_Info>(listRoleInfos);
                lvPurviewRole.SetDataSource(listRoleInfos);

                ListViewSorter sorter = new ListViewSorter(1, SortOrder.Ascending);
                lvPurviewRole.ListViewItemSorter = sorter;
                lvPurviewRole.Sorting = SortOrder.Ascending;

                this._isEdited = false;
                this._ListRoleMasterInfo = listRoleInfos;
            }
            catch (Exception ex)
            {
                this.ShowErrorMessage("系統異常，異常信息：" + ex.Message);
                this.Cursor = Cursors.Default;
            }

            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// 新增角色操作
        /// </summary>
        void AddNewRoleOpt()
        {
            lvRole.Enabled = false;
            if (this._EditStatus == DefineConstantValue.EditStateEnum.OE_Insert)
            {
                tbxRoleNum.Enabled = true;
            }
            tbxRoleNum.Text = string.Empty;
            tbxRoleDesc.Enabled = true;
            tbxRoleDesc.Text = string.Empty;
            lvRoleUserList.Enabled = true;
            btnAddRoleUser.Enabled = true;
            btnSaveRole.Enabled = true;
            btnCancelRole.Enabled = true;
            sysToolBar.BtnNew_IsEnabled = false;
        }

        private void btnAddRoleUser_Click(object sender, EventArgs e)
        {
            SysUserMasterSearch dlgUserSearch = new SysUserMasterSearch();
            dlgUserSearch.ShowDialog();
            List<Sys_UserMaster_usm_Info> listUserAdd = dlgUserSearch._RtvInfo;
            foreach (ListViewItem item in lvRoleUserList.Items)
            {
                int iRecord = Convert.ToInt32(item.SubItems[0].Text);
                Sys_UserMaster_usm_Info user = listUserAdd.Find(x => x.usm_iRecordID == iRecord);
                if (user != null)
                {
                    listUserAdd.Remove(user);
                }
            }
            lvRoleUserList.SetDataSource<Sys_UserMaster_usm_Info>(listUserAdd, false);

            ListViewSorter sorter = new ListViewSorter(1, SortOrder.Ascending);
            lvRoleUserList.ListViewItemSorter = sorter;
            lvRoleUserList.Sorting = SortOrder.Ascending;
        }

        private void btnDeleteRoleUser_Click(object sender, EventArgs e)
        {
            if (lvRoleUserList.SelectedItems.Count > 0)
            {
                lvRoleUserList.Items.Remove(lvRoleUserList.SelectedItems[0]);
            }
        }

        private void btnSaveRole_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                Sys_RoleMaster_rlm_Info role = new Sys_RoleMaster_rlm_Info();

                if (this._EditStatus == DefineConstantValue.EditStateEnum.OE_Insert)//插入新增角色
                {
                    role.rlm_cRoleID = tbxRoleNum.Text.Trim();
                    role.rlm_cRoleDesc = tbxRoleDesc.Text.Trim();
                    role.rlm_cAdd = base.UserInformation != null ? base.UserInformation.usm_cUserLoginID : "sys";
                    role.rlm_dAddDate = DateTime.Now;
                    role.rlm_cLast = base.UserInformation != null ? base.UserInformation.usm_cUserLoginID : "sys";
                    role.rlm_dLastDate = DateTime.Now;
                    role.userMasterList = GetRoleUserList(lvRoleUserList);

                    ReturnValueInfo res = this._ISysRoleMasterBL.Save(role, DefineConstantValue.EditStateEnum.OE_Insert);
                    if (res.boolValue && !res.isError)
                    {
                        this.ShowInformationMessage("新增記錄成功。");

                        BindRoleInfos();

                        RoleSaveSuccOpt();

                        this._EditStatus = DefineConstantValue.EditStateEnum.OE_ReaOnly;
                    }
                    else
                    {
                        this.ShowWarningMessage("新增記錄失敗。異常信息：" + res.messageText);
                    }
                }
                else if (this._EditStatus == DefineConstantValue.EditStateEnum.OE_Update)//更新原有角色信息記錄
                {
                    role = this._ISysRoleMasterBL.SearchRecords(new Sys_RoleMaster_rlm_Info() { rlm_iRecordID = this._CurrentRoleID }).FirstOrDefault() as Sys_RoleMaster_rlm_Info;
                    if (role == null)
                    {
                        role = this._ListRoleMasterInfo.Find(x => x.rlm_iRecordID == this._CurrentRoleID);
                    }
                    //role.rlm_cRoleID = tbxRoleNum.Text.Trim();
                    role.rlm_cRoleDesc = tbxRoleDesc.Text.Trim();
                    role.rlm_cLast = base.UserInformation != null ? base.UserInformation.usm_cUserLoginID : "sys";
                    role.rlm_dLastDate = DateTime.Now;
                    role.userMasterList = GetRoleUserList(lvRoleUserList);

                    ReturnValueInfo res = this._ISysRoleMasterBL.Save(role, DefineConstantValue.EditStateEnum.OE_Update);
                    if (res.boolValue && !res.isError)
                    {
                        this.ShowInformationMessage("更新記錄成功。");

                        BindRoleInfos();

                        RoleSaveSuccOpt();

                        this._EditStatus = DefineConstantValue.EditStateEnum.OE_ReaOnly;
                    }
                    else
                    {
                        this.ShowWarningMessage("更新記錄失敗。異常信息：" + res.messageText);
                    }
                }
            }
            catch (Exception ex)
            {
                this.ShowErrorMessage(ex);
            }

            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// 成功保存用戶信息記錄的控件操作
        /// </summary>
        void RoleSaveSuccOpt()
        {
            sysToolBar.BtnNew_IsEnabled = true;
            sysToolBar.BtnModify_IsEnabled = false;
            sysToolBar.BtnDelete_IsEnabled = false;

            lvRole.Enabled = true;
            tbxRoleNum.Enabled = false;
            tbxRoleDesc.Enabled = false;
            lvRoleUserList.Enabled = false;
            lvRoleUserList.SetDataSource<Sys_UserMaster_usm_Info>(null);
            btnAddRoleUser.Enabled = false;
            btnDeleteRoleUser.Enabled = false;
        }

        /// <summary>
        /// 獲得ListView中的用戶列表
        /// </summary>
        /// <param name="lvSource"></param>
        /// <returns></returns>
        List<Sys_UserMaster_usm_Info> GetRoleUserList(ListView lvSource)
        {
            List<Sys_UserMaster_usm_Info> listRes = new List<Sys_UserMaster_usm_Info>();
            foreach (ListViewItem item in lvSource.Items)
            {
                Sys_UserMaster_usm_Info user = new Sys_UserMaster_usm_Info();
                user.usm_iRecordID = Convert.ToInt32(item.SubItems[0].Text);
                user.usm_cUserLoginID = item.SubItems[1].Text;
                listRes.Add(user);
            }
            return listRes;
        }

        private void btnCancelRole_Click(object sender, EventArgs e)
        {
            if (this._EditStatus != DefineConstantValue.EditStateEnum.OE_ReaOnly)
            {
                if (!this.ShowQuestionMessage("確定取消正在進行的操作嗎？"))
                {
                    return;
                }
            }

            lvRole.Enabled = true;
            tbxRoleNum.Enabled = false;
            tbxRoleNum.Text = string.Empty;
            tbxRoleDesc.Enabled = false;
            tbxRoleDesc.Text = string.Empty;
            lvRoleUserList.Enabled = false;
            lvRoleUserList.SetDataSource<Sys_UserMaster_usm_Info>(null);
            btnAddRoleUser.Enabled = false;
            btnDeleteRoleUser.Enabled = false;
            btnSaveRole.Enabled = false;
            btnCancelRole.Enabled = false;

            sysToolBar.BtnNew_IsEnabled = true;
            sysToolBar.BtnModify_IsEnabled = false;
            sysToolBar.BtnDelete_IsEnabled = false;
            this._EditStatus = DefineConstantValue.EditStateEnum.OE_ReaOnly;
        }

        private void lvRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            this._EditStatus = DefineConstantValue.EditStateEnum.OE_ReaOnly;
            if (lvRole.SelectedItems.Count > 0)
            {
                int iRoleID = Convert.ToInt32(lvRole.SelectedItems[0].SubItems[0].Text);
                this._CurrentRoleID = iRoleID;
                Sys_RoleMaster_rlm_Info role = this._ListRoleMasterInfo.Where(x => x.rlm_iRecordID == iRoleID).FirstOrDefault();
                if (role != null)
                {
                    tbxRoleNum.Text = role.rlm_cRoleID;
                    tbxRoleDesc.Text = role.rlm_cRoleDesc;
                    if (role.userMasterList != null && role.userMasterList.Count > 0)
                    {
                        lvRoleUserList.SetDataSource<Sys_UserMaster_usm_Info>(role.userMasterList);
                    }

                    sysToolBar.BtnDelete_IsEnabled = true;
                    sysToolBar.BtnModify_IsEnabled = true;
                    sysToolBar.BtnNew_IsEnabled = false;

                    return;
                }
            }

            tbxRoleNum.Text = string.Empty;
            tbxRoleDesc.Text = string.Empty;
            lvRoleUserList.SetDataSource<Sys_UserMaster_usm_Info>(null);

            btnAddRoleUser.Enabled = false;
            btnDeleteRoleUser.Enabled = false;
            btnSaveRole.Enabled = false;
            btnCancelRole.Enabled = false;
            lvRoleUserList.Enabled = false;

            sysToolBar.BtnDelete_IsEnabled = false;
            sysToolBar.BtnModify_IsEnabled = false;
            sysToolBar.BtnNew_IsEnabled = true;
        }

        private void lvRole_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lvRole.SelectedItems.Count > 0)
            {
                int iRoleID = Convert.ToInt32(lvRole.SelectedItems[0].SubItems[0].Text);
                this._CurrentRoleID = iRoleID;

                Sys_RoleMaster_rlm_Info role = this._ListRoleMasterInfo.Where(x => x.rlm_iRecordID == iRoleID).FirstOrDefault();
                if (role != null)
                {
                    this._EditStatus = DefineConstantValue.EditStateEnum.OE_Update;

                    tbxRoleNum.Text = role.rlm_cRoleID;
                    tbxRoleDesc.Text = role.rlm_cRoleDesc;
                    if (role.userMasterList != null && role.userMasterList.Count > 0)
                    {
                        lvRoleUserList.SetDataSource<Sys_UserMaster_usm_Info>(role.userMasterList);
                    }

                    sysToolBar.BtnDelete_IsEnabled = false;
                    sysToolBar.BtnModify_IsEnabled = false;
                    sysToolBar.BtnNew_IsEnabled = false;
                    lvRole.Enabled = false;

                    //tbxRoleNum.Enabled = true;
                    tbxRoleDesc.Enabled = true;
                    lvRoleUserList.Enabled = true;
                    btnAddRoleUser.Enabled = true;
                    btnSaveRole.Enabled = true;
                    btnCancelRole.Enabled = true;
                }
            }
        }

        private void lvRoleUserList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvRoleUserList.SelectedItems.Count > 0)
            {
                btnAddRoleUser.Enabled = false;
                btnDeleteRoleUser.Enabled = true;
            }
            else
            {
                btnAddRoleUser.Enabled = true;
                btnDeleteRoleUser.Enabled = false;
            }
        }

        /// <summary>
        /// 删除角色
        /// </summary>
        void DeleteRole()
        {
            if (lvRole.SelectedItems.Count > 0)
            {
                this._EditStatus = DefineConstantValue.EditStateEnum.OE_Delete;
                string strRoleID = lvRole.SelectedItems[0].SubItems[1].Text;
                if (this.ShowQuestionMessage("確定要刪除角色【" + strRoleID + "】嗎？"))
                {
                    Sys_RoleMaster_rlm_Info role = new Sys_RoleMaster_rlm_Info();
                    role.rlm_iRecordID = Convert.ToInt32(lvRole.SelectedItems[0].SubItems[0].Text);
                    ReturnValueInfo rvInfo = this._ISysRoleMasterBL.Save(role, DefineConstantValue.EditStateEnum.OE_Delete);
                    if (rvInfo.boolValue && !rvInfo.isError)
                    {
                        this.ShowInformationMessage("刪除成功。");
                        this._EditStatus = DefineConstantValue.EditStateEnum.OE_ReaOnly;
                    }
                    else
                    {
                        this.ShowInformationMessage("刪除失敗。異常信息：" + rvInfo.messageText);
                        this._EditStatus = DefineConstantValue.EditStateEnum.OE_ReaOnly;
                    }
                }
            }
        }

        #endregion

        #region ************************************權限信息相關************************************

        private class LVUserRoleInfo
        {
            public int RecordID { get; set; }
            public string UserRoleID { get; set; }
            public string UserRoleDesc { get; set; }
            public int FormID { get; set; }
        }

        /// <summary>
        /// 綁定權限信息
        /// </summary>
        private void BindRightInfos()
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                BindFormTreeView();

                //BindFormLocalTreeView();
            }
            catch (Exception ex)
            {
                this.ShowErrorMessage("系統異常，異常信息：" + ex.Message);
                this.Cursor = Cursors.Default;
            }

            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// 新增權限操作
        /// </summary>
        void AddRightOpt()
        {
            sysToolBar.BtnNew_IsEnabled = false;
            tvFromMain.Enabled = true;
            tvFromMain.CheckBoxes = true;
            btnSaveRight.Enabled = true;
            btnCancelRight.Enabled = true;
        }

        void BindFormTreeView()
        {
            this.Cursor = Cursors.WaitCursor;

            //TODO: 修改成遞歸算法

            Sys_FormMaster_fom_Info info = new Sys_FormMaster_fom_Info();
            //info.fom_cSysCode = Common.DefineConstantValue.SysFormCodeEnum.HBManager.ToString();
            List<IModelObject> listObjForms = this._ISysFormMasterBL.SearchRecords(info);
            this._ListFormInfos = new List<Sys_FormMaster_fom_Info>();
            foreach (Sys_FormMaster_fom_Info item in listObjForms)
            {
                if (item != null)
                {
                    this._ListFormInfos.Add(item);
                }
            }

            List<Sys_FormMaster_fom_Info> listForms = this._ListFormInfos;
            try
            {
                //增加根结点
                tvFromMain.Nodes.Clear();

                tvFromMain2.Nodes.Clear();

                info = listForms.Find(x => x.fom_iParentID == -1);
                if (info == null)
                {
                    this.Cursor = Cursors.Default;
                    return;
                }
                TreeNode rootNode = new TreeNode(info.fom_cFormDesc);
                rootNode.Name = info.fom_iRecordID.ToString();
                rootNode.Tag = info.fom_cExePath.ToString();
                tvFromMain.Nodes.Add(rootNode);

                TreeNode rootNode2 = new TreeNode(info.fom_cFormDesc);
                rootNode2.Name = info.fom_iRecordID.ToString();
                rootNode2.Tag = info.fom_cExePath.ToString();
                tvFromMain2.Nodes.Add(rootNode2);
                GetFormList(rootNode2, listForms, info.fom_iRecordID);


                //加载子节点
                GetFormList(rootNode, listForms, info.fom_iRecordID);

                if (tvFromMain.Nodes.Count > 0)
                {
                    tvFromMain.ExpandAll();
                    tvFromMain.SelectedNode = tvFromMain.Nodes[0];
                }

                if (tvFromMain2.Nodes.Count > 0)
                {
                    tvFromMain2.ExpandAll();
                    tvFromMain2.SelectedNode = tvFromMain.Nodes[0];
                }
            }
            catch (Exception Ex)
            { this.ShowErrorMessage(Ex); }

            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// 加載樹節點的所有子節點
        /// </summary>
        /// <param name="nodeCurrent">當前樹節點</param>
        /// <param name="listForms">窗體記錄列表</param>
        /// <param name="iParentID">當前節點綁定的窗體ID</param>
        void GetFormList(TreeNode nodeCurrent, List<Sys_FormMaster_fom_Info> listForms, int iParentID)
        {
            List<Sys_FormMaster_fom_Info> listSubForms = listForms.Where(x => x.fom_iParentID == iParentID).ToList();
            if (listForms == null)
            {
                return;
            }
            if (listForms.Count < 1)
            {
                return;
            }

            foreach (Sys_FormMaster_fom_Info formItem in listSubForms)
            {
                if (formItem == null)
                {
                    continue;
                }
                TreeNode subNode = new TreeNode(formItem.fom_cFormDesc);
                subNode.Name = formItem.fom_iRecordID.ToString();
                subNode.Tag = formItem.fom_cExePath.ToString();
                nodeCurrent.Nodes.Add(subNode);

                GetFormList(subNode, listForms, formItem.fom_iRecordID);
            }
        }

        void BindFormLocalTreeView()
        {
            List<MenuItem> listMenu = new List<MenuItem>();
            foreach (MenuItem item in ((MainForm)this.Parent.Parent).TopMenu.MenuItems)
            {
                foreach (MenuItem subItem in item.MenuItems)
                {
                    if (subItem != null)
                    {
                        listMenu.Add(subItem);
                    }
                }
            }
        }


        private void btnSaveRight_Click(object sender, EventArgs e)
        {
            SaveRightSub();

            this._EditStatus = DefineConstantValue.EditStateEnum.OE_ReaOnly;
        }

        private void SaveRightSub()
        {
            List<Sys_UserPurview_usp_Info> rightList = new List<Sys_UserPurview_usp_Info>();

            if (this._selecedFormID != 0)
            {
                if (lvPurviewUser.CheckedItems != null && lvPurviewUser.CheckedItems.Count > 0)
                {
                    foreach (ListViewItem userInfo in lvPurviewUser.CheckedItems)
                    {
                        Sys_UserPurview_usp_Info checkedUser = new Sys_UserPurview_usp_Info();

                        checkedUser.usp_cUserLoginID = userInfo.SubItems[1].Text;

                        checkedUser.usp_iFormID = this._selecedFormID;

                        checkedUser.usp_cAdd = this.UserInformation.usm_cUserLoginID;

                        checkedUser.usp_cLast = this.UserInformation.usm_cUserLoginID;

                        rightList.Add(checkedUser);
                    }
                }

                if (lvPurviewRole.CheckedItems != null && lvPurviewRole.CheckedItems.Count > 0)
                {
                    foreach (ListViewItem roleInfo in lvPurviewRole.CheckedItems)
                    {
                        Sys_UserPurview_usp_Info checkedRole = new Sys_UserPurview_usp_Info();

                        checkedRole.usp_cRoleID = roleInfo.SubItems[1].Text;

                        checkedRole.usp_iFormID = this._selecedFormID;

                        checkedRole.usp_cLast = this.UserInformation.usm_cUserLoginID;

                        checkedRole.usp_cAdd = this.UserInformation.usm_cUserLoginID;

                        rightList.Add(checkedRole);
                    }
                }

                try
                {
                    ReturnValueInfo returnInfo = this._IUserPurviewBL.SavePruview(rightList, this._selecedFormID);

                    if (returnInfo.boolValue)
                    {
                        ShowInformationMessage(Common.DefineConstantValue.SystemMessageText.strMessageText_I_SaveSuccess);
                    }
                    else
                    {
                        ShowErrorMessage(returnInfo.messageText);
                    }
                }
                catch (Exception Ex)
                {

                    ShowErrorMessage(Ex.Message);
                }

                gbRole.Enabled = false;

                gbUser.Enabled = false;

                tvFromMain.Enabled = true;

                this._isEdited = false;
            }
        }

        private void btnCancelRight_Click(object sender, EventArgs e)
        {
            //if (this._EditStatus != DefineConstantValue.EditStateEnum.OE_ReaOnly)
            //{
            //    if (!this.ShowQuestionMessage("確定取消正在進行的操作嗎？"))
            //    {
            //        return;
            //    }
            //}

            this._isEdited = false;

            sysToolBar.BtnNew_IsEnabled = false;
            sysToolBar.BtnModify_IsEnabled = false;
            tvFromMain.Enabled = true;
            tvFromMain.CheckBoxes = false;

            btnSaveRight.Enabled = false;
            btnCancelRight.Enabled = false;

            gbUser.Enabled = false;

            gbRole.Enabled = false;

            BindRightInfos();

            this._EditStatus = DefineConstantValue.EditStateEnum.OE_ReaOnly;
        }

        private void btnAddRightRole_Click(object sender, EventArgs e)
        {

        }

        private void btnRightUser_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 删除權限信息
        /// </summary>
        void DeleteRight()
        {

        }

        private void SetColor(TreeNode objNode)
        {
            if (objNode != null)
            {
                if (objNode.Nodes != null && objNode.Nodes.Count > 0)
                {
                    foreach (TreeNode item in objNode.Nodes)
                    {
                        SetColor(item);
                    }

                }
                objNode.ForeColor = Color.Black;
            }
        }

        private void tvMain_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            this._EditStatus = DefineConstantValue.EditStateEnum.OE_Update;

            this._CurrentOptType = EnumOptType.Type_RightFrom;

            LoadUserAndRoleRight(sender);
        }

        private void LoadUserAndRoleRight(object sender)
        {
            if (!this._isEdited)
            {
                if (tvFromMain.SelectedNode != null && tvFromMain.SelectedNode.Nodes.Count == 0)
                {
                    this._isEdited = false;

                    this._selecedFormID = Convert.ToInt32(((TreeView)sender).SelectedNode.Name);

                    SetColor(((TreeView)sender).Nodes[0]);

                    (((TreeView)sender).SelectedNode).ForeColor = Color.Red;

                    Sys_UserPurview_usp_Info query = new Sys_UserPurview_usp_Info();

                    query.usp_iFormID = _selecedFormID;

                    try
                    {
                        List<Sys_UserPurview_usp_Info> formUser = _IUserPurviewBL.GetFormPurview(query);

                        if (formUser != null && formUser.Count > 0)
                        {
                            foreach (Sys_UserPurview_usp_Info item in formUser)
                            {
                                #region 设置选定用户
                                if (item.userMasterList != null && item.userMasterList.Count > 0)
                                {
                                    foreach (Sys_UserMaster_usm_Info userInfo in item.userMasterList)
                                    {
                                        Sys_UserMaster_usm_Info usercheckInfo = this._ListUserMasterInfo.FirstOrDefault(t => t.usm_iRecordID == userInfo.usm_iRecordID);

                                        if (usercheckInfo != null)
                                        {
                                            usercheckInfo.isChecked = true;
                                        }
                                        else
                                        {
                                            usercheckInfo.isChecked = false;
                                        }
                                    }
                                }
                                else
                                {

                                    foreach (ListViewItem info in lvPurviewUser.Items)
                                    {
                                        info.Checked = false;
                                    }
                                }
                                #endregion

                                #region 设置选定角色
                                if (item.roleMasterList != null && item.roleMasterList.Count > 0)
                                {
                                    foreach (Sys_RoleMaster_rlm_Info roleInfo in item.roleMasterList)
                                    {
                                        //this._ListRoleMasterInfo.Add(roleInfo);

                                        Sys_RoleMaster_rlm_Info roleCheckInfo = _ListRoleMasterInfo.FirstOrDefault(t => t.rlm_iRecordID == roleInfo.rlm_iRecordID);

                                        if (roleCheckInfo != null)
                                        {
                                            roleCheckInfo.isChecked = true;
                                        }
                                        else
                                        {
                                            roleCheckInfo.isChecked = false;
                                        }
                                    }
                                }
                                else
                                {
                                    foreach (ListViewItem info in lvPurviewRole.Items)
                                    {
                                        info.Checked = false;
                                    }
                                }
                                #endregion
                            }

                            #region 显示选定角色
                            foreach (ListViewItem item in lvPurviewRole.Items)
                            {
                                Sys_RoleMaster_rlm_Info roleInfo = this._ListRoleMasterInfo.FirstOrDefault(t => t.rlm_iRecordID == Convert.ToInt32(item.SubItems[0].Text));

                                if (roleInfo != null)
                                {

                                    item.Checked = roleInfo.isChecked;

                                    if (item.Checked)
                                    {
                                        item.BackColor = Color.SkyBlue;
                                    }
                                    else
                                    {
                                        item.BackColor = Color.White;
                                    }

                                }
                                else
                                {
                                    item.Checked = false;

                                    item.BackColor = Color.White;
                                }
                            }
                            #endregion

                            #region 显示选定用户
                            foreach (ListViewItem item in lvPurviewUser.Items)
                            {
                                Sys_UserMaster_usm_Info userInfo = this._ListUserMasterInfo.FirstOrDefault(t => t.usm_iRecordID == Convert.ToInt32(item.SubItems[0].Text));

                                if (userInfo != null)
                                {
                                    item.Checked = userInfo.isChecked;

                                    if (item.Checked)
                                    {
                                        item.BackColor = Color.SkyBlue;
                                    }
                                    else
                                    {
                                        item.BackColor = Color.White;
                                    }
                                }
                                else
                                {
                                    item.Checked = false;

                                    item.BackColor = Color.White;
                                }
                            }
                            #endregion


                        }
                        else
                        {
                            #region 重置数据
                            foreach (ListViewItem item in lvPurviewRole.Items)
                            {
                                item.Checked = false;

                                item.BackColor = Color.White;
                            }

                            foreach (ListViewItem item in lvPurviewUser.Items)
                            {
                                item.Checked = false;

                                item.BackColor = Color.White;
                            }
                            #endregion
                        }

                        #region 重置显示
                        foreach (Sys_UserMaster_usm_Info item in this._ListUserMasterInfo)
                        {
                            item.isChecked = false;


                        }

                        foreach (Sys_RoleMaster_rlm_Info item in this._ListRoleMasterInfo)
                        {
                            item.isChecked = false;

                        }

                        this.EditState = DefineConstantValue.EditStateEnum.OE_Update;

                        gbUser.Enabled = true;

                        gbRole.Enabled = true;

                        btnSaveRight.Enabled = true;

                        btnCancelRight.Enabled = true;

                        this._isEdited = false;
                        #endregion

                    }
                    catch (Exception Ex)
                    {

                        ShowErrorMessage(Ex.Message);

                        this.EditState = DefineConstantValue.EditStateEnum.OE_ReaOnly;


                    }
                }
                else
                {
                    gbUser.Enabled = false;

                    gbRole.Enabled = false;

                    btnSaveRight.Enabled = false;

                    btnCancelRight.Enabled = false;
                }
            }
            else
            {
                if (!this.ShowQuestionMessage("確定保存当前修改嗎？"))
                {
                    this._isEdited = false;

                    LoadUserAndRoleRight(sender);


                }
                else
                {
                    SaveRightSub();

                    LoadUserAndRoleRight(sender);

                }


            }
        }



        #endregion

        /// <summary>
        /// 編輯信息類型枚舉
        /// </summary>
        private enum EnumOptType
        {
            /// <summary>
            /// 用戶信息
            /// </summary>
            Type_User = 0,
            /// <summary>
            /// 角色信息
            /// </summary>
            Type_Role = 1,
            /// <summary>
            /// 權限信息
            /// </summary>
            Type_RightFrom = 2,

            /// <summary>
            /// 權限信息
            /// </summary>
            Type_RightUesr = 3
        }

        private void sysToolBar_OnItemNew_Click(object sender, EventArgs e)
        {
            this._EditStatus = DefineConstantValue.EditStateEnum.OE_Insert;
            lvUsers.Enabled = false;
            btnUserEnabled.Enabled = false;
            btnUserDisabled.Enabled = false;
            btnPwdReset.Enabled = false;


            switch (this._CurrentOptType)
            {
                case EnumOptType.Type_User:
                    AddNewUserOpt();
                    break;
                case EnumOptType.Type_Role:
                    AddNewRoleOpt();
                    break;
                case EnumOptType.Type_RightFrom:
                    AddRightOpt();
                    break;
                default:
                    this._EditStatus = DefineConstantValue.EditStateEnum.OE_ReaOnly;
                    break;
            }
        }

        private void sysToolBar_OnItemModify_Click(object sender, EventArgs e)
        {
            this._EditStatus = DefineConstantValue.EditStateEnum.OE_Update;
            switch (this._CurrentOptType)
            {
                case EnumOptType.Type_User:
                    lvUsers_MouseDoubleClick(null, null);
                    break;
                case EnumOptType.Type_Role:
                    lvRole_MouseDoubleClick(null, null);
                    break;
                case EnumOptType.Type_RightFrom:
                    tvMain_NodeMouseDoubleClick(null, null);
                    break;
                default:
                    this._EditStatus = DefineConstantValue.EditStateEnum.OE_ReaOnly;
                    break;
            }
        }

        private void sysToolBar_OnItemDelete_Click(object sender, EventArgs e)
        {
            this._EditStatus = DefineConstantValue.EditStateEnum.OE_Delete;
            switch (this._CurrentOptType)
            {
                case EnumOptType.Type_User:
                    DeleteUser();
                    btnCancelUser_Click(null, null);
                    break;
                case EnumOptType.Type_Role:
                    DeleteRole();
                    btnCancelRole_Click(null, null);
                    break;
                case EnumOptType.Type_RightFrom:
                    DeleteRight();
                    btnCancelRight_Click(null, null);
                    break;
                default:
                    break;
            }
        }

        private void sysToolBar_OnItemRefresh_Click(object sender, EventArgs e)
        {
            this._EditStatus = DefineConstantValue.EditStateEnum.OE_ReaOnly;
            switch (this._CurrentOptType)
            {
                case EnumOptType.Type_User:
                    BindUserInfos();
                    break;
                case EnumOptType.Type_Role:
                    BindRoleInfos();
                    break;
                case EnumOptType.Type_RightFrom:
                    BindRightInfos();
                    break;
                default:
                    break;
            }
        }

        private void sysToolBar_OnItemExit_Click(object sender, EventArgs e)
        {
            if (this._EditStatus == DefineConstantValue.EditStateEnum.OE_Update)
            {
                if (this.ShowQuestionMessage("正在編輯數據中，確認退出？"))
                {
                    this.Close();
                }
            }
            else if (this._EditStatus == DefineConstantValue.EditStateEnum.OE_Insert)
            {
                if (this.ShowQuestionMessage("正在新增數據中，確認退出？"))
                {
                    this.Close();
                }
            }
            else
            {
                if (this.ShowQuestionMessage("確認退出？"))
                {
                    this.Close();
                }
            }
        }

        private void tbcMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this._EditStatus == DefineConstantValue.EditStateEnum.OE_ReaOnly)
            {
                switch (tbcMain.SelectedIndex)
                {
                    case (int)EnumOptType.Type_User:
                        {
                            this._CurrentOptType = EnumOptType.Type_User;
                            BindUserInfos();
                            btnCancelUser_Click(null, null);
                            break;
                        }
                    case (int)EnumOptType.Type_Role:
                        {
                            this._CurrentOptType = EnumOptType.Type_Role;
                            BindRoleInfos();
                            btnCancelRole_Click(null, null);
                            break;
                        }
                    case (int)EnumOptType.Type_RightFrom:
                        {
                            this._CurrentOptType = EnumOptType.Type_RightFrom;
                            BindRightInfos();
                            btnCancelRight_Click(null, null);
                            sysToolBar.BtnModify_IsUsed = false;

                            sysToolBar.BtnNew_IsEnabled = false;
                            break;
                        }
                    case (int)EnumOptType.Type_RightUesr:
                        {
                            this._CurrentOptType = EnumOptType.Type_RightUesr;
                            BindRoleInfos();
                            btnCancelRight_Click(null, null);
                            sysToolBar.BtnModify_IsUsed = false;

                            sysToolBar.BtnNew_IsEnabled = false;
                            break;
                        }
                    default:
                        break;
                }
            }
            else
            {
                switch (this._CurrentOptType)
                {
                    case EnumOptType.Type_User:
                        if (tbcMain.SelectedIndex != (int)EnumOptType.Type_User)
                        {
                            tbcMain.SelectedIndex = (int)EnumOptType.Type_User;

                            sysToolBar.BtnNew_IsEnabled = true;

                            sysToolBar.BtnNew_IsUsed = true;
                        }
                        break;
                    case EnumOptType.Type_Role:
                        if (tbcMain.SelectedIndex != (int)EnumOptType.Type_Role)
                        {
                            tbcMain.SelectedIndex = (int)EnumOptType.Type_Role;

                            sysToolBar.BtnNew_IsEnabled = true;

                            sysToolBar.BtnNew_IsUsed = true;
                        }
                        break;
                    case EnumOptType.Type_RightFrom:
                        if (tbcMain.SelectedIndex != (int)EnumOptType.Type_RightFrom)
                        {
                            tbcMain.SelectedIndex = (int)EnumOptType.Type_RightFrom;

                            sysToolBar.BtnNew_IsEnabled = false;

                            sysToolBar.BtnNew_IsUsed = false;
                        }
                        break;

                    case EnumOptType.Type_RightUesr:
                        if (tbcMain.SelectedIndex != (int)EnumOptType.Type_RightUesr)
                        {
                            tbcMain.SelectedIndex = (int)EnumOptType.Type_RightUesr;

                            sysToolBar.BtnNew_IsEnabled = false;

                            sysToolBar.BtnNew_IsUsed = false;
                        }
                        break;
                    default:
                        this._EditStatus = DefineConstantValue.EditStateEnum.OE_ReaOnly;
                        break;
                }

            }

            BindRoleInfos();
        }

        private void lvPurviewUser_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            this._isEdited = true;
        }

        private void lvPurviewRole_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            this._isEdited = true;
        }

        private void tbxSearch_TextChanged(object sender, EventArgs e)
        {
            Sys_UserAndRoleGeneral_Info qeruyInfo = new Sys_UserAndRoleGeneral_Info();

            qeruyInfo.searchKey = tbxSearch.Text.Trim();

            try
            {
                List<Sys_UserAndRoleGeneral_Info> returnList = this._IUserPurviewBL.SearchUserAndRole(qeruyInfo);

                if (returnList != null)
                {
                    lvUserAndRole.SetDataSource(returnList);

                    this._seachUserAndRoleList = returnList;
                }
            }
            catch (Exception Ex)
            {

                ShowErrorMessage(Ex.Message);
            }


        }

        private void btnSetRight_Click(object sender, EventArgs e)
        {
            if (lvUserAndRole.SelectedItems != null && lvUserAndRole.SelectedItems.Count > 0)
            {
                this._EditStatus = DefineConstantValue.EditStateEnum.OE_Update;

                this._CurrentOptType = EnumOptType.Type_RightUesr;

                gbxUserAndRole.Enabled = false;

                gbFormTree.Enabled = true;

                btnSaveFormRight.Enabled = true;

                btnCancelFormRight.Enabled = true;

                btnSetRight.Enabled = false;

                Sys_UserPurview_usp_Info info = new Sys_UserPurview_usp_Info();

                if (lvUserAndRole.SelectedItems[0].SubItems[4].Text == Sys_UserAndRoleGeneral_Info.accountType.userID.ToString())
                {
                    info.usp_cUserLoginID = lvUserAndRole.SelectedItems[0].SubItems[1].Text;
                }
                else
                {
                    info.usp_cRoleID = lvUserAndRole.SelectedItems[0].SubItems[1].Text;
                }

                try
                {
                    List<Sys_UserPurview_usp_Info> allRight = this._IUserPurviewBL.GetUserOrRolePurview(info);

                    CheckedNode(tvFromMain2.Nodes[0], allRight);




                }
                catch (Exception Ex)
                {

                    ShowErrorMessage(Ex.Message);
                }


            }
        }

        private void CheckedNode(TreeNode node, List<Sys_UserPurview_usp_Info> rightList)
        {
            if (rightList != null)
            {
                Sys_UserPurview_usp_Info info = rightList.FirstOrDefault(t => t.usp_iFormID == Convert.ToInt32(node.Name));

                if (info != null)
                {
                    node.Checked = true;
                }
                else
                {
                    node.Checked = false;
                }

                if (node.Nodes != null && node.Nodes.Count > 0)
                {
                    foreach (TreeNode item in node.Nodes)
                    {
                        CheckedNode(item, rightList);
                    }
                }
            }
            else
            {

                node.Checked = false;

                CheckedNode(node, new List<Sys_UserPurview_usp_Info>());
            }
        }

        private void tvFromMain2_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Action != TreeViewAction.Unknown)
            {
                if (e.Node.Nodes.Count > 0)
                {
                    this.CheckAllChildNodes(e.Node, e.Node.Checked);
                }
            }
        }

        private void CheckAllChildNodes(TreeNode treeNode, bool nodeChecked)
        {
            foreach (TreeNode node in treeNode.Nodes)
            {
                node.Checked = nodeChecked;
                if (node.Nodes.Count > 0)
                {
                    this.CheckAllChildNodes(node, nodeChecked);
                }
            }
        }

        private void btnSaveFormRight_Click(object sender, EventArgs e)
        {


            string objID = string.Empty;

            List<Sys_UserPurview_usp_Info> saveList = new List<Sys_UserPurview_usp_Info>();

            List<Sys_UserMaster_usm_Info> userList = new List<Sys_UserMaster_usm_Info>();

            List<Sys_RoleMaster_rlm_Info> roleList = new List<Sys_RoleMaster_rlm_Info>();

            List<Sys_FormMaster_fom_Info> formList = new List<Sys_FormMaster_fom_Info>();

            #region MyRegion
            if (lvUserAndRole.SelectedItems != null && lvUserAndRole.SelectedItems.Count > 0)
            {
                foreach (ListViewItem item in lvUserAndRole.SelectedItems)
                {
                    if (item.SubItems[4].Text == Sys_UserAndRoleGeneral_Info.accountType.userID.ToString())
                    {
                        Sys_UserMaster_usm_Info info = new Sys_UserMaster_usm_Info();

                        info.RecordID = Convert.ToInt32(item.SubItems[0].Text);

                        info.usm_cUserLoginID = item.SubItems[1].Text;

                        objID = info.usm_cUserLoginID;

                        userList.Add(info);

                        saveTypeID = Sys_UserAndRoleGeneral_Info.accountType.userID;
                    }
                    else
                    {
                        Sys_RoleMaster_rlm_Info info = new Sys_RoleMaster_rlm_Info();

                        info.rlm_iRecordID = Convert.ToInt32(item.SubItems[0].Text);

                        info.rlm_cRoleID = item.SubItems[1].Text;

                        objID = info.rlm_cRoleID;

                        roleList.Add(info);

                        saveTypeID = Sys_UserAndRoleGeneral_Info.accountType.roleID;
                    }
                }
            }
            #endregion


            HandelFormRight(tvFromMain2.Nodes[0], formList);

            foreach (Sys_UserMaster_usm_Info user in userList)
            {
                foreach (Sys_FormMaster_fom_Info form in formList)
                {
                    Sys_UserPurview_usp_Info info = new Sys_UserPurview_usp_Info();

                    info.usp_iFormID = form.fom_iRecordID;

                    info.usp_cUserLoginID = user.usm_cUserLoginID;

                    info.usp_cAdd = this.UserInformation.usm_cUserLoginID;

                    info.usp_cLast = this.UserInformation.usm_cUserLoginID;

                    saveList.Add(info);
                }
            }

            foreach (Sys_RoleMaster_rlm_Info role in roleList)
            {
                foreach (Sys_FormMaster_fom_Info form in formList)
                {
                    Sys_UserPurview_usp_Info info = new Sys_UserPurview_usp_Info();

                    info.usp_iFormID = form.fom_iRecordID;

                    info.usp_cRoleID = role.rlm_cRoleID;

                    info.usp_cAdd = this.UserInformation.usm_cUserLoginID;

                    info.usp_cLast = this.UserInformation.usm_cUserLoginID;

                    saveList.Add(info);
                }
            }

            try
            {
                ReturnValueInfo returnInfo = this._IUserPurviewBL.SavePruview(saveList, objID, saveTypeID);

                if (returnInfo.boolValue)
                {
                    ShowInformationMessage(DefineConstantValue.SystemMessageText.strMessageText_I_SaveSuccess);

                    gbFormTree.Enabled = false;

                    gbxUserAndRole.Enabled = true;

                    btnSaveFormRight.Enabled = false;

                    btnCancelFormRight.Enabled = false;

                    btnSetRight.Enabled = true;
                }
                else
                {
                    ShowErrorMessage(returnInfo.messageText);
                }
            }
            catch (Exception Ex)
            {

                ShowErrorMessage(Ex.Message);
            }
            this._EditStatus = DefineConstantValue.EditStateEnum.OE_ReaOnly;
        }

        private void HandelFormRight(TreeNode node, List<Sys_FormMaster_fom_Info> objList)
        {
            if (node.Checked)
            {
                Sys_FormMaster_fom_Info info = new Sys_FormMaster_fom_Info();

                info.fom_iRecordID = Convert.ToInt32(node.Name);

                objList.Add(info);
            }

            if (node.Nodes != null && node.Nodes.Count > 0)
            {
                foreach (TreeNode item in node.Nodes)
                {
                    HandelFormRight(item, objList);
                }
            }
        }

        private void btnCancelFormRight_Click(object sender, EventArgs e)
        {
            gbxUserAndRole.Enabled = true;

            gbFormTree.Enabled = false;

            btnSetRight.Enabled = true;

            btnSaveFormRight.Enabled = false;

            btnCancelFormRight.Enabled = false;

            this._EditStatus = DefineConstantValue.EditStateEnum.OE_ReaOnly;
        }
    }
}
