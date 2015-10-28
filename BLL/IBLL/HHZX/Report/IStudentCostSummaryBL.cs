using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.HHZX.Report;

namespace BLL.IBLL.HHZX.Report
{
    public interface IStudentCostSummaryBL
    {
        List<StudentCostSummary_scs_Info> SearchRecords(StudentCostSummary_scs_Info searchInfo);
    }
}
