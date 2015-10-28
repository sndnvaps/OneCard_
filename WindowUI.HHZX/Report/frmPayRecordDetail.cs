using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL.IBLL.General;
using BLL.Factory.General;
using WindowUI.HHZX.ClassLibrary.Public;
using BLL.IBLL.HHZX.Report;
using BLL.Factory.HHZX;
using Model.HHZX.Report;
using Model.General;
using Model.SysMaster;

namespace WindowUI.HHZX.Report
{
    public partial class frmPayRecordDetail : BaseForm
    {
        IPayRecordBL _payRecordBL;

        IGeneralBL _generalBL;

        PayRecord_prd_Info _editInfo;

        public frmPayRecordDetail()
        {
            InitializeComponent();

            this._generalBL = GeneralBLLFactory.GetBLL<IGeneralBL>(GeneralBLLFactory.General);

            this._payRecordBL = MasterBLLFactory.GetBLL<IPayRecordBL>(MasterBLLFactory.PayRecord);


        }

        private void BindBox(Common.DefineConstantValue.MasterType mType)
        {
            try
            {
                List<Model.IModel.IModelObject> returnList = this._generalBL.GetMasterDataInformations(mType);

                switch (mType)
                {

                    case Common.DefineConstantValue.MasterType.UserDepartment:

                        cbxPayDepartment.SetDataSource(returnList);

                        cbxPayDepartment.SelectItemForValue("");

                        break;

                    case Common.DefineConstantValue.MasterType.CostType:

                        cbxPayType.SetDataSource(returnList);

                        cbxPayType.SelectItemForValue(string.Empty);

                        break;

                    default:
                        break;
                }
            }
            catch (Exception Ex)
            {

                ShowErrorMessage(Ex.Message);
            }
        }

        public void ShowForm(Sys_UserMaster_usm_Info userInfo, PayRecord_prd_Info showInfo, Common.DefineConstantValue.EditStateEnum statc)
        {
            this.UserInformation = userInfo;

            this._editInfo = showInfo;

            this.EditState = statc;

            this.ShowDialog();

        }

        private bool VaildInput()
        {
            if (cbxPayType.SelectedValue == null)
            {
                ShowWarningMessage("请选择支出项目。");

                return false;
            }

            if (cbxPayDepartment.SelectedValue == null)
            {
                ShowWarningMessage("请选择部门。");

                return false;
            }

            try
            {
                int num;
                num = int.Parse(txtPayMoney.Text.Trim());
            }
            catch
            {
                try
                {
                    float num = float.Parse(txtPayMoney.Text.Trim());
                }
                catch
                {
                    ShowWarningMessage("支出金额输入错误。");

                    txtPayMoney.Focus();

                    return false;
                }
            }

            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ReturnValueInfo returnInfo = new ReturnValueInfo(false);

            if (VaildInput())
            {
                PayRecord_prd_Info objInfo = PageUIData();

                objInfo.prd_cRecordID = this._editInfo.prd_cRecordID;

                try
                {

                    switch (this.EditState)
                    {
                        case Common.DefineConstantValue.EditStateEnum.OE_Insert:
                            returnInfo = this._payRecordBL.Save(objInfo, Common.DefineConstantValue.EditStateEnum.OE_Insert);
                            break;
                        case Common.DefineConstantValue.EditStateEnum.OE_Update:
                            returnInfo = this._payRecordBL.Save(objInfo, Common.DefineConstantValue.EditStateEnum.OE_Update);
                            break;
                        case Common.DefineConstantValue.EditStateEnum.OE_Delete:
                            break;
                        case Common.DefineConstantValue.EditStateEnum.OE_ReaOnly:
                            break;
                        default:
                            break;
                    }

                    if (returnInfo.boolValue)
                    {
                        ShowInformationMessage("保存成功。");

                        this.Close();
                    }
                    else
                    {
                        ShowErrorMessage(returnInfo.messageText);
                    }
                }
                catch (Exception Ex)
                {

                    ShowErrorMessage(Ex.Message);
                }
            }
        }

        private void cls()
        {
            cbxPayDepartment.SelectItemForValue(string.Empty);

            cbxPayType.SelectItemForValue(string.Empty);

            txtCertificateID.Text = string.Empty;

            this.txtPayMoney.Text = string.Empty;
        }

        private PayRecord_prd_Info PageUIData()
        {
            PayRecord_prd_Info objInfo = new PayRecord_prd_Info();

            objInfo.prd_cPayType = cbxPayType.SelectedValue.ToString();

            objInfo.prd_cDepartmentID = new Guid(cbxPayDepartment.SelectedValue.ToString());

            objInfo.prd_cCertificateID = txtCertificateID.Text;

            objInfo.prd_dCertificateDate = dtpCertificateDate.Value;

            objInfo.prd_fPayMoney = Convert.ToDecimal(txtPayMoney.Text.Trim());

            objInfo.prd_cAdd = this.UserInformation.usm_cUserLoginID;

            objInfo.prd_cLast = this.UserInformation.usm_cUserLoginID;

            objInfo.prd_iPayCount = Convert.ToInt32(nbxCount.Text);

            return objInfo;
        }

        private void ShowDataToUI(PayRecord_prd_Info showInfo)
        {
            if (showInfo != null)
            {
                cbxPayType.SelectItemForValue(showInfo.prd_cPayType);

                cbxPayDepartment.SelectItemForValue(showInfo.prd_cDepartmentID.ToString());

                txtCertificateID.Text = showInfo.prd_cCertificateID;

                dtpCertificateDate.Value = showInfo.prd_dCertificateDate;

                txtPayMoney.Text = showInfo.prd_fPayMoney.ToString();

                nbxCount.Text = showInfo.prd_iPayCount.ToString();
            }
        }

        private void frmPayRecordDetail_Load(object sender, EventArgs e)
        {
            BindBox(Common.DefineConstantValue.MasterType.UserDepartment);

            BindBox(Common.DefineConstantValue.MasterType.CostType);

            if (this.EditState == Common.DefineConstantValue.EditStateEnum.OE_Update)
            {
                this._editInfo = this._payRecordBL.DisplayRecord(this._editInfo) as PayRecord_prd_Info;

                ShowDataToUI(this._editInfo);
            }
        }


    }
}
