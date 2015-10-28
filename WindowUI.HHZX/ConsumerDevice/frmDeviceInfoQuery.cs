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
using WindowUI.HHZX.ClassLibrary.Public;
using Model.IModel;
using Model.HHZX.ConsumerDevice;
using Model.General;
using Common;

namespace WindowUI.HHZX.ConsumerDevice
{
    /// <summary>
    /// 消费设备信息查询设置
    /// </summary>
    public partial class frmDeviceInfoQuery : BaseForm
    {
        private IConsumeMachineBL _icmBL;
        private List<ConsumeMachineMaster_cmm_Info> _infoList;

        public frmDeviceInfoQuery()
        {
            InitializeComponent();

            _icmBL = MasterBLLFactory.GetBLL<IConsumeMachineBL>(MasterBLLFactory.ConsumeMachine);

            initMachineType();
            initMachineStatus();
            ShwoView();
        }

        private void initMachineType()
        {
            List<ComboboxDataInfo> infoList = new List<ComboboxDataInfo>();

            foreach (Common.DefineConstantValue.ConsumeMachineType macType in Enum.GetValues(typeof(Common.DefineConstantValue.ConsumeMachineType)))
            {
                ComboboxDataInfo info = new ComboboxDataInfo();
                info.DisplayMember = DefineConstantValue.GetMacTypeDesc(macType);
                info.ValueMember = macType.ToString();
                infoList.Add(info);
            }

            ComboboxDataInfo infoTotal = new ComboboxDataInfo();
            infoTotal.DisplayMember = "全部";
            infoTotal.ValueMember = string.Empty;
            infoList.Add(infoTotal);

            this.cmbMachineType.DataSource = infoList;
            this.cmbMachineType.DisplayMember = "DisplayMember";
            this.cmbMachineType.ValueMember = "ValueMember";

            this.cmbMachineType.SelectedIndex = infoList.Count - 1;

        }

        private void initMachineStatus()
        {
            List<ComboboxDataInfo> infoList = new List<ComboboxDataInfo>();

            foreach (Common.DefineConstantValue.ConsumeMachineStatus usingType in Enum.GetValues(typeof(Common.DefineConstantValue.ConsumeMachineStatus)))
            {
                ComboboxDataInfo info = new ComboboxDataInfo();
                info.DisplayMember = DefineConstantValue.GetMacUsingDesc(usingType);
                info.ValueMember = usingType.ToString();
                infoList.Add(info);
            }

            ComboboxDataInfo infoTotal = new ComboboxDataInfo();
            infoTotal.DisplayMember = "全部";
            infoTotal.ValueMember = string.Empty;
            infoList.Add(infoTotal);

            this.cmbMachineStatus.DataSource = infoList;
            this.cmbMachineStatus.DisplayMember = "DisplayMember";
            this.cmbMachineStatus.ValueMember = "ValueMember";

            this.cmbMachineStatus.SelectedIndex = infoList.Count - 1;
        }

        private void sysToolBar_OnItemNew_Click(object sender, EventArgs e)
        {
            frmDeviceInfoDetail frmDetail = new frmDeviceInfoDetail();
            frmDetail.UserInformation = this.UserInformation;
            frmDetail.ShowDialog();

            ShwoView();
        }

        private void sysToolBar_OnItemModify_Click(object sender, EventArgs e)
        {
            if (this.lvMachines.SelectedItems.Count > 0)
            {
                ConsumeMachineMaster_cmm_Info ccmInfo = _infoList[Int32.Parse(this.lvMachines.SelectedItems[0].SubItems[0].Text) - 1] as ConsumeMachineMaster_cmm_Info;

                frmDeviceInfoDetail frmDetail = new frmDeviceInfoDetail(ccmInfo);
                frmDetail.UserInformation = this.UserInformation;
                frmDetail.ShowDialog();

                ShwoView();
            }
            else
            {
                base.ShowErrorMessage("请选择一条记录！");
            }

        }

        class ViewInfo
        {
            public string index { get; set; }//序号
            public string cmm_iMacNo { get; set; }//机号
            public string cmm_cMacName { get; set; }//机名
            public string cmm_cIPAddr { get; set; }//IP地址
            public string cmm_iPort { get; set; }//端口
            public string cmm_cUsageType { get; set; }//使用类型
            public string cmm_cStatus { get; set; }//使用状态
            public string cmm_cDesc { get; set; }//地点描述
            public string cmm_cAdd { get; set; }//添加人
            public string cmm_dAddDate { get; set; }//添加时间
            public string cmm_cLast { get; set; }//修改人
            public string cmm_dLastDate { get; set; }//修改时间
        }

        private ConsumeMachineMaster_cmm_Info GetSelectObj()
        {
            ConsumeMachineMaster_cmm_Info cmmInfo = new ConsumeMachineMaster_cmm_Info();

            if (!String.IsNullOrEmpty(this.nudPort.Text))
            {
                cmmInfo.cmm_iPort = Int32.Parse(this.nudPort.Text);
            }
            if (!String.IsNullOrEmpty(this.nudMacNo.Text))
            {
                cmmInfo.cmm_iMacNo = Int32.Parse(this.nudMacNo.Text);
            }

            cmmInfo.cmm_cMacName = this.txtMacName.Text;
            cmmInfo.cmm_cIPAddr = this.txtIPAddr.Text;

            cmmInfo.cmm_cUsageType = this.cmbMachineType.SelectedValue.ToString();
            cmmInfo.cmm_cStatus = this.cmbMachineStatus.SelectedValue.ToString();

            return cmmInfo;
        }

        private void ShwoView()
        {
            try
            {
                ConsumeMachineMaster_cmm_Info ccmInfo = GetSelectObj();

                List<ViewInfo> viewList = new List<ViewInfo>();

                _infoList = _icmBL.SearchRecords(ccmInfo);

                _infoList = _infoList.OrderBy(p => p.cmm_iMacNo).ToList();

                if (_infoList != null)
                {
                    for (int index = 0; index < _infoList.Count; index++)
                    {
                        ConsumeMachineMaster_cmm_Info infos = _infoList[index] as ConsumeMachineMaster_cmm_Info;

                        ViewInfo vi = new ViewInfo();
                        vi.index = (index + 1).ToString();
                        vi.cmm_cAdd = infos.cmm_cAdd;
                        vi.cmm_cDesc = infos.cmm_cDesc;
                        vi.cmm_cIPAddr = infos.cmm_cIPAddr;
                        vi.cmm_cLast = infos.cmm_cLast;
                        vi.cmm_cMacName = infos.cmm_cMacName;
                        vi.cmm_cStatus = Common.DefineConstantValue.GetMacUsingDesc(infos.cmm_cStatus);
                        vi.cmm_cUsageType = Common.DefineConstantValue.GetMacTypeDesc(infos.cmm_cUsageType);
                        vi.cmm_dAddDate = infos.cmm_dAddDate.ToString("yyyy/MM/dd HH:mm:ss");
                        vi.cmm_dLastDate = infos.cmm_dLastDate.ToString("yyyy/MM/dd HH:mm:ss");
                        vi.cmm_iMacNo = infos.cmm_iMacNo.ToString();
                        vi.cmm_iPort = infos.cmm_iPort.ToString();

                        viewList.Add(vi);
                    }
                }

                this.lblRecordAmount.Text = viewList.Count.ToString();
                lvMachines.SetDataSource(viewList);
            }
            catch
            {

            }
        }

        //private string GetType_CN(string eumn)
        //{
        //    try
        //    {
        //        switch (eumn)
        //        {
        //            case "StuSetmeal":
        //                return "学生定餐机";
        //            case "StuPay":
        //                return "学生加菜机";
        //            case "TeachPay":
        //                return "教师就餐机";
        //        }
        //    }
        //    catch
        //    {

        //    }
        //    return "";
        //}

        //private string GetStatus_CN(string eumn)
        //{
        //    try
        //    {
        //        switch (eumn)
        //        {
        //            case "Using":
        //                return "使用中";
        //            case "Stop":
        //                return "停用";
        //            case "Repair":
        //                return "維修";
        //        }
        //    }
        //    catch
        //    {

        //    }
        //    return "";
        //}

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ShwoView();
        }

        private void lvMachines_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView lv = sender as ListView;

            if (lv.SelectedItems.Count > 0)
            {
                this.sysToolBar.BtnModify_IsEnabled = true;
            }
            else
            {
                this.sysToolBar.BtnModify_IsEnabled = false;
            }
        }

        private void lvMachines_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (lvMachines.Sorting == SortOrder.Ascending)
            {
                ListViewSorter sorter = new ListViewSorter(e.Column, SortOrder.Descending);
                lvMachines.ListViewItemSorter = sorter;
                lvMachines.Sorting = SortOrder.Descending;
            }
            else
            {
                ListViewSorter sorter = new ListViewSorter(e.Column, SortOrder.Ascending);
                lvMachines.ListViewItemSorter = sorter;
                lvMachines.Sorting = SortOrder.Ascending;
            }
        }

        private void sysToolBar_OnItemRefresh_Click(object sender, EventArgs e)
        {
            ShwoView();
        }

    }
}
