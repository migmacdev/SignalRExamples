using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using StrongTypedClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatServerStrongTyped
{
    [HubName("ChatHub")]
    public class ChatHub : Hub
    {

        public override Task OnConnected()
        {
            Console.WriteLine("Client Connected " + Context.ConnectionId);
            //Getting query strings
            var version = Context.QueryString["chatversion"];
            if (version != "1.0")
            {
                Console.WriteLine("Client chat version different, Connection ID: " + Context.ConnectionId);
            }
            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            return base.OnDisconnected(stopCalled);
        }

        [HubMethodName("SendMsg")]
        public void SendMsg(ChatMsg msg)
        {
            //Sends Msg to all clients but the caller
            Clients.Others.ReceiveMsg(msg);
        }
    }
}
