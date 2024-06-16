﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using commons.Network;
using commons.Table;

namespace commons.VirtualDB {
    public abstract class VirtualTable<Key, R> where R : InfoBase<Key>, new() {
        private readonly TableType type = new R().type;
        protected Dictionary<Key, R> cache;

        private int _token = Packet.GUEST;
        protected int token { get { return _token; } }

        public VirtualTable() {
            cache = new Dictionary<Key, R>();

            using (var socket = new ClientSocket()) {
                // ping
                socket.write(PacketFactory.newHello());

                var pong = socket.read<Packet>();
            }
        }

        ~VirtualTable() {
            using (var socket = new ClientSocket()) {
                socket.write(PacketFactory.newDisconnect(_token));

                var recv = socket.read<Packet>();
            }
        }

        protected static bool parseResponse(in Response response) {
            switch (response.responseType) {
            case Response.ResponseType.OK:
                return true;
            case Response.ResponseType.BAD_REQUEST:
                Debug.WriteLine("Bad Request");
                goto default;
                throw new Exception("Bad Request");
            case Response.ResponseType.REJECTED:
                goto default;
            case Response.ResponseType.NOT_FOUND:
                goto default;
            default:
                return false;
            }
        }

        public void signin(in LoginInfo loginInfo) {
            cache = new Dictionary<Key, R>();

            using (var socket = new ClientSocket()) {
                socket.write(PacketFactory.newAuth(loginInfo));

                var resp = socket.read<Packet>();

                _token = resp.authToken;
            }
        }

        public bool create(in R newItem) {
            bool succeed = false;

            // connect to server
            using (var socket = new ClientSocket()) {
                // sent request
                socket.write(new Request(_token) {
                    requestType = Request.RequestType.CREATE,
                    payloadType = type,
                    payload = Serializer.serialize(newItem)
                });

                // recv response
                var response = socket.read<Response>();
                succeed = parseResponse(response);
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
                // send request
                socket.write(new Request(_token) {
                    requestType = Request.RequestType.READ,
                    payloadType = type,
                    payload = Serializer.serialize(primaryKey)
                });

                // receive response
                var response = socket.read<Response>();
                if (succeed = parseResponse(response)) {
                    item = Parser.parse<R>(response.payload);
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
                // send request
                socket.write(new Request(_token) {
                    requestType = Request.RequestType.UPDATE,
                    payloadType = type,
                    payload = Serializer.serialize(item)
                });

                // receive response
                var response = socket.read<Response>();
                succeed = parseResponse(response);
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
                // send request
                socket.write(new Request(_token) {
                    requestType = Request.RequestType.DELETE,
                    payloadType = type,
                    payload = Serializer.serialize(primaryKey)
                });

                // receive response
                var response = socket.read<Response>();
                return parseResponse(response);
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
