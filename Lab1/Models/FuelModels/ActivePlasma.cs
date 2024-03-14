using Itmo.ObjectOrientedProgramming.Lab1.Entities.Fuel;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.GuildMarket;
using Itmo.ObjectOrientedProgramming.Lab1.Models.ValueObject;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.FuelModels;

public class ActivePlasma : IImpulseFuel
{
    public ActivePlasma(int amount)
    {
        Amount = amount;
    }

    public int Amount { get; }

    public Money GetMarketPrice(IExchange exchange)
    {
        return exchange.GetPriceForFuelType(GetType());
    }
}