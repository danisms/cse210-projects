public class BreathingActivity : Activity
{
    public BreathingActivity(string name, string description) : base(name, description)
    {

    }

    public void Run()
    {
        List<int> breathTiming = new List<int>();
        breathTiming.Add(3);
        breathTiming.Add(4);
        breathTiming.Add(5);
        breathTiming.Add(6);

        int getRandomTiming()
        {
            Random getRandomNum = new Random();
            int randomNum = getRandomNum.Next(0, breathTiming.Count);
            int countTimer = breathTiming[randomNum];
            return countTimer;
        }

        // display animation
        Console.Clear();
        Console.Write("Get ready...");
        base.ChooseRandomAnimation(getRandomTiming());
        Console.WriteLine();  // for spacing purpose
        // check timing
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(GetDuration());
        while (DateTime.Now < endTime)
        {
            Console.WriteLine();  // for spacing purpose;
            Console.Write("Breath In...");
            base.ShowCountDown(getRandomTiming());
            Console.WriteLine();  // for spacing
            Console.Write("Now Breath Out...");
            base.ShowCountDown(getRandomTiming());
            Console.WriteLine(); // for line breaking purpose
        }
        // display end message
        base.DisplayEndingMessage();
        Thread.Sleep(3000);
        Console.Clear();
    }
}