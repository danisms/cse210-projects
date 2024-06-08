using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine(">>>>>>>>>>>>>>>WELCOME TO DANISM FITNESS<<<<<<<<<<<<<<<");

        // create all activity list to store all activities
        List<Activity> allActivities = new List<Activity>();

        // create a running activity
        RunningActivity danielRun = new RunningActivity("04 June 2024", 30, 4.8);
        allActivities.Add(danielRun);
        // create a cycling activity
        CyclingActivity danielCycling = new CyclingActivity("06 July 2024", 30, 9.6);
        allActivities.Add(danielCycling);
        // create a swimming activity
        SwimmingActivity danielSwimming = new SwimmingActivity("10 August 2024", 30, 96);
        allActivities.Add(danielSwimming);

        // Display each activity in all activity list
        int count = 1;
        foreach (Activity activity in allActivities)
        {
            // Display Header
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine($"\t\t\tActivity {count}");
            Console.WriteLine("------------------------------------------------------");
            activity.GetSummary();
            // Console.WriteLine(activitySummary);
            Console.WriteLine();  // for spacing purpose;
            // increment count
            count++;
        }


    }
}