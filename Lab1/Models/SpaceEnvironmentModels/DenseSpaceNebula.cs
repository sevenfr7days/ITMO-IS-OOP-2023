using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Fuel;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.GuildMarket;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceEnvironment;
using Itmo.ObjectOrientedProgramming.Lab1.Models.FuelModels;
using Itmo.ObjectOrientedProgramming.Lab1.Models.ValueObject;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.SpaceEnvironmentModels;

public class DenseSpaceNebula : ISpaceEnvironment
{
    private readonly LightHours _length;
    private IReadOnlyCollection<IDenseSpaceNebulaObstacle> _obstaclesCollection;

    public DenseSpaceNebula(LightHours length, params IDenseSpaceNebulaObstacle[] obstacles)
    {
        _length = length;
        _obstaclesCollection = obstacles;
    }

    public PassingOneEnvironmentResult PassOnePath(
        IShip ship,
        IExchange exchange,
        params IFuel[] fuels)
    {
        IJumperEngine? jumper = ship.JumperEngine;
        IJumperFuel optimalFuel = new GravitoMatter(int.MaxValue);

        foreach (IFuel fuel in fuels)
        {
            if (fuel.GetMarketPrice(exchange).Amount >= optimalFuel.GetMarketPrice(exchange).Amount) continue;
            if (fuel is IJumperFuel jumperFuel)
            {
                optimalFuel = jumperFuel;
            }
        }

        if (jumper is null)
        {
            return new PassingOneEnvironmentResult.Fail(
                ship,
                new ShipStatus.ShipLost());
        }

        ShipStatus shipStatus = new ShipStatus.Active();
        EnvironmentFlightResult pathResult = jumper.PassPath(_length);

        // Ship can't pass
        if (pathResult is EnvironmentFlightResult.Fail)
        {
            return new PassingOneEnvironmentResult.Fail(
                ship,
                new ShipStatus.ShipLost());
        }

        if (pathResult is EnvironmentFlightResult.Success success)
        {
            optimalFuel = new GravitoMatter(optimalFuel.Amount - success.FuelWasted.Amount);
            Time time = success.TimeWasted;

            foreach (IDenseSpaceNebulaObstacle obstacle in _obstaclesCollection)
            {
                shipStatus = ship.ReceiveDamage(obstacle);
            }

            if (shipStatus is not ShipStatus.Active)
            {
                return new PassingOneEnvironmentResult.Fail(ship, shipStatus);
            }

            return new PassingOneEnvironmentResult.Success(
                ship,
                shipStatus,
                new Money(optimalFuel.Amount * optimalFuel.GetMarketPrice(exchange).Amount),
                time);
        }

        return new PassingOneEnvironmentResult.Fail(
            ship,
            new ShipStatus.ShipLost());
    }
}