using System;
using System.Collections.Generic;
using System.Diagnostics;
using commons.Network;
using commons.Table;

namespace commons.VirtualDB {
    using static ResponseType;
    using static RequestType;

    public abstract class VirtualTable2<Key, R> where R : InfoBase<Key>, new() {
        private readonly TableType type = new R().type;
        protected Dictionary<Key, R> cache;

        protected int _token = Packet2.GUEST;
        protected int token { get { return _token; } }

        public VirtualTable2() {
            cache = new Dictionary<Key, R>();

            using (var socket = new ClientSocket()) {
                // ping
                socket.write(PacketFactory2.newHello());

                var pong = socket.read<Packet2>();
            }
        }

        ~VirtualTable2() {
            using (var socket = new ClientSocket()) {
                socket.write(PacketFactory2.newDisconnect(_token));

                var recv = socket.read<Packet2>();
            }
        }

        protected static bool parseResponse(in ResponseExpression exp) {
            switch (exp.response) {
            case OK:
                return true;
            case BAD_REQUEST:
                Debug.WriteLine("Bad Request");
                goto default;
                throw new Exception("Bad Request");
            case REJECTED:
                goto default;
            case NOT_FOUND:
                goto default;
            default:
                return false;
            }
        }

        public void signin(in LoginInfo loginInfo) {
            cache = new Dictionary<Key, R>();

            using (var socket = new ClientSocket()) {
                socket.write(PacketFactory.newAuth(loginInfo));

                var resp = socket.read<Packet2>();

                _token = resp.authToken;
            }
        }

        public bool create(in R newItem) {
            bool succeed = false;

            // connect to server
            using (var socket = new ClientSocket()) {
                var reqExp = new RequestExpression() {
                    request = CREATE,
                    table = type
                };
                reqExp.setArg(newItem);

                var request = PacketFactory2.newReplication(_token);
                request.setPayload(reqExp);

                // sent request
                socket.write(request);

                // recv response
                var response = socket.read<Packet2>();
                var resExp = response.getPayload<ResponseExpression>();
                succeed = parseResponse(resExp);
            }

            if (succeed) {
                cache.Add(newItem.getKey(), newItem);
            }

            return succeed;
        }

        public bool createItems(in R[] items) {
            foreach (var item in items) {
                if (!create(item)) {
                    return false;
                }
            }

            return true;
        }

        public virtual bool read(in Key primaryKey, out R item) {
            bool succeed = false;

            if (cache.TryGetValue(primaryKey, out item)) {
                return true;
            }

            // item not found in cache
            // connect to server
            using (var socket = new ClientSocket()) {
                var reqExp = new RequestExpression() {
                    request = READ,
                    table = type
                };
                reqExp.setArg(primaryKey);

                var request = PacketFactory2.newReplication(_token);
                request.setPayload(reqExp);

                // sent request
                socket.write(request);

                // recv response
                var response = socket.read<Packet2>();
                var resExp = response.getPayload<ResponseExpression>();
                if (succeed = parseResponse(resExp)) {
                    item = resExp.getArg<R>();
                    // memorize it.
                    cache.Add(primaryKey, item);
                }
            }

            return succeed;
        }

        public bool readItems(in Key[] keys, out R[] items) {
            int idx = 0;

            R[] tempItems = new R[keys.Length];

            foreach (var key in keys) {
                if (!read(key, out tempItems[idx++])) {
                    items = tempItems;
                    return false;
                }
            }

            items = tempItems;
            return true;
        }

        public bool update(in R item) {
            bool succeed = false;

            // connect to server
            using (var socket = new ClientSocket()) {
                var reqExp = new RequestExpression() {
                    request = UPDATE,
                    table = type
                };
                reqExp.setArg(item);

                var request = PacketFactory2.newReplication(_token);
                request.setPayload(reqExp);

                // sent request
                socket.write(request);

                // recv response
                var response = socket.read<Packet2>();
                var resExp = response.getPayload<ResponseExpression>();
                succeed = parseResponse(resExp);
            }

            if (succeed) {
                cache[item.getKey()] = item;
            }

            return succeed;
        }
        public bool updateItems(in R[] items) {
            foreach (var item in items) {
                if (!update(item)) {
                    return false;
                }
            }

            return true;
        }
        public bool delete(in Key primaryKey) {
            // connect to server
            using (var socket = new ClientSocket()) {
                var reqExp = new RequestExpression() {
                    request = DELETE,
                    table = type
                };
                reqExp.setArg(primaryKey);

                var request = PacketFactory2.newReplication(_token);
                request.setPayload(reqExp);

                // sent request
                socket.write(request);

                // recv response
                var response = socket.read<Packet2>();
                var resExp = response.getPayload<ResponseExpression>();
                return parseResponse(resExp);
            }
        }
        public bool deleteItems(in Key[] keys) {
            foreach (var key in keys) {
                if (!delete(key)) {
                    return false;
                }
            }

            return true;
        }
        public void flush() {
            cache = null;
        }
    };
}
