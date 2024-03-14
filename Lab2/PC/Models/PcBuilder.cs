using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab2.Bios.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.CoolingSystem.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.Cpu.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.GPU.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.Motherboard.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.PC.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.PcCase.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.PowerSupply.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.Ram.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.Storage.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.Validators;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;
using Itmo.ObjectOrientedProgramming.Lab2.WiFiAdapter.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.XmpProfile;

namespace Itmo.ObjectOrientedProgramming.Lab2.PC.Models;

public class PcBuilder
{
    private IMotherboard? _motherboard;
    private ICpu? _cpu;
    private IBios? _bios;
    private ICoolingSystem? _coolingSystem;
    private ICollection<IRam> _ram;
    private ICollection<ISsd> _ssds;
    private ICollection<IHdd> _hdds;
    private IXmpProfile? _xmpProfile;
    private IPcCase? _pcCase;
    private IPowerSupply? _powerSupply;
    private ICollection<IGpu> _gpus;
    private IWiFiAdapter? _wiFiAdapter;

    public PcBuilder(IPc innerPc)
    {
        _motherboard = innerPc.Motherboard;
        _cpu = innerPc.Cpu;
        _bios = innerPc.Bios;
        _coolingSystem = innerPc.CoolingSystem;
        _ram = innerPc.Rams;
        _ssds = innerPc.Ssds;
        _hdds = innerPc.Hdds;
        _xmpProfile = innerPc.XmpProfile;
        _pcCase = innerPc.PcPcCase;
        _powerSupply = innerPc.PowerSupply;
        _gpus = innerPc.Gpus;
        _wiFiAdapter = innerPc.WiFiAdapter;
    }

    public PcBuilder()
    {
        _gpus = new Collection<IGpu>();
        _ram = new Collection<IRam>();
        _ssds = new Collection<ISsd>();
        _hdds = new Collection<IHdd>();
    }

    public PcBuilder SetMotherboard(IMotherboard motherboard)
    {
        _motherboard = motherboard;
        return this;
    }

    public PcBuilder SetCpu(ICpu cpu)
    {
        _cpu = cpu;
        return this;
    }

    public PcBuilder SetBios(IBios bios)
    {
        _bios = bios;
        return this;
    }

    public PcBuilder SetCoolingSystem(ICoolingSystem coolingSystem)
    {
        _coolingSystem = coolingSystem;
        return this;
    }

    public PcBuilder SetRam(ICollection<IRam> ram)
    {
        _ram = ram;
        return this;
    }

    public PcBuilder SetGpu(ICollection<IGpu> gpus)
    {
        _gpus = gpus;
        return this;
    }

    public PcBuilder SetSsds(ICollection<ISsd> ssds)
    {
        _ssds = ssds;
        return this;
    }

    public PcBuilder SetHdds(ICollection<IHdd> hdds)
    {
        _hdds = hdds;
        return this;
    }

    public PcBuilder SetXmpProfile(IXmpProfile xmpProfile)
    {
        _xmpProfile = xmpProfile;
        return this;
    }

    public PcBuilder SetPcCase(IPcCase pcCase)
    {
        _pcCase = pcCase;
        return this;
    }

    public PcBuilder SetPowerSupply(IPowerSupply powerSupply)
    {
        _powerSupply = powerSupply;
        return this;
    }

    public PcBuilder SetWifiAdapter(IWiFiAdapter wiFiAdapter)
    {
        _wiFiAdapter = wiFiAdapter;
        return this;
    }

    public PcBuildResult Build()
    {
        if (Validate().IsValid)
        {
            return new PcBuildResult(
                new Pc(
                    _motherboard,
                    _cpu,
                    _bios,
                    _coolingSystem,
                    _ram,
                    _ssds,
                    _hdds,
                    _xmpProfile,
                    _pcCase,
                    _powerSupply,
                    _gpus,
                    _wiFiAdapter),
                new PcCreatingResult(Validate().SolutionMessages).GetPcCreatingResult());
        }

        return new PcBuildResult(null, new PcCreatingResult(Validate().SolutionMessages).GetPcCreatingResult());
    }

    private ValidationResult Validate()
    {
        Collection<SolutionMessage> messages = new();
        bool isValid = true;
        var biosMatchValidation = new BiosMatchValidation(_bios, _cpu);
        var gpuSizeValidation = new GpuSizeValidation(_gpus, _pcCase);
        var motherboardFormFactorValidation = new MotherboardFormfactorValidation(_motherboard, _pcCase);
        var ramValidation = new RamValidation(_ram, _motherboard);
        var socketMatchValidation = new SocketMatchValidation(_cpu, _motherboard, _coolingSystem);
        var validateSataAndPciPorts = new ValidateSataAndPciPorts(
            _motherboard,
            _hdds,
            _ssds,
            _gpus);
        var coolingSystemTdpValidation = new CoolingSystemTdpValidation(_coolingSystem, _cpu);
        if (_xmpProfile is not null && _ram.Count != 0)
        {
            var xmpProfileValidation = new XmpProfileValidation(_xmpProfile, _ram, _motherboard);
            messages.Add(xmpProfileValidation.Validate());
        }

        messages.Add(biosMatchValidation.Validate());
        messages.Add(gpuSizeValidation.Validate());
        messages.Add(motherboardFormFactorValidation.Validate());
        messages.Add(ramValidation.Validate());
        messages.Add(socketMatchValidation.Validate());
        messages.Add(validateSataAndPciPorts.Validate());
        messages.Add(coolingSystemTdpValidation.Validate());

        foreach (SolutionMessage message in messages)
        {
            if (message is SolutionMessage.Fail)
            {
                isValid = false;
            }
        }

        return new ValidationResult(isValid, messages);
    }
}