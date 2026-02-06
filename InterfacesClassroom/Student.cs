using System;

namespace InterfacesClassroom;

public class Student : IPerson, IComparable
{
    public string Name { get; set; } = string.Empty;
    public int Age { get; set; } = 0;
    public string Role => "Student";

    public void DisplayInfo()
    {
        Console.WriteLine($"Student Name: {Name}, Age: {Age}");
    }

    public int CompareTo(object? obj)
    {
        // Check if obj is null
        if (obj == null)
        {
            throw new ArgumentNullException(nameof(obj), "Cannot compare to a null object.");
        }

        // Check if obj is of type Student
        if (obj is Student other)
        {
            // Compare the Age property
            return Age.CompareTo(other.Age);
        }
        else
        {
            throw new ArgumentException("The object being compared must be of type Student.", nameof(obj));
        }
    }
}
