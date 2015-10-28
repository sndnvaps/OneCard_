using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.IModel;

namespace Model.SysMaster
{
    public class Sys_FormMaster_fom_Info : IModelObject
    {

        #region 构造函数

        public Sys_FormMaster_fom_Info()
        {

            fom_iRecordID = 0;

            fom_iParentID = 0;

            fom_iIndex = 0;

            fom_cFormNumber = string.Empty;

            fom_cFormDesc = string.Empty;

            fom_cExePath = string.Empty;

            fom_cShortCut = string.Empty;

            fom_lIsPopForm = false;

            fom_lIsPreOpen = false;

            fom_cRemark = string.Empty;

            fom_cAdd = string.Empty;

            fom_cLast = string.Empty;

            this.functionMaster = new List<Sys_FunctionMaster_fum_Info>();

            isEnable = false;

            fom_lVaild = true;
        }
        #endregion

        #region 析构函数
        ~Sys_FormMaster_fom_Info()
        {

        }
        #endregion

        #region 属性

        public Int32 fom_iRecordID { set; get; }

        public Int32 fom_iParentID { set; get; }

        public Int32 fom_iIndex { set; get; }

        public string fom_cFormNumber { set; get; }

        public string fom_cFormDesc { set; get; }

        public string fom_cExePath { set; get; }

        public string fom_cShortCut { set; get; }

        public string fom_cRemark { set; get; }

        public bool fom_lIsPopForm { set; get; }

        public bool fom_lIsPreOpen { set; get; }

        public string fom_cAdd { set; get; }

        public DateTime fom_dAddDate { set; get; }

        public string fom_cLast { set; get; }

        public DateTime fom_dLastDate { set; get; }

        public bool fom_lVaild { get; set; }

        public bool isEnable { get; set; }

        public List<Sys_FunctionMaster_fum_Info> functionMaster
        {
            set;
            get;
        }

        #endregion

        #region 长度属性


        public int fom_iRecordID_Length { set; get; }

        public int fom_iParentID_Length { set; get; }

        public int fom_iIndex_Length { set; get; }

        public int fom_cFormNumber_Length { set; get; }

        public int fom_cFormDesc_Length { set; get; }

        public int fom_cExePath_Length { set; get; }

        public int fom_cRemark_Length { set; get; }

        public int fom_cAdd_Length { set; get; }

        public int fom_dAddDate_Length { set; get; }

        public int fom_cLast_Length { set; get; }

        public int fom_dLastDate_Length { set; get; }

        public int fom_lVaild_Length { get; set; }

        #endregion

        #region IModelObject Members

        public int RecordID
        {
            get;
            set;
        }

        #endregion
    }
}