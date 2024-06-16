namespace commons.Network {
    using static Packet2.PacketType;

    public static class PacketFactory2 {
        public static Packet2 newHello() {
            return new Packet2(Packet2.GUEST) {
                packetType = Hello
            };
        }

        public static Packet2 newAuth(in Table.LoginInfo login) {
            return new Packet2(Packet2.GUEST) {
                packetType = Auth,
                payload = Serializer.serialize(login)
            };
        }

        public static Packet2 newReplication(in int authToken) {
            return new Packet2(authToken) {
                packetType = Replication,
            };
        }

        public static Packet2 newDisconnect(in int authToken) {
            return new Packet2(authToken) {
                packetType = Disconnect,
            };
        }
    }
}
