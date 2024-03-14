using Itmo.ObjectOrientedProgramming.Lab3.Messages.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Recipient.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messenger.Entities;

public class MessengerRecipient : IRecipient
{
    private readonly IExternalMessenger _externalMessenger;

    public MessengerRecipient(IExternalMessenger externalMessenger)
    {
        _externalMessenger = externalMessenger;
    }

    public void ReceiveMessage(IMessage message)
    {
        _externalMessenger.WriteMessage(message.ConvertMessageToString());
    }
}