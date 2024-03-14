using Itmo.ObjectOrientedProgramming.Lab2.DifferentThings;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.PowerSupply.Entity;

public interface IPowerSupply : IComponent
{
    Watt PeakLoadPower { get; }
}