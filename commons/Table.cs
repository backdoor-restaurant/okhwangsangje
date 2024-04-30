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

        public new string ToString()
        {
            return "MemberInfo{" +
                studentId + ", " +
                name + ", " +
                department + ", " +
                phoneNumber + ", " +
                isAdministrator.ToString() + "}";
        }
    }

    [Serializable]
    public class ItemInfo
    {
        const Type type = Type.ITEM_INFO;

        public string name;
        public int amount;
    }

    [Serializable]
    public class LentInfo
    {
        const Type type = Type.LENT_INFO;

        public string itemName;
        public int amount;
        public string studentId;
        public string startDate;
    }

    [Serializable]
    public class ScheduleInfo
    {
        private static int seed = 0;
        public string id = (seed++).ToString();
        public string date;
        public string title;
        public string content;
    }
}
