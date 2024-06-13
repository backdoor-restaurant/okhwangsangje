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

        public static void testMemberVT(in int delay = 0) {
            var vtable = new MemberVT();
            vtable.signin(admin);

            var test = new MemberInfo() {
                studentId = "1234",
                name = "Dummy",
                department = "Software",
                phoneNumber = "010-0000-0000"
            };
            var key = test.getKey();
            // var key = new MemberInfoKey(test);
            // var key = new MemberInfoKey("1234");
            // MemberInfoKey key = "1234";
            var updated = new MemberInfo() {
                studentId = "1234",
                name = "Dummy",
                department = "Computer Sci.",
                phoneNumber = "010-4321-4321"
            };

            var c_result = vtable.create(test);
            Console.WriteLine($"Create Result: {c_result}");
            Thread.Sleep(delay);

            var r_result = vtable.read(key, out MemberInfo member);
            // var r_result = vtable.read("1234", out MemberInfo member);
            Console.WriteLine($"Read Result: {r_result}, {member}");
            Thread.Sleep(delay);

            var u_result = vtable.update(updated);
            Console.WriteLine($"Update Result: {u_result}");
            Thread.Sleep(delay);

            // var d_result = vtable.delete(key);
            var d_result = vtable.delete("1234");
            Console.WriteLine($"Delete Result: {d_result}");
        }

        public static void testItemVT(in int delay = 0) {
            var vtable = new ItemVT();
            vtable.signin(admin);

            var test = new ItemInfo() {
                itemName = "Newbie Bow",
                amount = 10
            };
            var key = test.getKey();
            var updated = new ItemInfo() {
                itemName = "Newbie Bow",
                amount = 8
            };

            var c_result = vtable.create(test);
            Console.WriteLine($"Create Result: {c_result}");
            Thread.Sleep(delay);

            var r_result = vtable.read(key, out ItemInfo item);
            Console.WriteLine($"Read Result: {r_result}, {item}");
            Thread.Sleep(delay);

            var u_result = vtable.update(updated);
            Console.WriteLine($"Update Result: {u_result}");
            Thread.Sleep(delay);

            var d_result = vtable.delete(key);
            Console.WriteLine($"Delete Result: {d_result}");
        }

        public static void testLoginVT(in int delay = 0) {
            var vtable = new LoginVT();
            vtable.signin(admin);

            var test = new LoginInfo() {
                // student id is foreign key
                studentId = "6",
                password = "qwerty1357"
            };
            var key = test.getKey();
            var updated = new LoginInfo() {
                studentId = "6",
                password = "updated1357"
            };

            var c_result = vtable.create(test);
            Console.WriteLine($"Create Result: {c_result}");
            Thread.Sleep(delay);

            var r_result = vtable.read(key, out LoginInfo login);
            Console.WriteLine($"Read Result: {r_result}, {login}");
            Thread.Sleep(delay);

            var u_result = vtable.update(updated);
            Console.WriteLine($"Update Result: {u_result}");
            Thread.Sleep(delay);

            var d_result = vtable.delete(key);
            Console.WriteLine($"Delete Result: {d_result}");
        }

        public static void testLentInfoVT(in int delay = 0) {
            var vtable = new LentInfoVT();
            vtable.signin(admin);

            var test = new LentInfo() {
                // itemName is foreign key
                itemName = "Test Bow",
                amount = 1,
                // student id is foreign key
                studentId = "6",
                startDate = DateTime.Today.ToString("yyyy-MM-dd")
            };
            var key = test.getKey();
            var updated = new LentInfo() {
                itemName = "Test Bow",
                amount = 2,
                studentId = "6",
                startDate = DateTime.Today.ToString("yyyy-MM-dd")
            };

            var c_result = vtable.create(test);
            Console.WriteLine($"Create Result: {c_result}");
            Thread.Sleep(delay);

            var r_result = vtable.read(key, out LentInfo info);
            Console.WriteLine($"Read Result: {r_result}, {info}");
            Thread.Sleep(delay);

            var u_result = vtable.update(updated);
            Console.WriteLine($"Update Result: {u_result}");
            Thread.Sleep(delay);

            var d_result = vtable.delete(key);
            Console.WriteLine($"Delete Result: {d_result}");
        }

        public static void testScheduleVT(in int delay = 0) {
            var vtable = new ScheduleVT();
            vtable.signin(admin);

            var test = new ScheduleInfo() {
                date = DateTime.Today.ToString("yyyy-MM-dd"),
                title = "Schedule Test",
                content = "Test Contents"
            };
            var key = test.getKey();
            var updated = new ScheduleInfo() {
                date = DateTime.Today.ToString("yyyy-MM-dd"),
                title = "Schedule Test",
                content = "New Test Contents"
            };

            var c_result = vtable.create(test);
            Console.WriteLine($"Create Result: {c_result}");
            Thread.Sleep(delay);

            var r_result = vtable.read(key, out ScheduleInfo schedule);
            Console.WriteLine($"Read Result: {r_result}, {schedule}");
            Thread.Sleep(delay);

            var u_result = vtable.update(updated);
            Console.WriteLine($"Update Result: {u_result}");
            Thread.Sleep(delay);

            var d_result = vtable.delete(key);
            Console.WriteLine($"Delete Result: {d_result}");
        }
    }
}
