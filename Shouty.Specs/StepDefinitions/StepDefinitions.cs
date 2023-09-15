using TechTalk.SpecFlow;
using Xunit;

namespace Shouty.Specs.StepDefinitions;

[Binding]
public class StepDefinitions
{   
    private Network network;
    private Person lucy;
    private Person sean;
    private string messageFromSean;

    [BeforeScenario]
    public void CreateNetwork()
    {
        network = new Network();
    }

    [Given("a person named Lucy")]
    public void GivenAPersonNamedLucy()
    {
        lucy = new(network);
    }

    [Given("a person named Sean")]
    public void GivenAPersonNamedSean()
    {
        sean = new(network);
    }
    
    [When("Sean shouts {string}")]
    public void WhenSeanshouts(string message)
    {
        sean.Shout(message);
        messageFromSean = message;
    }

    [Then("Lucy hears Sean's message")]
    public void ThenLucyHearsSeansMessage()
    {
        Assert.Contains(messageFromSean, lucy.GetMessagesHeard());
    }
}