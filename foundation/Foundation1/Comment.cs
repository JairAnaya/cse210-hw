public class Comment
{
    public string _name;
    public string _text;

    public void DisplayComment()
    {
        Console.WriteLine($"Comment from {_name}: {_text}");
    }
}