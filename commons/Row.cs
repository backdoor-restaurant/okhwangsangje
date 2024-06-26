﻿using System;

namespace commons.Table {
    public enum TableType {
        LOGIN_INFO,
        MEMBER_INFO,
        ITEM_INFO,
        RENT_INFO,
        SCHEDULE_INFO
    }

    public interface Row {
        string ToString();
    }

    [Serializable]
    public abstract class InfoBase<Key> : Row {
        public readonly TableType type;
        public InfoBase(TableType type) { this.type = type; }
        public abstract Key getKey();
    }

    [Serializable]
    public class MemberInfo : InfoBase<MemberInfoKey> {
        public string studentId;
        public string name;
        public string department;
        public string phoneNumber = "";
        public bool isAdministrator = false;

        public MemberInfo() : base(TableType.MEMBER_INFO) { }
        public override string ToString()
            => $"{type}{{{studentId}, {name}, {department}, {phoneNumber}, {isAdministrator}}}";
        public override MemberInfoKey getKey()
            => new MemberInfoKey(this);
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

        public static implicit operator MemberInfoKey(string s_id)
            => new MemberInfoKey(s_id);
        public override string ToString()
            => $"MemberInfoKey{{{studentId}}}";
    }

    [Serializable]
    public class ItemInfo : InfoBase<ItemInfoKey> {
        public string itemName;
        public int amount;

        public ItemInfo() : base(TableType.ITEM_INFO) { }
        public override string ToString()
            => $"{type}{{{itemName}, {amount}}}";
        public override ItemInfoKey getKey()
            => new ItemInfoKey(this);
    }

    [Serializable]
    public class ItemInfoKey {
        public readonly string itemName;

        public ItemInfoKey() {
            itemName = null;
        }
        public ItemInfoKey(in ItemInfo item) {
            itemName = item.itemName;
        }
        public ItemInfoKey(in string itemName) {
            this.itemName = itemName;
        }

        public static implicit operator ItemInfoKey(string i_name)
            => new ItemInfoKey(i_name);
        public override string ToString()
            => $"ItemInfoKey{{{itemName}}}";
    }

    [Serializable]
    public class LoginInfo : InfoBase<LoginInfoKey> {
        public string studentId;
        public string password = "default password";

        public LoginInfo() : base(TableType.LOGIN_INFO) { }
        public override string ToString()
            => $"{type}{{{studentId}, {password}}}";
        public override LoginInfoKey getKey()
            => new LoginInfoKey(this);
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

        public static implicit operator LoginInfoKey(string s_id)
            => new LoginInfoKey(s_id);
        public override string ToString()
            => $"LoginInfoKey{{{studentId}}}";
    }

    [Serializable]
    public class RentInfo : InfoBase<RentInfoKey> {
        public string itemName;
        public int amount;
        public string studentId;
        public string startDate;

        public RentInfo() : base(TableType.RENT_INFO) { }
        public override string ToString()
            => $"{type}{{{itemName}, {amount}, {studentId}, {startDate}}}";
        public override RentInfoKey getKey()
            => new RentInfoKey(this);
    }
    [Serializable]
    public class RentInfoKey {
        public readonly string itemName;
        public readonly string studentId;

        public RentInfoKey(in RentInfo info) {
            itemName = info.itemName;
            studentId = info.studentId;
        }
        public RentInfoKey(in string itemName, in string studentId) {
            this.itemName = itemName;
            this.studentId = studentId;
        }

        public override string ToString()
            => $"LentInfoKey{{{itemName}, {studentId}}}";
    }

    [Serializable]
    public class ScheduleInfo : InfoBase<ScheduleInfoKey> {
        public string date;
        public string title;
        public string content;

        public ScheduleInfo() : base(TableType.SCHEDULE_INFO) { }
        public override string ToString()
            => $"{type}{{{date}, {title}, {content}}}";
        public override ScheduleInfoKey getKey()
            => new ScheduleInfoKey(this);
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

        public override string ToString()
            => $"ScheduleInfoKey{{{date}, {title}}}";
    }
}
