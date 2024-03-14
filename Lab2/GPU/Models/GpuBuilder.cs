using Itmo.ObjectOrientedProgramming.Lab2.GPU.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.GPU.Models;

public class GpuBuilder : IGpuBuilder
{
    private Name? _name;
    private Millimeters? _length;
    private Millimeters? _width;
    private Version? _pcieVersion;
    private Megahertz? _chipFrequency;
    private Watt? _powerConsumption;
    private MemorySize? _memory;

    public GpuBuilder()
    {
    }

    public GpuBuilder(IGpu innerGpu)
    {
        _name = innerGpu.Name;
        _length = innerGpu.Length;
        _width = innerGpu.Width;
        _pcieVersion = innerGpu.PcieVersion;
        _chipFrequency = innerGpu.ChipFrequency;
        _powerConsumption = innerGpu.PowerConsumption;
    }

    public GpuBuilder WithName(Name name)
    {
        _name = name;
        return this;
    }

    public GpuBuilder WithLength(Millimeters length)
    {
        _length = length;
        return this;
    }

    public GpuBuilder WithWidth(Millimeters width)
    {
        _width = width;
        return this;
    }

    public GpuBuilder WithMemory(MemorySize memory)
    {
        _memory = memory;
        return this;
    }

    public GpuBuilder WithPcieVersion(Version pcieVersion)
    {
        _pcieVersion = pcieVersion;
        return this;
    }

    public GpuBuilder WithChipFrequency(Megahertz chipFrequency)
    {
        _chipFrequency = chipFrequency;
        return this;
    }

    public GpuBuilder WithPowerConsumption(Watt powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public Gpu Build()
    {
        return new Gpu(
            _name,
            _length,
            _width,
            _pcieVersion,
            _chipFrequency,
            _powerConsumption,
            _memory);
    }
}