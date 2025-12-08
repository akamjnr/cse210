using System;

public class SwimmingActivity : Activity
{
    private int _laps;

    public SwimmingActivity(DateTime date, int lengthMinutes, int laps)
        : base(date, lengthMinutes)
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        double kilometers = _laps * 50.0 / 1000.0;
        double miles = kilometers * 0.62;
        return miles;
    }

    public override double GetSpeed()
    {
        double distance = GetDistance();
        return (distance / GetLengthMinutes()) * 60.0;
    }

    public override double GetPace()
    {
        double distance = GetDistance();
        return GetLengthMinutes() / distance;
    }
}
