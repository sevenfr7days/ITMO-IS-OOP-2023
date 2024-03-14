using Itmo.ObjectOrientedProgramming.Lab2.Bios.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.Cpu.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Validators;

public class BiosMatchValidation
{
    private readonly IBios? _bios;
    private readonly ICpu? _cpu;

    public BiosMatchValidation(IBios? bios, ICpu? cpu)
    {
        _bios = bios;
        _cpu = cpu;
    }

    public SolutionMessage Validate()
    {
        if (_bios is not null && _cpu is not null && _bios.SupportedCpus.Contains(_cpu))
        {
            return new SolutionMessage.Success();
        }
        else
        {
            return new SolutionMessage.Fail("Cpu is not supported by this bios");
        }
    }
}