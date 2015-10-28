using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Model.HHZX.Report;
using BLL.IBLL.HHZX.Report;
using BLL.Factory.HHZX;
using Microsoft.Reporting.WinForms;

namespace WindowUI.HHZX.Report
{
    public partial class frmCardFeeSummary : BaseForm
    {
        public frmCardFeeSummary()
        {
            InitializeComponent();
        }

        private void frmCardFeeSummary_Load(object sender, EventArgs e)
        {
            this.rptViewer.RefreshReport();
        }

        private void rsPanel_OnShowReportClick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                CardFeeSummary_cfs_Info searchInfo = new CardFeeSummary_cfs_Info();

                if (!string.IsNullOrEmpty(this.rsPanel.RSP_MonthFrom))
                {
                    DateTime dtMonthFrom = DateTime.Parse(this.rsPanel.RSP_MonthFrom);
                    searchInfo.cfs_dMonthFrom = dtMonthFrom;
                }
                if (!string.IsNullOrEmpty(this.rsPanel.RSP_MonthTo))
                {
                    DateTime dtMonthTo = DateTime.Parse(this.rsPanel.RSP_MonthTo);
                    searchInfo.cfs_dMonthTo = dtMonthTo;
                }

                ICardFeeSummaryBL cardBL = MasterBLLFactory.GetBLL<ICardFeeSummaryBL>(MasterBLLFactory.CardFeeSummary);
                List<CardFeeSummary_cfs_Info> listDeposit = cardBL.SearchRecords(searchInfo);

                ShowReport(listDeposit);
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex);
            }
            this.Cursor = Cursors.Default;
        }

        private void ShowReport(List<CardFeeSummary_cfs_Info> listDeposit)
        {
            ReportDataSource source = new ReportDataSource("CardFeeSummary_cfs_Info", listDeposit);
            rptViewer.LocalReport.ReportPath = Common.DefineConstantValue.ReportFileBasePath + @"CardFeeSummary.rdlc";
            rptViewer.LocalReport.DataSources.Clear();
            rptViewer.LocalReport.DataSources.Add(source);
            rptViewer.RefreshReport();
        }
    }
}
