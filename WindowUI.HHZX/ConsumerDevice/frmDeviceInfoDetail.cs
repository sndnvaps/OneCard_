using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Model.General;
using Common;
using Model.HHZX.ConsumerDevice;
using BLL.IBLL.HHZX.ConsumerDevice;
using BLL.Factory.HHZX;
using WindowUI.HHZX.ClassLibrary.Public;
using PaymentEquipment.DeviceFactory;
using PaymentEquipment.IDevice;
using System.Net;
using PaymentEquipment.Enum;
using Model.IModel;

namespace WindowUI.HHZX.ConsumerDevice
{
    /// <summary>
    /// 消费机详细资料 查询/修改
    /// </summary>
    public partial class frmDeviceInfoDetail : BaseForm
    {
        private ConsumeMachineMaster_cmm_Info _info;
        private IConsumeMachineBL _icmBL;
        private DefineConstantValue.EditStateEnum _eduitType = DefineConstantValue.EditStateEnum.OE_Insert;

        private int _macNo;

        public frmDeviceInfoDetail()
        {
            InitializeComponent();
            initConsumeMachineType();
            initMachineStatus();

            _icmBL = MasterBLLFactory.GetBLL<IConsumeMachineBL>(MasterBLLFactory.ConsumeMachine);

            SetcontrolStatus(_eduitType);
        }

        public frmDeviceInfoDetail(ConsumeMachineMaster_cmm_Info info)
        {
            InitializeComponent();
            initConsumeMachineType();
            initMachineStatus();

            _icmBL = MasterBLLFactory.GetBLL<IConsumeMachineBL>(MasterBLLFactory.ConsumeMachine);
            _eduitType = DefineConstantValue.EditStateEnum.OE_Update;

            _macNo = info.cmm_iMacNo;
            this._info = info;
            SetControlValue();
            SetcontrolStatus(_eduitType);
        }

        private void initMachineStatus()
        {
            List<IModelObject> list = new List<IModelObject>();

            foreach (Common.DefineConstantValue.ConsumeMachineStatus usingType in Enum.GetValues(typeof(Common.DefineConstantValue.ConsumeMachineStatus)))
            {
                ComboboxDataInfo info = new ComboboxDataInfo();
                info.DisplayMember = DefineConstantValue.GetMacUsingDesc(usingType);
                info.ValueMember = usingType.ToString();
                list.Add(info);
            }

            this.cmbMachineStatus.SetDataSource(list);
            this.cmbMachineStatus.SelectedIndex = 0;
        }

        private void SetcontrolStatus(DefineConstantValue.EditStateEnum eduitType)
        {
            switch (eduitType)
            {
                case DefineConstantValue.EditStateEnum.OE_Insert:

                    break;
                case DefineConstantValue.EditStateEnum.OE_Update:
                    btnDetailSettings.Enabled = true;
                    break;
            }
        }

        private void SetControlValue()
        {
            if (_info != null)
            {
                this.txtDesc.Text = _info.cmm_cDesc;
                this.nudMacNo.Text = _info.cmm_iMacNo.ToString();
                this.txtIPAddr.Text = _info.cmm_cIPAddr;
                this.txtMacName.Text = _info.cmm_cMacName;
                this.nudPort.Text = _info.cmm_iPort.ToString();
                this.cmbType.SelectedValue = _info.cmm_cUsageType;
                this.cmbMachineStatus.SelectedValue = _info.cmm_cStatus;
            }
        }

        private ConsumeMachineMaster_cmm_Info GetControlValue()
        {
            if (_info == null)
            {
                _info = new ConsumeMachineMaster_cmm_Info();
            }

            _info.cmm_cDesc = this.txtDesc.Text;
            _info.cmm_cUsageType = this.cmbType.SelectedValue.ToString();
            _info.cmm_cStatus = this.cmbMachineStatus.SelectedValue.ToString();

            _info.cmm_lIsActive = true;

            if (!String.IsNullOrEmpty(this.nudMacNo.Text))
            {
                _info.cmm_iMacNo = Int32.Parse(this.nudMacNo.Text);
            }
            else
            {
                base.ShowErrorMessage("请输入机号。");
                return null;
            }

            if (!String.IsNullOrEmpty(this.nudPort.Text))
            {
                _info.cmm_iPort = Int32.Parse(this.nudPort.Text);
            }
            else
            {
                base.ShowErrorMessage("请输入端口。");
                return null;
            }

            if (!String.IsNullOrEmpty(this.txtIPAddr.Text))
            {
                _info.cmm_cIPAddr = this.txtIPAddr.Text;
            }
            else
            {
                base.ShowErrorMessage("请输入IP地址。");
                return null;
            }

            if (!String.IsNullOrEmpty(this.txtMacName.Text))
            {
                _info.cmm_cMacName = this.txtMacName.Text;
            }
            else
            {
                base.ShowErrorMessage("请输入机器名。");
                return null;
            }

            if (_eduitType == DefineConstantValue.EditStateEnum.OE_Insert)
            {
                _info.cmm_cAdd = this.UserInformation.usm_cUserLoginID;
                _info.cmm_cLast = this.UserInformation.usm_cUserLoginID;
            }
            else
            {
                _info.cmm_cLast = this.UserInformation.usm_cUserLoginID;
            }

            return _info;
        }

        private void initConsumeMachineType()
        {
            List<IModelObject> listValues = new List<IModelObject>();
            foreach (Common.DefineConstantValue.ConsumeMachineType item in Enum.GetValues(typeof(Common.DefineConstantValue.ConsumeMachineType)))
            {
                if (item != Common.DefineConstantValue.ConsumeMachineType.Unknown)
                {
                    ComboboxDataInfo value = new ComboboxDataInfo();
                    value.ValueMember = item.ToString();
                    value.DisplayMember = Common.DefineConstantValue.GetMacTypeDesc(item);
                    listValues.Add(value);
                }
            }

            cmbType.SetDataSource(listValues);
            cmbType.SelectedIndex = -1;
        }

        private void btnDetailSettings_Click(object sender, EventArgs e)
        {
            _info = GetControlValue();
            frmDeviceFunctionSetting frmSetting = new frmDeviceFunctionSetting(_info);
            frmSetting.ShowDialog();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ConsumeMachineMaster_cmm_Info ccmInfo = GetControlValue();

            if (ccmInfo == null)
            {
                return;
            }

            try
            {
                if (_macNo != ccmInfo.cmm_iMacNo)
                {
                    ConsumeMachineMaster_cmm_Info searchInfo = new ConsumeMachineMaster_cmm_Info();
                    searchInfo.cmm_iMacNo = ccmInfo.cmm_iMacNo;

                    List<ConsumeMachineMaster_cmm_Info> infoList = _icmBL.SearchRecords(searchInfo);
                    //检查机号是否已存在
                    if (infoList != null && infoList.Count > 0)
                    {
                        MessageBox.Show("机号：" + ccmInfo.cmm_iMacNo + "已使用，请不要输入重复机号。", "提示");
                        return;
                    }
                    else
                    {
                        _macNo = ccmInfo.cmm_iMacNo;
                    }
                }

                ReturnValueInfo rvInfoSave = _icmBL.Save(_info, _eduitType);
                if (rvInfoSave.isError || !rvInfoSave.boolValue)
                {
                    base.ShowErrorMessage("保存失败。");
                }
                else
                {
                    if (_eduitType == DefineConstantValue.EditStateEnum.OE_Insert)
                    {
                        base.ShowInformationMessage("保存成功，现在可以进行消费机参数设置。");
                        this.pnlEduit.Enabled = false;
                        this.btnDetailSettings.Enabled = true;
                        this.btnSave.Enabled = false;
                    }
                    else
                    {
                        base.ShowInformationMessage("保存成功。");
                        this.Close();
                    }
                }
            }
            catch
            {
            }
        }

        private void btnCheckNet_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                string ip = this.txtIPAddr.Text.Trim();
                int port = Int32.Parse(this.nudPort.Text);
                int macNo = Int32.Parse(this.nudMacNo.Text);

                IPHostEntry hostEntry = Dns.GetHostEntry(ip);
                IPAddress ipAdd = hostEntry.AddressList[0];

                AbstractPayDevice payDevice = PaymentDeviceFactory.CreateDevice(PaymentDeviceFactory.EastRiverDevice);

                ReturnValueInfo returnInfo = payDevice.Conn(ipAdd, port, macNo);

                string IPstr = "IP：" + ip + ":" + port + " 机号：" + macNo;

                this.Cursor = Cursors.Default;

                if (returnInfo.boolValue)
                {
                    MessageBox.Show(IPstr + " 连接成功。", "提示");
                }
                else
                {
                    base.ShowErrorMessage(IPstr + " 连接失败。" + returnInfo.messageText);
                }
            }
            catch
            {
            }
            this.Cursor = Cursors.Default;
        }
    }
}
