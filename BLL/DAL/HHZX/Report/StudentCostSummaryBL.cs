using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL.IBLL.HHZX.Report;
using Model.HHZX.Report;
using DAL.IDAL.Report;
using DAL.Factory.HHZX;

namespace BLL.DAL.HHZX.Report
{
    class StudentCostSummaryBL : IStudentCostSummaryBL
    {
        IStudentCostSummaryDA _IStudentCostSummaryDA;

        public StudentCostSummaryBL()
        {
            this._IStudentCostSummaryDA = MasterDAFactory.GetDAL<IStudentCostSummaryDA>(MasterDAFactory.StudentCostSummary);
        }

        public List<StudentCostSummary_scs_Info> SearchRecords(StudentCostSummary_scs_Info searchInfo)
        {
            try
            {
                return this._IStudentCostSummaryDA.SearchRecords(searchInfo);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
