public class SwimmingActivity : Activity
{
    private double _laps;

    // Constructors
    public SwimmingActivity(string date, double length, double laps) : base(date, length)
    {
        _type = "Swimming";
        _laps = laps;
    }

    // Methods
    public override double Distance()
    {
        double distance = _laps * 50 / 1000;
        return distance;
    }

    public override double Speed()
    {
        double pace = _length * Distance();
        return pace;
    }

    public override double Pace()
    {
        double pace = 60 / Speed();
        return pace;
    }


}