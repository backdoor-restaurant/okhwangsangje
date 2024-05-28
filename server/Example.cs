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
            commons.Environment.Environment.AllocConsole();

            var dataSet = new Database.DataSet();
            dataSet.ReadXml("../../Database/CheonWoonDB.xml");


            dataSet.WriteXml("../../Database/Result.xml");

            foreach(var m in dataSet.MemberInfo){
                Console.WriteLine(m.Name);
            }

            Console.ReadLine();
        }
    }
}
