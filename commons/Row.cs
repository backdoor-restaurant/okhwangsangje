using System;

namespace commons.Table {
    public enum Type {
        LOGIN_INFO,
        MEMBER_INFO,
        ITEM_INFO,
        LENT_INFO,
        SCHEDULE_INFO
    }

    public interface Row {
        string ToString();
    }

    [Serializable]
    public abstract class InfoBase<Key> : Row {
        public readonly Type type;
        public InfoBase(Type type) { this.type = type; }
        public abstract Key getKey();
    }

    [Serializable]
    public class MemberInfo : InfoBase<MemberInfoKey> {
        public string studentId;
        public string name;
        public string department;
        public string phoneNumber = "";
        public bool isAdministrator = false;

        public MemberInfo() : base(Type.MEMBER_INFO) { }
        public override string ToString() {
            return $"{type}{{{studentId}, {name}, {department}, {phoneNumber}, {isAdministrator}}}";
        }
        public override MemberInfoKey getKey() {
            return new MemberInfoKey(this);
        }
    }

    [Serializable]
    public class MemberInfoKey {
        public readonly string studentId;

        public MemberInfoKey(in MemberInfo member) {
            studentId = member.studentId;
        }
        public MemberInfoKey(in string studentId) {
            this.studentId = studentId;
        }

        public override string ToString() {
            return $"MemberInfoKey{{{studentId}}}";
        }
    }

    [Serializable]
    public class ItemInfo : InfoBase<ItemInfoKey> {
        public string itemName;
        public int amount;

        public ItemInfo() : base(Type.ITEM_INFO) { }
        public override string ToString() {
            return $"{type}{{{itemName}, {amount}}}";
        }
        public override ItemInfoKey getKey() {
            return new ItemInfoKey(this);
        }
    }

    [Serializable]
    public class ItemInfoKey {
        public readonly string itemName;

        public ItemInfoKey(in ItemInfo item) {
            itemName = item.itemName;
        }
        public ItemInfoKey(in string itemName) {
            this.itemName = itemName;
        }

        public override string ToString() {
            return $"ItemInfoKey{{{itemName}}}";
        }
    }

    [Serializable]
    public class LoginInfo : InfoBase<LoginInfoKey> {
        public string studentId;
        public string password = "default password";

        public LoginInfo() : base(Type.LOGIN_INFO) { }
        public override string ToString() {
            return $"{type}{{{studentId}, {password}}}";
        }
        public override LoginInfoKey getKey() {
            return new LoginInfoKey(this);
        }
    }

    [Serializable]
    public class LoginInfoKey {
        public readonly string studentId;

        public LoginInfoKey(in LoginInfo pair) {
            studentId = pair.studentId;
        }
        public LoginInfoKey(in string studentId) {
            this.studentId = studentId;
        }

        public override string ToString() {
            return $"LoginInfoKey{{{studentId}}}";
        }
    }

    [Serializable]
    public class LentInfo : InfoBase<LentInfoKey> {
        public string itemName;
        public int amount;
        public string studentId;
        public string startDate;

        public LentInfo() : base(Type.LENT_INFO) { }
        public override string ToString() {
            return $"{type}{{{itemName}, {amount}, {studentId}, {startDate}}}";
        }
        public override LentInfoKey getKey() {
            return new LentInfoKey(this);
        }
    }
    [Serializable]
    public class LentInfoKey {
        public readonly string itemName;
        public readonly string studentId;

        public LentInfoKey(in LentInfo info) {
            itemName = info.itemName;
            studentId = info.studentId;
        }
        public LentInfoKey(in string itemName, in string studentId) {
            this.itemName = itemName;
            this.studentId = studentId;
        }

        public override string ToString() {
            return $"LentInfoKey{{{itemName}, {studentId}}}";
        }
    }

    [Serializable]
    public class ScheduleInfo : InfoBase<ScheduleInfoKey> {
        public string date;
        public string title;
        public string content;

        public ScheduleInfo() : base(Type.SCHEDULE_INFO) { }
        public override string ToString() {
            return $"{type}{{{date}, {title}, {content}}}";
        }
        public override ScheduleInfoKey getKey() {
            return new ScheduleInfoKey(this);
        }
    }

    [Serializable]
    public class ScheduleInfoKey {
        public readonly string date;
        public readonly string title;

        public ScheduleInfoKey(in ScheduleInfo schedule) {
            date = schedule.date;
            title = schedule.title;
        }
        public ScheduleInfoKey(in string date, in string title) {
            this.date = date;
            this.title = title;
        }

        public override string ToString() {
            return $"ScheduleInfoKey{{{date}, {title}}}";
        }
    }
}
