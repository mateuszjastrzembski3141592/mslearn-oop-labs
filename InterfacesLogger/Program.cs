using System;

namespace InterfacesLogger;

class Program
{
    static void Main()
    {
        var logger = new ConsoleLogger();
        var dataAccess = new DatabaseAccess();

        // Dependency injection
        var app = new Application(logger, dataAccess);
        app.Run();
    }
}