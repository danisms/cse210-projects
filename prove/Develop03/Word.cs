public class Word
{
    // properties (attributes)
    private string _word;
    private bool _isHidden;

    // constructor
    public Word(string word)
    {
        _word = word;
        _isHidden = false;
    }

    // Methods (Behavior)
    public void Hide()
    {
        // responsible for setting the isHidden property of a word
        _isHidden = true;
    }
    public void Show()
    {
        // responsible for setting the isHidden property of a word
        _isHidden = false;
    }
    public bool IsHidden()
    {
        return _isHidden;
    }
    public string GetDisplayWord()
    {
        string displayWord;
        if(IsHidden())
        {
            displayWord = "_";
        }
        else
        {
            displayWord = _word;
        }
        return displayWord;
    }
}