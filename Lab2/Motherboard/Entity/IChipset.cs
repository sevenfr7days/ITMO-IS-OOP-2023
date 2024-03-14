using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;
using Itmo.ObjectOrientedProgramming.Lab2.XmpProfile;

namespace Itmo.ObjectOrientedProgramming.Lab2.Motherboard.Entity;

public interface IChipset
{
    ICollection<Megahertz> SupportedRamFrequency { get; }
    ICollection<IXmpProfile> SupportedXmpProfiles { get; }
}