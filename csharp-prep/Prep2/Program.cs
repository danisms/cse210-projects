using System;
using System.Reflection.Metadata;

class Program
{
    static void Main(string[] args)
    {
        // Welcome user
        Console.WriteLine("Hello! Welcome to Prep2!");

        // define important variables
        int userGradeNum = 0;
        string letter;
        string sign;
        bool digit = false;

        // get grade value from user (check for value error and correct it)
        while (!digit)
        {
            try
            {
                Console.Write("Enter your grade percentage: ");
                userGradeNum = int.Parse(Console.ReadLine());
                digit = true;
            }
            catch (Exception errorMsg)
            {
                Console.WriteLine(errorMsg);
                Console.WriteLine("Invalid Entry. Numbers only (Do not include the % sign)");
                digit = false;
            }
        }

        // use grade value to determine grade later and display it back to the user
        if (userGradeNum >= 90)
        {
            letter = "A";
        }
        else if (userGradeNum >= 80)
        {
            letter = "B";
        }
        else if (userGradeNum >= 70)
        {
            letter = "C";
        }
        else if (userGradeNum >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        // get letter sign of + or - (last-digit > 7 = +; last-digit < 3 = -; else no-sign)
        int lastDigit = userGradeNum % 10;
        if (lastDigit >= 7 && userGradeNum < 90 && userGradeNum >= 60)
        {
            sign = "+";
        }
        else if (lastDigit < 3 && userGradeNum >= 60)
        {
            sign = "-";
        }
        else
        {
            sign = "";
        }

        // use grade value to determine if user pass the class
        // assuming the cutoff score is 70 at least
        if (userGradeNum >= 70)
        {
            Console.WriteLine($"Congratulations! You Scored {letter}{sign}! This is a good grade.\n You pass the class.");
        }
        else
        {
            Console.WriteLine($"So sorry you scored {letter}{sign}, this is not a good grade.\n Try to work harder next time, I'm sure you'll pass if you do so.");
        }
    }
}