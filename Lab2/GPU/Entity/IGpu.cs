using Itmo.ObjectOrientedProgramming.Lab2.DifferentThings;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.GPU.Entity;

public interface IGpu : IComponent
{
    Millimeters Length { get; }
    Millimeters Width { get; }
    MemorySize Memory { get; }
    Version PcieVersion { get; }
    Megahertz ChipFrequency { get; }
    Watt PowerConsumption { get; }
}