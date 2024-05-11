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
                    var response = new Response(request.authToken)
                    {
                        payloadType = request.payloadType
                    };

                    switch (request.payloadType)
                    {
                        case commons.Table.Type.MEMBER_INFO:
                            switch (request.requestType)
                            {
                                case Request.RequestType.CREATE:
                                    goto case Request.RequestType.UPDATE;
                                case Request.RequestType.READ:
                                    var info = Hardcoded.db.find(PacketParser.parse<string>(request));
                                    if(info != null)
                                    {
                                        response.payload = Serializer.serialize(info);
                                        response.type = Response.ResponseType.OK;
                                    }
                                    else
                                    {
                                        response.payload = new byte[0];
                                        response.type = Response.ResponseType.NOT_FOUND;
                                    }
                                    break;
                                case Request.RequestType.UPDATE:
                                    goto case Request.RequestType.DELETE;
                                case Request.RequestType.DELETE:
                                    response.payload = new byte[0];
                                    response.type = Response.ResponseType.REJECTED;
                                    break;
                            }
                            break;
                        default:
                            response.payload = new byte[0];
                            response.type = Response.ResponseType.NOT_FOUND;
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
