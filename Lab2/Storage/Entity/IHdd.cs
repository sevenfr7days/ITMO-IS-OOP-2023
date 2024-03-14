using Itmo.ObjectOrientedProgramming.Lab2.DifferentThings;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Storage.Entity;

public interface IHdd : IComponent
{
    MemorySize Capacity { get; }
    Watt PowerConsumption { get; }
    SpindleSpeed SpindleSpeed { get; }
}