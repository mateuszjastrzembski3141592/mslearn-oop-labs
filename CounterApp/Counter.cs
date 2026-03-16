using System;

namespace CounterApp;

public class Counter
{
    public int Total { get; private set; }
    public int Threshold { get; set; }

    public event EventHandler<ThresholdReachedEventArgs>? ThresholdReached;

    public Counter(int threshold)
    {
        Threshold = threshold;
        Total = 0;
    }

    public void Add(int value)
    {
        Total += value;
        Console.WriteLine($"Current Total: {Total}");

        if (Total >= Threshold)
        {
            var args = new ThresholdReachedEventArgs
            {
                Threshold = Threshold,
                TimeReached = DateTime.Now
            };

            OnThresholdReached(args);
        }
    }

    protected virtual void OnThresholdReached(ThresholdReachedEventArgs e)
    {
        ThresholdReached?.Invoke(this, e);
    }
}
