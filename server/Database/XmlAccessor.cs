using commons.Table;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
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
                itemName = row.ItemName,
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
            if(row is null) return null;

            return new LentInfo {
                itemName = row.ItemName,
                amount = row.amount,
                studentId = row.StudentID,
                startDate = row.StartDate
            };
        }
        internal static LentInfo[] make(in LentInfoRow[] rows) {
            var result = new LentInfo[rows.Length];

            for (int i = 0; i < rows.Length; ++i) {
                result[i] = new LentInfo {
                    itemName = rows[i].ItemName,
                    amount = rows[i].amount,
                    studentId = rows[i].StudentID,
                    startDate = rows[i].StartDate
                };
            }

            return result;
        }
        internal static ScheduleInfo make(in ScheduleInfoRow row) {
            return new ScheduleInfo {
                date = row.Date,
                title = row.Title,
                content = row.Content
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
        private readonly DataSet dataSet;

        public XmlAccessor(in string xmlFileName) {
            dataSet = new DataSet();
            dataSet.ReadXml(path + xmlFileName);
        }
        public XmlAccessor(in DataSet dataSet) {
            this.dataSet = dataSet;
        }

        public bool create(in MemberInfo member) {
            try {
                tryCreate(member);
                dataSet.MemberInfo.AcceptChanges();

                return true;
            }
            catch (NoNullAllowedException) {
                return false;
            }
            catch (ConstraintException) {
                return false;
            }
            catch (InvalidConstraintException) {
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
        public bool create(in ItemInfo item) {
            try {
                tryCreate(item);

                return true;
            }
            catch (NoNullAllowedException) {
                return false;
            }
            catch (ConstraintException) {
                return false;
            }
            catch (InvalidConstraintException) {
                return false;
            }
        }
        private void tryCreate(in ItemInfo item) {
            dataSet.ItemInfo.AddItemInfoRow(
                item.itemName,
                item.amount
            );
        }
        public bool create(in LoginInfo info) {
            try {
                tryCreate(info);

                return true;
            }
            catch (NoNullAllowedException) {
                return false;
            }
            catch (ConstraintException) {
                return false;
            }
            catch (InvalidConstraintException) {
                return false;
            }
        }
        private void tryCreate(in LoginInfo info) {
            dataSet.LoginInfo.AddLoginInfoRow(
                info.studentId,
                info.password
            );
        }
        public bool create(in LentInfo info) {
            try {
                tryCreate(info);

                return true;
            }
            catch (NoNullAllowedException) {
                return false;
            }
            catch (ConstraintException) {
                return false;
            }
            catch (InvalidConstraintException) {
                return false;
            }
        }
        private void tryCreate(in LentInfo info) {
            dataSet.LentInfo.AddLentInfoRow(
                info.itemName,
                info.amount,
                info.studentId,
                info.startDate
            );
        }
        public bool create(in ScheduleInfo schedule) {
            try {
                tryCreate(schedule);

                return true;
            }
            catch (NoNullAllowedException) {
                return false;
            }
            catch (ConstraintException) {
                return false;
            }
            catch (InvalidConstraintException) {
                return false;
            }
        }
        private void tryCreate(in ScheduleInfo schedule) {
            dataSet.ScheduleInfo.AddScheduleInfoRow(
                schedule.date,
                schedule.title,
                schedule.content
            );
        }

        public bool read(in MemberInfoKey key, out MemberInfo member) {
            if (key.studentId.Length == 0)
                throw new ArgumentException();

            var row = dataSet.MemberInfo.FindByStudentID(key.studentId);
            if (row is null) {
                member = null;
                return false;
            }
            
            member = Factory.make(row);
            return true;
        }
        public bool read(in ItemInfoKey key, out ItemInfo item) {
            if(key.itemName.Length == 0)
                throw new ArgumentException();

            var row = dataSet.ItemInfo.FindByItemName(key.itemName);
            if(row is null) {
                item = null;
                return false;
            }

            item = Factory.make(row);
            return true;
        }
        public bool read(in LoginInfoKey key, out LoginInfo pair) {
            if (key.studentId.Length == 0)
                throw new ArgumentException();

            var row = dataSet.LoginInfo.FindByStudentID(key.studentId);
            if(row is null) {
                pair = null;
                return false;
            }

            pair = Factory.make(row);
            return true;
        }
        public bool read(in LentInfoKey key, out LentInfo info) {
            if(key.studentId.Length == 0 || key.itemName.Length == 0)
                throw new ArgumentException();

            var row = dataSet.LentInfo.FindByItemNameStudentID(
                key.itemName, key.studentId
            );
            if(row is null) {
                info = null;
                return false;
            }

            info = Factory.make(row);
            return true;
        }
        public bool readFromStudentID(string s_id, out LentInfo[] info) {
            if (s_id.Length == 0)
                throw new ArgumentException();

            var query = from l in dataSet.LentInfo
                        where l.StudentID == s_id
                        select l;
            info = Factory.make(query.ToArray());
            return info.Count() > 0;
        }
        public bool read(in ScheduleInfoKey key, out ScheduleInfo info) {
            if (key.date.Length == 0 || key.title.Length == 0)
                throw new ArgumentException();

            var row = dataSet.ScheduleInfo.FindByDateTitle(
                key.date, key.title
            );
            if (row is null) {
                info = null;
                return false;
            }

            info = Factory.make(row);
            return true;
        }
        public bool readFromDate(string date, out ScheduleInfo[] schedules) {
            if(date.Length == 0)
                throw new ArgumentException();

            var query = from s in dataSet.ScheduleInfo
                        where s.Date == date
                        select s;
            schedules = Factory.make(query.ToArray());
            return schedules.Count() > 0;
        }
        
        public bool tryUpdate(in MemberInfo member) {
            var row = dataSet.MemberInfo.FindByStudentID(member.studentId);
            if (row is null) return false;

            row.Name = member.name;
            row.Department = member.department;
            row.PhoneNumber = member.phoneNumber;
            row.isAdministrator = member.isAdministrator;

            return true;
        }
        public bool tryUpdate(in ItemInfo item) {
            var row = dataSet.ItemInfo.FindByItemName(item.itemName);
            if (row is null) return false;

            row.amount = item.amount;

            return true;
        }
        public bool tryUpdate(in LoginInfo pair) {
            var row = dataSet.LoginInfo.FindByStudentID(pair.studentId);
            if (row is null) return false;

            row.Password = pair.password;

            return true;
        }
        public bool tryUpdate(in LentInfo info) {
            var row = dataSet.LentInfo.FindByItemNameStudentID(
                info.itemName, info.studentId
            );

            if (row is null) return false;

            row.amount = info.amount;
            row.StartDate = info.startDate;

            return true;
        }
        public bool tryUpdate(ScheduleInfo info) {
            var row = dataSet.ScheduleInfo.FindByDateTitle(
                info.date, info.title
            );
            if (row is null) return false;

            row.Content = info.content;

            return true;
        }

        public bool delete(in MemberInfoKey key) {
            if (key.studentId.Length == 0)
                throw new ArgumentException();

            var row = dataSet.MemberInfo.FindByStudentID(key.studentId);
            if (row is null) return false;

            dataSet.MemberInfo.RemoveMemberInfoRow(row);
            return true;
        }
        public bool delete(in ItemInfoKey key) {
            if (key.itemName.Length == 0)
                throw new ArgumentException();

            var row = dataSet.ItemInfo.FindByItemName(key.itemName);
            if (row is null) return false;

            dataSet.ItemInfo.RemoveItemInfoRow(row);
            return true;
        }
        public bool delete(in LoginInfoKey key) {
            if (key.studentId.Length == 0)
                throw new ArgumentException();

            var row = dataSet.LoginInfo.FindByStudentID(key.studentId);
            if (row is null) return false;

            dataSet.LoginInfo.RemoveLoginInfoRow(row);
            return true;
        }
        public bool delete(in LentInfoKey key) {
            if (key.studentId.Length == 0 ||
                key.itemName.Length == 0 
            ) throw new ArgumentException();

            var row = dataSet.LentInfo.FindByItemNameStudentID(
                key.itemName, key.studentId
            );
            if (row is null) return false;

            dataSet.LentInfo.RemoveLentInfoRow(row);
            return true;
        }
        public bool deleteFromStudentID(string s_id) {
            if(s_id.Length == 0) 
                throw new ArgumentException();

            var query = from l in dataSet.LentInfo
                        where l.StudentID == s_id
                        select l;

            bool deleted = false;
            foreach(var r in query.ToList()) {
                deleted = true;
                dataSet.LentInfo.RemoveLentInfoRow(r);
            }

            return deleted;
        }
        public bool delete(in ScheduleInfoKey key) {
            if (key.date.Length == 0 ||
                key.title.Length == 0
            ) throw new ArgumentException();

            var row = dataSet.ScheduleInfo.FindByDateTitle(
                key.date, key.title
            );
            if (row is null) return false;

            dataSet.ScheduleInfo.RemoveScheduleInfoRow(row);
            return true;
        }
        public bool deleteFromDate(string date) {
            if (date.Length == 0)
                throw new ArgumentException();

            var query = from s in dataSet.ScheduleInfo
                        where s.Date == date
                        select s;

            bool deleted = false;
            foreach(var r in query.ToList()) {
                deleted = true;
                dataSet.ScheduleInfo.RemoveScheduleInfoRow(r);
            }

            return deleted;
        }

        ~XmlAccessor() {
            const string dst = "Result.xml";
            dataSet.WriteXml(path + dst);
        }
    }
}
