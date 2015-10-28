using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WindowsUI.WebMonitor.Public;
using WindowsUI.WebMonitor.Model;
using WindowUI.WebMonitor.ClassLibrary.Public;

namespace WindowsUI.WebMonitor.IPList
{
    public partial class frmIPOperate : Form
    {
        private List<MonitorBox> _mbList;

        public frmIPOperate()
        {
            InitializeComponent();
            init();
        }

        private void init()
        {
            XMLOperate xml = new XMLOperate();

            _mbList = xml.GetMonitorList();

            this.lvwIPList.SetDataSource(_mbList);
        }

        private void utbTool_BtnNewClick(object sender, EventArgs e)
        {
            frmIPAdd fiaForm = new frmIPAdd();
            fiaForm.ShowDialog();
            init();
        }

        private void lvwIPList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.lvwIPList.SelectedItems != null && this.lvwIPList.SelectedItems.Count > 0)
                {
                    this.utbTool.BtnModifyEnabled = true;
                    this.utbTool.BtnDeleteEnabled = true;
                }
                else
                {
                    this.utbTool.BtnModifyEnabled = false;
                    this.utbTool.BtnDeleteEnabled = false;
                }
            }
            catch
            {

            }
        }

        private void utbTool_BtnModifyClick(object sender, EventArgs e)
        {
            if (this.lvwIPList.SelectedItems != null && this.lvwIPList.SelectedItems.Count > 0)
            {
                int index = this.lvwIPList.SelectedItems[0].Index;

                frmIPAdd fiaForm = new frmIPAdd(_mbList[index]);
                fiaForm.ShowDialog();
                init();
            }
        }

        private void utbTool_BtnDeleteClick(object sender, EventArgs e)
        {
            if (this.lvwIPList.SelectedItems != null && this.lvwIPList.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("是否删除该记录?", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int index = this.lvwIPList.SelectedItems[0].Index;
                    XMLOperate xml = new XMLOperate();
                    xml.DeleteMonitorInfo(_mbList[index]);
                    init();
                }
            }
            else
            {
                MessageBox.Show("请选择一条记录。","提示");
            }

            
        }
    }
}
