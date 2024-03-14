using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.DifferentThings;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;
using Itmo.ObjectOrientedProgramming.Lab2.XmpProfile;

namespace Itmo.ObjectOrientedProgramming.Lab2.Ram.Entity;

public interface IRam : IComponent
{
    MemorySize AvailableMemorySize { get; }
    ICollection<(Megahertz JedecFrequency, Voltage JedecVoltage)> JedecFrequenciesAndVoltages { get; }
    ICollection<IXmpProfile> XmpProfiles { get; }
    FormFactor FormFactor { get; }
    Version DdrStandard { get; }
    Watt PowerConsumption { get; }
}