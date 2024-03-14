using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.ValueObject;

public abstract record ExpeditionResult
{
    private ExpeditionResult(IShip? ship)
    {
        Ship = ship;
    }

    public IShip? Ship { get; }

    public sealed record Success(IShip Ship, Money Price, Time Time) : ExpeditionResult(Ship);

    public sealed record CrewDead(IShip? Ship) : ExpeditionResult(Ship);

    public sealed record ShipLost(IShip? Ship) : ExpeditionResult(Ship);

    public sealed record Fail(IShip? Ship) : ExpeditionResult(Ship);

    public sealed record ShipBrokenDown(IShip? Ship) : ExpeditionResult(Ship);
}