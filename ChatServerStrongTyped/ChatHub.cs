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
       
        [HubMethodName("SendMsg")]
        public void SendMsg(ChatMsg msg)
        {
            //Sends Msg to all clients but the caller
            Clients.Others.ReceiveMsg(msg);
        }
    }
}
