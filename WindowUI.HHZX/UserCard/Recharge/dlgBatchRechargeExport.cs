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

namespace WindowUI.HHZX.UserCard.Recharge
{
    public partial class dlgBatchRechargeExport : BaseForm
    {
        IGeneralBL _IGeneralBL;

        private Thread _InvokeDialogThread;

        private DialogResult _DlgResult;

        public dlgBatchRechargeExport()
        {
            InitializeComponent();

            this._IGeneralBL = GeneralBLLFactory.GetBLL<IGeneralBL>(GeneralBLLFactory.General);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            BindCombox();
        }

        private void BindCombox()
        {
            List<IModelObject> result = new List<IModelObject>();
            try
            {
                result = this._IGeneralBL.GetMasterDataInformations(DefineConstantValue.MasterType.CodeMaster_Key2, DefineConstantValue.CodeMasterDefine.KEY1_SIOT_CardUserIdentity);
            }
            catch (Exception Ex)
            {
                ShowErrorMessage(Ex);
            }

            cbbTempleType.SetDataSource(result);
            cbbTempleType.SelectItemForValue(string.Empty);
        }

        /// <summary>
        /// 插入数据到工作表
        /// </summary>
        /// <param name="excelUtil">源工作表文件</param>
        /// <param name="sheetIndex">工作表索引</param>
        /// <param name="startCell">开始单元</param>
        /// <param name="cb">数据源</param>
        private void AddDataToSheet(ExcelUtil excelUtil, int sheetIndex, string startCell, List<IModelObject> cb)
        {
            int temp = 0;

            foreach (ComboboxDataInfo item in cb)
            {
                temp++;
                excelUtil.AddValueToCell(sheetIndex, temp, 1, item.DisplayMember);
                excelUtil.AddValueToCell(sheetIndex, temp, 2, item.ValueMember);
            }
        }

        /// <summary>
        /// 插入数据到工作表
        /// </summary>
        /// <param name="excelUtil">源工作表文件</param>
        /// <param name="sheetIndex">工作表索引</param>
        /// <param name="cb">数据源</param>
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

        /// <summary>
        /// 导出模板
        /// </summary>
        /// <param name="xlsSavePath">文件保存路径</param>
        private void ExportTemplate(string xlsSavePath)
        {
            ExcelUtil excelUtil = null;
            try
            {
                excelUtil = new ExcelUtil();

                excelUtil.Open(Application.StartupPath + "/ExcelTemplate/TransferBatchRecharge.xls");
                bgWorker.ReportProgress(10);

                List<Model.IModel.IModelObject> sexList = this._IGeneralBL.GetMasterDataInformations(DefineConstantValue.MasterType.CardUserSex);

                AddDataToStuSheet(excelUtil, 2, sexList);

                bgWorker.ReportProgress(30);

                List<Model.IModel.IModelObject> classList = this._IGeneralBL.GetMasterDataInformations(DefineConstantValue.MasterType.UserClass);

                AddDataToStuSheet(excelUtil, 3, classList);

                bgWorker.ReportProgress(90);
                excelUtil.SaveCopyAs(xlsSavePath);
                excelUtil.Close();
                bgWorker.ReportProgress(100);

                ShowInformationMessage("导出成功。");
            }
            catch (Exception ex)
            {
                ShowInformationMessage("导出错误，请联系管理员。错误原因：" + ex.Message);
            }
            finally
            {
                try
                {
                    if (excelUtil != null)
                    {
                        excelUtil.Close();
                    }
                }
                catch (Exception)
                { }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            dlgSaveFile = new SaveFileDialog();
            dlgSaveFile.Filter = "Microsoft Office 97-2003 Excle文件(*.xls)|*.xls|所有文件(*.*)|*.*";
            dlgSaveFile.FileName = cbbTempleType.Text + "批量充值模板.xls";

            string strXlsSavePath = string.Empty;

            ///開啟保存對話框線程
            this._InvokeDialogThread = new Thread(new ThreadStart(InvokeMethod));
            this._InvokeDialogThread.SetApartmentState(ApartmentState.STA);
            this._InvokeDialogThread.Start();
            this._InvokeDialogThread.Join();

            if (this._DlgResult == DialogResult.OK && !string.IsNullOrEmpty(dlgSaveFile.FileName))
            {
                strXlsSavePath = dlgSaveFile.FileName;

                progressBar.Visible = true;

                bgWorker.RunWorkerAsync(strXlsSavePath);
            }
            else
            {
                if (this._DlgResult == DialogResult.OK)
                {
                    DialogResult resutl = MessageBox.Show("请填写文件名称。", "系统提示", MessageBoxButtons.OKCancel);

                    if (resutl == DialogResult.Cancel)
                    {
                        this.Close();
                    }
                }
            }

            progressBar.Visible = true;
        }

        private void InvokeMethod()
        {
            this._DlgResult = dlgSaveFile.ShowDialog();
        }

        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            bgWorker.ReportProgress(5);

            ExportTemplate(e.Argument.ToString());
        }

        private void bgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
        }

        private void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar.Visible = false;
        }
    }
}
