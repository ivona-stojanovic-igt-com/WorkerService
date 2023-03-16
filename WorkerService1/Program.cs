using NLog.Extensions.Logging;
using WorkerService;

IHost host = Host.CreateDefaultBuilder(args)
 .ConfigureServices((_, services) =>
 {
     services.AddLogging(loggingBuilder =>
     {
         loggingBuilder.ClearProviders();
         loggingBuilder.AddNLog();
     }).BuildServiceProvider();
     services.AddHostedService<Worker>();
 })
 .UseWindowsService()
 .Build(); await host.RunAsync();