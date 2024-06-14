using System;
using System.IO;
using System.Net.Sockets;

namespace commons.Network {
    public class Socket {
        protected const string defaultIp = "127.0.0.1";
        protected const int defaultPort = 49152;

        protected TcpClient client = null;
        protected NetworkStream nstream = null;

        public T read<T>() {
            using (var ms = new MemoryStream()) {
                byte[] buffer = new byte[1024];
                
                do {
                    nstream.Read(buffer, 0, buffer.Length);
                    ms.Write(buffer, 0, buffer.Length);
                } while (nstream.DataAvailable);

                return Parser.parse<T>(ms);
            }
        }

        public void write<T>(in T obj) {
            var bytes = Serializer.serialize(obj);

            nstream.Write(bytes, 0, bytes.Length);
        }

        public void disconnect() {
            nstream?.Close();
            nstream = null;
            client?.Close();
            client = null;
        }
    }

    public class ClientSocket : Socket, IDisposable {
        public ClientSocket(string ip = defaultIp, int port = defaultPort) {
            client = new TcpClient(ip, port);
            nstream = client.GetStream();
        }
        public void Dispose() => disconnect();
    }
}
