using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL.IBLL.HHZX.ConsumeAccount;
using Model.IModel;
using WindowUI.HHZX.ClassLibrary.Public;
using PaymentEquipment.Entity;
using BLL.IBLL.SysMaster;
using Model.SysMaster;
using Model.HHZX.ConsumerDevice;
using BLL.IBLL.HHZX.ConsumerDevice;
using BLL.Factory.HHZX;
using Model.General;
using PaymentEquipment.IDevice;
using PaymentEquipment.DeviceFactory;
using System.Net;

namespace WindowUI.HHZX.ConsumerDevice
{
    /// <summary>
    /// 消费数据收集
    /// </summary>
    public partial class frmConsumptionRecordCollect : BaseForm
    {
        private ICodeMasterBL _icmBL;
        private IConsumeMachineBL _icsmBL;
        

        private List<CodeMaster_cmt_Info> _codeMasterList;
        private List<ConsumeMachineMaster_cmm_Info> _infoList;

        private DateTime _startTime;
        private DateTime _endTime;

        public frmConsumptionRecordCollect()
        {
            InitializeComponent();
            _icmBL = BLL.Factory.SysMaster.MasterBLLFactory.GetBLL<ICodeMasterBL>(BLL.Factory.SysMaster.MasterBLLFactory.CodeMaster_cmt);
            _icsmBL = MasterBLLFactory.GetBLL<IConsumeMachineBL>(MasterBLLFactory.ConsumeMachine);
            ShowCollectDateList();
            ShwoDeviceList();
        }

        /// <summary>
        /// 收数时段
        /// </summary>
        class CollectInfo
        {
            public string Name { get; set; }//时段名
            public string StartTime { get; set; }//开始时间
            //public string EndTime { get; set; }//结束时间
            public string TimeType { get; set; }
            public string Enable { get; set; }//启用
        }

        /// <summary>
        /// 消費機
        /// </summary>
        class DeviceInfo
        {
            public string index { get; set; }//序号
            public int cmm_iMacNo { get; set; }//机号
            public string cmm_cMacName { get; set; }//机名
            public string cmm_cIPAddr { get; set; }//IP地址
            public string cmm_cUsageType { get; set; }//使用类型
            public string cmm_cStatus { get; set; }//使用状态
            public string cmm_cDesc { get; set; }//地点描述
            public string cmm_dLastAccessTime { get; set; }//最后访问时间
            public string isSuccess { get; set; }//是否成功收數
            public bool isNormal { get; set; }
        }

        /// <summary>
        /// 显示收数时段
        /// </summary>
        private void ShowCollectDateList()
        {
            try
            {
                List<CollectInfo> collectList = new List<CollectInfo>();

                CodeMaster_cmt_Info cmt = new CodeMaster_cmt_Info();
                cmt.cmt_cKey1 = Common.DefineConstantValue.CodeMasterDefine.KEY1_RecordCollectInterval.ToString();

                List<CodeMaster_cmt_Info> cmtList = _icmBL.FindRecord(cmt);

                cmtList = cmtList.OrderBy(p => p.cmt_cRemark).ToList();

                if (cmtList != null)
                {
                    foreach (CodeMaster_cmt_Info item in cmtList)
                    {
                        if (item != null)
                        {
                            CollectInfo info = new CollectInfo();
                            info.StartTime = DateTime.Parse(item.cmt_cRemark).ToString("HH:mm");
                            info.Name = item.cmt_cRemark2;
                            info.Enable = item.cmt_fNumber == 1 ? "启用" : "停用";
                            info.TimeType = Common.DefineConstantValue.GetMealTypeDesc(item.cmt_cValue);
                            collectList.Add(info);
                        }
                    }

                    _codeMasterList = cmtList;

                    //DataTable dt = new DataTable();
                    //dt.Columns.Add(new DataColumn("StartTime", typeof(DateTime)));//执行时间
                    //dt.Columns.Add(new DataColumn("TimeType", typeof(string)));//时段类型

                    //for (int index = 0; index < cmtList.Count; index++)
                    //{
                    //    CollectInfo cinfo = new CollectInfo();
                    //    cinfo.Name = cmtList[index].cmt_cRemark2;

                    //    try
                    //    {
                    //        DateTime startTime = FormatDate(cmtList[index].cmt_cRemark);

                    //        DataRow dr = dt.NewRow();
                    //        dr["StartTime"] = startTime;
                    //        dr["TimeType"] = cmtList[index].cmt_cValue;
                    //        dt.Rows.Add(dr);//記錄所有時間段

                    //        cinfo.StartTime = startTime.ToString("HH:mm");
                    //        cinfo.EndTime = endTime.ToString("HH:mm");
                    //    }
                    //    catch
                    //    {

                    //    }

                    //    if (cmtList[index].cmt_fNumber > 0)
                    //    {
                    //        cinfo.Enable = "启用";
                    //    }
                    //    else
                    //    {
                    //        cinfo.Enable = "停用";
                    //    }
                    //    collectList.Add(cinfo);
                    //}
                    //SetCurrentTime(dt);
                }

                this.lvwCollectList.SetDataSource(collectList);
            }
            catch
            {

            }
        }

        /// <summary>
        /// 显示消费机列表
        /// </summary>
        private void ShwoDeviceList()
        {
            try
            {
                List<DeviceInfo> viewList = new List<DeviceInfo>();

                ConsumeMachineMaster_cmm_Info cmmInfo = new ConsumeMachineMaster_cmm_Info();
                cmmInfo.cmm_lIsActive = true;

                _infoList = _icsmBL.SearchRecords(cmmInfo);

                _infoList = _infoList.OrderBy(p => p.cmm_iMacNo).ToList();

                if (_infoList != null)
                {
                    for (int index = 0; index < _infoList.Count; index++)
                    {
                        ConsumeMachineMaster_cmm_Info infos = _infoList[index] as ConsumeMachineMaster_cmm_Info;

                        DeviceInfo vi = new DeviceInfo();
                        vi.index = (index + 1).ToString();
                        vi.cmm_cDesc = infos.cmm_cDesc;
                        vi.cmm_cIPAddr = infos.cmm_cIPAddr;
                        vi.cmm_cMacName = infos.cmm_cMacName;
                        vi.cmm_cStatus = infos.cmm_cStatus;
                        vi.cmm_cUsageType = infos.cmm_cUsageType;
                        vi.cmm_iMacNo = infos.cmm_iMacNo;
                        vi.cmm_dLastAccessTime = infos.cmm_dLastAccessTime.ToString("yyyy/MM/dd HH:mm:ss");

                        if (infos.cmm_lLastAccessRes == true)
                        {
                            vi.isSuccess = "收数成功";
                            vi.isNormal = true;
                        }
                        else
                        {
                            vi.isSuccess = "收数失败";
                            vi.isNormal = false;
                        }

                        viewList.Add(vi);
                    }
                }

                this.lblMachineAmount.Text = viewList.Count.ToString();

                //viewList = viewList.OrderBy(p => p.cmm_dLastAccessTime).ToList();

                viewList = viewList.OrderBy(p => p.isNormal).ToList();

                lvMachines.Items.Clear();

                lvMachines.ListViewItemSorter = null;

                lvMachines.SetDataSource(viewList);


                for (int index = 0; index < viewList.Count; index++)//按收數成功設置底色
                {
                    if (viewList[index].isNormal)
                    {
                        lvMachines.Items[index].ForeColor = Color.Blue;
                    }
                    else
                    {
                        lvMachines.Items[index].ForeColor = Color.Red;
                    }


                }
            }
            catch
            {

            }
        }

        /// <summary>
        /// 格式化時間段
        /// </summary>
        /// <param name="dt"></param>
        private DateTime FormatDate(string time)
        {
            DateTime onTime = System.DateTime.Now;

            string times = onTime.ToString("yyyy/MM/dd") + " " + time;

            DateTime returnTime = DateTime.Parse(times);

            return returnTime;

        }

        /// <summary>
        /// 設置當前最新收數時間段
        /// </summary>
        /// <param name="dt"></param>
        private void SetCurrentTime(DataTable dt)
        {
            if (dt != null)
            {
                DataView dv = dt.DefaultView;
                dv.Sort = "StartTime Asc";

                dt = dv.ToTable();

                DateTime time = System.DateTime.Now;

                if (time < (DateTime)dt.Rows[0]["StartTime"])
                {
                    _startTime = ((DateTime)dt.Rows[dt.Rows.Count - 1]["StartTime"]).AddDays(-1);
                    _endTime = ((DateTime)dt.Rows[dt.Rows.Count - 1]["EndTime"]).AddDays(-1);
                    return;
                }
                if (time > (DateTime)dt.Rows[dt.Rows.Count - 1]["StartTime"])
                {
                    _startTime = (DateTime)dt.Rows[dt.Rows.Count - 1]["StartTime"];
                    _endTime = (DateTime)dt.Rows[dt.Rows.Count - 1]["EndTime"];
                    return;
                }

                try
                {
                    for (int index = 0; index < dt.Rows.Count; index++)
                    {
                        if (time > (DateTime)dt.Rows[index]["StartTime"] && time < (DateTime)dt.Rows[index + 1]["StartTime"])
                        {
                            _startTime = (DateTime)dt.Rows[index]["StartTime"];
                            _endTime = (DateTime)dt.Rows[index]["EndTime"];
                            return;
                        }
                    }
                }
                catch
                {

                }
            }
        }

        private void lvMachines_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            ListView lv = sender as ListView;

            try
            {
                if (lv.CheckedItems != null && lv.CheckedItems.Count > 0)
                {
                    this.btnCollection.Enabled = true;
                }
                else
                {
                    this.btnCollection.Enabled = false;
                }
            }
            catch
            {

            }

            
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            frmRecordCollectSet frcSet = new frmRecordCollectSet();
            frcSet.UserInformation = this.UserInformation;
            frcSet.ShowDialog();
            ShowCollectDateList();
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            if (this.lvwCollectList.SelectedItems.Count > 0)
            {
                int index = this.lvwCollectList.SelectedItems[0].Index;

                CodeMaster_cmt_Info cmtInfo = _codeMasterList[index];

                frmRecordCollectSet frcSet = new frmRecordCollectSet(cmtInfo);
                frcSet.UserInformation = this.UserInformation;
                frcSet.ShowDialog();
                ShowCollectDateList();
            }
            else
            {
                base.ShowErrorMessage("请选择一条记录！");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.lvwCollectList.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("是否确认删除?", "提示", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }

                int index = this.lvwCollectList.SelectedItems[0].Index;
                CodeMaster_cmt_Info cmtInfo = _codeMasterList[index];
                ReturnValueInfo returnInfo = _icmBL.Save(cmtInfo, Common.DefineConstantValue.EditStateEnum.OE_Delete);

                if (returnInfo.isError)
                {
                    base.ShowErrorMessage("删除失败！");
                }
                else
                {
                    MessageBox.Show("删除成功。", "提示");
                    ShowCollectDateList();
                }
            }
            else
            {
                base.ShowErrorMessage("请选择一条记录！");
            }
        }

        private void btnCollection_Click(object sender, EventArgs e)
        {
            if (this.lvMachines.CheckedItems.Count > 0)
            {
                if (MessageBox.Show("此操作可能会因数据量的多少而执行较长时间，是否确认执行?", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                }
                else
                {
                    return;
                }

                frmReceiptsRecordDialog rrdFrom = new frmReceiptsRecordDialog(this.lvMachines,_infoList);
                rrdFrom.Show();

                ShwoDeviceList();
            }
            else
            {
                base.ShowErrorMessage("请选择一条记录！");
            }

            this.Cursor = Cursors.Default;
           // _CurrentDevice.
        }

        private void sysToolBar_OnItemRefresh_Click(object sender, EventArgs e)
        {
            ShowCollectDateList();
            ShwoDeviceList();
        }

        private void lvwCollectList_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (lvwCollectList.Sorting == SortOrder.Ascending)
            {
                ListViewSorter sorter = new ListViewSorter(e.Column, SortOrder.Descending);
                lvwCollectList.ListViewItemSorter = sorter;
                lvwCollectList.Sorting = SortOrder.Descending;
            }
            else
            {
                ListViewSorter sorter = new ListViewSorter(e.Column, SortOrder.Ascending);
                lvwCollectList.ListViewItemSorter = sorter;
                lvwCollectList.Sorting = SortOrder.Ascending;
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

        private void chbCheckedAll_CheckedChanged(object sender, EventArgs e)
        {
            if (this.lvMachines.Items != null)
            {
                for (int index = 0; index < this.lvMachines.Items.Count; index++)
                {
                    this.lvMachines.Items[index].Checked = this.chbCheckedAll.Checked;
                }
            }
        }

        private void btnCheckedReverse_Click(object sender, EventArgs e)
        {
            if (this.chbCheckedAll.Checked)
            {
                this.chbCheckedAll.Checked = false;
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
    }
}
