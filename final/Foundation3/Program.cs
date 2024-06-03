using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();  // clear previous texts

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(">>>>>>>>>>>>>>>>Welcome to Danism Event Panner!<<<<<<<<<<<<<<<<<<<<<<<<");

        Console.ForegroundColor = ConsoleColor.Blue;
        // In each event display their marketing messages
        Console.WriteLine("\t\t\tAll EVENTS");
        int count = 1;

        // Lecture Event (Institute Class Opening)
        // creating a venue address
        Address instituteClassOpeningVenue = new Address("Ikpokpan St, Oka", "Benin City", "Edo", "Nigeria");
        LectureEvent instituteClassOpening = new LectureEvent("Institute Class Opening", "come and enjoy the awesome gathering of institute students. Have fun and learn at same time.", "June 15th, 2024", "3:00pm", instituteClassOpeningVenue, "Brother Ojulary", 100);
        // Display Event marketing message
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("------------------------------------------------------");
        Console.WriteLine($"\t\t\tEvent {count}");
        Console.WriteLine("------------------------------------------------------");
        // display short description
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Short Description");
        Console.ForegroundColor = ConsoleColor.Green;
        instituteClassOpening.DisplayShortDescription();
        Console.WriteLine();  // for spacing purpose
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Full Description");
        Console.ForegroundColor = ConsoleColor.Green;
        instituteClassOpening.DisplayFullDetails();
        Console.WriteLine();  // for spacing purpose
        count++;

        // Reception Event (Brother and Sister Opute's Wedding)
        // creating a venue address
        Address oputeWeddingVenue = new Address("Okada Avenue", "Benin City", "Edo", "Nigeria");
        ReceptionEvent oputeWedding = new ReceptionEvent("most decent anonymous wed Gabriel Chukwuyenum Opute", "welcome to the wedding ceremony of Most Decent Anonymous and Gabriel Chukwuyenum Opute. a blessed union.", "Feb 14th, 2025", "10am", oputeWeddingVenue, "danielcopute@gmail.com");
        // Display Event marketing message
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("------------------------------------------------------");
        Console.WriteLine($"\t\t\tEvent {count}");
        Console.WriteLine("------------------------------------------------------");
        // display short description
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Short Description");
        Console.ForegroundColor = ConsoleColor.Green;
        oputeWedding.DisplayShortDescription();
        Console.WriteLine();  // for spacing purpose
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Full Description");
        Console.ForegroundColor = ConsoleColor.Green;
        oputeWedding.DisplayFullDetails();
        Console.WriteLine();  // for spacing purpose
        count++;

        // Outdoor Event (Stake Picnic)
        // creating a venue address
        Address ikpokpanStakePicnicVenue = new Address("no 9, philip temile street, off airport Rd, obazagbon", "benin city", "edo state", "nigeria");
        OutdoorEvent ikpokpanStakePicnic = new OutdoorEvent("Ikpokpan Stake Family Picnic", "Lets enjoy wholesome recreational activities with our families uniting with the saints.", "August 20th, 2024", "12pm", ikpokpanStakePicnicVenue, "28℃ sunny all day");
        // Display Event marketing message
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("------------------------------------------------------");
        Console.WriteLine($"\t\t\tEvent {count}");
        Console.WriteLine("------------------------------------------------------");
        // display short description
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Short Description");
        Console.ForegroundColor = ConsoleColor.Green;
        ikpokpanStakePicnic.DisplayShortDescription();
        Console.WriteLine();  // for spacing purpose
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Full Details");
        Console.ForegroundColor = ConsoleColor.Green;
        ikpokpanStakePicnic.DisplayFullDetails();
        Console.WriteLine();  // for spacing purpose
        count++;
    }
}