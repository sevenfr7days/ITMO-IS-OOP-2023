using Itmo.ObjectOrientedProgramming.Lab1.Entities.Fuel;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.GuildMarket;
using Itmo.ObjectOrientedProgramming.Lab1.Models.ValueObject;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.FuelModels;

public class GravitoMatter : IJumperFuel
{
    public GravitoMatter(int amount)
    {
        Amount = amount;
    }

    public int Amount { get; }

    public Money GetMarketPrice(IExchange exchange)
    {
        return exchange.GetPriceForFuelType(GetType());
    }
}