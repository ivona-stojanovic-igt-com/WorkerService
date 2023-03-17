using Microsoft.Extensions.Options;
using NLog.Extensions.Logging;
using System.ServiceProcess;
using WorkerService;

namespace Com.IGT.Mw.ReportService
{
    static class Program
    {
        public const String ConsoleArg = "--console";

        static void Main(string[] args)
        {
            if(args.Length > 0 && string.Compare(args[0], ConsoleArg) == 0)
            {
                try
                {
                    using (ServiceImplementation impl = new ServiceImplementation())
                    {
                        impl.OnStart();
                        Console.ReadLine();
                        impl.OnStop();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    throw;
                }

            } else
            {
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[] { new WinService() };
                ServiceBase.Run(ServicesToRun);
            }
        }
    }
}