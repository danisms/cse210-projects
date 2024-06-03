public class CyclingActivity : Activity
{
    private double _speed;

    // Constructors
    public CyclingActivity(string date, double length, double speed) : base(date, length)
    {
        _type = "Cycling";
        _speed = speed;
    }

    // Methods
    public override double Distance()
    {
        // km/hr
        double distance = _speed * _length / 60;
        return distance;
    }

    public override double Speed()
    {
        return _speed;
    }

    public override double Pace()
    {
        double pace = 60 / _speed;
        return pace;
    }
}