using Itmo.ObjectOrientedProgramming.Lab2.PowerSupply.Models;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.PowerSupply.Entity;

public interface IPowerSupplyBuilder
{
    public PowerSupplyBuilder WithName(Name name);

    public PowerSupplyBuilder WithPeakLoadPower(Watt peakLoadPower);

    public Models.PowerSupply Build();
}