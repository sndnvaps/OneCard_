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
using BLL.IBLL.HHZX.ConsumeAccount;
using BLL.Factory.HHZX;
using Model.HHZX.ComsumeAccount;
using Microsoft.Reporting.WinForms;
using Common;

namespace WindowUI.HHZX.Report
{
    public partial class frmRemind : BaseForm
    {

        ICardUserAccountBL _cardUserAccountBL;

        IGeneralBL _generalBL;

        public frmRemind()
        {
            InitializeComponent();

            this._generalBL = GeneralBLLFactory.GetBLL<IGeneralBL>(GeneralBLLFactory.General);

            this._cardUserAccountBL = MasterBLLFactory.GetBLL<ICardUserAccountBL>(MasterBLLFactory.CardUserAccount);

        }

        private void BindBoxIdentity()
        {
            try
            {
                List<Model.IModel.IModelObject> identity = this._generalBL.GetMasterDataInformations(Common.DefineConstantValue.MasterType.CardUserIdentity);

                cbxIdentity.SetDataSource(identity);

                cbxIdentity.SelectItemForValue("");
            }
            catch (Exception Ex)
            {

                ShowErrorMessage(Ex.Message);
            }
        }

        public void ShowForm()
        {

            this.ShowDialog();


        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbxIdentity.SelectedValue != null && cbxIdentity.SelectedValue.ToString() != string.Empty)
                {
                    decimal money = 0;

                    if (!string.IsNullOrEmpty(txtMoney.Text))
                    {
                        money = Convert.ToDecimal(txtMoney.Text);
                    }

                    Guid classID = Guid.Empty;

                    if (cbxClass.SelectedValue != null && cbxClass.SelectedValue.ToString() != string.Empty)
                    {
                        classID = new Guid(cbxClass.SelectedValue.ToString());
                    }

                    string strUserName = tbxName.Text;

                    try
                    {
                        this.Cursor = Cursors.WaitCursor;

                        List<CardUserAccount_cua_Info> sources = this._cardUserAccountBL.GetRemindList(cbxIdentity.SelectedValue.ToString(), classID, money, cbxFilter.Checked, strUserName);
                        if (ckbPreRecharge.Checked)
                        {
                            sources = sources.Where(x => x.PreRechargeMoney > 0).ToList();
                        }

                        if (sources != null && sources.Count > 0)
                        {
                            //sources = sources.OrderBy(p => p.cus_cStudentID).OrderBy(p => p.cua_fCurrentBalance).ToList();
                            sources = sources.OrderBy(p => p.cua_cClassName).ToList();
                            List<CardUserAccount_cua_Info> listRemind = new List<CardUserAccount_cua_Info>();
                            IEnumerable<IGrouping<string, CardUserAccount_cua_Info>> groupRemind = sources.GroupBy(x => x.cua_cClassName);
                            foreach (var item in groupRemind)
                            {
                                List<CardUserAccount_cua_Info> listQueryItem = item.OrderBy(p => p.cus_cStudentID).ToList();
                                listRemind.AddRange(listQueryItem);
                            }

                            ShowReport(sources);
                        }
                        else
                        {
                            ShowWarningMessage("找不到符合条件的记录。");
                        }
                    }
                    catch (Exception Ex)
                    {

                        ShowErrorMessage(Ex.Message);
                    }
                    this.Cursor = Cursors.Default;
                }
                else
                {
                    ShowWarningMessage("请选择身份。");
                }
            }
            catch (Exception exMain)
            {
                ShowErrorMessage(exMain);
            }

        }

        private void cbxIdentity_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbxIdentity.SelectedValue != null && cbxIdentity.SelectedValue.ToString() != "")
            {
                cbxClass.Enabled = true;

                btnQuery.Enabled = true;

                List<Model.IModel.IModelObject> sources = null;

                try
                {
                    if (cbxIdentity.SelectedValue.ToString() == Common.DefineConstantValue.CodeMasterDefine.KEY2_SIOT_CardUserIdentity_Staff)
                    {
                        sources = this._generalBL.GetMasterDataInformations(Common.DefineConstantValue.MasterType.UserDepartment);

                    }
                    else
                    {
                        sources = this._generalBL.GetMasterDataInformations(Common.DefineConstantValue.MasterType.UserClass);

                    }

                    cbxClass.SetDataSource(sources);

                    cbxClass.SelectItemForValue(string.Empty);
                }
                catch (Exception Ex)
                {

                    ShowErrorMessage(Ex.Message);
                }
            }
            else
            {
                cbxClass.Enabled = false;
            }
        }

        private void frmRemind_Load(object sender, EventArgs e)
        {
            BindBoxIdentity();
            this.rpvMain.RefreshReport();
        }

        private void ShowReport(List<CardUserAccount_cua_Info> infoList)
        {
            //ReportDataSource rds = new ReportDataSource("Model_HHZX_ComsumeAccount_CardUserAccount_cua_Info", infoList);

            ReportDataSource rds = new ReportDataSource("CardUserAccount_cua_Info", infoList);

            rpvMain.LocalReport.ReportPath = DefineConstantValue.ReportFileBasePath + @"RemindDetail.rdlc";

            rpvMain.LocalReport.DataSources.Clear();

            rpvMain.LocalReport.DataSources.Add(rds);

            this.rpvMain.LocalReport.Refresh();
            this.rpvMain.RefreshReport();
        }
    }
}
