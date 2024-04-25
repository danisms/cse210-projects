using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Sandbox World!");
        Console.Write("Hello!");
        Console.WriteLine("Hi");
        Console.Write("How are you?");
        Console.WriteLine("I'm fine");
        Console.Write("Are you sure?: ");
        string response = Console.ReadLine();
        Console.WriteLine($"Since you said {response}, may God bless you.");
    }
}
