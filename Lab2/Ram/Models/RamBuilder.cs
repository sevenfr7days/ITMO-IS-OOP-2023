using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Ram.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;
using Itmo.ObjectOrientedProgramming.Lab2.XmpProfile;

namespace Itmo.ObjectOrientedProgramming.Lab2.Ram.Models;

public class RamBuilder : IRamBuilder
{
    private Name? _name;
    private MemorySize? _availableMemorySize;
    private ICollection<(Megahertz JedecFrequency, Voltage JedecVoltage)>? _jedecFrequenciesAndVoltages;
    private ICollection<IXmpProfile>? _xmpProfiles;
    private FormFactor? _formFactor;
    private Version? _ddrStandard;
    private Watt? _powerConsumption;

    public RamBuilder(IRam innerRam)
    {
        _name = innerRam.Name;
        _availableMemorySize = innerRam.AvailableMemorySize;
        _jedecFrequenciesAndVoltages = innerRam.JedecFrequenciesAndVoltages;
        _xmpProfiles = innerRam.XmpProfiles;
        _formFactor = innerRam.FormFactor;
        _ddrStandard = innerRam.DdrStandard;
        _powerConsumption = innerRam.PowerConsumption;
    }

    public RamBuilder()
    {
    }

    public RamBuilder WithName(Name name)
    {
        _name = name;
        return this;
    }

    public RamBuilder WithAvailableMemorySize(MemorySize availableMemorySize)
    {
        _availableMemorySize = availableMemorySize;
        return this;
    }

    public RamBuilder WithJedecFrequenciesAndVoltages(
        ICollection<(Megahertz JedecFrequency, Voltage JedecVoltage)> jedecFrequenciesAndVoltages)
    {
        _jedecFrequenciesAndVoltages = jedecFrequenciesAndVoltages;
        return this;
    }

    public RamBuilder WithXmpProfiles(ICollection<IXmpProfile> xmpProfiles)
    {
        _xmpProfiles = xmpProfiles;
        return this;
    }

    public RamBuilder WithFormFactor(FormFactor formFactor)
    {
        _formFactor = formFactor;
        return this;
    }

    public RamBuilder WithDdrStandard(Version ddrStandard)
    {
        _ddrStandard = ddrStandard;
        return this;
    }

    public RamBuilder WithPowerConsumption(Watt powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public Ram Build()
    {
        return new Ram(
            _name,
            _availableMemorySize,
            _jedecFrequenciesAndVoltages,
            _xmpProfiles,
            _formFactor,
            _ddrStandard,
            _powerConsumption);
    }
}