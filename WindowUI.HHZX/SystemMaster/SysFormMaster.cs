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

namespace WindowUI.HHZX.SysMaster
{
    public partial class SysFormMaster : BaseForm
    {
        ISysFunctionMasterBL _ISysFunctionMasterBL;
        ISysFormMasterBL _ISysFormMasterBL;
        string _iRecordID;
        Model.General.ReturnValueInfo _msg;
        string _pCode;

        public SysFormMaster()
        {
            InitializeComponent();

            _iRecordID = string.Empty;
            _msg = new ReturnValueInfo();
            _pCode = string.Empty;
            this._ISysFormMasterBL = MasterBLLFactory.GetBLL<ISysFormMasterBL>(MasterBLLFactory.SysFormMaster);
            this._ISysFunctionMasterBL = MasterBLLFactory.GetBLL<ISysFunctionMasterBL>(MasterBLLFactory.SysFunctionMaster);


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
            BindFormLocalTreeView();

            base.SetPurview(this.SysToolBar);
            SetControlLength();
            SetOpenToolBar();
            BindTreeView();
            Bind();
        }

        /// <summary>
        /// 設置按鈕狀態
        /// </summary>
        private void SetOpenToolBar()
        {
            SysToolBar.BtnNewEnabled = true;
            SysToolBar.BtnModifyEnabled = true;
            SysToolBar.BtnDeleteEnabled = true;
            SysToolBar.BtnSaveEnabled = false;
            SysToolBar.BtnCancelEnabled = false;
        }

        private void SetControlLength()
        {
            Sys_FormMaster_fom_Info info = null;
            try
            {
                info = this._ISysFormMasterBL.GetTableFieldLenght() as Sys_FormMaster_fom_Info;
            }
            catch (Exception Ex)
            {
                ShowErrorMessage(Ex);
            }

            if (info != null)
            {
                txtcCode.MaxLength = info.fom_cFormNumber_Length;
                txtcDesc.MaxLength = info.fom_cFormDesc_Length;
                txtcPath.MaxLength = info.fom_cExePath_Length;
                txtcParentCode.MaxLength = info.fom_iParentID_Length;
                txtcID.MaxLength = info.fom_iIndex_Length;
            }
        }

        /// <summary>
        /// 設置文本狀態
        /// </summary>
        /// <param name="type"></param>
        private void SetTxtBox(DefineConstantValue.EditStateEnum type)
        {
            switch (type)
            {
                case DefineConstantValue.EditStateEnum.OE_ReaOnly:
                    txtcCode.Enabled = false;
                    txtcCode.TextBoxSetStatus(true);

                    txtcDesc.Enabled = false;
                    txtcDesc.TextBoxSetStatus(true);
                    txtcPath.Enabled = false;
                    txtcPath.TextBoxSetStatus(true);

                    txtcID.Enabled = false;
                    txtcID.TextBoxSetStatus(true);

                    lvwPur.Enabled = false;
                    btnNew.Enabled = false;
                    btnDel.Enabled = false;
                    tvwMain.Enabled = true;
                    break;
                case DefineConstantValue.EditStateEnum.OE_Insert:
                    txtcCode.Enabled = true;
                    txtcCode.TextBoxSetStatus(false);

                    txtcDesc.Enabled = true;
                    txtcDesc.TextBoxSetStatus(false);
                    txtcPath.Enabled = true;
                    txtcPath.TextBoxSetStatus(false);

                    txtcID.Enabled = false;
                    txtcID.TextBoxSetStatus(true);

                    lvwPur.Enabled = true;
                    btnNew.Enabled = true;
                    btnDel.Enabled = true;
                    tvwMain.Enabled = false;
                    break;
                case DefineConstantValue.EditStateEnum.OE_Update:
                    txtcCode.Enabled = false;
                    txtcCode.TextBoxSetStatus(true);

                    txtcDesc.Enabled = true;
                    txtcDesc.TextBoxSetStatus(false);
                    txtcPath.Enabled = true;
                    txtcPath.TextBoxSetStatus(false);

                    txtcID.Enabled = false;
                    txtcID.TextBoxSetStatus(true);

                    lvwPur.Enabled = true;
                    btnNew.Enabled = true;
                    btnDel.Enabled = true;
                    tvwMain.Enabled = false;
                    break;
            }
        }

        private bool ChecktxtcName()
        {
            DataTypeVerifyResultInfo vInfo = null;
            vInfo = General.VerifyDataType(txtcCode.Text, DataType.ChinaChar);

            if (!vInfo.IsMatch)
            {
                ShowWarningMessage("表单编号不能" + vInfo.Message);
                this.txtcCode.Focus();

                return false;
            }
            else
                return true;
        }

        /// <summary>
        /// 顯示數據
        /// </summary>
        /// <param name="info"></param>
        private void ShowInfo(Sys_FormMaster_fom_Info info)
        {
            SetTxtBox(DefineConstantValue.EditStateEnum.OE_ReaOnly);
            try
            {
                if (info != null)
                {
                    _iRecordID = info.fom_iRecordID.ToString();
                    txtcAdd.Text = info.fom_cAdd.ToString();
                    txtcLast.Text = info.fom_cLast.ToString();

                    txtcCode.Text = info.fom_cFormNumber.ToString();
                    txtcDesc.Text = info.fom_cFormDesc.ToString();
                    txtcPath.Text = info.fom_cExePath.ToString();

                    //txtcParentCode.Text = info.fom_iParentID.ToString();
                    //txtcParentCode.Text = info.fom_cFormNumber.ToString();
                    txtcID.Text = info.fom_iIndex.ToString();

                    lvwPur.Items.Clear();

                    lvwPur.SetDataSource<Sys_FunctionMaster_fum_Info>(info.functionMaster);


                    txtdAddDate.Text = info.fom_dAddDate != null ? info.fom_dAddDate.Value.ToString(Common.DefineConstantValue.gc_DateFormat) : string.Empty;
                    txtdLastDate.Text = info.fom_dLastDate != null ? info.fom_dLastDate.Value.ToString(Common.DefineConstantValue.gc_DateFormat) : string.Empty;
                }
            }
            catch (Exception Ex)
            { ShowErrorMessage(Ex); }
        }

        private void BindTreeView()
        {
            Sys_FormMaster_fom_Info info = new Sys_FormMaster_fom_Info();

            try
            {
                //增加根结点
                this.tvwMain.Nodes.Clear();
                var listObjNodeInfos = this._ISysFormMasterBL.SearchRecords(info);

                foreach (Sys_FormMaster_fom_Info nodeInfo in listObjNodeInfos)
                {
                    if (nodeInfo.fom_iParentID != 0)
                    {
                        continue;
                    }
                    info = nodeInfo;
                    TreeNode root = new TreeNode(info.fom_cFormDesc);
                    root.Name = info.fom_iRecordID.ToString();
                    root.Tag = info.fom_cFormNumber.ToString();
                    this.tvwMain.Nodes.Add(root);

                    //info.fom_iParentID = info.fom_iRecordID;
                    info = new Sys_FormMaster_fom_Info();
                    info.fom_iParentID = int.Parse(root.Name.ToString());

                    //增加子结点
                    foreach (var chile in _ISysFormMasterBL.SearchRecords(info))
                    {
                        info = chile as Sys_FormMaster_fom_Info;
                        TreeNode node = new TreeNode(info.fom_cFormDesc);
                        node.Name = info.fom_iRecordID.ToString();
                        node.Tag = info.fom_cFormNumber.ToString();
                        root.Nodes.Add(node);

                        //info.fom_iParentID = info.fom_iRecordID;
                        info = new Sys_FormMaster_fom_Info();
                        info.fom_iParentID = int.Parse(node.Name.ToString());
                        //增加孙结点
                        foreach (var q in _ISysFormMasterBL.SearchRecords(info))
                        {
                            info = q as Sys_FormMaster_fom_Info;
                            TreeNode nd = new TreeNode(info.fom_cFormDesc);
                            nd.Name = info.fom_iRecordID.ToString();
                            nd.Tag = info.fom_cFormNumber.ToString();
                            node.Nodes.Add(nd);
                        }
                    }
                }

                #region 原添加Web根节点代码

                //读取Web权限
                Sys_FormMaster_fom_Info webinfo = new Sys_FormMaster_fom_Info();
                try
                {
                    webinfo = _ISysFormMasterBL.GetWebTreeRoot();
                }
                catch (Exception Ex)
                {
                    ShowErrorMessage(Ex);
                    return;
                }

                TreeNode webRoot = new TreeNode();
                webRoot.Text = webinfo.fom_cFormDesc;
                webRoot.Name = webinfo.fom_iRecordID.ToString();
                webRoot.Tag = webinfo.fom_cFormNumber.ToString();

                List<Sys_FormMaster_fom_Info> webList = new List<Sys_FormMaster_fom_Info>();
                try
                {
                    webList = _ISysFormMasterBL.GetWebTreeNode(webinfo);
                    if (webList.Count > 0)
                    {
                        foreach (Sys_FormMaster_fom_Info t in webList)
                        {

                            TreeNode tempNode = new TreeNode();
                            tempNode.Text = t.fom_cFormDesc.ToString();
                            tempNode.Name = t.fom_iRecordID.ToString();
                            tempNode.Tag = t.fom_cFormNumber.ToString();

                            List<Sys_FormMaster_fom_Info> tempNodeList = new List<Sys_FormMaster_fom_Info>();
                            tempNodeList = _ISysFormMasterBL.GetWebTreeNode(t);
                            if (tempNodeList.Count > 0)
                            {
                                foreach (Sys_FormMaster_fom_Info tt in tempNodeList)
                                {
                                    TreeNode tempNode2 = new TreeNode();
                                    tempNode2.Text = tt.fom_cFormDesc.ToString();
                                    tempNode2.Name = tt.fom_iRecordID.ToString();
                                    tempNode2.Tag = tt.fom_cFormNumber.ToString();

                                    tempNode.Nodes.Add(tempNode2);
                                }
                            }

                            webRoot.Nodes.Add(tempNode);
                        }
                    }
                }
                catch (Exception Ex)
                {
                    ShowErrorMessage(Ex);
                    return;
                }
                this.tvwMain.Nodes.Add(webRoot);

                #endregion

                tvwMain.ExpandAll();
                //}
            }
            catch (Exception Ex)
            { ShowErrorMessage(Ex); }
        }

        private void SysToolBar_BtnCancelClick(object sender, EventArgs e)
        {
            this.EditState = DefineConstantValue.EditStateEnum.OE_ReaOnly;
            Model.Base.DataBaseCommandKeyInfo comkey = new Model.Base.DataBaseCommandKeyInfo();
            Sys_FormMaster_fom_Info Info = new Sys_FormMaster_fom_Info();
            try
            {
                comkey.KeyValue = _iRecordID;
                if (comkey.KeyValue != string.Empty && comkey.KeyValue != "0")
                {
                    Info.fom_iRecordID = Convert.ToInt32(comkey.KeyValue);
                    Model.IModel.IModelObject result = _ISysFormMasterBL.DisplayRecord(Info);
                    Info = result as Sys_FormMaster_fom_Info;
                    ShowInfo(Info);
                    SetOpenToolBar();
                    SetTxtBox(DefineConstantValue.EditStateEnum.OE_ReaOnly);
                }
            }
            catch (Exception Ex)
            {
                ShowErrorMessage(Ex);
            }
        }

        private void SysToolBar_BtnDeleteClick(object sender, EventArgs e)
        {
            this.EditState = DefineConstantValue.EditStateEnum.OE_Delete;
            Model.General.ReturnValueInfo msg = new Model.General.ReturnValueInfo();
            Model.Base.DataBaseCommandInfo com = new Model.Base.DataBaseCommandInfo();
            Model.Base.DataBaseCommandKeyInfo comkey = new Model.Base.DataBaseCommandKeyInfo();
            Sys_FormMaster_fom_Info Info = new Sys_FormMaster_fom_Info();
            try
            {
                comkey.KeyValue = _iRecordID;
                Info.fom_iParentID = int.Parse(_iRecordID);
                if (_ISysFormMasterBL.SearchRecords(Info).Count > 0)
                {
                    msg.messageText = "该表单含有子表单,请先删除子表单!";
                    ShowInformationMessage(msg.messageText);
                    SetOpenToolBar();
                }
                else
                {
                    if (comkey.KeyValue != string.Empty && comkey.KeyValue != "0")
                    {
                        Info.fom_iRecordID = Convert.ToInt32(comkey.KeyValue);
                        _ISysFormMasterBL.Save(Info, Common.DefineConstantValue.EditStateEnum.OE_Delete);

                        SetOpenToolBar();
                        //Handel(Common.DefineConstantValue.GetReocrdEnum.GR_Next);
                        Bind();
                        BindTreeView();
                    }
                }
            }
            catch (Exception Ex)
            { ShowErrorMessage(Ex); }
        }

        private void SysToolBar_BtnNewClick(object sender, EventArgs e)
        {
            this.EditState = DefineConstantValue.EditStateEnum.OE_Insert;
            SetTxtBox(DefineConstantValue.EditStateEnum.OE_Insert);
            txtcCode.Text = string.Empty;
            txtcDesc.Text = string.Empty;
            txtcPath.Text = string.Empty;

            txtcParentCode.Text = _iRecordID.ToString();
            if (txtcParentCode.Text != string.Empty)
            {
                Sys_FormMaster_fom_Info fomInfo = new Sys_FormMaster_fom_Info();
                fomInfo.fom_iParentID = Convert.ToInt32(txtcParentCode.Text);
                List<Model.IModel.IModelObject> list = _ISysFormMasterBL.SearchRecords(fomInfo);
                if (list.Count > 0)
                {
                    txtcID.Text = (list.Count + 1).ToString();
                }
                else
                {
                    txtcID.Text = "1";
                }
            }
            else
            {
                txtcParentCode.Text = "0";
                txtcID.Text = "1";
            }

            txtcAdd.Text = string.Empty;
            txtcLast.Text = string.Empty;
            txtdAddDate.Text = string.Empty;
            txtdLastDate.Text = string.Empty;
            lvwPur.Items.Clear();
        }

        private void SysToolBar_BtnSaveClick(object sender, EventArgs e)
        {
            Sys_FormMaster_fom_Info info = new Sys_FormMaster_fom_Info();
            Sys_FunctionMaster_fum_Info frmInfo = null;
            if (ChecktxtcName())
            {
                if (txtcCode.Text == string.Empty)
                {
                    _msg.messageText = "表单编号" + Common.DefineConstantValue.SystemMessageText.strMessageText_W_CannotEmpty;
                    ShowWarningMessage(_msg.messageText);
                    txtcCode.Focus();
                }
                else if (txtcDesc.Text == string.Empty)
                {
                    _msg.messageText = "表单描述" + Common.DefineConstantValue.SystemMessageText.strMessageText_W_CannotEmpty;
                    ShowWarningMessage(_msg.messageText);
                    txtcDesc.Focus();
                }
                else
                {
                    try
                    {
                        if (this.EditState == DefineConstantValue.EditStateEnum.OE_Update)
                        {
                            info.fom_iRecordID = Convert.ToInt32(_iRecordID);
                        }
                        info.fom_cFormNumber = txtcCode.Text;
                        info.fom_cFormDesc = txtcDesc.Text;
                        info.fom_cExePath = txtcPath.Text;

                        if (this.EditState == DefineConstantValue.EditStateEnum.OE_Update)
                        {
                            info.fom_iParentID = Convert.ToInt32(_pCode);
                        }
                        if (this.EditState == DefineConstantValue.EditStateEnum.OE_Insert)
                        {
                            if (txtcParentCode.Text != string.Empty)
                            {
                                //info.fom_iParentID = Convert.ToInt32(_pCode);
                                info.fom_iParentID = Convert.ToInt32(txtcParentCode.Text);
                            }
                            else
                            {
                                info.fom_iParentID = 0;
                            }
                        }
                        info.fom_iIndex = Convert.ToInt32(txtcID.Text);

                        for (int i = 0; i < lvwPur.Items.Count; i++)
                        {
                            frmInfo = new Sys_FunctionMaster_fum_Info();
                            frmInfo.fum_cFunctionNumber = lvwPur.Items[i].SubItems[0].Text;
                            //userInfo.cum_cName = lvwMaster.Items[i].SubItems[1].Text;
                            info.functionMaster.Add(frmInfo);
                        }

                        if (this.EditState == DefineConstantValue.EditStateEnum.OE_Insert)
                        {
                            info.fom_cAdd = UserInformation.usm_cUserLoginID;
                            info.fom_dAddDate = DateTime.Now;
                        }
                        info.fom_cLast = UserInformation.usm_cUserLoginID;
                        info.fom_dLastDate = DateTime.Now;
                        if (this.EditState == DefineConstantValue.EditStateEnum.OE_Update)
                        {
                            _msg = _ISysFormMasterBL.Save(info, DefineConstantValue.EditStateEnum.OE_Update);
                        }
                        else
                        {
                            _msg = _ISysFormMasterBL.Save(info, DefineConstantValue.EditStateEnum.OE_Insert);
                        }

                        if (_msg.messageText != null)
                            ShowInformationMessage(_msg.messageText);
                        else
                        {
                            SetOpenToolBar();
                            SetTxtBox(DefineConstantValue.EditStateEnum.OE_ReaOnly);
                        }
                        BindTreeView();
                    }
                    catch (Exception Ex)
                    { ShowErrorMessage(Ex); }
                }
            }
            BindTreeView();
        }

        private void SysToolBar_BtnModifyClick(object sender, EventArgs e)
        {
            this.EditState = DefineConstantValue.EditStateEnum.OE_Update;
            SetTxtBox(DefineConstantValue.EditStateEnum.OE_Update);
            SysToolBar.BtnNewEnabled = false;
            SysToolBar.BtnModifyEnabled = false;
            SysToolBar.BtnDeleteEnabled = false;
            SysToolBar.BtnSaveEnabled = true;
            SysToolBar.BtnCancelEnabled = true;
        }

        private enum enmLvwMaster
        {
            fum_cFunctionNumber,
            fum_cFunctionDesc
        }

        private bool IsExistsItem(string text)
        {
            for (int i = 0; i < lvwPur.Items.Count; i++)
            {

                if (lvwPur.Items[i].SubItems[(int)enmLvwMaster.fum_cFunctionNumber].Text == text)
                {
                    return true;
                }
            }
            return false;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            SysFunctionMasterSearch win = new SysFunctionMasterSearch();
            win.ShowDialog();

            List<Sys_FunctionMaster_fum_Info> items = new List<Sys_FunctionMaster_fum_Info>();
            items = win._RtvInfo;
            if (items != null)
            {
                try
                {

                    List<Sys_FunctionMaster_fum_Info> cumList = new List<Sys_FunctionMaster_fum_Info>();

                    foreach (Sys_FunctionMaster_fum_Info fum in items)
                    {
                        ListViewItem list = new ListViewItem();
                        list.Text = fum.fum_cFunctionNumber.ToString();
                        if (!IsExistsItem(list.Text))
                        {
                            //cumList.Add(cum);

                            ListViewItem it = new ListViewItem(fum.fum_cFunctionNumber.ToString());
                            it.SubItems.Add(fum.fum_cFunctionDesc.ToString());
                            lvwPur.Items.Add(it);
                        }
                    }

                }
                catch (Exception Ex)
                { ShowErrorMessage(Ex); }
            }

            win.Dispose();
            win = null;
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (lvwPur.SelectedItems.Count > 0)
                {
                    if (MessageBox.Show("您確認要删除吗？", "系統信息", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        lvwPur.Items.Remove(lvwPur.SelectedItems[0]);
                    }
                }
            }
            catch (Exception Ex)
            {
                ShowErrorMessage(Ex);
            }
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            Sys_FormMaster_fom_Info fomInfo = new Sys_FormMaster_fom_Info();
            try
            {
                if (tvwMain.SelectedNode != null)
                {
                    fomInfo.fom_iRecordID = int.Parse(tvwMain.SelectedNode.Name.ToString());
                    Model.IModel.IModelObject result = _ISysFormMasterBL.DisplayRecord(fomInfo);
                    fomInfo = result as Sys_FormMaster_fom_Info;
                    if (fomInfo == null)
                    {
                        return;
                    }
                    Sys_FormMaster_fom_Info fomUp = new Sys_FormMaster_fom_Info();
                    if (fomInfo.fom_iIndex > 1)
                    {
                        fomUp.fom_iParentID = fomInfo.fom_iParentID;
                        fomUp.fom_iIndex = fomInfo.fom_iIndex - 1;
                        List<Model.IModel.IModelObject> list = _ISysFormMasterBL.SearchRecords(fomUp);
                        fomUp = list[0] as Sys_FormMaster_fom_Info;

                        fomInfo.fom_iIndex = fomInfo.fom_iIndex - 1;

                        fomUp.fom_iIndex = fomUp.fom_iIndex + 1;

                        _ISysFormMasterBL.Save(fomInfo, DefineConstantValue.EditStateEnum.OE_Update);
                        _ISysFormMasterBL.Save(fomUp, DefineConstantValue.EditStateEnum.OE_Update);
                        txtcID.Text = fomInfo.fom_iIndex.ToString();
                        BindTreeView();
                    }
                }
            }
            catch (Exception Ex)
            {
                ShowErrorMessage(Ex);
            }
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            Sys_FormMaster_fom_Info fomInfo = new Sys_FormMaster_fom_Info();
            try
            {
                if (tvwMain.SelectedNode != null)
                {
                    fomInfo.fom_iRecordID = int.Parse(tvwMain.SelectedNode.Name.ToString());
                    Model.IModel.IModelObject result = _ISysFormMasterBL.DisplayRecord(fomInfo);
                    Sys_FormMaster_fom_Info temp = new Sys_FormMaster_fom_Info();
                    fomInfo = result as Sys_FormMaster_fom_Info;
                    if (fomInfo == null)
                    {
                        return;
                    }
                    temp.fom_iParentID = fomInfo.fom_iParentID;
                    List<Model.IModel.IModelObject> list = _ISysFormMasterBL.SearchRecords(temp);
                    Sys_FormMaster_fom_Info fomDown = new Sys_FormMaster_fom_Info();
                    if (fomInfo.fom_iIndex < list.Count)
                    {
                        fomDown.fom_iParentID = fomInfo.fom_iParentID;
                        fomDown.fom_iIndex = fomInfo.fom_iIndex + 1;
                        list = _ISysFormMasterBL.SearchRecords(fomDown);
                        fomDown = list[0] as Sys_FormMaster_fom_Info;

                        fomInfo.fom_iIndex = fomInfo.fom_iIndex + 1;

                        fomDown.fom_iIndex = fomDown.fom_iIndex - 1;

                        _ISysFormMasterBL.Save(fomInfo, DefineConstantValue.EditStateEnum.OE_Update);
                        _ISysFormMasterBL.Save(fomDown, DefineConstantValue.EditStateEnum.OE_Update);
                        txtcID.Text = fomInfo.fom_iIndex.ToString();
                        BindTreeView();
                    }
                }
            }
            catch (Exception Ex)
            {
                ShowErrorMessage(Ex);
            }
        }

        void ClearColor(TreeNode node)
        {
            node.ForeColor = Color.Black;
            foreach (TreeNode var in node.Nodes)
            {
                var.ForeColor = Color.Black;
                ClearColor(var);
            }
        }

        private void Bind()
        {
            Sys_FormMaster_fom_Info formInfo = new Sys_FormMaster_fom_Info();
            formInfo = this._ISysFormMasterBL.GetRecord_First();
            ShowInfo(formInfo);
        }

        private void tvwMain_AfterSelect(object sender, TreeViewEventArgs e)
        {
            SelectTreeNode();
        }

        private void SelectTreeNode()
        {
            for (int i = 0; i < tvwMain.Nodes.Count; i++)
            {
                ClearColor(tvwMain.Nodes[i]);
            }
            tvwMain.SelectedNode.ForeColor = Color.Red;

            Sys_FormMaster_fom_Info info = new Sys_FormMaster_fom_Info();
            Sys_FormMaster_fom_Info parInfo = new Sys_FormMaster_fom_Info();
            try
            {
                if (tvwMain.SelectedNode != null)
                {
                    info.fom_iRecordID = int.Parse(tvwMain.SelectedNode.Name.ToString());
                    Model.IModel.IModelObject result = _ISysFormMasterBL.DisplayRecord(info);
                    info = result as Sys_FormMaster_fom_Info;
                    if (info == null)
                    {
                        return;
                    }
                    _pCode = info.fom_iParentID.ToString();

                    //查父编号
                    parInfo.fom_iRecordID = info.fom_iParentID;
                    Model.IModel.IModelObject parResult = _ISysFormMasterBL.DisplayRecord(parInfo);
                    parInfo = parResult as Sys_FormMaster_fom_Info;
                    txtcParentCode.Text = parInfo.fom_cFormNumber;
                    //

                    ShowInfo(info);
                }
            }
            catch (Exception Ex)
            {
                ShowErrorMessage(Ex);
            }
        }
    }
}