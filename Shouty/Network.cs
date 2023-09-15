namespace Shouty;

public class Network
{
    private readonly List<Person> listeners = new();

    public virtual void Subscribe(Person person)
    {
        listeners.Add(person);
    }

    public virtual void Broadcast(string message)
    {
        foreach (var listener in listeners)
        {
            listener.Hear(message);
        }
    }

}