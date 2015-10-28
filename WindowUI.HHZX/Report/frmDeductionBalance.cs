using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Model.HHZX.UserInfomation.CardUserInfo;
using Microsoft.Reporting.WinForms;
using Common;
using Model.HHZX.Report;
using BLL.IBLL.HHZX.Report;
using BLL.Factory.HHZX;


namespace WindowUI.HHZX.Report
{
    public partial class frmDeductionBalance : BaseForm
    {
        private IDeductionBalanceBL _idbBL;

        public frmDeductionBalance()
        {
            InitializeComponent();
            _idbBL = MasterBLLFactory.GetBLL<IDeductionBalanceBL>(MasterBLLFactory.DeductionBalance);
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                List<DeductionBalance_Info> _objList = new List<DeductionBalance_Info>();

                DeductionBalance_Info dbInfo = new DeductionBalance_Info();

                DateTime StartTime = this.rspSearch.RSP_TimeFrom;
                DateTime EndTime = this.rspSearch.RSP_TimeTo;

                if (!String.IsNullOrEmpty(this.rspSearch.RSP_StudentID))
                {
                    dbInfo.StudentID = this.rspSearch.RSP_StudentID;
                }

                if (!String.IsNullOrEmpty(this.rspSearch.RSP_ChaName))
                {
                    dbInfo.ChaName = this.rspSearch.RSP_ChaName;
                }

                if (this.rspSearch.RSP_CardID > 0)
                {
                    dbInfo.CardNo = this.rspSearch.RSP_CardID;
                }

                if (this.rspSearch.RSP_ClassID != Guid.Empty)
                {
                    dbInfo.ClassID = this.rspSearch.RSP_ClassID;
                }

                dbInfo.FromTime = StartTime;
                dbInfo.ToTime = EndTime.AddDays(1);

                _objList = _idbBL.SearchRecords(dbInfo);

                if (_objList != null && _objList.Count > 0)
                {
                    _objList = _objList.OrderBy(p => p.ucp_iCardNo).OrderBy(p => p.csm_cClassName).ToList();

                    ShowReport(_objList);
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

        public void ShowForm(CardUserMaster_cus_Info info)
        {
            this.ShowDialog();
        }

        private void ShowReport(List<DeductionBalance_Info> objList)
        {
            ReportDataSource rds = new ReportDataSource("DeductionBalance_Info", objList);

            rpvMain.LocalReport.ReportPath = DefineConstantValue.ReportFileBasePath + @"DeductionBalance.rdlc";

            rpvMain.LocalReport.DataSources.Clear();

            rpvMain.LocalReport.DataSources.Add(rds);

            this.rpvMain.RefreshReport();
        }
    }
}
