using TechTalk.SpecFlow;
using Xunit;

namespace Shouty.Specs.StepDefinitions;

[Binding]
public class StepDefinitions
{
    private Person lucy = new ();
    private Person sean = new ();

    private string messageFromSean;

    [Given("Lucy is located {int}m from Sean")]
    public void GivenLucyislocatedmfromSean(int distance)
    {        
        lucy.MoveTo(distance);
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