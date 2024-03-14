using Itmo.ObjectOrientedProgramming.Lab4.States.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.ValueObjects;

public abstract record StateBuildingResult
{
    public sealed record Success(Context Context) : StateBuildingResult;

    public sealed record Fail : StateBuildingResult;
}