using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using SampleLib;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

var services = new ServiceCollection();
services.AddLogging(b => b.AddSerilog());
var provider = services.BuildServiceProvider();

var logger = provider.GetRequiredService<ILogger<Program>>();
logger.LogInformation("SampleApp started");

var result = StringHelper.Serialize(new { Name = "Black Duck", Version = "11.4.2" });
Console.WriteLine(result);
