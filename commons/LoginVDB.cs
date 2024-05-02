using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using commons.Table;

namespace commons.VirtualDB
{
    public class LoginVDB : VirtualDatabase<string, LoginInfo>
    {
        public override bool create(in LoginInfo item)
        {
            throw new NotImplementedException();
        }
        public override bool createItems(in LoginInfo[] items)
        {
            throw new NotImplementedException();
        }
        public override LoginInfo read(in string scheduleId)
        {
            throw new NotImplementedException();
        }
        public override LoginInfo[] readItems(in string[] ids)
        {
            throw new NotImplementedException();
        }
        public override bool update(in LoginInfo item)
        {
            throw new NotImplementedException();
        }
        public override bool updateItems(in LoginInfo[] items)
        {
            throw new NotImplementedException();
        }
        public override bool delete(in string scheduleId)
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
