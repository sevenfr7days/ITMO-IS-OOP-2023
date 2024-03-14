using Itmo.ObjectOrientedProgramming.Lab3.Messages.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Users.Entities;

public interface IUser
{
    Id Id { get; }
    void ReceiveMessage(IMessage message);
    ResultType MarkAsRead(Id messageId);
}