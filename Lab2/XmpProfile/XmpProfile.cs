using System;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.XmpProfile;

public class XmpProfile : IXmpProfile
{
    public XmpProfile(
        Name? name,
        int? cl,
        int? trcd,
        int? trp,
        int? tras,
        Voltage? voltage,
        Megahertz? frequency)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        CL = cl ?? throw new ArgumentNullException(nameof(cl));
        TRCD = trcd ?? throw new ArgumentNullException(nameof(trcd));
        TRP = trp ?? throw new ArgumentNullException(nameof(trp));
        TRAS = tras ?? throw new ArgumentNullException(nameof(tras));
        Voltage = voltage ?? throw new ArgumentNullException(nameof(voltage));
        Frequency = frequency ?? throw new ArgumentNullException(nameof(frequency));
    }

    public int CL { get; }
    public int TRCD { get; }
    public int TRP { get; }
    public int TRAS { get; }
    public Voltage Voltage { get; }
    public Megahertz Frequency { get; }
    public Name Name { get; }
}