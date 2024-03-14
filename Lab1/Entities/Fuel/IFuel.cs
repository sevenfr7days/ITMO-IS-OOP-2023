using Itmo.ObjectOrientedProgramming.Lab1.Entities.GuildMarket;
using Itmo.ObjectOrientedProgramming.Lab1.Models.ValueObject;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Fuel;

public interface IFuel
{
    int Amount { get; }
    Money GetMarketPrice(IExchange exchange);
}