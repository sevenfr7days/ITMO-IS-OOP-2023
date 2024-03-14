using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Motherboard.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.Ram.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Validators;

public class RamValidation
{
    private readonly ICollection<IRam> _ram;
    private readonly IMotherboard? _motherboard;

    public RamValidation(ICollection<IRam> ram, IMotherboard? motherboard)
    {
        _ram = ram;
        _motherboard = motherboard;
    }

    public SolutionMessage Validate()
    {
        if (_motherboard is null) return new SolutionMessage.Fail("Computer must have a motherboard");

        if (_ram.Any(ram => ram.DdrStandard != _motherboard.DdrStandard))
        {
            return new SolutionMessage.Fail("DDR motherboard standard is not compatible with RAM");
        }

        return new SolutionMessage.Success();
    }
}