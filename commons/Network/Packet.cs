using System;

namespace commons.Network
{
    [Serializable]
    public class Packet
    {
        // packet header
        public enum PacketType
        {
            Hello,
            Auth,
            Replication,
            Disconnect
        }
        public PacketType packetType;

        public const uint GUEST = 0;
        public uint authToken = GUEST;

        // packet body
        public Table.Type payloadType;
        public byte[] payload = null;

        public Packet(in uint token)
        {
            authToken = token;
        }
        public override string ToString()
        {
            return $"{packetType} {authToken}";
        }
    }

    [Serializable]
    public class Request : Packet
    {
        public enum RequestType
        {
            CREATE,
            READ,
            UPDATE,
            DELETE
        }
        public RequestType requestType;

        public Request(in uint token) : base(token)
        {
            packetType = PacketType.Replication;
        }
        public override string ToString()
        {
            string result = $"{requestType} {payloadType} ";

            switch (requestType)
            {
                case RequestType.CREATE:
                    switch (payloadType)
                    {
                        case Table.Type.MEMBER_INFO:
                            return result + PacketParser.parse<Table.MemberInfo>(this);
                        default:
                            return result;
                    }
                case RequestType.READ:
                    return result + PacketParser.parse(this);
                default:
                    return result;
            }
        }
    }

    [Serializable]
    public class Response : Packet
    {
        public enum ResponseType
        {
            OK,
            NOT_FOUND,
            BAD_REQUEST,
            REJECTED
        }
        public ResponseType type;

        public Response(in uint token) : base(token)
        {
            packetType = PacketType.Replication;
        }
        public override string ToString()
        {
            var result = $"{type} {payloadType}";

            switch (type)
            {
                case ResponseType.OK:
                    switch (payloadType)
                    {
                        case Table.Type.MEMBER_INFO:
                            return $"{result} primary_key={PacketParser.parse<Table.MemberInfo>(this)}";
                        default:
                            return result;
                    }
                default:
                    return result;
            }
        }
    }
}
