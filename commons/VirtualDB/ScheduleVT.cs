using commons.Table;
using System;

namespace commons.VirtualDB {
    public class ScheduleVT : VirtualTable<ScheduleInfoKey, ScheduleInfo> {
        public ScheduleInfo[] readFromDate(in string date) {
            throw new NotImplementedException();
        }
        public bool deleteFromDate(in string date) {
            throw new NotImplementedException();
        }
    }
}
