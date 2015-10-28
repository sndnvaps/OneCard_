using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Model.HHZX.UserInfomation;
using Model.HHZX.UserInfomation.CardUserInfo;
using Model.SysMaster;
using BLL.IBLL.HHZX.Report;
using BLL.Factory.HHZX;
using Model.HHZX.Report;
using BLL.IBLL.General;
using BLL.Factory.General;
using WindowUI.HHZX.ClassLibrary.Public;
using Microsoft.Reporting.WinForms;
using Common;

namespace WindowUI.HHZX.Report
{
    public partial class frmCostBalance : BaseForm
    {

        IPayRecordBL _payRecordBL;

        IGeneralBL _generalBL;

        public frmCostBalance()
        {
            InitializeComponent();

            this._payRecordBL = MasterBLLFactory.GetBLL<IPayRecordBL>(MasterBLLFactory.PayRecord);

            this._generalBL = GeneralBLLFactory.GetBLL<IGeneralBL>(GeneralBLLFactory.General);
        }

        private void BindBox()
        {
            try
            {
                List<Model.IModel.IModelObject> returnList = this._generalBL.GetMasterDataInformations(Common.DefineConstantValue.MasterType.CostType);

                cbxPayType.SetDataSource(returnList);

                cbxPayType.SelectItemForValue("");
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

        private void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                PayRecord_prd_Info query = new PayRecord_prd_Info();

                query.prd_dStartDate = this.rspSearch.RSP_TimeFrom;

                query.prd_dEndDate = this.rspSearch.RSP_TimeTo;

                if (cbxPayType.SelectedValue != null)
                {
                    query.prd_cPayType = cbxPayType.SelectedValue.ToString();
                }

                List<Model.IModel.IModelObject> searchRecord = this._payRecordBL.SearchRecords(query);

                if (searchRecord != null && searchRecord.Count > 0)
                {
                    List<PayRecord_prd_Info> showData = new List<PayRecord_prd_Info>();

                    if (searchRecord != null && searchRecord.Count > 0)
                    {
                        foreach (PayRecord_prd_Info item in searchRecord)
                        {
                            showData.Add(item);
                        }
                    }

                    showData = showData.OrderBy(p => p.prd_cPayType).ToList();

                    ShowReport(showData);
                }
                else
                {
                    ShowWarningMessage("找不到符合条件的记录。");
                }
            }
            catch
            {

            }
            this.Cursor = Cursors.Default;
        }


        private void btnPayRecord_Click_1(object sender, EventArgs e)
        {
            frmPayRecord frm = new frmPayRecord();

            frm.ShowForm(this.UserInformation);
        }

        private void frmCostBalance_Load(object sender, EventArgs e)
        {
            BindBox();
            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }

        private void ShowReport(List<PayRecord_prd_Info> infoList)
        {
            ReportDataSource rds = new ReportDataSource("PayRecord_prd_Info", infoList);

            reportViewer1.LocalReport.ReportPath = DefineConstantValue.ReportFileBasePath + @"CostBalance_report.rdlc";
            //reportViewer1.LocalReport.ReportPath = DefineConstantValue.ReportFileBasePath + @"CostBalanceDetail_report.rdlc";

            reportViewer1.LocalReport.DataSources.Clear();

            reportViewer1.LocalReport.DataSources.Add(rds);

            this.reportViewer1.RefreshReport();
        }
    }
}
