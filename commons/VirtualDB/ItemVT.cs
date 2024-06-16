using commons.Network;
using commons.Table;

namespace commons.VirtualDB {
    using static Table.TableType;
    using static RequestType;

    public class ItemVT : VirtualTable<ItemInfoKey, ItemInfo>{
        public bool readAll(out ItemInfo[] items) {
            bool succeed = false;

            using (var socket = new ClientSocket()) {
                var incompleteKey = new ItemInfoKey((string)null);

                var reqExp = new RequestExpression() {
                    request = READ,
                    table = ITEM_INFO
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
                    items = resExp.getArg<ItemInfo[]>();
                    // memorize it.
                    foreach (var item in items) {
                        var key = item.getKey();
                        cache[key] = item;
                    }
                }
                else {
                    items = new ItemInfo[0];
                }
            }

            return succeed;
        }
    }
}
