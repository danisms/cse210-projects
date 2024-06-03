public class RunningActivity : Activity
{
    private double _distance;

    // Constructors
    public RunningActivity(string date, double length, double distance) : base(date, length)
    {
        _type = "Running";
        _distance = distance;
    }

    // Methods
    public override double Distance()
    {
        // km
        return _distance;
    }

    public override double Speed()
    {
        // km/hr
        double  speed = _distance / _length * 60;
        return speed;
    }

    public override double Pace()
    {
        // m/km
        double pace = _length / _distance;
        return pace;
    }
}