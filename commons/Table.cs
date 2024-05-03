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

    [Serializable]
    public abstract class InfoBase {
        public readonly Type type;
        public InfoBase(Type type) { this.type = type; }
    }

    [Serializable]
    public class LoginInfo : InfoBase
    {
        public string studentId;
        public string password = "default password";

        public LoginInfo() : base(Type.LOGIN_INFO) { }
        public override string ToString()
        {
            return $"{type}{{{studentId}, {password}}}";
        }
    }

    [Serializable]
    public class MemberInfo : InfoBase
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
    }

    [Serializable]
    public class ItemInfo : InfoBase
    {
        public string name;
        public int amount;

        public ItemInfo() : base(Type.ITEM_INFO) { }
        public override string ToString()
        {
            return $"{type}{{{name}, {amount}}}";
        }
    }

    [Serializable]
    public class LentInfo : InfoBase
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
    }

    [Serializable]
    public class ScheduleInfo : InfoBase
    {
        private static int seed = 0;
        public string id = (seed++).ToString();
        public string date;
        public string title;
        public string content;

        public ScheduleInfo() : base(Type.SCHEDULE_INFO) { }
        public override string ToString()
        {
            return $"{type}{{{id}, {date}, {title}, {content}}}";
        }
    }
}
