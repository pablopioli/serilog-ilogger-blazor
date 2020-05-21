The popular logging framework Serilog can be used in Blazor to replace the provided logging capabilities.  See for example https://github.com/serilog/serilog-sinks-browserconsole

However this forces you to use the Serilog classes insted of the Net Core abstraction **ILogger**.

There are benefits in using a popular abstraction, so this library allows you to use Serilog behind the ILogger interface.

Note that this is not original code, all meaningful code was copied verbatim from the https://github.com/serilog/serilog-extensions-hosting project, wich does not run under Blazor.

### Instructions

* Add the package **BlazorILogger** from nuget.

* Add the package **Microsoft.Extensions.Logging.Abstractions** from Nuget
* Configure Serilog as usual
* In program.cs add 
```csharp
   using Serilog.Extensions.Logging;
```
* Add UseSerilog in your Main method, as in
```csharp
var builder = WebAssemblyHostBuilder.CreateDefault(args);
            
builder.Services.AddSingleton(new HttpClient
            {
                BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
            });

builder.Logging.AddSerilog(); // you need to add this

builder.RootComponents.Add<App>("app");

await builder.Build().RunAsync();
```

* And that's all, now you can use **ILogger<>** in any Blazor component to send your logs to any configured Serilog sink.

See the included sample project for a complete example.