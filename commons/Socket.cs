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

        public void listen(in int port=49152)
        {
            try
            {
                if(listener == null)
                {
                    listener = new TcpListener(IPAddress.Parse("127.0.0.1"), port);
                    listener.Start();
                }

                Console.WriteLine("Waiting...");
                client = listener.AcceptTcpClient();

                Console.WriteLine("Connected.");
                nstream = client.GetStream();
            }
            catch(Exception e)
            {
                nstream.Close();
                client.Close();
                listener.Stop();

                throw e;
            }
        }

        public void connect(in string ip="127.0.0.1", in int port=49152)
        {
            try
            {
                Console.WriteLine("Connecting...");
                client = new TcpClient(ip, port);

                Console.WriteLine("Connected.");
                nstream = client.GetStream();
            }
            catch(Exception e)
            {
                nstream.Close();
                client.Close();

                throw e;
            }
        }

        public T read<T>()
        {
            using(var ms = new MemoryStream(1024))
            {
                byte[] buffer = new byte[1024];

                do
                {
                    int bytesRead = nstream.Read(buffer, 0, buffer.Length);
                    ms.Write(buffer, 0, bytesRead);
                } while (nstream.DataAvailable);

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
            nstream.Close();
            client.Dispose();
            client.Close();
            nstream = null;
            client = null;
        }
    }
}
