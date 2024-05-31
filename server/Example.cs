using System;
using System.Data;
using commons.Network;
using server.Network;
using server.Database;

namespace server {
    internal static class Example {
        public static void run1() {
            // commons.Environment.Environment.AllocConsole();

            var gate = new Gate();
            gate.start();
        }
    }
}
