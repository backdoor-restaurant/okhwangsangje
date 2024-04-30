using System;
using System.Threading;

using commons;
using commons.Database;

namespace ConsoleServer
{
    internal class Program
    {
        static void Main()
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
                        response.payload = Serializer.serialize(
                            HardcodedDatabase.db.find(
                                PacketParser.parse(request)
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

                Thread.Sleep(100);

                socket.disconnect();
            }
        }
    }
}
