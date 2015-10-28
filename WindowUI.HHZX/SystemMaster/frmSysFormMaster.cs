using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WindowUI.HHZX.ClassLibrary.Public;
using Model.General;
using Common;
using Common.DataTypeVerify;
using Model.SysMaster;
using BLL.IBLL.SysMaster;
using BLL.Factory.SysMaster;
using Model.IModel;


namespace WindowUI.HHZX.SystemMaster
{
    public partial class frmSysFormMaster : BaseForm
    {

        ISysFormMasterBL _ISysFormMasterBL;

        Sys_FormMaster_fom_Info _showInfo;

        public frmSysFormMaster()
        {
            InitializeComponent();

            _showInfo = new Sys_FormMaster_fom_Info();

            this._ISysFormMasterBL = MasterBLLFactory.GetBLL<ISysFormMasterBL>(MasterBLLFactory.SysFormMaster);
        }

        void BindFormLocalTreeView()
        {
            Dictionary<string, List<MenuItem>> dicMenu = new Dictionary<string, List<MenuItem>>();
            foreach (MenuItem item in ((MainForm)this.Parent.Parent).TopMenu.MenuItems)
            {
                foreach (MenuItem subItem in item.MenuItems)
                {
                    if (!dicMenu.Keys.Contains(subItem.Name))
                    {
                        List<MenuItem> listMenu = new List<MenuItem>();
                        dicMenu.Add(subItem.Name, listMenu);
                    }
                    if (subItem != null)
                    {
                        dicMenu[subItem.Name].Add(subItem);
                    }
                }
            }
        }

        private void SysFormMaster_Load(object sender, EventArgs e)
        {
            BindFormTreeView();

            SetFormStatc(DefineConstantValue.EditStateEnum.OE_ReaOnly);

            BindCombo();
        }


        void BindFormTreeView()
        {
            this.Cursor = Cursors.WaitCursor;

            Sys_FormMaster_fom_Info info = new Sys_FormMaster_fom_Info();
            List<IModelObject> listObjForms = this._ISysFormMasterBL.SearchRecords(info);
            List<Sys_FormMaster_fom_Info> ListFormInfos = new List<Sys_FormMaster_fom_Info>();
            foreach (Sys_FormMaster_fom_Info item in listObjForms)
            {
                if (item != null)
                {
                    ListFormInfos.Add(item);
                }
            }

            List<Sys_FormMaster_fom_Info> listForms = ListFormInfos;
            try
            {
                //增加根结点
                tvFromMain.Nodes.Clear();

                info = listForms.Find(x => x.fom_iParentID == -1);
                if (info == null)
                {
                    this.Cursor = Cursors.Default;
                    return;
                }
                TreeNode rootNode = new TreeNode(info.fom_cFormDesc);
                rootNode.Name = info.fom_iRecordID.ToString();
                rootNode.Tag = info.fom_cExePath.ToString();
                tvFromMain.Nodes.Add(rootNode);


                //加载子节点
                GetFormList(rootNode, listForms, info.fom_iRecordID);

                if (tvFromMain.Nodes.Count > 0)
                {
                    tvFromMain.ExpandAll();
                    tvFromMain.SelectedNode = tvFromMain.Nodes[0];
                }


            }
            catch (Exception Ex)
            { this.ShowErrorMessage(Ex); }

            this.Cursor = Cursors.Default;
        }

        void BindCombo()
        {
            cbxShortCut.DataSource = Enum.GetValues(typeof(Shortcut));
        }

        /// <summary>
        /// 加載樹節點的所有子節點
        /// </summary>
        /// <param name="nodeCurrent">當前樹節點</param>
        /// <param name="listForms">窗體記錄列表</param>
        /// <param name="iParentID">當前節點綁定的窗體ID</param>
        void GetFormList(TreeNode nodeCurrent, List<Sys_FormMaster_fom_Info> listForms, int iParentID)
        {
            List<Sys_FormMaster_fom_Info> listSubForms = listForms.Where(x => x.fom_iParentID == iParentID).ToList();
            if (listForms == null)
            {
                return;
            }
            if (listForms.Count < 1)
            {
                return;
            }

            foreach (Sys_FormMaster_fom_Info formItem in listSubForms)
            {
                if (formItem == null)
                {
                    continue;
                }
                TreeNode subNode = new TreeNode(formItem.fom_cFormDesc);
                subNode.Name = formItem.fom_iRecordID.ToString();
                subNode.Tag = formItem.fom_cExePath.ToString();
                nodeCurrent.Nodes.Add(subNode);

                GetFormList(subNode, listForms, formItem.fom_iRecordID);
            }
        }

        private void ShowInfoToUI(Sys_FormMaster_fom_Info showInfo)
        {
            if (showInfo != null)
            {
                ckbIsPopForm.Checked = showInfo.fom_lIsPopForm;

                txtcCode.Text = showInfo.fom_cFormNumber;

                txtcID.Text = showInfo.fom_iIndex.ToString();

                txtDesc.Text = showInfo.fom_cFormDesc;

                txtcPath.Text = showInfo.fom_cExePath;

                txtcRemark.Text = showInfo.fom_cRemark;

                txtcParentCode.Text = showInfo.fom_iParentID.ToString();

                txtdAddDate.Text = showInfo.fom_dAddDate == DateTime.MinValue ? string.Empty : showInfo.fom_dAddDate.ToString(DefineConstantValue.gc_DateFormat);

                txtdLastDate.Text = showInfo.fom_dLastDate == DateTime.MinValue ? string.Empty : showInfo.fom_dLastDate.ToString(DefineConstantValue.gc_DateFormat);

                ckbPreOpen.Checked = showInfo.fom_lIsPreOpen;

                if (string.IsNullOrEmpty(showInfo.fom_cShortCut))
                {
                    cbxShortCut.Text = Shortcut.None.ToString();
                }
                else
                {
                    cbxShortCut.Text = showInfo.fom_cShortCut;
                }

                txtcAdd.Text = showInfo.fom_cAdd;

                txtcLast.Text = showInfo.fom_cLast;
            }

            SetFormStatc(DefineConstantValue.EditStateEnum.OE_ReaOnly);

            this.EditState = DefineConstantValue.EditStateEnum.OE_ReaOnly;

        }

        private void tvFromMain_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.EditState = DefineConstantValue.EditStateEnum.OE_ReaOnly;

            HightLight(e.Node);

            Sys_FormMaster_fom_Info query = new Sys_FormMaster_fom_Info();

            query.fom_iRecordID = Convert.ToInt32(e.Node.Name);

            try
            {
                this._showInfo = this._ISysFormMasterBL.DisplayRecord(query) as Sys_FormMaster_fom_Info;

                ShowInfoToUI(this._showInfo);
            }
            catch (Exception Ex)
            {

                ShowErrorMessage(Ex.Message);
            }


        }

        private void HightLight(TreeNode node)
        {
            HandelNode(tvFromMain.Nodes[0]);

            SetColor(node, Color.Red);
        }

        private void HandelNode(TreeNode node)
        {
            SetColor(node, Color.Black);

            if (node.Nodes != null && node.Nodes.Count > 0)
            {
                foreach (TreeNode item in node.Nodes)
                {
                    HandelNode(item);
                }
            }
        }

        private void SetColor(TreeNode objNode, Color clr)
        {
            if (objNode != null)
            {
                objNode.ForeColor = clr;
            }
        }

        private void SetFormStatc(DefineConstantValue.EditStateEnum statc)
        {
            switch (statc)
            {
                case DefineConstantValue.EditStateEnum.OE_Insert:

                    SysToolBar.BtnNewEnabled = false;
                    SysToolBar.BtnModifyEnabled = false;
                    SysToolBar.BtnDeleteEnabled = false;
                    SysToolBar.BtnSaveEnabled = true;
                    SysToolBar.BtnCancelEnabled = true;
                    tvFromMain.Enabled = false;
                    txtcCode.Enabled = true;
                    txtDesc.Enabled = true;
                    txtcRemark.Enabled = true;
                    txtcPath.Enabled = true;
                    txtcParentCode.Enabled = false;
                    txtcID.Enabled = true;
                    cbxShortCut.Enabled = true;
                    ckbPreOpen.Enabled = true;
                    ckbIsPopForm.Enabled = true;
                    break;
                case DefineConstantValue.EditStateEnum.OE_Update:

                    SysToolBar.BtnNewEnabled = false;
                    SysToolBar.BtnModifyEnabled = false;
                    SysToolBar.BtnDeleteEnabled = false;
                    SysToolBar.BtnSaveEnabled = true;
                    SysToolBar.BtnCancelEnabled = true;
                    tvFromMain.Enabled = false;
                    txtcCode.Enabled = false;
                    txtDesc.Enabled = true;
                    txtcRemark.Enabled = true;
                    txtcPath.Enabled = true;
                    txtcParentCode.Enabled = false;
                    txtcID.Enabled = true;
                    cbxShortCut.Enabled = true;
                    ckbPreOpen.Enabled = true;
                    ckbIsPopForm.Enabled = true;
                    break;
                case DefineConstantValue.EditStateEnum.OE_Delete:
                    break;
                case DefineConstantValue.EditStateEnum.OE_ReaOnly:

                    SysToolBar.BtnNewEnabled = true;
                    SysToolBar.BtnModifyEnabled = true;
                    SysToolBar.BtnDeleteEnabled = true;
                    SysToolBar.BtnSaveEnabled = false;
                    SysToolBar.BtnCancelEnabled = false;
                    tvFromMain.Enabled = true;
                    txtcCode.Enabled = false;
                    txtDesc.Enabled = false;
                    txtcRemark.Enabled = false;
                    txtcPath.Enabled = false;
                    txtcParentCode.Enabled = false;
                    txtcID.Enabled = false;
                    cbxShortCut.Enabled = false;
                    ckbPreOpen.Enabled = false;
                    ckbIsPopForm.Enabled = false;
                    break;
                default:
                    break;
            }
        }

        private void SysToolBar_BtnNewClick(object sender, EventArgs e)
        {
            if (this._showInfo == null)
            {
                return;
            }
            SetFormStatc(DefineConstantValue.EditStateEnum.OE_Insert);

            this.EditState = DefineConstantValue.EditStateEnum.OE_Insert;

            this.txtcParentCode.Text = this._showInfo.fom_iRecordID.ToString();

            cls();

        }

        private void cls()
        {
            txtcCode.Text = string.Empty;

            txtDesc.Text = string.Empty;

            txtcRemark.Text = string.Empty;

            txtcPath.Text = string.Empty;

            txtcID.Text = string.Empty;

        }

        private void SysToolBar_BtnModifyClick(object sender, EventArgs e)
        {
            SetFormStatc(DefineConstantValue.EditStateEnum.OE_Update);

            this.EditState = DefineConstantValue.EditStateEnum.OE_Update;
        }

        private void SysToolBar_BtnDeleteClick(object sender, EventArgs e)
        {
            Sys_FormMaster_fom_Info deleteInfo = this._showInfo;

            ReturnValueInfo returnInfo = this._ISysFormMasterBL.Save(deleteInfo, DefineConstantValue.EditStateEnum.OE_Delete);

            if (returnInfo.boolValue)
            {
                ShowInformationMessage(DefineConstantValue.SystemMessageText.strMessageText_I_RecordByDelete);

                BindFormTreeView();
            }
            else
            {
                ShowErrorMessage(returnInfo.messageText);
            }
        }

        private void SysToolBar_BtnSaveClick(object sender, EventArgs e)
        {
            try
            {
                Int32 tempInt = Convert.ToInt32(txtcID.Text);
            }
            catch
            {

                ShowWarningMessage("请先输入正确窗体序号！");

                txtcID.Select();

                return;
            }

            ReturnValueInfo returnValue = new ReturnValueInfo(false);

            Sys_FormMaster_fom_Info objInfo = new Sys_FormMaster_fom_Info();

            objInfo.fom_cFormNumber = txtcCode.Text.Trim();

            objInfo.fom_cFormDesc = txtDesc.Text.Trim();

            objInfo.fom_cRemark = txtcRemark.Text.Trim();

            objInfo.fom_cExePath = txtcPath.Text.Trim();

            objInfo.fom_iParentID = Convert.ToInt32(txtcParentCode.Text.Trim());

            objInfo.fom_iIndex = Convert.ToInt32(txtcID.Text.Trim());

            objInfo.fom_cAdd = this.UserInformation.usm_cUserLoginID;

            objInfo.fom_cLast = this.UserInformation.usm_cUserLoginID;

            objInfo.fom_lIsPopForm = ckbIsPopForm.Checked;

            objInfo.fom_lIsPreOpen = ckbPreOpen.Checked;

            objInfo.fom_cShortCut = cbxShortCut.Text;

            //objInfo.fom_cSysCode = DefineConstantValue.SysFormCodeEnum.HBManager.ToString();

            objInfo.fom_lVaild = true;

            try
            {
                switch (this.EditState)
                {
                    case DefineConstantValue.EditStateEnum.OE_Insert:

                        returnValue = this._ISysFormMasterBL.Save(objInfo, DefineConstantValue.EditStateEnum.OE_Insert);

                        break;
                    case DefineConstantValue.EditStateEnum.OE_Update:

                        objInfo.fom_iRecordID = this._showInfo.fom_iRecordID;

                        returnValue = this._ISysFormMasterBL.Save(objInfo, DefineConstantValue.EditStateEnum.OE_Update);

                        break;
                    case DefineConstantValue.EditStateEnum.OE_Delete:

                        break;
                    case DefineConstantValue.EditStateEnum.OE_ReaOnly:
                        break;
                    default:
                        break;
                }

                if (returnValue.boolValue)
                {
                    ShowInformationMessage(DefineConstantValue.SystemMessageText.strMessageText_I_SaveSuccess);

                    BindFormTreeView();

                    this._showInfo.fom_iRecordID = objInfo.fom_iRecordID;

                    this._showInfo = this._ISysFormMasterBL.DisplayRecord(this._showInfo) as Sys_FormMaster_fom_Info;

                    ShowInfoToUI(this._showInfo);

                }
                else
                {
                    ShowErrorMessage(returnValue.messageText);
                }
            }
            catch (Exception Ex)
            {

                ShowErrorMessage(Ex.Message);
            }
        }

        private void SysToolBar_BtnCancelClick(object sender, EventArgs e)
        {
            ShowInfoToUI(this._showInfo);
        }
    }
}