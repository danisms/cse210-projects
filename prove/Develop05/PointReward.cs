public class PointReward : Reward
{
    // creation constructor
    public PointReward(string name, string description, int point) : base(name, description, point)
    {

    }

    // loading constructor
    public PointReward(string name, string description, int point, bool isEarned, bool isComplete) : base(name, description, point, isEarned, isComplete)
    {

    }

    public override string GetDetailsString()
    {
        // return a string value of goal
        string rewardValue;
        if (IsEarned() && IsComplete())
        {
            rewardValue = $"{GetName()} ({GetDescription()}) -Points[{_point}] - Earned[✓] - Completed[✓]";
        }
        else if (IsEarned() && !IsComplete())
        {
            rewardValue = $"{GetName()} ({GetDescription()}) -Points[{_point}] - Earned[✓] - Completed[ ]";
        }
        else
        {
            rewardValue = $"{GetName()} ({GetDescription()})-Points[{_point}] - Earned[ ] - Completed[ ]";
        }
        return rewardValue;
    }

    public override string GetStringRepresentation()
    {
        // create a JSON format string
        string name = "\"name\"" + ":" + $"\"{GetName()}\"";
        string type = "\"type\"" + ":" + $"\"pointReward\"";
        string description = "\"description\"" + ":" + $"\"{GetDescription()}\"";
        string point = "\"point\"" + ":" + $"{_point}";
        string isEarned = "\"isEarned\"" + ":" + $"{IsEarned().ToString().ToLower()}";
        string isComplete = "\"isComplete\"" + ":" + $"{IsComplete().ToString().ToLower()}";

        string values = "\t\t{\n" + $"\t\t\t{name},\n\t\t\t{type},\n\t\t\t{description},\n\t\t\t{point},\n\t\t\t{isEarned},\n\t\t\t{isComplete}" + "\n\t\t}";
        return values;
    }

}