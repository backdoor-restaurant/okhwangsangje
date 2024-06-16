namespace commons.Network {
    using static Packet.PacketType;

    public static class PacketFactory {
        public static Packet newHello() {
            return new Packet(Packet.GUEST) {
                packetType = Hello
            };
        }

        public static Packet newAuth(in Table.LoginInfo login) {
            return new Packet(Packet.GUEST) {
                packetType = Auth,
                payload = Serializer.serialize(login)
            };
        }

        public static Packet newReplication(in int authToken) {
            return new Packet(authToken) {
                packetType = Replication,
            };
        }

        public static Packet newDisconnect(in int authToken) {
            return new Packet(authToken) {
                packetType = Disconnect,
            };
        }
    }
}
