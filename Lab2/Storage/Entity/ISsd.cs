using Itmo.ObjectOrientedProgramming.Lab2.DifferentThings;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Storage.Entity;

public interface ISsd : IComponent
{
    MemorySize Capacity { get; }
    Watt PowerConsumption { get; }
    int MaximumSpeedWork { get; }
    ConnectionVariant ConnectionVariant { get; }
}