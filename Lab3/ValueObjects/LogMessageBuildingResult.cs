using Itmo.ObjectOrientedProgramming.Lab3.Logger.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

public abstract record LogMessageBuildingResult
{
    private LogMessageBuildingResult()
    {
    }

    public sealed record Fail() : LogMessageBuildingResult();

    public sealed record Success(LogMessage LogMessage) : LogMessageBuildingResult;
}
