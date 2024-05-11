using System.Runtime.CompilerServices;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words = new List<Word>();
    private List<int> _generatedUniqueRandomNumbers = new List<int>();

    // constructor
    public Scripture(Reference Reference, string text)
    {
        _reference = Reference;
        string[] words = text.Split(" ");
        foreach (string word in words)
        {
            Word aWord = new Word(word);
            _words.Add(aWord);
        }
    }

    // methods
    // get a unique random number 
    public int GetUniqueRandomNumber()
    {
        int num = 0;
        bool numFoundInUnique = true;

        while (numFoundInUnique)
        {
            // generate a random number in the range of world list
            Random randomNum = new Random();
            num = randomNum.Next(0, _words.Count());

            // check if the number already exit in the _generatedUniqueRandomNumbers list;
            if (_generatedUniqueRandomNumbers.Count > 0 && _generatedUniqueRandomNumbers.Count < _words.Count)
            {
                foreach (int uniqueNum in _generatedUniqueRandomNumbers)
                {
                    if (num == uniqueNum)
                    {
                        numFoundInUnique = true;
                        break;
                    }
                    else {
                        numFoundInUnique = false;
                    }
                }
            }
            else
            {
                if (_generatedUniqueRandomNumbers.Count == _words.Count)
                {
                    // flush the _generatedUniqueRandomNumbers list
                    _generatedUniqueRandomNumbers.Clear();
                    // set num to the newly generated number
                    break;
                }
                else
                {
                    // pass
                    // num is set to the newly generated random number
                    break;
                }
            }
        }
        // // for debugging/testing purpose
        // Console.Write("[");
        // foreach (int value in _generatedUniqueRandomNumbers)
        // {
        //     Console.Write($"{value}, ");
        // }
        // Console.WriteLine("]");
        // Console.WriteLine($"Generated-Number: {num}");

        // append generated number to list and return the newly generated number
        _generatedUniqueRandomNumbers.Add(num);
        return num;
    }
    public void HideRandomWords()
    {
        int numberToHide = GetUniqueRandomNumber();
        // hide a world
        _words[numberToHide].Hide();
    }
    public string GetDisplayText()
    {
        string displayText;
        // display reference
        displayText = $"{_reference.GetDisplayText()}\n";
        foreach (Word word in _words)
        {
            displayText += $"{word.GetDisplayWord()} ";
        }
        return displayText;
    }
    public bool IsCompletelyHidden()
    {
        bool isAllHidden = true;

        foreach (Word word in _words)
        {
            if (word.IsHidden() == false)
            {
                return false;
            }
        }
        return isAllHidden;
    }
}