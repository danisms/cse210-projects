using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hey! I'm Learning02!");

        // Testing Job Class
        // creating a Job instance (instantiating job1)
        Job job1 = new Job();
        job1._jobTitle = "Software Engineer";
        job1._companyName = "Microsoft";
        job1._startDate = 2019;
        job1._endDate = 2022;
        // Console.WriteLine(job1._jobTitle);  // for testing purpose
        // job1.DisplayJobDetail();  // for testing purpose;

        // instantiating job2
        Job job2 = new Job();
        job2._jobTitle = "Manager";
        job2._companyName = "Apple";
        job2._startDate = 2022;
        job2._endDate = 2023;
        // Console.WriteLine(job2._companyName);  // for testing purpose
        // job2.DisplayJobDetail();  // for testing purpose

        // Testing Resume Class
        Resume myResume = new Resume();  // create an object instance of the Resume Class
        myResume._userName = "Daniel Opute";  // assigning value the the instance of the class
        myResume._jobs.Add(job1);   // assign value to a list value in the instance of the class
        myResume._jobs.Add(job2);  // same
        // displaying myResume instance of the the Resume class by calling the Display method in the class
        myResume.DisplayResume();
    }
}