using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.HHZX.Report;

namespace DAL.IDAL.Report
{
    public interface IMealBookingDA : IMainGeneralDA<MealBooking_mbk_info>
    {
        List<MealBooking_mbk_info> GetClassBookingHistory(MealBooking_mbk_info searchCondition);
        List<MealBooking_mbk_info> GetPlanBooking(MealBooking_mbk_info searchCondition);
    }
}
