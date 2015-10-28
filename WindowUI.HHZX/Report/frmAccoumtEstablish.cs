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
using BLL.IBLL.General;
using BLL.Factory.General;
using WindowUI.HHZX.ClassLibrary.Public;
using Model.HHZX.ComsumeAccount;
using BLL.IBLL.HHZX.UserCard;
using BLL.Factory.HHZX;
using Microsoft.Reporting.WinForms;
using Common;

namespace WindowUI.HHZX.Report
{
    public partial class frmAccoumtEstablish : BaseForm
    {
        IGeneralBL _generalBL;

        IUserCardPairBL _userCardPairBL;

        public frmAccoumtEstablish()
        {
            InitializeComponent();

            this._generalBL = GeneralBLLFactory.GetBLL<IGeneralBL>(GeneralBLLFactory.General);

            this._userCardPairBL = MasterBLLFactory.GetBLL<IUserCardPairBL>(MasterBLLFactory.UserCardPair);

        }

        public void ShowForm()
        {

            this.ShowDialog();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                List<CardUserAccount_cua_Info> returnList = this._userCardPairBL.GetAccoumtEstablishInfo(this.rspSearch.RSP_TimeFrom, this.rspSearch.RSP_TimeTo, this.rspSearch.RSP_ClassID, this.rspSearch.RSP_StudentID);

                if (returnList != null && returnList.Count > 0)
                {
                    returnList = returnList.OrderBy(p => p.cua_cCardNo).OrderBy(p => p.cua_cClassName).ToList();

                    ShowReport(returnList);
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

        private void ShowReport(List<CardUserAccount_cua_Info> infoList)
        {
            ReportDataSource rds = new ReportDataSource("Model_HHZX_ComsumeAccount_CardUserAccount_cua_Info", infoList);

            rpvMain.LocalReport.ReportPath = DefineConstantValue.ReportFileBasePath + @"AccoumtEstablishDetail.rdlc";

            rpvMain.LocalReport.DataSources.Clear();

            rpvMain.LocalReport.DataSources.Add(rds);

            this.rpvMain.RefreshReport();
        }
    }
}
