public class Reward
{
    private string _name;
    private string _description;
    protected int _point;
    private bool _isEarned;
    private bool _isComplete;

    public Reward(string name, string description)
    {
        _name = name;
        _description = description;
        _point = 0;
        _isEarned = false;
        _isComplete = false;
    }

    public Reward(string name, string description, int point)
    {
        _name = name;
        _description = description;
        _point = point;
        _isEarned = false;
        _isComplete = false;
    }

    public Reward(string name, string description, int point, bool isEarned, bool isComplete)
    {
        _name = name;
        _description = description;
        _point = point;
        _isEarned = isEarned;
        _isComplete = isComplete;
    }

    public string GetName()
    {
        return _name;
    }

    public string GetDescription()
    {
        return _description;
    }

    public int GetPoint()
    {
        return _point;
    }

    public bool IsEarned()
    {
        return _isEarned;
    }

    public bool IsComplete()
    {
        return _isComplete;
    }

    public void SetIsComplete(bool value)
    {
        _isComplete = value;
    }

    // Methods
    public void EarnReward()
    {
        // check and set the earning of a reward
        _isEarned = true;
        Console.WriteLine("\n>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
        Console.WriteLine($"Congrats! You just Earned a Reward!\nReward: {_description}");
        Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<\n");
    }

    public void EarnBonusReward()
    {
        // check and set the earning of a reward
        _isEarned = true;
        Console.WriteLine("\n>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
        Console.WriteLine($"Congrats! You just Earned a Bonus Reward!\nReward: {_description}");
        Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<\n");
    }

    public void RecordReward()
    {
        // check and set the completion of a reward
        _isComplete = true;
        Console.WriteLine("\n>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
        Console.WriteLine($"Congratulations for completing your reward: {_name} - ({_description})");
        Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<\n");
    }

    public virtual string GetDetailsString()
    {
        // return a string value of goal
        string rewardValue;
        if (IsEarned() && IsComplete())
        {
            rewardValue = $"{_name} ({_description}) - Earned[✓] - Completed[✓]";
        }
        else if (IsEarned() && !IsComplete())
        {
            rewardValue = $"{_name} ({_description}) - Earned[✓] - Completed[ ]";
        }
        else
        {
            rewardValue = $"{_name} ({_description}) - Earned[ ] - Completed[ ]";
        }
        return rewardValue;
    }

    public virtual string GetStringRepresentation()
    {
        // create a JSON format string
        string name = "\"name\"" + ":" + $"\"{_name}\"";
        string type = "\"type\"" + ":" + $"\"reward\"";
        string description = "\"description\"" + ":" + $"\"{_description}\"";
        string point = "\"point\"" + ":" + $"{_point}";
        string isEarned = "\"isEarned\"" + ":" + $"{IsEarned().ToString().ToLower()}";
        string isComplete = "\"isComplete\"" + ":" + $"{IsComplete().ToString().ToLower()}";

        string values = "\t\t\t{\n" + $"\t\t\t\t{name},\n\t\t\t\t{type},\n\t\t\t\t{description},\n\t\t\t\t{point},\n\t\t\t\t{isEarned},\n\t\t\t\t{isComplete}" + "\n\t\t\t}";
        return values;
    }
}