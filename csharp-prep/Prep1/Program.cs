using System;

class Program
{
    static void Main(string[] args)
    {
        // Welcome the user
        Console.WriteLine("Hello Welcome to Prep1!");

        // Get user first name
        Console.Write("What is your first name? ");
        string first_name = Console.ReadLine();

        // Get user last name
        Console.Write("What is your last name? ");
        string last_name = Console.ReadLine();

        // Display user first name and last name back to the user
        Console.WriteLine();
        string display_name = $"Your name is {last_name}, {first_name} {last_name}.";
        Console.WriteLine(display_name);
    }
}