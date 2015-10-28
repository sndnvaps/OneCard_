using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsUI.TQS.SystemForm
{
    public class SetMealInfo
    {
        public DateTime times { get; set; }
        public bool? Breakfast { get; set; }
        public bool? Lunch { get; set; }
        public bool? Dinner { get; set; }
    }
}
