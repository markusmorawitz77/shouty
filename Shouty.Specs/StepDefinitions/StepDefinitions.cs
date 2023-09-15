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
        network = new Network();
        people = new Dictionary<string, Person>();
    }

    [Given("a person named {word}")]
    public void GivenAPerson(string name)
    {
        people.Add(name, new Person(network));
    }
    
    [When("{word} shouts {string}")]
    public void WhenSeanshouts(string name, string message)
    {
        people[name].Shout(message);
        shoutedMessage = message;
    }

    [Then("{word} hears {word}'s message")]
    public void ThenLucyHearsSeansMessage(string listener, string shouter)
    {
        Assert.Contains(shoutedMessage, people[listener].GetMessagesHeard());
    }
}