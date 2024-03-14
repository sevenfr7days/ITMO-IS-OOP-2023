using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.DifferentThings;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Cpu.Entity;

public interface ICpu : IComponent
{
    Gigahertz CoreFrequency { get; }
    Quantity CoresQuantity { get; }
    Socket Socket { get; }
    bool IsVideoCoreIntegrated { get; }
    Watt Tdp { get; }
    Watt PowerConsumption { get; }
    ICollection<Megahertz> SupportedMemoryFrequencies { get; }
}