using System;

namespace InterfacesLogger;

public class Application
{
    private readonly ILogger _logger;
    private readonly IDataAccess _dataAccess;

    public Application(ILogger logger, IDataAccess dataAccess)
    {
        _logger = logger;
        _dataAccess = dataAccess;
    }

    public void Run()
    {
        _logger.Log("Application started.");

        _dataAccess.Connect();
        var data = _dataAccess.GetData();

        _logger.Log($"Data retrieved: {data}");

        _logger.Log("Application finished.");
    }
}
