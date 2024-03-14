using Itmo.ObjectOrientedProgramming.Lab2.GPU.Models;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.GPU.Entity;

public interface IGpuBuilder
{
    public GpuBuilder WithName(Name name);

    public GpuBuilder WithLength(Millimeters length);

    public GpuBuilder WithWidth(Millimeters width);

    public GpuBuilder WithMemory(MemorySize memory);

    public GpuBuilder WithPcieVersion(Version pcieVersion);

    public GpuBuilder WithChipFrequency(Megahertz chipFrequency);

    public GpuBuilder WithPowerConsumption(Watt powerConsumption);

    public Gpu Build();
}