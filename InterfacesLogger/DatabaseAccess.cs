using System;

namespace InterfacesLogger;

public class DatabaseAccess : IDataAccess
{
    // Simulate connecting to a database.
    public void Connect()
    {
        Console.WriteLine("Database connected.");
    }

    // Simulate retrieving data from the database.
    public string GetData()
    {
        return "Sample Data from Database";
    }
}
