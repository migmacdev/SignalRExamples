using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatServerStrongTyped
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
                Console.WriteLine("Running Server, Run ChatClientStrongTypedDebLog as client");
                Console.ReadLine();
            }
        }
    }
}
