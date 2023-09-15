namespace Shouty;

public class Person
{
    private readonly Network network;
    private readonly List<string> messagesHeard = new ();
    public int Location { get; }

    public Person(Network network, int location)
    {
        this.network = network;
        this.Location = location;
        network.Subscribe(this);
    }

    public IEnumerable<string> GetMessagesHeard()
    {
        return messagesHeard;
    }

     public class HeardMessage
    {
        public required string Message { get; set; }
    }

    public IList<HeardMessage> GetMessagesHeardEx()
    {
        return messagesHeard
            .Select(m => new HeardMessage {Message = m})
            .ToArray();
    }

    public void Shout(string message)
    {
        network.Broadcast(message, Location);
    }

    public void Hear(string message)
    {
        messagesHeard.Add(message);
    }
}