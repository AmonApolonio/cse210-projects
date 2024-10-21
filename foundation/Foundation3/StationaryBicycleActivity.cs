public class Cycling : Activity
{
    private double _speed;

    public Cycling(DateTime date, int minutes, double speed) 
        : base(date, minutes)
    {
        _speed = speed;
    }

    public override double GetDistance()
    {
        return (_speed * _minutes) / 60;
    }

    public override double GetSpeed() => _speed;

    public override double GetPace()
    {
        return 60 / _speed;
    }

    public override string GetSummary()
    {
        return $"{base.GetSummary()} Cycling - Distance: {GetDistance():0.0} miles, Speed: {_speed:0.0} mph, Pace: {GetPace():0.0} min per mile";
    }
}