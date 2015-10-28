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
using Common;

namespace WindowUI.HHZX.Report
{
    public partial class frmStudentCostSummary : BaseForm
    {
        IStudentCostSummaryBL _IStudentCostSummaryBL;
        /// <summary>
        /// 短信模板（0-姓名，1-生成日期，2-账户余额，3-消费总额，4-定餐消费额，5-餐外消费额，6-预计存款，7-扣费月份，8-扣费日
        /// </summary>
        private string _strSMSFormat;

        public frmStudentCostSummary()
        {
            InitializeComponent();

            this._IStudentCostSummaryBL = MasterBLLFactory.GetBLL<IStudentCostSummaryBL>(MasterBLLFactory.StudentCostSummary);

            _strSMSFormat = "尊敬的家长：贵子女 {0}，截止到本月{1}日，账户余额 {2}元，饭堂消费共 {3}元，其中定餐消费 {4}元，餐外消费 {5}元，建议下月存款 {6}元，定于{7}月{8}日通过银行交费，请及时充值，谢谢合作。【鹤华中学--膳食部】";
        }

        private void frmStudentCostSummary_Load(object sender, EventArgs e)
        {
            this.rvMain.RefreshReport();
        }

        private void rsPanel_OnShowReportClick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                StudentCostSummary_scs_Info searchInfo = new StudentCostSummary_scs_Info();
                searchInfo.scs_dStartDate = DateTime.Parse(rsPanel.RSP_SingleMonth);
                searchInfo.scs_dEndDate = DateTime.Parse(rsPanel.RSP_SingleMonth).AddMonths(1).AddDays(-1);
                if (!string.IsNullOrEmpty(rsPanel.RSP_StudentID))
                {
                    searchInfo.scs_cUserNum = rsPanel.RSP_StudentID;
                }
                if (rsPanel.RSP_GradeID != Guid.Empty)
                {
                    searchInfo.GradeID = rsPanel.RSP_GradeID;
                }
                if (rsPanel.RSP_ClassID != Guid.Empty)
                {
                    searchInfo.ClassID = rsPanel.RSP_ClassID;
                }
                if (!string.IsNullOrEmpty(rsPanel.RSP_ChaName))
                {
                    searchInfo.scs_cUserName = rsPanel.RSP_ChaName;
                }

                decimal fSupplement = decimal.Parse(nbxSupplement.Text);
                List<StudentCostSummary_scs_Info> listReportRes = this._IStudentCostSummaryBL.SearchRecords(searchInfo);
                if (listReportRes != null && listReportRes.Count > 0)
                {
                    if (ckbExcept.Checked)
                    {
                        listReportRes = listReportRes.Where(x => (x.scs_fPreMealCost + x.scs_fHistoryFreeCost + x.scs_fSupplement - x.scs_fAccountBalance) > 0).ToList();
                    }
                    foreach (StudentCostSummary_scs_Info scsItem in listReportRes)
                    {
                        scsItem.scs_cMonthName = rsPanel.RSP_SingleMonth;
                        scsItem.scs_fSupplement = fSupplement;
                        scsItem.scs_cSMSContent = string.Format(_strSMSFormat, scsItem.scs_cUserName, DateTime.Now.Day.ToString(), scsItem.scs_fAccountBalance.ToString(), scsItem.scs_fTotalCost.ToString(), scsItem.scs_fHistoryMealCost.ToString(), scsItem.scs_fHistoryFreeCost.ToString(), (scsItem.scs_fPreMealCost + scsItem.scs_fHistoryFreeCost + scsItem.scs_fSupplement - scsItem.scs_fAccountBalance).ToString(), tbxRechargeMonth.Text, tbxRechargeDay.Text);
                    }
                    listReportRes = listReportRes.OrderBy(x => x.scs_cClassName).ToList();
                    ShowReport(listReportRes);
                }
                else
                {
                    base.ShowWarningMessage("未找到符合条件的记录，请设置合适条件后重试。");
                }
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                ShowErrorMessage("查询报表数据出现异常。" + Environment.NewLine + ex.Message);
            }
            this.Cursor = Cursors.Default;
        }

        private void ShowReport(List<StudentCostSummary_scs_Info> listDatas)
        {
            ReportDataSource rds = new ReportDataSource("StudentCostSummary_scs_Info", listDatas);

            rvMain.LocalReport.ReportPath = DefineConstantValue.ReportFileBasePath + @"StudentCostSummary.rdlc";

            rvMain.LocalReport.DataSources.Clear();

            rvMain.LocalReport.DataSources.Add(rds);

            rvMain.LocalReport.Refresh();
            rvMain.RefreshReport();
        }
    }
}
