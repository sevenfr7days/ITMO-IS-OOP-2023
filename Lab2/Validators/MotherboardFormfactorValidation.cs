using Itmo.ObjectOrientedProgramming.Lab2.Motherboard.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.PcCase.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Validators;

public class MotherboardFormfactorValidation
{
    private readonly IMotherboard? _motherboard;
    private readonly IPcCase? _pcCase;

    public MotherboardFormfactorValidation(IMotherboard? motherboard, IPcCase? pcCase)
    {
        _motherboard = motherboard;
        _pcCase = pcCase;
    }

    public SolutionMessage Validate()
    {
        if (_pcCase is null)
        {
            return new SolutionMessage.Fail("Computer must have a case");
        }

        if (_motherboard is null)
        {
            return new SolutionMessage.Fail("Computer must have a motherboard");
        }

        if (!_pcCase.SupportedMotherboardsFormFactors.Contains(_motherboard.FormFactor))
        {
            return new SolutionMessage.Fail("The computer case does not support the motherboard form factor");
        }

        return new SolutionMessage.Success();
    }
}