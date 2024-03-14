using Itmo.ObjectOrientedProgramming.Lab2.Storage.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Storage.Models;

public class HddBuilder : IHddBuilder
{
    private Name? _name;
    private MemorySize? _capacity;
    private Watt? _powerConsumption;
    private SpindleSpeed? _spindleSpeed;

    public HddBuilder()
    {
    }

    public HddBuilder(IHdd innerHdd)
    {
        _name = innerHdd.Name;
        _capacity = innerHdd.Capacity;
        _powerConsumption = innerHdd.PowerConsumption;
        _spindleSpeed = innerHdd.SpindleSpeed;
    }

    public HddBuilder WithName(Name name)
    {
        _name = name;
        return this;
    }

    public HddBuilder WithCapacity(MemorySize capacity)
    {
        _capacity = capacity;
        return this;
    }

    public HddBuilder WithPowerConsumption(Watt powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public HddBuilder WithSpindleSpeed(SpindleSpeed spindleSpeed)
    {
        _spindleSpeed = spindleSpeed;
        return this;
    }

    public Hdd Build()
    {
        return new Hdd(
            _name,
            _capacity,
            _powerConsumption,
            _spindleSpeed);
    }
}