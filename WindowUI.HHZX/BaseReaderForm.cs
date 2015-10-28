using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PaymentEquipment.IDevice;
using PaymentEquipment.DeviceFactory;
using Model.General;
using PaymentEquipment.Entity;
using Model.HHZX.UserInfomation.CardUserInfo;
using UKey;
using System.Configuration;

namespace WindowUI.HHZX
{
    public partial class BaseReaderForm : BaseForm
    {
        /// <summary>
        /// 卡资料所在卡片扇区号
        /// </summary>
        protected short _CardInfoSection;
        /// <summary>
        /// 扇区密码
        /// </summary>
        protected string _SectionPwd;
        /// <summary>
        /// 消费密码
        /// </summary>
        protected string _PayPwd;
        /// <summary>
        /// 当前卡用户信息
        /// </summary>
        protected CardUserMaster_cus_Info _CurrentCardUserInfo;
        /// <summary>
        /// 当前卡信息缓存
        /// </summary>
        protected ConsumeCardInfo _CurrentCardInfo;
        /// <summary>
        /// 读写器
        /// </summary>
        protected AbstractReader _Reader;
        /// <summary>
        /// 是否通讯中
        /// </summary>
        protected bool _IsConnected;

        protected readonly string _OrganizeSectionPwd = string.Empty.PadLeft(12, 'F');

        public BaseReaderForm()
        {
            InitializeComponent();

            this._IsConnected = false;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            try
            {
                InitReader();
            }
            catch (Exception ex)
            {
                base.ShowWarningMessage("读写器连接不成功，请尝试重新连接。" + ex.Message);
            }

            this._CardInfoSection = 1;
            this._PayPwd = ConfigurationSettings.AppSettings["PaymentPwd"];
            if (string.IsNullOrEmpty(this._PayPwd))
            {
                this._PayPwd = "654321";
            }
        }

        protected bool CheckUKey()
        {
            AbstractUKey uKey = UKeyFactory.GetUKey();
            var rvInfo = uKey.ReadPassword();
            if (rvInfo.IsSuccess)
            {
                this._SectionPwd = rvInfo.MessageText.ToUpper();
                return true;
            }
            else
            {
                this.ShowWarningMessage("没有找到可用的U盾，无法正常进行下一步操作。");
                this._SectionPwd = string.Empty;
                return false;
            }
        }

        /// <summary>
        /// 初始化读写器
        /// </summary>
        protected void InitReader()
        {
            if (this._IsConnected)
            {
                return;
            }
            this._Reader = PaymentReaderFactory.CreateWriter(PaymentReaderFactory.EastRiverReader906);

            ReturnValueInfo rvInfo = this._Reader.Conn();
            if (rvInfo.boolValue && !rvInfo.isError)
            {
                this._IsConnected = true;
            }
        }

        /// <summary>
        /// 用于显示读写器的连接状态及重置状态的点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void labReaderState_Click(object sender, EventArgs e)
        {
            if (!this._IsConnected)
            {
                Label labSource = sender as Label;
                InitReader();
                ReturnValueInfo rvInfo = this._Reader.Conn();
                if (rvInfo.boolValue && !rvInfo.isError)
                {
                    labSource.Text = "读卡器已连接";
                }
                else
                {
                    labSource.Text = "读卡器未连接";
                }
            }
        }

        /// <summary>
        /// 用于显示读写器的连接状态及重置状态的点击事件（按鈕）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnReaderState_Click(object sender, EventArgs e)
        {
            if (!this._IsConnected)
            {
                Button btnSource = sender as Button;
                btnSource.BackColor = Color.Yellow;
                btnSource.Text = "开始连接";

                InitReader();
                ReturnValueInfo rvInfo = this._Reader.Conn();
                if (rvInfo.boolValue && !rvInfo.isError)
                {
                    btnSource.Text = "读卡器已连接";
                    btnSource.BackColor = Color.Blue;
                    btnSource.ForeColor = Color.White;
                    this._IsConnected = true;
                }
                else
                {
                    btnSource.Text = "读卡器未连接";
                    btnSource.BackColor = Color.Red;
                    this._IsConnected = false;
                }
            }
        }


        protected override void OnClosing(CancelEventArgs e)
        {
            //if (this._Reader != null)
            //{
            //    this._Reader.DisConn();
            //}

            base.OnClosing(e);
        }
    }
}
