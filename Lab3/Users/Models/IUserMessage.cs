using Itmo.ObjectOrientedProgramming.Lab3.Messages.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Users.Models;

public interface IUserMessage
{
    bool IsRead { get; }
    IMessage Message { get; }
    ResultType MarkAsRead();
}