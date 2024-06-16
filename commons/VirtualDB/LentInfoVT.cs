using commons.Network;
using commons.Table;

namespace commons.VirtualDB {
    using static Table.TableType;
    using static RequestType;

    public class LentInfoVT : VirtualTable<LentInfoKey, LentInfo> {
        public bool readFromStudentID(in string s_id, out LentInfo[] info) {
            bool succeed = false;

            using (var socket = new ClientSocket()) {
                var incompleteKey = new LentInfoKey(null, s_id);

                socket.write(new Request(token) {
                    requestType = Request.RequestType.READ,
                    payloadType = LENT_INFO,
                    payload = Serializer.serialize(incompleteKey)
                });

                var response = socket.read<Response>();
                if(succeed = parseResponse(response)) {
                    info = Parser.parse<LentInfo[]>(response.payload);

                    foreach(var i in info) {
                        var key = i.getKey();
                        cache[key] = i;
                    }
                }
                else {
                    info = new LentInfo[0];
                }
            }

            return succeed;
        }
        public bool deleteFromStudentID(in string s_id) {
            using(var socket = new ClientSocket()){
                var incompleteKey = new LentInfoKey(null, s_id);

                socket.write(new Request(token) {
                    requestType = Request.RequestType.DELETE,
                    payloadType = LENT_INFO,
                    payload = Serializer.serialize(incompleteKey)
                });

                var response = socket.read<Response>();
                return parseResponse(response);
            }
        }
    }

    public class LentInfoVT2 : VirtualTable2<LentInfoKey, LentInfo> {
        public bool readFromStudentID(in string s_id, out LentInfo[] info) {
            bool succeed = false;

            using (var socket = new ClientSocket()) {
                var incompleteKey = new LentInfoKey(null, s_id);

                var reqExp = new RequestExpression() {
                    request = READ,
                    table = LENT_INFO
                };
                reqExp.setArg(incompleteKey);

                var request = PacketFactory2.newReplication(_token);
                request.setPayload(reqExp);

                // sent request
                socket.write(request);

                // recv response
                var response = socket.read<Packet2>();
                var resExp = response.getPayload<ResponseExpression>();
                if (succeed = parseResponse(resExp)) {
                    info = resExp.getArg<LentInfo[]>();
                    // memorize it.
                    foreach (var i in info) {
                        var key = i.getKey();
                        cache[key] = i;
                    }
                }
                else {
                    info = new LentInfo[0];
                }
            }

            return succeed;
        }
        public bool deleteFromStudentID(in string s_id) {
            using (var socket = new ClientSocket()) {
                var incompleteKey = new LentInfoKey(null, s_id);

                var reqExp = new RequestExpression() {
                    request = DELETE,
                    table = LENT_INFO
                };
                reqExp.setArg(incompleteKey);

                var request = PacketFactory2.newReplication(_token);
                request.setPayload(reqExp);

                // sent request
                socket.write(request);

                // recv response
                var response = socket.read<Packet2>();
                var resExp = response.getPayload<ResponseExpression>();
                return parseResponse(resExp);
            }
        }
    }
}
