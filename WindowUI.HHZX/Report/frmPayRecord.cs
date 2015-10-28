using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Model.SysMaster;
using BLL.IBLL.HHZX.Report;
using BLL.Factory.HHZX;
using Model.HHZX.Report;
using WindowUI.HHZX.ClassLibrary.Public;
using Model.General;

namespace WindowUI.HHZX.Report
{
    public partial class frmPayRecord : BaseForm
    {
        IPayRecordBL _payRecordBL;

        public frmPayRecord()
        {
            InitializeComponent();

            this._payRecordBL = MasterBLLFactory.GetBLL<IPayRecordBL>(MasterBLLFactory.PayRecord);
        }

        public void LoadAllData()
        {
            PayRecord_prd_Info query = new PayRecord_prd_Info();

            try
            {
                List<Model.IModel.IModelObject> returnList = this._payRecordBL.SearchRecords(query);

                lvPayRecord.SetDataSource(returnList);
            }
            catch (Exception Ex)
            {

                ShowErrorMessage(Ex.Message);
            }
        }

        public void ShowForm(Sys_UserMaster_usm_Info userInfo)
        {
            this.UserInformation = userInfo;

            this.ShowDialog();
        }

        private void systemToolBar1_OnItemNew_Click(object sender, EventArgs e)
        {
            frmPayRecordDetail frm = new frmPayRecordDetail();

            PayRecord_prd_Info info = new PayRecord_prd_Info();

            frm.ShowForm(this.UserInformation, info, Common.DefineConstantValue.EditStateEnum.OE_Insert);

            LoadAllData();
        }

        private void frmPayRecord_Load(object sender, EventArgs e)
        {
            LoadAllData();
        }

        private void EditSelected()
        {
            if (lvPayRecord.SelectedItems != null && lvPayRecord.SelectedItems.Count > 0)
            {
                PayRecord_prd_Info info = new PayRecord_prd_Info();

                frmPayRecordDetail frm = new frmPayRecordDetail();

                info.prd_cRecordID = new Guid(lvPayRecord.SelectedItems[0].SubItems[0].Text);

                frm.ShowForm(this.UserInformation, info, Common.DefineConstantValue.EditStateEnum.OE_Update);
            }
        }

        private void systemToolBar1_OnItemModify_Click(object sender, EventArgs e)
        {
            EditSelected();
        }

        private void systemToolBar1_OnItemRefresh_Click(object sender, EventArgs e)
        {
            LoadAllData();
        }

        private void lvPayRecord_DoubleClick(object sender, EventArgs e)
        {
            EditSelected();
        }

        private void systemToolBar1_OnItemDelete_Click(object sender, EventArgs e)
        {
            if (lvPayRecord.SelectedItems != null && lvPayRecord.SelectedItems.Count > 0)
            {
                PayRecord_prd_Info info = new PayRecord_prd_Info();

                info.prd_cRecordID = new Guid(lvPayRecord.SelectedItems[0].SubItems[0].Text);

                try
                {
                    ReturnValueInfo returnInfo = this._payRecordBL.Save(info, Common.DefineConstantValue.EditStateEnum.OE_Delete);

                    if (returnInfo.boolValue)
                    {
                        ShowInformationMessage("删除成功！");

                        LoadAllData();
                    }
                    else
                    {
                        ShowErrorMessage(returnInfo.messageText);
                    }
                }
                catch (Exception Ex)
                {

                    ShowErrorMessage(Ex.Message);
                }
            }
        }
    }
}
