using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;

namespace ChatServerStrongTyped
{
    class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //Custom configuration
            var hubConfiguration = new HubConfiguration();
            hubConfiguration.EnableDetailedErrors = true;
            hubConfiguration.EnableJavaScriptProxies = false;

            //Mapping SignalR to different path and a different configuration
            app.MapSignalR("/custompath", hubConfiguration);
        }
    }
}
