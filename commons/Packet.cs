using System;

using commons.Table;

namespace commons
{
    [Serializable]
    public class Packet
    {
        public Table.Type table;
        
        public byte[] payload;
    }

    [Serializable]
    public class Request : Packet
    {
        public enum Type
        {
            CREATE,
            READ,
            UPDATE,
            DELETE
        }
        public Type type;

        public override string ToString()
        {
            return $"{type} {table} primary_key={PacketParser.parse(this)}";
        }
    }
    [Serializable]
    public class Response : Packet
    {
        public enum Type
        {
            OK,
            NOT_FOUND,
            BAD_REQUEST,
            REJECTED
        }
        public Type type;

        public override string ToString()
        {
            var result = $"{type} {table} ";
            switch (table)
            {
                case Table.Type.MEMBER_INFO:
                    return result + PacketParser.parse<MemberInfo>(this);
                default:
                    return result;
            }
        }
    }
}
