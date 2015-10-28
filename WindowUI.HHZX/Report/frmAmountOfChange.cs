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
using Model.HHZX.ComsumeAccount;
using BLL.IBLL.HHZX.ConsumeAccount;
using BLL.Factory.HHZX;
using Model.HHZX.Report;
using Microsoft.Reporting.WinForms;
using Common;

namespace WindowUI.HHZX.Report
{
    public partial class frmAmountOfChange : BaseForm
    {
        RechargeRecord_rcr_Info _info;

        IRechargeRecordBL _rechargeRecordBL;

        public frmAmountOfChange()
        {
            InitializeComponent();

            this._info = null;

            this._rechargeRecordBL = MasterBLLFactory.GetBLL<IRechargeRecordBL>(MasterBLLFactory.RechargeRecord);
        }


        private void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                AmountOfChange_aoc_Info query = new AmountOfChange_aoc_Info();

                query.startDate = this.rspSearch.RSP_TimeFrom;
                query.endDate = this.rspSearch.RSP_TimeTo;
                query.cus_cStudentID = this.rspSearch.RSP_StudentID;
                query.aoc_cName = this.rspSearch.RSP_ChaName;
                query.IsRechargeTransfer = this.chbRechargeTransfer.Checked;
                query.IsRefundTransfer = this.chbArther.Checked;

                if (this.rspSearch.RSP_IsAllTech)//是否限制为教师身份
                {
                    query.cus_cIdentityNum = Common.DefineConstantValue.CodeMasterDefine.KEY2_SIOT_CardUserIdentity_Staff;
                }
                else if (this.rspSearch.RSP_IsAllStu)//是否限制为学生身份
                {
                    query.cus_cIdentityNum = Common.DefineConstantValue.CodeMasterDefine.KEY2_SIOT_CardUserIdentity_Student;
                }
                else if (!this.rspSearch.RSP_IsAllTech && !this.rspSearch.RSP_IsAllStu)
                {
                    if (this.rspSearch.RSP_ClassID != Guid.Empty)
                    {
                        query.cus_cIdentityNum = Common.DefineConstantValue.CodeMasterDefine.KEY2_SIOT_CardUserIdentity_Student;
                        query.classID = this.rspSearch.RSP_ClassID;
                    }
                    else if (this.rspSearch.RSP_DepartmentID != Guid.Empty)
                    {
                        query.cus_cIdentityNum = Common.DefineConstantValue.CodeMasterDefine.KEY2_SIOT_CardUserIdentity_Staff;
                        query.classID = this.rspSearch.RSP_DepartmentID;
                    }
                }

                query.selectMenu = string.Empty;//充值类型条件

                if (this.chbPersonalCash.Checked)//现金退款
                {
                    query.selectMenu += "'" + DefineConstantValue.ConsumeMoneyFlowType.Refund_PersonalCash.ToString() + "'" + Environment.NewLine;
                }

                if (this.chbPersonalRealTime.Checked)//个人实时充值
                {
                    if (!String.IsNullOrEmpty(query.selectMenu))
                    {
                        query.selectMenu += "," + Environment.NewLine;
                    }
                    query.selectMenu += "'" + DefineConstantValue.ConsumeMoneyFlowType.Recharge_PersonalRealTime.ToString() + "'" + Environment.NewLine;
                }
                if (this.chbArther.Checked)//其他款项
                {
                    if (!String.IsNullOrEmpty(query.selectMenu))
                    {
                        query.selectMenu += "," + Environment.NewLine;
                    }
                    query.selectMenu += "'" + DefineConstantValue.ConsumeMoneyFlowType.Refund_CardPersonalRealTime.ToString() + "'" + Environment.NewLine;
                    //query.selectMenu += "," + Environment.NewLine;
                    //query.selectMenu += "'" + DefineConstantValue.ConsumeMoneyFlowType.Refund_PersonalTransfer.ToString() + "'" + Environment.NewLine;
                    //query.selectMenu += "," + Environment.NewLine;
                    //query.selectMenu += "'" + DefineConstantValue.ConsumeMoneyFlowType.Refund_BatchTransfer.ToString() + "'" + Environment.NewLine;
                }

                List<AmountOfChange_aoc_Info> sources = this._rechargeRecordBL.AccountDetailList(query);

                if (sources != null && sources.Count > 0)
                {
                    sources = sources.OrderByDescending(p => p.aoc_opTime).ToList();

                    ShowReport(sources);
                }
                else
                {
                    rpvMain.LocalReport.DataSources.Clear();
                    rpvMain.RefreshReport();
                    ShowWarningMessage("找不到符合条件的记录。");
                }
            }
            catch
            {

            }

            this.Cursor = Cursors.Default;
        }

        private void ShowReport(List<AmountOfChange_aoc_Info> infoList)
        {
            ReportDataSource rds = new ReportDataSource("Model_HHZX_Report_AmountOfChange_aoc_Info", infoList);

            rpvMain.LocalReport.ReportPath = DefineConstantValue.ReportFileBasePath + @"AmountOfChangeDetail.rdlc";

            rpvMain.LocalReport.DataSources.Clear();

            rpvMain.LocalReport.DataSources.Add(rds);

            this.rpvMain.RefreshReport();
        }
    }
}
