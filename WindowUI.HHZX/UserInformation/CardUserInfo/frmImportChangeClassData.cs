using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Model.HHZX.UserInfomation.CardUserInfo;
using Common;
using BLL.IBLL.HHZX.UserInfomation.CardUserInfo;
using BLL.Factory.HHZX;
using WindowUI.HHZX.ClassLibrary.Public;
using Model.General;

namespace WindowUI.HHZX.UserInformation.CardUserInfo
{
    public partial class frmImportChangeClassData : BaseForm
    {
        IClassMasterBL _IClassMasterBL;
        ICardUserMasterBL _ICardUserMasterBL;
        List<ChangeClassRecord_ccr_Info> _ListAllStudents;
        /// <summary>
        /// 导入的文件路径
        /// </summary>
        string _StrFilePath;

        public frmImportChangeClassData()
        {
            InitializeComponent();

            this._ICardUserMasterBL = MasterBLLFactory.GetBLL<ICardUserMasterBL>(MasterBLLFactory.CardUserMaster);
            this._IClassMasterBL = MasterBLLFactory.GetBLL<IClassMasterBL>(MasterBLLFactory.ClassMaster);
        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            labErrorMsg.Visible = false;
            labErrorMsg.Text = string.Empty;

            OpenFileDialog dlgImport = new OpenFileDialog();
            dlgImport.Filter = Common.DefineConstantValue.ImportFileFilter.ExExcel;

            if (dlgImport.ShowDialog() == DialogResult.OK)
            {
                if (!string.IsNullOrEmpty(dlgImport.FileName))
                {
                    this._StrFilePath = dlgImport.FileName;
                    txtFilePatch.Text = dlgImport.FileName;
                    progressBar.Visible = true;

                    this.Cursor = Cursors.WaitCursor;

                    validExcelData(dlgImport.FileName); 
                    progressBar.Value = 0;
                    progressBar.Visible = false;

                    this.Cursor = Cursors.Default;
                }
                else
                {
                    this._StrFilePath = string.Empty;
                    txtFilePatch.Text = string.Empty;
                    progressBar.Visible = false;
                    ShowWarningMessage("请先选择正确的文件路径。");
                }
            }
        }

        /// <summary>
        /// 校验导入的文件数据
        /// </summary>
        /// <param name="strExcelFilePath"></param>
        void validExcelData(string strExcelFilePath)
        {
            this._ListAllStudents = null;
            try
            {
                progressBar.Value = 20;

                btnImport.Enabled = true;
                DataSet ds = General.GetExcelDs(strExcelFilePath, "转班导入");
                progressBar.Value = 50;

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    this._ListAllStudents = new List<ChangeClassRecord_ccr_Info>();
                    for (int i = 1; i <= ds.Tables[0].Rows.Count - 1; i++)
                    {
                        bool res = true;
                        ChangeClassRecord_ccr_Info inputData = new ChangeClassRecord_ccr_Info();
                        CardUserMaster_cus_Info UserInfo = null;

                        //检查学生ID
                        #region 检查学生ID

                        string strRecordID = ds.Tables[0].Rows[i][0].ToString();
                        if (!string.IsNullOrEmpty(strRecordID))
                        {
                            try
                            {
                                inputData.ccr_cCardUserMasterID = new Guid(strRecordID);//学生记录ID
                                UserInfo = this._ICardUserMasterBL.DisplayRecord(new CardUserMaster_cus_Info() { cus_cRecordID = inputData.ccr_cCardUserMasterID });
                                if (UserInfo == null)
                                {
                                    res = res && false;
                                    inputData.VaildString += "该条学生记录ID异常，没有对应记录。" + Environment.NewLine;
                                }
                            }
                            catch (Exception exRecordID)
                            {
                                res = res && false;
                                inputData.VaildString += "该条学生记录ID异常。" + exRecordID.Message + Environment.NewLine;
                            }
                        }
                        else
                        {
                            res = res && false;
                            inputData.VaildString += "该条学生记录ID为空。" + Environment.NewLine;
                        }

                        #endregion

                        //检查学生原学号是否相符
                        #region 检查学生原学号是否相符

                        string strOldStuNum = ds.Tables[0].Rows[i][1].ToString();//学生原学号
                        if (res && UserInfo != null)
                        {
                            if (strOldStuNum.Trim() != UserInfo.cus_cStudentID.Trim())
                            {
                                res = res && false;
                                inputData.VaildString += "旧学号与数据库记录不相符。文件：" + strOldStuNum.Trim() + "，数据库：" + UserInfo.cus_cStudentID.Trim() + Environment.NewLine;
                            }
                        }
                        inputData.ccr_cOldStudentID = strOldStuNum;

                        #endregion

                        //检查学生姓名是否相符
                        #region 检查学生姓名是否相符

                        string strName = ds.Tables[0].Rows[i][2].ToString();//学生名称
                        if (res && UserInfo != null)
                        {
                            if (strName.Trim() != UserInfo.cus_cChaName.Trim())
                            {
                                res = res && false;
                                inputData.VaildString += "姓名与数据库记录不相符。文件：" + strName.Trim() + "，数据库：" + UserInfo.cus_cChaName.Trim() + Environment.NewLine;
                            }
                        }
                        inputData.ccr_cCName = strName;

                        #endregion

                        //检查旧班名称
                        #region 检查旧班名称

                        string strOldClassName = ds.Tables[0].Rows[i][3].ToString();//旧版班级名称
                        if (res)
                        {
                            List<ClassMaster_csm_Info> listOldClass = this._IClassMasterBL.SearchRecords(new ClassMaster_csm_Info() { csm_cClassName = strOldClassName });
                            if (listOldClass == null || (listOldClass != null && listOldClass.Count < 1))
                            {
                                res = res && false;
                                inputData.VaildString += "原班级信息已被修改，请导出最新的模板文件后进行修改。" + Environment.NewLine;
                            }
                        }
                        inputData.ccr_cOldClassName = strOldClassName;

                        #endregion

                        //检查新版名称
                        #region 检查新版名称

                        string strNewClassName = ds.Tables[0].Rows[i][4].ToString();//新版班级名称
                        if (res)
                        {
                            List<ClassMaster_csm_Info> listNewClass = this._IClassMasterBL.SearchRecords(new ClassMaster_csm_Info() { csm_cClassName = strNewClassName });
                            if (listNewClass == null || (listNewClass != null && listNewClass.Count < 1))
                            {
                                res = res && false;
                                inputData.VaildString += "目标新班级信息已被修改，请导出最新的模板文件后进行修改。" + Environment.NewLine;
                            }
                        }
                        inputData.ccr_cClassName = strNewClassName;

                        #endregion

                        //检查新学号
                        #region 检查新学号

                        string strNewStuNum = ds.Tables[0].Rows[i][5].ToString();//新学号                        
                        if (string.IsNullOrEmpty(strNewStuNum))
                        {
                            inputData.VaildString = "新学号不能为空。";
                            res = res && false;
                        }
                        else
                        {
                            CardUserMaster_cus_Info searchInfo = new CardUserMaster_cus_Info() { cus_cStudentID = strNewStuNum };
                            List<CardUserMaster_cus_Info> listSearchRes = this._ICardUserMasterBL.SearchRecords(searchInfo);
                            if (listSearchRes != null && listSearchRes.Count > 0)
                            {
                                inputData.VaildString = "新学号已被占用。正在使用人：" + listSearchRes[0].cus_cChaName;
                                res = res && false;
                            }
                        }
                        inputData.ccr_cStudentID = strNewStuNum;

                        #endregion

                        inputData.ValidBool = res;
                        if (res)
                        {
                            inputData.VaildString = "验证通过";
                        }
                        this._ListAllStudents.Add(inputData);
                    }

                    progressBar.Value = 70;

                    this._ListAllStudents = this._ListAllStudents.OrderBy(x => x.ccr_cOldStudentID).ToList();
                    lvStudentList.SetDataSource(this._ListAllStudents);
                    bool chkRes = true;
                    foreach (ListViewItem item in lvStudentList.Items)
                    {
                        if (!Convert.ToBoolean(item.SubItems[1].Text))
                        {
                            item.BackColor = Color.Tomato;
                            chkRes = chkRes && false;
                        }
                        else
                        {
                            item.BackColor = Color.LightGreen;
                            chkRes = chkRes && true;
                        }
                    }
                    btnImport.Enabled = chkRes;
                    progressBar.Value = 100;
                }
                else
                {
                    progressBar.Visible = false;
                    progressBar.Value = 0;
                    lvStudentList.SetDataSource(new List<ChangeClassRecord_ccr_Info>());

                    btnImport.Enabled = false;
                    labErrorMsg.Text = "导入的文件不包含可用的升年级信息，请检查后再试。";

                    return;
                }
            }
            catch (Exception ex)
            {
                progressBar.Visible = false;
                progressBar.Value = 0;
                lvStudentList.SetDataSource(new List<CardUserMaster_cus_Info>());
                btnImport.Enabled = false;

                labErrorMsg.Visible = true;
                labErrorMsg.Text = ex.Message;

                return;
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ShowQuestionMessage("是否确认要进行升年级处理？"))
                {
                    return;
                }

                ReturnValueInfo returnInfo = this._ICardUserMasterBL.InportChangeClassData(this._ListAllStudents);

                if (returnInfo.boolValue && !returnInfo.isError)
                {
                    ShowInformationMessage("升班数据处理成功。");

                    labErrorMsg.Text = "升班数据处理成功";
                    labErrorMsg.Visible = true;

                    btnImport.Enabled = false;
                }
                else
                {
                    ShowErrorMessage(returnInfo.messageText);

                    labErrorMsg.Text = "升班数据处理失败";
                    labErrorMsg.Visible = true;

                    btnImport.Enabled = false;
                }
            }
            catch (Exception Ex)
            {
                ShowErrorMessage(Ex.Message);
            }
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
    }
}
