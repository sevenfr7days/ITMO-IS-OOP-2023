using Itmo.ObjectOrientedProgramming.Lab1.Entities.Fuel;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.ValueObject;

public abstract record EnvironmentFlightResult
{
    public sealed record Success(IFuel FuelWasted, Time TimeWasted) : EnvironmentFlightResult();

    public sealed record Fail() : EnvironmentFlightResult();
}
