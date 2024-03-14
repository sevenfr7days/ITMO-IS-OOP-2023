using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Models.FuelModels;
using Itmo.ObjectOrientedProgramming.Lab1.Models.ValueObject;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.EngineModels;

public class JumperEngineAClass : IJumperEngine
{
    private const int JumperEngineAClassSpeed = 100;
    private readonly LightHours _speed;

    public JumperEngineAClass()
    {
        _speed = new LightHours(JumperEngineAClassSpeed);
    }

    public EnvironmentFlightResult PassPath(LightHours length)
    {
        if (length.Amount <= _speed.Amount)
        {
            return new EnvironmentFlightResult.Success(
                new GravitoMatter(length.Amount / _speed.Amount),
                new Time(length.Amount / _speed.Amount));
        }

        return new EnvironmentFlightResult.Fail();
    }
}