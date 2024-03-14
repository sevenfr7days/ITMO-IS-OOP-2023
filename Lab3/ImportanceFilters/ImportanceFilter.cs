using Itmo.ObjectOrientedProgramming.Lab3.Messages.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Recipient.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.ImportanceFilters;

public class ImportanceFilter : IRecipient
{
    private readonly IRecipient _recipient;
    private readonly ImportanceLevel _importanceLevel;

    public ImportanceFilter(IRecipient recipient, ImportanceLevel importanceLevel)
    {
        _recipient = recipient;
        _importanceLevel = importanceLevel;
    }

    public void ReceiveMessage(IMessage message)
    {
        if (_importanceLevel >= message.ImportanceLevel)
        {
            _recipient.ReceiveMessage(message);
        }
    }
}