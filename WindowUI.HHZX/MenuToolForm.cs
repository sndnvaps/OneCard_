using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WindowUI.HHZX.ClassLibrary.Public;
using WeifenLuo.WinFormsUI.Docking;
using UtilityLibrary.WinControls;
using Model.General;
using Model.IModel;
using BLL.IBLL.Base;
using BLL.IBLL.SysMaster;
using BLL.Factory.Base;
using Model.SysMaster;
using BLL.Factory.SysMaster;
//using WindowUI.HHZX.SchoolInternetOfThings.Master;

namespace WindowUI.HHZX
{
    public partial class MenuToolForm : BaseForm
    {
        private Dictionary<string, BaseForm> _childrenForms;
        private OutlookBar _outlookBar;
        DockPanel _dockPanel;
        public TreeNodeInfo _parentNode;
        ILoginFormBL _loginFormBL;
        Sys_UserMaster_usm_Info _userInfo;

        public MenuToolForm(DockPanel dockPanel, TreeNodeInfo parentNode, Sys_UserMaster_usm_Info userInfo)
        {
            InitializeComponent();

            this._loginFormBL = MasterBLLFactory.GetBLL<ILoginFormBL>(MasterBLLFactory.LoginForm);
            this._childrenForms = new Dictionary<string, BaseForm>();
            this._dockPanel = dockPanel;

            this._parentNode = parentNode;
            //
            this._userInfo = userInfo;
            //
            UserInformation = userInfo;

            InitializeOutlookbar(userInfo);

            this.Text = parentNode.Text;
            this.TabText = parentNode.Text;

            //TONO: 便貼停靠位置
            this.Show(this._dockPanel, DockState.DockBottom);
            this.DockState = DockState.DockBottomAutoHide;
        }

        private void InitializeOutlookbar(Sys_UserMaster_usm_Info userInfo)
        {
            this._outlookBar = new OutlookBar();
            _outlookBar.AnimationSpeed = 0;

            TreeNodeInfo rootNodeInfo = _parentNode;
            if (rootNodeInfo == null || rootNodeInfo.TreeNodeInfos == null || rootNodeInfo.TreeNodeInfos.Length == 0)
            {
                return;
            }

            OutlookBarBand outlookBarBand;
            OutlookBarItem outlookBarItem;
            TreeNodeInfo tNodeInfo;

            for (int i = 0; i < rootNodeInfo.TreeNodeInfos.Length; i++)
            {
                tNodeInfo = rootNodeInfo.TreeNodeInfos[i];
                outlookBarBand = new OutlookBarBand(tNodeInfo.Text);
                outlookBarBand.SmallImageList = this.imgLW;
                outlookBarBand.LargeImageList = this.imgLW;

                if (tNodeInfo.TreeNodeInfos != null && tNodeInfo.TreeNodeInfos.Length > 0)
                {
                    for (int j = 0; j < tNodeInfo.TreeNodeInfos.Length; j++)
                    {
                        outlookBarItem = new OutlookBarItem();
                        outlookBarItem.Text = tNodeInfo.TreeNodeInfos[j].Text;
                        outlookBarItem.Tag = tNodeInfo.TreeNodeInfos[j];
                        outlookBarItem.ImageIndex = tNodeInfo.TreeNodeInfos[j].ImageIndex;
                        outlookBarBand.Items.Add(outlookBarItem);
                    }
                }
                outlookBarBand.Background = this.BackColor;
                outlookBarBand.TextColor = this.ForeColor;

                this._outlookBar.Bands.Add(outlookBarBand);
            }

            this._outlookBar.Dock = DockStyle.Fill;
            this._outlookBar.SetCurrentBand(0);
            this._outlookBar.ItemClicked += new OutlookBarItemClickedHandler(outlookBar_ItemClicked);
            this.pnlContainer.Controls.AddRange(new Control[] { this._outlookBar });
        }

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

        public void MenuToolForm_ItemClicked(string menuItemTag)
        {
            BaseForm frm;

            string[] formNames;
            string formName = string.Empty;

            formNames = menuItemTag.Split('.');

            if (formNames.Length > 0)
            {
                formName = formNames[formNames.Length - 1];
            }

            IDockContent[] idcs = this._dockPanel.Contents.ToArray();
            string itemFormName = string.Empty;
            bool isExistForm = false;

            foreach (IDockContent idc in idcs)
            {
                DockContentHandler dch = idc.DockHandler;
                itemFormName = dch.Form.Name;
                if (itemFormName == formName)
                {
                    isExistForm = true;
                    frm = dch.Form as BaseForm;
                    break;
                }
            }

            if (!isExistForm)
            {
                frm = GetFormIn(menuItemTag);
            }
            else
            {
                frm = null;
            }

            if (frm != null)
            {
                Sys_UserMaster_usm_Info usmInfo = new Sys_UserMaster_usm_Info();
                usmInfo = _userInfo;
                Sys_FormMaster_fom_Info fomInfo = new Sys_FormMaster_fom_Info();
                List<Sys_UserMaster_usm_Info> usmInfoList = new List<Sys_UserMaster_usm_Info>();
                fomInfo.fom_cFormNumber = GetFormIn(menuItemTag).Name.ToString();
                usmInfo.formMasterList.Clear();
                usmInfo.formMasterList.Add(fomInfo);
                foreach (Sys_UserMaster_usm_Info usm in _loginFormBL.SearchRecords(usmInfo))
                {
                    usmInfoList.Add(usm);
                }
                frm._setFunctionList = usmInfoList[0].functionMasterList;
                frm.UserInformation = this.UserInformation;
                frm.Show(this._dockPanel);
            }
        }

        void RuningEXE(string fileName, string workingDirectory)
        {
            System.Diagnostics.ProcessStartInfo info = new System.Diagnostics.ProcessStartInfo();
            info.FileName = fileName;
            info.Arguments = "text.txt";
            info.WorkingDirectory = workingDirectory;
            System.Diagnostics.Process pro;
            try
            {
                pro = System.Diagnostics.Process.Start(info);
            }
            catch (System.ComponentModel.Win32Exception ex)
            {
                MessageBox.Show("系统找不到指定的文件。\r{0}");
                return;
            }
        }

        void outlookBar_ItemClicked(OutlookBarBand band, OutlookBarItem item)
        {
            if (item.Tag != null)
            {
                TreeNodeInfo tNodeInfo = null;

                tNodeInfo = item.Tag as TreeNodeInfo;
                if (tNodeInfo != null)
                {
                    if (tNodeInfo.Remark == "EXE")
                    {
                        RuningEXE(tNodeInfo.FileName, tNodeInfo.WorkingDirectory);
                    }
                    else
                    {
                        MenuToolForm_ItemClicked(tNodeInfo.Tag);
                    }
                }
            }
        }
    }
}
