using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.IDAL.HHZX;
using LinqToSQLModel;
using Model.HHZX;
using DAL.IDAL.HHZX.UserInformation.CardUserInfo;
using Model.HHZX.UserInfomation.CardUserInfo;
using Model.General;
using Model.IModel;

namespace DAL.SqlDAL.HHZX.UserInformation.CardUserInfo
{
    public class DepartmentMasterDA : IDepartmentMasterDA
    {
        public DepartmentMaster_dpm_Info DisplayRecord(IModelObject KeyObject)
        {
            DepartmentMaster_dpm_Info resInfo = null;
            DepartmentMaster_dpm_Info searchInfo = KeyObject as DepartmentMaster_dpm_Info;
            if (searchInfo == null)
            {
                return resInfo;
            }
            else
            {
                try
                {
                    using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                    {
                        DepartmentMaster_dpm queryInfo = db.DepartmentMaster_dpm.Where(x => x.dpm_RecordID == searchInfo.dpm_RecordID).FirstOrDefault();
                        resInfo = Common.General.CopyObjectValue<DepartmentMaster_dpm, DepartmentMaster_dpm_Info>(queryInfo);
                    }
                }
                catch (Exception ex)
                {

                    throw ex;
                }
                return resInfo;
            }
        }

        public List<DepartmentMaster_dpm_Info> SearchRecords(IModelObject infoObj)
        {
            List<DepartmentMaster_dpm_Info> listReturn = null;

            DepartmentMaster_dpm_Info searchInfo = infoObj as DepartmentMaster_dpm_Info;
            if (searchInfo != null)
            {
                try
                {
                    StringBuilder sbSQL = new StringBuilder();
                    sbSQL.AppendLine("SELECT TOP");
                    sbSQL.AppendLine(Common.DefineConstantValue.ListRecordMaxCount.ToString());
                    sbSQL.AppendLine("* FROM DepartmentMaster_dpm WHERE 1 = 1");
                    if (!string.IsNullOrEmpty(searchInfo.dpm_cName))
                    {
                        sbSQL.AppendLine("AND dpm_cName LIKE N'%" + searchInfo.dpm_cName + "%'");
                    }

                    using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                    {
                        listReturn = db.ExecuteQuery<DepartmentMaster_dpm_Info>(sbSQL.ToString(), new object[] { }).ToList();
                    }
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }

            return listReturn;
        }

        public List<DepartmentMaster_dpm_Info> AllRecords()
        {
            List<DepartmentMaster_dpm_Info> listReturn = null;

            try
            {
                StringBuilder sbSQL = new StringBuilder();
                sbSQL.AppendLine("SELECT * FROM DepartmentMaster_dpm");

                using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                {
                    listReturn = db.ExecuteQuery<DepartmentMaster_dpm_Info>(sbSQL.ToString(), new object[] { }).ToList();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return listReturn;
        }

        public ReturnValueInfo InsertRecord(DepartmentMaster_dpm_Info infoObj)
        {
            ReturnValueInfo rvInfo = new ReturnValueInfo();
            if (infoObj == null)
            {
                rvInfo.messageText = Common.DefineConstantValue.SystemMessageText.strMessageText_E_ObjectNull;
                rvInfo.isError = true;
                return rvInfo;
            }
            try
            {
                using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                {
                    infoObj.dpm_RecordID = Guid.NewGuid();
                    infoObj.dpm_dAddDate = DateTime.Now;

                    DepartmentMaster_dpm newTab = Common.General.CopyObjectValue<DepartmentMaster_dpm_Info, DepartmentMaster_dpm>(infoObj);
                    db.DepartmentMaster_dpm.InsertOnSubmit(newTab);
                    db.SubmitChanges();
                    rvInfo.boolValue = true;
                }
            }
            catch (Exception ex)
            {
                rvInfo.isError = true;
                rvInfo.messageText = ex.Message;
            }
            return rvInfo;
        }

        public ReturnValueInfo UpdateRecord(DepartmentMaster_dpm_Info infoObj)
        {
            ReturnValueInfo rvInfo = new ReturnValueInfo();
            if (infoObj == null)
            {
                rvInfo.messageText = Common.DefineConstantValue.SystemMessageText.strMessageText_E_ObjectNull;
                rvInfo.isError = true;
                return rvInfo;
            }
            try
            {
                using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                {
                    DepartmentMaster_dpm query = db.DepartmentMaster_dpm.SingleOrDefault(t => t.dpm_RecordID == infoObj.dpm_RecordID);
                    if (query != null)
                    {
                        query.dpm_cName = infoObj.dpm_cName;
                        query.dpm_cLast = infoObj.dpm_cLast;
                        query.dpm_dLastDate = infoObj.dpm_dLastDate;
                        query.dpm_lEnable = infoObj.dpm_lEnable;
                        query.dpm_cRemark = infoObj.dpm_cRemark;

                        db.SubmitChanges();
                        rvInfo.boolValue = true;
                    }
                }
            }
            catch (Exception ex)
            {
                rvInfo.isError = true;
                rvInfo.messageText = ex.Message;
            }
            return rvInfo;
        }

        public ReturnValueInfo DeleteRecord(IModelObject KeyObject)
        {
            ReturnValueInfo rvInfo = new ReturnValueInfo();
            DepartmentMaster_dpm_Info searchInfo = KeyObject as DepartmentMaster_dpm_Info;
            if (searchInfo == null)
            {
                rvInfo.messageText = Common.DefineConstantValue.SystemMessageText.strMessageText_E_ObjectNull;
                rvInfo.isError = true;
                return rvInfo;
            }
            try
            {
                using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                {
                    List<DepartmentMaster_dpm> listDept = db.DepartmentMaster_dpm.Where(x => x.dpm_RecordID == searchInfo.dpm_RecordID).ToList();

                    if (listDept != null)
                    {
                        db.DepartmentMaster_dpm.DeleteAllOnSubmit(listDept);
                        db.SubmitChanges();
                        rvInfo.boolValue = true;
                    }
                }
            }
            catch (Exception ex)
            {
                rvInfo.messageText = ex.Message;
                rvInfo.isError = true;
            }
            return rvInfo;
        }
    }
}
