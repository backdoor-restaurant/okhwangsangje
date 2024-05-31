using commons.Network;
using commons.Table;
using server.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.Network {
    using static Packet.PacketType;
    using static Request.RequestType;
    using static Response.ResponseType;
    using static commons.Table.Type;

    internal class Gate {
        private readonly XmlAccessor db = new XmlAccessor("Dummy.xml");
        private int tokenSeed = 0;

        public void start() {
            using (var socket = new ServerSocket()) {
                while (true) {
                    // wait client connection
                    socket.listen();
                    Console.WriteLine("asd");
                    // connection established, wait packet
                    var recv = socket.read<Packet>();
                    Console.WriteLine($"Receive: {recv}");

                    var send = makePacket(recv);
                    Console.WriteLine($"Send: {send}");

                    socket.write(send);
                }
            }
        }

        private Packet makePacket(in Packet recv) {
            switch (recv.packetType) {
            case Hello:
                return pong(recv);
            case Auth:
                return authorize(recv);
            case Replication:
                return query(recv as Request);
            case Disconnect:
                return disconnect(recv);
            default:
                throw new ArgumentException("Unknown Packet");
            }
        }

        private Packet pong(in Packet ping) {
            var pong = PacketFactory.newHello();
            pong.authToken = ping.authToken;
            pong.payload = Serializer.serialize("Hello, World!");

            return pong;
        }

        private Packet authorize(in Packet recv) {
            var info = Parser.parse<LoginInfo>(recv.payload);

            if (!verified(info)) {
                return new Packet(Packet.GUEST) {
                    packetType = Auth
                };
            }

            return new Packet(++tokenSeed) {
                packetType = Auth,
            };
        }

        private bool verified(in LoginInfo info) {
            // id - pw pair verification process...
            return true;
        }

        private Response query(in Request request) {
            Response response = new Response(request.authToken) {
                payloadType = request.payloadType,
                payload = null
            };

            bool havePermission = request.requestType == READ ||
                haveModifiablePermission(request.authToken);
            if (!havePermission) {
                response.responseType = REJECTED;
                return response;
            }

            switch (request.payloadType) {
            case MEMBER_INFO:
                aboutMemberDB(request, ref response);
                break;
            default:
                response.responseType = REJECTED;
                break;
            }

            return response;
        }

        bool haveModifiablePermission(in int authToken) {
            // check session permission (read-only or all)
            return authToken != 0;
        }


        private void aboutMemberDB(in Request request, ref Response response) {

            bool result;
            switch (request.requestType) {
            case CREATE:
                result = db.create(
                    Parser.parse<MemberInfo>(request.payload)
                );
                break;
            case READ:
                result = db.read(
                    Parser.parse<string>(request.payload),
                    out MemberInfo read
                );
                Console.WriteLine(result);
                if (result)
                    response.payload = Serializer.serialize(read);
                break;
            case UPDATE:
                result = db.update(
                    Parser.parse<MemberInfo>(request.payload)
                );
                break;
            case DELETE:
                result = db.deleteMember(
                    Parser.parse<string>(request.payload)
                );
                break;
            default:
                result = false;
                break;
            }

            response.responseType = result ? OK : BAD_REQUEST;
        }

        private Packet disconnect(in Packet recv) {
            if (recv.authToken != 0) {
                closeSession(recv.authToken);
            }

            return recv;
        }

        private void closeSession(in int token) {
            // remove authToken from session list...
        }
    }
}
