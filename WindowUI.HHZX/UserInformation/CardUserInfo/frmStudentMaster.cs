using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WindowUI.HHZX.ClassLibrary.Public;
using Model.TestModel;
using BLL.IBLL.General;
using BLL.Factory.General;
using Model.IModel;
using Common;
using Model.HHZX.UserInfomation.CardUserInfo;
using Model.General;
using BLL.IBLL.HHZX.UserInfomation.CardUserInfo;
using BLL.Factory.HHZX;
using System.Threading;
using Common.Util;
using BLL.IBLL.HHZX.UserCard;
using Model.HHZX.UserCard;

namespace WindowUI.HHZX.UserInformation.CardUserInfo
{

    public partial class frmStudentMaster : BaseForm
    {
        #region 自定义变量

        Thread _InvokeDialogThread;

        DialogResult _Result;

        IGeneralBL _IGeneralBL;
        ICardUserMasterBL _ICardUserMasterBL;
        IUserCardPairBL _IUserCardPairBL;

        bool _IsBatchModify;

        /// <summary>
        /// 缓存中的查询学生记录
        /// </summary>
        List<CardUserMaster_cus_Info> _ListQueryStuInfo;

        #endregion

        public frmStudentMaster()
        {
            InitializeComponent();

            this._ListQueryStuInfo = new List<CardUserMaster_cus_Info>();

            this._IGeneralBL = GeneralBLLFactory.GetBLL<IGeneralBL>(GeneralBLLFactory.General);

            this._ICardUserMasterBL = MasterBLLFactory.GetBLL<ICardUserMasterBL>(MasterBLLFactory.CardUserMaster);
            this._IUserCardPairBL = MasterBLLFactory.GetBLL<IUserCardPairBL>(MasterBLLFactory.UserCardPair);
        }

        void bindComboBox(DefineConstantValue.MasterType mType)
        {
            List<IModelObject> result = new List<IModelObject>();
            try
            {
                result = this._IGeneralBL.GetMasterDataInformations(mType);
            }
            catch (Exception Ex)
            {
                ShowErrorMessage(Ex);
            }
            switch (mType)
            {
                case DefineConstantValue.MasterType.CardUserSex:
                    cboSex.SetDataSource(result, 0);
                    cboSex.SelectItemForValue(string.Empty);
                    break;
                case DefineConstantValue.MasterType.UserClass:
                    cboClass.SetDataSource(result, 0);
                    cboClass.SelectItemForValue(string.Empty);
                    break;
                default:
                    break;
            }
        }

        private void frmStudentMaster_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;

            bindComboBox(DefineConstantValue.MasterType.Grade);
            bindComboBox(DefineConstantValue.MasterType.UserClass);
            bindComboBox(DefineConstantValue.MasterType.CardUserSex);

            if (this.UserInformation != null && (this.UserInformation.usm_cUserLoginID == "sa" || this.UserInformation.usm_cUserLoginID == "donaldhuang"))
            {
                btnBatchModifyDetail.Visible = true;
            }
            else
            {
                btnBatchModifyDetail.Visible = false;
            }
        }

        private void ShowDetailForm(Common.DefineConstantValue.EditStateEnum editStatc)
        {
            frmStudentMasterDetailNew frmNew = new frmStudentMasterDetailNew();
            frmNew.UserInformation = this.UserInformation;

            ReturnValueInfo rvInfo = new ReturnValueInfo(false);

            CardUserMaster_cus_Info objInfo = new CardUserMaster_cus_Info();

            if (editStatc == DefineConstantValue.EditStateEnum.OE_Update)
            {
                if (lvStudentList.SelectedItems.Count > 0)
                {
                    if (this._IsBatchModify)
                    {
                        //frmNew.ShowForm(null, Common.DefineConstantValue.EditStateEnum.OE_Insert, _IsBatchModify);
                    }
                    else
                    {
                        try
                        {
                            objInfo.cus_cRecordID = new Guid(lvStudentList.SelectedItems[0].SubItems[0].Text);

                            objInfo = this._ICardUserMasterBL.DisplayRecord(objInfo) as CardUserMaster_cus_Info;

                            objInfo.cus_cLast = this.UserInformation.usm_cUserLoginID;

                            frmNew.ShowForm(objInfo, Common.DefineConstantValue.EditStateEnum.OE_Update);
                        }
                        catch (Exception Ex)
                        {
                            ShowErrorMessage(Ex.Message);
                        }
                    }
                }
            }
            else
            {
                frmNew.ShowForm(objInfo, Common.DefineConstantValue.EditStateEnum.OE_Insert);
            }
        }

        private void sysToolBar_OnItemModify_Click(object sender, EventArgs e)
        {
            if (_IsBatchModify)
            {
                if (lvStudentList.CheckedItems != null && lvStudentList.CheckedItems.Count > 0)
                {
                    frmStudentMasterDetailNew frmNew = new frmStudentMasterDetailNew();
                    frmNew.UserInformation = this.UserInformation;

                    List<CardUserMaster_cus_Info> editInfos = new List<CardUserMaster_cus_Info>();

                    foreach (ListViewItem item in lvStudentList.CheckedItems)
                    {
                        CardUserMaster_cus_Info info = new CardUserMaster_cus_Info();

                        info.cus_cRecordID = new Guid(item.SubItems[0].Text);

                        editInfos.Add(info);
                    }

                    frmNew.ShowForm(editInfos);
                }
                else
                {
                    ShowWarningMessage("请先选择学生记录。");
                    ckbSelectAll.Focus();
                }
            }
            else
            {
                ShowDetailForm(Common.DefineConstantValue.EditStateEnum.OE_Update);
            }
        }

        private void sysToolBar_OnItemNew_Click(object sender, EventArgs e)
        {
            ShowDetailForm(Common.DefineConstantValue.EditStateEnum.OE_Insert);
        }

        private void btnBatchmodify_Click(object sender, EventArgs e)
        {
            if (!_IsBatchModify)
            {
                btnBatchmodify.Text = "取消批量修改";
                lvStudentList.CheckBoxes = true;
                ckbSelectAll.Visible = true;
                ckbSelectAll.Checked = false;
                this._IsBatchModify = true;

                pnlFuncArea.Enabled = false;
                pnlQUeryArea.Enabled = false;
                sysToolBar.BtnDelete_IsEnabled = false;
                sysToolBar.BtnModify_IsEnabled = true;
                sysToolBar.BtnNew_IsEnabled = false;
                btnQuery.Enabled = false;
                btnGrauduation.Visible = true;

                lvStudentList.CheckBoxes = true;
                lvStudentList.Columns[0].Width = 22;
            }
            else
            {
                btnBatchmodify.Text = "批量修改";
                if (lvStudentList.CheckedItems.Count > 0)
                {
                    foreach (ListViewItem item in lvStudentList.CheckedItems)
                    {
                        item.Checked = false;
                    }
                }
                lvStudentList.CheckBoxes = false;
                ckbSelectAll.Visible = false;
                ckbSelectAll.Checked = false;
                this._IsBatchModify = false;

                pnlFuncArea.Enabled = true;
                pnlQUeryArea.Enabled = true;
                sysToolBar.BtnDelete_IsEnabled = true;
                sysToolBar.BtnModify_IsEnabled = false;
                sysToolBar.BtnNew_IsEnabled = true;
                btnQuery.Enabled = true;
                btnGrauduation.Visible = false;

                lvStudentList.CheckBoxes = false;
                lvStudentList.Columns[0].Width = 0;

                btnQuery_Click(null, null);
            }
        }

        private void btnDataImport_Click(object sender, EventArgs e)
        {
            frmImportStudentData isdForm = new frmImportStudentData();
            isdForm.ShowForm(this.UserInformation);
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            SearchStudents();
        }

        private void SearchStudents()
        {
            try
            {
                CardUserMaster_cus_Info queryInfo = new CardUserMaster_cus_Info();

                if (cboClass.SelectedValue != null && !string.IsNullOrEmpty(cboClass.Text))
                {
                    queryInfo.cus_cClassID = new Guid(cboClass.SelectedValue.ToString());
                }
                if (!string.IsNullOrEmpty(tbxStudentID.Text))
                {
                    queryInfo.cus_cStudentID = tbxStudentID.Text.Trim().Replace("'", "''");
                }
                if (!string.IsNullOrEmpty(tbxStudenName.Text))
                {
                    queryInfo.cus_cChaName = tbxStudenName.Text.Trim().Replace("'", "''");
                }
                if (cboSex.SelectedValue != null && !string.IsNullOrEmpty(cboSex.Text))
                {
                    queryInfo.cus_cSexNum = cboSex.SelectedValue.ToString();
                }
                queryInfo.cus_lIsGraduate = cbxVaild.Checked;
                queryInfo.cus_cIdentityNum = Common.DefineConstantValue.CodeMasterDefine.KEY2_SIOT_CardUserIdentity_Student;

                try
                {
                    this.Cursor = Cursors.WaitCursor;

                    List<CardUserMaster_cus_Info> returnList = this._ICardUserMasterBL.SearchRecord_ForMaster(queryInfo);

                    if (returnList != null && returnList.Count > 0)
                    {
                        this._ListQueryStuInfo.Clear();

                        //foreach (CardUserMaster_cus_Info item in returnList)
                        //{
                        //    this._ListQueryStuInfo.Add(item);
                        //}
                        this._ListQueryStuInfo.AddRange(returnList);

                        lvStudentList.Items.Clear();
                        lvStudentList.SetDataSource(returnList);
                        gbxRes.Text = "查询结果：共 " + returnList.Count.ToString() + " 条";

                        ListViewSorter sorter = new ListViewSorter(1, SortOrder.Ascending);
                        lvStudentList.ListViewItemSorter = sorter;
                        lvStudentList.Sorting = SortOrder.Ascending;

                        btnExportGradeUp.Enabled = true;

                        btnBatchmodify.Enabled = true;
                    }
                    else
                    {

                        lvStudentList.Items.Clear();

                        this._ListQueryStuInfo = new List<CardUserMaster_cus_Info>();

                        ShowInformationMessage(Common.DefineConstantValue.SystemMessageText.strMessageText_W_RecordIsEmpty);

                        btnExportGradeUp.Enabled = false;

                        btnBatchmodify.Enabled = false;

                        gbxRes.Text = "查询结果：共 0 条";
                    }
                }
                catch (Exception Ex)
                {
                    ShowErrorMessage(Ex);
                }
            }
            catch (Exception exx)
            {
                ShowErrorMessage(exx);
            }
            this.Cursor = Cursors.Default;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excle文件(*.xls)|*.xls|所有文件(*.*)|*.*";

            string xlsSavePath = "";


            ///開啟保存對話框線程

            _InvokeDialogThread = new Thread(new ThreadStart(InvokeMethod));
            _InvokeDialogThread.SetApartmentState(ApartmentState.STA);
            _InvokeDialogThread.Start();
            _InvokeDialogThread.Join();

            if (_Result == DialogResult.OK && saveFileDialog.FileName != "")
            {
                xlsSavePath = saveFileDialog.FileName;

                progressBar1.Visible = true;

                bgWorkerInfoTemp.RunWorkerAsync(xlsSavePath);
            }
            else
            {
                if (_Result == DialogResult.OK)
                {
                    DialogResult resutl = MessageBox.Show("请填写文件名称。", "系统提示", MessageBoxButtons.OKCancel);
                    if (resutl == DialogResult.Cancel)
                    {
                        this.Close();
                    }


                    progressBar1.Visible = true;
                }
                else
                {
                    progressBar1.Visible = false;
                }
            }


        }

        private void InvokeMethod()
        {
            _Result = saveFileDialog.ShowDialog();
        }

        private void bgWorkerInfoTemp_DoWork(object sender, DoWorkEventArgs e)
        {
            bgWorkerInfoTemp.ReportProgress(5);
            ExportTemplate(e.Argument.ToString());
        }

        private void bgWorkerInfoTemp_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void bgWorkerInfoTemp_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar1.Visible = false;
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
                bgWorkerInfoTemp.ReportProgress(10);
                //excelUtil.AddValueToCell(5,1,"simon");

                List<Model.IModel.IModelObject> sexList = _IGeneralBL.GetMasterDataInformations(DefineConstantValue.MasterType.CardUserSex);

                AddDataToStuSheet(excelUtil, 2, sexList);

                bgWorkerInfoTemp.ReportProgress(30);

                List<Model.IModel.IModelObject> classList = _IGeneralBL.GetMasterDataInformations(DefineConstantValue.MasterType.UserClass);

                AddDataToStuSheet(excelUtil, 3, classList);

                bgWorkerInfoTemp.ReportProgress(90);
                excelUtil.SaveCopyAs(xlsSavePath);
                bgWorkerInfoTemp.ReportProgress(100);
                ShowInformationMessage("导出成功。");
                //this.Close();
            }
            catch (Exception ex)
            {
                ShowInformationMessage("导出错误，请联系管理员。错误原因：" + ex.Message);

                if (excelUtil != null)
                {
                    excelUtil.Close();
                }
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

        private void btnChangeClass_Click(object sender, EventArgs e)
        {
            saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excle文件(*.xls)|*.xls|所有文件(*.*)|*.*";

            string xlsSavePath = "";


            ///開啟保存對話框線程

            _InvokeDialogThread = new Thread(new ThreadStart(InvokeMethod));
            _InvokeDialogThread.SetApartmentState(ApartmentState.STA);
            _InvokeDialogThread.Start();
            _InvokeDialogThread.Join();

            if (_Result == DialogResult.OK && saveFileDialog.FileName != "")
            {
                xlsSavePath = saveFileDialog.FileName;

                progressBar1.Visible = true;

                bgWorkerGradeUpTemp.RunWorkerAsync(xlsSavePath);
            }
            else
            {
                if (_Result == DialogResult.OK)
                {
                    DialogResult resutl = MessageBox.Show("请填写文件名称。", "系统提示", MessageBoxButtons.OKCancel);
                    if (resutl == DialogResult.Cancel)
                    {
                        this.Close();
                    }

                    progressBar1.Visible = true;
                }
                else
                {
                    progressBar1.Enabled = false;
                }
            }



        }

        private void bgWorkerGradeUpTemp_DoWork(object sender, DoWorkEventArgs e)
        {
            bgWorkerGradeUpTemp.ReportProgress(5);
            ExportChangeClassTemplate(e.Argument.ToString());
        }

        private enum ColName
        {
            cus_cRecordID = 1,

            cus_cStudentID = 2,

            cus_cChaName = 3,

            cus_cClassName = 4
        }

        private void ExportChangeClassTemplate(string xlsSavePath)
        {
            ExcelUtil excelUtil = null;
            try
            {

                excelUtil = new ExcelUtil();

                excelUtil.Open(Application.StartupPath + "/ExcelTemplate/studentChangeClass.xls");
                bgWorkerGradeUpTemp.ReportProgress(10);
                //excelUtil.AddValueToCell(5,1,"simon");

                bgWorkerGradeUpTemp.ReportProgress(30);

                List<Model.IModel.IModelObject> classList = _IGeneralBL.GetMasterDataInformations(DefineConstantValue.MasterType.UserClass);

                AddDataToStuSheet(excelUtil, 3, classList);

                int startRow = 3;

                if (this._ListQueryStuInfo != null)
                {
                    foreach (CardUserMaster_cus_Info item in this._ListQueryStuInfo)
                    {
                        excelUtil.AddValueToCell(startRow, (Int32)ColName.cus_cRecordID, item.cus_cRecordID.ToString());

                        excelUtil.AddValueToCell(startRow, (Int32)ColName.cus_cChaName, item.cus_cChaName);

                        excelUtil.AddValueToCell(startRow, (Int32)ColName.cus_cStudentID, item.cus_cStudentID);

                        excelUtil.AddValueToCell(startRow, (Int32)ColName.cus_cClassName, item.ClassName);

                        startRow++;
                    }
                }


                bgWorkerGradeUpTemp.ReportProgress(90);
                excelUtil.SaveCopyAs(xlsSavePath);
                bgWorkerGradeUpTemp.ReportProgress(100);
                ShowInformationMessage("导出成功。");

            }
            catch (Exception ex)
            {
                ShowInformationMessage("导出错误，请联系管理员。错误原因：" + ex.Message);

                if (excelUtil != null)
                {
                    excelUtil.Close();
                }

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

        private void bgWorkerGradeUpTemp_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void bgWorkerGradeUpTemp_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar1.Visible = false;
        }

        private void btnImportGradeUp_Click(object sender, EventArgs e)
        {
            frmImportChangeClassData frm = new frmImportChangeClassData();

            frm.ShowDialog();
        }

        private void lvStudentList_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (lvStudentList.Sorting == SortOrder.Ascending)
            {
                ListViewSorter sorter = new ListViewSorter(e.Column, SortOrder.Descending);
                lvStudentList.ListViewItemSorter = sorter;
                lvStudentList.Sorting = SortOrder.Descending;
            }
            else
            {
                ListViewSorter sorter = new ListViewSorter(e.Column, SortOrder.Ascending);
                lvStudentList.ListViewItemSorter = sorter;
                lvStudentList.Sorting = SortOrder.Ascending;
            }
        }

        private void lvStudentList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvStudentList.SelectedItems.Count > 0)
            {
                sysToolBar.BtnDelete_IsEnabled = true;
                sysToolBar.BtnModify_IsEnabled = true;
                sysToolBar.BtnRefresh_IsEnabled = false;
                sysToolBar.BtnNew_IsEnabled = false;
            }
            else
            {
                sysToolBar.BtnDelete_IsEnabled = false;
                sysToolBar.BtnModify_IsEnabled = false;
                sysToolBar.BtnRefresh_IsEnabled = true;
                sysToolBar.BtnNew_IsEnabled = true;
            }
        }

        private void btnGrauduation_Click(object sender, EventArgs e)
        {
            if (ShowQuestionMessage("是否确认需要将选中的学生状态置为“已毕业”？"))
            {
                if (lvStudentList.CheckedItems.Count > 0)
                {
                    try
                    {
                        if (this._ListQueryStuInfo == null)
                        {
                            ShowWarningMessage("学生信息缓存异常，请重新查询后重试。");
                            return;
                        }
                        List<CardUserMaster_cus_Info> listSelected = new List<CardUserMaster_cus_Info>();
                        foreach (ListViewItem item in lvStudentList.CheckedItems)
                        {
                            CardUserMaster_cus_Info user = this._ListQueryStuInfo.Find(x => x.cus_cRecordID == new Guid(item.SubItems[0].Text));
                            if (user != null)
                            {
                                user.cus_lIsGraduate = true;
                                user.cus_cLast = this.UserInformation.usm_cUserLoginID;
                                listSelected.Add(user);
                            }
                            else
                            {
                                ShowWarningMessage("部分学生信息已被更新，请刷新后重试。");
                                break;
                            }
                        }

                        dlgGraduationCheck dlgChk = new dlgGraduationCheck(listSelected);
                        if (dlgChk.ShowDialog() == DialogResult.Cancel)
                        {
                            return;
                        }
                        ReturnValueInfo rvInfo = this._ICardUserMasterBL.BatchUpdateUserInfo(listSelected);
                        if (rvInfo.boolValue && !rvInfo.isError)
                        {
                            ShowInformationMessage("处理成功。");

                            btnBatchmodify_Click(null, null);
                        }
                        else
                        {
                            ShowErrorMessage("处理失败。" + rvInfo.messageText);
                        }
                    }
                    catch (Exception ex)
                    {
                        ShowErrorMessage(ex);
                    }
                }
                else
                {
                    ShowWarningMessage("无选中项，请选择后重试。");
                }
            }
        }

        private void sysToolBar_OnItemRefresh_Click(object sender, EventArgs e)
        {
            //Control.CheckForIllegalCrossThreadCalls = false;

            //bindComboBox(DefineConstantValue.MasterType.Grade);

            //bindComboBox(DefineConstantValue.MasterType.UserClass);

            //bindComboBox(DefineConstantValue.MasterType.CardUserSex);

            //cbxVaild.Checked = false;
            //tbxStudenName.Text = string.Empty;
            //tbxStudentID.Text = string.Empty;
            //btnQuery.Enabled = true;
            //btnBatchmodify.Enabled = true;
            //pnlFuncArea.Enabled = true;
            //pnlQUeryArea.Enabled = true;
            //lvStudentList.SetDataSource(new List<CardUserMaster_cus_Info>());

            SearchStudents();
        }

        private void sysToolBar_OnItemDelete_Click(object sender, EventArgs e)
        {
            if (lvStudentList.SelectedItems.Count > 0)
            {
                if (ShowQuestionMessage("是否确认需要删除选中项？"))
                {
                    try
                    {
                        string strID = lvStudentList.SelectedItems[0].SubItems[0].Text;
                        Guid gRecordID = new Guid(strID);
                        CardUserMaster_cus_Info delInfo = new CardUserMaster_cus_Info();
                        delInfo.cus_cRecordID = gRecordID;

                        List<UserCardPair_ucp_Info> listCardPairInfo = this._IUserCardPairBL.SearchRecords(delInfo);
                        listCardPairInfo = listCardPairInfo.Where(x => x.ucp_cUseStatus == Common.DefineConstantValue.ConsumeCardStatus.Normal.ToString()).ToList();
                        if (listCardPairInfo != null && listCardPairInfo.Count > 0)
                        {
                            ShowWarningMessage("删除失败。此用户扔持有消费卡，请退卡后重试。");
                            return;
                        }

                        ReturnValueInfo rvInfo = this._ICardUserMasterBL.Save(delInfo, DefineConstantValue.EditStateEnum.OE_Delete);
                        if (rvInfo.boolValue && !rvInfo.isError)
                        {
                            ShowInformationMessage("删除成功。");
                        }
                        else
                        {
                            ShowErrorMessage("删除失败。" + rvInfo.messageText);
                        }
                        btnQuery_Click(null, null);
                    }
                    catch (Exception ex)
                    { ShowErrorMessage(ex); }
                }
            }
        }

        private void lvStudentList_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (lvStudentList.CheckedItems.Count > 0)
            {
                if (!btnGrauduation.Enabled)
                {
                    btnGrauduation.Enabled = true;
                }
            }
            else
            {
                if (btnGrauduation.Enabled)
                {
                    btnGrauduation.Enabled = false;
                }
            }
        }

        private void ckbSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chkTarget = sender as CheckBox;
            if (chkTarget == null)
            {
                return;
            }
            if (lvStudentList.Items.Count < 1)
            {
                return;
            }
            foreach (ListViewItem item in lvStudentList.Items)
            {
                item.Checked = chkTarget.Checked;
            }
        }

        private void lvStudentList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lvStudentList.SelectedItems.Count > 0)
            {
                sysToolBar_OnItemModify_Click(null, null);
            }
        }

        private void btnBatchModifyDetail_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlgOpen = new OpenFileDialog();
            dlgOpen.Filter = Common.DefineConstantValue.ImportFileFilter.ExExcel;
            if (dlgOpen.ShowDialog() == DialogResult.OK)
            {
                string strPathName = dlgOpen.FileName;
                DataSet ds = General.GetExcelDs(strPathName, "批量修改用户信息导入");
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    CardUserMaster_cus_Info searchInfo = new CardUserMaster_cus_Info();
                    searchInfo.cus_cIdentityNum = Common.DefineConstantValue.CodeMasterDefine.KEY2_SIOT_CardUserIdentity_Student;
                    List<CardUserMaster_cus_Info> listUsers = this._ICardUserMasterBL.SearchRecord_ForMaster(searchInfo);
                    if (listUsers != null)
                    {
                        listUsers = listUsers.Where(x => x.cus_lValid).ToList();
                        for (int i = 1; i <= ds.Tables[0].Rows.Count - 1; i++)
                        {
                            string strName = ds.Tables[0].Rows[i][0].ToString();
                            string strClassName = ds.Tables[0].Rows[i][1].ToString();
                            string strParentName = ds.Tables[0].Rows[i][2].ToString();
                            string strParentPhone = ds.Tables[0].Rows[i][3].ToString();
                            string strBankAccount = ds.Tables[0].Rows[i][4].ToString();

                            CardUserMaster_cus_Info currentUser = listUsers.Find(x => x.cus_cChaName.Trim() == strName && x.ClassName.Trim() == strClassName);
                            if (currentUser != null)
                            {
                                currentUser.cus_cContractName = strParentName;
                                currentUser.cus_cContractPhone = strParentPhone;
                                currentUser.cus_cBankAccount = strBankAccount;
                            }
                            else
                            {

                            }
                        }

                        ReturnValueInfo rvInfo = this._ICardUserMasterBL.BatchUpdateUserInfo(listUsers);
                        if (rvInfo.boolValue && !rvInfo.isError)
                        {
                            ShowInformationMessage("批量修改银行信息成功");
                        }
                        else
                        {
                            ShowErrorMessage("批量修改银行信息失败。" + rvInfo.messageText);
                        }
                    }
                }
                else
                {
                    ShowErrorMessage("无可用资料。");
                }
            }
        }
    }
}
