using Microsoft.Owin.Hosting;
using System;

namespace StockServer
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = @"http://localhost:8080/";
            //Binding app a la url y puerto
            //Para hacer binding a todas las direcciones
            //usar http://*:8080 or http://+:8080. 
            using (WebApp.Start<Startup>(url))
            {
                Console.WriteLine("Running Server, Run StockClient as client");
                Console.ReadLine();
            }
        }
    }
}
