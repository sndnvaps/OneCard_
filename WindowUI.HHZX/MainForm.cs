using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using Model.Base;
using Model.IModel;
using Common;
using BLL.Base;
using WindowUI.HHZX.ClassLibrary.Public;
using WeifenLuo.WinFormsUI.Docking;
using Model.SysMaster;
using WindowUI.HHZX.Report;
using Model.HHZX.UserInfomation;
using WindowUI.HHZX.SystemSettings;
using WindowUI.HHZX.UserCard;
using WindowUI.HHZX.UserCard.Recharge;
using WindowUI.HHZX.UserCard.Refund;
using Model.HHZX.UserInfomation.CardUserInfo;
using WindowUI.HHZX.ConsumerDevice;
using BLL.IBLL.SysMaster;
using BLL.Factory.SysMaster;
using BLL.IBLL.HHZX.MealBooking;
using Model.HHZX.MealBooking;
using BLL.IBLL.HHZX.ConsumerDevice;
using Model.HHZX.ConsumerDevice;
using PaymentEquipment.IDevice;
using PaymentEquipment.DeviceFactory;
using System.Net;
using Model.General;

namespace WindowUI.HHZX
{
    /*
     * 注意：设计界面中的菜单栏，除【文件】栏外已改为从窗体主档中自动获取生成。Donald
     */
    /// <summary>
    /// 主窗体
    /// </summary>
    public partial class MainForm : BaseForm
    {
        #region 自定义变量

        private DefineConstantValue.SystemMessage _systemMessageText;
        public static DockMenu DockMenu;
        public List<IModelObject> _formFunctionList;
        private bool _isLogin;
        private LoginForm _LoginForm;
        private Sys_UserMaster_usm_Info _usm;
        private System.Windows.Forms.Timer _tmrDisplayTime;
        //private System.Windows.Forms.Timer _tmrRefreshStatus;
        private delegate void StatusBarRefresh(bool isStart);
        private event StatusBarRefresh OnStatusBarChanged;
        /// <summary>
        /// 后台处理挂失\解挂黑名单的时钟
        /// </summary>
        private System.Timers.Timer _tmrBlacklistHandler;
        private IBlacklistChangeRecordBL _IBlacklistChangeRecordBL;
        private IConsumeMachineBL _IConsumeMachineBL;
        private bool _IsOptBlacklist;

        #endregion

        public MainForm()
        {
            InitializeComponent();

            this._systemMessageText = new DefineConstantValue.SystemMessage(string.Empty);
            this._isLogin = false;

            this._tmrDisplayTime = new Timer();
            this._tmrDisplayTime.Interval = 1000;
            this._tmrDisplayTime.Tick += new EventHandler(_tmrDisplayTime_Tick);
            this._tmrDisplayTime.Enabled = true;

            this._IBlacklistChangeRecordBL = BLL.Factory.HHZX.MasterBLLFactory.GetBLL<IBlacklistChangeRecordBL>(BLL.Factory.HHZX.MasterBLLFactory.BlacklistChangeRecord);
            this._IConsumeMachineBL = BLL.Factory.HHZX.MasterBLLFactory.GetBLL<IConsumeMachineBL>(BLL.Factory.HHZX.MasterBLLFactory.ConsumeMachine);

            OnStatusBarChanged += new StatusBarRefresh(MainForm_OnStatusBarChanged);

            this.BaseDockPanel = this.dpnlContainer;

            this._LoginForm = new LoginForm();

            Cursor.Current = Cursors.WaitCursor;

            Cursor.Current = Cursors.Arrow;
        }

        /// <summary>
        /// 绑定菜单栏
        /// </summary>
        void BindMenuItems()
        {
            Sys_FormMaster_fom_Info info = new Sys_FormMaster_fom_Info();
            ISysFormMasterBL _ISysFormMasterBL = MasterBLLFactory.GetBLL<ISysFormMasterBL>(MasterBLLFactory.SysFormMaster);
            Sys_UserMaster_usm_Info user = this.UserInformation;
            List<Sys_FormMaster_fom_Info> listObjForms = _ISysFormMasterBL.GetUserMenu(info, user);
            List<Sys_FormMaster_fom_Info> listForms = new List<Sys_FormMaster_fom_Info>();
            foreach (Sys_FormMaster_fom_Info item in listObjForms)
            {
                if (item != null)
                {
                    listForms.Add(item);
                }
            }

            Sys_FormMaster_fom_Info ParentFormInfo = listForms.Find(x => x.fom_iParentID == -1);
            if (ParentFormInfo == null)
            {
                return;
            }

            ClearMenuItem();

            bool isException = false;
            if (this.UserInformation != null)
            {
                if (this.UserInformation.usm_cUserLoginID == "sa")
                {
                    isException = true;
                }
            }
            GetMenuItems(TopMenu.MenuItems, listForms, ParentFormInfo.fom_iRecordID, isException);

            SetSystemMenu();
        }

        /// <summary>
        /// 清除菜单栏
        /// </summary>
        void ClearMenuItem()
        {
            MenuItem menuBegin = TopMenu.MenuItems[0];
            TopMenu.MenuItems.Clear();
            TopMenu.MenuItems.Add(menuBegin);
        }

        /// <summary>
        /// 设置系统菜单，帮助、关于
        /// </summary>
        void SetSystemMenu()
        {
            MenuItem menu = new MenuItem();
            menu.Name = "menu" + Guid.NewGuid().ToString();
            menu.Text = "帮助(&A)";
            //menu.Tag = formItem.fom_cExePath;

            MenuItem about = new MenuItem();
            about.Name = "menu" + Guid.NewGuid().ToString();
            about.Text = "关于(&A)";

            Sys_FormMaster_fom_Info aboutInfo = new Sys_FormMaster_fom_Info();
            aboutInfo.fom_cExePath = "WindowUI.HHZX.AboutForm";
            aboutInfo.fom_lIsPopForm = true;
            about.Tag = aboutInfo;
            about.Click += new EventHandler(menuForm_Click);
            menu.MenuItems.Add(about);

            TopMenu.MenuItems.Add(menu);
        }

        void GetMenuItems(System.Windows.Forms.Menu.MenuItemCollection ParentItemList, List<Sys_FormMaster_fom_Info> listForms, int iParentID, bool isException)
        {
            if (ParentItemList == null)
            {
                return;
            }
            if (listForms == null)
            {
                return;
            }
            List<Sys_FormMaster_fom_Info> listSubForms = listForms.Where(x => x.fom_iParentID == iParentID).ToList();
            if (listSubForms == null)
            {
                return;
            }
            if (listSubForms.Count < 1)
            {
                return;
            }

            foreach (Sys_FormMaster_fom_Info formItem in listSubForms)
            {
                if (formItem == null)
                {
                    continue;
                }
                MenuItem menu = new MenuItem();
                menu.Name = "menu" + formItem.fom_iRecordID.ToString();
                menu.Text = formItem.fom_cFormDesc;
                //menu.Tag = formItem.fom_cExePath;
                menu.Tag = formItem;
                menu.Enabled = isException == true ? isException : formItem.isEnable;

                if (!string.IsNullOrEmpty(formItem.fom_cExePath))
                {
                    menu.Click += new EventHandler(menuForm_Click);
                }

                if (formItem.fom_cShortCut != Shortcut.None.ToString() && !string.IsNullOrEmpty(formItem.fom_cShortCut))
                {
                    Shortcut vShortcut = (Shortcut)TypeDescriptor.GetConverter(typeof(Keys)).ConvertFromString(formItem.fom_cShortCut);
                    menu.Shortcut = vShortcut;
                    menu.ShowShortcut = true;
                }

                if (formItem.fom_lIsPreOpen)
                {
                    menuForm_Click(menu, null);
                }

                GetMenuItems(menu.MenuItems, listForms, formItem.fom_iRecordID, isException);

                ParentItemList.Add(menu);

            }
        }

        void MainForm_OnStatusBarChanged(bool isStart)
        {
            if (isStart)
            {
                this.Cursor = Cursors.WaitCursor;
                //this._tmrRefreshStatus.Enabled = true;
                this.tssProgressBar.Visible = true;
            }
            else
            {
                //this._tmrRefreshStatus.Enabled = false;
                this.tssProgressBar.Value = 100;
                this.tssProgressBar.Visible = false;
                this.Cursor = Cursors.Default;
            }
        }

        void _tmrDisplayTime_Tick(object sender, EventArgs e)
        {
            this.tssLabTimeDisplay.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        /// <summary>
        /// 初始化系統數據
        /// </summary>
        private void LoadSystemData()
        {
            if (this._usm != null)
            {
                BindMenuItems();
                this.tssLabUserName.Text = _usm.usm_cUserLoginID;
            }
        }

        private void meuCodeMstr_Click(object sender, EventArgs e) { }

        private void meuExit_Click(object sender, EventArgs e)
        {
            if (ShowQuestionMessage(this._systemMessageText.strMessageText_Q_ExitApplication))
            {
                this.Dispose();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ShowLoginFrm();

            this.tssLabVersion.Text = " Ver:" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            if (!this.ShowQuestionMessage("是否确定注销？"))
            {
                return;
            }

            this._isLogin = false;
            this.Visible = false;

            int iNum = this.dpnlContainer.Contents.Count;
            while (iNum >= 1)
            {
                var panel = this.dpnlContainer.Contents[iNum - 1];
                if (panel.DockHandler.DockState != DockState.DockBottom)
                {
                    panel.DockHandler.Form.Close();
                    iNum = this.dpnlContainer.Contents.Count;
                }
            }

            _LoginForm = new LoginForm();
            ShowLoginFrm();
        }

        private void ShowLoginFrm()
        {
            this.Visible = false;
            _usm = new Sys_UserMaster_usm_Info();
            _LoginForm.ShowDialog();
            if (_LoginForm._login)
            {
                this.Show();
                this._isLogin = true;
                this.UserInformation = _LoginForm._userInfo;
                this._formFunctionList = _LoginForm.userObjs;
            }
            else
            {
                this.Close();
                return;
            }

            _usm = _LoginForm._userInfo;

            LoadSystemData();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this._isLogin)
            {
                if (MessageBox.Show(this._systemMessageText.strMessageText_Q_ExitApplication, this._systemMessageText.strMessageTitle + this._systemMessageText.strQuestion.Trim(), MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        private void menuForm_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                Sys_FormMaster_fom_Info tagInfo = (sender as MenuItem).Tag as Sys_FormMaster_fom_Info;
                if (tagInfo != null)
                {
                    if (tagInfo.fom_lIsPopForm)
                    {
                        base.ShowShellForm(tagInfo.fom_cExePath);
                    }
                    else
                    {
                        base.ShowSubForm(sender, this.dpnlContainer);
                    }
                }
            }
            catch (Exception ex)
            {
                this.ShowErrorMessage(ex);
            }

            this.Cursor = Cursors.Default;
        }
    }
}
