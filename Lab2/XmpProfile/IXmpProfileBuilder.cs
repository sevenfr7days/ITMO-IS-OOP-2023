using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.XmpProfile;

public interface IXmpProfileBuilder
{
    public XmpBuilder WithName(Name name);

    public XmpBuilder WithCl(int cl);

    public XmpBuilder WithTrcd(int trcd);

    public XmpBuilder WithTrp(int trp);

    public XmpBuilder WithTras(int tras);

    public XmpBuilder WithVoltage(Voltage voltage);

    public XmpBuilder WithFrequency(Megahertz frequency);

    public XmpProfile Build();
}