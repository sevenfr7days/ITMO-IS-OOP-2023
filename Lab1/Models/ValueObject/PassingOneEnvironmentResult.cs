using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.ValueObject;

public abstract record PassingOneEnvironmentResult(IShip? Ship, ShipStatus? ShipStatus)
{
    public sealed record Success
        (IShip? Ship, ShipStatus? ShipStatus, Money Price, Time Time) : PassingOneEnvironmentResult(Ship, ShipStatus);
    public sealed record Fail
        (IShip? Ship, ShipStatus? ShipStatus) : PassingOneEnvironmentResult(Ship, ShipStatus);
}