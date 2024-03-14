using Itmo.ObjectOrientedProgramming.Lab2.CoolingSystem.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.Cpu.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.Motherboard.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Validators;

public class SocketMatchValidation
{
    private readonly ICpu? _cpu;
    private readonly IMotherboard? _motherboard;
    private readonly ICoolingSystem? _coolingSystem;

    public SocketMatchValidation(ICpu? cpu, IMotherboard? motherboard, ICoolingSystem? coolingSystem)
    {
        _cpu = cpu;
        _motherboard = motherboard;
        _coolingSystem = coolingSystem;
    }

    public SolutionMessage Validate()
    {
        if (_cpu is not null && _motherboard is not null && _coolingSystem is not null &&
            _cpu.Socket == _motherboard.Socket &&
            _coolingSystem.SupportedSockets.Contains(_cpu.Socket))
        {
            return new SolutionMessage.Success();
        }

        return new SolutionMessage.Fail("Motherboard, CPU and cooler sockets are not compatible");
    }
}