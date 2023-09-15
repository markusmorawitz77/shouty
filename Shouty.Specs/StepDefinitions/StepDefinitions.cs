using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Xunit;

namespace Shouty.Specs.StepDefinitions;

[Binding]
public class StepDefinitions
{   
    private const int DEFAULT_RANGE = 100;
    private Network network = new Network(DEFAULT_RANGE);
    private Dictionary<string, Person> people;
    private string shoutedMessage;

    public class Whereabouts
    {
        public string Name { get; set; }
        public int Location {get; set; }
    }

    [StepArgumentTransformation]
    public Whereabouts[] ConvertWhereabouts(Table table)
    {
        return table.CreateSet<Whereabouts>().ToArray();
    }

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

    [Given("a person named {word}")]
    public void GivenAPersonWithDefaultLocation(string name)
    {
        people.Add(name, new Person(network, 0));
    }

    [Given("people are located at")]
    public void GivenPeopleAreLocatedAt(Whereabouts[] whereaboutsList)
    {
        foreach (var whereabouts in whereaboutsList)
        {
            people.Add(whereabouts.Name, new Person(network, whereabouts.Location));
        }
    }

    [Given("a person named {word} is located at {int}")]
    public void GivenAPerson(string name, int location)
    {
        people.Add(name, new Person(network, location));
    }

    [When("{word} shouts")]
    public void WhenSomeoneShouts(string name)
    {
        people[name].Shout("Hello");
    }
    
    [When("{word} shouts {string}")]
    [When("{word} shouts the following message")]
    public void WhenSomeoneShoutsAMessage(string name, string message)
    {
        people[name].Shout(message);
        shoutedMessage = message;
    }

    [Then("{word} should hear a shout")]
    public void ThenListenerShouldHearAShout(string listener)
    {
        Assert.Single(people[listener].GetMessagesHeard());
    }

    [Then("{word} should not hear a shout")]
    public void ThenListenerShouldNotHearAShout(string listener)
    {
        Assert.Empty(people[listener].GetMessagesHeard());
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

    [Then("{word} hears the following messages:")]
    public void ThenListenerHearsTheFollowingMessages(string listener, Table expectedMessagesTable)
    {
        var actualMessages = people[listener].GetMessagesHeardEx();
        expectedMessagesTable.CompareToSet(actualMessages);
    }
}