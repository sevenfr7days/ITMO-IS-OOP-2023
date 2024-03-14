using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Cpu.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.GPU.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.PowerSupply.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.Ram.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.Storage.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;
using Itmo.ObjectOrientedProgramming.Lab2.WiFiAdapter.Entity;

namespace Itmo.ObjectOrientedProgramming.Lab2.Validators;

public class PowerUnitPeakLoadValidate
{
    private readonly IPowerSupply? _powerSupply;
    private readonly ICpu? _cpu;
    private readonly ICollection<IGpu> _gpus;
    private readonly ICollection<IHdd> _hdds;
    private readonly ICollection<ISsd> _ssds;
    private readonly ICollection<IRam> _rams;
    private readonly IWiFiAdapter? _wiFiAdapter;

    public PowerUnitPeakLoadValidate(
        IPowerSupply powerSupply,
        ICpu cpu,
        ICollection<IGpu> gpus,
        ICollection<IHdd> hdds,
        ICollection<ISsd> ssds,
        ICollection<IRam> rams,
        IWiFiAdapter? wiFiAdapter)
    {
        _powerSupply = powerSupply;
        _cpu = cpu;
        _gpus = gpus;
        _hdds = hdds;
        _ssds = ssds;
        _rams = rams;
        _wiFiAdapter = wiFiAdapter;
    }

    public SolutionMessage Validate()
    {
        int pcPowerConsumption = 0;
        if (_cpu is not null)
        {
            pcPowerConsumption += _cpu.PowerConsumption.Amount;
        }

        foreach (IGpu gpu in _gpus)
        {
            pcPowerConsumption += gpu.PowerConsumption.Amount;
        }

        foreach (IHdd hdd in _hdds)
        {
            pcPowerConsumption += hdd.PowerConsumption.Amount;
        }

        foreach (IHdd ssd in _ssds)
        {
            pcPowerConsumption += ssd.PowerConsumption.Amount;
        }

        foreach (IRam ram in _rams)
        {
            pcPowerConsumption += ram.PowerConsumption.Amount;
        }

        if (_wiFiAdapter is not null)
        {
            pcPowerConsumption += _wiFiAdapter.PowerConsumption.Amount;
        }

        if (_powerSupply is not null && pcPowerConsumption * 0.8 <= _powerSupply.PeakLoadPower.Amount)
        {
            if (pcPowerConsumption <= _powerSupply.PeakLoadPower.Amount)
            {
                return new SolutionMessage.Success();
            }

            if (pcPowerConsumption * 0.7 <= _powerSupply.PeakLoadPower.Amount)
            {
                return new SolutionMessage.Warning("Warning! The power supply is running at its limit");
            }
        }

        return new SolutionMessage.Fail("The power supply is too weak for this solution");
    }
}