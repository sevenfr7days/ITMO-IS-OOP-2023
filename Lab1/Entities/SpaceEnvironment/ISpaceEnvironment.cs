using Itmo.ObjectOrientedProgramming.Lab1.Entities.Fuel;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.GuildMarket;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Models.ValueObject;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceEnvironment;

public interface ISpaceEnvironment
{
    PassingOneEnvironmentResult PassOnePath(IShip ship, IExchange exchange, params IFuel[] fuels);
}