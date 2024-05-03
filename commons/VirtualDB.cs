using System;
using System.Collections.Generic;

using commons.Table;

namespace commons.VirtualDB
{
    public class VirtualDatabase<Key, T> where T : InfoBase, new()
    {
        private readonly commons.Table.Type type = (new T()).type;
        protected Dictionary<Key, T> cache;

        private static bool parseResponse(in Response response)
        {
            switch(response.type)
            {
                case Response.Type.OK:
                    return true;
                case Response.Type.BAD_REQUEST:
                    throw new Exception("Bad Request");
                case Response.Type.REJECTED:
                    goto default;
                case Response.Type.NOT_FOUND:
                    goto default;
                default:
                    return false;
            }
        }

        public bool create(in T newItem)
        {
            // connect to server
            using (var socket = new ClientSocket())
            {
                // sent request
                socket.write(new Request()
                {
                    type = Request.Type.CREATE,
                    table = type,
                    payload = Serializer.serialize(newItem)
                });

                // recv response
                var response = socket.read<Response>();
                return parseResponse(response);
            }
        }

        public bool createItems(in T[] items)
        {
            throw new NotImplementedException();
        }

        public bool read(in Key primaryKey, out T item)
        {
            // connect to server
            using (var socket = new ClientSocket())
            {
                // send request
                socket.write(new Request()
                {
                    type = Request.Type.READ,
                    table = type,
                    payload = Serializer.serialize(primaryKey)
                });

                // receive response
                var response = socket.read<Response>();
                if(response.type == Response.Type.OK)
                {
                    item = PacketParser.parse<T>(response);
                }
                else
                {
                    item = null;
                }
                return parseResponse(response);
            }
        }

        public bool readItems(in Key[] keys, out T[] items)
        {
            throw new NotImplementedException();
        }

        public bool update(in T item)
        {
            // connect to server
            using (var socket = new ClientSocket())
            {
                // send request
                socket.write(new Request()
                {
                    type = Request.Type.UPDATE,
                    table = type,
                    payload = Serializer.serialize(item)
                });

                // receive response
                var response = socket.read<Response>();
                return parseResponse(response);
            }
        }
        public bool updateItems(in T[] items)
        {
            throw new NotImplementedException();
        }
        public bool delete(in Key primaryKey)
        {
            // connect to server
            using (var socket = new ClientSocket())
            {
                // send request
                socket.write(new Request()
                {
                    type = Request.Type.DELETE,
                    table = type,
                    payload = Serializer.serialize(primaryKey)
                });

                // receive response
                var response = socket.read<Response>();
                return parseResponse(response);
            }
        }
        public bool deleteItems(in Key[] keys)
        {
            throw new NotImplementedException();
        }
        public bool sync()
        {
            throw new NotImplementedException();
        }
    };
}
