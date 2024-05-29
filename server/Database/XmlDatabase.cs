using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using commons.Table;
using static server.Database.DataSet;

namespace server.Database {
    internal static class Factory {
        internal static MemberInfo make(in MemberInfoRow row) {
            if (row == null) return null;

            return new MemberInfo{
                studentId = row.StudentID,
                name = row.Name,
                department = row.Department,
                phoneNumber = row.PhoneNumber,
                isAdministrator = row.isAdministrator
            };
        }
        internal static ScheduleInfo[] make(in ScheduleInfoRow[] rows) {
            return null;
        }
    }

    internal class XmlDatabase
    {
        const string path = "../../Database/";
        private DataSet dataSet = new DataSet();

        public XmlDatabase(in string xmlFileName)
        {
            dataSet.Locale = CultureInfo.InvariantCulture;

            dataSet.ReadXml(path+xmlFileName);
        }

        public bool read(string s_id, out MemberInfo member) {
            var query = from m in dataSet.MemberInfo
                        where m.StudentID == s_id
                        select m;
            member = Factory.make(query.First());
            return member != null;
        }
        public bool read(string date, out ScheduleInfo[] schedules) {
            var query = from s in dataSet.ScheduleInfo
                        where s.Date == date
                        select s;
            schedules = Factory.make(query.ToArray());
            return schedules.Count() > 0;
        }

        public void doSomething() {
            if (read("3", out MemberInfo member)) {
                Console.WriteLine(member.name);
            }
        }

        ~XmlDatabase() {
            const string dst = "Result.xml";
            dataSet.WriteXml(path + dst);
        }
    }
}
