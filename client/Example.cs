using System;
using commons.VirtualDB;
using commons.Table;
using System.Threading;

namespace client {
    internal class Example {
        private static readonly LoginInfo admin = new LoginInfo() {
            studentId = "0",
            password = "secret1234"
        };

        public static void testMemberVT() {
            var memberVT = new MemberVT();
            memberVT.signin(admin);

            var testMember = new MemberInfo() {
                studentId = "1234",
                name = "Dummy",
                department = "Software",
                phoneNumber = "010-0000-0000"
            };
            var testKey = testMember.getKey();
             //var testKey = new MemberInfoKey(testMember);
            var updated = new MemberInfo() {
                studentId = "1234",
                name = "Dummy",
                department = "Computer Sci.",
                phoneNumber = "010-4321-4321"
            };

            var c_result = memberVT.create(testMember);
            Console.WriteLine($"Create Result: {c_result}");
            Thread.Sleep(1000);

            var r_result = memberVT.read(testKey, out MemberInfo member);
            // var r_result = memberVT.read("1234", out MemberInfo member);
            Console.WriteLine($"Read Result: {r_result}, {member}");
            Thread.Sleep(1000);

            var u_result = memberVT.update(updated);
            Console.WriteLine($"Update Result: {u_result}");
            Thread.Sleep(1000);

            // var d_result = memberVT.delete(testKey);
            var d_result = memberVT.delete("1234");
            Console.WriteLine($"Delete Result: {d_result}");
        }

        public static void testItemInfoVT() {
            var itemVT = new LoginInfoVTB();
            itemVT.signin(admin);

            var testItemInfo = new ItemInfo() {
                itemName = "Newbie Bow",
                amount = 10
            };
            //var testKey = testItemInfo.getKey();
             var testKey = new ItemInfoKey(testItemInfo);
            var updated = new ItemInfo() {
                itemName = "Newbie Bow",
                amount = 8
            };

            var c_result = itemVT.create(testItemInfo);
            Console.WriteLine($"Create Result: {c_result}");
            Thread.Sleep(1000);

            //var r_result = itemVT.read(testKey, out ItemInfo item);
             var r_result = itemVT.read("Newbie Bow", out ItemInfo item);
            Console.WriteLine($"Read Result: {r_result}, {item}");
            Thread.Sleep(1000);

            var u_result = itemVT.update(updated);
            Console.WriteLine($"Update Result: {u_result}");
            Thread.Sleep(1000);

             var d_result = itemVT.delete(testKey);
            //var d_result = itemVT.delete("Newbie Bow");
            Console.WriteLine($"Delete Result: {d_result}");
        }

        public static void testLoginInfoVT() {
            var loginVT = new LoginVT();
            loginVT.signin(admin);

            var testLoginInfo = new LoginInfo() {
                studentId = "1357",
                password = "qwerty1357"
            };
            var testKey = testLoginInfo.getKey();
            //var testKey = new LoginInfoKey(testLoginInfo);
            var updated = new LoginInfo() {
                studentId = "1357",
                password = "updated1357"
            };

            var c_result = loginVT.create(testLoginInfo);
            Console.WriteLine($"Create Result: {c_result}");
            Thread.Sleep(1000);

            var r_result = loginVT.read(testKey, out LoginInfo login);
            //var r_result = loginVT.read("1357", out LoginInfo login);
            Console.WriteLine($"Read Result: {r_result}, {login}");
            Thread.Sleep(1000);

            var u_result = loginVT.update(updated);
            Console.WriteLine($"Update Result: {u_result}");
            Thread.Sleep(1000);

            var d_result = loginVT.delete(testKey);
            // var d_result = loginVT.delete("1357");
            Console.WriteLine($"Delete Result: {d_result}");
        }

        public static void testLentInfoVT() {
            var lentInfoVT = new LentInfoVT();
            lentInfoVT.signin(admin);

            var testLentInfo = new LentInfo() {
                itemName = "Newbie Bow",
                amount = 1,
                studentId = "1357",
                startDate = DateTime.Today.ToString("yyyy-MM-dd")
            };
            //var testKey = testLentInfo.getKey();
            var testKey = new LentInfoKey(testLentInfo);
            var updated = new LentInfo() {
                itemName = "Newbie Bow",
                amount = 2,
                studentId = "1357",
                startDate = DateTime.Today.ToString("yyyy-MM-dd")
            };

            var c_result = lentInfoVT.create(testLentInfo);
            Console.WriteLine($"Create Result: {c_result}");
            Thread.Sleep(1000);

            var r_result = lentInfoVT.read(testKey, out LentInfo info);
            Console.WriteLine($"Read Result: {r_result}, {info}");
            Thread.Sleep(1000);

            var u_result = lentInfoVT.update(updated);
            Console.WriteLine($"Update Result: {u_result}");
            Thread.Sleep(1000);

            var d_result = lentInfoVT.delete(testKey);
            Console.WriteLine($"Delete Result: {d_result}");
        }
    }
}
