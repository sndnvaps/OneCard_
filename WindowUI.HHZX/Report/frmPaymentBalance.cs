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
using Microsoft.Reporting.WinForms;
using Common;
using BLL.IBLL.HHZX.Report;
using BLL.Factory.HHZX;

namespace WindowUI.HHZX.Report
{
    public partial class frmPaymentBalance : BaseForm
    {
        private IPaymentBalanceBL _ipbBL;

        public frmPaymentBalance()
        {
            InitializeComponent();

            _ipbBL = MasterBLLFactory.GetBLL<IPaymentBalanceBL>(MasterBLLFactory.PaymentBalance);
        }

        public void ShowForm(CardUserMaster_cus_Info info)
        {
            this.ShowDialog();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                PaymentBalance_Info info = new PaymentBalance_Info();

                if (this.rspSearch.RSP_IsAllTech)
                {
                    info.cus_cIdentityNum = Common.DefineConstantValue.CodeMasterDefine.KEY2_SIOT_CardUserIdentity_Staff;
                }
                else if (this.rspSearch.RSP_IsAllStu)
                {
                    info.cus_cIdentityNum = Common.DefineConstantValue.CodeMasterDefine.KEY2_SIOT_CardUserIdentity_Student;
                }
                else if (!this.rspSearch.RSP_IsAllTech && !this.rspSearch.RSP_IsAllStu)
                {
                    if (this.rspSearch.RSP_ClassID != Guid.Empty)
                    {
                        info.cus_cIdentityNum = Common.DefineConstantValue.CodeMasterDefine.KEY2_SIOT_CardUserIdentity_Student;
                        info.ClassID = this.rspSearch.RSP_ClassID;
                    }
                    else if (this.rspSearch.RSP_DepartmentID != Guid.Empty)
                    {
                        info.cus_cIdentityNum = Common.DefineConstantValue.CodeMasterDefine.KEY2_SIOT_CardUserIdentity_Staff;
                        info.ClassID = this.rspSearch.RSP_DepartmentID;
                    }
                }

                string strTimeFrom = this.rspSearch.RSP_TimeFrom.ToString("yyyy-MM-dd");
                string strTimeTo = this.rspSearch.RSP_TimeTo.ToString("yyyy-MM-dd");
                if (ckbUseTimeSpan.Checked)
                {
                    strTimeFrom += dtpTimeFrom.Value.ToString(" HH:mm:ss");
                    strTimeTo += dtpTimeTo.Value.ToString(" HH:mm:ss");
                }
                else
                {
                    strTimeFrom += " 00:00:00";
                    strTimeTo += " 23:59:59";
                }

                info.TimeFrom = DateTime.Parse(strTimeFrom);
                //info.TimeTo = this.rspSearch.RSP_TimeTo.AddDays(1);
                info.TimeTo = DateTime.Parse(strTimeTo);
                info.cus_cStudentID = this.rspSearch.RSP_StudentID;
                info.cus_cChaName = this.rspSearch.RSP_ChaName;
                try
                {
                    info.MacNo = this.nbbMachenNo.DecimalValue.ToString();
                }
                catch
                {

                }

                bool bChkMac = ckbMacRec.Checked;
                bool bChkPreCost = ckbPreCostRec.Checked;
                if (!string.IsNullOrEmpty(nbbMachenNo.Text))
                {
                    if (bChkPreCost)
                    {
                        bChkPreCost = false;
                    }
                }
                List<PaymentBalance_Info> infoList = _ipbBL.SearchRecords(info, bChkMac, bChkPreCost);
                if (infoList != null && infoList.Count > 0)
                {
                    infoList = infoList.OrderBy(p => p.csr_dConsumeDate).OrderBy(p => p.csm_cClassName).ToList();
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

        private void ShowReport(List<PaymentBalance_Info> objList)
        {
            ReportDataSource rds = new ReportDataSource("PaymentBalance_Info", objList);

            rpvMain.LocalReport.ReportPath = DefineConstantValue.ReportFileBasePath + @"PaymentBalance.rdlc";

            rpvMain.LocalReport.DataSources.Clear();

            rpvMain.LocalReport.DataSources.Add(rds);

            this.rpvMain.RefreshReport();
        }

        private void ckbMacRec_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbMacRec.Checked)
            {
                nbbMachenNo.Enabled = true;
            }
            else
            {
                nbbMachenNo.Enabled = false;
                nbbMachenNo.Text = string.Empty;
            }
        }

        private void ckbUseTimeSpan_CheckedChanged(object sender, EventArgs e)
        {
            pnlTimeSpan.Enabled = ckbUseTimeSpan.Checked;
        }
    }
}
