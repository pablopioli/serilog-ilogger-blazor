The popular logging framework Serilog can be used in Blazor to replace the provided logging capabilities.  See for example https://github.com/serilog/serilog-sinks-browserconsole

However this forces you to use the Serilog classes insted of the Net Core abstraction **ILogger**.

There are benefits in using a popular abstraction, so this library allows you to use Serilog behind the ILogger interface.

Note that this is not original code, all meaningful code was copied verbatim from the https://github.com/serilog/serilog-extensions-hosting project, wich does not run under Blazor.

### Instructions (Blazor 3.1)

* Add the package **BlazorILogger** from nuget (version 1.0.1-preview3.1.0)

* Add the package **Microsoft.Extensions.Logging.Abstractions** from Nuget
* Configure Serilog as usual
* In program.cs add 
```csharp
   using Serilog.Extensions.Logging;
```
* Add UseSerilog in your HostBuilder, as in
```csharp
        public static IWebAssemblyHostBuilder CreateHostBuilder(string[] args) =>
            BlazorWebAssemblyHost.CreateDefaultBuilder()
                .UseBlazorStartup<Startup>()
                .UseSerilog();
```

* And that's all, now you can use **ILogger<>** in any Blazor component to send your logs to any configured Serilog sink.

See the included sample project for a complete example.


### Instructions (Blazor 3.2)

* Add the package **BlazorILogger** from nuget. Use 1.1.0-preview3.2.0 for Blazor 3.2 Preview 1, use  1.2.0-3.2.0preview2 for Blazor 3.2 Preview 2.

* Add the package **Microsoft.Extensions.Logging.Abstractions** from Nuget
* Configure Serilog as usual
* In program.cs add 
```csharp
   using Serilog.Extensions.Logging;
```
* Add UseSerilog in your Main method, as in
```csharp
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            builder.UseSerilog(); // you need to add this

            builder.RootComponents.Add<App>("app");

            await builder.Build().RunAsync();
```

* And that's all, now you can use **ILogger<>** in any Blazor component to send your logs to any configured Serilog sink.

See the included sample project for a complete example.