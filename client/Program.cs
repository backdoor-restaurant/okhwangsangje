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
                Example.testMemberVT();
                Console.ReadLine();

                Example.testItemInfoVT();
                Console.ReadLine();

                Example.testLoginInfoVT();
                Console.ReadLine();

                Console.ReadLine();
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
        }
    }
}
