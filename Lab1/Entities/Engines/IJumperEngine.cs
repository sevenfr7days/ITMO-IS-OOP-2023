using Itmo.ObjectOrientedProgramming.Lab1.Models.ValueObject;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

public interface IJumperEngine
{
    public EnvironmentFlightResult PassPath(LightHours length);
}