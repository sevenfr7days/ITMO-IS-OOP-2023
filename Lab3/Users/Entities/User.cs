using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab3.Messages.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Users.Models;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Users.Entities;

public class User : IUser
{
    private readonly IList<IUserMessage> _unreadMessages;
    private readonly IList<IUserMessage> _readMessages;

    public User(Id id)
    {
        Id = id;
        _unreadMessages = new List<IUserMessage>();
        _readMessages = new List<IUserMessage>();
    }

    public IEnumerable<IUserMessage> UnreadMessages => _unreadMessages.AsReadOnly();

    public IEnumerable<IUserMessage> ReadMessages => _readMessages.AsReadOnly();

    public Id Id { get; }

    public void ReceiveMessage(IMessage message)
    {
        var userMessage = new UserMessage(message);
        _unreadMessages.Add(userMessage);
    }

    public ResultType MarkAsRead(Id messageId)
    {
        IUserMessage? messageToMark = _unreadMessages.FirstOrDefault(x => x.Message.Id == messageId);

        if (messageToMark is null) return new ResultType.Fail();

        messageToMark.MarkAsRead();
        _unreadMessages.Remove(messageToMark);
        _readMessages.Add(messageToMark);
        return new ResultType.Success();
    }
}