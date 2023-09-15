using TechTalk.SpecFlow;
using Xunit;

namespace Shouty.Specs.StepDefinitions;

[Binding]
public class StepDefinitions
{

    private string messageFromSean;

    [Given("{Person} is located {int}m from {Person}")]
    public void GivenLucyislocatedmfromSean(Person receiver, int distance, Person sender)
    {        
        receiver.MoveTo(distance);
    }
    
    [When("{Person} shouts {string}")]
    public void WhenSeanshouts(Person sender, string message)
    {
        sender.Shout(message);
        messageFromSean = message;
    }

    [Then("{Person} hears {Person}'s message")]
    public void ThenLucyHearsSeansMessage(Person receiver, Person sender)
    {
        Assert.Contains(messageFromSean, receiver.GetMessagesHeard());
    }
}