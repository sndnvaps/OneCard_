using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Model.HHZX.Report;
using Microsoft.Reporting.WinForms;
using BLL.IBLL.HHZX.Report;
using BLL.Factory.HHZX;

namespace WindowUI.HHZX.Report
{
    public partial class frmDepositSummary : BaseForm
    {
        public frmDepositSummary()
        {
            InitializeComponent();
        }

        private void frmDepositSummary_Load(object sender, EventArgs e)
        {
        }

        private void reportPanel_OnShowReportClick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                DepositSummary_dps_Info searchInfo = new DepositSummary_dps_Info();

                if (this.reportPanel.RSP_ClassID != Guid.Empty)
                {
                    searchInfo.dps_cClassID = this.reportPanel.RSP_ClassID;
                }
                else
                {
                    if (this.reportPanel.RSP_DepartmentID != Guid.Empty)
                    {
                        searchInfo.dps_cDptID = this.reportPanel.RSP_DepartmentID;
                    }
                }

                if (!string.IsNullOrEmpty(this.reportPanel.RSP_MonthFrom))
                {
                    DateTime dtMonthFrom = DateTime.Parse(this.reportPanel.RSP_MonthFrom);
                    searchInfo.dps_dMonthFrom = dtMonthFrom;
                }
                if (!string.IsNullOrEmpty(this.reportPanel.RSP_MonthTo))
                {
                    DateTime dtMonthTo = DateTime.Parse(this.reportPanel.RSP_MonthTo);
                    searchInfo.dps_dMonthTo = dtMonthTo;
                }

                IDepositSummaryBL depositBL = MasterBLLFactory.GetBLL<IDepositSummaryBL>(MasterBLLFactory.DepositSummary);
                List<DepositSummary_dps_Info> listDeposit = depositBL.SearchRecords(searchInfo);
                ShowReport(listDeposit);
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex);
            }
            this.Cursor = Cursors.Default;
        }

        private void ShowReport(List<DepositSummary_dps_Info> listDeposit)
        {
            ReportDataSource source = new ReportDataSource("Model_HHZX_Report_DepositSummary_dps_Info", listDeposit);
            rvMain.LocalReport.ReportPath = Common.DefineConstantValue.ReportFileBasePath + @"DepositSummary.rdlc";
            rvMain.LocalReport.DataSources.Clear();
            rvMain.LocalReport.DataSources.Add(source);
            rvMain.RefreshReport();
        }
    }
}
