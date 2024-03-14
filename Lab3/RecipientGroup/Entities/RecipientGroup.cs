using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Messages.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Recipient.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab3.RecipientGroup.Entities;

public class RecipientGroup : IRecipient
{
    private readonly IEnumerable<IRecipient> _recipients;

    public RecipientGroup(IEnumerable<IRecipient> recipients)
    {
        _recipients = recipients;
    }

    public void ReceiveMessage(IMessage message)
    {
        foreach (IRecipient recipient in _recipients)
        {
            recipient.ReceiveMessage(message);
        }
    }
}