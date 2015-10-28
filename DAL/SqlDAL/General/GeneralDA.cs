using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.IDAL.General;
using LinqToSQLModel;
using System.Data.Linq.SqlClient;
using Common;
using Model.General;

namespace DAL.SqlDAL.General
{
    class GeneralDA : IGeneralDA
    {
        public List<Model.General.ComboboxDataInfo> GetMasterDataInformations(Common.DefineConstantValue.MasterType masterType)
        {
            List<Model.General.ComboboxDataInfo> infoList = null;

            try
            {
                switch (masterType)
                {
                    case DefineConstantValue.MasterType.CodeMaster_Key1:
                        infoList = GetCodeMaster_Key1();
                        break;

                    case DefineConstantValue.MasterType.Grade:
                        infoList = GetGradeList();
                        break;

                    case DefineConstantValue.MasterType.CardUserSex:
                        infoList = GetCodeMaster(Common.DefineConstantValue.CodeMasterDefine.KEY1_SIOT_CardUserSex);
                        break;

                    case DefineConstantValue.MasterType.CodeMaster_Class:
                        infoList = GetCodeMaster(Common.DefineConstantValue.CodeMasterDefine.KEY1_SIOT_CardUserClass);
                        break;

                    case DefineConstantValue.MasterType.UserClass:
                        infoList = GetUserClassList(Guid.Empty);
                        break;

                    case DefineConstantValue.MasterType.UserDepartment:
                        infoList = GetUserDepartmentList();
                        break;

                    case DefineConstantValue.MasterType.Staff:
                        infoList = GetStaffInformations();
                        break;

                    case DefineConstantValue.MasterType.CostType:
                        infoList = GetCostType();
                        break;

                    case DefineConstantValue.MasterType.CardUserIdentity:
                        infoList = GetUserIdentity();
                        break;

                    case DefineConstantValue.MasterType.TeacherInfo:
                        infoList = GetTeacherInfos();
                        break;

                    case DefineConstantValue.MasterType.UserValid:
                        infoList = GetUserValidInfos();
                        break;

                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return infoList;
        }

        public List<ComboboxDataInfo> GetUserValidInfos()
        {
            List<ComboboxDataInfo> listInfos = new List<ComboboxDataInfo>();
            try
            {
                ComboboxDataInfo dataInfo = new ComboboxDataInfo();
                dataInfo.DisplayMember = "是";
                dataInfo.ValueMember = "true";
                listInfos.Add(dataInfo);
                dataInfo = new ComboboxDataInfo();
                dataInfo.DisplayMember = "否";
                dataInfo.ValueMember = "false";
                listInfos.Add(dataInfo);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return listInfos;
        }

        public List<ComboboxDataInfo> GetTeacherInfos()
        {
            List<ComboboxDataInfo> infoList = new List<ComboboxDataInfo>();

            try
            {
                using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                {
                    List<CardUserMaster_cus> listTeachers = db.CardUserMaster_cus.Where(x => x.cus_lValid && x.cus_cIdentityNum == Common.DefineConstantValue.CodeMasterDefine.KEY2_SIOT_CardUserIdentity_Staff).ToList();

                    if (listTeachers != null)
                    {
                        listTeachers = listTeachers.OrderBy(x => x.cus_cChaName).ToList();

                        foreach (CardUserMaster_cus item in listTeachers)
                        {
                            ComboboxDataInfo info = new ComboboxDataInfo();

                            info.DisplayMember = item.cus_cChaName;

                            info.ValueMember = item.cus_cRecordID.ToString();

                            infoList.Add(info);
                        }
                    }
                }
            }
            catch (Exception Ex)
            {

                throw Ex;
            }

            return infoList;
        }


        public List<ComboboxDataInfo> GetUserIdentity()
        {
            List<ComboboxDataInfo> infoList = new List<ComboboxDataInfo>();

            try
            {
                using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                {
                    IEnumerable<CodeMaster_cmt> allType = from t in db.CodeMaster_cmt
                                                          where t.cmt_cKey1 == Common.DefineConstantValue.CodeMasterDefine.KEY1_SIOT_CardUserIdentity
                                                          select t;
                    if (allType != null)
                    {
                        foreach (CodeMaster_cmt item in allType)
                        {
                            ComboboxDataInfo info = new ComboboxDataInfo();

                            info.DisplayMember = item.cmt_cValue;

                            info.ValueMember = item.cmt_cKey2.ToString();

                            infoList.Add(info);
                        }
                    }
                }
            }
            catch (Exception Ex)
            {

                throw Ex;
            }

            return infoList;
        }


        public List<ComboboxDataInfo> GetCostType()
        {
            List<ComboboxDataInfo> infoList = new List<ComboboxDataInfo>();

            try
            {
                using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                {
                    IEnumerable<CodeMaster_cmt> allType = from t in db.CodeMaster_cmt
                                                          where t.cmt_cKey1 == Common.DefineConstantValue.CodeMasterDefine.KEY1_SIOT_CostType
                                                          select t;
                    if (allType != null)
                    {
                        foreach (CodeMaster_cmt item in allType)
                        {
                            ComboboxDataInfo info = new ComboboxDataInfo();

                            info.DisplayMember = item.cmt_cValue;

                            info.ValueMember = item.cmt_cKey2.ToString();

                            infoList.Add(info);
                        }
                    }
                }
            }
            catch (Exception Ex)
            {

                throw Ex;
            }

            return infoList;
        }


        public List<ComboboxDataInfo> GetStaffInformations()
        {
            List<ComboboxDataInfo> infoList = new List<ComboboxDataInfo>();

            try
            {
                using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                {
                    IEnumerable<CardUserMaster_cus> staffInfo = from t in db.CardUserMaster_cus
                                                                where t.cus_lValid == true && t.cus_cIdentityNum == DefineConstantValue.CodeMasterDefine.KEY2_SIOT_CardUserIdentity_Staff
                                                                select t;

                    staffInfo = staffInfo.OrderBy(p => p.cus_cChaName);

                    if (staffInfo != null && staffInfo.Count() > 0)
                    {
                        foreach (CardUserMaster_cus item in staffInfo)
                        {
                            ComboboxDataInfo info = new ComboboxDataInfo();

                            info.DisplayMember = item.cus_cChaName;

                            info.ValueMember = item.cus_cRecordID.ToString();

                            infoList.Add(info);
                        }
                    }
                }
            }
            catch (Exception Ex)
            {

                throw Ex;
            }

            return infoList;
        }


        public List<ComboboxDataInfo> GetMasterDataInformations(DefineConstantValue.MasterType masterType, object keyInfo)
        {
            List<Model.General.ComboboxDataInfo> infoList = null;

            try
            {
                switch (masterType)
                {
                    case DefineConstantValue.MasterType.CodeMaster_Key2:
                        infoList = GetCodeMaster_Key2(keyInfo as string);
                        break;

                    case DefineConstantValue.MasterType.CardUserSex:
                        infoList = GetCodeMaster(keyInfo.ToString());
                        break;
                    case DefineConstantValue.MasterType.UserClass:
                        infoList = GetUserClassList((Guid)keyInfo);
                        break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return infoList;
        }

        /// <summary>
        /// 获得用户部门列表
        /// </summary>
        /// <returns></returns>
        private List<ComboboxDataInfo> GetUserDepartmentList()
        {
            List<ComboboxDataInfo> infoList = new List<ComboboxDataInfo>();

            try
            {
                using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                {
                    IEnumerable<DepartmentMaster_dpm> allInfo = from t in db.DepartmentMaster_dpm
                                                                orderby t.dpm_cName
                                                                select t;

                    if (allInfo != null && allInfo.Count() > 0)
                    {
                        foreach (DepartmentMaster_dpm item in allInfo)
                        {
                            ComboboxDataInfo info = new ComboboxDataInfo();

                            info.DisplayMember = item.dpm_cName;

                            info.ValueMember = item.dpm_RecordID.ToString();

                            infoList.Add(info);
                        }
                    }
                }
            }
            catch (Exception Ex)
            {

                throw Ex;
            }

            return infoList;
        }

        /// <summary>
        /// 获得用户班级列表
        /// </summary>
        /// <returns></returns>
        private List<ComboboxDataInfo> GetUserClassList(Guid gradeKey)
        {
            List<ComboboxDataInfo> infoList = new List<ComboboxDataInfo>();

            try
            {
                using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                {
                    IEnumerable<ClassMaster_csm> allInfo = from t in db.ClassMaster_csm
                                                           where (gradeKey == Guid.Empty || t.csm_cGDMID == gradeKey)
                                                           orderby t.csm_cClassName
                                                           select t;

                    allInfo = allInfo.OrderBy(x => x.csm_cClassName);
                    if (allInfo != null && allInfo.Count() > 0)
                    {
                        foreach (ClassMaster_csm item in allInfo)
                        {
                            ComboboxDataInfo info = new ComboboxDataInfo();

                            info.DisplayMember = item.csm_cClassName;

                            info.ValueMember = item.csm_cRecordID.ToString();

                            infoList.Add(info);
                        }
                    }
                }
            }
            catch (Exception Ex)
            {

                throw Ex;
            }

            return infoList;
        }

        /// <summary>
        /// 获取系统定义年级列表
        /// </summary>
        /// <returns></returns>
        private List<ComboboxDataInfo> GetGradeList()
        {
            List<ComboboxDataInfo> infoList = new List<ComboboxDataInfo>();

            try
            {
                using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                {
                    IEnumerable<GradeMaster_gdm> allInfo = from t in db.GradeMaster_gdm
                                                           orderby t.gdm_dAddDate ascending
                                                           select t;

                    allInfo = allInfo.OrderBy(x => x.gdm_cGradeName);

                    if (allInfo != null && allInfo.Count() > 0)
                    {
                        foreach (GradeMaster_gdm item in allInfo)
                        {
                            ComboboxDataInfo info = new ComboboxDataInfo();

                            info.DisplayMember = item.gdm_cGradeName;

                            info.ValueMember = item.gdm_cRecordID.ToString();

                            infoList.Add(info);
                        }
                    }
                }
            }
            catch (Exception Ex)
            {

                throw Ex;
            }

            return infoList;
        }

        private List<ComboboxDataInfo> GetCodeMaster_Key2(string CodeMaster_Key1)
        {
            List<ComboboxDataInfo> infoList = new List<ComboboxDataInfo>();
            try
            {
                using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                {
                    //var taQuery =
                    //    (from t in db.CodeMaster_cmt
                    //     where t.cmt_cKey1 == CodeMaster_Key1
                    //     select new { name = t.cmt_cKey2 }).Distinct();
                    //if (taQuery.Count() > 0)
                    //{
                    //    foreach (var t in taQuery)
                    //    {
                    //        ComboboxDataInfo info = new Model.General.ComboboxDataInfo();
                    //        info.DisplayMember = t.name;
                    //        info.ValueMember = t.name;
                    //        infoList.Add(info);
                    //    }
                    //}

                    List<CodeMaster_cmt> listCode = db.CodeMaster_cmt.Where(x => x.cmt_cKey1 == CodeMaster_Key1).ToList();
                    if (listCode != null)
                    {
                        foreach (CodeMaster_cmt codeItem in listCode)
                        {
                            ComboboxDataInfo info = new Model.General.ComboboxDataInfo();
                            info.DisplayMember = codeItem.cmt_cValue;
                            info.ValueMember = codeItem.cmt_cKey2;
                            infoList.Add(info);
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            return infoList;
        }

        private List<ComboboxDataInfo> GetCodeMaster_Key1()
        {
            List<ComboboxDataInfo> infoList = new List<ComboboxDataInfo>();
            try
            {
                using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                {
                    var taQuery =
                         (from t in db.CodeMaster_cmt
                          select new { name = t.cmt_cKey1 }
                          ).Distinct();
                    if (taQuery.Count() > 0)
                    {
                        foreach (var t in taQuery)
                        {
                            ComboboxDataInfo info = new ComboboxDataInfo();
                            info.DisplayMember = t.name;
                            info.ValueMember = t.name;
                            infoList.Add(info);
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            return infoList;
        }

        private List<ComboboxDataInfo> GetCodeMaster(string key)
        {
            List<ComboboxDataInfo> infoList = new List<ComboboxDataInfo>();
            try
            {
                using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                {
                    IQueryable<CodeMaster_cmt> taQuery =
                        from t in db.CodeMaster_cmt
                        where t.cmt_cKey1 == key.ToString()
                        orderby t.cmt_cKey2 ascending
                        select t;
                    if (taQuery.Count() > 0)
                    {
                        foreach (CodeMaster_cmt t in taQuery)
                        {
                            ComboboxDataInfo info = new ComboboxDataInfo();
                            info.DisplayMember = t.cmt_cValue;
                            info.ValueMember = t.cmt_cKey2;
                            infoList.Add(info);
                        }
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
