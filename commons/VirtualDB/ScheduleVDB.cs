using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using commons.Table;

namespace commons.VirtualDB
{
    public class ScheduleVDB : VirtualDatabase<string, ScheduleInfo>
    {
        public ScheduleInfo[] readFromDate(in string date)
        {
            throw new NotImplementedException();
        }
        public bool deleteFromDate(in string date)
        {
            throw new NotImplementedException();
        }
    }
}
