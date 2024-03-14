using Itmo.ObjectOrientedProgramming.Lab2.Storage.Models;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Storage.Entity;

public interface IHddBuilder
{
    public HddBuilder WithName(Name name);

    public HddBuilder WithCapacity(MemorySize capacity);

    public HddBuilder WithPowerConsumption(Watt powerConsumption);

    public HddBuilder WithSpindleSpeed(SpindleSpeed spindleSpeed);

    public Hdd Build();
}