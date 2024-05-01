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
    public class LoginInfo
    {
        const Type type = Type.LOGIN_INFO;

        public string studentId;
        public string password = "default password";

        public override string ToString()
        {
            return $"{type}{{{studentId}, {password}}}";
        }
    }

    [Serializable]
    public class MemberInfo
    {
        const Type type = Type.MEMBER_INFO;

        public string studentId;
        public string name;
        public string department;
        public string phoneNumber = "";
        public bool isAdministrator = false;

        public override string ToString()
        {
            return $"{type}{{{studentId}, {name}, {department}, {phoneNumber}, {isAdministrator}}}";
        }
    }

    [Serializable]
    public class ItemInfo
    {
        const Type type = Type.ITEM_INFO;

        public string name;
        public int amount;

        public override string ToString()
        {
            return $"{type}{{{name}, {amount}}}";
        }
    }

    [Serializable]
    public class LentInfo
    {
        const Type type = Type.LENT_INFO;

        public string itemName;
        public int amount;
        public string studentId;
        public string startDate;

        public override string ToString()
        {
            return $"{type}{{{itemName}, {amount}, {studentId}, {startDate}}}";
        }
    }

    [Serializable]
    public class ScheduleInfo
    {
        const Type type = Type.SCHEDULE_INFO;

        private static int seed = 0;
        public string id = (seed++).ToString();
        public string date;
        public string title;
        public string content;

        public override string ToString()
        {
            return $"{type}{{{id}, {date}, {title}, {content}}}";
        }
    }
}
