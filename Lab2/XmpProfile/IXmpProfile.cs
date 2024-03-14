using Itmo.ObjectOrientedProgramming.Lab2.DifferentThings;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.XmpProfile;

public interface IXmpProfile : IComponent
{
    int CL { get; }
    int TRCD { get; }
    int TRP { get; }
    int TRAS { get; }
    Voltage Voltage { get; }
    Megahertz Frequency { get; }
}