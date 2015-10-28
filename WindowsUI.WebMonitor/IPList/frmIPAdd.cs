using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WindowsUI.WebMonitor.Model;
using WindowsUI.WebMonitor.Public;

namespace WindowsUI.WebMonitor.IPList
{
    public partial class frmIPAdd : Form
    {
        private MonitorBox _mbInfo;
        private FromStatus _status;

        public frmIPAdd()
        {
            InitializeComponent();
            _status = FromStatus.New;
        }

        public frmIPAdd(MonitorBox info)
        {
            InitializeComponent();
            this._mbInfo = info;
            _status = FromStatus.Eduit;
            ShowInfo();
        }

        private enum FromStatus
        {
            New,
            Eduit
        }

        private void ShowInfo()
        {
            this.txtIP.Text = _mbInfo.IP;
            this.txtName.Text = _mbInfo.Name;
            this.txtNo.Text = _mbInfo.Number;
        }

        private MonitorBox GetValue()
        {
            if(_mbInfo == null)
            {
                _mbInfo = new MonitorBox();
            }

            _mbInfo.IP = this.txtIP.Text;
            _mbInfo.Name = this.txtName.Text;
            _mbInfo.Number = this.txtNo.Text;

            return _mbInfo;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                _mbInfo = GetValue();

                XMLOperate xml = new XMLOperate();

                switch (_status)
                {
                    case FromStatus.New:
                        xml.SaveMonitorInfo(_mbInfo);
                        break;
                    case FromStatus.Eduit:
                        xml.UpdateMonitorInfo(_mbInfo);
                        break;
                }
                

                MessageBox.Show("保存完成！","提示");
                this.Close();
            }
            catch
            {
                MessageBox.Show("保存失敗！", "提示");
            }
        }
    }
}
