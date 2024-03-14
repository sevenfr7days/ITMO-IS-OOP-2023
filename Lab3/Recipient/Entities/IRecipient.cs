using Itmo.ObjectOrientedProgramming.Lab3.Messages.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Recipient.Entities;

public interface IRecipient
{
    void ReceiveMessage(IMessage message);
}