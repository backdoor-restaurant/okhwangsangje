using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

using commons;
using commons.Table;

namespace ConsoleServer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var socket = new commons.Socket();

                while (true)
                {
                    Console.WriteLine("Waiting...");
                    socket.listen();

                    Console.WriteLine("Connected!");

                    var request = socket.read<Request>();

                    // <-- make packet
                    var response = new Response()
                    {
                        table = request.table
                    };

                    if(request.table == commons.Table.Type.MEMBER_INFO)
                    {                        
                        var key = request.Deserialize<string>();
                        Console.WriteLine($"{request.type} {request.table} {key}");

                        // Assume member info found.
                        response.type = Response.Type.OK;

                        var memberInfo = new MemberInfo()
                        {
                            name = "홍길동",
                            department = "Software",
                            studentId = "1234567890",
                            phoneNumber = "010-1234-5678"
                        };

                        response.Serialize(memberInfo);
                    }

                    // end -->
                    Console.WriteLine($"Response: {response}");
                    socket.write(response);
                    socket.disconnect();
                }
            }
            catch(SocketException se)
            {
                Console.WriteLine($"Socket Exception: {se}");
            }
        }
    }
}
