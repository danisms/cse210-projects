public class SimpleGoal : Goal
{
    private bool _isComplete;

    // Constructor
    public SimpleGoal(string name, string description, int points) : base(name, description, points)
    {
        _isComplete = false;
    }
    public SimpleGoal(string name, string description, int points, bool isComplete) : base(name, description, points)
    {
        _isComplete = isComplete;
    }
    public SimpleGoal(string name, string description, int points, bool isComplete, Reward reward) : base(name, description, points, reward)
    {
        _isComplete = isComplete;
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    // Methods
    public override int RecordEvent()
    {
        // check and set the completion of a goal and return the point of that goal
        if (!IsComplete())
        {
            // set _isComplete to true
            _isComplete = true;
            Console.WriteLine("\n>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
            if (_points > 1)
            {
                Console.WriteLine($"Congratulations! {GetGoalName()} Recorded Successfully.\nYou've earned {_points} points!");
            }
            else
            {
                Console.WriteLine($"Congratulations! {GetGoalName()} Recorded Successfully.\nYou've earned {_points} point!");
            }
            Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<\n");

            // set reward earned to be true
            GetReward().EarnReward();

            return _points;
        }
        else
        {
            return 0;
        }
    }

    public override string GetStringRepresentation()
    {
        // create a JSON format string
        string name = "\"name\"" + ":" + $"\"{GetGoalName()}\"";
        string type = "\"type\"" + ":" + $"\"simple\"";
        string description = "\"description\"" + ":" + $"\"{GetGoalDescription()}\"";
        string point = "\"point\"" + ":" + $"{_points}";
        string isComplete = "\"isComplete\"" + ":" + $"{IsComplete().ToString().ToLower()}";
        string getReward = "\"reward\"" + ":" + $"{GetReward().GetStringRepresentation()}";

        string values = "\t\t{\n" + $"\t\t\t{name},\n\t\t\t{type},\n\t\t\t{description},\n\t\t\t{point},\n\t\t\t{isComplete}, \n\t\t\t{getReward}" + "\n\t\t}";
        return values;
    }
}