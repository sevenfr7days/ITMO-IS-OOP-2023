using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.GPU.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.PcCase.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Validators;

public class GpuSizeValidation
{
    private readonly ICollection<IGpu> _gpus;
    private readonly IPcCase? _pcCase;

    public GpuSizeValidation(ICollection<IGpu> gpus, IPcCase? pcCase)
    {
        _gpus = gpus;
        _pcCase = pcCase;
    }

    public SolutionMessage Validate()
    {
        bool isMatch = true;
        if (_pcCase is null) return new SolutionMessage.Fail("Computer must have a case");

        foreach (IGpu gpu in _gpus)
        {
            isMatch = isMatch && (gpu.Length.Amount <= _pcCase.MaxGpuLength.Amount) && (gpu.Width.Amount <= _pcCase.MaxGpuWidth.Amount);
        }

        if (isMatch)
        {
            return new SolutionMessage.Success();
        }

        return new SolutionMessage.Fail("Gpu's are too large for this computer case");
    }
}