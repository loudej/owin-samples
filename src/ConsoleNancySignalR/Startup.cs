using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConsoleNancySignalR.Utils;
using Gate.Adapters.Nancy;
using Gate.Middleware;
using Nancy;
using Owin;

namespace ConsoleNancySignalR
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app
                .UseFunc(LogRequests)
                .UseShowExceptions()
                .MapHubs("/signalr")
                .RunNancy(new DefaultNancyBootstrapper());
        }

        private static Func<IDictionary<string, object>, Task> LogRequests(Func<IDictionary<string, object>, Task> next)
        {
            return env =>
            {
                var output = Dict.Get(env, "host.TraceOutput", () => Console.Out);
                output.WriteLine(
                    "{0} {1}{2} {3}",
                    env["owin.RequestMethod"],
                    env["owin.RequestPathBase"],
                    env["owin.RequestPath"],
                    env["owin.RequestQueryString"]);
                return next(env);
            };
        }

    }
}
