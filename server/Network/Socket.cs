using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace server.Network {
    internal class ServerSocket : commons.Network.Socket, IDisposable {
        private readonly TcpListener listener;

        public ServerSocket() {
            listener = new TcpListener(IPAddress.Parse(defaultIp), defaultPort);
            listener.Start();
        }

        public async Task listen() {
            client = await listener.AcceptTcpClientAsync();
            nstream = client.GetStream();
        }

        public void Dispose() => disconnect();
    }
}
