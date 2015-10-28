using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Model.IModel;
using Model.HHZX.UserInfomation;
using Model.HHZX.UserInfomation.CardUserInfo;
using Model.HHZX.Report;
using BLL.IBLL.HHZX.Report;
using BLL.Factory.HHZX;
using Model.General;
using WindowUI.HHZX.ClassLibrary.Public;
using BLL.IBLL.General;
using BLL.IBLL.HHZX.UserInfomation.CardUserInfo;
using BLL.Factory.General;
using Microsoft.Reporting.WinForms;
using Common;

namespace WindowUI.HHZX.Report
{
    public partial class frmMealBalance : BaseForm
    {
        private IMealBookingBL _imbBL;

        public frmMealBalance()
        {
            InitializeComponent();

            _imbBL = MasterBLLFactory.GetBLL<IMealBookingBL>(MasterBLLFactory.mealBookingReport);
        }

        public void ShowForm(CardUserMaster_cus_Info query)
        {
            this.ShowDialog();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                List<MealBooking_mbk_info> _objList = new List<MealBooking_mbk_info>();

                MealBooking_mbk_info mbkInfo = new MealBooking_mbk_info();
                mbkInfo.StartTime = this.rspSearch.RSP_TimeFrom;
                mbkInfo.EndTime = this.rspSearch.RSP_TimeTo;

                if (this.rspSearch.RSP_GradeID != Guid.Empty && this.rspSearch.RSP_ClassID == Guid.Empty)
                {
                    mbkInfo.GradeID = this.rspSearch.RSP_GradeID;
                }
                else if (this.rspSearch.RSP_ClassID != Guid.Empty)
                {
                    mbkInfo.ClassID = this.rspSearch.RSP_ClassID;
                }

                _objList = _imbBL.SearchRecords(mbkInfo);

                if (_objList != null && _objList.Count > 0)
                {
                    _objList = _objList.OrderBy(p => p.className).ToList();

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

        private void ShowReport(List<MealBooking_mbk_info> objList)
        {
            ReportDataSource rds = new ReportDataSource("Model_HHZX_Report_MealBooking_mbk_info", objList);

            rpvMain.LocalReport.ReportPath = DefineConstantValue.ReportFileBasePath + @"MealBalance.rdlc";

            rpvMain.LocalReport.DataSources.Clear();

            rpvMain.LocalReport.DataSources.Add(rds);

            this.rpvMain.RefreshReport();
        }
    }
}
