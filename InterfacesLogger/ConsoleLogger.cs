using System;

namespace InterfacesLogger;

public class ConsoleLogger
{
    public void Log(string message)
    {
        Console.WriteLine($"ConsoleLogger: {message}");
    }
}
