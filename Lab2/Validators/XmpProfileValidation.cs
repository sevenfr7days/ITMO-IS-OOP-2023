using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Motherboard.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.Ram.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;
using Itmo.ObjectOrientedProgramming.Lab2.XmpProfile;

namespace Itmo.ObjectOrientedProgramming.Lab2.Validators;

public class XmpProfileValidation
{
    private readonly IXmpProfile? _xmpProfile;
    private readonly ICollection<IRam> _rams;
    private readonly IMotherboard? _motherboard;

    public XmpProfileValidation(IXmpProfile? xmpProfile, ICollection<IRam> rams, IMotherboard? motherboard)
    {
        _xmpProfile = xmpProfile;
        _rams = rams;
        _motherboard = motherboard;
    }

    public SolutionMessage Validate()
    {
        foreach (IRam vRam in _rams)
        {
            if (vRam.XmpProfiles.All(xmpProfile => xmpProfile != _xmpProfile)) return new SolutionMessage.Fail("XMP computer profile is not supported by RAM");
        }

        if (_motherboard is not null &&
            _motherboard.Chipset.SupportedXmpProfiles.Any(xmpProfile => xmpProfile == _xmpProfile))
        {
            return new SolutionMessage.Success();
        }

        return new SolutionMessage.Fail("Motherboard chipset does not support this XMP profile");
    }
}