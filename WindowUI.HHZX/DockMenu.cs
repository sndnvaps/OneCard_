using System.Collections.Generic;
using Model.General;
using BLL.Factory.Base;
using System;
using System.Linq;
using System.Text;
using WeifenLuo.WinFormsUI.Docking;
using Model.SysMaster;

namespace WindowUI.HHZX
{
    public class DockMenu
    {
        private List<MenuToolForm> menuToolForms = new List<MenuToolForm>();
        private TreeNodeInfo[] treeNodeInfos = null;
        public DockMenu(DockPanel dockPanel, Sys_UserMaster_usm_Info userInfo)
        {
            try
            {
                if (userInfo.usm_cUserLoginID.ToUpper() == "SA")
                {
                    treeNodeInfos = SystemMenuBLLFactory.Instance.GetISystemMenuBLL().GetMenuTreeNodes();
                }
                else
                {
                    treeNodeInfos = SystemMenuBLLFactory.Instance.GetISystemMenuBLL().CheckUser(userInfo);
                }

                foreach (TreeNodeInfo node in treeNodeInfos)
                {
                    if (node.Name == "SystemMenu")
                    {
                        node.Index = 4;
                    }
                    MenuToolForm mtf = new MenuToolForm(dockPanel, node, userInfo);
                    menuToolForms.Add(mtf);
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void Dispose()
        {
            foreach (MenuToolForm node in menuToolForms)
            {
                node.Dispose();
            }
        }

        public void OpenForm(string formName)
        {
            menuToolForms[0].MenuToolForm_ItemClicked(formName);
        }
    }
}
