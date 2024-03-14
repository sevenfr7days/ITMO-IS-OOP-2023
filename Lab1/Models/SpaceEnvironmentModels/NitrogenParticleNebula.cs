using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Fuel;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.GuildMarket;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceEnvironment;
using Itmo.ObjectOrientedProgramming.Lab1.Models.EngineModels;
using Itmo.ObjectOrientedProgramming.Lab1.Models.FuelModels;
using Itmo.ObjectOrientedProgramming.Lab1.Models.ValueObject;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.SpaceEnvironmentModels;

public class NitrogenParticleNebula : ISpaceEnvironment
{
    private readonly LightHours _length;
    private IReadOnlyCollection<INitrogenParticleNebulaObstacle> _obstaclesCollection;

    public NitrogenParticleNebula(LightHours length, params INitrogenParticleNebulaObstacle[] obstacles)
    {
        _length = length;
        _obstaclesCollection = obstacles;
    }

    public PassingOneEnvironmentResult PassOnePath(
        IShip ship,
        IExchange exchange,
        params IFuel[] fuels)
    {
        IImpulseFuel optimalFuel = new ActivePlasma(int.MaxValue);

        foreach (IFuel fuel in fuels)
        {
            if (fuel.GetMarketPrice(exchange).Amount >= optimalFuel.GetMarketPrice(exchange).Amount) continue;
            if (fuel is IImpulseFuel impulseFuel)
            {
                optimalFuel = impulseFuel;
            }
        }

        ShipStatus shipStatus = new ShipStatus.Active();

        if (ship.ImpulseEngine is ImpulseEngineCClass)
        {
            ship.ImpulseEngine.DecreaseSpeed();
        }

        EnvironmentFlightResult pathResult = ship.ImpulseEngine.PassPath(_length, optimalFuel);
        if (pathResult is EnvironmentFlightResult.Success success)
        {
            optimalFuel = new ActivePlasma(optimalFuel.Amount - success.FuelWasted.Amount);
            Time time = success.TimeWasted;

            foreach (INitrogenParticleNebulaObstacle obstacle in _obstaclesCollection)
            {
                shipStatus = ship.ReceiveDamage(obstacle);
            }

            return new PassingOneEnvironmentResult.Success(
                ship,
                shipStatus,
                new Money(optimalFuel.Amount * optimalFuel.GetMarketPrice(exchange).Amount),
                time);
        }

        return new PassingOneEnvironmentResult.Fail(ship, shipStatus);
    }
}