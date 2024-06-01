using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Dynamic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using commons.Table;
using commons.VirtualDB;
using static server.Database.DataSet;

namespace server.Database {
    internal static class Factory {
        internal static MemberInfo make(in MemberInfoRow row) {
            if (row is null) return null;

            return new MemberInfo{
                studentId = row.StudentID,
                name = row.Name,
                department = row.Department,
                phoneNumber = row.PhoneNumber,
                isAdministrator = row.isAdministrator
            };
        }
        internal static ItemInfo make(in ItemInfoRow row) {
            if (row is null) return null;

            return new ItemInfo {
                name = row.ItemName,
                amount = row.amount
            };
        }
        internal static LoginInfo make(in LoginInfoRow row) {
            if (row is null) return null;

            return new LoginInfo {
                studentId = row.StudentID,
                password = row.Password
            };
        }
        internal static LentInfo make(in LentInfoRow row) {
            if (row is null) return null;

            return new LentInfo {
                itemName = row.ItemName,
                studentId = row.StudentID,
                amount = row.amount,
                startDate = row.StartDate
            };
        }
        internal static ScheduleInfo[] make(in ScheduleInfoRow[] rows) {
            var result = new ScheduleInfo[rows.Length];
            for(int i=0; i<rows.Length; ++i) {
                result[i] = new ScheduleInfo {
                    date = rows[i].Date,
                    title = rows[i].Title,
                    content = rows[i].Content,
                };
            }

            return result;
        }
    }

    internal class XmlAccessor {
        const string path = "../../Database/";
        private readonly DataSet dataSet = new DataSet();

        public XmlAccessor(in string xmlFileName) {
            dataSet.Locale = CultureInfo.InvariantCulture;

            dataSet.ReadXml(path + xmlFileName);
        }

        public bool create(in MemberInfo member) {
            Console.WriteLine("CREATE CALLED");

            try {
                tryCreate(member);

                return true;
            }
            catch (NoNullAllowedException e) {
                Console.WriteLine(e);
                return false;
            }
            catch (ConstraintException e) {
                Console.WriteLine(e);
                return false;
            }
        }
        private void tryCreate(in MemberInfo member) {
            dataSet.MemberInfo.AddMemberInfoRow(
                member.studentId,
                member.name,
                member.department,
                member.phoneNumber,
                member.isAdministrator
            );
        }

        public bool read(string s_id, out MemberInfo member) {
            var row = dataSet.MemberInfo.FindByStudentID(s_id);
            if (row is null) {
                member = null;
                return false;
            }
            
            member = Factory.make(row);
            return member != null;
        }
        public bool read(string i_name, out ItemInfo item) {
            var query = from i in dataSet.ItemInfo
                        where i.ItemName == i_name
                        select i;
            item = Factory.make(query.SingleOrDefault(null));
            return item != null;
        }
        public bool read(string s_id, out LoginInfo pair) {
            var query = from p in dataSet.LoginInfo
                        where p.StudentID == s_id
                        select p;
            pair = Factory.make(query.First());
            return pair != null;
        }
        public bool read(string i_name, string s_id, out LentInfo info) {
            var query = from l in dataSet.LentInfo
                        where l.StudentID == s_id
                        where l.ItemName == i_name
                        select l;
            info = Factory.make(query.First());
            return info != null;
        }
        public bool read(string date, out ScheduleInfo[] schedules) {
            var query = from s in dataSet.ScheduleInfo
                        where s.Date == date
                        select s;
            schedules = Factory.make(query.ToArray());
            return schedules.Count() > 0;
        }
        
        public bool update(in MemberInfo member) {
            try {
                tryUpdate(member);

                return true;
            }
            catch (NoNullAllowedException e) {
                Console.WriteLine(e);
                return false;
            }
            catch (ConstraintException e) {
                Console.WriteLine(e);
                return false;
            }
        }

        private void tryUpdate(in MemberInfo member) {
            var row = dataSet.MemberInfo.FindByStudentID(member.studentId);

            row.Name = member.name;
            row.Department = member.department;
            row.PhoneNumber = member.phoneNumber;
            row.isAdministrator = member.isAdministrator;
        }

        public bool deleteMember(in string s_id) {
            var row = dataSet.MemberInfo.FindByStudentID(s_id);
            if (row is null) return false;

            dataSet.MemberInfo.RemoveMemberInfoRow(row);
            return true;
        }

        ~XmlAccessor() {
            const string dst = "Result.xml";
            dataSet.WriteXml(path + dst);
        }
    }
}
