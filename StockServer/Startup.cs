using Microsoft.Owin.Cors;
using Owin;

namespace StockServer
{
    class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //Any Hubs configuration or OWIN configuration goes here
            //For enable Cross Domain Origin
            app.UseCors(CorsOptions.AllowAll);

            //Mapps SignalR to defaul route /signalr/hubs/
            app.MapSignalR();
        }
    }
}
