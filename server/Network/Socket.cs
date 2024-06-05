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

        public void listen() {
            try {
                client = listener.AcceptTcpClient();
                nstream = client.GetStream();
            }
            catch (Exception e) {
                nstream.Close();
                client.Close();
                listener.Stop();

                throw e;
            }
        }

        public async Task<T> readAsync<T>(){
            client = await listener.AcceptTcpClientAsync();
            nstream = client.GetStream();

            return read<T>();
        }

        public void Dispose() => disconnect();
    }
}
