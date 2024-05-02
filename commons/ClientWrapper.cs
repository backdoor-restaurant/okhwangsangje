using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using commons.Table;

namespace commons.VirtualDB
{
    public abstract class VirtualDatabase<Key, T>
    {
        protected Dictionary<Key, T> cache;

        public abstract bool create(in T item);
        public abstract bool createItems(in T[] items);
        public abstract T read(in Key primaryKey);
        public abstract T[] readItems(in Key[] keys);
        public abstract bool update(in T item);
        public abstract bool updateItems(in T[] items);
        public abstract bool delete(in Key primaryKey);
        public abstract bool deleteItems(in Key[] keys);
        public abstract bool sync();
    };
    
    public static class ClientWrapper
    {
        public static bool createMemberInfo(in MemberInfo newMember)
        {
            // connect to server
            using (var socket = new ClientSocket())
            {
                // sent request
                socket.write(new Request()
                {
                    type = Request.Type.CREATE,
                    table = Table.Type.MEMBER_INFO,
                    payload = Serializer.serialize(newMember)
                });

                // recv response
                var response = socket.read<Response>();

                // parse response
                switch(response.type)
                {
                    case Response.Type.OK:
                        return true;
                    default:
                        return false;
                }
            }
        }

        public static MemberInfo readMemberInfo(in string studentId)
        {
            // connect to server
            using(var socket = new ClientSocket())
            {
                // send request
                socket.write(new Request()
                {
                    type = Request.Type.READ,
                    table = commons.Table.Type.MEMBER_INFO,
                    payload = Serializer.serialize(studentId)
                });
                
                // receive response
                var response = socket.read<Response>();

                // parse response
                switch (response.type)
                {
                    case Response.Type.OK:
                        return PacketParser.parse<MemberInfo>(response);
                    case Response.Type.BAD_REQUEST:
                        throw new Exception("BAD_REQUEST");
                    default:
                        return null;
                }
            }
        }

        public static bool updateMemberInfo(in string studentId, in MemberInfo updated)
        {
            return false;
        }

        public static bool deleteMemberInfo(in string studentId)
        {
            return false;
        }

        // Schedule Info
        public static bool createSchedule(in ScheduleInfo scheduleInfo)
        {
            return false;
        }

        public static ScheduleInfo readSchedule(in string scheduleId)
        {
            return null;
        }

        public static ScheduleInfo[] readSchedules(in string date)
        {
            return null;
        }

        public static ScheduleInfo[] readAllSchedule()
        {
            return null;
        }

        public static bool updateSchdeule(in string scheduleId, in ScheduleInfo newSchedule)
        {
            return false;
        }

        public static bool deleteSchedule(in string scheduleId)
        {
            return false;
        }
    }
}
