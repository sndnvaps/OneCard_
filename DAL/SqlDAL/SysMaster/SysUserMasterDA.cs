﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.IDAL.SysMaster;
using model = Model.SysMaster;
using LinqToSQLModel;
using DAL.SqlDAL.LocalLayer;
using System.Data.Linq.SqlClient;
using Model.SysMaster;
using Common;

namespace DAL.SqlDAL.SysMaster
{
    public class SysUserMasterDA : ISysUserMasterDA
    {

        private Sys_UserMaster_usm_Info FindUserRole(Sys_UserMaster_usm_Info info)
        {
            string sqlString = string.Empty;
            sqlString += "SELECT rlm_cRoleID,rlm_cRoleDesc " + Environment.NewLine;
            sqlString += "FROM Sys_RoleMaster_rlm " + Environment.NewLine;
            sqlString += "LEFT JOIN  Sys_UserRoles_usr" + Environment.NewLine;
            sqlString += "ON rlm_cRoleID=usr_cRoleID" + Environment.NewLine;
            sqlString += "LEFT JOIN Sys_UserMaster_usm" + Environment.NewLine;
            sqlString += "ON usm_cUserLoginID=usr_cUserLoginID WHERE usm_cUserLoginID='" + info.usm_cUserLoginID + "'";

            IEnumerable<Sys_RoleMaster_rlm_Info> infos = null;
            List<Sys_RoleMaster_rlm_Info> infoList = null;

            try
            {
                using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                {
                    infos = db.ExecuteQuery<Sys_RoleMaster_rlm_Info>(sqlString, new object[] { });

                    if (infos != null)
                    {
                        infoList = infos.ToList<Sys_RoleMaster_rlm_Info>();
                    }
                    foreach (Sys_RoleMaster_rlm_Info t in infoList)
                    {
                        info.roleMasterList.Add(t);
                    }
                    return info;
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }

        }

        public Model.SysMaster.Sys_UserMaster_usm_Info GetRecord_First()
        {
            try
            {

                using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                {
                    IQueryable<Sys_UserMaster_usm> taQuery =
                        (from ta in db.Sys_UserMaster_usm
                         orderby ta.usm_iRecordID ascending
                         select ta).Take(1);
                    Sys_UserMaster_usm_Info info = new Sys_UserMaster_usm_Info();
                    if (taQuery.Count() > 0)
                    {
                        foreach (var t in taQuery)
                        {
                            info = Common.General.CopyObjectValue<Sys_UserMaster_usm, Sys_UserMaster_usm_Info>(t);
                            FindUserRole(info);
                        }
                    }
                    return info;
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public Model.SysMaster.Sys_UserMaster_usm_Info GetRecord_Last()
        {
            try
            {
                using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                {
                    IQueryable<Sys_UserMaster_usm> taQuery =
                        (from ta in db.Sys_UserMaster_usm
                         orderby ta.usm_iRecordID descending
                         select ta).Take(1);
                    Sys_UserMaster_usm_Info info = new Sys_UserMaster_usm_Info();
                    if (taQuery.Count() > 0)
                    {
                        foreach (var t in taQuery)
                        {
                            info = Common.General.CopyObjectValue<Sys_UserMaster_usm, Sys_UserMaster_usm_Info>(t);
                            FindUserRole(info);
                        }
                    }
                    return info;
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public Model.SysMaster.Sys_UserMaster_usm_Info GetRecord_Previous(Model.Base.DataBaseCommandInfo commandInfo)
        {
            Sys_UserMaster_usm_Info info = null;
            try
            {
                using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                {
                    string iRecordId = string.Empty;
                    foreach (var id in commandInfo.KeyInfoList)
                    {
                        iRecordId = id.KeyValue;
                        break;
                    }
                    IQueryable<Sys_UserMaster_usm> taQuery =
                        (from ta in db.Sys_UserMaster_usm
                         where ta.usm_iRecordID < Convert.ToInt32(iRecordId)
                         orderby ta.usm_iRecordID descending
                         select ta).Take(1);

                    if (taQuery.Count() > 0)
                    {
                        foreach (var t in taQuery)
                        {
                            info = Common.General.CopyObjectValue<Sys_UserMaster_usm, Sys_UserMaster_usm_Info>(t);
                            FindUserRole(info);
                        }
                    }
                    return info;
                }
            }
            catch (Exception Ex)
            {
                return info;
            }
        }

        public Model.SysMaster.Sys_UserMaster_usm_Info GetRecord_Next(Model.Base.DataBaseCommandInfo commandInfo)
        {
            Sys_UserMaster_usm_Info info = null;
            try
            {
                using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                {
                    string iRecordId = string.Empty;
                    foreach (var id in commandInfo.KeyInfoList)
                    {
                        iRecordId = id.KeyValue;
                        break;
                    }
                    IQueryable<Sys_UserMaster_usm> taQuery =
                        (from ta in db.Sys_UserMaster_usm
                         where ta.usm_iRecordID > Convert.ToInt32(iRecordId)
                         orderby ta.usm_iRecordID ascending
                         select ta).Take(1);
                    if (taQuery.Count() > 0)
                    {
                        foreach (var t in taQuery)
                        {
                            info = Common.General.CopyObjectValue<Sys_UserMaster_usm, Sys_UserMaster_usm_Info>(t);
                            FindUserRole(info);
                        }
                    }
                    return info;
                }
            }
            catch (Exception Ex)
            {
                return info;
            }
        }

        public bool IsExistRecord(object KeyObject)
        {
            using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
            {
                Sys_UserMaster_usm usm = new Sys_UserMaster_usm();
                try
                {
                    usm = Common.General.CopyObjectValue<object, Sys_UserMaster_usm>(KeyObject);

                    IQueryable<Sys_UserMaster_usm> taQuery =
                            (from ta in db.Sys_UserMaster_usm where ta.usm_cUserLoginID == usm.usm_cUserLoginID select ta);
                    if (taQuery.Count() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception Ex)
                {
                    throw Ex;
                }
            }
        }

        public Model.General.ReturnValueInfo LockRecord(object KeyObject)
        {
            throw new NotImplementedException();
        }

        public Model.General.ReturnValueInfo UnLockRecord(object KeyObject)
        {
            throw new NotImplementedException();
        }

        public bool IsMyLockedRecord(object KeyObject)
        {
            throw new NotImplementedException();
        }

        public Model.IModel.IModelObject GetTableFieldLenght()
        {
            LocalGeneral general = new LocalGeneral();
            Sys_UserMaster_usm_Info info = null;

            try
            {
                info = general.GetTableFieldLenght<Sys_UserMaster_usm_Info>("Sys_UserMaster_usm");
            }
            catch (Exception Ex)
            {
                throw Ex;
            }

            return info;
        }

        public bool InsertRecord(Model.SysMaster.Sys_UserMaster_usm_Info infoObject)
        {
            using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
            {
                Sys_UserMaster_usm usm = new Sys_UserMaster_usm();
                try
                {
                    usm = Common.General.CopyObjectValue<Sys_UserMaster_usm_Info, Sys_UserMaster_usm>(infoObject);


                    if (infoObject.roleMasterList != null && infoObject.roleMasterList.Count > 0)
                    {
                        for (int i = 0; i < infoObject.roleMasterList.Count; i++)
                        {

                            Sys_RoleMaster_rlm_Info usmInfo = infoObject.roleMasterList[i];

                            Sys_UserRoles_usr item = new Sys_UserRoles_usr();

                            item.usr_cUserLoginID = infoObject.usm_cUserLoginID;
                            item.usr_cRoleID = usmInfo.rlm_cRoleID;
                            //courseitem.cum_cNumber;
                            usm.Sys_UserRoles_usr.Add(item);
                            //db.Sys_UserRoles_usrs.InsertOnSubmit(item);
                        }
                    }


                    db.Sys_UserMaster_usm.InsertOnSubmit(usm);
                    db.SubmitChanges();
                    return true;
                }
                catch (Exception Ex)
                {
                    throw Ex;
                }
            }
        }

        public bool UpdateRecord(Model.SysMaster.Sys_UserMaster_usm_Info infoObject)
        {
            using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
            {
                Sys_UserMaster_usm usm = new Sys_UserMaster_usm();
                try
                {

                    usm = db.Sys_UserMaster_usm.SingleOrDefault(t => t.usm_iRecordID == infoObject.usm_iRecordID);

                    for (int i = 0; i < usm.Sys_UserRoles_usr.Count; i++)
                    {
                        Sys_UserRoles_usr sta = usm.Sys_UserRoles_usr[i];
                        db.Sys_UserRoles_usr.DeleteOnSubmit(sta);
                    }



                    string sqlString = string.Empty;
                    Sys_UserMaster_usm_Info info = new Sys_UserMaster_usm_Info();

                    info = Common.General.CopyObjectValue<Sys_UserMaster_usm, Sys_UserMaster_usm_Info>(usm);

                    IEnumerable<Sys_UserMaster_usm_Info> IEusm = null;
                    IEnumerable<Sys_UserRoles_usr_Info> IEusr = null;

                    sqlString += "UPDATE Sys_UserMaster_usm" + Environment.NewLine;
                    sqlString += " SET usm_cUserLoginID='" + infoObject.usm_cUserLoginID + "'," + Environment.NewLine;
                    sqlString += " usm_cChaName='" + infoObject.usm_cChaName + "'," + Environment.NewLine;

                    if (infoObject.usm_cPwd != null && infoObject.usm_cPwd != "")
                    {
                        sqlString += " usm_cPwd='" + infoObject.usm_cPwd + "'," + Environment.NewLine;
                    }

                    sqlString += " usm_cEMail='" + infoObject.usm_cEmail + "'," + Environment.NewLine;

                    sqlString += " usm_iLock='" + infoObject.usm_iLock + "'," + Environment.NewLine;
                    sqlString += " usm_cLast='" + infoObject.usm_cLast + "'," + Environment.NewLine;
                    sqlString += " usm_dLastDate='" + infoObject.usm_dLastDate.ToString(DefineConstantValue.gc_DateTimeFormat) + "'" + Environment.NewLine;

                    sqlString += " WHERE usm_iRecordID='" + infoObject.usm_iRecordID + "'";

                    IEusm = db.ExecuteQuery<Sys_UserMaster_usm_Info>(sqlString, new object[] { });

                    sqlString = string.Empty;
                    sqlString += "DELETE FROM Sys_UserRoles_usr WHERE usr_cUserLoginID='" + infoObject.usm_cUserLoginID + "'";
                    IEusr = db.ExecuteQuery<Sys_UserRoles_usr_Info>(sqlString, new object[] { });


                    if (infoObject.roleMasterList != null && infoObject.roleMasterList.Count > 0)
                    {
                        for (int i = 0; i < infoObject.roleMasterList.Count; i++)
                        {
                            sqlString = string.Empty;
                            Sys_RoleMaster_rlm_Info rlmInfo = infoObject.roleMasterList[i];

                            sqlString += "INSERT INTO Sys_UserRoles_usr" + Environment.NewLine;
                            sqlString += "(usr_cUserLoginID, usr_cRoleID)" + Environment.NewLine;
                            sqlString += " VALUES " + Environment.NewLine;
                            sqlString += "('" + infoObject.usm_cUserLoginID + "','" + rlmInfo.rlm_cRoleID + "')";

                            IEusr = db.ExecuteQuery<Sys_UserRoles_usr_Info>(sqlString, new object[] { });
                        }
                    }
                    
                    return true;
                }
                catch (Exception Ex)
                {
                    throw Ex;
                }
            }
        }

        public bool DeleteRecord(Model.IModel.IModelObject KeyObject)
        {
            Sys_UserMaster_usm_Info info = null;
            try
            {
                info = KeyObject as Sys_UserMaster_usm_Info;
                using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                {
                    Sys_UserMaster_usm usm = db.Sys_UserMaster_usm.Single<Sys_UserMaster_usm>(i => i.usm_iRecordID == info.usm_iRecordID);

                    for (int i = 0; i < usm.Sys_UserRoles_usr.Count; i++)
                    {
                        Sys_UserRoles_usr sta = usm.Sys_UserRoles_usr[i];
                        db.Sys_UserRoles_usr.DeleteOnSubmit(sta);
                    }


                    db.Sys_UserMaster_usm.DeleteOnSubmit(usm);
                    db.SubmitChanges();
                    return true;
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public Model.SysMaster.Sys_UserMaster_usm_Info DisplayRecord(Model.IModel.IModelObject KeyObject)
        {
            Sys_UserMaster_usm_Info usm = new Sys_UserMaster_usm_Info();
            Sys_UserMaster_usm_Info info = new Sys_UserMaster_usm_Info();
            usm = KeyObject as Sys_UserMaster_usm_Info;
            try
            {

                using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                {
                    IQueryable<Sys_UserMaster_usm> taQuery =
                        (from ta in db.Sys_UserMaster_usm
                         where ta.usm_iRecordID == usm.usm_iRecordID
                         select ta).Take(1);

                    if (taQuery != null)
                    {
                        foreach (Sys_UserMaster_usm t in taQuery)
                        {
                            info = Common.General.CopyObjectValue<Sys_UserMaster_usm, Sys_UserMaster_usm_Info>(t);
                            FindUserRole(info);
                        }
                    }
                    return info;
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public List<Model.SysMaster.Sys_UserMaster_usm_Info> SearchRecords(Model.IModel.IModelObject searchCondition)
        {
            string sqlString = string.Empty;
            string whereString = string.Empty;

            sqlString = "SELECT TOP " + Common.DefineConstantValue.ListRecordMaxCount.ToString() + Environment.NewLine;
            sqlString += " usm_iRecordID," + Environment.NewLine;
            sqlString += " usm_cUserLoginID," + Environment.NewLine;
            sqlString += " usm_cChaName," + Environment.NewLine;
            sqlString += " usm_cEmail," + Environment.NewLine;
            sqlString += " (CASE usm_iLock WHEN 1 THEN N'已锁' WHEN 0 THEN N'未锁' END) AS iLock," + Environment.NewLine;
            sqlString += " usm_cRemark," + Environment.NewLine;
            sqlString += " usm_cAdd," + Environment.NewLine;
            sqlString += " usm_dAddDate," + Environment.NewLine;
            sqlString += " usm_cLast," + Environment.NewLine;
            sqlString += " usm_iLock," + Environment.NewLine;
            sqlString += " usm_dLastDate " + Environment.NewLine;
            sqlString += " FROM Sys_UserMaster_usm" + Environment.NewLine;


            Sys_UserMaster_usm_Info info = null;

            info = searchCondition as Sys_UserMaster_usm_Info;

            if (info != null)
            {
                whereString = " WHERE 1=1 ";
                if (info.usm_iRecordID != 0)
                {
                    whereString += "AND usm_iRecordID = " + info.usm_iRecordID.ToString() + "";
                }
                else
                {
                    if (!string.IsNullOrEmpty(info.usm_cUserLoginID))
                    {
                        if (info.usm_cUserLoginID.ToString().Contains("*") || info.usm_cUserLoginID.ToString().Contains("?"))
                        {
                            whereString += " AND usm_cUserLoginID LIKE N'" + LocalDefine.General.ReplaceSQLLikeCondition(info.usm_cUserLoginID) + "'";
                        }
                        else
                        {
                            whereString += "AND usm_cUserLoginID = N'" + info.usm_cUserLoginID.ToString().Trim() + "'";
                        }
                    }
                    if (!string.IsNullOrEmpty(info.usm_cChaName))
                    {
                        if (info.usm_cChaName.ToString().Contains("*") || info.usm_cChaName.ToString().Contains("?"))
                        {
                            whereString += " AND usm_cChaName LIKE N'" + LocalDefine.General.ReplaceSQLLikeCondition(info.usm_cChaName) + "'";
                        }
                        else
                        {
                            whereString += "AND usm_cChaName = N'" + info.usm_cChaName.ToString().Trim() + "'";
                        }
                    }
                    if (!string.IsNullOrEmpty(info.usm_cEmail))
                    {
                        if (info.usm_cEmail.ToString().Contains("*") || info.usm_cEmail.ToString().Contains("?"))
                        {
                            whereString += " AND usm_cEmail LIKE N'" + LocalDefine.General.ReplaceSQLLikeCondition(info.usm_cEmail) + "'";
                        }
                        else
                        {
                            whereString += "AND usm_cEmail = N'" + info.usm_cEmail.ToString().Trim() + "'";
                        }
                    }
                }
            }

            sqlString += whereString;

            IEnumerable<Sys_UserMaster_usm_Info> infos = null;
            List<Sys_UserMaster_usm_Info> infoList = null;

            try
            {
                using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                {
                    infos = db.ExecuteQuery<Sys_UserMaster_usm_Info>(sqlString, new object[] { });

                    if (infos != null)
                    {
                        infoList = infos.ToList<Sys_UserMaster_usm_Info>();
                    }

                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            return infoList;
        }
    }
}
