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

            var ra_result = vtable.readAll(out ItemInfo[] items);
            Console.WriteLine($"Read Result: {ra_result}, {items.Length}");
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

            var test = new RentInfo() {
                // itemName is foreign key
                itemName = "Dummy",
                amount = 5,
                // student id is foreign key
                studentId = "6",
                startDate = DateTime.Today.ToString("yyyy-MM-dd")
            };
            var key = test.getKey();
            var updated = new RentInfo() {
                itemName = "Dummy",
                amount = 2,
                studentId = "6",
                startDate = DateTime.Today.ToString("yyyy-MM-dd")
            };

            var c_result = vtable.create(test);
            Console.WriteLine($"Create Result: {c_result}");
            Thread.Sleep(delay);

            var r1_result = vtable.read(key, out RentInfo info1);
            Console.WriteLine($"Read Result: {r1_result}, {info1}");
            Thread.Sleep(delay);
            
            var r2_result = vtable.readFromStudentID("6", out RentInfo[] info2);
            Console.WriteLine($"Read Result: {r2_result}");
            foreach(var i in info2) {
                Console.WriteLine(i);
            }

            var u_result = vtable.update(updated);
            Console.WriteLine($"Update Result: {u_result}");
            Thread.Sleep(delay);

            var d_result = vtable.delete(key);
            Console.WriteLine($"Delete Result: {d_result}");
        }

        public static void testScheduleVT(in int delay = 0) {
            var vtable = new ScheduleVT();
            vtable.signin(admin);

            var today = DateTime.Today.ToString("yyyy-MM-dd");

            var test1 = new ScheduleInfo() {
                date = today,
                title = "Schedule Test 1",
                content = "Test Contents 1"
            };
            var test2 = new ScheduleInfo() {
                date = today,
                title = "Schedule Test 2",
                content = "Test Contents 2"
            };
            var test3 = new ScheduleInfo() {
                date = today,
                title = "Schedule Test 3",
                content = "Test Contents 3"
            };
            var key = test1.getKey();
            var updated = new ScheduleInfo() {
                date = DateTime.Today.ToString("yyyy-MM-dd"),
                title = "Schedule Test 1",
                content = "New Test Contents"
            };

            var c_result1 = vtable.create(test1);
            Console.WriteLine($"Create Result1: {c_result1}");
            var c_result2 = vtable.create(test2);
            Console.WriteLine($"Create Result2: {c_result2}");
            var c_result3 = vtable.create(test3);
            Console.WriteLine($"Create Result3: {c_result3}");
            Thread.Sleep(delay);

            var r_result1 = vtable.read(key, out ScheduleInfo schedule);
            Console.WriteLine($"Read Result: {r_result1}, {schedule}");
            Thread.Sleep(delay);

            var r_result2 = vtable.readFromDate(today, out ScheduleInfo[] schedules);
            Console.WriteLine($"Read Result: {r_result1}, {schedules.Length}");
            Thread.Sleep(delay);

            var u_result = vtable.update(updated);
            Console.WriteLine($"Update Result: {u_result}");
            Thread.Sleep(delay);

            var d_result1 = vtable.delete(key);
            Console.WriteLine($"Delete Result: {d_result1}");
            Thread.Sleep(delay);

            var d_result2 = vtable.deleteFromDate(today);
            Console.WriteLine($"Delete Result: {d_result2}");
        }
    }
}
