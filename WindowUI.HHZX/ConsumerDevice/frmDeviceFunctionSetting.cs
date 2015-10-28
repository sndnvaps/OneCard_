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
using System.Net;
using PaymentEquipment.DeviceImplement;
using PaymentEquipment.Enum;
using WindowUI.HHZX.ClassLibrary.Public;
using Model.IModel;
using Model.HHZX.ConsumerDevice;
using PaymentEquipment.Entity;

namespace WindowUI.HHZX.ConsumerDevice
{
    /// <summary>
    /// 消费机功能设置
    /// </summary>
    public partial class frmDeviceFunctionSetting : BaseForm
    {
        /// <summary>
        /// 当前使用的消费机资料（如需针对一台消费机设置，则需要在打开窗口之前传入该值）
        /// </summary>
        private ConsumeMachineMaster_cmm_Info _MachineInfo;

        private AbstractPayDevice _CurrentDevice;

        public frmDeviceFunctionSetting()
        {
            InitializeComponent();
        }

        public frmDeviceFunctionSetting(ConsumeMachineMaster_cmm_Info _info)
        {
            InitializeComponent();
            _MachineInfo = _info;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            BindComboDeviceMode();

            if (_MachineInfo != null)
            {
                tbxIPAddr.Text = _MachineInfo.cmm_cIPAddr;
                tbxIPAddr.Enabled = false;
                tbxPort.Text = _MachineInfo.cmm_iPort.ToString();
                tbxPort.Enabled = false;
                tbxMacNo.Text = _MachineInfo.cmm_iMacNo.ToString();
                tbxMacNo.Enabled = false;
            }
        }

        private void btnDeviceConnnTest_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbxIPAddr.Text))
            {
                this.ShowWarningMessage("请输入设备IP地址。");
                tbxIPAddr.Focus();
                return;
            }
            try
            {
                bool res = Common.General.Ping(tbxIPAddr.Text.Trim());
                if (res)
                {
                    this.ShowInformationMessage("设备在线中。");
                }
                else
                {
                    this.ShowWarningMessage("设备离线。");
                }
            }
            catch (Exception ex)
            {
                this.ShowErrorMessage(ex);
                tbxIPAddr.Focus();
                return;
            }
        }

        private void btnConn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbxIPAddr.Text.Trim()))
            {
                this.ShowWarningMessage("请输入设备IP地址。");
                tbxIPAddr.Focus();
                return;
            }
            if (string.IsNullOrEmpty(tbxPort.Text.Trim()))
            {
                this.ShowWarningMessage("请输入设备端口号。");
                tbxPort.Focus();
                return;
            }
            if (string.IsNullOrEmpty(tbxMacNo.Text.Trim()))
            {
                this.ShowWarningMessage("请输入设备机号。");
                tbxMacNo.Focus();
                return;
            }

            IPAddress IPAddr = IPAddress.Parse(tbxIPAddr.Text.Trim());
            if (IPAddr == null)
            {
                this.ShowWarningMessage("请检查IP地址的格式。");
                tbxIPAddr.Focus();
                return;
            }

            int iPort;
            bool res = int.TryParse(tbxPort.Text.Trim(), out iPort);
            if (!res)
            {
                this.ShowWarningMessage("请输入检查设备端口号的格式。");
                tbxPort.Focus();
                return;
            }

            int iMacNo;
            res = int.TryParse(tbxMacNo.Text.Trim(), out iMacNo);
            if (!res)
            {
                this.ShowWarningMessage("请输入检查设备机号的格式。");
                tbxMacNo.Focus();
                return;
            }

            this.Cursor = Cursors.WaitCursor;

            this._CurrentDevice = PaymentDeviceFactory.CreateDevice(PaymentDeviceFactory.EastRiverDevice);
            ReturnValueInfo rvInfo = this._CurrentDevice.Conn(IPAddr, iPort, iMacNo);

            if (rvInfo.boolValue && !rvInfo.isError)
            {
                this.ShowInformationMessage("设备连接成功。");
                gbxMacOpt.Enabled = true;
            }
            else
            {
                this.ShowWarningMessage("设备连接失败。异常：" + rvInfo.messageText);
            }

            this.Cursor = Cursors.Default;
        }

        private void btnDisConn_Click(object sender, EventArgs e)
        {
            if (this._CurrentDevice != null)
            {
                ReturnValueInfo rvInfo = this._CurrentDevice.DisConn();
                if (rvInfo.boolValue && !rvInfo.isError)
                {
                    this.ShowInformationMessage("设备断开成功。");
                    gbxMacOpt.Enabled = false;
                }
                else
                {
                    this.ShowWarningMessage("设备断开失败。异常：" + rvInfo.messageText);
                }
            }
            else
            {
                this.ShowWarningMessage("设备未被初始化，请重新连接。");
                btnConn.Focus();
            }
        }

        private void btnGetMacTime_Click(object sender, EventArgs e)
        {
            DateTime? dtTime = this._CurrentDevice.GetDeviceTime();
            if (dtTime != null)
            {
                labMacTIme.Text = dtTime.Value.ToString();
            }
        }

        private void btnAdjustMacTime_Click(object sender, EventArgs e)
        {
            ReturnValueInfo rvInfo = this._CurrentDevice.SyncDeviceTime();
            if (rvInfo.boolValue && !rvInfo.isError)
            {
                this.ShowInformationMessage("同步设备时间成功。");
            }
            else
            {
                this.ShowWarningMessage("同步设备时间失败。异常：" + rvInfo.messageText);
            }
        }

        private void btnReadRepeatTime_Click(object sender, EventArgs e)
        {
            try
            {
                int iInterval = this._CurrentDevice.GetReadCardInterval();
                if (iInterval > -1)
                {
                    tbxReadCardInterval.Text = iInterval.ToString();
                }
                else
                {
                    this.ShowWarningMessage("获取重复刷卡时间间隔失败，请重试");
                }
            }
            catch (Exception ex)
            {
                this.ShowWarningMessage("获取重复刷卡时间间隔失败，请重试。异常：" + ex.Message);
            }
        }

        private void btnSetRepeatTime_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbxReadCardInterval.Text.Trim()))
            {
                this.ShowWarningMessage("请输入时间间隔值。");
                tbxReadCardInterval.Focus();
                return;
            }

            int iInterval;
            bool res = int.TryParse(tbxReadCardInterval.Text.Trim(), out iInterval);
            if (!res)
            {
                this.ShowWarningMessage("请检查时间间隔值的格式。");
                tbxReadCardInterval.Focus();
                return;
            }
            if (iInterval < 0 || iInterval > 99)
            {
                this.ShowWarningMessage("时间间隔值超出范围，请输入0~99内整数值。");
                tbxReadCardInterval.Focus();
                return;
            }

            ReturnValueInfo rvInfo = this._CurrentDevice.SetReadCardInterval(iInterval);
            if (rvInfo.boolValue && !rvInfo.isError)
            {
                this.ShowInformationMessage("设置重复刷卡时间间隔值成功。");
            }
            else
            {
                this.ShowWarningMessage("设置重复刷卡时间间隔值失败。异常" + rvInfo.messageText);
            }
        }

        private void btnReadDeviceMode_Click(object sender, EventArgs e)
        {
            try
            {
                EnumDeviceMode mode = this._CurrentDevice.ReadDeviceMode();
                GeneralTools.ExchangeComboValue(((int)mode).ToString(), cbxDeviceMode);
            }
            catch (Exception ex)
            {
                this.ShowWarningMessage("获取消费机工作模式失败。异常：" + ex.Message);
            }
        }

        /// <summary>
        /// 绑定消费机模式值
        /// </summary>
        void BindComboDeviceMode()
        {
            List<IModelObject> listValues = new List<IModelObject>();

            foreach (EnumDeviceMode item in Enum.GetValues(typeof(EnumDeviceMode)))
            {
                if (item != EnumDeviceMode.Unknown)
                {
                    ComboboxDataInfo value = new ComboboxDataInfo();
                    value.ValueMember = ((int)item).ToString();
                    value.DisplayMember = EumExchangeTool.GetEumModeName(item);
                    listValues.Add(value);
                }
            }

            cbxDeviceMode.SetDataSource(listValues);
            cbxDeviceMode.SelectedIndex = -1;
        }

        private void btnSetDeviceMode_Click(object sender, EventArgs e)
        {
            if (cbxDeviceMode.SelectedIndex > -1 && !string.IsNullOrEmpty(cbxDeviceMode.Text))
            {
                EnumDeviceMode mode = (EnumDeviceMode)Convert.ToInt32(cbxDeviceMode.SelectedValue);
                ReturnValueInfo res = this._CurrentDevice.SetDeviceMode(mode);
                if (res.boolValue && !res.isError)
                {
                    this.ShowInformationMessage("设置消费机工作模式成功，当前模式：" + cbxDeviceMode.Text);
                }
                else
                {
                    this.ShowWarningMessage("设置消费机工作模式失败。异常：" + res.messageText);
                }
            }
        }

        private void btnSetDayConsumeLimit_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(tbxDayConsumeLimit.Text))
                {
                    this.ShowWarningMessage("请输入每日消费限额值。");
                    tbxDayConsumeLimit.Focus();
                    return;
                }

                decimal dLimit;
                bool res = decimal.TryParse(tbxDayConsumeLimit.Text.Trim(), out dLimit);
                if (res)
                {
                    ReturnValueInfo rvInfo = this._CurrentDevice.SetDayConsumeLimit(dLimit);
                    if (rvInfo.boolValue && !rvInfo.isError)
                    {
                        this.ShowInformationMessage("设置每日消费限额值成功，限额值为：" + dLimit.ToString());
                    }
                    else
                    {
                        this.ShowInformationMessage("设置每日消费限额值失败。");
                        tbxDayConsumeLimit.Focus();
                        return;
                    }
                }
                else
                {
                    this.ShowWarningMessage("请检查每日消费限额值的格式。");
                    tbxDayConsumeLimit.Focus();
                    return;
                }
            }
            catch (Exception ex)
            {
                this.ShowErrorMessage(ex);
                tbxDayConsumeLimit.Focus();
            }
        }

        private void btnReadDayConsumeLimit_Click(object sender, EventArgs e)
        {
            try
            {
                decimal dLimit = this._CurrentDevice.GetDayConsumeLimit();
                if (dLimit > -1)
                {
                    tbxDayConsumeLimit.Text = dLimit.ToString();
                }
                else
                {
                    this.ShowWarningMessage("获取日消费限额值失败。");
                }
            }
            catch (Exception ex)
            {
                this.ShowErrorMessage(ex);
            }
        }

        private void btnReadPerConsumeLimit_Click(object sender, EventArgs e)
        {
            try
            {
                decimal dLimit = this._CurrentDevice.GetPerConsumeLimit();
                if (dLimit > -1)
                {
                    tbxPerConsumeLimit.Text = dLimit.ToString();
                }
                else
                {
                    this.ShowWarningMessage("获取每次消费限额值失败。");
                }
            }
            catch (Exception ex)
            {
                this.ShowErrorMessage(ex);
            }
        }

        private void btnSetPerConsumeLimit_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(tbxPerConsumeLimit.Text))
                {
                    this.ShowWarningMessage("请输入每次消费限额值。");
                    tbxPerConsumeLimit.Focus();
                    return;
                }

                decimal dLimit;
                bool res = decimal.TryParse(tbxPerConsumeLimit.Text.Trim(), out dLimit);
                if (res)
                {
                    ReturnValueInfo rvInfo = this._CurrentDevice.SetPerConsumeLimit(dLimit);
                    if (rvInfo.boolValue && !rvInfo.isError)
                    {
                        this.ShowInformationMessage("设置每次消费限额值成功，限额值为：" + dLimit.ToString());
                    }
                    else
                    {
                        this.ShowInformationMessage("设置每次消费限额值失败。");
                        tbxPerConsumeLimit.Focus();
                        return;
                    }
                }
                else
                {
                    this.ShowWarningMessage("请检查每次消费限额值的格式。");
                    tbxPerConsumeLimit.Focus();
                    return;
                }
            }
            catch (Exception ex)
            {
                this.ShowErrorMessage(ex);
                tbxDayConsumeLimit.Focus();
            }
        }

        private void btnSetNewMacNo_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(tbxNewMacNo.Text.Trim()))
                {
                    this.ShowWarningMessage("请输入新机号。");
                    tbxNewMacNo.Focus();
                    return;
                }

                int iMacNo;
                bool res = int.TryParse(tbxNewMacNo.Text.Trim(), out iMacNo);
                if (res)
                {
                    ReturnValueInfo rvInfo = this._CurrentDevice.SetDeviceNo(iMacNo);
                    if (rvInfo.boolValue && !rvInfo.isError)
                    {
                        this.ShowInformationMessage("设置新机号成功。新机号为：" + iMacNo.ToString());
                        tbxMacNo.Text = tbxNewMacNo.Text;
                        tbxNewMacNo.Text = string.Empty;
                        btnDisConn_Click(null, null);
                    }
                    else
                    {
                        this.ShowWarningMessage("设置新机号失败。" + rvInfo.messageText);
                    }
                }
                else
                {
                    this.ShowWarningMessage("请检查新机号的格式。");
                    tbxNewMacNo.Focus();
                    return;
                }
            }
            catch (Exception ex)
            {
                this.ShowErrorMessage(ex);
                tbxNewMacNo.Focus();
            }
        }

        private void btnClearBL_Click(object sender, EventArgs e)
        {
            ReturnValueInfo rvInfo = this._CurrentDevice.RemoveAllBlacklist();
            if (rvInfo.boolValue && !rvInfo.isError)
            {
                this.ShowInformationMessage("清除黑名单成功。");
            }
            else
            {
                this.ShowWarningMessage("清除黑名单失败。" + rvInfo.messageText);
                btnClearBL.Focus();
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            if (this._CurrentDevice != null)
            {
                this._CurrentDevice.DisConn();
            }

            base.OnClosed(e);
        }

        private void btnReadTimeSpan_Click(object sender, EventArgs e)
        {
            this._CurrentDevice.GetMacTimeSpan();
        }

        private void btnSetTimeSpan_Click(object sender, EventArgs e)
        {
            if (this.rdbConsumeTime.Checked)
            {
                ConsumeTimeSpan cts = new ConsumeTimeSpan();
                cts.BeginTime = TimeSpan.Parse(txtStartTime1.Text);
                cts.EndTime = TimeSpan.Parse(txtEndTime1.Text);
                cts.SetMoney = decimal.Parse(txtCost1.Text);
                cts.LimitedTimes = Int32.Parse(txtTimes1.Text);

                List<ConsumeTimeSpan> list = new List<ConsumeTimeSpan>();
                list.Add(cts);
                this._CurrentDevice.SetMacTimeSpan(list);
                this._CurrentDevice.SetConsumetimeParam(1, 0);
            }
            else
            {
                this._CurrentDevice.SetConsumetimeParam(0, 1);
            }

        }

        private void rdbConsumeTime_CheckedChanged(object sender, EventArgs e)
        {
            this.gpbConsumeTime.Enabled = true;
        }

        private void rdbConsumeFeel_CheckedChanged(object sender, EventArgs e)
        {
            this.gpbConsumeTime.Enabled = false;
        }

        private void btnAddSingleWhite_Click(object sender, EventArgs e)
        {
            ReturnValueInfo rvInfo = this._CurrentDevice.AddWhitelist(tbxWhiteCardNo.Text);
            if (rvInfo.boolValue && !rvInfo.isError)
            {
                this.ShowInformationMessage("添加白名单成功。");
            }
            else
            {
                this.ShowWarningMessage("添加白名单失败。" + rvInfo.messageText);
                btnAddSingleWhite.Focus();
            }
        }

        private void btnDeleteSingleWhite_Click(object sender, EventArgs e)
        {
            ReturnValueInfo rvInfo = this._CurrentDevice.RemoveWhitelist(tbxWhiteCardNo.Text);
            if (rvInfo.boolValue && !rvInfo.isError)
            {
                this.ShowInformationMessage("删除白名单成功。");
            }
            else
            {
                this.ShowWarningMessage("删除白名单失败。" + rvInfo.messageText);
                btnDeleteSingleWhite.Focus();
            }
        }

        private void btnDeleteAllBlack_Click(object sender, EventArgs e)
        {
            ReturnValueInfo rvInfo = this._CurrentDevice.RemoveAllWhitelist();
            if (rvInfo.boolValue && !rvInfo.isError)
            {
                this.ShowInformationMessage("删除所有白名单成功。");
            }
            else
            {
                this.ShowWarningMessage("删除所有白名单失败。" + rvInfo.messageText);
                btnDeleteAllBlack.Focus();
            }
        }
    }
}
