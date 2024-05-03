using System;

using commons.VirtualDB;
using commons.Table;

namespace ConsoleClient
{
    internal class Program
    {
        static void Main()
        {
            MemberInfo newMember = new MemberInfo()
            {
                studentId = "1234",
                name = "Dummy",
                department = "Software",
                phoneNumber = "010-0000-0000"
            };
            Console.WriteLine($"New Member {newMember}");

            var c_result = ClientWrapper.createMemberInfo(newMember);
            Console.WriteLine($"Create Result: {c_result}");

            var r_result = ClientWrapper.readMemberInfo(newMember.studentId);
            Console.WriteLine($"Read Result: {r_result}");

            var u_result = ClientWrapper.updateMemberInfo(newMember.studentId, newMember);
            Console.WriteLine($"Update Result: {u_result}");

            var d_result = ClientWrapper.deleteMemberInfo(newMember.studentId);
            Console.WriteLine($"Delete Result: {d_result}");
        }
    }
}
