using Itmo.ObjectOrientedProgramming.Lab4.Command.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.ValueObjects;

public abstract record HandleResult
{
    public sealed record Success(ICommand Command) : HandleResult;

    public sealed record Fail() : HandleResult;
}