﻿using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace commons
{
    public static class Serializer
    {
        public static byte[] serialize<T>(T obj)
        {
            using (var ms = new MemoryStream(1024))
            {
                (new BinaryFormatter()).Serialize(ms, obj);
                return ms.ToArray();
            }
        }
    }

    public static class Parser
    {
        public static T parse<T>(in byte[] bytes)
        {
            using(var ms = new MemoryStream(1024))
            {
                ms.Write(bytes, 0, bytes.Length);

                return parse<T>(ms);
            }
        }

        public static T parse<T>(in MemoryStream mstream)
        {
            mstream.Position = 0;

            return (T)(new BinaryFormatter()).Deserialize(mstream);
        }
    }

    public static class PacketParser
    {
        public static T parse<T>(Request request)
            => Parser.parse<T>(request.payload);
        public static string parse(Request request)
            => Parser.parse<string>(request.payload);
        public static T parse<T>(Response response)
            => Parser.parse<T>(response.payload);
    }
}