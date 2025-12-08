using System;

public abstract class Activity
{
    private DateTime _date;
    private int _lengthMinutes; // duration in minutes

    protected Activity(DateTime date, int lengthMinutes)
    {
        _date = date;
        _lengthMinutes = lengthMinutes;
    }

    protected int GetLengthMinutes()
    {
        return _lengthMinutes;
    }

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    public virtual string GetSummary()
    {
        string dateText = _date.ToString("dd MMM yyyy");
        double distance = GetDistance();
        double speed = GetSpeed();
        double pace = GetPace();

        string activityName = GetType().Name.Replace("Activity", "");

        return $"{dateText} {activityName} ({_lengthMinutes} min): " +
               $"Distance {distance:F1} miles, Speed {speed:F1} mph, Pace: {pace:F1} min per mile";
    }
}
