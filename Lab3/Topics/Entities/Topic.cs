using Itmo.ObjectOrientedProgramming.Lab3.Messages.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Recipient.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Topics.Entities;

public class Topic : ITopic
{
    private readonly IRecipient _recipient;
    private string _name;

    public Topic(string name, IRecipient recipient)
    {
        _name = name;
        _recipient = recipient;
    }

    public void Send(IMessage message)
    {
        _recipient.ReceiveMessage(message);
    }
}