using System;

namespace CounterApp;

class Program
{
    static void Main()
    {
        Counter counter = new(10);

        counter.ThresholdReached += Counter_ThresholdReached;

        Console.WriteLine("Press \"a\" to add 1 to the counter or \"q\" to quit");

        while (true)
        {
            var key = Console.ReadKey(true).KeyChar;

            if (key == 'a')
            {
                counter.Add(1);
            }
            else if (key == 'q')
            {
                break;
            }
        }
    }

    static void Counter_ThresholdReached(object? sender, ThresholdReachedEventArgs e)
    {
        Console.WriteLine($"Threshold of {e.Threshold} reached at {e.TimeReached}.");
    }
}