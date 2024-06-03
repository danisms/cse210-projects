public class LectureEvent : Event
{
    private string _speaker;
    private int _capacity;

    // Constructor
    public LectureEvent(string title, string description, string date, string time, Address address, string speaker, int capacity) : base(title, description, date, time, address)
    {
        _type = "Lecture Event";
        _speaker = speaker;
        _capacity = capacity;
    }

    public void DisplayFullDetails()
    {
        string specificInfo = $"Type of Event: {TitleCase(_type)}\nSpeaker: {TitleCase(_speaker)}\nCapacity: {_capacity}";
        Console.WriteLine(specificInfo);
        DisplayStandardDetails();
    }
}