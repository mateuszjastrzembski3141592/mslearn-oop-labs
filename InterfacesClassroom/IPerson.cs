using System;

namespace InterfacesClassroom;

public interface IPerson
{
    string Name { get; set; }
    int Age { get; set; }
    string Role { get; }

    void DisplayInfo();

    void Greet()
    {
        Console.WriteLine($"Hello, my name is {Name} and I am a {Role}.");
    }
}
