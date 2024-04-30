using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

using commons;

namespace ConsoleClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var socket = new commons.Socket();

            socket.connect();

            var request = new Request()
            {
                type = Request.Type.READ,
                table = commons.Table.Type.MEMBER_INFO
            };
            request.Serialize("4");

            Console.WriteLine($"Request: {request}");
            socket.write(request);

            var response = socket.read<Response>();
            Console.WriteLine($"Response: {response}");
        }
    }
}
