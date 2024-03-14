using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.GPU.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.Motherboard.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.Storage.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Validators;

public class ValidateSataAndPciPorts
{
    private readonly int _pciPortsAmount;
    private readonly int _sataPortsAmount;
    private readonly ICollection<IHdd> _hdds;
    private readonly ICollection<ISsd> _ssds;
    private readonly ICollection<IGpu> _gpus;

    public ValidateSataAndPciPorts(
        IMotherboard? motherboard,
        ICollection<IHdd> hdds,
        ICollection<ISsd> ssds,
        ICollection<IGpu> gpus)
    {
        if (motherboard is not null)
        {
            _pciPortsAmount = motherboard.PciLinesQuantity.Amount;
            _sataPortsAmount = motherboard.SataPortsQuantity.Amount;
        }
        else
        {
            _pciPortsAmount = _sataPortsAmount = 0;
        }

        _hdds = hdds;
        _ssds = ssds;
        _gpus = gpus;
    }

    public SolutionMessage Validate()
    {
        if (_pciPortsAmount >= _ssds.Count(vSsd => vSsd.ConnectionVariant.Connection == "SATA") &&
            _sataPortsAmount >= _ssds.Count(vSsd => vSsd.ConnectionVariant.Connection == "PCI") + _gpus.Count)
        {
            return new SolutionMessage.Success();
        }

        return new SolutionMessage.Fail("The number of PCI or SATA ports is not enough for this solution");
    }
}