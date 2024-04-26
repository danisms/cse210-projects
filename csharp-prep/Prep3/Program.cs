using System;
using System.Diagnostics.CodeAnalysis;

class Program
{
    static void Main(string[] args)
    {
        // Welcome user
        Console.WriteLine("Hello! Welcome to Prep3, the Guess and win Game!");

        // Design a guess and win game
        // step 1: computer generates a random number
        Random genRandomNum = new();
        int luckyNum = genRandomNum.Next(1, 100);

        // step 2: get, track and validate user guess value
        int userGuess = 0;
        int guessesMade = 0;
        // validate user guess using a function
        void GetUserGuess()
        {
            do
            {
                try
                {
                    Console.Write("What is the magic number? ");
                    userGuess = int.Parse(Console.ReadLine());
                    break;
                }
                catch (Exception excError)
                {
                    Console.WriteLine(excError);
                    Console.WriteLine("Invalid input: Whole numbers only.");
                }
            } while (true);
        }

        // step 3: compare userGuess value with genRandomNum and report to user
        while (luckyNum != userGuess)
        {
            Console.WriteLine($"Lucky-Number: {luckyNum}");  // for testing purpose;
            GetUserGuess();
            // increment guesses made by one;
            guessesMade++;
            // check if lucky-number matches user-guess
            if (luckyNum > userGuess)
            {
                Console.WriteLine("Pick a Higher number");
            }
            else if (luckyNum < userGuess)
            {
                Console.WriteLine("Pick a lower number");
            }
            else
            {
                // display congratulation message according to the number of attempts made
                if (guessesMade == 1)
                {
                    Console.WriteLine($"Congratulation! You guessed it correctly after {guessesMade} valid attempt.");
                    Console.WriteLine("That is miraculous!");
                }
                else
                {
                    Console.WriteLine($"Congratulation! You guessed it correctly after {guessesMade} valid attempts.");
                }

                Console.WriteLine($"The Lucky Number is: {luckyNum}");
                // step 4: request user to play gain or end the game
                bool playAgainValidResponse = false;
                while (!playAgainValidResponse)
                {
                    Console.Write("/nDo you want to play again?['yes'/'no']: ");
                    string playAgain = Console.ReadLine();

                    // verify user response
                    string[] yesResponse = ["yes", "Yes", "YES", "y", "Y"];
                    string[] noResponse = ["no", "No", "NO", "n", "N"];
                    foreach (string yesRespond in yesResponse)
                    {
                        if (playAgain == yesRespond)
                        {
                            // reset values to default
                            userGuess = 0;
                            guessesMade = 0;
                            luckyNum = genRandomNum.Next(1, 100);
                            // end play again while loop
                            playAgainValidResponse = true;
                            break;  // end foreach loop
                        }
                        else
                        {
                            // pass
                        }
                    }
                    // check if play gain valid response is not true;
                    if (!playAgainValidResponse)
                    {
                        foreach (string noRespond in noResponse)
                        {
                            if (playAgain == noRespond)
                            {
                                Console.WriteLine("Thanks for playing. Hope to see you later sometimes.");
                                playAgainValidResponse = true;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Invalid Entry: Enter a yes or no answer.");
                                break;
                            }
                        }
                    }
                    else
                    {
                        // pass
                    }
                }
            }
        }
    }
}