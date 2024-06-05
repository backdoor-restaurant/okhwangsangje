using System;
using commons.VirtualDB;
using commons.Table;

namespace client
{
    internal class Example
    {
        private static readonly MemberVT memberVDB = new MemberVT();

        public static void main()
        {
            // commons.Environment.Environment.AllocConsole();

            LoginInfo loginInfo = new LoginInfo()
            {
                studentId = "0",
                password = "secret1234"
            };
            memberVDB.signin(loginInfo);

            MemberInfo newMember = new MemberInfo()
            {
                studentId = "1234",
                name = "Dummy",
                department = "Software",
                phoneNumber = "010-0000-0000"
            };
            Console.WriteLine($"New Member {newMember}");

            var c_result = memberVDB.create(newMember);
            Console.WriteLine($"Create Result: {c_result}");

            var r_result = memberVDB.read(
                new MemberInfoKey("0"),
                out MemberInfo member
            );
            Console.WriteLine($"Read Result: {r_result}, {member}");

            var u_result = memberVDB.update(newMember);
            Console.WriteLine($"Update Result: {u_result}");

            var d_result = memberVDB.delete(
                new MemberInfoKey("4")
            );
            Console.WriteLine($"Delete Result: {d_result}");
        }
    }
}
