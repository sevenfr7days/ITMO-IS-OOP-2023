using System;
using Itmo.ObjectOrientedProgramming.Lab2.GPU.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;
using Version = Itmo.ObjectOrientedProgramming.Lab2.ValueObjects.Version;

namespace Itmo.ObjectOrientedProgramming.Lab2.GPU.Models;

public class Gpu : IGpu
{
    public Gpu(
        Name? name,
        Millimeters? length,
        Millimeters? width,
        Version? pcieVersion,
        Megahertz? chipFrequency,
        Watt? powerConsumption,
        MemorySize? memory)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Length = length ?? throw new ArgumentNullException(nameof(length));
        Width = width ?? throw new ArgumentNullException(nameof(width));
        PcieVersion = pcieVersion ?? throw new ArgumentNullException(nameof(pcieVersion));
        ChipFrequency = chipFrequency ?? throw new ArgumentNullException(nameof(chipFrequency));
        PowerConsumption = powerConsumption ?? throw new ArgumentNullException(nameof(powerConsumption));
        Memory = memory ?? throw new ArgumentNullException(nameof(memory));
    }

    public Millimeters Length { get; }
    public Millimeters Width { get; }
    public MemorySize Memory { get; }
    public Version PcieVersion { get; }
    public Megahertz ChipFrequency { get; }
    public Watt PowerConsumption { get; }
    public Name Name { get; }
}