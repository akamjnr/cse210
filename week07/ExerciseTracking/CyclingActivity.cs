using System;

public class CyclingActivity : Activity
{
    private double _speedMph;

    public CyclingActivity(DateTime date, int lengthMinutes, double speedMph)
        : base(date, lengthMinutes)
    {
        _speedMph = speedMph;
    }

    public override double GetDistance()
    {
        double hours = GetLengthMinutes() / 60.0;
        return _speedMph * hours;
    }

    public override double GetSpeed()
    {
        return _speedMph;
    }

    public override double GetPace()
    {
        return 60.0 / _speedMph;
    }
}
