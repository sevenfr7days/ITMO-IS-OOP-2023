using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Fuel;
using Itmo.ObjectOrientedProgramming.Lab1.Models.FuelModels;
using Itmo.ObjectOrientedProgramming.Lab1.Models.ValueObject;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.EngineModels;

public class ImpulseEngineCClass : IImpulseEngine
{
    private const int ImpulseEngineCClassSpeed = 10;
    private const int ImpulseEngineCClassFuelConsumption = 10;
    private const int ImpulseEngineSpeedSlowingCoefficient = 5;
    private readonly ActivePlasma _fuelConsumption;
    private LightHours _speed;

    public ImpulseEngineCClass(int shipMultiplier)
    {
        _speed = new LightHours(ImpulseEngineCClassSpeed);
        _fuelConsumption = new ActivePlasma(ImpulseEngineCClassFuelConsumption * shipMultiplier);
    }

    public EnvironmentFlightResult PassPath(LightHours length, IFuel amountOfFuel)
    {
        if (length.Amount <= _speed.Amount * (amountOfFuel.Amount / _fuelConsumption.Amount))
        {
            var time = new Time(length.Amount / _speed.Amount);
            return new EnvironmentFlightResult.Success(new ActivePlasma(_fuelConsumption.Amount * time.Amount), time);
        }

        return new EnvironmentFlightResult.Fail();
    }

    public void DecreaseSpeed()
    {
        _speed = new LightHours(_speed.Amount / ImpulseEngineSpeedSlowingCoefficient);
    }
}