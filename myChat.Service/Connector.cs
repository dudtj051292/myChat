using myChat;
using myChatClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace myChat.Service
{
    public sealed class Connector
    {
        private static TcpClient client = null;
        private static NetworkStream stream = null;
        private static StreamWriter writer = null;
        private static StreamReader reader = null;

        // 커넥터는 초기 생성시 was와 연결한다.
        private Connector() { }
        private static readonly Lazy<Connector> _Connector = new Lazy<Connector>(() => new Connector());

        public static Connector GetChatModule
        {
            get { return _Connector.Value; }
        }

        public static LOGIN_STATUS Login(string sabun, string pw, string ip)
        {
            if (client != null && client.Connected)
            {

            }
            else
            {
                Connect(sabun, pw, ip);
            }
            return LoginModule.Login(sabun, pw, ip);
        }
        public static void Connect(string sabun, string pw, string ip)
        {
            //서버에 연결! Connector 클래스가 생성될때 생성되도록 한다.
            if (client == null || client.Connected == false)
            {
                client = new TcpClient();
                client.Connect(ip, Definition.SERVER_PORT);
            }
            stream = client.GetStream();

            writer = new StreamWriter(stream)
            {
                AutoFlush = true
            };

            reader = new StreamReader(stream, Definition.encoder);

        }
        public static void DataTransfer(string message)
        {
            writer.WriteLineAsync(message);
        }

        public static void MessageTransfer(string message)
        {
            writer.WriteLineAsync(message);
        }
    }
}
