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
    public sealed class ChatModule
    {
        private static TcpClient client = null;
        private static NetworkStream stream = null;
        private static StreamWriter writer  = null;
        private static StreamReader reader  = null;

        private ChatModule() { }

        private static ChatModule _chatModule = null;

        public static ChatModule GetChatModule()
        {
            if(_chatModule == null)
            {
                _chatModule = new ChatModule();
                Connect();
            }
            return _chatModule;
        }

        public static void Connect()
        {
            if(client == null)
            {
                client = new TcpClient();
                client.Connect(Definition.SERVER_IP, Definition.SERVER_PORT);
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
            DataTable dt = null;
        }

        public static void MessageTransfer(string message)
        {
            writer.WriteLineAsync(message);
        }
    }
}
