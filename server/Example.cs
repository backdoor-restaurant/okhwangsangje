using System;
using System.Data;
using commons.Network;
using server.Network;

namespace server
{
    internal static class Example
    {
        public static void run1()
        {
            commons.Environment.Environment.AllocConsole();

            var gate = new Gate();
            gate.start();
        }

        public static void run2() {
            // commons.Environment.Environment.AllocConsole();

            var dataSet = new Database.DataSet();
            dataSet.ReadXml("../../Database/Dummy.xml");


            dataSet.WriteXml("../../Database/Dummy.xml");

            foreach(var m in dataSet.MemberInfo){
                Console.WriteLine("{0} {1}", m.Name, m.isAdministrator);
            }

            Console.ReadLine();
        }
    }
}
