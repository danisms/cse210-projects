public class MathAssignment : Assignment
{
    string _textbookSection;
    string _problems;

    public MathAssignment(string studentName, string topic, string textbookSection, string problem) : base(studentName, topic)
    {
        _textbookSection = textbookSection;
        _problems = problem;
    }

    public string GetHomeworkList()
    {
        return $"Section {_textbookSection} Problems {_problems}";
    }
}