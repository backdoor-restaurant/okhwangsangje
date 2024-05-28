using System;
using System.Configuration;
using System.Windows.Forms;

namespace server
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (ConfigurationManager.AppSettings["Console"] == "true")
            {
                Example.run2();
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Server());
        }
    }
}
