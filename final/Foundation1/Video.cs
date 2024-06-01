public class Video
{
    private string _title;
    private string _author;
    private int _length;
    private List<Comment> _comments = new List<Comment>();

    // Constructors
    public Video(string title, string author, int length)
    {
        _title = title;
        _author = author;
        _length = length;
    }
    public Video(string title, string author, int length, List<Comment> comments)
    {
        _title = title;
        _author = author;
        _length = length;
        _comments = comments;
    }

    // Methods
    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    public int NumberOfComments()
    {
        int numberOfComments = _comments.Count;
        return numberOfComments;
    }

    private void DisplayComments()
    {
        foreach(Comment comment in _comments)
        {
            comment.DisplayComment();
            Console.WriteLine();  // for spacing
        }
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Title: {_title}");
        Console.WriteLine($"Author: {_author}");
        Console.WriteLine($"Length: {_length} secs");
        Console.WriteLine("-----------");
        Console.WriteLine("  COMMENT");
        Console.WriteLine("-----------");
        DisplayComments();
    }
}