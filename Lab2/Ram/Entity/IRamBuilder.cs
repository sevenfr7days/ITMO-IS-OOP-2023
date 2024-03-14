using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Ram.Models;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;
using Itmo.ObjectOrientedProgramming.Lab2.XmpProfile;

namespace Itmo.ObjectOrientedProgramming.Lab2.Ram.Entity;

public interface IRamBuilder
{
    public RamBuilder WithName(Name name);

    public RamBuilder WithAvailableMemorySize(MemorySize availableMemorySize);

    public RamBuilder WithJedecFrequenciesAndVoltages(
        ICollection<(Megahertz JedecFrequency, Voltage JedecVoltage)> jedecFrequenciesAndVoltages);

    public RamBuilder WithXmpProfiles(ICollection<IXmpProfile> xmpProfiles);

    public RamBuilder WithFormFactor(FormFactor formFactor);

    public RamBuilder WithDdrStandard(Version ddrStandard);

    public RamBuilder WithPowerConsumption(Watt powerConsumption);

    public Models.Ram Build();
}