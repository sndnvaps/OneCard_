using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.HHZX.Report;

namespace DAL.IDAL.Report
{
    /// <summary>
    /// 学生消费汇总表
    /// </summary>
    public interface IStudentCostSummaryDA
    {
        List<StudentCostSummary_scs_Info> SearchRecords(StudentCostSummary_scs_Info searchInfo);
    }
}
