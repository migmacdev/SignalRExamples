using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System.Collections.Generic;

namespace StockServer
{
    [HubName("StockHub")]
    public class StockHub : Hub
    {
        //StockTicker singleton reference
        private readonly StockTicker _stockTicker;

        //Initializing every Hub instance to use the stockticker singleton
        public StockHub() : this(StockTicker.Instance) { }

        public StockHub(StockTicker stockTicker)
        {
            _stockTicker = stockTicker;
        }

        [HubMethodName("GetAllStocks")]
        public IEnumerable<Stock> GetAllStocks()
        {
            //Returns value to the caller, in a strong typed way
            return _stockTicker.GetAllStocks();
        }
    }
}
