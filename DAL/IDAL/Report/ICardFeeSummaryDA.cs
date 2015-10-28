using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.HHZX.Report;

namespace DAL.IDAL.Report
{
    public interface ICardFeeSummaryDA
    {
        List<CardFeeSummary_cfs_Info> SearchRecords(CardFeeSummary_cfs_Info searchInfo);
    }
}
