using System;

using commons.Table;

namespace commons.Database
{
    public class HardcodedDatabase
    {
        public static HardcodedDatabase db = new HardcodedDatabase();

        private LoginInfo[] logins = new LoginInfo[]
        {
            new LoginInfo()
            {
                studentId = "0",
                password = "secret1234"
            }
        };

        private MemberInfo[] members = new MemberInfo[]
        {
            new MemberInfo()
            {
                studentId = "0",
                name = "root",
                department = "",
                isAdministrator = true,
            },
            new MemberInfo()
            {
                studentId = "1",
                name = "Some Random Guy",
                department = "Software",
                phoneNumber = "010-1234-5678",
            },
            new MemberInfo()
            {
                studentId = "2",
                name = "Elon Musk",
                department = "Enginerring",
                phoneNumber = "010-2345-6789",
            },
            new MemberInfo()
            {
                studentId = "3",
                name = "Bill Gates",
                department = "Computer Sci.",
                phoneNumber = "010-3456-7890",
            },
            new MemberInfo()
            {
                studentId = "4",
                name = "Warren Buffett",
                department = "Economics",
                phoneNumber = "010-1324-5768",
                isAdministrator = true,
            },
            new MemberInfo()
            {
                studentId = "5",
                name = "ChatGPT",
                department = "Software",
            }
        };

        private ItemInfo[] items = new ItemInfo[]
        {
            new ItemInfo()
            {
                name = "46 장궁",
                amount = 1
            }
        };

        private LentInfo[] lents = new LentInfo[]
        {
            new LentInfo()
            {
                itemName = "46 장궁",
                amount = 1,
                studentId = "1",
                startDate = "2024-03-21"
            }
        };

        private ScheduleInfo[] schedules = new ScheduleInfo[]
        {
            new ScheduleInfo()
            {
                date = "2024-04-30",
                title = "간식행사",
                content = "Lorem Ipsum..."
            }
        };

        public MemberInfo find(string studentId)
        {
            return Array.Find(members, m => studentId.Equals(m.studentId));
        }
    }
}
