public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;
    private bool _isComplete;

    // Constructor
    public ChecklistGoal(string name, string description, int points, int target, int bonus) : base(name, description, points)
    {
        _target = target;
        _bonus = bonus;
        _amountCompleted = 0;
    }
    public ChecklistGoal(string name, string description, int points, int target, int bonus, Reward reward) : base(name, description, points, reward)
    {
        _target = target;
        _bonus = bonus;
        _amountCompleted = 0;
    }
    public ChecklistGoal(string name, string description, int points, int target, int bonus, Reward reward, Reward bonusReward) : base(name, description, points, reward, bonusReward)
    {
        _target = target;
        _bonus = bonus;
        _amountCompleted = 0;
    }

    public ChecklistGoal(string name, string description, int points, bool isComplete, int target, int amountCompleted, int bonus) : base(name, description, points)
    {
        _isComplete = isComplete;
        _target = target;
        _bonus = bonus;
        _amountCompleted = amountCompleted;
    }

    public ChecklistGoal(string name, string description, int points, bool isComplete, int target, int amountCompleted, int bonus, Reward reward) : base(name, description, points, reward)
    {
        _isComplete = isComplete;
        _target = target;
        _bonus = bonus;
        _amountCompleted = amountCompleted;
    }

    public ChecklistGoal(string name, string description, int points, bool isComplete, int target, int amountCompleted, int bonus, Reward reward, Reward bonusReward) : base(name, description, points, reward, bonusReward)
    {
        _isComplete = isComplete;
        _target = target;
        _bonus = bonus;
        _amountCompleted = amountCompleted;
    }


    public override int RecordEvent()
    {
        if (!IsComplete())
        {
            int point = 0;

            if (_amountCompleted < _target)
            {
                _amountCompleted++;
                point = _points;
                Console.WriteLine("\n>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                if (_points > 1)
                {
                    Console.WriteLine($"Congrats! {GetGoalName()} Recorded Successfully.\nYou've earned {_points} points!");
                }
                else
                {
                    Console.WriteLine($"Congrats! {GetGoalName()} Recorded Successfully.\nYou've earned {_points} point!");
                }
                Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<\n");

                // set reward earned to be true
                GetReward().EarnReward();
            }

            if (_amountCompleted == _target)
            {
                _isComplete = true;
                point = _bonus;
                Console.WriteLine("\n>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                Console.WriteLine($"Congratulations! You've successfully completed {GetGoalName()} checklist goal!\nYou've earned a bonus point of {_bonus}!");
                Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<\n");

                // set reward earned to be true
                GetBonusReward().EarnBonusReward();
            }

            return point;
        }
        else
        {
            return 0;
        }
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override string GetDetailsString()
    {
        // return a string value of goal
        string goalValue;
        if (!IsComplete())
        {
            if (_amountCompleted < _target)
            {
                goalValue = $"[{_amountCompleted}/{_target}] {GetGoalName()} ({GetGoalDescription()})";
            }
            else
            {
                goalValue = $"[✓] {GetGoalName()} ({GetGoalDescription()}) -- completed: {_amountCompleted}/{_target}";
            }
            return goalValue;
        }
        else
        {
            goalValue = $"[✓] {GetGoalName()} ({GetGoalDescription()}) -- completed: {_amountCompleted}/{_target}";
            return goalValue;
        }
    }

    public override string GetStringRepresentation()
    {
        // create a JSON format string
        string name = "\"name\"" + ":" + $"\"{GetGoalName()}\"";
        string type = "\"type\"" + ":" + $"\"checklist\"";
        string description = "\"description\"" + ":" + $"\"{GetGoalDescription()}\"";
        string point = "\"point\"" + ":" + $"{_points}";
        string isComplete = "\"isComplete\"" + ":" + $"{IsComplete().ToString().ToLower()}";
        string target = "\"target\"" + ":" + $"{_target}";
        string amountCompleted = "\"amountCompleted\"" + ":" + $"{_amountCompleted}";
        string bonus = "\"bonus\"" + ":" + $"{_bonus}";

        string values;
        if (GetReward() != null && GetBonusReward() != null)
        {
            string getReward = "\"reward\"" + ":" + $"{GetReward().GetStringRepresentation()}";
            string getBonusReward = "\"bonusReward\"" + ":" + $"{GetBonusReward().GetStringRepresentation()}";

            values = "\t\t{\n" + $"\t\t\t{name},\n\t\t\t{type},\n\t\t\t{description},\n\t\t\t{point},\n\t\t\t{isComplete},\n\t\t\t{target},\n\t\t\t{amountCompleted},\n\t\t\t{bonus}, \n\t\t\t{getReward}, \n\t\t\t{getBonusReward}" + "\n\t\t}";
        }
        else if (GetReward() == null && GetBonusReward() != null)
        {
            string getBonusReward = "\"bonusReward\"" + ":" + $"{GetBonusReward().GetStringRepresentation()}";

            values = "\t\t{\n" + $"\t\t\t{name},\n\t\t\t{type},\n\t\t\t{description},\n\t\t\t{point},\n\t\t\t{isComplete},\n\t\t\t{target},\n\t\t\t{amountCompleted},\n\t\t\t{bonus}, \n\t\t\t{getBonusReward}" + "\n\t\t}";
        }
        else if (GetReward() != null && GetBonusReward() == null)
        {
            string getReward = "\"reward\"" + ":" + $"{GetReward().GetStringRepresentation()}";

            values = "\t\t{\n" + $"\t\t\t{name},\n\t\t\t{type},\n\t\t\t{description},\n\t\t\t{point},\n\t\t\t{isComplete},\n\t\t\t{target},\n\t\t\t{amountCompleted},\n\t\t\t{bonus}, \n\t\t\t{getReward}" + "\n\t\t}";
        }
        else
        {
            values = "\t\t{\n" + $"\t\t\t{name},\n\t\t\t{type},\n\t\t\t{description},\n\t\t\t{point},\n\t\t\t{isComplete},\n\t\t\t{target},\n\t\t\t{amountCompleted},\n\t\t\t{bonus}" + "\n\t\t}";
        }
        return values;
    }
}