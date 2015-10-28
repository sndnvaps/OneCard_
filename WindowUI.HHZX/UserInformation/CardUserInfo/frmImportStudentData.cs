using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Common.Util;
using Common;
using Model.HHZX.UserInfomation.CardUserInfo;
using WindowUI.HHZX.ClassLibrary.Public;
using BLL.IBLL.HHZX.UserInfomation.CardUserInfo;
using BLL.Factory.HHZX;
using Model.General;
using Model.SysMaster;
using BLL.IBLL.SysMaster;

namespace WindowUI.HHZX.UserInformation.CardUserInfo
{
    public partial class frmImportStudentData : BaseForm
    {
        ICardUserMasterBL _ICardUserMasterBL;
        IClassMasterBL _IClassMasterBL;
        ICodeMasterBL _ICodeMasterBL;

        /// <summary>
        /// 缓存中的学生信息
        /// </summary>
        List<CardUserMaster_cus_Info> _ListAllStudents;
        /// <summary>
        /// 缓存中的文件路径信息
        /// </summary>
        string _StrCurrentFileName;

        public frmImportStudentData()
        {
            InitializeComponent();

            this._ICardUserMasterBL = MasterBLLFactory.GetBLL<ICardUserMasterBL>(MasterBLLFactory.CardUserMaster);
            this._IClassMasterBL = MasterBLLFactory.GetBLL<IClassMasterBL>(MasterBLLFactory.ClassMaster);
            this._ICodeMasterBL = BLL.Factory.SysMaster.MasterBLLFactory.GetBLL<ICodeMasterBL>(BLL.Factory.SysMaster.MasterBLLFactory.CodeMaster_cmt);
        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlgOpen = new OpenFileDialog();

            dlgOpen.Filter = Common.DefineConstantValue.ImportFileFilter.ExExcel;

            if (dlgOpen.ShowDialog() == DialogResult.OK)
            {
                if (!string.IsNullOrEmpty(dlgOpen.FileName))
                {
                    this._StrCurrentFileName = dlgOpen.FileName;
                    txtFilePatch.Text = dlgOpen.FileName;
                    progressBar.Visible = true;

                    this.Cursor = Cursors.WaitCursor;

                    validImportData(dlgOpen.FileName);
                    progressBar.Visible = false;
                    progressBar.Value = 0;

                    this.Cursor = Cursors.Default;
                }
                else
                {
                    btnImport.Enabled = false;
                    ShowWarningMessage("请选择需要导入的文件。");
                }
            }
        }

        public void ShowForm(Sys_UserMaster_usm_Info user)
        {
            this.UserInformation = user;

            this.ShowDialog();
        }

        /// <summary>
        /// 检查导入的数据文件
        /// </summary>
        /// <param name="strFilePath">文件路径</param>
        void validImportData(string strFilePath)
        {
            this._ListAllStudents = null;
            try
            {
                DataSet ds = General.GetExcelDs(strFilePath, "学生信息导入");
                progressBar.Value = 20;

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    this._ListAllStudents = new List<CardUserMaster_cus_Info>();
                    List<CodeMaster_cmt_Info> listSexNum = this._ICodeMasterBL.SearchRecords(new CodeMaster_cmt_Info() { cmt_cKey1 = Common.DefineConstantValue.CodeMasterDefine.KEY1_SIOT_CardUserSex });

                    for (int i = 2; i < ds.Tables[0].Rows.Count; i++)
                    {
                        CardUserMaster_cus_Info SutUserInfo = new CardUserMaster_cus_Info();
                        bool res = true;

                        //检查学号唯一性
                        #region 检查学号唯一性

                        string strStuNum = ds.Tables[0].Rows[i][0].ToString();//学号
                        if (!string.IsNullOrEmpty(strStuNum))
                        {
                            List<CardUserMaster_cus_Info> listSearchInfo = this._ICardUserMasterBL.SearchRecords(new CardUserMaster_cus_Info() { cus_cStudentID = strStuNum });
                            if (listSearchInfo != null && listSearchInfo.Count > 0)
                            {
                                if (listSearchInfo.Exists(x => x.cus_cStudentID == strStuNum))
                                {
                                    res = res && false;
                                    SutUserInfo.CheckString = "此学号已被占用。正在使用者：" + listSearchInfo[0].cus_cChaName;
                                }
                            }
                        }
                        else
                        {
                            res = res && false;
                            SutUserInfo.CheckString += "学号不能为空。";
                        }
                        SutUserInfo.cus_cStudentID = strStuNum;

                        #endregion

                        SutUserInfo.cus_cChaName = ds.Tables[0].Rows[i][1].ToString();//学生姓名

                        SutUserInfo.cus_cSexNum = ds.Tables[0].Rows[i][2].ToString() == "男" ? "MALE" : "FEMALE";//性别编号

                        SutUserInfo.SexName = ds.Tables[0].Rows[i][2].ToString();

                        SutUserInfo.cus_cComeYear = ds.Tables[0].Rows[i][3].ToString();//入学时间

                        SutUserInfo.cus_cGraduationPeriod = ds.Tables[0].Rows[i][4].ToString();//届别

                        //检查班级名是否存在
                        #region 检查班级名是否存在

                        string strClassName = ds.Tables[0].Rows[i][5].ToString();//班名
                        if (res)
                        {
                            List<ClassMaster_csm_Info> listClass = this._IClassMasterBL.SearchRecords(new ClassMaster_csm_Info() { csm_cClassName = strClassName });
                            if (listClass == null || (listClass != null && listClass.Count < 1))
                            {
                                res = res && false;
                                SutUserInfo.CheckString += "数据库班级信息已被修改，请导出最新的模板文件后进行修改。" + Environment.NewLine;
                            }
                            else
                            {
                                SutUserInfo.cus_cClassID = listClass[0].csm_cRecordID;
                            }
                        }
                        SutUserInfo.ClassName = strClassName;

                        #endregion

                        SutUserInfo.cus_cContractName = ds.Tables[0].Rows[i][6].ToString();//联系人名称

                        SutUserInfo.cus_cContractPhone = ds.Tables[0].Rows[i][7].ToString();//联系人电话号码

                        SutUserInfo.cus_cRemark = ds.Tables[0].Rows[i][8].ToString();//备注

                        SutUserInfo.cus_cAdd = this.UserInformation.usm_cUserLoginID;

                        SutUserInfo.cus_cLast = this.UserInformation.usm_cUserLoginID;

                        SutUserInfo.cus_cIdentityNum = Common.DefineConstantValue.CodeMasterDefine.KEY2_SIOT_CardUserIdentity_Student;

                        SutUserInfo.CheckBool = res;
                        if (SutUserInfo.CheckBool)
                        {
                            SutUserInfo.CheckString = "验证成功";
                        }

                        if (String.IsNullOrEmpty(SutUserInfo.cus_cStudentID) &&
                            String.IsNullOrEmpty(SutUserInfo.cus_cChaName) &&
                            String.IsNullOrEmpty(SutUserInfo.SexName) &&
                            String.IsNullOrEmpty(SutUserInfo.cus_cComeYear) &&
                            String.IsNullOrEmpty(SutUserInfo.cus_cGraduationPeriod) &&
                            String.IsNullOrEmpty(SutUserInfo.ClassName) &&
                            String.IsNullOrEmpty(SutUserInfo.cus_cContractName) &&
                            String.IsNullOrEmpty(SutUserInfo.cus_cContractPhone) &&
                            String.IsNullOrEmpty(SutUserInfo.cus_cRemark))
                        {

                        }
                        else
                        {
                            this._ListAllStudents.Add(SutUserInfo);
                        }

                    }
                    progressBar.Value = 50;

                    //this._ListAllStudents = this._ICardUserMasterBL.CheckForInportData(this._ListAllStudents);
                    this._ListAllStudents = this._ListAllStudents.OrderBy(x => x.cus_cStudentID).ToList();

                    lvStudentList.SetDataSource(this._ListAllStudents);

                    bool resChkAll = true;
                    foreach (ListViewItem item in lvStudentList.Items)
                    {
                        if (!Convert.ToBoolean(item.SubItems[0].Text))
                        {
                            item.BackColor = Color.Tomato;
                            resChkAll = resChkAll && false;
                        }
                        else
                        {
                            item.BackColor = Color.LightGreen;
                        }
                    }
                    if (resChkAll)
                    {
                        btnImport.Enabled = resChkAll;
                    }
                    progressBar.Value = 90;
                }
                else
                {
                    progressBar.Visible = false;
                    progressBar.Value = 0;
                    lvStudentList.SetDataSource(new List<ChangeClassRecord_ccr_Info>());

                    btnImport.Enabled = false;
                    labErrorMsg.Text = "导入的文件不包含可用的学生信息，请检查后再试。";

                    return;
                }
            }
            catch (Exception ex)
            {

                ShowErrorMessage(ex);
            }
        }

        private void btnInport_Click(object sender, EventArgs e)
        {
            try
            {
                ReturnValueInfo returnInfo = this._ICardUserMasterBL.InportData(this._ListAllStudents);

                if (returnInfo.boolValue)
                {
                    ShowInformationMessage(Common.DefineConstantValue.SystemMessageText.strMessageText_I_SaveSuccess);

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
}
