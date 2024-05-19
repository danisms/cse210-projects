using System;

class Program
{
    static void Main(string[] args)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Clear();
        Console.WriteLine("Welcome To Danism Mindfulness");
        // create menu display message/options.
        string optionMsg = "1. Start breathing activity\n2. Start reflecting activity\n3. Start listing activity\n4. Quit";
        // display option message
        while (true)
        {
            Console.WriteLine();  // for spacing
            Console.WriteLine(optionMsg);
            try
            {
                Console.Write("\nSelect a choice from the menu: ");
                int userChoice = int.Parse(Console.ReadLine());
                if (userChoice == 1)
                {
                    // clear console
                    Console.Clear();
                    // Enter Breathing Activity
                    string description = "This activity will help you relax by walking you through breathing in and out slowly.\nClear your mind and focus on your breathing.";
                    BreathingActivity breathing = new BreathingActivity("Breathing", description);

                    // Display stating message
                    breathing.DisplayStatingMessage();

                    // get and set activity duration
                    while (true)
                    {
                        Console.WriteLine();  // for spacing
                        Console.WriteLine("Please Note: A section should be between 10 seconds and above");
                        Console.Write("How long, in seconds, would you like for your session?: ");
                        try
                        {
                            int duration = int.Parse(Console.ReadLine());
                            if (duration >= 10)
                            {
                                // set duration
                                breathing.SetDuration(duration);
                                break;
                            }
                            else
                            {
                                Console.WriteLine("A section cannot be less than 10 seconds.");
                            }
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Invalid Entry: Numbers only.");
                        }
                        catch (Exception error)
                        {
                            Console.WriteLine(error);
                        }
                    }

                    // run breathing activity
                    breathing.Run();
                }
                else if (userChoice == 2)
                {
                    // Enter Reflection Activity
                }
                else if (userChoice == 3)
                {
                    // Enter Listing Activity
                }
                else if (userChoice == 4)
                {
                    Console.WriteLine();  // for spacing
                    Console.WriteLine("Thanks for visiting! Bye!");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice: Please choose from the options provided.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid Entry: Numbers only.");
            }
            catch (Exception error)
            {
                Console.WriteLine(error);
            }
        }
    }
}