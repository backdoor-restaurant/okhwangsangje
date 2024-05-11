using System;
using commons.Network;
using server.Database;
using server.Network;

namespace server
{
    internal static class Example
    {
        public static void main()
        {
            commons.Environment.Environment.AllocConsole();

            var gate = new Gate();
            gate.start();
        }
    }
}
