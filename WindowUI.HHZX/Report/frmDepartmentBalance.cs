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
using BLL.IBLL.HHZX.ConsumeAccount;
using BLL.Factory.HHZX;
using Model.HHZX.Report;
using Microsoft.Reporting.WinForms;
using Common;
using Model.General;

namespace WindowUI.HHZX.Report
{
    public partial class frmDepartmentBalance : BaseForm
    {
        ISystemAccountDetailBL _systemAccountDetailBL;

        DepartmentBalance_dtb_Info _info;

        public frmDepartmentBalance()
        {
            InitializeComponent();

            this._systemAccountDetailBL = MasterBLLFactory.GetBLL<ISystemAccountDetailBL>(MasterBLLFactory.SystemAccountDetail);

            this._info = new DepartmentBalance_dtb_Info();

            this.lblHotWaterIncome.Text = "0.00";
            this.lblOrtherIncome.Text = "0.00";
            this.nbxHotIncome.Text = this.lblHotWaterIncome.Text;
            this.nbxOrtherIncome.Text = this.lblHotWaterIncome.Text;
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                this._info.startDate = this.rspSearch.RSP_TimeFrom;

                this._info.endDate = this.rspSearch.RSP_TimeTo;

                this._info = this._systemAccountDetailBL.DepartmentBalance(this._info);

                List<DepartmentBalance_dtb_Info> source = new List<DepartmentBalance_dtb_Info>();

                if (_info != null)
                {
                    source.Add(this._info);

                    ShowReport(source);
                }
                else
                {
                    ShowWarningMessage("找不到符合条件的记录。");
                }
            }
            catch (Exception)
            {
                ShowWarningMessage("查询失败，请重试。");
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void ShowReport(List<DepartmentBalance_dtb_Info> infoList)
        {
            try
            {
                ReportDataSource rds = new ReportDataSource("DepartmentBalance_dtb_Info", infoList);

                rpvMain.LocalReport.ReportPath = DefineConstantValue.ReportFileBasePath + @"DepartmentBalance.rdlc";

                rpvMain.LocalReport.DataSources.Clear();

                rpvMain.LocalReport.DataSources.Add(rds);

                this.rpvMain.RefreshReport();
            }
            catch (Exception ex)
            {
                this.ShowWarningMessage("查询失败，请稍后重试。");
            }
        }

        private void frmDepartmentBalance_Load(object sender, EventArgs e)
        {
            this.rpvMain.RefreshReport();
        }

        private void btnQueryOIncome_Click(object sender, EventArgs e)
        {
            decimal fHotIncome = this._systemAccountDetailBL.GetHotIncome(dtpOrderIncome.Value.Date);
            decimal fOrtherIncome = this._systemAccountDetailBL.GetOrtherIncome(dtpOrderIncome.Value.Date);
            this.lblHotWaterIncome.Text = Math.Round(fHotIncome, 2).ToString();
            this.lblOrtherIncome.Text = Math.Round(fOrtherIncome, 2).ToString();
        }

        private void btnDeleteOIncome_Click(object sender, EventArgs e)
        {
            ReturnValueInfo rvHotIncome = this._systemAccountDetailBL.SetHotIncome(dtpOrderIncome.Value.Date, decimal.Zero);
            ReturnValueInfo rvOrtherIncome = this._systemAccountDetailBL.SetOrtherIncome(dtpOrderIncome.Value.Date, decimal.Zero);
            if (!rvHotIncome.isError && !rvOrtherIncome.isError)
            {
                this.ShowInformationMessage(dtpOrderIncome.Value.Date.ToString("yyyy年MM月dd日") + "收入删除成功。");
            }
            else
            {
                string strErrHot = dtpOrderIncome.Value.Date.ToString("yyyy年MM月dd日，热水收入删除失败。");
                string strErrOrther = dtpOrderIncome.Value.Date.ToString("yyyy年MM月dd日，其他收入删除失败。");
                string strErrAll = dtpOrderIncome.Value.Date.ToString("yyyy年MM月dd日，收入删除失败。");
                if (rvHotIncome.isError && !rvOrtherIncome.isError)
                {
                    this.ShowWarningMessage(strErrHot);
                }
                else if (!rvHotIncome.isError && rvOrtherIncome.isError)
                {
                    this.ShowWarningMessage(strErrOrther);
                }
                else
                {
                    this.ShowWarningMessage(strErrAll);
                }
            }
            btnQueryOIncome_Click(null, null);
        }

        private void btnSaveOIncome_Click(object sender, EventArgs e)
        {
            ReturnValueInfo rvHotIncome = this._systemAccountDetailBL.SetHotIncome(dtpOrderIncome.Value.Date, decimal.Parse(this.nbxHotIncome.Text.Trim()));
            ReturnValueInfo rvOrtherIncome = this._systemAccountDetailBL.SetOrtherIncome(dtpOrderIncome.Value.Date, decimal.Parse(this.nbxOrtherIncome.Text.Trim()));
            if (!rvHotIncome.isError && !rvOrtherIncome.isError)
            {
                this.ShowInformationMessage(dtpOrderIncome.Value.Date.ToString("yyyy年MM月dd日") + "收入保存成功。");
            }
            else
            {
                string strErrHot = dtpOrderIncome.Value.Date.ToString("yyyy年MM月dd日，热水收入保存失败。");
                string strErrOrther = dtpOrderIncome.Value.Date.ToString("yyyy年MM月dd日，其他收入保存失败。");
                string strErrAll = dtpOrderIncome.Value.Date.ToString("yyyy年MM月dd日，收入保存失败。");
                if (rvHotIncome.isError && !rvOrtherIncome.isError)
                {
                    this.ShowWarningMessage(strErrHot);
                }
                else if (!rvHotIncome.isError && rvOrtherIncome.isError)
                {
                    this.ShowWarningMessage(strErrOrther);
                }
                else
                {
                    this.ShowWarningMessage(strErrAll);
                }
            }
            btnQueryOIncome_Click(null, null);
        }

        private void lblHotWaterIncome_TextChanged(object sender, EventArgs e)
        {
            Label lblSource = sender as Label;
            this.nbxHotIncome.Text = lblSource.Text;
        }

        private void lblOrtherIncome_TextChanged(object sender, EventArgs e)
        {
            Label lblSource = sender as Label;
            this.nbxOrtherIncome.Text = lblSource.Text;
        }

        private void dtpOrderIncome_ValueChanged(object sender, EventArgs e)
        {
            btnQueryOIncome_Click(null, null);
        }
    }
}
