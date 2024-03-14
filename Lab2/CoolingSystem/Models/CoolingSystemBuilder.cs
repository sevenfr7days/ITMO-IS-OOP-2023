using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab2.CoolingSystem.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.CoolingSystem.Models;

public class CoolingSystemBuilder : ICoolingSystemBuilder
{
    private Name? _name;
    private Millimeters? _sizeX;
    private Millimeters? _sizeY;
    private Millimeters? _sizeZ;
    private Watt? _maxTdp;
    private ICollection<Socket>? _supportedSockets;

    public CoolingSystemBuilder(ICoolingSystem innerCoolingSystem)
    {
        _name = innerCoolingSystem.Name;
        _sizeX = innerCoolingSystem.SizeX;
        _sizeY = innerCoolingSystem.SizeY;
        _sizeZ = innerCoolingSystem.SizeZ;
        _maxTdp = innerCoolingSystem.MaxTdp;
        _supportedSockets = innerCoolingSystem.SupportedSockets;
    }

    public CoolingSystemBuilder()
    {
        _supportedSockets = new Collection<Socket>();
    }

    public CoolingSystemBuilder WithName(Name name)
    {
        _name = name;
        return this;
    }

    public CoolingSystemBuilder WithSize(Millimeters x, Millimeters y, Millimeters z)
    {
        _sizeX = x;
        _sizeY = y;
        _sizeZ = z;
        return this;
    }

    public CoolingSystemBuilder WithMaxTdp(Watt maxTdp)
    {
        _maxTdp = maxTdp;
        return this;
    }

    public CoolingSystemBuilder WithSupportedSockets(ICollection<Socket> sockets)
    {
        _supportedSockets = sockets;
        return this;
    }

    public CoolingSystem Build()
    {
        return new CoolingSystem(
            _name,
            _sizeX,
            _sizeY,
            _sizeZ,
            _maxTdp,
            _supportedSockets);
    }
}