using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;

namespace commons
{    public class Socket
    {
        private TcpListener listener = null;
        private TcpClient client = null;
        private NetworkStream nstream = null;

        public void connect(in string ip="127.0.0.1", in int port=49152)
        {
            client = new TcpClient();
            client.Connect(IPAddress.Parse(ip), port);

            nstream = client.GetStream();
        }

        public void listen(in int port=49152)
        {
            if(listener == null)
            {
                listener = new TcpListener(IPAddress.Parse("127.0.0.1"), port);
                listener.Start();
            }

            client = listener.AcceptTcpClient();

            nstream = client.GetStream();
        }

        public T read<T>()
        {
            using(var ms = new MemoryStream(1024))
            {
                byte[] buffer = new byte[1024];

                int bytesRead;
                do
                {
                    bytesRead = nstream.Read(buffer, 0, buffer.Length);
                    ms.Write(buffer, 0, bytesRead);
                } while (bytesRead == buffer.Length);

                ms.Position = 0;
                
                return (T)(new BinaryFormatter()).Deserialize(ms);
            }
        }

        public void write<T>(in T obj)
        {
            using (var ms = new MemoryStream(1024))
            {
                (new BinaryFormatter()).Serialize(ms, obj);

                byte[] buffer = ms.ToArray();

                nstream.Write(buffer, 0, buffer.Length);
            }
        }

        public void disconnect()
        {
            nstream.Flush();
            client.Dispose();
            client.Close();
            nstream = null;
            client = null;
        }
    }
}
