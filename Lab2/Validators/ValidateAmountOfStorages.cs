using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Storage.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Validators;

public class ValidateAmountOfStorages
{
    private ICollection<IHdd> _hdds;
    private ICollection<ISsd> _ssds;

    public ValidateAmountOfStorages(ICollection<IHdd> hdds, ICollection<ISsd> ssds)
    {
        _hdds = hdds;
        _ssds = ssds;
    }

    public SolutionMessage Validate()
    {
        if (_ssds.Count != 0 || _hdds.Count != 0)
        {
            return new SolutionMessage.Success();
        }

        return new SolutionMessage.Fail("The computer must have at least 1 HDD or SSD");
    }
}