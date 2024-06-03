using commons.Network;
using commons.Table;
using System;
using System.Linq;
using System.Runtime.CompilerServices;

namespace commons.VirtualDB {
    public class ScheduleVT : VirtualTable<ScheduleInfoKey, ScheduleInfo> {
        public bool readFromDate(string date, out ScheduleInfo[] schedules) {
            bool succeed = false;

            using (var socket = new ClientSocket()) {
                var incompleteKey = new ScheduleInfoKey(date, null);

                socket.write(new Request(token) {
                    requestType = Request.RequestType.READ,
                    payloadType = Table.Type.SCHEDULE_INFO,
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
            throw new NotImplementedException();
        }
    }
}
