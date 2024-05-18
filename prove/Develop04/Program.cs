using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Develop04 World!");
        Activity newActivty = new Activity("Breathing", "Texting if it will work", 30);

        newActivty.ShowSpinner(5);
    }
}