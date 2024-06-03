public class OutdoorEvent : Event
{
    private string _weatherForecast;

    // Constructor
    public OutdoorEvent(string title, string description, string date, string time, Address address, string weatherForecast) : base(title, description, date, time, address)
    {
        _type = "Outdoor Event";
        _weatherForecast = weatherForecast;
    }

    // Methods
    public void DisplayFullDetails()
    {
        string specificInfo = $"Type of Event: {TitleCase(_type)}\nWeather: {Capitalize(_weatherForecast)}";
        Console.WriteLine(specificInfo);
        DisplayStandardDetails();
    }
}