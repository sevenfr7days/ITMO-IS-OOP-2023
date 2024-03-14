using System;
using Itmo.ObjectOrientedProgramming.Lab2.Storage.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Storage.Models;

public class Hdd : IHdd
{
    public Hdd(Name? name, MemorySize? capacity, Watt? powerConsumption, SpindleSpeed? spindleSpeed)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Capacity = capacity ?? throw new ArgumentNullException(nameof(capacity));
        PowerConsumption = powerConsumption ?? throw new ArgumentNullException(nameof(powerConsumption));
        SpindleSpeed = spindleSpeed ?? throw new ArgumentNullException(nameof(spindleSpeed));
    }

    public MemorySize Capacity { get; }
    public Watt PowerConsumption { get; }
    public SpindleSpeed SpindleSpeed { get; }
    public Name Name { get; }
}