using System;

namespace commons.Network {
    [Serializable]
    public class Packet {
        // packet header
        public enum PacketType {
            Hello,
            Auth,
            Replication,
            Disconnect
        }
        public PacketType packetType;

        public const int GUEST = 0;
        public int authToken = GUEST;

        // packet body
        public Table.Type payloadType;
        public byte[] payload = null;

        public Packet(in int token) {
            authToken = token;
        }
        public override string ToString() {
            return $"{packetType} {authToken}";
        }
    }

    [Serializable]
    public class Request : Packet {
        public enum RequestType {
            CREATE,
            READ,
            UPDATE,
            DELETE
        }
        public RequestType requestType;

        public Request(in int token) : base(token) {
            packetType = PacketType.Replication;
        }
        public override string ToString() {
            string result = $"{requestType} {payloadType} ";

            if (payload is null) return result;

            switch (requestType) {
            case RequestType.CREATE:
                switch (payloadType) {
                case Table.Type.MEMBER_INFO:
                    return result + Parser.parse<Table.MemberInfo>(payload);
                default:
                    return result;
                }
            case RequestType.READ:
                return result + Parser.parse<string>(payload);
            default:
                return result;
            }
        }
    }

    [Serializable]
    public class Response : Packet {
        public enum ResponseType {
            OK,
            NOT_FOUND,
            BAD_REQUEST,
            REJECTED
        }
        public ResponseType responseType;

        public Response(in int token) : base(token) {
            packetType = PacketType.Replication;
        }
        public override string ToString() {
            var result = $"{responseType} {payloadType}";

            if (payload is null) return result;

            switch (responseType) {
            case ResponseType.OK:
                switch (payloadType) {
                case Table.Type.MEMBER_INFO:
                    return $"{result} primary_key={Parser.parse<Table.MemberInfo>(payload)}";
                default:
                    return result;
                }
            default:
                return result;
            }
        }
    }
}
