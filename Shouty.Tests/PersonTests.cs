using Moq;
using Xunit;

namespace Shouty.Tests;

public class PersonTests
{
    // for mocking a default constructor is necessary
    public class TestableNetwork : Network
    {
        public TestableNetwork() : base(100) { }
    }

    private readonly Mock<TestableNetwork> networkMock = new();
    

    [Fact]
    public void It_subscribes_to_the_network()
    {
        var person = new Person(networkMock.Object, 100);
        networkMock.Verify(n => n.Subscribe(person));
    }

    [Fact]
    public void It_has_a_location()
    {
        var person = new Person(networkMock.Object, 100);
        Assert.Equal(100, person.Location);
    }

    [Fact]
    public void Broadcasts_shouts_to_the_network()
    {
        const string message = "free bagels!";
        var sean = new Person(networkMock.Object, 0);
        sean.Shout(message);
        networkMock.Verify(n => n.Broadcast(message, 0));
    }

    [Fact]
    public void Remembers_messages_heard()
    {
        const string message = "Free bagels!";
        var lucy = new Person(networkMock.Object, 100);
        lucy.Hear(message);
        Assert.Contains(message, lucy.GetMessagesHeard());
    }
}