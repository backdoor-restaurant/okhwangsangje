using commons.Table;
using System;

namespace commons.Network {
    public enum ResponseType {
        // 작업 성공
        OK,
        // (구문 오류) 해당 작업 불가.
        NOT_ACCEPTED,
        // (R, U, D)에서 해당 row를 찾을 수 없음.
        NOT_FOUND,
        // (패킷 오류) 해당 작업 불가.
        BAD_REQUEST,
        // 해당 작업에 대한 권한 없음.
        REJECTED,
        // 아직 구현되지 않음.
        NOT_IMPLEMENTED
    }

    [Serializable]
    public class ResponseExpression {
        public ResponseType response;
        private byte[] argument = null;

        public void setArg<T>(in T t)
            => argument = Serializer.serialize(t);
        public T getArg<T>()
            => Parser.parse<T>(argument);
    }
}
