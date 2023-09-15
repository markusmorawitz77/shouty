namespace Shouty;

public class Person
{
    private readonly Network network;
    private readonly List<string> messagesHeard = new ();

    public Person(Network network)
    {
        this.network = network;
        network.Subscribe(this);
    }

    public IEnumerable<string> GetMessagesHeard()
    {
        return messagesHeard;
    }

    public void Shout(string message)
    {
        network.Broadcast(message);
    }

    public void Hear(string message)
    {
        messagesHeard.Add(message);
    }
}