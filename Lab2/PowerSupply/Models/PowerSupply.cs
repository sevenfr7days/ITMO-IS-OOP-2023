using System;
using Itmo.ObjectOrientedProgramming.Lab2.PowerSupply.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.PowerSupply.Models;

public class PowerSupply : IPowerSupply
{
    public PowerSupply(Name? name, Watt? peakLoadPower)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        PeakLoadPower = peakLoadPower ?? throw new ArgumentNullException(nameof(peakLoadPower));
    }

    public Watt PeakLoadPower { get; }
    public Name Name { get; }
}