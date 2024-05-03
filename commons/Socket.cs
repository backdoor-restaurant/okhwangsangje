using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices.ComTypes;

namespace commons
{    public class Socket
    {
        protected const string defaultIp = "127.0.0.1";
        protected const int defaultPort = 49152;

        protected TcpClient client = null;
        protected NetworkStream nstream = null;

        public T read<T>()
        {
            using(var ms = new MemoryStream(1024))
            { 
                do
                {
                    byte[] buffer = new byte[1024];
                    
                    nstream.Read(buffer, 0, buffer.Length);
                    ms.Write(buffer, 0, buffer.Length);
                } while (nstream.DataAvailable);
                
                return Parser.parse<T>(ms);
            }
        }

        public void write<T>(in T obj)
        {
            var bytes = Serializer.serialize(obj);

            nstream.Write(bytes, 0, bytes.Length);
        }

        public void disconnect()
        {
            nstream.Flush();
            nstream.Close();
            client.Dispose();
            client.Close();
            nstream = null;
            client = null;
        }
    }

    public class ClientSocket: Socket, IDisposable
    {
        public ClientSocket(string ip = defaultIp, int port = defaultPort)
        {
            try
            {
                client = new TcpClient(ip, port);
                nstream = client.GetStream();
            }
            catch (Exception e)
            {
                nstream.Close();
                client.Close();

                throw e;
            }
        }
        public void Dispose() => disconnect();
    }

    public class ServerSocket: Socket, IDisposable
    {
        private readonly TcpListener listener;

        public ServerSocket()
        {
            listener = new TcpListener(IPAddress.Parse(defaultIp), defaultPort);
            listener.Start();
        }

        public void listen()
        {
            try
            {
                client = listener.AcceptTcpClient();
                nstream = client.GetStream();
            }
            catch (Exception e)
            {
                nstream.Close();
                client.Close();
                listener.Stop();

                throw e;
            }
        }

        public void Dispose() => disconnect();
    }
}
