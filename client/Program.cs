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
                int delay = 1000;

                Console.Write("Press Enter to test MemberInfoVT...");
                Console.ReadLine();
                Example.testMemberVT(delay);

                Console.Write("\nPress Enter to test ItemInfoVT...");
                Console.ReadLine();
                Example.testItemVT(delay);

                Console.Write("\nPress Enter to test LoginInfoVT...");
                Console.ReadLine();
                Example.testLoginVT(delay);

                Console.Write("\nPress Enter to test LentInfoVT...");
                Console.ReadLine();
                Example.testLentInfoVT(delay);

                Console.Write("\nPress Enter to test ScheduleVT...");
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
