using System;

class Program
{
    static void Main(string[] args)
    {
        // Welcome the user
        Console.WriteLine("Hello Welcome to Prep1!");

        // Get user first name
        Console.Write("What is your first name? ");
        string firstName = Console.ReadLine();

        // Get user last name
        Console.Write("What is your last name? ");
        string lastName = Console.ReadLine();

        // Display user first name and last name back to the user
        Console.WriteLine();
        string displayName = $"Your name is {lastName}, {firstName} {lastName}.";
        Console.WriteLine(displayName);
    }
}