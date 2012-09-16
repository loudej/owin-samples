using System.Collections.Generic;
using System.Globalization;
using Owin;

namespace ConsoleNancySignalR.Utils
{
    static class AppBuilderExtensions
    {
        public static IAppBuilder AddHostAddress(this IAppBuilder builder, string scheme, string host, int port)
        {
            var addresses = Dict.Get<IList<IDictionary<string, object>>>(
                builder.Properties,
                "host.Addresses",
                () => new List<IDictionary<string, object>>());

            addresses.Add(
                new Dictionary<string, object>
                    {
                        {"scheme", scheme},
                        {"host", host},
                        {"port", port.ToString(CultureInfo.InvariantCulture)},
                    });
            return builder;
        }

        public static IAppBuilder SetHostAddress(this IAppBuilder builder, string scheme, string host, int port)
        {
            var addresses = Dict.Get<IList<IDictionary<string, object>>>(
                builder.Properties,
                "host.Addresses",
                () => new List<IDictionary<string, object>>());

            addresses.Clear();
            addresses.Add(
                new Dictionary<string, object>
                    {
                        {"scheme", scheme},
                        {"host", host},
                        {"port", port.ToString(CultureInfo.InvariantCulture)},
                    });
            return builder;
        }
    }
}
