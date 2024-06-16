using commons.Network;
using commons.Table;
using server.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;

namespace server.Network {
    using static Packet.PacketType;
    using static RequestType;
    using static ResponseType;
    using static commons.Table.TableType;

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

        public async void start() {
            using (var socket = new ServerSocket()) {
                while (true) {
                    // wait client connection
                    await socket.listen();

                    // connection established, wait packet
                    var recv = socket.read<Packet>();
                    Debug.WriteLine($"Receive: {recv}");

                    var send = makePacket(recv);

                    Debug.WriteLine($"Send: {send}");
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
                return query(recv);
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
            var info = recv.getPayload<LoginInfo>();

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
            db.read(info.getKey(), out LoginInfo pair);

            var verified = info.password.Equals(pair.password);
            // id - pw pair verification
            return verified;
        }

        private Packet query(in Packet request) {
            var response = new Packet(request.authToken);
            var resExp = new ResponseExpression();

            //if (request.payload is null) {
            //    resExp.response = BAD_REQUEST;
            //    response.setPayload(resExp);

            //    return response;
            //}

            var reqExp = request.getPayload<RequestExpression>();
            
            bool havePermission = reqExp.request == READ ||
                haveModifiablePermission(request.authToken);
            if (!havePermission) {
                resExp.response = NOT_ACCEPTED;
                response.setPayload(resExp);

                return response;
            }

            var obj = RequestInterpreter.interpret(reqExp);

            switch (reqExp.request) {
            case CREATE:
                create(reqExp.table, obj, ref resExp);
                break;
            case READ:
                read(reqExp.table, obj, ref resExp);
                break;
            case UPDATE:
                update(reqExp.table, obj, ref resExp);
                break;
            case DELETE:
                delete(reqExp.table, obj, ref resExp);
                break;
            default:
                resExp.response = NOT_IMPLEMENTED;
                break;
            }

            response.setPayload(resExp);
            return response;
        }

        bool haveModifiablePermission(in int authToken) {
            var id = sessions[authToken];
            var known = db.read(new MemberInfoKey(id), out MemberInfo member);

            if (!known) return false;

            // check session permission (read-only or all)
            return member.isAdministrator;
        }

        private void create(in TableType table, in object obj, ref ResponseExpression resExp) {
            bool result = false;
            switch (table) {
            case MEMBER_INFO:
                result = db.create(obj as MemberInfo);
                break;
            case ITEM_INFO:
                result = db.create(obj as ItemInfo);
                break;
            case LOGIN_INFO:
                result = db.create(obj as LoginInfo);
                break;
            case RENT_INFO:
                result = db.create(obj as RentInfo);
                break;
            case SCHEDULE_INFO:
                result = db.create(obj as ScheduleInfo);
                break;
            default:
                resExp.response = NOT_IMPLEMENTED;
                return;
            }

            resExp.response = result ? OK : NOT_ACCEPTED;
        }

        private void read(in TableType table, in object obj, ref ResponseExpression resExp) {
            try {
                bool result = false;
                switch (table) {
                case MEMBER_INFO:
                    result = db.read(obj as MemberInfoKey, out MemberInfo member);
                    resExp.setArg(member);
                    break;
                case ITEM_INFO:
                    var itemKey = obj as ItemInfoKey;
                    if(itemKey.itemName is null) {
                        result = db.readAll(out ItemInfo[] items);
                        resExp.setArg(itemKey);
                    }
                    else {
                        result = db.read(obj as ItemInfoKey, out ItemInfo item);
                        resExp.setArg(item);
                    }
                    break;
                case LOGIN_INFO:
                    result = db.read(obj as LoginInfoKey, out LoginInfo pair);
                    resExp.setArg(pair);
                    break;
                case RENT_INFO:
                    var lentKey = obj as RentInfoKey;
                    if (lentKey.itemName is null) {
                        result = db.readFromStudentID(lentKey.studentId,
                            out RentInfo[] info
                        );
                        resExp.setArg(info);
                    }
                    else {
                        result = db.read(lentKey, out RentInfo info);
                        resExp.setArg(info);
                    }
                    break;
                case SCHEDULE_INFO:
                    var scheduleKey = obj as ScheduleInfoKey;
                    if (scheduleKey.title is null) {
                        result = db.readFromDate(scheduleKey.date,
                            out ScheduleInfo[] schedules
                        );
                        resExp.setArg(schedules);
                    }
                    else {
                        result = db.read(scheduleKey, out ScheduleInfo schedule);
                        resExp.setArg(schedule);
                    }
                    break;
                default:
                    resExp.response = NOT_IMPLEMENTED;
                    return;
                }

                resExp.response = result ? OK : NOT_FOUND;
            }
            catch (ArgumentException) {
                resExp.response = NOT_ACCEPTED;
            }
        }

        private void update(in TableType table, in object obj, ref ResponseExpression resExp) {
            try {
                bool result = false;
                switch (table) {
                case MEMBER_INFO:
                    result = db.tryUpdate(obj as MemberInfo);
                    break;
                case ITEM_INFO:
                    result = db.tryUpdate(obj as ItemInfo);
                    break;
                case LOGIN_INFO:
                    result = db.tryUpdate(obj as LoginInfo);
                    break;
                case RENT_INFO:
                    result = db.tryUpdate(obj as RentInfo);
                    break;
                case SCHEDULE_INFO:
                    result = db.tryUpdate(obj as ScheduleInfo);
                    break;
                default:
                    resExp.response = NOT_IMPLEMENTED;
                    return;
                }
                resExp.response = result ? OK : NOT_FOUND;
            }
            catch (NoNullAllowedException) {
                resExp.response = NOT_ACCEPTED;
            }
            catch (ConstraintException) {
                resExp.response = NOT_ACCEPTED;
            }
            catch (InvalidConstraintException) {
                resExp.response = NOT_ACCEPTED;
            }
        }

        private void delete(in TableType table, in object obj, ref ResponseExpression resExp) {
            try {
                bool result = false;
                switch (table) {
                case MEMBER_INFO:
                    result = db.delete(obj as MemberInfoKey);
                    break;
                case ITEM_INFO:
                    result = db.delete(obj as ItemInfoKey);
                    break;
                case LOGIN_INFO:
                    result = db.delete(obj as LoginInfoKey);
                    break;
                case RENT_INFO:
                    var lentKey = obj as RentInfoKey;
                    if (lentKey.itemName is null) {
                        result = db.deleteFromStudentID(lentKey.studentId);
                    }
                    else {
                        result = db.delete(lentKey);
                    }
                    break;
                case SCHEDULE_INFO:
                    var scheduleKey = obj as ScheduleInfoKey;
                    if (scheduleKey.title is null) {
                        result = db.deleteFromDate(scheduleKey.date);
                    }
                    else {
                        result = db.delete(scheduleKey);
                    }
                    break;
                default:
                    resExp.response = NOT_IMPLEMENTED;
                    return;
                }
                resExp.response = result ? OK : NOT_FOUND;
            }
            catch (ArgumentException) {
                resExp.response = NOT_ACCEPTED;
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
