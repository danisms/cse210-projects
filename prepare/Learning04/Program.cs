using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello! Welcome to Learning04!");
        Assignment student1 = new Assignment("Daniel", "Integration");
        string student1Summary = student1.GetSummary();
        Console.WriteLine(student1Summary);
        // check math assignment class
        MathAssignment student1Math = new MathAssignment("Daniel", "Integration", "2.4", "4-8");
        string student1MathAssList = student1Math.GetHomeworkList();
        string student1MathSummary = student1Math.GetSummary();
        Console.WriteLine(student1MathSummary);
        Console.WriteLine(student1MathAssList);
        // check writing assignment class
        WritingAssignment student1Writing = new WritingAssignment("Daniel", "Demogracy", "The freedom of my country");
        Console.WriteLine(student1Writing.GetSummary());
        Console.WriteLine(student1Writing.GetWritingInformation());
    }
}