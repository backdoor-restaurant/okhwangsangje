using System;

using commons.Table;

namespace commons.Network
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
            string result = $"{type} {table} ";

            switch (type)
            {
                case Type.CREATE:
                    switch (table)
                    {
                        case Table.Type.MEMBER_INFO:
                            return result + PacketParser.parse<MemberInfo>(this);
                        default:
                            return result;
                    }
                case Type.READ:
                    return result + PacketParser.parse(this);
                default:
                    return result;
            }
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
            var result = $"{type} {table}";

            switch (type)
            {
                case Type.OK:
                    switch (table)
                    {
                        case Table.Type.MEMBER_INFO:
                            return $"{result} primary_key={PacketParser.parse<MemberInfo>(this)}";
                        default:
                            return result;
                    }
                default:
                    return result;
            }
        }
    }
}
