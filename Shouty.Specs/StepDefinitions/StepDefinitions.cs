using TechTalk.SpecFlow;
using Xunit;

namespace Shouty.Specs.StepDefinitions;

[Binding]
public class StepDefinitions
{   
    private Person lucy;
    private Person sean;
    private string messageFromSean;

    [Given("Lucy is {int} metre(s) from Sean")]
    public void GivenLucyislocatedmfromSean(int distance)
    {        
        var network = new Network();
        sean = new(network);
        lucy = new(network);
        lucy.MoveTo(distance);
    }

    [Given("a person named Lucy")]
    public void GivenAPersonNamedLucy()
    {
        throw new PendingStepException();
    }

    [Given("a person named Sean")]
    public void GivenAPersonNamedSean()
    {
        throw new PendingStepException();
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