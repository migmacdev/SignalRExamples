using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace ChatServer
{
    [HubName ("ChatHub")]
    public class ChatHub : Hub
    {
        [HubMethodName("SendMsg")]
        public void SendMsg(string msg)
        {
            //Sends Msg to all clients but the caller
            Clients.Others.ReceiveMsg(msg);
        }
    }
}
