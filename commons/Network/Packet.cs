using System;

namespace commons.Network {
    [Serializable]
    public class Packet2 {
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
        public byte[] payload = null;

        public Packet2(in int token) {
            authToken = token;
        }
        public void setPayload<T>(in T t)
            => payload = Serializer.serialize(t);
        public T getPayload<T>()
            => Parser.parse<T>(payload);
        public override string ToString() {
            return $"{packetType} {authToken}";
        }
    }
}
