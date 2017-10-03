using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatServerStrongTyped
{
    class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //Maps SignalR to defaul route /signalr/hubs/
            app.MapSignalR();
        }
    }
}
