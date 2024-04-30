using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using commons.Table;

namespace commons.Database
{
    public class HardcodedDatabase
    {
        public static HardcodedDatabase db = new HardcodedDatabase();

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

        public MemberInfo find(string studentId)
        {
            return Array.Find<MemberInfo>(members, m => studentId.Equals(m.studentId));
        }
    }
}
