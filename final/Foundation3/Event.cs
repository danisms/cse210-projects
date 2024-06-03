using System.ComponentModel.DataAnnotations;

public class Event : FormatText
{
    protected string _type;
    private string _title;
    private string _description;
    private string _date;
    private string _time;
    private Address _address;

    // Constructor
    public Event(string title, string description, string date, string time, Address address)
    {
        _title = title;
        _description = description;
        _date = date;
        _time = time;
        _address = address;
    }

    // Methods
    public void  DisplayStandardDetails()
    {
        string standardDetails = $"Title: {TitleCase(_title)}\nDescription: {Capitalize(_description)}\nDate: {_date}\nTime: {_time}\nAddress: {_address.GetAddress()}.";
        Console.WriteLine(standardDetails);
    }
    public void DisplayShortDescription()
    {
        string shortDescription = $"Type of Event: {TitleCase(_type)}\nTitle: {TitleCase(_title)}\nDate: {TitleCase(_date)}";
        Console.WriteLine(shortDescription);
    }
}