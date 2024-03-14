namespace Itmo.ObjectOrientedProgramming.Lab2;

public abstract record Results
{
    private Results()
    {
    }

    private Results(string message)
    {
        Message = message;
    }

    private string? Message { get; }

    public sealed record Success() : Results();

    public sealed record Fail(string Message) : Results(Message);

    public sealed record Warning(string Message) : Results(Message);
}