using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL.IBLL.HHZX.ConsumerDevice;
using BLL.Factory.HHZX;
using Model.HHZX.ConsumerDevice;
using WindowUI.HHZX.ClassLibrary.Public;
using PaymentEquipment.IDevice;
using PaymentEquipment.DeviceFactory;
using System.Net;
using Model.General;
using System.Threading;

namespace WindowUI.HHZX.MealBooking
{
    public partial class frmClrearBooking : BaseReaderForm
    {
        private IConsumeMachineBL _icsmBL;

        private List<ConsumeMachineMaster_cmm_Info> _infoList;
        private AbstractPayDevice _CurrentDevice;

        private bool _isRun = false;

        public frmClrearBooking()
        {
            InitializeComponent();

            _icsmBL = MasterBLLFactory.GetBLL<IConsumeMachineBL>(MasterBLLFactory.ConsumeMachine);

            ShowMachineList();
        }

        /// <summary>
        /// 消費機
        /// </summary>
        class DeviceInfo
        {
            public int cmm_iMacNo { get; set; }//机号
            public string cmm_cMacName { get; set; }//机名
            public string cmm_cIPAddr { get; set; }//IP地址
            public int cmm_iPort { get; set; }//端口
        }

        private void ShowMachineList()
        {
            try
            {
                List<DeviceInfo> viewList = new List<DeviceInfo>();

                ConsumeMachineMaster_cmm_Info cmmInfo = new ConsumeMachineMaster_cmm_Info();
                cmmInfo.cmm_lIsActive = true;

                List<ConsumeMachineMaster_cmm_Info>  infoList = _icsmBL.SearchRecords(cmmInfo);

                infoList = infoList.OrderBy(p => p.cmm_iMacNo).ToList();

                if (infoList != null)
                {
                    for (int index = 0; index < infoList.Count; index++)
                    {
                        ConsumeMachineMaster_cmm_Info infos = infoList[index] as ConsumeMachineMaster_cmm_Info;

                        DeviceInfo vi = new DeviceInfo();
                        vi.cmm_cIPAddr = infos.cmm_cIPAddr;
                        vi.cmm_cMacName = infos.cmm_cMacName;
                        vi.cmm_iMacNo = infos.cmm_iMacNo;
                        vi.cmm_iPort = infos.cmm_iPort;
                        viewList.Add(vi);
                    }
                }

                lvMachines.Items.Clear();

                lvMachines.ListViewItemSorter = null;

                lvMachines.SetDataSource(viewList);

            }
            catch
            {

            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            bool resUkey = base.CheckUKey();
            if (!resUkey)
            {
                return;
            }

            if (this.lvMachines.CheckedItems != null && this.lvMachines.CheckedItems.Count > 0)
            {
                if (MessageBox.Show("是否清除名单限制?", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (MessageBox.Show("清除名单限制后，将开放卡用户的消费许可限制，是否确认清除?", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        clearStatus();

                        _infoList = GetSelelctInfo();
                        this.pgbPro.Maximum = _infoList.Count();

                        this.btnClear.Enabled = false;
                        this.pnlPro.Enabled = true;
                        this._isRun = true;

                        bgwClear.RunWorkerAsync();
                        
                    }
                }
            }
            else
            {
                MessageBox.Show("请选择需要清除名单的消费机。");
            }
        }

        private void bgwClear_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                bgwClear.ReportProgress(0);

                this._CurrentDevice = PaymentDeviceFactory.CreateDevice(PaymentDeviceFactory.EastRiverDevice);

                for (int index = 0; index < _infoList.Count; index ++ )
                {
                    if (!_isRun)
                    {
                        break;
                    }

                    IPAddress IPAddr = IPAddress.Parse(_infoList[index].cmm_cIPAddr);

                    ReturnValueInfo rvInfo = this._CurrentDevice.Conn(IPAddr, _infoList[index].cmm_iPort, _infoList[index].cmm_iMacNo);

                    if (rvInfo.boolValue)
                    {
                        rvInfo = this._CurrentDevice.RemoveAllBlacklist();
                        if (rvInfo.boolValue && !rvInfo.isError)
                        {
                            bgwClear.ReportProgress(index + 1,true);
                        }
                        else
                        {
                            bgwClear.ReportProgress(index + 1,false);
                        }
                    }
                    else
                    {
                        bgwClear.ReportProgress(index + 1,false);
                    }

                    
                    
                }

                //bgwClear.ReportProgress(_infoList.Count);

                if (!_isRun)
                {
                    bgwClear.ReportProgress( -10);
                }

            }
            catch
            {

            }
        }

        private void bgwClear_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            try
            {
                if (e.ProgressPercentage == 0)
                {
                    this.pgbPro.Value = 0;
                    this.lblMessage.Text = "正在处理 0/" + _infoList.Count;
                }
                else if (e.ProgressPercentage > 0)
                {
                    if (e.ProgressPercentage == _infoList.Count)
                    {
                        this.btnClear.Enabled = true;
                        this.pnlPro.Enabled = false;

                        this.lblMessage.Text = "已完成 " + _infoList.Count + "/" + _infoList.Count;
                    }
                    else
                    {
                        this.lblMessage.Text = "正在处理 " + e.ProgressPercentage + "/" + _infoList.Count;
                    }


                    this.pgbPro.Value = e.ProgressPercentage;

                    if ((bool)e.UserState)
                    {
                        this.lvMachines.CheckedItems[e.ProgressPercentage - 1].SubItems[3].Text = "已清除";
                        this.lvMachines.CheckedItems[e.ProgressPercentage - 1].ForeColor = Color.Blue;
                    }
                    else
                    {
                        this.lvMachines.CheckedItems[e.ProgressPercentage - 1].SubItems[3].Text = "失败";
                        this.lvMachines.CheckedItems[e.ProgressPercentage - 1].ForeColor = Color.Red;
                    }
                    

                    if (e.ProgressPercentage > 14)
                    {
                        this.lvMachines.TopItem = this.lvMachines.Items[e.ProgressPercentage - 13];
                    }
                }
                else
                {
                    this.btnClear.Enabled = true;
                    this.pnlPro.Enabled = false;
                }
            }
            catch
            {

            }
        }

        private void clearStatus()
        {
            if(this.lvMachines.Items != null)
            {
                for (int index = 0; index < this.lvMachines.Items.Count; index ++ )
                {
                    this.lvMachines.Items[index].SubItems[3].Text = "";
                    this.lvMachines.Items[index].ForeColor = Color.Black;
                }
            }
        }

        private List<ConsumeMachineMaster_cmm_Info> GetSelelctInfo()
        {
            List<ConsumeMachineMaster_cmm_Info> cmmList = new List<ConsumeMachineMaster_cmm_Info>();
            if (this.lvMachines.CheckedItems != null && this.lvMachines.CheckedItems.Count > 0)
            {
                for(int index = 0 ;index < this.lvMachines.CheckedItems.Count ;index ++)
                {
                    ConsumeMachineMaster_cmm_Info cmmInfo = new ConsumeMachineMaster_cmm_Info();
                    cmmInfo.cmm_cIPAddr = this.lvMachines.CheckedItems[index].SubItems[2].Text;
                    cmmInfo.cmm_iMacNo = Int32.Parse(this.lvMachines.CheckedItems[index].SubItems[1].Text);
                    cmmInfo.cmm_iPort = Int32.Parse(this.lvMachines.CheckedItems[index].SubItems[4].Text);
                    cmmList.Add(cmmInfo);
                }
                
            }
            return cmmList;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            _isRun = false;
            Thread.Sleep(2000);

            this.Cursor = Cursors.Default;
        }

        private void btn_Click(object sender, EventArgs e)
        {
            if (this.chbSelectAll.Checked)
            {
                this.chbSelectAll.Checked = false;
            }
            else
            {
                if (this.lvMachines.Items != null)
                {
                    for (int index = 0; index < this.lvMachines.Items.Count; index++)
                    {
                        this.lvMachines.Items[index].Checked = !this.lvMachines.Items[index].Checked;
                    }
                }
            }
        }

        private void chbSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (this.lvMachines.Items != null)
            {
                for (int index = 0; index < this.lvMachines.Items.Count; index++)
                {
                    this.lvMachines.Items[index].Checked = this.chbSelectAll.Checked;
                }
            }
        }
    }
}
