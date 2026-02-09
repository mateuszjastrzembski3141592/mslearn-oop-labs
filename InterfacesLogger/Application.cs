using System;

namespace InterfacesLogger;

public class Application
{
    private readonly ConsoleLogger _logger;
    private readonly DatabaseAccess _dataAccess;

    public Application()
    {
        _logger = new ConsoleLogger();
        _dataAccess = new DatabaseAccess();
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
