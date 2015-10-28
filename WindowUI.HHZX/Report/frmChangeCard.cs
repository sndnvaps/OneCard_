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
using Model.HHZX.Report;
using BLL.IBLL.HHZX.UserCard;
using BLL.Factory.HHZX;
using Microsoft.Reporting.WinForms;
using Common;

namespace WindowUI.HHZX.Report
{
    public partial class frmChangeCard : BaseForm
    {
        CardUserMaster_cus_Info _info;

        IUserCardPairBL _userCardPairBL;

        public frmChangeCard()
        {
            InitializeComponent();

            this._info = null;

            this._userCardPairBL = MasterBLLFactory.GetBLL<IUserCardPairBL>(MasterBLLFactory.UserCardPair);
        }

        public void ShowForm(CardUserMaster_cus_Info info)
        {
            this._info = info;

            this.ShowDialog();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                ChangeCardDetail_ccd_Info query = new ChangeCardDetail_ccd_Info();

                query.startDate = this.rspSearch.RSP_TimeFrom;
                query.endDate = this.rspSearch.RSP_TimeTo;
                query.ccd_cNewID = (Int32)(this.nbbNewCardNo.DecimalValue);

                if (this.rspSearch.RSP_ClassID != Guid.Empty)
                {
                    query.classID = this.rspSearch.RSP_ClassID;
                }
                else if(this.rspSearch.RSP_DepartmentID != Guid.Empty)
                {
                    query.classID = this.rspSearch.RSP_DepartmentID;
                }

                List<ChangeCardDetail_ccd_Info> sources = this._userCardPairBL.GetChangeCardDetail(query);

                if (sources != null && sources.Count > 0)
                {
                    ShowReport(sources);
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
            

            //frmChangeCardDetail win = new frmChangeCardDetail();

            //win.ShowForm(sources);
        }

        private void ShowReport(List<ChangeCardDetail_ccd_Info> infoList)
        {
            ReportDataSource rds = new ReportDataSource("Model_HHZX_Report_ChangeCardDetail_ccd_Info", infoList);

            rpvMain.LocalReport.ReportPath = DefineConstantValue.ReportFileBasePath + @"ChangeCardDetail.rdlc";

            rpvMain.LocalReport.DataSources.Clear();

            rpvMain.LocalReport.DataSources.Add(rds);

            this.rpvMain.RefreshReport();
        }
    }
}
