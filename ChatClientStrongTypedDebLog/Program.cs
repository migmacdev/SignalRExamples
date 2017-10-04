using Microsoft.AspNet.SignalR.Client;
using Microsoft.AspNet.SignalR.Client.Transports;
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

            #region Logging and config
            //Add query strings
            var querystringData = new Dictionary<string, string>();
            querystringData.Add("chatversion", "1.0");

            //For sending querystrings and a custom path in signalR
            var connection = new HubConnection(url + "custompath", querystringData, false);

            //For client logging
            //connection.TraceLevel = TraceLevels.All;
            //connection.TraceWriter = Console.Out;
            connection.Error += Connection_Error;
            connection.ConnectionSlow += Connection_ConnectionSlow;
            connection.Closed += Connection_Closed;
            connection.StateChanged += Connection_StateChanged;
            connection.Reconnected += Connection_Reconnected;
           
            _hub = connection.CreateHubProxy("ChatHub");

            //EXPLICIT TRANSPORT SPECIFIED
            connection.Start().Wait();
            #endregion

            #region chat functions
            //Event subscription
            _hub.On<ChatMsg>("ReceiveMsg", x => OnReceiveMsg(x));

            Console.WriteLine("Enter Name:");
            userName = Console.ReadLine();

            //Save state data
            _hub["username"] = userName;

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
            #endregion
        }
        //Event function for receiving messages
        private static void OnReceiveMsg(ChatMsg msg)
        {
            Console.WriteLine(msg.Sender + " : " + msg.MsgBody);
        }

        #region Connection Lifetime Events
        private static void Connection_Reconnected()
        {
            Console.WriteLine("Reconnected");
        }

        private static void Connection_StateChanged(StateChange obj)
        {
            Console.WriteLine("State changed " + obj.NewState);
        }

        private static void Connection_Closed()
        {
            Console.WriteLine("Connection Closed");
        }

        private static void Connection_ConnectionSlow()
        {
            Console.WriteLine("Connection Slow");
        }

        private static void Connection_Error(Exception obj)
        {
            Console.WriteLine("Connection error " + obj.Message);
        }
        #endregion
    }
}
