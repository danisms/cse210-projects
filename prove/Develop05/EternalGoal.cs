public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points) : base(name, description, points)
    {

    }

    public EternalGoal(string name, string description, int points, Reward reward) : base(name, description, points, reward)
    {

    }

    public override int RecordEvent()
    {
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
        if (GetReward() != null)
        {
            GetReward().EarnReward();
            // set completed reward value to be false
            GetReward().SetIsComplete(false);
        }

        // return points
        return _points;
    }

    public override bool IsComplete()
    {
        return false;
    }

    public override string GetDetailsString()
    {
        // return a string value of goal
        string goalValue = $"[∞] {GetGoalName()} ({GetGoalDescription()})";
        return goalValue;
    }

    public override string GetStringRepresentation()
    {
        // create a JSON format string
        string name = "\"name\"" + ":" + $"\"{GetGoalName()}\"";
        string type = "\"type\"" + ":" + $"\"eternal\"";
        string description = "\"description\"" + ":" + $"\"{GetGoalDescription()}\"";
        string point = "\"point\"" + ":" + $"{_points}";
        string isComplete = "\"isComplete\"" + ":" + $"{IsComplete().ToString().ToLower()}";
        string getReward = "\"reward\"" + ":" + $"{GetReward().GetStringRepresentation()}";

        string values = "\t\t{\n" + $"\t\t\t{name},\n\t\t\t{type},\n\t\t\t{description},\n\t\t\t{point},\n\t\t\t{isComplete}, \n\t\t\t{getReward}" + "\n\t\t}";
        return values;
    }
}