public class ReflectingActivity : Activity
{
    private List<string> _prompts = new List<string>();
    private List<string> _questions = new List<string>();

    private List<string> _selectedPrompts = new List<string>();
    private List<string> _selectedQuestions = new List<string>();

    private string _currentPrompt;
    private string _currentQuestion;

    public ReflectingActivity(string name, string description, List<string> prompts, List<string> questions) : base(name, description)
    {
        _prompts = prompts;
        _questions = questions;
    }

    public void Run()
    {
        // display animation
        Console.Clear();
        Console.Write("Get ready...");
        base.ChooseRandomAnimation(randomTiming());
        Console.WriteLine();  // for spacing purpose

        // Produce a prompt question
        Console.WriteLine("Consider the following prompt: ");
        Console.WriteLine();  // for spacing purpose
        Console.WriteLine($"--- {GetRandomPrompt()} ---\n");
        Console.WriteLine("When you have something in mind, press enter to continue.");
        Console.ReadLine();

        // check timing
        Console.WriteLine("Now ponder on each of the following questions as they relate to this experience.");
        Console.Write("You may begin in: ");
        base.ShowCountDown(randomTiming());

        // clear console
        Console.Clear();

        // set and begin section from duration.
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(GetDuration());
        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            GetRandomQuestion();
            DisplayQuestion();
            ShowSpinner(15);
            Console.WriteLine(); // for spacing purpose;
        }
        // display end message
        base.DisplayEndingMessage();
        Thread.Sleep(3000);
        Console.Clear();
    }

    public string GetRandomPrompt()
    {
        bool promptIn = true;
        if (_selectedPrompts.Count < _prompts.Count)
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
                // check if current prompt exit in _selectedPrompts
                // if it exist generate another random number and check again
                // else add _currentPrompt to _previousPrompt and return _currentPrompt;
                if (_selectedPrompts.Count > 0)
                {
                    foreach (string prompt in _selectedPrompts)
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
            _selectedPrompts.Add(_currentPrompt);
            // Console.WriteLine($"Returning current prompt {_currentPrompt}");
            return _currentPrompt;
        }
        else
        {
            // clear _selectedPrompts list
            _selectedPrompts.Clear();
            // run the function again
            return GetRandomPrompt();
        }
    }

    public string GetRandomQuestion()
    {
        bool queIn = true;
        if (_selectedQuestions.Count < _questions.Count)
        {
            while (queIn)
            {
                // generate a random number
                Random randomNum = new Random();
                int genRandomNum = randomNum.Next(0, _questions.Count);
                // Console.WriteLine($"Gen-Num: {genRandomNum}");  // for testing purpose
                // use the random number to pick a value from the list
                _currentQuestion = _questions[genRandomNum];
                // Console.WriteLine(_currentPrompt);  // for testing purpose
                // check if current prompt exit in _previousPrompts
                // if it exist generate another random number and check again
                // else add _currentPrompt to _previousPrompt and return _currentPrompt;
                if (_selectedQuestions.Count > 0)
                {
                    foreach (string question in _selectedQuestions)
                    {
                        if (_currentQuestion == question)
                        {
                            queIn = true;
                            // Console.WriteLine("question found in selected questions");
                            break;
                        }
                        else
                        {
                            queIn = false;
                            // Console.WriteLine("question not found");
                        }
                    }
                }
                else
                {
                    queIn = false;
                }
            }
            _selectedQuestions.Add(_currentQuestion);
            // Console.WriteLine($"Returning current prompt {_currentPrompt}");
            return _currentQuestion;
        }
        else
        {
            // clear _previousPrompts list
            _selectedQuestions.Clear();
            // run the function again
            return GetRandomQuestion();
        }
    }

    public void DisplayPrompt()
    {
        Console.WriteLine(_currentPrompt);
    }

    public void DisplayQuestion()
    {
        Console.Write(_currentQuestion);
    }
}