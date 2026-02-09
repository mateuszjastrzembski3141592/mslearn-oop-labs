using System;

namespace InterfacesLogger;

public class ConsoleLogger : ILogger
{
    public void Log(string message)
    {
        Console.WriteLine($"ConsoleLogger: {message}");
    }
}
