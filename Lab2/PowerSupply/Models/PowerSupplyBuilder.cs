using Itmo.ObjectOrientedProgramming.Lab2.PowerSupply.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.PowerSupply.Models;

public class PowerSupplyBuilder : IPowerSupplyBuilder
{
    private Name? _name;
    private Watt? _peakLoadPower;

    public PowerSupplyBuilder()
    {
    }

    public PowerSupplyBuilder(IPowerSupply innerPowerSupply)
    {
        _name = innerPowerSupply.Name;
        _peakLoadPower = innerPowerSupply.PeakLoadPower;
    }

    public PowerSupplyBuilder WithName(Name name)
    {
        _name = name;
        return this;
    }

    public PowerSupplyBuilder WithPeakLoadPower(Watt peakLoadPower)
    {
        _peakLoadPower = peakLoadPower;
        return this;
    }

    public PowerSupply Build()
    {
        return new PowerSupply(
            _name,
            _peakLoadPower);
    }
}