public class ListingActivity : Activity
{
    private int _count;
    private List<string> _prompts = new List<string>();
    private List<string> _previousPrompts = new List<string>();
    private string _currentPrompt;
    private List<string> _userResponse = new List<string>();
    
    public ListingActivity(string name, string description, List<string> prompts) : base(name, description)
    {
        _prompts = prompts;
    }

    public void Run()
    {
        // display animation
        Console.Clear();
        Console.Write("Get ready...");
        base.ChooseRandomAnimation(randomTiming());
        Console.WriteLine();  // for spacing purpose

        Console.WriteLine("\nList as many responses you can to the following prompt:");
        Console.WriteLine($"--- {GetRandomPrompt()} ---");
        Console.Write("You may begin in: ");
        ShowCountDown(randomTiming());
        Console.WriteLine();  // for spacing purpose;
        
        // check timing
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(GetDuration());
        // initiate count
        _count = 0;
        while (DateTime.Now < endTime)
        {
            GetListFromUser();
            _count += 1;
        }

        // display number of entries made
        Console.WriteLine($"You listed {_count} items!");

        // display end message
        base.DisplayEndingMessage();
        Thread.Sleep(5000);
        Console.Clear();
    }

    public string GetRandomPrompt()
    {
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
                // Console.WriteLine(_prompts[0]);  // for testing purpose
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


    public List<string> GetListFromUser()
    {
        Console.Write(">: ");
        string response = Console.ReadLine();
        // store response
        _userResponse.Add(response);
        return _userResponse;
    }
}
