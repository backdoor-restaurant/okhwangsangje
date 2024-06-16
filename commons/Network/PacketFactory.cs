namespace commons.Network
{   
    public static class PacketFactory
    {
        public static Packet newHello()
        {
            return new Packet(Packet.GUEST)
            {
                packetType = Packet.PacketType.Hello
            };
        }

        public static Packet newAuth(in Table.LoginInfo login)
        {
            return new Packet(Packet.GUEST)
            {
                packetType = Packet.PacketType.Auth,
                payloadType = Table.TableType.LOGIN_INFO,
                payload = Serializer.serialize(login)
            };
        }

        public static Packet newDisconnect(in int authToken)
        {
            return new Packet(authToken)
            {
                packetType = Packet.PacketType.Disconnect,
                authToken = authToken
            };
        }
    }
}
