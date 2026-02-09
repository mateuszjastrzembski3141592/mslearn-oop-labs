using System;

namespace InterfacesLogger;

public interface IDataAccess
{
    void Connect();

    string GetData();
}
