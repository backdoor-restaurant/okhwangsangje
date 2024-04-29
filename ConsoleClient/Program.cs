using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

using commons;
using commons.Table;

namespace ConsoleClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var socket = new commons.Socket();

                socket.connect();
                Console.WriteLine("Connected");

                var request = new Request();
                request.type = Request.Type.READ;
                request.table = commons.Table.Type.MEMBER_INFO;
                request.Serialize("2020203077");

                Console.WriteLine($"Request: {request}");
                socket.write(request);

                var response = socket.read<Response>();
                Console.WriteLine($"Response: {response}");

                if(response.table == commons.Table.Type.MEMBER_INFO)
                {
                    var memberInfo = response.Deserialize<MemberInfo>();
                    Console.WriteLine($"{memberInfo.department} {memberInfo.name} {memberInfo.studentId} {memberInfo.phoneNumber}");
                }
            }
            catch (SocketException se)
            {
                Console.WriteLine($"Socket Exception: {se}");
            }
        }
    }
}
