public class Resume
{
    /* class Diagram 
        class Resume
            Attribute(Properties)
                * _userName : string
                * _jobs : List<Job>
            Behavior(Methods)
                * DisplayResume() : void
    */

    // properties
    public string _userName;
   public List<Job> _jobs = new List<Job>();

    // method
    public void DisplayResume()
    {
        Console.WriteLine($"Name: {_userName}\nJobs:");
        foreach (Job job in _jobs) {
            job.DisplayJobDetail();
        }
    }
}