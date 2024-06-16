using commons.Table;
using System;

namespace commons.Network {
    public enum RequestType {
        CREATE,
        READ,
        UPDATE,
        DELETE
    }

    [Serializable]
    public class RequestExpression {
        public RequestType request;
        public TableType table;
        private byte[] argument = null;

        public void setArg<T>(in T t)
            => argument = Serializer.serialize(t);
        public T getArg<T>()
            => Parser.parse<T>(argument);
    }
}
