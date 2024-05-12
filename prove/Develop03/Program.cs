using System;
using System.IO;
using System.Linq.Expressions;
using System.Reflection.Metadata;

class Program
{
    static void Main(string[] args)
    {   
        // Change Console Text Color
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("\t*** ---Welcome To Danism Scripture Memorizer--- ***");
        string optionMsg1 = "1. Memorize\n2. Customize\n3. About\n4. Quit";
        string optionMsg11 = "1. Select\n2. Pick Random\n3. Back";
        string optionMsg2 = "1. Add Scripture\n2. Create File\n3. Back";
        
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
                Console.WriteLine("Invalid Choice: Numbers only.");
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
                        Console.WriteLine("Invalid Choice: Numbers only.");
                    }
                    catch (Exception error)
                    {
                        Console.WriteLine($"Uncaught Error: {error}");
                    }
                    // validate choice
                    if (userChoice == 1)
                    {
                        // Open Select scripture menu
                        while(true)
                        {
                            try
                            {
                                // Create the load scripture object
                                FileHandler LoadScriptureFile = new FileHandler();
                                LoadScriptureFile.DisplayDirectories(); // display directory options available to user
                                Console.Write("Choice: ");
                                userChoice = int.Parse(Console.ReadLine());
                                string dirName = LoadScriptureFile.getDirName(userChoice);  // get directory name from user choice
                                LoadScriptureFile.LoadDirectories(dirName);  // load files in the directory
                                Console.WriteLine();  // for spacing purpose
                                while(true)
                                {
                                    try
                                    {
                                        bool isEmpty = LoadScriptureFile.DisplayFiles();  // display the files in the directory
                                        if (isEmpty)
                                        {
                                            break;
                                        }
                                        else
                                        {
                                            Console.Write("Choice: ");
                                            userChoice = int.Parse(Console.ReadLine());
                                            string fileName = LoadScriptureFile.getFileName(userChoice);
                                            LoadScriptureFile.LoadFromFile(fileName);
                                            Console.WriteLine();  // for spacing purpose
                                            while(true)
                                            {
                                                try
                                                {
                                                    LoadScriptureFile.DisplayFileContent();
                                                    Console.Write("Choice a Scripure: ");
                                                    userChoice = int.Parse(Console.ReadLine());
                                                    string[] aScripture = LoadScriptureFile.GetALine(userChoice);
                                                    // call the scripure function to begin memorizing.
                                                    RunScripture(aScripture);
                                                    userChoice = 0;
                                                    break;
                                                }
                                                catch (FormatException)
                                                {
                                                    Console.WriteLine("Invalid Choice: Numbers only. Please enter a number from the options above");
                                                }
                                                catch (Exception)
                                                {
                                                    Console.WriteLine("Invalid Choice: Please select a number from the options above");
                                                }
                                                break;
                                            }
                                        }
                                        break;
                                    }
                                    catch (FormatException)
                                    {
                                        Console.WriteLine("Invalid Choice: Numbers only. Please enter a number from the options above");
                                    }
                                    catch (Exception)
                                    {
                                        Console.WriteLine("Invalid Choice: Please select a number from the options above");
                                    }
                                    break;
                                }
                                break;
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Invalid Choice: Numbers only. Please choose from the available options above");
                            }
                            catch (Exception)
                            {
                                Console.WriteLine($"Invalid Choice: Please choose fromt he options available");
                            }
                        }
                    }
                    else if (userChoice == 2)
                    {
                        // Pick a random scripture
                        while(true)
                        {
                            try
                            {
                                // Create the load scripture object
                                FileHandler LoadScriptureFile = new FileHandler();
                                LoadScriptureFile.DisplayDirectories(); // display directory options available to user
                                Console.Write("Choice: ");
                                userChoice = int.Parse(Console.ReadLine());
                                string dirName = LoadScriptureFile.getDirName(userChoice);  // get directory name from user choice
                                LoadScriptureFile.LoadDirectories(dirName);  // load files in the directory
                                Console.WriteLine();  // for spacing purpose
                                while(true)
                                {
                                    try
                                    {
                                        bool isEmpty = LoadScriptureFile.DisplayFiles();  // display the files in the directory
                                        if (isEmpty)
                                        {
                                            break;
                                        }
                                        else
                                        {
                                            Random randomNum = new();
                                            int choice = randomNum.Next(1, LoadScriptureFile.GetCount());
                                            string fileName = LoadScriptureFile.getFileName(choice);
                                            LoadScriptureFile.LoadFromFile(fileName);
                                            Console.WriteLine();  // for spacing purpose
                                            while(true)
                                            {
                                                try
                                                {
                                                    choice = randomNum.Next(1, LoadScriptureFile.GetCount());
                                                    string[] aScripture = LoadScriptureFile.GetALine(choice);
                                                    // call the scripure function to begin memorizing.
                                                    RunScripture(aScripture);
                                                    userChoice = 0;
                                                    break;
                                                }
                                                catch (FormatException)
                                                {
                                                    Console.WriteLine("Invalid Choice: Numbers only. Please enter a number from the options above");
                                                }
                                                catch (Exception)
                                                {
                                                    Console.WriteLine("Invalid Choice: Please select a number from the options above");
                                                }
                                                break;
                                            }
                                        }
                                        break;
                                    }
                                    catch (FormatException)
                                    {
                                        Console.WriteLine("Invalid Choice: Numbers only. Please enter a number from the options above");
                                    }
                                    catch (Exception)
                                    {
                                        Console.WriteLine("Invalid Choice: Please select a number from the options above");
                                    }
                                    break;
                                }
                                break;
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Invalid Choice: Numbers only. Please choose from the available options above");
                            }
                            catch (Exception)
                            {
                                Console.WriteLine($"Invalid Choice: Please choose fromt he options available");
                            }
                        }
                    }
                    else if (userChoice == 3)
                    {
                        // move backward
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
                while(true)
                {
                    try
                    {
                        Console.WriteLine($"{optionMsg2}");
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
                        // display all saved files in customized directory.
                        // Create the load scripture object
                        FileHandler LoadScriptureFile = new FileHandler();
                        string dirName = LoadScriptureFile.getDirName(1);  // get directory name for customize directory
                        LoadScriptureFile.LoadDirectories(dirName);  // load files in the directory
                        Console.WriteLine();  // for spacing purpose
                        while(true)
                        {
                            try
                            {
                                bool isEmpty = LoadScriptureFile.DisplayFiles();  // display the files in the directory
                                if (isEmpty)
                                {
                                    break;
                                }
                                else
                                {
                                    Console.Write("Choice: ");
                                    userChoice = int.Parse(Console.ReadLine());
                                    string fileName = LoadScriptureFile.getFileName(userChoice);
                                    LoadScriptureFile.LoadFromFile2(fileName);
                                    Console.WriteLine();  // for spacing purpose
                                    while(true)
                                    {
                                        try
                                        {
                                            LoadScriptureFile.DisplayFullContent();
                                            Console.WriteLine("\nAdd New Scripture");
                                            Console.Write("Enter Book-Title: ");
                                            string book = Console.ReadLine();
                                            int chapter;
                                            int verse;
                                            int endVerse;
                                            while(true)
                                            {
                                                try
                                                {
                                                    Console.Write("Chapter: ");
                                                    chapter = int.Parse(Console.ReadLine());
                                                    break;
                                                }
                                                catch (Exception)
                                                {
                                                    Console.WriteLine("Invalid Entry: Numbers only");
                                                }
                                            }
                                            while(true)
                                            {
                                                try
                                                {
                                                    Console.Write("Verse(start/only): ");
                                                    verse = int.Parse(Console.ReadLine());
                                                    break;
                                                }
                                                catch (Exception)
                                                {
                                                    Console.WriteLine("Invalid Entry: Numbers only");
                                                }
                                            }
                                            while(true)
                                            {
                                                try
                                                {
                                                    Console.WriteLine("Enter zero(0) if no end verse");
                                                    Console.Write("End-verse: ");
                                                    endVerse = int.Parse(Console.ReadLine());
                                                    break;
                                                }
                                                catch (Exception)
                                                {
                                                    Console.WriteLine("Invalid Entry: Numbers only");
                                                }
                                            }
                                            Console.WriteLine("Scriptural-Text");
                                            Console.Write(">: ");
                                            string scripturalText = Console.ReadLine();
                                            // Write to file
                                            if (endVerse > 0)
                                            {
                                                LoadScriptureFile.WriteToFile(fileName, book, chapter, verse, endVerse, scripturalText);
                                            }
                                            else
                                            {
                                                LoadScriptureFile.WriteToFile(fileName, book, chapter, verse, scripturalText);
                                            }
                                            userChoice = 0;
                                            break;
                                        }
                                        catch (FormatException)
                                        {
                                            Console.WriteLine("Invalid Choice: Numbers only. Please enter a number from the options above");
                                        }
                                        catch (Exception)
                                        {
                                            Console.WriteLine("Invalid Choice: Please select a number from the options above");
                                        }
                                        break;
                                    }
                                }
                                break;
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Invalid Choice: Numbers only. Please enter a number from the options above");
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Invalid Choice: Please select a number from the options above");
                            }
                            break;
                        }
                    }
                    else if (userChoice == 2)
                    {
                        // ask user for a filename to create.
                        Console.WriteLine("---CUSTOMIZE--");
                        // display all saved files in customized directory.
                        // Create the load scripture object
                        FileHandler LoadScriptureFile = new FileHandler();
                        string dirName = LoadScriptureFile.getDirName(1);  // get directory name for customize directory
                        LoadScriptureFile.LoadDirectories(dirName);  // load files in the directory
                        Console.WriteLine();  // for spacing purpose
                        // Display Files in Directory
                        LoadScriptureFile.DisplayFiles();
                        Console.WriteLine();  // for spacing purpose
                        Console.WriteLine("--Create New File--");
                        Console.Write("Filename: ");
                        string filename = Console.ReadLine();
                        // create file
                        LoadScriptureFile.CreateFile(filename);
                    }
                    else if (userChoice == 3)
                    {
                        // send backward
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Choice! Please choose from the available options above");
                    }
                }
                
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
                Console.WriteLine("Invalid Choice! Please choose from the available options");
            }
        }


        static void RunScripture(string[] selectedScripture)
        {
            // getting scripture
            string book = selectedScripture[0];
            int chapter = int.Parse(selectedScripture[1]);
            string verse = selectedScripture[2];
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
            string text = selectedScripture[3];
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