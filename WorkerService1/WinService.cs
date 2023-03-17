using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace WorkerService
{
    internal class WinService : ServiceBase
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
        private ServiceImplementation _impl;

        public WinService()
        {
            try
            {
                _impl = new ServiceImplementation();
            }
            catch (Exception ex)
            {
                _logger.Fatal(ex, "WinService failed.");
                throw;
            }
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                _logger.Info("WinService.OnStart.");
                _impl.OnStart();
            }
            catch (Exception ex)
            {
                _logger.Fatal(ex, "WinService.OnStart failed.");
                throw;
            }
        }

        protected override void OnStop()
        {
            try
            {
                _logger.Info("WinService.OnStop.");
                _impl.OnStop();
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "WinService.OnStop failed.");
                throw;
            }
        }

        public void Start()
        {
            _logger.Info("WinService.Start.");
        }

    }

}

