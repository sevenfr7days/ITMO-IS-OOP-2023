using Itmo.ObjectOrientedProgramming.Lab1.Models.ValueObject;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.GuildMarket;

public interface IExchange
{
    Money GetPriceForFuelType(System.Type fuelType);
}