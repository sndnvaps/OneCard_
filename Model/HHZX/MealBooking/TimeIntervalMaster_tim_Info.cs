using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.IModel;

namespace Model.HHZX.MealBooking
{
    public class TimeIntervalMaster_tim_Info : IModelObject
    {
        #region IModelObject Members

        public int RecordID
        {
            get;
            set;
        }

        #endregion

        public Guid tim_cRecord { get; set; }
        public string tim_cIntervalName { get; set; }
        public string tim_cIntervalType { get; set; }
        public int tim_cIntervalIndex { get; set; }
        public string tim_cBeginTime { get; set; }
        public string tim_cEndTime { get; set; }
        public decimal tim_fValue { get; set; }
        public bool tim_lIsUsed { get; set; }
        public bool tim_lIsActive { get; set; }
        public string tim_cAdd { get; set; }
        public DateTime tim_dAddDate { get; set; }
        public string timcLast { get; set; }
        public DateTime tim_dLastDate { get; set; }
    }
}
