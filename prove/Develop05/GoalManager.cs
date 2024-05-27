using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.JavaScript;
using System.Runtime.CompilerServices;
using System.Diagnostics.Tracing;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private List<PointReward> _pointRewards = new List<PointReward>();
    private int _score;

    // Constructor
    public GoalManager()
    {
        _score = 0;
    }

    // Methods
    public void Start()
    {
        string menuOptions = "Menu Options:\n  1. Create New Goal\n  2. List Goals\n  3. Save Goals\n  4. Load Goals\n  5. Record Event\n  6. My Reward\n  7. Quit";
        int userChoice = 0;

        while (true)
        {
            // record point earned reward if any
            RecordEarnReward();

            // check if user choice is a number
            bool isNumber = true;

            // display user score value
            Console.WriteLine("\n---------------------------------------");
            Console.WriteLine($"You have {DisplayPlayerInfo()} points");
            Console.WriteLine("---------------------------------------");
            try
            {
                Console.WriteLine($"{menuOptions}");
                Console.Write("Select a choice from the menu: ");
                userChoice = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("\n_______________________________________");
                Console.WriteLine("Invalid Choice: Numbers only. Please choose from the available options above");
                Console.WriteLine("_______________________________________\n");
                isNumber = false;
            }
            catch (Exception error)
            {
                Console.WriteLine("\n_______________________________________");
                Console.WriteLine($"\nUncaught Error: {error}");
                Console.WriteLine("_______________________________________\n");
            }

            // validate choice
            if (userChoice == 1)
            {
                // create new goal
                Console.Clear();
                Console.WriteLine("\n---------------------------------------");
                Console.WriteLine($"Create New Goal");
                Console.WriteLine("---------------------------------------");
                CreateGoal();
            }
            else if (userChoice == 2)
            {
                // list goals
                Console.Clear();
                Console.WriteLine("\n---------------------------------------");
                Console.WriteLine($"All Goals");
                Console.WriteLine("---------------------------------------");
                ListGoalDetails();
            }
            else if (userChoice == 3)
            {
                // save goals
                Console.Clear();
                Console.WriteLine("\n---------------------------------------");
                Console.WriteLine($"Save Goals");
                Console.WriteLine("---------------------------------------");
                SaveGoals();
            }
            else if (userChoice == 4)
            {
                Console.Clear();
                Console.WriteLine("\n---------------------------------------");
                Console.WriteLine($"Load Goals");
                Console.WriteLine("---------------------------------------");
                LoadGoals();
            }
            else if (userChoice == 5)
            {
                // record event
                Console.Clear();
                Console.WriteLine("\n---------------------------------------");
                Console.WriteLine($"Record Event");
                Console.WriteLine("---------------------------------------");
                RecordEvent();
            }
            else if (userChoice == 6)
            {
                // enter my reward menu
                Console.Clear();
                Console.WriteLine("\n---------------------------------------");
                Console.WriteLine($"Reward Menu");
                Console.WriteLine("---------------------------------------");
                Reward();
            }
            else if (userChoice == 7)
            {
                // quit program
                Console.WriteLine("\n_______________________________________");
                Console.WriteLine("Sad to see you leave. Bye See you some other time");
                Console.WriteLine("_______________________________________\n");
                break;
            }
            else
            {
                if (isNumber)
                {
                    Console.WriteLine("\n_______________________________________");
                    Console.WriteLine("Invalid Choice! Please choose from the available options above");
                    Console.WriteLine("_______________________________________\n");
                }
            }
        }
    }

    public int DisplayPlayerInfo()
    {
        return _score;
    }

    public int ListGoalNames()
    {
        Console.WriteLine("The goals are:");
        int sn = 1;
        foreach (Goal goal in _goals)
        {
            if (!goal.IsComplete())
            {
                Console.WriteLine($"{sn}. {goal.GetGoalName()}");
                sn++;
            }
        }
        return _goals.Count();
    }

    public void ListGoalDetails()
    {
        int sn = 1;
        if (_goals.Count > 0)
        {
            foreach (Goal goal in _goals)
            {
                // display goal details
                Console.WriteLine($"{sn}. {goal.GetDetailsString()}");
                sn++;
            }
        }
        else
        {
            Console.WriteLine("\n_______________________________________");
            Console.WriteLine("Empty! You've not created a goal yet.");
            Console.WriteLine("_______________________________________\n");
        }
    }

    public void CreateGoal()
    {
        // Select Goal options
        string goalOptions = "  1. Simple Goal\n  2. Eternal Goal\n  3. Checklist Goal\n  4. Back";
        int goalChoice = 0;
        while (true)
        {
            // check if goal choice is a number
            bool isGoalNumber = true;

            try
            {
                Console.WriteLine("The types of Goals are:");
                Console.WriteLine(goalOptions);
                Console.Write("What type of goal would you like to create?: ");
                goalChoice = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("\n_______________________________________");
                Console.WriteLine("Invalid Choice: Numbers only. Please choose from the available options above");
                Console.WriteLine("_______________________________________\n");
                isGoalNumber = false;
            }
            catch (Exception error)
            {
                Console.WriteLine("\n_______________________________________");
                Console.WriteLine($"\nUncaught Error: {error}");
                Console.WriteLine("_______________________________________\n");
            }

            // validate choice
            if (goalChoice == 1)
            {
                // CREATE A SIMPLE GOAL
                Console.Clear();
                Console.WriteLine("\n---------------------------------------");
                Console.WriteLine($"Create A Simple Goal");
                Console.WriteLine("---------------------------------------");

                // get goal info.
                // name
                Console.Write("What is the name of your goal?: ");
                string goalName = Console.ReadLine();
                // description
                Console.Write("What is a short description of it?: ");
                string goalDescription = Console.ReadLine();
                // goal point
                int goalPoint;
                while (true)
                {
                    try
                    {
                        Console.Write("What is the amount of points associated with this goal?: ");
                        goalPoint = int.Parse(Console.ReadLine());
                        break;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("\n_______________________________________");
                        Console.WriteLine("Invalid Choice: Numbers only. Please enter the number of points to be attached to this goal.");
                        Console.WriteLine("_______________________________________\n");
                    }
                    catch (Exception error)
                    {
                        Console.WriteLine("\n_______________________________________");
                        Console.WriteLine($"\nUncaught Error: {error}");
                        Console.WriteLine("_______________________________________\n");
                    }
                }
                // Create object
                SimpleGoal simpleGoal = new SimpleGoal(goalName, goalDescription, goalPoint);

                // ASK USER TO ATTACH A REWARD TO THE GOAL
                while (true)
                {
                    Console.Write("Do you want to attach a reward to this goal?[Yes/No]: ");
                    string attachReward = Console.ReadLine();
                    if (attachReward.ToLower() == "yes")
                    {
                        Console.Write("\nEnter a short description of the reward: ");
                        string rewardDescription = Console.ReadLine();
                        // create a reward object
                        Reward newReward = new Reward(goalName, rewardDescription);
                        // add reward to simple goal
                        simpleGoal.SetReward(newReward);
                        break;
                    }
                    else if (attachReward.ToLower() == "no")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("\n_______________________________________");
                        Console.WriteLine("Invalid Response: Please enter yes or no.");
                        Console.WriteLine("_______________________________________\n");
                    }
                }
                // add goal to goal list
                _goals.Add(simpleGoal);
                // display confirmation message
                Console.WriteLine("<<<---GOAL ADDED SUCCESSFULLY--->>>\n");
            }
            else if (goalChoice == 2)
            {
                // create eternal goal
                Console.Clear();
                Console.WriteLine("\n---------------------------------------");
                Console.WriteLine($"Create An Eternal Goal");
                Console.WriteLine("---------------------------------------");
                // create EternalGoal Object
                // get goal info.
                // name
                Console.Write("What is the name of your goal?: ");
                string goalName = Console.ReadLine();
                // description
                Console.Write("What is a short description of it?: ");
                string goalDescription = Console.ReadLine();
                // goal point
                int goalPoint;
                while (true)
                {
                    try
                    {
                        Console.Write("What is the amount of points associated with this goal?: ");
                        goalPoint = int.Parse(Console.ReadLine());
                        break;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("\n_______________________________________");
                        Console.WriteLine("Invalid Choice: Numbers only. Please enter the number of points to be attached to this goal.");
                        Console.WriteLine("_______________________________________\n");
                    }
                    catch (Exception error)
                    {
                        Console.WriteLine("\n_______________________________________");
                        Console.WriteLine($"\nUncaught Error: {error}");
                        Console.WriteLine("_______________________________________\n");
                    }
                }
                // Create object
                EternalGoal eternalGoal = new EternalGoal(goalName, goalDescription, goalPoint);

                // ASK USER TO ATTACH A REWARD TO THE GOAL
                // get and set reward info
                while (true)
                {
                    Console.Write("Do you want to attach a reward to this goal?[Yes/No]: ");
                    string attachReward = Console.ReadLine();
                    if (attachReward.ToLower() == "yes")
                    {
                        Console.Write("\nEnter a short description of the reward: ");
                        string rewardDescription = Console.ReadLine();
                        Reward newReward = new Reward(goalName, rewardDescription);
                        eternalGoal.SetReward(newReward);
                        break;
                    }
                    else if (attachReward.ToLower() == "no")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("\n_______________________________________");
                        Console.WriteLine("Invalid Response: Please enter yes or no.");
                        Console.WriteLine("_______________________________________\n");
                    }
                }
                // add goal to goal list
                _goals.Add(eternalGoal);
                // display confirmation message
                Console.WriteLine("<<<---GOAL ADDED SUCCESSFULLY--->>>\n");
            }
            else if (goalChoice == 3)
            {
                // create checklist goal
                Console.Clear();
                Console.WriteLine("\n---------------------------------------");
                Console.WriteLine($"Create A Checklist Goal");
                Console.WriteLine("---------------------------------------");
                // create a ChecklistGoal Object
                // get goal info.
                // name
                Console.Write("What is the name of your goal?: ");
                string goalName = Console.ReadLine();
                // description
                Console.Write("What is a short description of it?: ");
                string goalDescription = Console.ReadLine();
                // goal point
                int goalPoint;
                while (true)
                {
                    try
                    {
                        Console.Write("What is the amount of points associated with this goal?: ");
                        goalPoint = int.Parse(Console.ReadLine());
                        break;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("\n_______________________________________");
                        Console.WriteLine("Invalid Choice: Numbers only. Please enter the number of points to be attached to this goal.");
                        Console.WriteLine("_______________________________________\n");
                    }
                    catch (Exception error)
                    {
                        Console.WriteLine("\n_______________________________________");
                        Console.WriteLine($"\nUncaught Error: {error}");
                        Console.WriteLine("_______________________________________\n");
                    }
                }
                // goal target
                int goalTarget;
                while (true)
                {
                    try
                    {
                        Console.Write("How many times does this goal need to be accomplished for a bonus?: ");
                        goalTarget = int.Parse(Console.ReadLine());
                        break;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("\n_______________________________________");
                        Console.WriteLine("Invalid Choice: Numbers only. Please enter the number of points to be attached to this goal.");
                        Console.WriteLine("_______________________________________\n");
                    }
                    catch (Exception error)
                    {
                        Console.WriteLine("\n_______________________________________");
                        Console.WriteLine($"\nUncaught Error: {error}");
                        Console.WriteLine("_______________________________________\n");
                    }
                }
                // goal bonus
                int goalBonus;
                while (true)
                {
                    try
                    {
                        Console.Write("What is the bonus for accomplishing it that many times?: ");
                        goalBonus = int.Parse(Console.ReadLine());
                        break;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("\n_______________________________________");
                        Console.WriteLine("Invalid Choice: Numbers only. Please enter the number of points to be attached to this goal.");
                        Console.WriteLine("_______________________________________\n");
                        isGoalNumber = false;
                    }
                    catch (Exception error)
                    {
                        Console.WriteLine("\n_______________________________________");
                        Console.WriteLine($"\nUncaught Error: {error}");
                        Console.WriteLine("_______________________________________\n");
                    }
                }
                // Create object
                ChecklistGoal checklistGoal = new ChecklistGoal(goalName, goalDescription, goalPoint, goalTarget, goalBonus);

                // ASK USER TO ATTACH A REWARD TO THE GOAL
                // get and set reward info
                while (true)
                {
                    Console.Write("Do you want to attach a reward to this goal?[Yes/No]: ");
                    string attachReward = Console.ReadLine();
                    if (attachReward.ToLower() == "yes")
                    {
                        Console.Write("\nEnter a short description of the reward: ");
                        string rewardDescription = Console.ReadLine();
                        Reward newReward = new Reward(goalName, rewardDescription);
                        checklistGoal.SetReward(newReward);
                        break;
                    }
                    else if (attachReward.ToLower() == "no")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("\n_______________________________________");
                        Console.WriteLine("Invalid Response: Please enter yes or no.");
                        Console.WriteLine("_______________________________________\n");
                    }
                }
                // get and create a bonusReward
                while (true)
                {
                    Console.Write("Do you want to attach a bonus reward to this goal?[Yes/No]: ");
                    string attachReward = Console.ReadLine();
                    if (attachReward.ToLower() == "yes")
                    {
                        Console.Write("\nEnter a short description of the bonus reward: ");
                        string bonusRewardDescription = Console.ReadLine();
                        Reward newBonusReward = new Reward(goalName, bonusRewardDescription);
                        checklistGoal.SetBonusReward(newBonusReward);
                        break;
                    }
                    else if (attachReward.ToLower() == "no")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("\n_______________________________________");
                        Console.WriteLine("Invalid Response: Please enter yes or no.");
                        Console.WriteLine("_______________________________________\n");
                    }
                }
                // add goal to goal list
                _goals.Add(checklistGoal);
                // display confirmation message
                Console.WriteLine("<<<---GOAL ADDED SUCCESSFULLY--->>>\n");
            }
            else if (goalChoice == 4)
            {
                // move back to main menu
                Console.Clear();
                break;
            }
            else
            {
                if (isGoalNumber)
                {
                    Console.WriteLine("\n_______________________________________");
                    Console.WriteLine("Invalid Choice! Please choose from the available options above");
                    Console.WriteLine("_______________________________________\n");
                }
            }
        }
    }

    public void RecordEvent()
    {
        // get the number of goals and display goal names
        int numberOfGoals = ListGoalNames();
        // ask user to choose event to record
        int eventChoice;
        while (true)
        {
            // check if goal choice is a number
            bool isNumber = true;

            if (numberOfGoals == 0)
            {
                Console.WriteLine("\n_______________________________________");
                Console.WriteLine("Empty! No goal to record.");
                Console.WriteLine("_______________________________________\n");
                break;
            }

            try
            {
                Console.Write("What goal did you accomplish?: ");
                eventChoice = int.Parse(Console.ReadLine());
                // decrement choice by one so it can match a list value
                eventChoice--;
                // validate choice
                if (eventChoice < _goals.Count())
                {
                    // store all goals that isn't completed to a list
                    List<Goal> myGoals = new List<Goal>();
                    foreach (Goal goal in _goals)
                    {
                        if (!goal.IsComplete())
                        {
                            myGoals.Add(goal);
                        }
                    }
                    // check list for selected value
                    int newScore = myGoals[eventChoice].RecordEvent();
                    _score += newScore;
                    break;
                }
                else
                {
                    if (isNumber)
                    {
                        Console.WriteLine("\n_______________________________________");
                        Console.WriteLine("Invalid Choice: Please choose from the available goal above");
                        Console.WriteLine("_______________________________________\n");
                    }
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("\n_______________________________________");
                Console.WriteLine("Invalid Choice: Numbers only. Please choose from the available options above");
                Console.WriteLine("_______________________________________\n");
                isNumber = false;
            }
            catch (Exception error)
            {
                Console.WriteLine("\n_______________________________________");
                Console.WriteLine($"\nUncaught Error: {error}");
                Console.WriteLine("_______________________________________\n");
            }
        }
    }

    public void SaveGoals()
    {
        Console.WriteLine("\n---Save Goals---");
        // Get filename and save to the file
        Console.Write("Enter Filename: ");
        string filename = Console.ReadLine();
        // store file into json format
        string extension = "json";
        string filePath = $"my-goals/{filename}.{extension}";

        using (StreamWriter document = new StreamWriter(filePath))
        {
            document.WriteLine("{");
            // save goals objects
            document.WriteLine("\t\"goals\" : [");
            try
            {
                int count = 1;
                foreach (Goal goal in _goals)
                {
                    if (count < _goals.Count())
                    {
                        document.WriteLine($"{goal.GetStringRepresentation()},");
                        count++;
                    }
                    else
                    {
                        document.WriteLine($"{goal.GetStringRepresentation()}");
                    }
                }
            }
            catch (Exception error)
            {
                Console.WriteLine("\n_______________________________________");
                Console.WriteLine(error);
                Console.WriteLine("_______________________________________\n");
            }
            document.WriteLine("\t],");
            // save PointReward Objects
            document.WriteLine("\t\"pointReward\" : [");
            try
            {
                int count = 1;
                foreach (PointReward pointReward in _pointRewards)
                {
                    if (count < _pointRewards.Count())
                    {
                        document.WriteLine($"{pointReward.GetStringRepresentation()},");
                        count++;
                    }
                    else
                    {
                        document.WriteLine($"{pointReward.GetStringRepresentation()}");
                    }
                }
            }
            catch (Exception error)
            {
                Console.WriteLine("\n_______________________________________");
                Console.WriteLine(error);
                Console.WriteLine("_______________________________________\n");
            }
            document.WriteLine("\t],");
            // save current scores
            document.WriteLine($"\t\"score\" : {_score}");
            // close the Json Object
            document.WriteLine("}");
        }
        // display confirmation message
        Console.WriteLine($"<<<---GOAL SAVED TO {filename} SUCCESSFULLY--->>>\n");
    }

    public class JsonObject
    {
        public AGoal[] goals { get; set; }
        public AReward[] pointReward { get; set; }
        public int score { get; set; }
    }

    public class AGoal
    {
        public string name { get; set; }
        public string type { get; set; }
        public string description { get; set; }
        public int point { get; set; }
        public bool isComplete { get; set; }
        public int target { get; set; }
        public int amountCompleted { get; set; }
        public int bonus { get; set; }
        public AReward reward { get; set; }
        public AReward bonusReward { get; set; }
    }

    public class AReward
    {
        public string name { get; set; }
        public string type { get; set; }
        public string description { get; set; }
        public int point { get; set; }
        public bool isEarned { get; set; }
        public bool isComplete { get; set; }
    }

    public static T Read<T>(string filePath)
    {
        string text = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<T>(text);
    }

    public void LoadGoals()
    {
        // Get filename and load the file
        while (true)
        {
            try
            {
                // check if goal is empty and request to save if not empty
                if (_goals.Count() > 0)
                {
                    Console.WriteLine("You have an unsaved goal");
                    string saveResponse = "";
                    while (saveResponse.ToLower() != "yes" || saveResponse.ToLower() != "no")
                    {
                        Console.Write("Do you want to save it before loading [Yes/No]? ");
                        saveResponse = Console.ReadLine();
                        if (saveResponse.ToLower() == "yes")
                        {
                            Console.WriteLine("Save Goal");
                            SaveGoals();
                            break;
                        }
                        else if (saveResponse.ToLower() == "no")
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("\n_______________________________________");
                            Console.WriteLine($"\nInvalid Response: Please Enter Yes or No");
                            Console.WriteLine("_______________________________________\n");
                        }
                    }

                }
                Console.WriteLine("\n---Load Goal---");
                Console.Write("Enter Filename: ");
                string filename = Console.ReadLine();
                // load a JSON file
                string extension = "json";
                string filePath = $"my-goals/{filename}.{extension}";
                JsonObject item = Read<JsonObject>(filePath);
                // clear previous goals
                _goals.Clear();
                _pointRewards.Clear();

                // load goals list
                foreach (AGoal goal in item.goals)
                {
                    if (goal.type == "simple")
                    {
                        Reward aReward = new Reward(goal.reward.name, goal.reward.description, goal.reward.point, goal.reward.isEarned, goal.reward.isComplete);
                        SimpleGoal aGoal = new SimpleGoal(goal.name, goal.description, goal.point, goal.isComplete, aReward);
                        _goals.Add(aGoal);
                    }
                    else if (goal.type == "eternal")
                    {
                        Reward aReward = new Reward(goal.reward.name, goal.reward.description, goal.reward.point, goal.reward.isEarned, goal.reward.isComplete);
                        EternalGoal aGoal = new EternalGoal(goal.name, goal.description, goal.point);
                        _goals.Add(aGoal);
                    }
                    else
                    {
                        Reward aReward = new Reward(goal.reward.name, goal.reward.description, goal.reward.point, goal.reward.isEarned, goal.reward.isComplete);
                        Reward aBonusReward = new Reward(goal.bonusReward.name, goal.bonusReward.description, goal.bonusReward.point, goal.bonusReward.isEarned, goal.bonusReward.isComplete);
                        ChecklistGoal aGoal = new ChecklistGoal(goal.name, goal.description, goal.point, goal.isComplete, goal.target, goal.amountCompleted, goal.bonus, aReward, aBonusReward);
                        _goals.Add(aGoal);
                    }
                }
                // load pointReward list
                foreach (AReward pointReward in item.pointReward)
                {
                    PointReward aPointReward = new PointReward(pointReward.name, pointReward.description, pointReward.point, pointReward.isEarned, pointReward.isComplete);
                    _pointRewards.Add(aPointReward);
                }
                // add score
                _score = item.score;
                // display confirmation message
                Console.WriteLine($"<<<---{filename} LOADED SUCCESSFULLY--->>>\n");
                break;
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("\n_______________________________________");
                Console.WriteLine($"\nNo Such File - Please Enter a valid filename");
                Console.WriteLine("_______________________________________\n");
            }
            catch (Exception error)
            {
                Console.WriteLine("\n_______________________________________");
                Console.WriteLine($"\nUncaught Error: {error}");
                Console.WriteLine("_______________________________________\n");
            }
        }


        // var jsonValue = JsonNode.Parse(filePath);  // for future use
    }

    public void Reward()
    {
        // Reward local functions
        void ListRewardDetails()
        {
            // clear console
            Console.Clear();
            // List all point rewards
            Console.WriteLine("Score Reward:");
            int sn = 1;
            if (_pointRewards.Count > 0)
            {
                foreach (PointReward pointReward in _pointRewards)
                {
                    // display goal details
                    Console.WriteLine($"{sn}. {pointReward.GetDetailsString()}");
                    sn++;
                }
            }
            else
            {
                Console.WriteLine("_______________________________________");
                Console.WriteLine("Empty! You've not created a score reward yet.");
                Console.WriteLine("_______________________________________");
            }

            // List all normal goal rewards
            Console.WriteLine("\nNormal Reward:");
            sn = 1;
            if (_goals.Count > 0)
            {
                // get number of displayed rewards
                int numberOfRewards = 0;

                foreach (Goal goal in _goals)
                {
                    // display goal details
                    if (goal.GetReward() != null)
                    {
                        Console.WriteLine($"{sn}. {goal.GetReward().GetDetailsString()}");
                        sn++;
                        numberOfRewards++;
                    }
                }
                // check if reward was displayed
                if (numberOfRewards == 0)
                {
                    Console.WriteLine("_______________________________________");
                    Console.WriteLine("Empty! You've not created a goal reward yet.");
                    Console.WriteLine("_______________________________________");
                }
            }
            else
            {
                Console.WriteLine("_______________________________________");
                Console.WriteLine("Empty! You've not created a goal reward yet.");
                Console.WriteLine("_______________________________________");
            }

            // List all bonus goal rewards
            Console.WriteLine("\nBonus Reward:");
            sn = 1;
            if (_goals.Count > 0)
            {
                // get number of displayed rewards
                int numberOfRewards = 0;

                foreach (Goal goal in _goals)
                {
                    // display goal details
                    if (goal.GetBonusReward() != null)
                    {
                        Console.WriteLine($"{sn}. {goal.GetBonusReward().GetDetailsString()}");
                        sn++;
                        numberOfRewards++;
                    }
                }
                // check if reward was displayed
                if (numberOfRewards == 0)
                {
                    Console.WriteLine("_______________________________________");
                    Console.WriteLine("Empty! You've not created a goal reward yet.");
                    Console.WriteLine("_______________________________________");
                }
            }
            else
            {
                Console.WriteLine("_______________________________________");
                Console.WriteLine("Empty! You've not created a goal bonus reward yet.");
                Console.WriteLine("_______________________________________");
            }
        }

        int ListRewardName()
        {
            int totalReward = 0;

            // List point rewards
            Console.WriteLine("SCORE REWARD: ");
            if (_pointRewards.Count() > 0)
            {
                // loop through goal and check if there is a reward set to a goal
                bool foundReward = false;
                foreach (Reward reward in _pointRewards)
                {
                    if (reward != null)
                    {
                        if (!reward.IsComplete() && reward.IsEarned())
                        {
                            foundReward = true;
                            break;
                        }
                    }
                }

                if (foundReward)
                {
                    int sn = 1;
                    foreach (Reward reward in _pointRewards)
                    {
                        if (reward != null)
                        {
                            if (!reward.IsComplete() && reward.IsEarned())
                            {
                                Console.WriteLine($"{sn}. {reward.GetName()}");
                                sn++;
                            }
                        }
                    }
                    totalReward += _pointRewards.Count();
                }
                else
                {
                    Console.WriteLine("Empty: No Earned Score Reward");
                }
            }
            else
            {
                Console.WriteLine("Empty: No Earned Score Reward");
            }

            // List goal rewards
            if (_goals.Count() > 0)
            {
                // loop through goal and check if there is a reward set to a goal
                bool foundReward = false;
                foreach (Goal goal in _goals)
                {
                    if (goal.GetReward() != null)
                    {
                        if (!goal.GetReward().IsComplete() && goal.GetReward().IsEarned())
                        {
                            foundReward = true;
                            break;
                        }
                    }
                }
                // display goal reward
                Console.WriteLine("\nNORMAL GOAL REWARD: ");
                if (foundReward)
                {
                    int sn = 1;
                    foreach (Goal goal in _goals)
                    {
                        if (goal.GetReward() != null)
                        {
                            if (!goal.GetReward().IsComplete() && goal.GetReward().IsEarned())
                            {
                                Console.WriteLine($"{sn}. {goal.GetReward().GetDescription()}");
                                sn++;
                            }
                        }
                    }
                    Console.WriteLine();  // for spacing purpose
                }
                else
                {
                    Console.WriteLine("Empty: No Earned Goal Reward\n");
                }

                // loop through goal and check if there is a reward set to a goal
                bool foundBonusReward = false;
                foreach (Goal goal in _goals)
                {
                    if (goal.GetBonusReward() != null)
                    {
                        if (!goal.GetBonusReward().IsComplete() && goal.GetBonusReward().IsEarned())
                        {
                            foundBonusReward = true;
                            break;
                        }
                    }
                }
                // display goal bonus reward
                Console.WriteLine("BONUS GOAL REWARD: ");
                if (foundBonusReward)
                {
                    int sn = 1;
                    foreach (Goal goal in _goals)
                    {
                        if (goal.GetBonusReward() != null)
                        {
                            if (!goal.GetBonusReward().IsComplete() && goal.GetBonusReward().IsEarned())
                            {
                                Console.WriteLine($"{sn}. {goal.GetBonusReward().GetDescription()} - [bonus]");
                                sn++;
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Empty: No Earned Bonus Reward\n");
                }
                totalReward += _goals.Count();
            }

            return totalReward;
        }

        int TotalInCompleteReward()
        {
            // calculate the total incomplete rewards and return the value
            int totalReward = 0;

            if (_pointRewards.Count() > 0)
            {
                // loop through goal and check if there is a reward set to a goal
                bool foundReward = false;
                foreach (Reward reward in _pointRewards)
                {
                    if (reward != null)
                    {
                        if (!reward.IsComplete() && reward.IsEarned())
                        {
                            foundReward = true;
                            break;
                        }
                    }
                }

                if (foundReward)
                {
                    int sn = 0;
                    foreach (Reward reward in _pointRewards)
                    {
                        if (reward != null)
                        {
                            if (!reward.IsComplete() && reward.IsEarned())
                            {
                                sn++;
                                totalReward += sn;
                            }
                        }
                    }
                }
            }

            // List goal rewards
            if (_goals.Count() > 0)
            {
                // loop through goal and check if there is a reward set to a goal
                bool foundReward = false;
                foreach (Goal goal in _goals)
                {
                    if (goal.GetReward() != null)
                    {
                        if (!goal.GetReward().IsComplete() && goal.GetReward().IsEarned())
                        {
                            foundReward = true;
                            break;
                        }
                    }
                }
                // display goal reward
                // Console.WriteLine("\nNORMAL GOAL REWARD: ");  // for testing purpose;
                if (foundReward)
                {
                    int sn = 0;
                    foreach (Goal goal in _goals)
                    {
                        if (goal.GetReward() != null)
                        {
                            if (!goal.GetReward().IsComplete() && goal.GetReward().IsEarned())
                            {
                                sn++;
                                totalReward += sn;
                            }
                        }
                    }
                }

                // loop through goal and check if there is a reward set to a goal
                bool foundBonusReward = false;
                foreach (Goal goal in _goals)
                {
                    if (goal.GetBonusReward() != null)
                    {
                        if (!goal.GetBonusReward().IsComplete() && goal.GetBonusReward().IsEarned())
                        {
                            foundBonusReward = true;
                            break;
                        }
                    }
                }
                // display goal bonus reward
                // Console.WriteLine("BONUS GOAL REWARD: ");  // for testing purpose
                if (foundBonusReward)
                {
                    int sn = 0;
                    foreach (Goal goal in _goals)
                    {
                        if (goal.GetBonusReward() != null)
                        {
                            if (!goal.GetBonusReward().IsComplete() && goal.GetBonusReward().IsEarned())
                            {
                                sn++;
                                totalReward += sn;
                            }
                        }
                    }
                }
            }

            return totalReward;
        }

        // Select Reward options
        int rewardChoice = 0;
        while (true)
        {
            // reward options variable
            string rewardOptions = $"  1. Add Point Reward\n  2. View Reward\n  3. Record Reward - [{TotalInCompleteReward()}]\n  4. Back";

            // check if reward choice is a number
            bool isRewardNumber = true;

            try
            {
                Console.WriteLine("\nThe types of Goals are:");
                Console.WriteLine(rewardOptions);
                Console.Write("What type of goal would you like to create?: ");
                rewardChoice = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("\n_______________________________________");
                Console.WriteLine("Invalid Choice: Numbers only. Please choose from the available options above");
                Console.WriteLine("_______________________________________\n");
                isRewardNumber = false;
            }
            catch (Exception error)
            {
                Console.WriteLine("\n_______________________________________");
                Console.WriteLine($"\nUncaught Error: {error}");
                Console.WriteLine("_______________________________________\n");
            }

            // validate choice
            if (rewardChoice == 1)
            {
                // add a reward
                Console.Clear();
                Console.WriteLine("\n---------------------------------------");
                Console.WriteLine($"Add Reward");
                Console.WriteLine("---------------------------------------");
                // Create a Point Reward Object
                // get point reward info
                // name
                Console.Write("Enter a Name for the Reward: ");
                string pointRewardName = Console.ReadLine();
                // description
                Console.Write("Enter a Description of the Reward: ");
                string pointRewardDescription = Console.ReadLine();
                // point
                int pointRewardScore;
                while (true)
                {
                    try
                    {
                        Console.Write("What is the amount of scores needed to earn this reward?: ");
                        pointRewardScore = int.Parse(Console.ReadLine());
                        // check if pointRewardScore is greater than current score
                        if (pointRewardScore > _score)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("\n_______________________________________");
                            Console.WriteLine("Invalid Score: Please enter a score that is bigger than current scores");
                            Console.WriteLine("_______________________________________\n");
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("\n_______________________________________");
                        Console.WriteLine("Invalid Choice: Numbers only. Please enter the number of points to be attached to this goal.");
                        Console.WriteLine("_______________________________________\n");
                    }
                    catch (Exception error)
                    {
                        Console.WriteLine("\n_______________________________________");
                        Console.WriteLine($"\nUncaught Error: {error}");
                        Console.WriteLine("_______________________________________\n");
                    }
                }
                // Create a PointReward object
                PointReward newPointReward = new PointReward(pointRewardName, pointRewardDescription, pointRewardScore);
                // add point reward into pointReward list
                _pointRewards.Add(newPointReward);
            }
            else if (rewardChoice == 2)
            {
                // list rewards
                Console.Clear();
                Console.WriteLine("\n---------------------------------------");
                Console.WriteLine($"All Rewards");
                Console.WriteLine("---------------------------------------");
                // list rewards
                ListRewardDetails();
            }
            else if (rewardChoice == 3)
            {
                // record reward
                Console.Clear();
                Console.WriteLine("\n---------------------------------------");
                Console.WriteLine($"Record Rewards");
                Console.WriteLine("---------------------------------------");
                // list reward names
                int numberOfRewards = ListRewardName();
                if (numberOfRewards > 0)
                {
                    // store matching response in a list
                    string[] matchingResponses = ["score", "normal", "bonus", "quite", "s", "n", "b", "q"];
                    string typeChoice;  // user choice
                    while (true)
                    {
                        Console.WriteLine("\n---[Possible Reward Types: Score(s), Normal(n), Bonus(b)] ---");
                        Console.Write("Choose a reward type [Enter 'Quit' to quit]: ");
                        typeChoice = Console.ReadLine();
                        // validate typeChoice
                        bool validResponse = false;
                        foreach (string matchRespond in matchingResponses)
                        {
                            if (typeChoice.ToLower() == matchRespond)
                            {
                                validResponse = true;
                            }
                        }
                        if (validResponse)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine($"{typeChoice} is not a valid reward type");
                        }
                    }
                    // check response
                    typeChoice = typeChoice.ToLower();
                    if (typeChoice == "score" || typeChoice == "s")
                    {
                        if (_pointRewards.Count > 0)
                        {
                            // store all not completed score rewards into a list
                            List<Reward> scoreRewards = new List<Reward>();
                            foreach (Reward scoreReward in _pointRewards)
                            {
                                if (!scoreReward.IsComplete() && scoreReward.IsEarned())
                                {
                                    scoreRewards.Add(scoreReward);
                                }
                            }

                            // check if scoreRewards list isn't empty
                            if (scoreRewards.Count > 0)
                            {
                                // ask user to choose reward from the selected type to record
                                int scoreRewardChoice;
                                while (true)
                                {
                                    // check if reward choice is a number
                                    bool isNumber = true;
                                    try
                                    {
                                        Console.Write("What reward in your selected reward type did you accomplish?: ");
                                        scoreRewardChoice = int.Parse(Console.ReadLine());
                                        // decrement choice by one so it can match a list value
                                        scoreRewardChoice--;
                                        // validate choice
                                        if (scoreRewardChoice < scoreRewards.Count() && scoreRewardChoice >= 0)
                                        {
                                            // check list of normal rewards that isn't completed yet for selected value
                                            scoreRewards[scoreRewardChoice].RecordReward();
                                            break;
                                        }
                                        else
                                        {
                                            if (isNumber)
                                            {
                                                Console.WriteLine("\n_______________________________________");
                                                Console.WriteLine("Invalid Choice: Please choose from the available reward above");
                                                Console.WriteLine("_______________________________________\n");
                                            }
                                        }
                                    }
                                    catch (FormatException)
                                    {
                                        Console.WriteLine("\n_______________________________________");
                                        Console.WriteLine("Invalid Choice: Numbers only. Please choose from the available options above");
                                        Console.WriteLine("_______________________________________\n");
                                        isNumber = false;
                                    }
                                    catch (Exception error)
                                    {
                                        Console.WriteLine("\n_______________________________________");
                                        Console.WriteLine($"\nUncaught Error: {error}");
                                        Console.WriteLine("_______________________________________\n");
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("Score Reward is Empty\n");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Score Reward is Empty\n");
                        }
                    }
                    else if (typeChoice == "normal" || typeChoice == "n")
                    {
                        if (_goals.Count() > 0)
                        {
                            List<Reward> normalRewards = new List<Reward>();
                            foreach (Goal goal in _goals)
                            {
                                Reward normalReward = goal.GetReward();
                                if (normalReward != null)
                                {
                                    // check if the normal reward is completed
                                    if (!normalReward.IsComplete() && normalReward.IsEarned())
                                    {
                                        // add the reward to the list of normalReward
                                        normalRewards.Add(normalReward);
                                    }
                                }
                            }
                            // check if normal reward exit and record reward
                            if (normalRewards.Count() > 0)
                            {
                                // ask user to choose reward from the selected type to record
                                int normalRewardChoice;
                                while (true)
                                {
                                    // check if reward choice is a number
                                    bool isNumber = true;
                                    try
                                    {
                                        Console.Write("What reward in your selected reward type did you accomplish?: ");
                                        normalRewardChoice = int.Parse(Console.ReadLine());
                                        // decrement choice by one so it can match a list value
                                        normalRewardChoice--;
                                        // validate choice
                                        if (normalRewardChoice < normalRewards.Count() && normalRewardChoice >= 0)
                                        {
                                            // check list of normal rewards that isn't completed yet for selected value
                                            normalRewards[normalRewardChoice].RecordReward();
                                            break;
                                        }
                                        else
                                        {
                                            if (isNumber)
                                            {
                                                Console.WriteLine("\n_______________________________________");
                                                Console.WriteLine("Invalid Choice: Please choose from the available reward above");
                                                Console.WriteLine("_______________________________________\n");
                                            }
                                        }
                                    }
                                    catch (FormatException)
                                    {
                                        Console.WriteLine("\n_______________________________________");
                                        Console.WriteLine("Invalid Choice: Numbers only. Please choose from the available options above");
                                        Console.WriteLine("_______________________________________\n");
                                        isNumber = false;
                                    }
                                    catch (Exception error)
                                    {
                                        Console.WriteLine("\n_______________________________________");
                                        Console.WriteLine($"\nUncaught Error: {error}");
                                        Console.WriteLine("_______________________________________\n");
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("Normal Reward is Empty\n");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Normal Reward is Empty\n");
                        }
                    }
                    else if (typeChoice == "bonus" || typeChoice == "b")
                    {
                        if (_goals.Count() > 0)
                        {
                            List<Reward> bonusRewards = new List<Reward>();
                            foreach (Goal goal in _goals)
                            {
                                Reward bonusReward = goal.GetBonusReward();
                                if (bonusReward != null)
                                {
                                    // check if the bonus reward is completed
                                    if (!bonusReward.IsComplete() && bonusReward.IsEarned())
                                    {
                                        // add the reward to the list of normalReward
                                        bonusRewards.Add(bonusReward);
                                    }
                                }
                            }
                            // check if normal reward exit and record reward
                            if (bonusRewards.Count() > 0)
                            {
                                // ask user to choose reward from the selected type to record
                                int bonusRewardChoice;
                                while (true)
                                {
                                    // check if reward choice is a number
                                    bool isNumber = true;
                                    try
                                    {
                                        Console.Write("What reward in your selected reward type did you accomplish?: ");
                                        bonusRewardChoice = int.Parse(Console.ReadLine());
                                        // decrement choice by one so it can match a list value
                                        bonusRewardChoice--;
                                        // validate choice
                                        if (bonusRewardChoice < bonusRewards.Count() && bonusRewardChoice >= 0)
                                        {
                                            // check list of normal rewards that isn't completed yet for selected value
                                            bonusRewards[bonusRewardChoice].RecordReward();
                                            break;
                                        }
                                        else
                                        {
                                            if (isNumber)
                                            {
                                                Console.WriteLine("\n_______________________________________");
                                                Console.WriteLine("Invalid Choice: Please choose from the available rewards above");
                                                Console.WriteLine("_______________________________________\n");
                                            }
                                        }
                                    }
                                    catch (FormatException)
                                    {
                                        Console.WriteLine("\n_______________________________________");
                                        Console.WriteLine("Invalid Choice: Numbers only. Please choose from the available options above");
                                        Console.WriteLine("_______________________________________\n");
                                        isNumber = false;
                                    }
                                    catch (Exception error)
                                    {
                                        Console.WriteLine("\n_______________________________________");
                                        Console.WriteLine($"\nUncaught Error: {error}");
                                        Console.WriteLine("_______________________________________\n");
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("Bonus Reward is Empty\n");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Bonus Reward is Empty\n");
                        }
                    }
                    else
                    {
                        // do nothing and quit to reward menu
                    }
                }
                else
                {
                    Console.WriteLine("\n_______________________________________");
                    Console.WriteLine($"\nEmpty: No reward to record.");
                    Console.WriteLine("_______________________________________\n");
                }
            }
            else if (rewardChoice == 4)
            {
                // back to main menu
                Console.Clear();
                break;
            }
            else
            {
                if (isRewardNumber)
                {
                    Console.WriteLine("\n_______________________________________");
                    Console.WriteLine("Invalid Choice! Please choose from the available options above");
                    Console.WriteLine("_______________________________________\n");
                }
            }
        }
    }

    public void RecordEarnReward()
    {
        // check and record all point earned rewards
        // loop through point reward list and compare each reward point to score
        foreach (Reward pointReward in _pointRewards)
        {
            if (pointReward.GetPoint() <= _score && !pointReward.IsEarned())
            {
                pointReward.EarnReward();
            }
        }
    }
}