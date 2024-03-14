using System;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.GuildMarket;
using Itmo.ObjectOrientedProgramming.Lab1.Models.ValueObject;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.MarketModels;

public class Exchange : IExchange
{
    private readonly Collection<MarketAttitude> _fuelPrices = new();

    public Exchange(params MarketAttitude[] prices)
    {
        foreach (MarketAttitude marketAttitude in prices)
        {
            _fuelPrices.Add(marketAttitude);
        }
    }

    public Money GetPriceForFuelType(Type fuelType)
    {
        foreach (MarketAttitude marketAttitude in _fuelPrices)
        {
            if (fuelType == marketAttitude.FuelType)
            {
                return marketAttitude.FuelPrice;
            }
        }

        return new Money(0);
    }
}