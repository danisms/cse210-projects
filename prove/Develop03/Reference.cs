public class Reference
{
    private string _book;
    private int _chapter;
    private int _startVerse;
    private int _endVerse;

    // constructor
    public Reference(string book, int chapter, int startVerse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = startVerse;
        _endVerse = 0;
    }
    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = startVerse;
        _endVerse = endVerse;
    }

    // Methods
    public string GetDisplayText()
    {
        string displayText;
        if (_endVerse == 0)
        {   
            displayText = $"{_book} {_chapter}:{_startVerse}";
        }
        else {
            displayText = $"{_book} {_chapter}:{_startVerse}-{_endVerse}";
        }
        return displayText;
    }
}