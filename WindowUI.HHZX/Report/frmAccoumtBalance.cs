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
using BLL.IBLL.HHZX.Report;
using BLL.Factory.HHZX;
using Model.HHZX.Report;
using BLL.IBLL.General;
using BLL.Factory.General;
using Model.IModel;
using Model.General;
using WindowUI.HHZX.ClassLibrary.Public;
using BLL.IBLL.HHZX.UserInfomation.CardUserInfo;
using Microsoft.Reporting.WinForms;
using Common;

namespace WindowUI.HHZX.Report
{
    public partial class frmAccoumtBalance : BaseForm
    {
        private IAccoumtBalanceBL _iabBL;
        private IGeneralBL _igBM;
        private IGradeMasterBL _igmBL;

        public frmAccoumtBalance()
        {
            InitializeComponent();

            _iabBL = MasterBLLFactory.GetBLL<IAccoumtBalanceBL>(MasterBLLFactory.AccoumtBalance);
            _igBM = GeneralBLLFactory.GetBLL<IGeneralBL>(GeneralBLLFactory.General);
            _igmBL = MasterBLLFactory.GetBLL<IGradeMasterBL>(MasterBLLFactory.GradeMaster);
        }

        private void frmAccoumtBalanceDetail_Load(object sender, EventArgs e)
        {
            this.rpvMain.RefreshReport();
        }

        private void ShowReport(List<AccoumtBalance_atb_info> objList)
        {
            ReportDataSource rds = new ReportDataSource("AccoumtBalance_atb_info", objList);

            rpvMain.LocalReport.ReportPath = DefineConstantValue.ReportFileBasePath + @"AccoumtBalance.rdlc";

            rpvMain.LocalReport.DataSources.Clear();

            rpvMain.LocalReport.DataSources.Add(rds);

            this.rpvMain.RefreshReport();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                AccoumtBalance_atb_info atbInfo = new AccoumtBalance_atb_info();

                DateTime startTime = DateTime.Parse(this.rspSearch.RSP_TimeFrom.ToString("yyyy/MM/dd"));
                DateTime endTime = DateTime.Parse(this.rspSearch.RSP_TimeTo.ToString("yyyy/MM/dd")).AddDays(1);

                atbInfo.AccountDate_From = startTime;
                atbInfo.AccountDate_To = endTime;

                if (!String.IsNullOrEmpty(this.rspSearch.RSP_GradeID.ToString()))
                {
                    atbInfo.GradeID = new Guid(this.rspSearch.RSP_GradeID.ToString());
                }

                if (!String.IsNullOrEmpty(this.rspSearch.RSP_ClassID.ToString()))
                {
                    atbInfo.ClassID = new Guid(this.rspSearch.RSP_ClassID.ToString());
                }

                List<AccoumtBalance_atb_info> infoList = _iabBL.SearchRecords(atbInfo);
                infoList = infoList.OrderBy(p => p.AccountDate).ToList();

                if (infoList != null && infoList.Count > 0)
                {
                    ShowReport(infoList);
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

        public void ShowForm(CardUserMaster_cus_Info query)
        {
            this.ShowDialog();
        }
    }
}
