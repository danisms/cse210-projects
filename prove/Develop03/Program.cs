using System;
using System.IO;
using System.Reflection.Metadata;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("\t*** ---Welcome To Danism Scripture Memorizer--- ***");
        string optionMsg1 = "1. Memorize\n2. Customize\n3. About\n4. Quit";
        string optionMsg11 = "1. Select\n2. Pick Random\n3. Back\n4. Quit";
        string optionMsg111 = "1. Doctrinal Mastery\n 2. Customized";
        string optionMsg1111 = "1. Book of Mormon\n2. New Testament\n3. Old Testament\n4. Doctrine & Covenant";
        string optionMsg12 = "1. Doctrinal Mastery\n 2.Customized";

        // Display menu
        while(true)
        {
            int userChoice = 0;
            try
            {
                Console.WriteLine($"{optionMsg1}\n");
                Console.Write("What do you want to do?: ");
                userChoice = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid Choice: Numbers only. Please choose from the available options above");
            }
            catch (Exception error)
            {
                Console.WriteLine($"Uncaught Error: {error}");
            }
            // validate choice
            if (userChoice == 1)
            {
                // Display Memorizer Menu
                while(true)
                {
                    try
                    {
                        Console.WriteLine($"{optionMsg11}\n");
                        Console.Write("What do you want to do?: ");
                        userChoice = int.Parse(Console.ReadLine());
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Invalid Choice: Numbers only. Please choose from the available options above");
                    }
                    catch (Exception error)
                    {
                        Console.WriteLine($"Uncaught Error: {error}");
                    }
                    // validate choice
                    if (userChoice == 1)
                    {
                        // Display Memorizer Menu
                        
                    }
                    else if (userChoice == 2)
                    {
                        // Display Customize Menu
                    }
                    else if (userChoice == 3)
                    {
                        // Display About
                    }
                    else if (userChoice == 4)
                    {
                        Console.WriteLine("Sad to see you leave. Bye See you some other time");
                        break;
                    }
                    else {
                        Console.WriteLine("Invalid Choice! Please choose from the available options above");
                    }
                }
            }
            else if (userChoice == 2)
            {
                // Display Customize Menu
            }
            else if (userChoice == 3)
            {
                // Display About
            }
            else if (userChoice == 4)
            {
                Console.WriteLine("Sad to see you leave. Bye See you some other time");
                break;
            }
            else {
                Console.WriteLine("Invalid Choice! Please choose from the available options above");
            }
        }


        static void RunScripture(int selectedLineNum, LoadFile fileLoader)
        {
            string[] selectedLine = fileLoader.GetALine(selectedLineNum);

            // getting scripture
            string book = selectedLine[0];
            int chapter = int.Parse(selectedLine[1]);
            string verse = selectedLine[2];
            // check if verse is more than one verses.
            string [] splittedVerse = verse.Split("-");

            // Instantiate Reference
            Reference aReference;
            if (splittedVerse.Length > 1)
            {
                aReference = new Reference(book, chapter, int.Parse(splittedVerse[0]), int.Parse(splittedVerse[1]));
            }
            else {
                aReference = new Reference(book, chapter, int.Parse(splittedVerse[0]));
            }
            // get scriptural text
            string text = selectedLine[3];
            Scripture scripture = new Scripture(aReference, text);

            string displayScripture = scripture.GetDisplayText();
            Console.WriteLine(displayScripture);
            // continue to display text value till user types quit or all words are hidden
            bool endTask = false;
            while (!endTask)
            {
                Console.WriteLine("\nEnter 'quit' to end the program or press 'enter' to continue");
                Console.Write(">: ");
                string response = Console.ReadLine();

                if (response == "" && scripture.IsCompletelyHidden() == false)
                {
                    // continue hiding words
                    Console.WriteLine("Hide Words");
                    // hide a random word
                    scripture.HideRandomWords();
                    displayScripture = scripture.GetDisplayText();
                    Console.Clear();
                    Console.WriteLine(displayScripture);
                }
                else if (response == "quit")
                {
                    // end the program
                    Console.WriteLine("\nI'm not sure why you're quitting🤔, quitters never win.😔");
                    while (true)
                    {
                        Console.Write("Are you sure you want to quit?['yes', 'no']: ");
                        string quit = Console.ReadLine();
                        if (quit.ToLower() == "yes" || quit.ToLower() == "y")
                        {
                            endTask = true;
                            Console.WriteLine("\nIt was great having you here.😊");
                            // Console.WriteLine("Program Ends Successfully.");
                            break;
                        }
                        else if (quit.ToLower() == "no" || quit.ToLower() == "n")
                        {
                            Console.WriteLine("\n🙌I knew you are not a quitter!😁 I'm so happy you didn't quit.\n");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("☹️Invalid Response: Enter a 'Yes' or 'No'");
                        }
                    }
                }
                else if (response == "" && scripture.IsCompletelyHidden())
                {
                    // end the program

                    Console.WriteLine("\nGreat job reaching this point!🎉🙏 I hope you've memorized it!😊\n");
                    break;
                }
                else
                {
                    Console.WriteLine("☹️Invalid Response, please read the options bellow.\n");
                }

            }
        }
    }
        
}