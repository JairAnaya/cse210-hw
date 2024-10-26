using System;
using System.Collections.Generic;
public class Cycling : Activity
{
    private double _speedKph;

    public Cycling(DateTime date, int durationMinutes, double speedKph) : base(date, durationMinutes)
    {
        _speedKph = speedKph;
    }

    public override double GetDistance()
    {
        return (_speedKph * DurationMinutes) / 60;
    }

    public override double GetSpeed()
    {
        return _speedKph;
    }

    public override double GetPace()
    {
        return 60 / _speedKph;
    }
}