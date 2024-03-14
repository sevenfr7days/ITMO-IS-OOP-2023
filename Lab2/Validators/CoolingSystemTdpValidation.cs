using Itmo.ObjectOrientedProgramming.Lab2.CoolingSystem.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.Cpu.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Validators;

public class CoolingSystemTdpValidation
{
    private readonly ICoolingSystem? _coolingSystem;
    private readonly ICpu? _cpu;

    public CoolingSystemTdpValidation(ICoolingSystem? coolingSystem, ICpu? cpu)
    {
        _coolingSystem = coolingSystem;
        _cpu = cpu;
    }

    public SolutionMessage Validate()
    {
        if (_coolingSystem is null || _cpu is null)
        {
            return new SolutionMessage.Fail("The computer must have a cooling system and cpu");
        }

        if (_coolingSystem.MaxTdp.Amount >= _cpu.Tdp.Amount)
        {
            return new SolutionMessage.Success();
        }
        else
        {
            return new SolutionMessage.Warning("Warning! The cooling system is too weak for this CPU");
        }
    }
}