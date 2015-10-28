#define M_DEBUG

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Model.IModel;
using WindowUI.HHZX.ClassLibrary.Public;
using Model.General;
using Common;
using Common.DataTypeVerify;
using Model.SysMaster;
using BLL.IBLL.SysMaster;
using BLL.Factory.SysMaster;
using BLL.IBLL.General;
using BLL.Factory.General;
using Model.HHZX.UserInfomation;
using System.Configuration;
using System.Reflection;

namespace WindowUI.HHZX
{
    public partial class LoginForm : BaseForm
    {
        //IUserSkinBL _userSkinBL;
        IGeneralBL _generalBL;
        ILoginFormBL _loginForm;
        public Sys_UserMaster_usm_Info _userInfo;
        public List<IModelObject> userObjs = new List<IModelObject>();
        public bool _login = false;
        public bool isMove = false;
        Point _oldPosition = new Point();
        int dLfet;

        public LoginForm()
        {
            InitializeComponent();
            this._loginForm = MasterBLLFactory.GetBLL<ILoginFormBL>(MasterBLLFactory.LoginForm);
            this._generalBL = GeneralBLLFactory.GetBLL<IGeneralBL>(GeneralBLLFactory.General);

            this.txtUserName.Text = System.Configuration.ConfigurationManager.AppSettings["LastLoginName"];

            CheckFocus();

#if M_DEBUG

            //txtUserName.Text = "sa";
            //txtPwd.Text = DateTime.Now.ToString("yyyy,MM,dd");

            //txtUserName.Text = "donaldhuang";
            //txtPwd.Text = "!!!aaa111";

            
#endif
           
        }

        private void ShowFrom()
        {
            this.Opacity = 0.1;
            dLfet = this.Left;
            this.Left += -40;
            timer1.Enabled = true;
            timer2.Enabled = true;
        }

        private void CheckFocus()
        {
            if (String.IsNullOrEmpty(this.txtUserName.Text))
            {
                this.txtPwd.TabIndex = 1;
                this.txtUserName.TabIndex = 0;
            }
            else
            {
                this.txtPwd.TabIndex = 0;
                this.txtUserName.TabIndex = 1;
            }
        }

        /// <summary>
        /// 检查登陆名，如果与上次不同，则保留最新登陆名
        /// </summary>
        private void CheckLoginName()
        {
            String oldName = System.Configuration.ConfigurationManager.AppSettings["LastLoginName"];

            if (!this.txtUserName.Text.Trim().Equals(oldName))
            {
                //读取程序集的配置文件

                string assemblyConfigFile = Assembly.GetEntryAssembly().Location;
                string appDomainConfigFile = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile;

                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                //获取appSettings节点
                AppSettingsSection appSettings = (AppSettingsSection)config.GetSection("appSettings");
                //删除name，然后添加新值
                appSettings.Settings.Remove("LastLoginName");
                appSettings.Settings.Add("LastLoginName", this.txtUserName.Text.Trim());

                //保存配置文件
                config.Save();
            }
        }

        private void BindCombox(DefineConstantValue.MasterType mType)
        {
            List<IModelObject> result = new List<IModelObject>();
            try
            {
                result = _generalBL.GetMasterDataInformations(mType);
            }
            catch (Exception Ex)
            {
                MessageBox.Show("网络连接错误，请检查网络！詳細信息：" + Ex.Message);
            }
            cbxSkin.SetDataSource(result);
            cbxSkin.SelectedValue = string.Empty;
        }

        private void cbxSkin_SelectedValueChanged(object sender, EventArgs e) { }

        private void UserSkin()
        {
            if (cbxSkin.SelectedValue != null)
            {
                skin.SkinFile = Application.StartupPath + "\\" + cbxSkin.SelectedValue.ToString();
                if (!string.IsNullOrEmpty(cbxSkin.SelectedValue.ToString()))
                {
                    skin.Active = true;
                }
                else
                {
                    skin.Active = false;
                }
            }
        }


        private void txtUserName_Leave(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Login();
            this.Cursor = Cursors.Default;
        }

        void Login()
        {
            Model.General.ReturnValueInfo msg = new Model.General.ReturnValueInfo();
            Sys_UserMaster_usm_Info userInfo = new Sys_UserMaster_usm_Info();
            userInfo.usm_cUserLoginID = txtUserName.Text;
            userInfo.usm_cPwd = txtPwd.Text;
            try
            {
                msg = _loginForm.Login(userInfo);
                if (msg.boolValue == true)
                {
                    userInfo = msg.ValueObject as Sys_UserMaster_usm_Info;

                    _userInfo = userInfo;
                    if (msg.messageText == null)
                    {
                        _login = true;
                        IModelObject obj = null;

                        foreach (Sys_FunctionMaster_fum_Info item in _userInfo.functionMasterList)
                        {
                            obj = item;
                            userObjs.Add(obj);
                        }
                        UserSkin();
                        this.DialogResult = DialogResult.OK;

                        //System.Configuration.ConfigurationManager.AppSettings["LastLoginName"]= userInfo.usm_cUserLoginID;

                        //System.Configuration.ConfigurationManager.AppSettings.Remove("LastLoginName");
                        //System.Configuration.ConfigurationManager.AppSettings.Add("LastLoginName", userInfo.usm_cUserLoginID);
                    }
                    else
                    {
                        ShowInformationMessage(msg.messageText);
                    }

                    CheckLoginName();
                }
                else
                {
                    txtPwd.Focus();
                    txtPwd.Text = string.Empty;
                    ShowInformationMessage(msg.messageText);
                }
            }
            catch (Exception Ex)
            {
                ShowErrorMessage(Ex);
            }
        }

        private void btnResert_Click(object sender, EventArgs e)
        {
            txtPwd.Text = string.Empty;
            txtUserName.Text = string.Empty;
        }

        private void LoginForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMove)
            {
                this.Left += Cursor.Position.X - _oldPosition.X;
                this.Top += Cursor.Position.Y - _oldPosition.Y;
                _oldPosition = Cursor.Position;
            }
        }

        private void LoginForm_MouseDown(object sender, MouseEventArgs e)
        {
            _oldPosition = Cursor.Position;
            isMove = true;
        }

        private void LoginForm_MouseUp(object sender, MouseEventArgs e)
        {
            isMove = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.Opacity <= 0.9)
            {
                this.Opacity += 0.07;
            }
            else
            {
                this.Opacity = 1;
                timer1.Enabled = false;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (this.Left < dLfet)
            {
                this.Left += 1;
            }
            else
            {
                this.Left = dLfet;
                timer2.Enabled = false;
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            ShowFrom();
        }

        private void txtPwd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnLogin_Click(sender, e);
            }
        }

        private void pbxExit_Click(object sender, EventArgs e)
        {
            bool res = base.ShowQuestionMessage("是否确认退出登录？");
            if (res)
            {
                this.Close();
            }
        }

        private void LoginForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (!e.Control && !e.Shift && !e.Alt)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnLogin_Click(null, null);
                }
                else if (e.KeyCode == Keys.Escape)
                {
                    pbxExit_Click(null, null);
                }
            }
        }
    }
}
