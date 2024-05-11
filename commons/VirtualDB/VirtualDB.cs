using System;
using System.Collections.Generic;
using commons.Network;
using commons.Table;

namespace commons.VirtualDB
{
    public class VirtualDatabase<Key, T> where T : InfoBase<Key>, new()
    {
        private readonly Table.Type type = (new T()).type;
        protected Dictionary<Key, T> cache;

        private uint token = Packet.GUEST;

        public VirtualDatabase()
        {
            cache = new Dictionary<Key, T>();

            using (var socket = new ClientSocket())
            {
                // ping
                socket.write(PacketFactory.newHello());

                var pong = socket.read<Packet>();
            }
        }

        ~VirtualDatabase()
        {
            throw new NotImplementedException();
        }

        private static bool parseResponse(in Response response)
        {
            switch(response.type)
            {
                case Response.ResponseType.OK:
                    return true;
                case Response.ResponseType.BAD_REQUEST:
                    throw new Exception("Bad Request");
                case Response.ResponseType.REJECTED:
                    goto default;
                case Response.ResponseType.NOT_FOUND:
                    goto default;
                default:
                    return false;
            }
        }

        public void signin(in LoginInfo loginInfo)
        {
            cache = new Dictionary<Key, T>();

            using (var socket = new ClientSocket())
            {
                socket.write(PacketFactory.newAuth(loginInfo));

                var resp = socket.read<Packet>();

                token = resp.authToken;
            }
        }

        public bool create(in T newItem)
        {
            bool succeed = false;

            // connect to server
            using (var socket = new ClientSocket())
            {
                // sent request
                socket.write(new Request(token)
                {
                    requestType = Request.RequestType.CREATE,
                    payloadType = type,
                    payload = Serializer.serialize(newItem)
                });

                // recv response
                var response = socket.read<Response>();
                succeed = parseResponse(response);
            }

            if (succeed)
            {
                cache.Add(newItem.getKey(), newItem);
            }

            return succeed;
        }

        public bool createItems(in T[] items)
        {
            foreach (var item in items)
            {
                if (!create(item))
                {
                    return false;
                }
            }

            return true;
        }

        public bool read(in Key primaryKey, out T item)
        {
            bool succeed = false;

            if(cache.TryGetValue(primaryKey, out item))
            {
                return true;
            }

            Console.WriteLine("Hello");

            // item not found in cache
            // connect to server
            using (var socket = new ClientSocket())
            {
                // send request
                socket.write(new Request(token)
                {
                    requestType = Request.RequestType.READ,
                    payloadType = type,
                    payload = Serializer.serialize(primaryKey)
                });

                // receive response
                var response = socket.read<Response>();
                if((succeed=parseResponse(response)))
                {
                    item = PacketParser.parse<T>(response);
                }
            }

            // memorize it.
            if (succeed)
            {
                cache.Add(primaryKey, item);
            }

            return succeed;
        }

        public bool readItems(in Key[] keys, out T[] items)
        {
            int idx = 0;

            T[] tempItems = new T[keys.Length];

            foreach (var key in keys)
            {
                if (!read(key, out tempItems[idx++]))
                {
                    items = tempItems;
                    return false;
                }
            }

            items = tempItems;
            return true;
        }

        public bool update(in T item)
        {
            bool succeed = false;

            // connect to server
            using (var socket = new ClientSocket())
            {
                // send request
                socket.write(new Request(token)
                {
                    requestType = Request.RequestType.UPDATE,
                    payloadType = type,
                    payload = Serializer.serialize(item)
                });

                // receive response
                var response = socket.read<Response>();
                succeed = parseResponse(response);
            }

            if (succeed)
            {
                cache[item.getKey()] = item;
            }

            return succeed;
        }
        public bool updateItems(in T[] items)
        {
            foreach (var item in items)
            {
                if (!update(item))
                {
                    return false;
                }
            }

            return true;
        }
        public bool delete(in Key primaryKey)
        {
            // connect to server
            using (var socket = new ClientSocket())
            {
                // send request
                socket.write(new Request(token)
                {
                    requestType = Request.RequestType.DELETE,
                    payloadType = type,
                    payload = Serializer.serialize(primaryKey)
                });

                // receive response
                var response = socket.read<Response>();
                return parseResponse(response);
            }
        }
        public bool deleteItems(in Key[] keys)
        {
            foreach (var key in keys)
            {
                if (!delete(key))
                {
                    return false;
                }
            }

            return true;
        }
        public void flush()
        {
            cache = null;
        }
    };
}
