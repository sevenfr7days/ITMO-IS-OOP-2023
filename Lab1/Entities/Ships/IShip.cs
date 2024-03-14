using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Models.ValueObject;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;

public interface IShip
{
    IJumperEngine? JumperEngine { get; }
    IImpulseEngine ImpulseEngine { get; }
    ShipStatus ReceiveDamage(IObstacle obstacle);
}