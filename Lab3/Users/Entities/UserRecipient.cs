using Itmo.ObjectOrientedProgramming.Lab3.Messages.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Recipient.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Users.Entities;

public class UserRecipient : IRecipient
{
    private readonly IUser _user;

    public UserRecipient(IUser user)
    {
        _user = user;
    }

    public ResultType MarkAsRead(Id messageId)
    {
        return _user.MarkAsRead(messageId);
    }

    public void ReceiveMessage(IMessage? message)
    {
        if (message is not null)
        {
            _user.ReceiveMessage(message);
        }
    }
}