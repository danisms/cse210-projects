public class Entry
{
    public string _date;
    public string _promptText;
    public string _entryText;
    public string _entry;

    public void Display()
    {
        // create and entry using the variables
        _entry = $"Date: {_date}\nPrompt: {_promptText}\nResponse: {_entryText}\n";
        Console.WriteLine(_entry);
    }

}