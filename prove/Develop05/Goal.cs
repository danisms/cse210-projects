public abstract class Goal
{
    private string _shortName;
    private string _description;
    protected int _points;
    private Reward _reward;
    private Reward _bonusReward;

    // Constructor
    public Goal(string name, string description, int points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }

    public Goal(string name, string description, int points, Reward reward)
    {
        _shortName = name;
        _description = description;
        _points = points;
        _reward = reward;
    }

    public Goal(string name, string description, int points, Reward reward, Reward bonusReward)
    {
        _shortName = name;
        _description = description;
        _points = points;
        _reward = reward;
        _bonusReward = bonusReward;
    }

    public Reward GetReward()
    {
        if (_reward == null)
        {
            return null;
        }
        else
        {
            return _reward;
        }
    }
    public void SetReward(Reward reward)
    {
        _reward = reward;
    }

    public Reward GetBonusReward()
    {
        if (_bonusReward == null)
        {
            return null;
        }
        else
        {
            return _bonusReward;
        }
    }
    public void SetBonusReward(Reward bonusReward)
    {
        _bonusReward = bonusReward;
    }

    public string GetGoalName()
    {
        return _shortName;
    }

    public string GetGoalDescription()
    {
        return _description;
    }

    // Methods
    public abstract int RecordEvent();
    public abstract bool IsComplete();
    public virtual string GetDetailsString()
    {
        // return a string value of goal
        string goalValue;
        if (IsComplete())
        {
            goalValue = $"[✓] {GetGoalName()} ({GetGoalDescription()})";
        }
        else
        {
            goalValue = $"[ ] {GetGoalName()} ({GetGoalDescription()})";
        }
        return goalValue;
    }
    public abstract string GetStringRepresentation();
}