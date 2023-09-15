using TechTalk.SpecFlow;
using Xunit;

namespace Shouty.Specs.StepDefinitions;

[Binding]
public class StepDefinitions
{   
    private Network network;
    private Dictionary<string, Person> people;
    private string shoutedMessage;

    [BeforeScenario]
    public void CreateNetwork()
    {
        people = new Dictionary<string, Person>();
    }

    [Given("the range is {int}")]
    public void GivenTheRangeIs(int range)
    {
        network = new Network(range);
    }

    [Given("a person named {word} is located at {int}")]
    public void GivenAPerson(string name, int location)
    {
        people.Add(name, new Person(network, location));
    }
    
    [When("{word} shouts {string}")]
    public void WhenSeanshouts(string name, string message)
    {
        people[name].Shout(message);
        shoutedMessage = message;
    }

    [Then("{word} should hear {word}'s message")]
    public void ThenListenerShouldHearShoutersMessage(string listener, string shouter)
    {
        Assert.Contains(shoutedMessage, people[listener].GetMessagesHeard());
    }

    [Then("{word} should not hear {word}'s message")]
    public void ThenListenerShouldNotHearShoutersMessage(string listener, string shouter)
    {
        Assert.DoesNotContain(shoutedMessage, people[listener].GetMessagesHeard());
    }
}