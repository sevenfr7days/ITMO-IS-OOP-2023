using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Models.FuelModels;
using Itmo.ObjectOrientedProgramming.Lab1.Models.ValueObject;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.EngineModels;

public class JumperEngineGammaClass : IJumperEngine
{
    private const int JumperEngineGammaClassSpeed = 3000;
    private readonly LightHours _speed;

    public JumperEngineGammaClass()
    {
        _speed = new LightHours(JumperEngineGammaClassSpeed);
    }

    public EnvironmentFlightResult PassPath(LightHours length)
    {
        if (length.Amount <= _speed.Amount)
        {
            return new EnvironmentFlightResult.Success(
                new GravitoMatter((int)(length.Amount * Math.Log10(length.Amount))),
                new Time(length.Amount / _speed.Amount));
        }

        return new EnvironmentFlightResult.Fail();
    }
}