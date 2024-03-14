namespace Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

public record ResultType
{
    public sealed record Fail : ResultType;

    public sealed record Success : ResultType;
}