public abstract class Goal
{
    private string _shortName;
    private string _description;
    private int _points;

    // Constructor
    public Goal(string name, string description, int points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }

    // Methods
    public abstract void RecordEvent();
    public abstract bool IsComplete();
    public virtual string GetDetailsString()
    {
        return "";
    }
    public abstract string GetStringRepresentation();
}