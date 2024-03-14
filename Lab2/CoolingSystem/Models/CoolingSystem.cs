using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.CoolingSystem.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.CoolingSystem.Models;

public class CoolingSystem : ICoolingSystem
{
    public CoolingSystem(Name? name, Millimeters? sizeX, Millimeters? sizeY, Millimeters? sizeZ, Watt? maxTdp, ICollection<Socket>? supportedSockets)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        SizeX = sizeX ?? throw new ArgumentNullException(nameof(sizeX));
        SizeY = sizeY ?? throw new ArgumentNullException(nameof(sizeY));
        SizeZ = sizeZ ?? throw new ArgumentNullException(nameof(sizeZ));
        MaxTdp = maxTdp ?? throw new ArgumentNullException(nameof(maxTdp));
        SupportedSockets = supportedSockets ?? throw new ArgumentNullException(nameof(supportedSockets));
    }

    public Name Name { get; }
    public Millimeters SizeX { get; }
    public Millimeters SizeY { get; }
    public Millimeters SizeZ { get; }
    public Watt MaxTdp { get; }
    public ICollection<Socket> SupportedSockets { get; }
}