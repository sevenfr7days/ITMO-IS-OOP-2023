using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Cpu.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Cpu.Models;

public class CpuBuilder : ICpuBuilder
{
    private Name? _name;
    private Gigahertz? _coreFrequency;
    private Quantity? _coresQuantity;
    private Socket? _socket;
    private bool? _isVideoCoreIntegrated;
    private Watt? _tdp;
    private Watt? _powerConsumption;
    private ICollection<Megahertz>? _supportedMemoryFrequencies;

    public CpuBuilder(ICpu innerCpu)
    {
        _name = innerCpu.Name;
        _coreFrequency = innerCpu.CoreFrequency;
        _coresQuantity = innerCpu.CoresQuantity;
        _socket = innerCpu.Socket;
        _isVideoCoreIntegrated = innerCpu.IsVideoCoreIntegrated;
        _supportedMemoryFrequencies = innerCpu.SupportedMemoryFrequencies;
        _tdp = innerCpu.Tdp;
        _powerConsumption = innerCpu.PowerConsumption;
    }

    public CpuBuilder()
    {
        _supportedMemoryFrequencies = new List<Megahertz>();
    }

    public CpuBuilder WithName(Name name)
    {
        _name = name;
        return this;
    }

    public CpuBuilder WithCoreFrequency(Gigahertz frequency)
    {
        _coreFrequency = frequency;
        return this;
    }

    public CpuBuilder WithCoresQuantity(Quantity quantity)
    {
        _coresQuantity = quantity;
        return this;
    }

    public CpuBuilder WithSocket(Socket socket)
    {
        _socket = socket;
        return this;
    }

    public CpuBuilder WithIntegratedVideoCore(bool isIntegrated)
    {
        _isVideoCoreIntegrated = isIntegrated;
        return this;
    }

    public CpuBuilder WithSupportedMemoryFrequencies(ICollection<Megahertz> frequencies)
    {
        _supportedMemoryFrequencies = frequencies;
        return this;
    }

    public CpuBuilder WithTdp(Watt tdp)
    {
        _tdp = tdp;
        return this;
    }

    public CpuBuilder WithPowerConsumption(Watt powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public Cpu Build()
    {
        return new Cpu(
            _name,
            _coreFrequency,
            _coresQuantity,
            _socket,
            _isVideoCoreIntegrated,
            _supportedMemoryFrequencies,
            _tdp,
            _powerConsumption);
    }
}