using System.Security.Cryptography;

public class Activity
{
    private string _name;
    private string _description;
    private int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void SetDuration(int duration)
    {
        // from parent
        _duration = duration;
    }

    public int GetDuration()
    {
        return _duration;
    }

    public int randomTiming()
    {
        Random timing = new Random();
        return timing.Next(3, 7);
    }

    public void DisplayStatingMessage()
    {
        Console.WriteLine($"Welcome to the {_name} Activity\n");
        Console.WriteLine(_description);
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine("\nWell Done!\n");
        ShowSpinner(randomTiming());
        Console.WriteLine();  // for spacing purpose
        if (_duration < 1)
        {
            Console.WriteLine($"You have completed another {_duration} second of the Breathing Activity");
        }
        else
        {
            Console.WriteLine($"You have completed another {_duration} seconds of the Breathing Activity");
        }
    }

    public void ShowSpinner(int seconds)
    {
        int timeInMs = seconds * 1000;
        int speed = 500;
        string[] animation = ["-", "\\", "|", "/", "-", "\\", "|", "/"];
        while (timeInMs > 0)
        {
            foreach (string move in animation)
            {
                Console.Write(move);
                Thread.Sleep(speed);
                Console.Write("\b \b");
                timeInMs -= speed;
            }
        }
    }

    public void ShowLoading(int seconds)
    {
        int timeInMs = seconds * 1000;
        int speed = 500;
        string[] animation = ["L", "O", "A", "D", "I", "N", "G"];
        while (timeInMs > 0)
        {
            foreach (string move in animation)
            {
                Console.Write(move);
                Thread.Sleep(speed);
                Console.Write("\b \b");
                timeInMs -= speed;
            }
            foreach (string latter in animation)
            {
                Console.Write(latter);
                Thread.Sleep(150);
            }
            Console.Write(" ");
        }
    }

    public void ChooseRandomAnimation(int timing)
    {
        int getRandomBool()
        {
            Random getZeroOrOne = new Random();
            return getZeroOrOne.Next(0, 2);
        }
        if (getRandomBool() == 0)
        {
            ShowSpinner(timing);
        }
        else
        {
            ShowLoading(timing);
        }
    }

    public void ShowCountDown(int seconds)
    {
        int timeInMs = seconds * 1000;
        int count = seconds;
        int speed = 1000;
        while (timeInMs > 0)
        {
            Console.Write(count);
            Thread.Sleep(speed);
            Console.Write("\b \b");  // for erasing the + character
            timeInMs -= speed;
            count -= 1;
        }
    }
}