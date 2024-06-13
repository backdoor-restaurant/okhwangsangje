using System;
using System.Configuration;
using System.Windows.Forms;

namespace client {
    internal static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            if (ConfigurationManager.AppSettings["Test"] == "true") {
                int delay = 0;

                Console.WriteLine("Press Any Key to test MemberInfoVT");
                Console.ReadLine();
                Example.testMemberVT(delay);

                Console.WriteLine("\nPress Any Key to test ItemInfoVT");
                Console.ReadLine();
                Example.testItemVT(delay);

                Console.WriteLine("\nPress Any Key to test LoginInfoVT");
                Console.ReadLine();
                Example.testLoginVT(delay);

                Console.WriteLine("\nPress Any Key to test LentInfoVT");
                Console.ReadLine();
                Example.testLentInfoVT(delay);

                Console.WriteLine("\nPress Any Key to test ScheduleVT");
                Console.ReadLine();
                Example.testScheduleVT(delay);

                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
        }
    }
}
