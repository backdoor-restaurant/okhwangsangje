using System;

using commons;
using commons.Database;

namespace ConsoleServer
{
    internal class Program
    {
        static void Main()
        {
            using (var socket = new ServerSocket())
            {
                while (true)
                {
                    // wait client connection
                    socket.listen();

                    // connection established, wait request
                    var request = socket.read<Request>();
                    Console.WriteLine($"Request: {request}");

                    // <-- make Response packet
                    // todo. move to response packet factory!
                    var response = new Response()
                    {
                        table = request.table
                    };

                    switch (request.table)
                    {
                        case commons.Table.Type.MEMBER_INFO:
                            switch (request.type)
                            {
                                case Request.Type.CREATE:
                                    goto case Request.Type.UPDATE;
                                case Request.Type.READ:
                                    var info = HardcodedDatabase.db.find(PacketParser.parse<string>(request));
                                    if(info != null)
                                    {
                                        response.payload = Serializer.serialize(info);
                                        response.type = Response.Type.OK;
                                    }
                                    else
                                    {
                                        response.payload = new byte[0];
                                        response.type = Response.Type.NOT_FOUND;
                                    }
                                    break;
                                case Request.Type.UPDATE:
                                    goto case Request.Type.DELETE;
                                case Request.Type.DELETE:
                                    response.payload = new byte[0];
                                    response.type = Response.Type.REJECTED;
                                    break;
                            }
                            break;
                        default:
                            response.payload = new byte[0];
                            response.type = Response.Type.NOT_FOUND;
                            break;
                    }
                    // end -->

                    // send query result.
                    Console.WriteLine($"Response: {response}");
                    socket.write(response);
                }
            }
        }
    }
}
