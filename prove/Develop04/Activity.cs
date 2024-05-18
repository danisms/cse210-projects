using System.Security.Cryptography;

public class Activity
{
    private string _name;
    private string _description;
    private int _duration;

    public Activity(string name, string description, int duration)
    {
        _name = name;
        _description = description;
        _duration = duration;
    }

    public void DisplayStatingMessage()
    {
        Console.WriteLine($"Welcome to the {_name} Activity\n");
        Console.WriteLine(_description);
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine("Well done!\n");
        if (_duration > 1)
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
        while (timeInMs > 0)
        {
            Console.Write('+');
            Thread.Sleep(speed);
            Console.Write("\b \b");  // for erasing the + character
            Console.Write("-");  // for replacing the the position of the + character with a minus (-) character
            timeInMs -= speed;            
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
            Console.Write(count);  // for replacing the the position of the + character with a minus (-) character           
        }
    }
}