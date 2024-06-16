using commons.Network;
using commons.Table;

namespace commons.VirtualDB {
    using static Table.TableType;
    using static RequestType;

    public class ScheduleVT : VirtualTable<ScheduleInfoKey, ScheduleInfo> {
        public bool readFromDate(in string date, out ScheduleInfo[] schedules) {
            bool succeed = false;

            using (var socket = new ClientSocket()) {
                var incompleteKey = new ScheduleInfoKey(date, null);

                var reqExp = new RequestExpression() {
                    request = READ,
                    table = SCHEDULE_INFO
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
                    schedules = resExp.getArg<ScheduleInfo[]>();
                    // memorize it.
                    foreach (var schedule in schedules) {
                        var key = schedule.getKey();
                        cache[key] = schedule;
                    }
                }
                else {
                    schedules = new ScheduleInfo[0];
                }
            }

            return succeed;
        }
        public bool deleteFromDate(in string date) {
            using (var socket = new ClientSocket()) {
                var incompleteKey = new ScheduleInfoKey(date, null);

                var reqExp = new RequestExpression() {
                    request = DELETE,
                    table = SCHEDULE_INFO
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
