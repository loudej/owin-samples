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
            var startup = new Startup(); // this program's Startup.cs class
            var app = new AppBuilder(); // the app builder, from Owin.Builder package

            // the server adapter, from Microsoft.HttpListener.Owin package, gets first chance
            ServerFactory.Initialize(app.Properties); 
            
            // this method adds all middleware and frameworks
            startup.Configuration(app);

            // ext method to set server address in app.Properties
            app.SetHostAddress("http", "+", 8080);

            // build pipeline, and give to server adapter from Microsoft.HttpListener.Owin package
            using (ServerFactory.Create(app.Build(), app.Properties))
            {
                Console.WriteLine("Running on http://+:8080/");
                Console.WriteLine("Press enter to exit");
                Console.ReadLine();
            }
        }
    }
}
