using Itmo.ObjectOrientedProgramming.Lab1.Entities.GuildMarket;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Routes;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceEnvironment;
using Itmo.ObjectOrientedProgramming.Lab1.Models.FuelModels;
using Itmo.ObjectOrientedProgramming.Lab1.Models.ValueObject;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services;

public class Expedition
{
    private readonly Route _route;
    private readonly IExchange _exchange;

    public Expedition(Route route, IExchange exchange)
    {
        _route = route;
        _exchange = exchange;
    }

    public ExpeditionResult PassRoute(IShip ship, ActivePlasma beginActivePlasmaFuel, GravitoMatter beginGravitoMatterFuel)
    {
        PassingOneEnvironmentResult? pathResult = null;
        ExpeditionResult expeditionResult = new ExpeditionResult.Fail(null);
        var time = new Time(0);
        var price = new Money(0);

        foreach (ISpaceEnvironment environment in _route.EnvironmentsCollection)
        {
            pathResult =
                environment.PassOnePath(ship, _exchange, beginActivePlasmaFuel, beginGravitoMatterFuel);
            if (pathResult is PassingOneEnvironmentResult.Success passingOneEnvironmentResultSuccess)
            {
                time = new Time(time.Amount + passingOneEnvironmentResultSuccess.Time.Amount);
                price = new Money(price.Amount + passingOneEnvironmentResultSuccess.Price.Amount);
            }

            if (pathResult is not PassingOneEnvironmentResult.Success || pathResult.ShipStatus is not ShipStatus.Active) break;
        }

        if (pathResult is PassingOneEnvironmentResult.Success { ShipStatus: ShipStatus.Active } success)
        {
            expeditionResult = new ExpeditionResult.Success(ship, price, success.Time);
        }

        expeditionResult = pathResult?.ShipStatus switch
        {
            ShipStatus.CrewDead => new ExpeditionResult.CrewDead(ship),
            ShipStatus.ShipBrokenDown => new ExpeditionResult.ShipBrokenDown(ship),
            ShipStatus.ShipLost => new ExpeditionResult.ShipLost(ship),
            _ => expeditionResult,
        };

        return expeditionResult;
    }
}