using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace Serilog.Extensions.Logging
{
    public static class Extensions
    {
        public static WebAssemblyHostBuilder UseSerilog(this WebAssemblyHostBuilder builder)
        {
            var serviceCollection = builder.Services;

            serviceCollection.AddSingleton(typeof(ILoggerFactory), new SerilogLoggerFactory());

            foreach (var item in serviceCollection.Where(x => x.ServiceType == typeof(ILogger<>)).ToArray())
            {
                serviceCollection.Remove(item);
            }

            serviceCollection.AddLogging(loggingBuilder => loggingBuilder.AddProvider(new SerilogLoggerProvider()));

            return builder;
        }
    }
}
