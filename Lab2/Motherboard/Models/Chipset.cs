using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Motherboard.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;
using Itmo.ObjectOrientedProgramming.Lab2.XmpProfile;

namespace Itmo.ObjectOrientedProgramming.Lab2.Motherboard.Models;

public class Chipset : IChipset
{
    public Chipset(ICollection<Megahertz> supportedRamFrequency, ICollection<IXmpProfile> supportedXmpProfiles)
    {
        SupportedRamFrequency = supportedRamFrequency;
        SupportedXmpProfiles = supportedXmpProfiles;
    }

    public ICollection<Megahertz> SupportedRamFrequency { get; }
    public ICollection<IXmpProfile> SupportedXmpProfiles { get; }
}