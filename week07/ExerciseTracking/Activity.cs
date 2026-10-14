using System;
using System.Globalization;

public abstract class Activity
{
private DateTime _date;
private int _length;


public Activity(DateTime date, int length)
{
    _date = date;
    _length = length;
}

public abstract double GetDistance();
public abstract double GetSpeed();
public abstract double GetPace();

public virtual string GetSummary()
{
    string date = _date.ToString("dd MMM yyyy", CultureInfo.InvariantCulture);
    string distance = GetDistance().ToString("0.0", CultureInfo.InvariantCulture);
    string speed = GetSpeed().ToString("0.0", CultureInfo.InvariantCulture);
    string pace = GetPace().ToString("0.0", CultureInfo.InvariantCulture);

    return $"{date} {GetType().Name} ({_length} min) - Distance: {distance} miles, Speed: {speed} mph, Pace: {pace} min per mile";
}

protected int GetLength()
{
    return _length;
}


}
