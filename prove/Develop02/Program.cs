using System;
using System.Reflection.Metadata;
using System.IO;

/* 
EXCEED REQUIREMENT
1. I added an Edit to the options that allows the user to edit their entries
2. I handled all exceptions to make sure the program doesn't crash or exit without the user intent.
3. I added more the prompt questions.
4. I added an algorithm in the GeneratePrompt Method under the PromptGenerator class that produces unique prompts.
5. I added prompts that inform user about the file they are saving or loading. This prompts inform the user
    if the file exit or not and if they would want to override and existing file or not.
*/
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Danism Journal Project\n");

        // Start the program
        int userOpt = 0;
        string promptMsg = "1. Write\n2. Display\n3. Edit\n4. Load\n5. Save\n6. Quit\n";
        // create an instance of a journal class
        Journal journal = new Journal();

        //create and load prompt questions into PromptGenerator Class
        PromptGenerator generatePrompt = new PromptGenerator
        {
            _prompts = ["What was the most interesting fact you learned today?",
                                "What inspiration did you receive today?",
                                "Who's words or actions touched your heart/life today?",
                                "How were you a blessing to the life of someone today?",
                                "What goal did you accomplish today?",
                                "What new records have been set today?",
                                "What took the most of your time today?",
                                "Who was the most interesting person I interacted with today?",
                                "What was the best part of my day?",
                                "How did I see the hand of the Lord in my life today?",
                                "What was the strongest emotion I felt today?",
                                "If I had one thing I could do over today, what would it be?"]
        };

        while (true)
        {
            try
            {
                Console.WriteLine(promptMsg);
                Console.Write("What would you like to do?: ");
                userOpt = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid Entry: Numbers Only\n");
            }
            catch (Exception err)
            {
                Console.WriteLine($"Error: {err}\n");
            }
            // user user option
            if (userOpt == 1)  // write
            {
                Console.WriteLine("-----------------------");
                Console.WriteLine("WRITE [ADD TO JOURNAL]");
                Console.WriteLine("-----------------------\n");

                // generate random prompt question
                string promptQuestion = generatePrompt.GetRandomPrompt();
                Console.WriteLine(promptQuestion);
                Console.Write(">: ");
                string userEntry = Console.ReadLine();
                // store user entry and prompt question
                Entry singleEntry = new Entry();
                singleEntry._promptText = promptQuestion;
                singleEntry._entryText = userEntry;
                // get current date and time
                DateTime currentDate = DateTime.Now;
                string dateText = currentDate.ToString("ddd-dd/MM/yyyy - h:mm:ss:tt");
                // Console.WriteLine(dateText);  // for testing purpose
                singleEntry._date = dateText;
                // add entry to journal entry list
                journal.AddEntry(singleEntry);
                Console.WriteLine();  // for spacing purpose;
            }
            else if (userOpt == 2)  // display
            {
                Console.WriteLine("------------------------");
                Console.WriteLine("DISPLAY [ALL ENTRIES]");
                Console.WriteLine("------------------------\n");
                journal.DisplayAllEntries();
            }
            else if (userOpt == 3)// edit 
            {
                Console.WriteLine("-----------------------------");
                Console.WriteLine("EDIT [SELECT AND EDIT ENTRY]");
                Console.WriteLine("-----------------------------\n");

                // display all entries for selection
                journal.DisplaySelectEntry();
                // get the number to edit
                int editNum;
                while (true)
                {
                    try
                    {
                        // verify edit number selected by the user is in the entry list
                        while (true)
                        {
                            Console.Write("Entry Number[0 to quit]: ");
                            editNum = int.Parse(Console.ReadLine());
                            if ((editNum > 0 && editNum <= journal.EntriesLength()) || editNum == 0)
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Invalid-Number: Please, select a number from the list of entries");
                            }
                        }
                        if (editNum > 0)
                        {
                            Console.Write("Edit-Response: ");
                            string editText = Console.ReadLine();
                            // edit entry
                            journal.EditEntry(editNum, editText);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("");  // for spacing purpose
                            break;
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Invalid Entry: Number only");
                    }
                    catch (Exception err)
                    {
                        Console.WriteLine($"Error: {err}");
                    }
                }

            }
            else if (userOpt == 4) // load
            {
                Console.WriteLine("---------------------");
                Console.WriteLine("LOAD [CHOOSE A FILE]");
                Console.WriteLine("---------------------\n");
                Console.Write("Enter Filename to Load: ");
                string filename = Console.ReadLine();
                journal.LoadFromFile(filename);
            }
            else if (userOpt == 5)  // save
            {
                Console.WriteLine("-----------------------");
                Console.WriteLine("SAVE [ENTRIES TO FILE]");
                Console.WriteLine("-----------------------\n");

                // check if a file has been loaded.
                if (journal._filename == null)  // if not loaded
                {
                    Console.Write("Enter Filename: ");
                    string filename = Console.ReadLine();
                    // save the file
                    journal.SaveToFile(filename);
                }
                else
                {
                    // save to current loaded file
                    journal.SaveToFile(journal._filename);
                }
            }
            else if (userOpt == 6)
            {
                Console.WriteLine("You're about to exit program, please make sure you save or new entires and changes made");
                Console.WriteLine("Do you want to proceed to Exit? ");
                Console.Write("1. Yes\n2. No\n>: ");
                int proceedExit = int.Parse(Console.ReadLine());
                if (proceedExit == 1)
                {
                    Console.WriteLine("---------------------------------");
                    Console.WriteLine("EXIT [PROGRAM EXIT SUCCESSFULLY]");
                    Console.WriteLine("---------------------------------\n");
                    Console.WriteLine("Bye! See you soon.\n");
                    // end the program
                    break;
                }
                else
                {
                    Console.WriteLine("");  // for spacing purpose
                }
            }
            else
            {
                Console.WriteLine("Please choose a number from the options provided\n");
            }
        }
    }
}

// approx. sour12.