using Moq;
using Xunit;

namespace Shouty.Tests;

public class PersonTests
{
    private readonly Mock<Network> networkMock = new();
    

    [Fact]
    public void It_subscribes_to_the_network()
    {
        var person = new Person(networkMock.Object);
        networkMock.Verify(n => n.Subscribe(person));
    }

    [Fact]
    public void Broadcasts_shouts_to_the_network()
    {
        const string message = "free bagels!";
        var sean = new Person(networkMock.Object);
        sean.Shout(message);
        networkMock.Verify(n => n.Broadcast(message));
    }

    [Fact]
    public void Remembers_messages_heard()
    {
        const string message = "Free bagels!";
        var lucy = new Person(networkMock.Object);
        lucy.Hear(message);
        Assert.Contains(message, lucy.GetMessagesHeard());
    }
}