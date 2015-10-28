using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Common;
using Common.DataTypeVerify;
using WeifenLuo.WinFormsUI.Docking;
using Model.SysMaster;
using WindowControls;
using Model.IModel;
using Sunisoft.IrisSkin;

namespace WindowUI.HHZX
{
    public partial class BaseForm : DockContent
    {
        #region 自定义变量

        /// <summary>
        /// 系統提示信息文字定義
        /// </summary>
        public readonly DefineConstantValue.SystemMessage SystemMessageText;

        /// <summary>
        /// 記錄編輯狀態
        /// </summary>
        public DefineConstantValue.EditStateEnum EditState;

        /// <summary>
        /// 記錄ToolBar狀態
        /// </summary>
        public DefineConstantValue.GetReocrdEnum TBViewStatc;

        /// <summary>
        /// 用戶信息
        /// </summary>
        public Sys_UserMaster_usm_Info UserInformation;

        /// <summary>
        /// 功能列表
        /// </summary>
        public List<Sys_FunctionMaster_fum_Info> FunctionList;

        public List<Sys_FunctionMaster_fum_Info> _setFunctionList;

        public static Sunisoft.IrisSkin.SkinEngine skin = new SkinEngine();

        public DockPanel BaseDockPanel;

        /// <summary>
        /// 窗體傳值容器
        /// </summary>
        public IModelObject BaseParam;

        #endregion

        public BaseForm()
        {
            InitializeComponent();

            this.TBViewStatc = DefineConstantValue.GetReocrdEnum.GR_First;
            this.SystemMessageText = new DefineConstantValue.SystemMessage(string.Empty);
            this.EditState = DefineConstantValue.EditStateEnum.OE_ReaOnly;
        }

        /// <summary>
        /// 设置权限
        /// </summary>
        /// <param name="toolBar"></param>
        public void SetPurview(UserToolBar toolBar)
        {
            FunctionList = _setFunctionList;

            if (toolBar != null)
            {
                toolBar.BtnNewVisible = false;
                toolBar.BtnModifyVisible = false;
                toolBar.BtnDeleteVisible = false;
                toolBar.BtnCardIssuanceVisible = false;
                toolBar.BtnCardReturnVisible = false;
                toolBar.BtnCardMissingVisible = false;
                toolBar.BtnCardRecoveryVisible = false;
                toolBar.BtnCardScrapVisible = false;

                toolBar.BtnDataInputVisible = false;
                toolBar.BtnDataExportVisible = false;
                toolBar.BtnExpCusDataVisible = false;
                toolBar.BtnExportTemplateVisible = false;
                toolBar.BtnExportCardUserPhotoVisible = false;

                toolBar.BtnImportPhotoVisible = false;
                toolBar.BtnGroupPersonVisible = false;

                toolBar.btnImportDataVisible = false;
                toolBar.btnExportDataVisible = false;

                if (this.FunctionList != null && this.FunctionList.Count > 0)
                {
                    for (int i = 0; i < this.FunctionList.Count; i++)
                    {

                        if (this.FunctionList[i].fum_cFunctionNumber.Trim() == DefineConstantValue.Sys_FormFunctionNum.New)
                        {
                            toolBar.BtnNewVisible = true;
                            continue;
                        }
                        if (this.FunctionList[i].fum_cFunctionNumber.Trim() == DefineConstantValue.Sys_FormFunctionNum.Modify)
                        {
                            toolBar.BtnModifyVisible = true;
                            continue;
                        }
                        if (this.FunctionList[i].fum_cFunctionNumber.Trim() == DefineConstantValue.Sys_FormFunctionNum.Delete)
                        {
                            toolBar.BtnDeleteVisible = true;
                            continue;
                        }
                    }
                }

                else if (this.UserInformation != null && this.UserInformation.usm_cUserLoginID == "sa")
                {
                    toolBar.BtnNewVisible = true;
                    toolBar.BtnModifyVisible = true;
                    toolBar.BtnDeleteVisible = true;
                }
            }
        }

        /// <summary>
        /// 显示错误信息
        /// </summary>
        /// <param name="Ex"></param>
        public void ShowErrorMessage(Exception Ex)
        {
            MessageBox.Show(Ex.Message.Trim(), this.SystemMessageText.strMessageTitle + this.SystemMessageText.strSystemError.Trim(), MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// 显示错误信息
        /// </summary>
        /// <param name="Ex"></param>
        public void ShowErrorMessage(string text)
        {
            MessageBox.Show(text.Trim(), this.SystemMessageText.strMessageTitle + this.SystemMessageText.strSystemError.Trim(), MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// 显示提示信息
        /// </summary>
        /// <param name="text"></param>
        public void ShowInformationMessage(string text)
        {
            MessageBox.Show(text, this.SystemMessageText.strMessageTitle + this.SystemMessageText.strInformation.Trim(), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// 显示警告信息
        /// </summary>
        /// <param name="text"></param>
        public void ShowWarningMessage(string text)
        {
            MessageBox.Show(text, this.SystemMessageText.strMessageTitle + this.SystemMessageText.strWarning.Trim(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        /// <summary>
        /// 显示确认信息
        /// </summary>
        /// <param name="text"></param>
        public bool ShowQuestionMessage(string text)
        {
            bool isYes = false;
            if (MessageBox.Show(text, this.SystemMessageText.strMessageTitle + this.SystemMessageText.strQuestion.Trim(), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                isYes = true;
            }

            return isYes;
        }

        /// <summary>
        /// 数据类型验证
        /// </summary>
        /// <param name="fieldText">栏位标题</param>
        /// <param name="text">验证内容</param>
        /// <param name="dataType">数据类型</param>
        /// <returns></returns>
        public bool VerifyDataType(string fieldText, string text, DataType dataType)
        {
            DataTypeVerifyResultInfo verifyResult = null;

            verifyResult = General.VerifyDataType(text, dataType);

            if (verifyResult != null)
            {
                if (!verifyResult.IsMatch)
                {
                    MessageBox.Show(fieldText + "： " + verifyResult.Message, this.SystemMessageText.strMessageTitle + this.SystemMessageText.strWarning.Trim(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            return verifyResult.IsMatch;
        }

        /// <summary>
        /// 设置窗口为选择状态
        /// 不能最大化，不能最小化，不能调整大小
        /// </summary>
        public void SetFormSelectState()
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        /// <summary>
        /// 显示子窗体
        /// </summary>
        /// <param name="sender">发送显示请求的按钮或其他控件</param>
        /// <param name="dpnlContainer">显示容器</param>
        public void ShowSubForm(object sender, DockPanel dpnlContainer)
        {
            ShowSubForm(sender, dpnlContainer, null);
        }

        /// <summary>
        /// 显示子窗体
        /// </summary>
        /// <param name="sender">发送显示请求的按钮或其他控件</param>
        /// <param name="dpnlContainer">显示容器</param>
        /// <param name="strTabName">卡位位置</param>
        public void ShowSubForm(object sender, DockPanel dpnlContainer, string strTabName)
        {
            ShowSubForm(sender, dpnlContainer, strTabName, DockState.Document);
        }

        /// <summary>
        /// 显示子窗体
        /// </summary>
        /// <param name="sender">发送显示请求的按钮或其他控件</param>
        /// <param name="dpnlContainer">显示容器</param>
        /// <param name="strTabName">卡位位置</param>
        /// <param name="strTabName">显示卡位位置</param>
        public void ShowSubForm(object sender, DockPanel dpnlContainer, string strTabName, DockState state)
        {
            string strFormName = string.Empty;

            MenuItem itemMenu = sender as MenuItem;
            if (itemMenu != null)
            {
                strFormName = (itemMenu.Tag as Sys_FormMaster_fom_Info).fom_cExePath;
            }
            else
            {
                ToolStripButton itemBtn = sender as ToolStripButton;
                if (itemBtn != null)
                {
                    strFormName = (itemBtn.Tag as Sys_FormMaster_fom_Info).fom_cExePath;
                }
            }

            if (!string.IsNullOrEmpty(strFormName))
            {
                if (!string.IsNullOrEmpty(strFormName))
                {
                    BaseForm frmTarget = GetFormIn(strFormName);

                    frmTarget.EditState = this.EditState;
                    frmTarget.BaseParam = this.BaseParam;
                    frmTarget.UserInformation = this.UserInformation;

                    if (!string.IsNullOrEmpty(strTabName))
                    {
                        frmTarget.TabText = strTabName;
                    }

                    if (frmTarget == null)
                    {
                        ShowErrorMessage("生成子窗体异常，请联系管理员。");
                    }
                    else
                    {
                        //var tmpList = dpnlContainer.Contents.Where(x => x.DockHandler.TabText == frmTarget.TabText).ToList();
                        var tmpList = dpnlContainer.Contents.Where(x => x.DockHandler.Form.Name == frmTarget.Name).ToList();
                        if (tmpList != null && tmpList.Count < 1)
                        {
                            frmTarget.BaseDockPanel = dpnlContainer;
                            frmTarget.Show(dpnlContainer, state);
                        }
                        else if (tmpList != null && tmpList.Count > 0)//當使用相同窗體不同編輯模式時，Form相同，需要外加編輯狀態屬性判斷是否已被打開該窗體
                        {
                            List<BaseForm> listCompForm = new List<BaseForm>();
                            foreach (var panItem in tmpList)
                            {
                                BaseForm bsTarget = panItem.DockHandler.Form as BaseForm;
                                if (bsTarget != null)
                                {
                                    listCompForm.Add(bsTarget);
                                }
                            }

                            var listTmp = listCompForm.Where(x => x.EditState == this.EditState).ToList();
                            if (listTmp != null && listTmp.Count < 1)
                            {
                                frmTarget.BaseDockPanel = dpnlContainer;
                                frmTarget.Show(dpnlContainer, state);
                            }
                            else if (listTmp != null && listTmp.Count > 0)
                            {
                                listTmp[0].DockHandler.Activate();
                            }
                        }
                    }
                }
                else
                {
                    ShowErrorMessage("发送显示请求的对象没有携带窗口信息，请联系管理员。");
                }
            }
            else
            {
                ShowErrorMessage("发送显示请求的对象有误，请联系管理员。");
            }
        }

        /// <summary>
        /// 显示子窗体
        /// </summary>
        /// <param name="sender">发送显示请求的按钮或其他控件</param>
        /// <param name="dpnlContainer">显示容器</param>
        /// <param name="strTabName">卡位位置</param>
        /// <param name="state">显示卡位位置</param>
        /// <param name="TransmitParam">需要传递的参数</param>
        public void ShowSubForm(object sender, DockPanel dpnlContainer, string strTabName, DockState state, IModelObject TransmitParam, DefineConstantValue.EditStateEnum EditState)
        {
            this.BaseParam = TransmitParam;
            this.EditState = EditState;
            ShowSubForm(sender, dpnlContainer, strTabName, state);
        }

        /// <summary>
        /// 显示弹出窗
        /// </summary>
        /// <param name="strFullName"></param>
        public void ShowShellForm(string strFullName)
        {
            Type accessorType = Type.GetType(strFullName, false);
            object obj = Activator.CreateInstance(accessorType);
            BaseForm bForm = obj as BaseForm;
            if (obj == null)
            {
                this.ShowWarningMessage("窗口打开异常，请联系管理员。");
                return;
            }
            bForm.UserInformation = this.UserInformation;
            bForm.BaseDockPanel = this.BaseDockPanel;
            bForm.ShowDialog();
        }

        /// <summary>
        /// 生成窗口实体
        /// </summary>
        /// <param name="formName">子窗体全命名</param>
        /// <returns></returns>
        private BaseForm GetFormIn(string formName)
        {
            BaseForm frm = null;
            Type type = Type.GetType(formName, false);
            if (type != null)
            {
                frm = Activator.CreateInstance(type) as BaseForm;
            }

            return frm;
        }
    }
}
