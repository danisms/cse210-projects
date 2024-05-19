public class ListingActivity : Activity
{
    private int _count;
    private List<string> _prompts = new List<string>();
    
    public ListingActivity(string name, string description, int count, List<string> prompts) : base(name, description)
    {
        _count = count;
        _prompts = prompts;
    }

    public void Run()
    {

    }

    public void GetRandomPrompt()
    {

    }

    public List<string> GetListFromUser()
    {
        List<string> list = new();
        return list;
    }
}
