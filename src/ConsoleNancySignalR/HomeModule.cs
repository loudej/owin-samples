using Nancy;

namespace ConsoleNancySignalR
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get["/"] = _ => "Hello, Nancy! Look for /signalr/hubs to see that signalr is mapped.";
        }
    }
}