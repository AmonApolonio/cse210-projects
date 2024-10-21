public class Running : Activity
{
    private double _distance;

    public Running(DateTime date, int minutes, double distance) 
        : base(date, minutes)
    {
        _distance = distance;
    }

    public override double GetDistance() => _distance;

    public override double GetSpeed()
    {
        return (_distance / _minutes) * 60;
    }

    public override double GetPace()
    {
        return _minutes / _distance;
    }

    public override string GetSummary()
    {
        return $"{base.GetSummary()} Running - Distance: {_distance:0.0} miles, Speed: {GetSpeed():0.0} mph, Pace: {GetPace():0.0} min per mile";
    }
}