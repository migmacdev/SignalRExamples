using Microsoft.AspNet.SignalR.Client;
using StrongTypedClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatClientStrongTyped
{
    class Program
    {
        static void Main(string[] args)
        {
            IHubProxy _hub;
            string url = @"http://localhost:8080/";
            string userName;

            var connection = new HubConnection(url);
            _hub = connection.CreateHubProxy("ChatHub");
            connection.Start().Wait();

            //Event subscription
            _hub.On<ChatMsg>("ReceiveMsg", x => OnReceiveMsg(x));

            Console.WriteLine("Enter Name:");
            userName = Console.ReadLine();

            Console.WriteLine("Welcome to the chat " + userName + "\n");

            //Msg object to send
            ChatMsg msg = new ChatMsg();
            msg.Sender = userName;

            string line;
            while ((line = Console.ReadLine()) != null)
            {
                msg.MsgBody = line;
                _hub.Invoke<IEnumerable<ChatMsg>>("SendMsg", msg).Wait();
            }
        }

        //Event function for receiving messages
        private static void OnReceiveMsg(ChatMsg msg)
        {
            Console.WriteLine(msg.Sender + " : " + msg.MsgBody);
        }
    }
}
