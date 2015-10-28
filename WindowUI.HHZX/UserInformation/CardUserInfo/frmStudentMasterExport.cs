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
using Common;
using Model.IModel;
using WindowUI.HHZX.ClassLibrary.Public;
using BLL.IBLL.HHZX.UserInfomation.CardUserInfo;
using BLL.Factory.HHZX;
using Model.HHZX.UserInfomation.CardUserInfo;
using Common.Util;
using Model.General;
using System.Threading;

namespace WindowUI.HHZX.UserInformation.CardUserInfo
{
    public partial class dlgBatchRechargeExport : BaseForm
    {
        IGeneralBL _generalBL;

        private Thread invokeDialogThread;

        private DialogResult result;

        public dlgBatchRechargeExport()
        {
            InitializeComponent();

            this._generalBL = GeneralBLLFactory.GetBLL<IGeneralBL>(GeneralBLLFactory.General);

        }

        private void BindCombox(DefineConstantValue.MasterType mType)
        {
            List<IModelObject> result = new List<IModelObject>();
            try
            {
                result = _generalBL.GetMasterDataInformations(mType);
            }
            catch (Exception Ex)
            {
                ShowErrorMessage(Ex);
            }
            switch (mType)
            {


                case DefineConstantValue.MasterType.UserClass:
                    cboClass.SetDataSource(result);
                    cboClass.SelectItemForValue("");
                    break;

                default:
                    break;
            }
        }

        private void frmStudentMasterExport_Load(object sender, EventArgs e)
        {
            BindCombox(DefineConstantValue.MasterType.UserClass);
        }

        private void AddDataToSheet(ExcelUtil excelUtil, int sheetIndex, string startCell, List<IModelObject> cb)
        {
            int temp = 0;
            //  StringBuilder dataBuilder = new StringBuilder();
            // string data = "";

            foreach (ComboboxDataInfo item in cb)
            {
                temp++;
                excelUtil.AddValueToCell(sheetIndex, temp, 1, item.DisplayMember);
                excelUtil.AddValueToCell(sheetIndex, temp, 2, item.ValueMember);
                // dataBuilder.Append(item.DisplayMember).Append(",");
            }
            //  Microsoft.Office.Interop.Excel.Range rang = excelUtil.GetRange(startCell, startCell).get_Resize(10000, 1);
            //  data = dataBuilder.ToString();
            //  excelUtil.AddValidation(rang, data.Substring(0, data.Length - 1));
        }

        private void AddDataToStuSheet(ExcelUtil excelUtil, int sheetIndex, List<IModelObject> cb)
        {

            int temp = 0;

            foreach (ComboboxDataInfo item in cb)
            {
                temp++;
                excelUtil.AddValueToCell(sheetIndex, temp, 1, item.DisplayMember);
                excelUtil.AddValueToCell(sheetIndex, temp, 2, item.ValueMember);
            }

        }

        private void ExportTemplate(string xlsSavePath)
        {
            ExcelUtil excelUtil = null;
            try
            {

                excelUtil = new ExcelUtil();

                excelUtil.Open(Application.StartupPath + "/ExcelTemplate/studentModel.xls");
                backgroundWorker1.ReportProgress(10);
                //excelUtil.AddValueToCell(5,1,"simon");

                List<Model.IModel.IModelObject> sexList = _generalBL.GetMasterDataInformations(DefineConstantValue.MasterType.CardUserSex);

                AddDataToStuSheet(excelUtil, 2, sexList);

                backgroundWorker1.ReportProgress(30);

                List<Model.IModel.IModelObject> classList = _generalBL.GetMasterDataInformations(DefineConstantValue.MasterType.UserClass);

                AddDataToStuSheet(excelUtil, 3, classList);

                backgroundWorker1.ReportProgress(90);
                excelUtil.SaveCopyAs(xlsSavePath);
                excelUtil.Close();
                backgroundWorker1.ReportProgress(100);
                ShowInformationMessage("导出成功。");
                //this.Close();
            }
            catch (Exception ex)
            {
                ShowInformationMessage("导出错误，请联系管理员。错误原因：" + ex.Message);

            }
            finally
            {
                //add by justinleung 2011/09/06
                if (excelUtil != null)
                {
                    excelUtil.Close();
                }
                //this.Close();
            }

        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Excle文件(*.xls)|*.xls|所有文件(*.*)|*.*";

            string xlsSavePath = "";

            ///開啟保存對話框線程
            invokeDialogThread = new Thread(new ThreadStart(InvokeMethod));
            invokeDialogThread.SetApartmentState(ApartmentState.STA);
            invokeDialogThread.Start();
            invokeDialogThread.Join();

            if (result == DialogResult.OK && saveFileDialog1.FileName != "")
            {
                xlsSavePath = saveFileDialog1.FileName;

                progressBar1.Visible = true;

                backgroundWorker1.RunWorkerAsync(xlsSavePath);
            }
            else
            {
                if (result == DialogResult.OK)
                {
                    DialogResult resutl = MessageBox.Show("请填写文件名称。", "系统提示", MessageBoxButtons.OKCancel);
                    if (resutl == DialogResult.Cancel)
                    {
                        this.Close();
                    }
                }
            }


            progressBar1.Visible = true;


        }

        private void InvokeMethod()
        {
            result = saveFileDialog1.ShowDialog();
        }


        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            backgroundWorker1.ReportProgress(5);
            ExportTemplate(e.Argument.ToString());
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar1.Visible = false;
        }
    }
}
