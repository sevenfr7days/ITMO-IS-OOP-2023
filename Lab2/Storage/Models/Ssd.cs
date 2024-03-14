using System;
using Itmo.ObjectOrientedProgramming.Lab2.Storage.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Storage.Models;

public class Ssd : ISsd
{
    public Ssd(
        Name? name,
        MemorySize? capacity,
        Watt? powerConsumption,
        int? maximumSpeedWork,
        ConnectionVariant? connectionVariant)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Capacity = capacity ?? throw new ArgumentNullException(nameof(capacity));
        PowerConsumption = powerConsumption ?? throw new ArgumentNullException(nameof(powerConsumption));
        MaximumSpeedWork = maximumSpeedWork ?? throw new ArgumentNullException(nameof(maximumSpeedWork));
        ConnectionVariant = connectionVariant ?? throw new ArgumentNullException(nameof(connectionVariant));
    }

    public MemorySize Capacity { get; }
    public Watt PowerConsumption { get; }
    public int MaximumSpeedWork { get; }
    public ConnectionVariant ConnectionVariant { get; }
    public Name Name { get; }
}