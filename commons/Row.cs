using System;

namespace commons.Table
{
    public enum Type
    {
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
    public abstract class InfoBase<Key> : Row{
        public readonly Type type;
        public InfoBase(Type type) { this.type = type; }
        public abstract Key getKey();
    }

    [Serializable]
    public class LoginInfo : InfoBase<string>
    {
        public string studentId;
        public string password = "default password";

        public LoginInfo() : base(Type.LOGIN_INFO) { }
        public override string ToString()
        {
            return $"{type}{{{studentId}, {password}}}";
        }
        public override string getKey()
        {
            return studentId;
        }
    }

    [Serializable]
    public class MemberInfo : InfoBase<string>
    {
        public string studentId;
        public string name;
        public string department;
        public string phoneNumber = "";
        public bool isAdministrator = false;

        public MemberInfo() : base(Type.MEMBER_INFO) { }
        public override string ToString()
        {
            return $"{type}{{{studentId}, {name}, {department}, {phoneNumber}, {isAdministrator}}}";
        }
        public override string getKey()
        {
            return studentId;
        }
    }

    [Serializable]
    public class ItemInfo : InfoBase<string>
    {
        public string name;
        public int amount;

        public ItemInfo() : base(Type.ITEM_INFO) { }
        public override string ToString()
        {
            return $"{type}{{{name}, {amount}}}";
        }
        public override string getKey()
        {
            return name;
        }
    }

    [Serializable]
    public class LentInfo : InfoBase<string>
    {
        public string itemName;
        public int amount;
        public string studentId;
        public string startDate;

        public LentInfo() : base(Type.LENT_INFO) { }
        public override string ToString()
        {
            return $"{type}{{{itemName}, {amount}, {studentId}, {startDate}}}";
        }
        public override string getKey()
        {
            return itemName;
        }
    }

    [Serializable]
    public class ScheduleInfo : InfoBase<string>
    {
        public string id;
        public string date;
        public string title;
        public string content;

        public ScheduleInfo() : base(Type.SCHEDULE_INFO) { }
        public override string ToString()
        {
            return $"{type}{{{id}, {date}, {title}, {content}}}";
        }
        public override string getKey()
        {
            return id;
        }
    }
}
