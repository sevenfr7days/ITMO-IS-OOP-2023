using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Ram.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;
using Itmo.ObjectOrientedProgramming.Lab2.XmpProfile;
using Version = Itmo.ObjectOrientedProgramming.Lab2.ValueObjects.Version;

namespace Itmo.ObjectOrientedProgramming.Lab2.Ram.Models;

public class Ram : IRam
{
    public Ram(
        Name? name,
        MemorySize? availableMemorySize,
        ICollection<(Megahertz JedecFrequency, Voltage JedecVoltage)>? jedecFrequenciesAndVoltages,
        ICollection<IXmpProfile>? xmpProfiles,
        FormFactor? formFactor,
        Version? ddrStandard,
        Watt? powerConsumption)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        AvailableMemorySize = availableMemorySize ?? throw new ArgumentNullException(nameof(availableMemorySize));
        JedecFrequenciesAndVoltages = jedecFrequenciesAndVoltages ?? throw new ArgumentNullException(nameof(jedecFrequenciesAndVoltages));
        XmpProfiles = xmpProfiles ?? throw new ArgumentNullException(nameof(xmpProfiles));
        FormFactor = formFactor ?? throw new ArgumentNullException(nameof(formFactor));
        DdrStandard = ddrStandard ?? throw new ArgumentNullException(nameof(ddrStandard));
        PowerConsumption = powerConsumption ?? throw new ArgumentNullException(nameof(powerConsumption));
    }

    public MemorySize AvailableMemorySize { get; }
    public ICollection<(Megahertz JedecFrequency, Voltage JedecVoltage)> JedecFrequenciesAndVoltages { get; }
    public ICollection<IXmpProfile> XmpProfiles { get; }
    public FormFactor FormFactor { get; }
    public Version DdrStandard { get; }
    public Watt PowerConsumption { get; }
    public Name Name { get; }
}