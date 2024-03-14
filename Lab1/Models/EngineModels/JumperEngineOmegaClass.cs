using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Models.FuelModels;
using Itmo.ObjectOrientedProgramming.Lab1.Models.ValueObject;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.EngineModels;

public class JumperEngineOmegaClass : IJumperEngine
{
    private const int JumperEngineOmegaClassSpeed = 500;
    private readonly LightHours _speed;

    public JumperEngineOmegaClass()
    {
        _speed = new LightHours(JumperEngineOmegaClassSpeed);
    }

    public EnvironmentFlightResult PassPath(LightHours length)
    {
        if (length.Amount <= _speed.Amount)
        {
            return new EnvironmentFlightResult.Success(
                new GravitoMatter((int)Math.Pow(length.Amount, 2)),
                new Time(length.Amount / _speed.Amount));
        }

        return new EnvironmentFlightResult.Fail();
    }
}