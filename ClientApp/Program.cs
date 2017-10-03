using Microsoft.AspNet.SignalR.Client;
using System;

namespace ClientApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Proxy Hub proxy for calling server functions
            IHubProxy _hub;

            //Server address
            string url = @"http://localhost:8080/";

            //Hub connection setup
            var connection = new HubConnection(url);
            _hub = connection.CreateHubProxy("ChatHub");
            connection.Start().Wait();  //wait for connection

            //Event subscription
            _hub.On("ReceiveMsg", x => OnReceiveMsg(x));

            string msg = null;

            while ((msg = Console.ReadLine()) != null)
            {
                _hub.Invoke("SendMsg", msg).Wait();
            }
        }

        //Event function for receiving messages
        private static void OnReceiveMsg(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
