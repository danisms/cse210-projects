using System;

class Program
{
    static void Main(string[] args)
    {
        // use functions to get and return value to the user
        // step 1: welcome the user
        DisplayWelcome();
        // step 2: get username
        string username = PromptUserName();
        // step 3: get user favorite number
        int favoriteNum = PromptUserNumber();
        // step 4: square user favorite number
        int squaredNum = SquareNumber(favoriteNum);
        // step 5: display result to the user
        DisplayResult(username, squaredNum);
    }

    // Function to display welcome message
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the program!");
    }

    // Function get and return user's  name
    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string username = Console.ReadLine();
        return username;
    }

    // Function to get and return user's favorite number
    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        int favoriteNum = int.Parse(Console.ReadLine());
        return favoriteNum;
    }

    // Function to square number
    static int SquareNumber(int number)
    {
        int squareNum = number * number;
        return squareNum;
    }

    // Function to display result to the user
    static void DisplayResult(string username, int number)
    {
        Console.WriteLine($"{username}, the square of your number {number}");
    }
}