public class Video
{
    public string _title;
    public string _author;
    public int _length;
    public List<Comment> _comments = new List<Comment>();

    public string DisplayList()
    {
        return $"\nVideo : {_title}.\nAuthor : {_author}.\nLength : {_length}s.\n";
    }

    public string NumberOfComments()
    {
        return $"Number of comments : {_comments.Count()}";
    }

    public void PrintComments()
    {
        foreach (Comment C in _comments)
        {
            C.DisplayComment();
        }
    }
}