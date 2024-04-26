using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        // welcome user
        Console.WriteLine("Hello! Welcome to Prep4!");

        // Program Description: Get numbers from users and perform some calculations
        // return the result back to user.

        // create user number variable an a list to hold user numbers
        int number = 1;
        List<int> userNumbers = new List<int>();
        // create other important variables
        int sumOfNumbers = 0;

        // get, verify and add user number to list
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        while (number != 0)
        {
            try
            {
                Console.Write("Enter number: ");
                number = int.Parse(Console.ReadLine());
                // add number to list if it's a number and not 0
                if (number != 0)
                {
                    userNumbers.Add(number);
                }
            }
            catch (Exception error)
            {
                Console.WriteLine(error);
                Console.WriteLine("Invalid input: Whole numbers only");
            }
        }

        // work with userNumbers list
        // get the sum of the numbers
        foreach (int num in userNumbers)
        {
            sumOfNumbers += num;
        }
        // get numbers average
        decimal averageNum = decimal.Divide(sumOfNumbers, userNumbers.Count);
        // get largest number and smallest number
        int largestNum = userNumbers[0];
        foreach (int num in userNumbers)
        {
            // get largest number
            if (num > largestNum)
            {
                largestNum = num;
            }
        }
        // get smallest number
        int smallestNum = largestNum;
        foreach (int num in userNumbers)
        {
            // get smallest number
            if (num > 0 && num < smallestNum)
            {
                smallestNum = num;
            }
        }

        // Display values
        Console.WriteLine($"The sum is: {sumOfNumbers}");
        Console.WriteLine($"The average is: {averageNum}");
        Console.WriteLine($"The largest number is: {largestNum}");
        Console.WriteLine($"The smallest positive number is: {smallestNum}");

        // sort list and display the value
        userNumbers.Sort();
        Console.Write("[");
        for (int i = 0; i < userNumbers.Count; i++)
        {
            if (i < userNumbers.Count - 1)
            {
                Console.Write($"{userNumbers[i]}, ");
            }
            else
            {
                Console.Write($"{userNumbers[i]}]");
            }
        }
    }
}