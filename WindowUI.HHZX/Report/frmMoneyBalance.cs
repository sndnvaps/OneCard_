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
using BLL.IBLL.HHZX.UserInfomation.CardUserInfo;
using BLL.Factory.HHZX;
using BLL.IBLL.HHZX.ConsumeAccount;
using Model.HHZX.ComsumeAccount;
using Microsoft.Reporting.WinForms;
using Common;
using BLL.IBLL.HHZX.Report;

namespace WindowUI.HHZX.Report
{
    public partial class frmMoneyBalance : BaseForm
    {
        IGeneralBL _generalBL;

        //ICardUserMasterBL _cardUserMasterBL;

        //ICardUserAccountBL _cardUserAccountBL;

        //IConsumeRecordBL _consumeRecordBL;

        IClassMasterBL _icmBL;

        IMoneyBalanceBL _imbBL;

        public frmMoneyBalance()
        {
            InitializeComponent();

            this._generalBL = GeneralBLLFactory.GetBLL<IGeneralBL>(GeneralBLLFactory.General);

            //this._cardUserMasterBL = MasterBLLFactory.GetBLL<ICardUserMasterBL>(MasterBLLFactory.CardUserMaster);

            //this._cardUserAccountBL = MasterBLLFactory.GetBLL<ICardUserAccountBL>(MasterBLLFactory.CardUserAccount);

            //this._consumeRecordBL = MasterBLLFactory.GetBLL<IConsumeRecordBL>(MasterBLLFactory.ConsumeRecord);

            this._icmBL = MasterBLLFactory.GetBLL<IClassMasterBL>(MasterBLLFactory.ClassMaster);

            this._imbBL = MasterBLLFactory.GetBLL<IMoneyBalanceBL>(MasterBLLFactory.MoneyBalance);
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

                if (!String.IsNullOrEmpty(this.rspSearch.RSP_ClassID.ToString()))
                {
                    ClassMaster_csm_Info classInfo = new ClassMaster_csm_Info();

                    classInfo.csm_cRecordID = this.rspSearch.RSP_ClassID;

                    List<ClassMaster_csm_Info> csmList = _icmBL.AllRecords();

                    CardUserMaster_cus_Info cusInfo = new CardUserMaster_cus_Info();

                    if (this.rspSearch.RSP_ClassID != Guid.Empty)
                    {
                        cusInfo.cus_cClassID = this.rspSearch.RSP_ClassID;
                    }
                    else if (this.rspSearch.RSP_DepartmentID != Guid.Empty)
                    {
                        cusInfo.cus_cClassID = this.rspSearch.RSP_DepartmentID;
                    }


                    cusInfo.cus_cStudentID = this.rspSearch.RSP_StudentID;
                    cusInfo.cus_cChaName = this.rspSearch.RSP_ChaName;


                    List<CardUserAccount_cua_Info> cuaList = _imbBL.SearchRecords(cusInfo);

                    if (cuaList != null && cuaList.Count > 0)
                    {
                        cuaList = cuaList.OrderBy(p => p.cua_cClassName).OrderBy(p => p.cus_cStudentID).OrderBy(p => p.cua_dAddDate).ToList();

                        ShowReport(cuaList);
                    }
                    else
                    {
                        ShowWarningMessage("找不到符合条件的记录。");
                    }
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

            rpvMain.LocalReport.ReportPath = DefineConstantValue.ReportFileBasePath + @"MoneyBalance.rdlc";

            rpvMain.LocalReport.DataSources.Clear();

            rpvMain.LocalReport.DataSources.Add(rds);


            this.rpvMain.RefreshReport();
        }
    }
}
