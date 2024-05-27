/* Exceed Requirements
    1. I added a reward menu which contain 3 options which is to add a score reward, view reward, and record reward.
    2. I added an option to allow user add a reward to each goal they set, including a bonus reward to checklist goals.
    3. I try to make sure all exceptions is handled correctly.
    4. This few and other I've added sofar.
*/

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("\t--- *Welcome To Eternal Quest!* ---");
        // create goal Manager object
        GoalManager eternalQuest = new GoalManager();
        // start goal manager
        eternalQuest.Start();
    }
}

// Danism - 27 - 05 - 24 - 23 - 41 