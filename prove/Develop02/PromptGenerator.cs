public class PromptGenerator
{
    // Attributes
    public List<string> _prompts = new List<string>();
    public string _currentPrompt;
    List<string> _previousPrompts = new List<string>();

    // code

    // Behavior
    public string GetRandomPrompt()
    {
        // Console.WriteLine($"PreviousPrompt: {_previousPrompts.Count} < PromptsList: {_prompts.Count}");  // for debugging purpose
        bool promptIn = true;
        if (_previousPrompts.Count < _prompts.Count)
        {
            while (promptIn)
            {
                // generate a random number
                Random randomNum = new Random();
                int genRandomNum = randomNum.Next(0, _prompts.Count);
                // Console.WriteLine($"Gen-Num: {genRandomNum}");  // for testing purpose
                // use the random number to pick a value from the list
                _currentPrompt = _prompts[genRandomNum];
                // Console.WriteLine(_currentPrompt);  // for testing purpose
                // check if current prompt exit in _previousPrompts
                // if it exist generate another random number and check again
                // else add _currentPrompt to _previousPrompt and return _currentPrompt;
                if (_previousPrompts.Count > 0)
                {
                    foreach (string prompt in _previousPrompts)
                    {
                        if (_currentPrompt == prompt)
                        {
                            promptIn = true;
                            // Console.WriteLine("prompt found in previous prompt");
                            break;
                        }
                        else
                        {
                            promptIn = false;
                            // Console.WriteLine("prompt not found");
                        }
                    }
                }
                else
                {
                    promptIn = false;
                }
            }
            _previousPrompts.Add(_currentPrompt);
            // Console.WriteLine($"Returning current prompt {_currentPrompt}");
            return _currentPrompt;
        }
        else
        {
            // clear _previousPrompts list
            _previousPrompts.Clear();
            // run the function again
            return GetRandomPrompt();
        }

    }
}