using Itmo.ObjectOrientedProgramming.Lab1.Entities.Fuel;
using Itmo.ObjectOrientedProgramming.Lab1.Models.ValueObject;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

public interface IImpulseEngine
{
    public EnvironmentFlightResult PassPath(LightHours length, IFuel amountOfFuel);
    public void DecreaseSpeed();
}