using Nancy;

namespace ConsoleNancySignalR
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get["/"] = _ => "Hello, Nancy!";
        }
    }
}