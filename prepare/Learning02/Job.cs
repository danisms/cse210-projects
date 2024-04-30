public class Job
{
    /* Class Diagram
        Class: Job
            Attributes(Property):
                * _companyName : string
                * _jobTitle : string
                * _startDate : int
                * _endDate : int
            Behaviors(Method):
                * DisplayJobTitle() : void
    */

    // Properties
    public string _companyName;
    public string _jobTitle;
    public int _startDate;
    public int _endDate;

    //methods
    public void DisplayJobDetail()
    {
        Console.WriteLine($"{_jobTitle} ({_companyName}) {_startDate}-{_endDate}");
    }
}