using Microsoft.AspNetCore.Blazor.Hosting;
using Serilog;
using Serilog.Core;
using Serilog.Extensions.Logging;
using System.Threading.Tasks;

namespace Sample
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            var levelSwitch = new LoggingLevelSwitch();
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.ControlledBy(levelSwitch)
                .WriteTo.BrowserConsole()
                .CreateLogger();

            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            builder.UseSerilog();

            builder.RootComponents.Add<App>("app");

            await builder.Build().RunAsync();
        }
    }
}
