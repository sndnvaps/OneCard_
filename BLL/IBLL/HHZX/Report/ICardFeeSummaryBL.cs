using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.HHZX.Report;

namespace BLL.IBLL.HHZX.Report
{
    public interface ICardFeeSummaryBL
    {
        List<CardFeeSummary_cfs_Info> SearchRecords(CardFeeSummary_cfs_Info searchInfo);
    }
}
