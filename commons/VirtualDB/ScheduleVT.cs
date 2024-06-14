using commons.Network;
using commons.Table;

namespace commons.VirtualDB {
    using static Request.RequestType;
    using static Table.Type;

    public class ScheduleVT : VirtualTable<ScheduleInfoKey, ScheduleInfo> {
        public bool readFromDate(in string date, out ScheduleInfo[] schedules) {
            bool succeed = false;

            using (var socket = new ClientSocket()) {
                var incompleteKey = new ScheduleInfoKey(date, null);

                socket.write(new Request(token) {
                    requestType = READ,
                    payloadType = SCHEDULE_INFO,
                    payload = Serializer.serialize(incompleteKey)
                });

                var response = socket.read<Response>();
                if(succeed = parseResponse(response)) {
                    schedules = Parser.parse<ScheduleInfo[]>(response.payload);

                    foreach(var schedule in schedules) {
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

                socket.write(new Request(token) {
                    requestType = DELETE,
                    payloadType = SCHEDULE_INFO,
                    payload = Serializer.serialize(incompleteKey)
                });

                var response = socket.read<Response>();
                return parseResponse(response);
            }
        }
    }
}
