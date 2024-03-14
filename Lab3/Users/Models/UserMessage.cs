using Itmo.ObjectOrientedProgramming.Lab3.Messages.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Users.Models;

public record UserMessage(IMessage Message) : IUserMessage
{
    public bool IsRead { get; private set; }

    public string ConvertMessageToString()
    {
        return Message.ConvertMessageToString();
    }

    public ResultType MarkAsRead()
    {
        if (IsRead)
        {
            return new ResultType.Fail();
        }

        IsRead = true;
        return new ResultType.Success();
    }
}