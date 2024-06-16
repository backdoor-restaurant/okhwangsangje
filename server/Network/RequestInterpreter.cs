using commons.Network;
using commons.Table;
using System;

namespace server.Network {
    using static RequestType;
    using static TableType;

    internal static class RequestInterpreter {
        internal static object interpret(in RequestExpression exp) {
            switch (exp.request) {
            case CREATE:
            case UPDATE:
                switch (exp.table) {
                case MEMBER_INFO:
                    return exp.getArg<MemberInfo>();
                case ITEM_INFO:
                    return exp.getArg<ItemInfo>();
                case LOGIN_INFO:
                    return exp.getArg<LoginInfo>();
                case RENT_INFO:
                    return exp.getArg<RentInfo>();
                case SCHEDULE_INFO:
                    return exp.getArg<ScheduleInfo>();
                default:
                    throw new NotImplementedException();
                }
            case READ:
            case DELETE:
                switch (exp.table) {
                case MEMBER_INFO:
                    return exp.getArg<MemberInfoKey>();
                case ITEM_INFO:
                    return exp.getArg<ItemInfoKey>();
                case LOGIN_INFO:
                    return exp.getArg<LoginInfoKey>();
                case RENT_INFO:
                    return exp.getArg<RentInfoKey>();
                case SCHEDULE_INFO:
                    return exp.getArg<ScheduleInfoKey>();
                default:
                    throw new NotImplementedException();
                }
            default:
                throw new NotImplementedException();
            }
        }
    }
}
