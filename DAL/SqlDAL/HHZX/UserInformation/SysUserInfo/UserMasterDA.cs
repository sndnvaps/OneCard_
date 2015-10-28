using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.IDAL.HHZX.UserInformation.SysUserInfo;
using LinqToSQLModel;
using Model.SysMaster;

namespace DAL.SqlDAL.HHZX.UserInformation.SysUserInfo
{
    public class UserMasterDA : IUserMasterDA
    {

        #region IUserMasterDA 成员

        public List<Sys_UserMaster_usm_Info> SearchRecords(Sys_UserMaster_usm_Info infoObj)
        {
            List<Sys_UserMaster_usm_Info> listReturn = null;

            try
            {
                string strSql = "select * from dbo.Sys_UserMaster_usm where 1=1 ";

                if(infoObj != null)
                {
                    if (!String.IsNullOrEmpty(infoObj.usm_cUserLoginID))
                    {
                        strSql += " and usm_cUserLoginID like %'" + infoObj.usm_cUserLoginID + "'% ";
                    }
                }

                IEnumerable<Sys_UserMaster_usm_Info> infos = null;

                using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                {
                    infos = db.ExecuteQuery<Sys_UserMaster_usm_Info>(strSql, new object[] { });
                    if (infos != null)
                    {
                        listReturn = infos.ToList();
                    }
                }
            }
            catch
            {
                throw;
            }

            return listReturn;
        }

        public bool SaveRecord(Sys_UserMaster_usm_Info infoObj)
        {
            try
            {
                using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                {
                    LinqToSQLModel.Sys_UserMaster_usm newTab = Common.General.CopyObjectValue<Sys_UserMaster_usm_Info, LinqToSQLModel.Sys_UserMaster_usm>(infoObj);
                    db.Sys_UserMaster_usm.InsertOnSubmit(newTab);
                    db.SubmitChanges();
                }
                return true;
            }
            catch
            {
                throw;
            }
        }

        public bool UpdateRecord(Sys_UserMaster_usm_Info infoObj)
        {
            try
            {
                using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                {
                    Sys_UserMaster_usm query = db.Sys_UserMaster_usm.SingleOrDefault(t => t.usm_iRecordID == infoObj.usm_iRecordID);
                    if (query != null)
                    {
                        query.usm_cEmail = infoObj.usm_cEmail;
                        query.usm_cLast = infoObj.usm_cLast;
                        query.usm_dLastDate = infoObj.usm_dLastDate;
                        query.usm_iLock = infoObj.usm_iLock;
                        query.usm_cRemark = infoObj.usm_cRemark;
                        query.usm_cPwd = infoObj.usm_cPwd;
                        query.usm_cChaName = infoObj.usm_cChaName;

                        db.SubmitChanges();
                    }
                }

                return true;
            }
            catch
            {
                throw;
            }
        }

        public bool DeleteRecord(int id)
        {
            try
            {
                using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                {
                    var ret_usm = from usm in db.Sys_UserMaster_usm where usm.usm_iRecordID == id select usm;

                    if (ret_usm.Count() > 0)
                    {
                        db.Sys_UserMaster_usm.DeleteAllOnSubmit(ret_usm);
                        db.SubmitChanges();
                    }
                }
                return true;
            }
            catch
            {
                throw;
            }
        }

        #endregion
    }
}
