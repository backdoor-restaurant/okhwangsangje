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

                var reqExp = new RequestExpression() {
                    request = READ,
                    table = LENT_INFO
                };
                reqExp.setArg(incompleteKey);

                var request = PacketFactory.newReplication(_token);
                request.setPayload(reqExp);

                // sent request
                socket.write(request);

                // recv response
                var response = socket.read<Packet>();
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

                var request = PacketFactory.newReplication(_token);
                request.setPayload(reqExp);

                // sent request
                socket.write(request);

                // recv response
                var response = socket.read<Packet>();
                var resExp = response.getPayload<ResponseExpression>();
                return parseResponse(resExp);
            }
        }
    }
}
