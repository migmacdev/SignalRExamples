namespace StockServer
{
    //Stock representation to send between server and clients
    public class Stock
    {
        public decimal Price { get; set; }
        public string Symbol { get; set; }
    }
}
