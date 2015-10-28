using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL.IBLL.SysMaster;
using Model.SysMaster;
using DAL.IDAL.SysMaster;
using DAL.Factory.SysMaster;

namespace BLL.DAL.SysMaster
{
    class SysFormMasterBL : ISysFormMasterBL
    {
        ISysFormMasterDA _sysFormMasterDA;

        public SysFormMasterBL()
        {
            this._sysFormMasterDA = MasterDAFactory.GetDAL<ISysFormMasterDA>(MasterDAFactory.SysFormMaster);
        }

        #region IDataBaseCommandBL<Sys_FormMaster_frm_Info> Members

        public Sys_FormMaster_fom_Info GetRecord_First()
        {
            Sys_FormMaster_fom_Info info = null;
            try
            {
                info = this._sysFormMasterDA.GetRecord_First();
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            return info;
        }

        public Sys_FormMaster_fom_Info GetRecord_Last()
        {
            Sys_FormMaster_fom_Info info = null;
            try
            {
                info = this._sysFormMasterDA.GetRecord_Last();
            }
            catch (Exception Ex)
            {
                throw Ex;
            }

            return info;
        }

        public Sys_FormMaster_fom_Info GetRecord_Previous(Model.Base.DataBaseCommandInfo commandInfo)
        {
            Sys_FormMaster_fom_Info info = null;
            if (commandInfo.KeyInfoList == null)
            {
                return info;
            }
            else
            {
                try
                {
                    info = this._sysFormMasterDA.GetRecord_Previous(commandInfo);
                }
                catch (Exception Ex)
                {
                    throw Ex;
                }

                return info;
            }
        }

        public Sys_FormMaster_fom_Info GetRecord_Next(Model.Base.DataBaseCommandInfo commandInfo)
        {
            Sys_FormMaster_fom_Info info = null;
            if (commandInfo.KeyInfoList == null)
            {
                return info;
            }
            else
            {
                try
                {
                    info = this._sysFormMasterDA.GetRecord_Next(commandInfo);
                }
                catch (Exception Ex)
                {
                    throw Ex;
                }

                return info;
            }
        }

        #endregion

        #region IExtraBL Members

        public bool IsExistRecord(object KeyObject)
        {
            throw new NotImplementedException();
        }

        public Model.IModel.IModelObject LockRecord(object KeyObject)
        {
            throw new NotImplementedException();
        }

        public Model.IModel.IModelObject UnLockRecord(object KeyObject)
        {
            throw new NotImplementedException();
        }

        public Model.IModel.IModelObject GetTableFieldLenght()
        {
            Model.IModel.IModelObject info = null;
            try
            {
                info = _sysFormMasterDA.GetTableFieldLenght();
            }
            catch (Exception Ex)
            {
                throw Ex;
            }

            return info;
        }

        #endregion

        #region IMainBL Members

        public Model.IModel.IModelObject DisplayRecord(Model.IModel.IModelObject itemEntity)
        {
            if (itemEntity == null)
            {
                return null;
            }
            else
            {
                Sys_FormMaster_fom_Info info = null;
                try
                {
                    info = this._sysFormMasterDA.DisplayRecord(itemEntity);
                }
                catch (Exception Ex)
                {
                    throw Ex;
                }
                return info;
            }
        }

        public List<Model.IModel.IModelObject> SearchRecords(Model.IModel.IModelObject itemEntity)
        {
            List<Model.IModel.IModelObject> info_imo = new List<Model.IModel.IModelObject>();
            List<Sys_FormMaster_fom_Info> info = new List<Sys_FormMaster_fom_Info>();
            try
            {
                info = _sysFormMasterDA.SearchRecords(itemEntity);
                foreach (Sys_FormMaster_fom_Info i in info)
                {
                    info_imo.Add(i);
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            return info_imo;
        }

        public Model.General.ReturnValueInfo Save(Model.IModel.IModelObject itemEntity, Common.DefineConstantValue.EditStateEnum EditMode)
        {
            bool b;
            Model.General.ReturnValueInfo msg = new Model.General.ReturnValueInfo();
            Sys_FormMaster_fom_Info info = null;
            info = itemEntity as Sys_FormMaster_fom_Info;

            if (info == null)
            {
                msg.boolValue = false;
                msg.messageText = "传入的数据为空！";

                return msg;
            }

            try
            {
                switch (EditMode)
                {
                    case Common.DefineConstantValue.EditStateEnum.OE_Delete:
                        b = this._sysFormMasterDA.DeleteRecord(info);
                        if (b == true)
                        {
                            msg.boolValue = true;

                            msg.messageText = Common.DefineConstantValue.SystemMessageText.strMessageText_I_RecordByDelete;
                        }
                        break;
                    case Common.DefineConstantValue.EditStateEnum.OE_Insert:

                        b = this._sysFormMasterDA.IsExistRecord(info);
                        if (b == false)
                        {
                            info.fom_dAddDate = DateTime.Now;

                            info.fom_dLastDate = DateTime.Now;

                            msg.boolValue = this._sysFormMasterDA.InsertRecord(info);
                        }
                        else
                        {
                            msg.messageText = Common.DefineConstantValue.SystemMessageText.strMessageText_I_AddFail + "  表单编号重复！";
                        }
                        break;
                    case Common.DefineConstantValue.EditStateEnum.OE_Update:

                        info.fom_dLastDate = DateTime.Now;

                        msg.boolValue = this._sysFormMasterDA.UpdateRecord(info);


                        //if (b == true)
                        //{
                        //    msg.messageText = Common.DefineConstantValue.SystemMessageText.strMessageText_I_UpdateSuccess;
                        //}
                        //else
                        //{
                        //    msg.messageText = Common.DefineConstantValue.SystemMessageText.strMessageText_I_UpdateFail;
                        //}
                        break;
                }
            }
            catch (Exception Ex)
            {
                msg.messageText = Ex.Message;

            }
            return msg;
        }

        #endregion

        //public Sys_FormMaster_fom_Info GetWebTreeRoot()
        //{
        //    try
        //    {
        //        return _sysFormMasterDA.GetWebTreeRoot();
        //    }
        //    catch (Exception Ex)
        //    {
        //        throw Ex;
        //    }
        //}

        //public List<Sys_FormMaster_fom_Info> GetWebTreeNode(Sys_FormMaster_fom_Info info)
        //{
        //    try
        //    {
        //        return _sysFormMasterDA.GetWebTreeNode(info);
        //    }
        //    catch (Exception Ex)
        //    {

        //        throw Ex;
        //    }
        //}

        #region ISysFormMasterBL Members

        /// <summary>
        /// 根据用户权限生成相关菜单
        /// </summary>
        /// <param name="searchCondition"></param>
        /// <param name="loginUser"></param>
        /// <returns></returns>
        public List<Sys_FormMaster_fom_Info> GetUserMenu(Model.IModel.IModelObject searchCondition, Sys_UserMaster_usm_Info loginUser)
        {
            try
            {
                List<Sys_FormMaster_fom_Info> allMenu = this._sysFormMasterDA.SearchRecords(searchCondition);

                if (loginUser.usm_cUserLoginID != "sa")
                {
                    List<Sys_FormMaster_fom_Info> userMenu = this._sysFormMasterDA.GetUserMenu(loginUser);

                    if (allMenu != null && userMenu != null)
                    {
                        foreach (Sys_FormMaster_fom_Info item in userMenu)
                        {
                            Sys_FormMaster_fom_Info menu = allMenu.FirstOrDefault(t => t.fom_iRecordID == item.fom_iRecordID);

                            if (menu != null)
                            {
                                menu.isEnable = true;
                            }

                            Sys_FormMaster_fom_Info parentMenu = allMenu.FirstOrDefault(t => t.fom_iRecordID == item.fom_iParentID);

                            if (parentMenu != null)
                            {
                                parentMenu.isEnable = true;

                                Sys_FormMaster_fom_Info ppMenu = allMenu.FirstOrDefault(t => t.fom_iRecordID == parentMenu.fom_iParentID);

                                if (ppMenu != null)
                                {
                                    ppMenu.isEnable = true;
                                }
                            }
                        }
                    }
                }
                else
                {
                    foreach (Sys_FormMaster_fom_Info item in allMenu)
                    {
                        item.isEnable = true;
                    }
                }

                return allMenu;
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }

        #endregion
    }
}
