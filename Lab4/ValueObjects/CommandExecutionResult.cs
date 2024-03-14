namespace Itmo.ObjectOrientedProgramming.Lab4.ValueObjects;

public abstract record CommandExecutionResult()
{
    public sealed record Success : CommandExecutionResult;

    public record Fail(string ErrorMessage) : CommandExecutionResult;

    public sealed record FileWasNotFound(string ErrorMessage) : Fail(ErrorMessage);

    public sealed record FileIsAlreadyExist(string ErrorMessage) : Fail(ErrorMessage);

    public sealed record UnknownMood(string ErrorMessage) : Fail(ErrorMessage);

    public sealed record SubdirectoryWasNotFound(string ErrorMessage) : Fail(ErrorMessage);

    public sealed record DirectoryWasNotFound(string ErrorMessage) : Fail(ErrorMessage);
}