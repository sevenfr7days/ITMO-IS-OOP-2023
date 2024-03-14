using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Cpu.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.GPU.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Validators;

public class VideoCoreValidation
{
    private readonly ICpu? _cpu;
    private readonly ICollection<IGpu> _gpus;

    public VideoCoreValidation(ICpu? cpu, ICollection<IGpu> gpus)
    {
        _cpu = cpu;
        _gpus = gpus;
    }

    public SolutionMessage Validate()
    {
        if (_cpu is not null && _cpu.IsVideoCoreIntegrated)
        {
            return new SolutionMessage.Success();
        }

        return new SolutionMessage.Fail("The computer must have at least 1 video core");
    }
}