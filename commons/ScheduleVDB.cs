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
        public override bool create(in ScheduleInfo item)
        {
            throw new NotImplementedException();
        }
        public override bool createItems(in ScheduleInfo[] items)
        {
            throw new NotImplementedException();
        }
        public override ScheduleInfo read(in string scheduleId)
        {
            throw new NotImplementedException();
        }
        public ScheduleInfo[] readFromDate(in string date)
        {
            throw new NotImplementedException();
        }
        public override ScheduleInfo[] readItems(in string[] ids)
        {
            throw new NotImplementedException();
        }
        public override bool update(in ScheduleInfo item)
        {
            throw new NotImplementedException();
        }
        public override bool updateItems(in ScheduleInfo[] items)
        {
            throw new NotImplementedException();
        }
        public override bool delete(in string scheduleId)
        {
            throw new NotImplementedException();
        }
        public bool deleteFromDate(in string date)
        {
            throw new NotImplementedException();
        }
        public override bool deleteItems(in string[] ids)
        {
            throw new NotImplementedException();
        }
        public override bool sync()
        {
            throw new NotImplementedException();
        }
    }
}
