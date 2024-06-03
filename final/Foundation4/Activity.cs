public abstract class Activity
{
    protected string _type;
    private string _date;
    protected double _length;

    // Constructor
    public Activity(string date, double length)
    {
        _date = date;
        _length = length;
    }

    // Methods
    public abstract double Distance();
    public abstract double Speed();
    public abstract double Pace();

    // public virtual string GetSummary()
    // {
    //     string activitySummary = $"{_date} {_type} ({_length} min) - Distance: {Distance():C2} km, Speed: {Speed():C2} k/h, Pace: {Pace():C2} min/km.";
    //     return activitySummary;
    // }

    public virtual void GetSummary()
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
        // Distance
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("Distance: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"{Distance()} km");
        // Speed
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("Speed: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"{Speed()} k/h");
        // Pace
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("Pace: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"{Pace()} min/km");
    }
}