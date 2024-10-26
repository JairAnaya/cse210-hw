using System;
using System.Collections.Generic;

public abstract class Activity
{
    private DateTime _date;
    private int _durationMinutes;

    public Activity(DateTime date, int durationMinutes)
    {
        _date = date;
        _durationMinutes = durationMinutes;
    }

    public DateTime Date => _date;
    public int DurationMinutes => _durationMinutes;

    protected double ConvertKmToMiles(double km)
    {
        return km * 0.62;
    }

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    public virtual string GetSummary()
    {
        double distanceKm = GetDistance();
        double distanceMiles = ConvertKmToMiles(distanceKm);
        double speedKph = GetSpeed();
        double speedMph = ConvertKmToMiles(speedKph);
        double paceKm = GetPace();
        double paceMiles = paceKm * 1.6;

        string miles = $"{_date:dd MMM yyyy} {this.GetType().Name} ({_durationMinutes} min): Distance {distanceMiles:0.0} miles, Speed {speedMph:0.0} mph, Pace: {paceMiles:0.00} min per mile";
        string kms = $"{_date:dd MMM yyyy} {this.GetType().Name} ({_durationMinutes} min): Distance {distanceKm:0.0} km, Speed {speedKph:0.0} kph, Pace: {paceKm:0.00} min per km";

        return $"{miles}\n{kms}";
    }
}