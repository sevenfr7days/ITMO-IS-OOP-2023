using Itmo.ObjectOrientedProgramming.Lab3.Messages.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

public abstract record MessageBuildingResult
{
    private MessageBuildingResult()
    {
    }

    public sealed record Fail() : MessageBuildingResult();

    public sealed record Success(IMessage Message) : MessageBuildingResult;
}