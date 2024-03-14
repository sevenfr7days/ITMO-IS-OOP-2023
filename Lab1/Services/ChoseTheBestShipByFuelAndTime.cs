using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.GuildMarket;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Routes;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Models.FuelModels;
using Itmo.ObjectOrientedProgramming.Lab1.Models.ValueObject;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services;

public class ChoseTheBestShipByFuelAndTime : IChoseTheBestShip
{
    private readonly Route _route;
    private readonly IExchange _exchange;

    public ChoseTheBestShipByFuelAndTime(Route route, IExchange exchange)
    {
        _route = route;
        _exchange = exchange;
    }

    public ExpeditionResult FindOptimalShip(ICollection<IShip> ships)
    {
        IShip? optimalShip = null;
        var minPrice = new Money(int.MaxValue);
        var minTime = new Time(int.MaxValue);

        foreach (IShip ship in ships)
        {
            var expedition = new Expedition(_route, _exchange);
            ExpeditionResult result = expedition.PassRoute(ship, new ActivePlasma(int.MaxValue), new GravitoMatter(int.MaxValue));

            if (result is not ExpeditionResult.Success success) continue;
            if (success.Price.Amount > minPrice.Amount) continue;
            if (success.Time.Amount > minTime.Amount) continue;
            minPrice = success.Price;
            optimalShip = success.Ship;
            minTime = success.Time;
        }

        return optimalShip is not null
            ? new ExpeditionResult.Success(optimalShip, minPrice, minTime)
            : new ExpeditionResult.Fail(null);
    }
}