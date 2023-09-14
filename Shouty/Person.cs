


namespace Shouty;

public class Person
{
    public IEnumerable<string> GetMessagesHeard()
    {
        return new List<string> { "free bagels at Sean's" };
    }

    public void MoveTo(int distance)
    {
    }

    public void Shout(string message)
    {
    }
}