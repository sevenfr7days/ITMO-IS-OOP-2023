using Itmo.ObjectOrientedProgramming.Lab2.Storage.Models;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Storage.Entity;

public interface ISsdBuilder
{
    public SsdBuilder WithName(Name name);

    public SsdBuilder WithCapacity(MemorySize capacity);

    public SsdBuilder WithPowerConsumption(Watt powerConsumption);

    public SsdBuilder WithMaximumSpeedWork(int maximumSpeedWork);

    public SsdBuilder WithConnectionVariant(ConnectionVariant connectionVariant);

    public Ssd Build();
}