using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

using commons;
using commons.Database;

namespace ConsoleServer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var socket = new commons.Socket();

            while (true)
            {
                socket.listen();
                var request = socket.read<Request>();
                Console.WriteLine($"Request: {request}");

                // <-- make Response packet
                var response = new Response()
                {
                    table = request.table

                };

                switch (request.table)
                {
                    case commons.Table.Type.MEMBER_INFO:
                        response.Serialize(
                            HardcodedDatabase.db.find(
                                request.Deserialize<string>()
                            )
                        );
                        response.type = Response.Type.OK;
                        break;
                    default:
                        response.type = Response.Type.NOT_FOUND;
                        break;
                }
                // end -->

                Console.WriteLine($"Response: {response}");
                socket.write(response);

                socket.disconnect();
            }
        }
    }
}
