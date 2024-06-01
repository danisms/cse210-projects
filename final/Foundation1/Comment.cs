public class Comment
{
    private string _name;
    private string _text;

    // Constructor
    public Comment(string name, string text)
    {
        _name = name;
        _text = text;
    }

    // Methods
    public void DisplayComment()
    {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine(_text);
    }
}