using commons.Network;
using commons.Table;
using server.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.Network
{
    internal class Gate
    {
        private uint tokenSeed = 0;

        public void start()
        {
            using (var socket = new ServerSocket())
            {
                while (true)
                {
                    // wait client connection
                    socket.listen();

                    // connection established, wait packet
                    var recv = socket.read<Packet>();
                    Console.WriteLine($"Receive: {recv}");

                    var send = makePacket(recv);
                    Console.WriteLine($"Send: {send}");
                    
                    socket.write(send);
                }
            }
        }

        private Packet makePacket(in Packet recv)
        {
            switch (recv.packetType)
            {
                case Packet.PacketType.Hello:
                    return pong(recv);
                case Packet.PacketType.Auth:
                    return authorize(recv);
                case Packet.PacketType.Replication:
                    return query((Request)recv);
                case Packet.PacketType.Disconnect:
                    return disconnect(recv);
                default:
                    throw new Exception("Unknown Packet");
            }
        }

        private Packet pong(in Packet ping)
        {
            var pong = PacketFactory.newHello();
            pong.authToken = ping.authToken;
            pong.payload = Serializer.serialize("Hello, World!");

            return pong;
        }

        private Packet authorize(in Packet recv)
        {
            var info = Parser.parse<LoginInfo>(recv.payload);

            if (!verified(info))
            {
                return new Packet(Packet.GUEST)
                {
                    packetType = Packet.PacketType.Auth
                };
            }

            return new Packet(++tokenSeed)
            {
                packetType = Packet.PacketType.Auth,
            };
        }

        private bool verified(in LoginInfo info)
        {
            return true;
        }

        private Response query(in Request request)
        {
            switch (request.payloadType)
            {
                case commons.Table.Type.MEMBER_INFO:
                    return aboutMemberDB(request);
                default:
                    return new Response(request.authToken)
                    {
                        type = Response.ResponseType.NOT_FOUND,
                        payload = new byte[0]
                    };
            }
        }

        private Response aboutMemberDB(in Request request)
        {
            var response = new Response(request.authToken)
            {
                payloadType = request.payloadType
            };

            switch (request.requestType)
            {
                case Request.RequestType.CREATE:
                    goto case Request.RequestType.UPDATE;
                case Request.RequestType.READ:
                    var info = Hardcoded.db.find(PacketParser.parse<string>(request));
                    if (info != null)
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

            return response;
        }

        private Packet disconnect(in Packet recv)
        {
            if(recv.authToken != 0)
            {
                closeSession(recv.authToken);
            }

            return recv;
        }

        private void closeSession(in uint token)
        {
            // remove authToken from session list...
        }
    }
}
