namespace Itmo.ObjectOrientedProgramming.Lab1.Models.ValueObject;

public abstract record ShipStatus
{
    public sealed record Active : ShipStatus;

    public sealed record CrewDead : ShipStatus;

    public sealed record ShipLost : ShipStatus;

    public sealed record ShipBrokenDown : ShipStatus;
}