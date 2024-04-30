using System;

using commons;

namespace ConsoleClient
{
    internal class Program
    {
        static void Main()
        {
            var socket = new commons.Socket();

            socket.connect();

            // <-- make Request packet
            var request = new Request()
            {
                type = Request.Type.READ,
                table = commons.Table.Type.MEMBER_INFO,
                payload = Serializer.serialize("4")
            };
            // end -->

            Console.WriteLine($"Request: {request}");
            socket.write(request);

            var response = socket.read<Response>();
            Console.WriteLine($"Response: {response}");
        }
    }
}
