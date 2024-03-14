using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.XmpProfile;

public class XmpBuilder : IXmpProfileBuilder
{
    private Name? _name;
    private int? _cl;
    private int? _trcd;
    private int? _trp;
    private int? _tras;
    private Voltage? _voltage;
    private Megahertz? _frequency;

    public XmpBuilder()
    {
    }

    public XmpBuilder(IXmpProfile innerXmpProfile)
    {
        _name = innerXmpProfile.Name;
        _cl = innerXmpProfile.CL;
        _trcd = innerXmpProfile.TRCD;
        _trp = innerXmpProfile.TRP;
        _tras = innerXmpProfile.TRAS;
        _voltage = innerXmpProfile.Voltage;
        _frequency = innerXmpProfile.Frequency;
    }

    public XmpBuilder WithName(Name name)
    {
        _name = name;
        return this;
    }

    public XmpBuilder WithCl(int cl)
    {
        _cl = cl;
        return this;
    }

    public XmpBuilder WithTrcd(int trcd)
    {
        _trcd = trcd;
        return this;
    }

    public XmpBuilder WithTrp(int trp)
    {
        _trp = trp;
        return this;
    }

    public XmpBuilder WithTras(int tras)
    {
        _tras = tras;
        return this;
    }

    public XmpBuilder WithVoltage(Voltage voltage)
    {
        _voltage = voltage;
        return this;
    }

    public XmpBuilder WithFrequency(Megahertz frequency)
    {
        _frequency = frequency;
        return this;
    }

    public XmpProfile Build()
    {
        return new XmpProfile(
            _name,
            _cl,
            _trcd,
            _trp,
            _tras,
            _voltage,
            _frequency);
    }
}