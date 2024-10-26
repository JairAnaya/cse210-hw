using System;
using System.Collections.Generic;
public class Swimming : Activity
{
    private int _laps;

    public Swimming(DateTime date, int durationMinutes, int laps) : base(date, durationMinutes)
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        return (_laps * 50) / 1000;
    }

    public override double GetSpeed()
    {
        return (GetDistance() / DurationMinutes) * 60;
    }

    public override double GetPace()
    {
        return DurationMinutes / GetDistance();
    }
}