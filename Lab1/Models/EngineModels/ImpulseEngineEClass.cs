using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Fuel;
using Itmo.ObjectOrientedProgramming.Lab1.Models.FuelModels;
using Itmo.ObjectOrientedProgramming.Lab1.Models.ValueObject;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.EngineModels;

public class ImpulseEngineEClass : IImpulseEngine
{
    private const int ImpulseEngineEClassSpeed = 1;
    private const int ImpulseEngineEClassFuelConsumption = 200;
    private readonly ActivePlasma _fuelConsumption;

    public ImpulseEngineEClass(int shipMultiplier)
    {
        Speed = new LightHours(ImpulseEngineEClassSpeed);
        _fuelConsumption = new ActivePlasma(ImpulseEngineEClassFuelConsumption * shipMultiplier);
    }

    public LightHours Speed { get; private set; }

    public EnvironmentFlightResult PassPath(LightHours length, IFuel amountOfFuel)
    {
        int t = 0;
        while (length.Amount > 0)
        {
            length = new LightHours(length.Amount - (int)Math.Exp(t));
            ++t;
        }

        if (amountOfFuel.Amount >= t * _fuelConsumption.Amount)
        {
            return new EnvironmentFlightResult.Success(new ActivePlasma(t * _fuelConsumption.Amount), new Time(t));
        }

        return new EnvironmentFlightResult.Fail();
    }

    public void DecreaseSpeed()
    {
    }
}