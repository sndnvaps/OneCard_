using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Model.HHZX.ConsumerDevice;
using PaymentEquipment.IDevice;
using PaymentEquipment.DeviceFactory;
using System.Net;
using Model.General;
using PaymentEquipment.Entity;
using Model.HHZX.ComsumeAccount;

namespace WindowUI.HHZX.ConsumerDevice
{
    public partial class frmReceiptsRecordDialog : BaseForm
    {
        private ListView _lvMain;
        private List<int> _lvList;//机号
        private List<ConsumeMachineMaster_cmm_Info> _cmmList;
        private AbstractPayDevice _CurrentDevice;

        public frmReceiptsRecordDialog(ListView lvMain, List<ConsumeMachineMaster_cmm_Info> cmmList)
        {
            InitializeComponent();

            this._lvMain = lvMain;
            this._cmmList = cmmList;

            _lvList = new List<int>();
            foreach(ListViewItem lvItem in _lvMain.CheckedItems)
            {

                //_lvList.Add(lvItem.Index);
                //try
                //{
                //    _lvList.Add(Int32.Parse(lvItem.SubItems[2].ToString()));
                //}
                //catch
                //{

                //}

                try
                {
                    string s = lvItem.SubItems[2].Text;

                    _lvList.Add(Int32.Parse(lvItem.SubItems[2].Text));
                }
                catch
                {

                }
            }
        }

        public void Show()
        {
            Receipts();
            this.ShowDialog();
        }

        private void Receipts()
        {
            this.lblProgress.Text = "0/" + _lvList.Count();

            this.Cursor = Cursors.WaitCursor;

            bgwReceipts.RunWorkerAsync();

            this.Cursor = Cursors.Default;
        }

        private void bgwReceipts_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            

            if (e.ProgressPercentage == 100)
            {
                this.btnClose.Enabled = true;
            }
            else if (e.ProgressPercentage == 101)
            {
                this.Close();
            }
            else 
            {
                this.lblProgress.Text = e.ProgressPercentage + "/" + _lvList.Count();

                this.pgbProgress.Value = 100 * e.ProgressPercentage / _lvList.Count();
            }
        }

        private void bgwReceipts_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {


        }

        private void bgwReceipts_DoWork(object sender, DoWorkEventArgs e)
        {
            String showMessage = "";
            try
            {
                if (_CurrentDevice == null)
                {
                    _CurrentDevice = PaymentDeviceFactory.CreateDevice(PaymentDeviceFactory.EastRiverDevice);
                }

                int number = 1;

                foreach (int lvIndex in _lvList)
                {
                    try
                    {
                        this.bgwReceipts.ReportProgress(number, null);
                        ConsumeMachineMaster_cmm_Info ccmInfo = null;// _cmmList[lvIndex];

                        for (int index = 0; index < _cmmList.Count(); index++)
                        {
                            if (lvIndex == _cmmList[index].cmm_iMacNo)
                            {
                                ccmInfo = _cmmList[index];
                            }
                        }

                        if (ccmInfo != null)
                        {
                            IPAddress ip = IPAddress.Parse(ccmInfo.cmm_cIPAddr);

                            ReturnValueInfo returnInfo = _CurrentDevice.Conn(ip, ccmInfo.cmm_iPort, ccmInfo.cmm_iMacNo);

                            if (returnInfo.isError)
                            {
                                showMessage += "消费机：" + ccmInfo.cmm_cMacName + "，机号：" + ccmInfo.cmm_iMacNo + " 连接失败！\n";
                            }
                            else
                            {
                                List<ConsumeRecord_csr_Info> posList = _CurrentDevice.GetAllProfileRecords();
                                if (posList != null)
                                {
                                    showMessage += "消费机：" + ccmInfo.cmm_cMacName + "，机号：" + ccmInfo.cmm_iMacNo + " 收数成功！\n";
                                }
                                else
                                {
                                    showMessage += "消费机：" + ccmInfo.cmm_cMacName + "，机号：" + ccmInfo.cmm_iMacNo + " 收数失败！\n";
                                }
                            }
                        }
                    }
                    catch
                    {

                    }
                    finally
                    {
                        _CurrentDevice.DisConn();

                        number++;
                    }
                }
                showMessage += "\n已完成收数操作，共处理" + _lvList.Count + "台收费机。";

                
            }
            catch
            {

            }
            finally
            {
                this.bgwReceipts.ReportProgress(100, null);
                MessageBox.Show(showMessage, "提示");
                this.bgwReceipts.ReportProgress(101, null);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
