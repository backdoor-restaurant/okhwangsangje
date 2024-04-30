using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace commons
{
    [Serializable]
    public class Packet
    {
        public Table.Type table;
        
        int payloadLength;
        byte[] payload;

        public void Serialize<T>(T obj)
        {
            using (var ms = new MemoryStream(1024))
            {
                (new BinaryFormatter()).Serialize(ms, obj);
                payload = ms.ToArray();
                payloadLength = payload.Length;
            }
        }

        public T Deserialize<T>()
        {
            using(var ms = new MemoryStream(1024))
            {
                ms.Write(payload, 0, payloadLength);
                ms.Position = 0;

                return (T)(new BinaryFormatter()).Deserialize(ms);
            }
        }
    }

    [Serializable]
    public class Request : Packet
    {
        public enum Type
        {
            CREATE,
            READ,
            UPDATE,
            DELETE
        }
        public Type type;
    }
    [Serializable]
    public class Response : Packet
    {
        public enum Type
        {
            OK,
            NOT_FOUND,
            BAD_REQUEST,
            REJECTED
        }
        public Type type;
    }
}
