using Itmo.ObjectOrientedProgramming.Lab3.Messages.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Recipient.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Logger.Entities;

public class LoggingRecipient : IRecipient
{
    private readonly ILogger _messageLogger;
    private readonly IRecipient _recipient;

    public LoggingRecipient(ILogger messageLogger, IRecipient recipient)
    {
        _messageLogger = messageLogger;
        _recipient = recipient;
    }

    public void ReceiveMessage(IMessage message)
    {
        _messageLogger.Log(message.ConvertMessageToString());
        _recipient.ReceiveMessage(message);
    }
}