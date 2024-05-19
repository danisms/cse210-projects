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
                    // clear console
                    Console.Clear();
                    // Enter Breathing Activity
                    string description = "This activity will help you reflect on times in your life when you have shown strength and resilience.\nThis will help you recognize the power you have and how you can use it in other aspects of your life.";

                    List<string> prompts = new List<string>();
                    prompts.Add("Think of a time when you stood up for someone else.");
                    prompts.Add("Think of a time when you did something really difficult.");
                    prompts.Add("Think of a time when you helped someone in need.");
                    prompts.Add("Think of a time when you did something truly selfless.");

                    List<string> questions = new List<string>();
                    questions.Add("Why was this experience meaningful to you?");
                    questions.Add("Have you ever done anything like this before?");
                    questions.Add("How did you get started?");
                    questions.Add("How did you feel when it was complete?");
                    questions.Add("What made this time different than other times when you were not as successful?");
                    questions.Add("What is your favorite thing about this experience?");
                    questions.Add("What could you learn from this experience that applies to other situations?");
                    questions.Add("What did you learn about yourself through this experience?");
                    questions.Add("How can you keep this experience in mind in the future?");

                    ReflectingActivity reflect = new ReflectingActivity("Reflect", description, prompts, questions);

                    // Display stating message
                    reflect.DisplayStatingMessage();

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
                                reflect.SetDuration(duration);
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
                    reflect.Run();
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