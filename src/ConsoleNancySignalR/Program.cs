using System;
using ConsoleNancySignalR.Utils;
using Microsoft.HttpListener.Owin;
using Owin;
using Owin.Builder;

namespace ConsoleNancySignalR
{
    class Program
    {
        static void Main(string[] args)
        {
            var startup = new Startup();
            var app = new AppBuilder();

            ServerFactory.Initialize(app.Properties);
            
            startup.Configuration(app);

            app.SetHostAddress("http", "+", 8080);   
         
            using (ServerFactory.Create(app.Build(), app.Properties))
            {
                Console.WriteLine("Running on http://+:8080/");
                Console.WriteLine("Press enter to exit");
                Console.ReadLine();
            }
        }
    }
}
