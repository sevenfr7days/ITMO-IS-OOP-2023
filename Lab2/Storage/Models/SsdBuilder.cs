using Itmo.ObjectOrientedProgramming.Lab2.Storage.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Storage.Models;

public class SsdBuilder : ISsdBuilder
{
    private Name? _name;
    private MemorySize? _capacity;
    private Watt? _powerConsumption;
    private int? _maximumSpeedWork;
    private ConnectionVariant? _connectionVariant;

    public SsdBuilder(ISsd innerSsd)
    {
        _name = innerSsd.Name;
        _capacity = innerSsd.Capacity;
        _powerConsumption = innerSsd.PowerConsumption;
        _maximumSpeedWork = innerSsd.MaximumSpeedWork;
        _connectionVariant = innerSsd.ConnectionVariant;
    }

    public SsdBuilder WithName(Name name)
    {
        _name = name;
        return this;
    }

    public SsdBuilder WithCapacity(MemorySize capacity)
    {
        _capacity = capacity;
        return this;
    }

    public SsdBuilder WithPowerConsumption(Watt powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public SsdBuilder WithMaximumSpeedWork(int maximumSpeedWork)
    {
        _maximumSpeedWork = maximumSpeedWork;
        return this;
    }

    public SsdBuilder WithConnectionVariant(ConnectionVariant connectionVariant)
    {
        _connectionVariant = connectionVariant;
        return this;
    }

    public Ssd Build()
    {
        return new Ssd(
            _name,
            _capacity,
            _powerConsumption,
            _maximumSpeedWork,
            _connectionVariant);
    }
}