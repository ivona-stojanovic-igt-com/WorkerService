using System;

public class ServiceImplementation : IDisposable
{
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

    public ServiceImplementation()
	{

	}

    public void OnStart()
    {
        _logger.Info("ServiceImpl.OnStart initiated.");
    }

    public void OnStop()
    {
        _logger.Info("ServiceImpl.OnStop initiated.");
    }

}
