using commons.Network;
using commons.Table;
using server.Database;
using System;
using System.Collections.Generic;
using System.Data;

namespace server.Network {
    using static commons.Table.Type;
    using static Packet.PacketType;
    using static Request.RequestType;
    using static Response.ResponseType;

    internal class Gate {
        private readonly XmlAccessor db;
        private int tokenSeed = 0;
        private readonly Dictionary<int, string> sessions = new Dictionary<int, string>();

        public Gate() {
            db = new XmlAccessor("Dummy.xml");
        }
        public Gate(in string xmlFile) {
            db = new XmlAccessor(xmlFile);
        }
        public Gate(in Database.DataSet dataSet) {
            db = new XmlAccessor(dataSet);
        }

        public void start() {
            using (var socket = new ServerSocket()) {
                while (true) {
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

        public async void startAsync() {
            using (var socket = new ServerSocket()) {
                while (true) {
                    var recv = await socket.readAsync<Packet>();
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

            if (!verify(info)) {
                return new Packet(Packet.GUEST) {
                    packetType = Auth
                };
            }

            int newToken = ++tokenSeed;
            sessions.Add(newToken, info.studentId);

            return new Packet(newToken) {
                packetType = Auth,
            };
        }

        private bool verify(in LoginInfo info) {
            db.read(new LoginInfoKey(info), out LoginInfo pair);

            var verified = info.password.Equals(pair.password);
            // id - pw pair verification
            return verified;
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

            if(request.payload is null) {
                response.responseType = BAD_REQUEST;
                return response;
            }

            switch (request.requestType) {
            case CREATE:
                create(request, ref response);
                break;
            case READ:
                read(request, ref response);
                break;
            case UPDATE:
                update(request, ref response);
                break;
            case DELETE:
                delete(request, ref response);
                break;
            default:
                response.responseType = NOT_IMPLEMENTED;
                break;
            }

            return response;
        }

        bool haveModifiablePermission(in int authToken) {
            var id = sessions[authToken];
            var known = db.read(new MemberInfoKey(id), out MemberInfo member);

            if (!known) return false;

            // check session permission (read-only or all)
            return member.isAdministrator;
        }

        private void create(in Request request, ref Response response) {
            bool result;
            switch (request.payloadType) {
            case MEMBER_INFO:
                result = db.create(Parser.parse<MemberInfo>(request.payload));
                break;
            case ITEM_INFO:
                result = db.create(Parser.parse<ItemInfo>(request.payload));
                break;
            case LOGIN_INFO:
                result = db.create(Parser.parse<LoginInfo>(request.payload));
                break;
            case LENT_INFO:
                result = db.create(Parser.parse<LentInfo>(request.payload));
                break;
            case SCHEDULE_INFO:
                result = db.create(Parser.parse<ScheduleInfo>(request.payload));
                break;
            default:
                response.responseType = NOT_IMPLEMENTED;
                return;
            }

            response.responseType = result ? OK : NOT_ACCEPTED;
        }

        private void read(in Request request, ref Response response) {
            try {
                bool result;
                switch (request.payloadType) {
                case MEMBER_INFO:
                    result = db.read(
                        Parser.parse<MemberInfoKey>(request.payload),
                        out MemberInfo member
                    );
                    response.payload = Serializer.serialize(member);
                    break;
                case ITEM_INFO:
                    result = db.read(
                        Parser.parse<ItemInfoKey>(request.payload),
                        out ItemInfo item
                    );
                    response.payload = Serializer.serialize(item);
                    break;
                case LOGIN_INFO:
                    result = db.read(
                        Parser.parse<LoginInfoKey>(request.payload),
                        out LoginInfo pair
                    );
                    response.payload = Serializer.serialize(pair);
                    break;
                case LENT_INFO:
                    var lentKey = Parser.parse<LentInfoKey>(request.payload);
                    if(lentKey.itemName is null) {
                        result = db.readFromStudentID(lentKey.studentId,
                            out LentInfo[] info
                        );
                        response.payload = Serializer.serialize(info);
                    }
                    else {
                        result = db.read(lentKey, out LentInfo info);
                        response.payload = Serializer.serialize(info);
                    }
                    break;
                case SCHEDULE_INFO:
                    var scheduleKey = Parser.parse<ScheduleInfoKey>(request.payload);
                    if (scheduleKey.title is null) {
                        result = db.readFromDate(
                            Parser.parse<string>(request.payload),
                            out ScheduleInfo[] schedules
                        );
                        response.payload = Serializer.serialize(schedules);
                    }
                    else {
                        result = db.read(scheduleKey, out ScheduleInfo schedule);
                        response.payload = Serializer.serialize(schedule);
                    }
                    break;
                default:
                    response.responseType = NOT_IMPLEMENTED;
                    return;
                }

                response.responseType = result ? OK : NOT_FOUND;
            }
            catch (ArgumentException) {
                response.responseType = NOT_ACCEPTED;
            }
        }

        private void update(in Request request, ref Response response) {
            try {
                bool result;
                switch (request.payloadType) {
                case MEMBER_INFO:
                    result = db.tryUpdate(Parser.parse<MemberInfo>(request.payload));
                    break;
                case ITEM_INFO:
                    result = db.tryUpdate(Parser.parse<ItemInfo>(request.payload));
                    break;
                default:
                    response.responseType = NOT_IMPLEMENTED;
                    return;
                }
                response.responseType = result ? OK : NOT_FOUND;
            }
            catch (NoNullAllowedException) {
                response.responseType = NOT_ACCEPTED;
            }
            catch (ConstraintException) {
                response.responseType = NOT_ACCEPTED;
            }
        }

        private void delete(in Request request, ref Response response) {
            try {
                bool result;
                switch(request.payloadType) {
                case MEMBER_INFO:
                    result = db.delete(Parser.parse<MemberInfoKey>(request.payload));
                    break;
                case ITEM_INFO:
                    result = db.delete(Parser.parse<ItemInfoKey>(request.payload));
                    break;
                case LOGIN_INFO:
                    result = db.delete(Parser.parse<LoginInfoKey>(request.payload));
                    break;
                case LENT_INFO:
                    var lentKey = Parser.parse<LentInfoKey>(request.payload);
                    if (lentKey.itemName is null) {
                        result = db.deleteFromStudentID(lentKey.studentId);
                    }
                    else {
                        result = db.delete(lentKey);
                    }
                    break;
                case SCHEDULE_INFO:
                    var scheduleKey = Parser.parse<ScheduleInfoKey>(request.payload);
                    if (scheduleKey.title is null) {
                        result = db.deleteFromDate(scheduleKey.date);
                    }
                    else {
                        result = db.delete(scheduleKey);
                    }
                    break;
                default:
                    response.responseType = NOT_IMPLEMENTED;
                    return;
                }
                response.responseType = result ? OK : NOT_FOUND;
            }
            catch (ArgumentException) {
                response.responseType = NOT_ACCEPTED;
            }
        }

        private Packet disconnect(in Packet recv) {
            if (recv.authToken != 0) {
                closeSession(recv.authToken);
            }

            return recv;
        }

        private void closeSession(int token) {
            sessions.Remove(token);
        }
    }
}
