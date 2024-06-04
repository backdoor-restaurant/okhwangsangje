using commons.Network;
using commons.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace commons.VirtualDB {
    using static Request.RequestType;
    using static Table.Type;

    public class LentInfoVT : VirtualTable<LentInfoKey, LentInfo> {
        public bool readFromStudentID(in string s_id, out LentInfo[] info) {
            bool succeed = false;

            using (var socket = new ClientSocket()) {
                var incompleteKey = new LentInfoKey(null, s_id);

                socket.write(new Request(token) {
                    requestType = READ,
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
                    requestType = DELETE,
                    payloadType = LENT_INFO,
                    payload = Serializer.serialize(incompleteKey)
                });

                var response = socket.read<Response>();
                return parseResponse(response);
            }
        }
    }
}
