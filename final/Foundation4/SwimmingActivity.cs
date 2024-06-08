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
        double pace = Distance() / _length * 60;
        return pace;
    }

    public override double Pace()
    {
        double pace = 60 / Speed();
        return pace;
    }

    public override void GetSummary()
    {
        // Date
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("Date: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"{_date}");
        // Type
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("Activity Type: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"{_type}");
        // Duration
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("Duration: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"{_length} min");
        // Lap
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("Lap: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"{_laps}");
        // Distance
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("Distance: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"{Math.Round(Distance(), 2)} km");
        // Speed
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("Speed: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"{Math.Round(Speed(), 2)} k/h");
        // Pace
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("Pace: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"{Math.Round(Pace(), 2)} min/km");
    }

}