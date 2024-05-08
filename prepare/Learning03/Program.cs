using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello! Welcome to Learning03!");
        // Create a new object of the fraction class and set values as needed
        Fraction fraction1 = new Fraction();
        Fraction fraction2 = new Fraction(1);
        Fraction fraction3 = new Fraction(3, 4);

        // Get Values

        // fraction 1
        string fraction1Value = fraction1.GetFractionString();
        Console.WriteLine(fraction1.GetFractionString());
        Console.WriteLine(fraction1.GetDecimalValue());
        // fraction 2
        Console.WriteLine(fraction2.GetFractionString());
        Console.WriteLine(fraction2.GetDecimalValue());
        // fraction 3
        Console.WriteLine(fraction3.GetFractionString());
        Console.WriteLine(fraction3.GetDecimalValue());
        
        // try getters
        Console.WriteLine(fraction1.GetBottom());
        Console.WriteLine(fraction2.GetTop());

        // try setters
        fraction1.SetBottom(2);
        Console.WriteLine(fraction1Value);
        Console.WriteLine(fraction1.GetFractionString());
        Console.WriteLine(fraction1.GetDecimalValue());

        fraction2.SetTop(1);
        fraction2.SetBottom(3);
        Console.WriteLine(fraction2.GetFractionString());
        Console.WriteLine(fraction2.GetDecimalValue());
    }
}