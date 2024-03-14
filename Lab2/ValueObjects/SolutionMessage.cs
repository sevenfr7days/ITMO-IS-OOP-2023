namespace Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

public abstract record SolutionMessage
{
    protected SolutionMessage() { }

    private SolutionMessage(string message)
    {
        Message = message;
    }

    public string? Message { get; }

    public sealed record Success : SolutionMessage;

    public sealed record Warning(string Message) : SolutionMessage(Message);

    public sealed record Fail(string Message) : SolutionMessage(Message);
}
