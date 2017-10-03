using Microsoft.AspNet.SignalR.Client;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace StockClient
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
            _hub = connection.CreateHubProxy("StockHub");
            connection.Start().Wait();  //wait for connection

            //Get a strong typed result of a server call
            var stocks = _hub.Invoke<IEnumerable<Stock>>("GetAllStocks").Result;
            Console.WriteLine("Got stocks------------------");

            //Event subscription to UpdateStockPrice function
            _hub.On("UpdateStockPrice", x => OnReceiveStock(x));

            while ((Console.ReadLine()) != null)
            {
            }
        }

        private static void OnReceiveStock(JObject stock)
        {
            Console.WriteLine(stock.GetValue("Symbol") + " : " + stock.GetValue("Price"));
        }
    }

    //Stock class client representation
    class Stock
    {
        public decimal Price { get; set; }

        public string Symbol { get; set; }
    }
}
