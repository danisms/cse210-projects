public class ReceptionEvent : Event
{
    private string _email;

    // Constructor
    public ReceptionEvent(string title, string description, string date, string time, Address address, string email) : base(title, description, date, time, address)
    {
        _type = "Reception Event";
        _email = email;
    }

    // Methods
    public void DisplayFullDetails()
    {
        string specificInfo = $"Type of Event: {TitleCase(_type)}\nR.S.V.P: {Capitalize(_email)}";
        Console.WriteLine(specificInfo);
        DisplayStandardDetails();
    }
}