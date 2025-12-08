using System;

public class RunningActivity : Activity
{
    private double _distanceMiles;

    public RunningActivity(DateTime date, int lengthMinutes, double distanceMiles)
        : base(date, lengthMinutes)
    {
        _distanceMiles = distanceMiles;
    }

    public override double GetDistance()
    {
        return _distanceMiles;
    }

    public override double GetSpeed()
    {
        return (_distanceMiles / GetLengthMinutes()) * 60.0;
    }

    public override double GetPace()
    {
        return GetLengthMinutes() / _distanceMiles;
    }
}
